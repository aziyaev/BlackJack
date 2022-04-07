using BlackJackLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlackJackGame
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Dealer Dealer { get; set; } = new Dealer();
        public HumanPlayer Player { get; set; } = new HumanPlayer("Cat Stepan", 1000);

        private GameStage stage = GameStage.BetWaiting;

        public MainWindow(Window owner)
        {
            Owner = owner;
            InitializeComponent();
        }

        private void PrepareToNewRound()
        {
            Dealer.DiscardSet();
            Player.DiscardSet();
            Player.Bet = 0;
            stage = GameStage.BetWaiting;
        }

        private void StartRound()
        {
            try
            {
                Dealer.ShuffleCards();
                Player.PickCard(Dealer.GiveCard());
                Player.PickCard(Dealer.GiveCard());
                Dealer.PickCard(Dealer.GiveCard());

                CheckWinner(Player, Dealer);
            }
            catch (RoundEndException ex)
            {
                Pay(ex.IsDealerWin);
                MessageBox.Show(ex.Message);
                IsGameOver();
                PrepareToNewRound();
            }
        }

        private void IsGameOver()
        {
            if (Player.Money > 0 && Dealer.Money <= 0)
            {
                MessageBox.Show("У дилера закончились монетки! Вы победили!");
                Close();
            }
            else if (Player.Money <= 0 && Dealer.Money > 0)
            {
                MessageBox.Show("У вас закончились монетки! Вы проиграли!");
                Close();
            }

        }

        private void CheckWinner(Player player, Player dealer)
        {
            if (player.Score == 21)
            {
                throw new RoundEndException(player);
            }
            if (dealer.Score <= 21 && player.Score > 21)
            {
                throw new RoundEndException(dealer);
            }
            if (dealer.Score == 21)
            {
                throw new RoundEndException(dealer);
            }
            if (player.Score <= 21 && dealer.Score > 21)
            {
                throw new RoundEndException(player);
            }
            if (stage == GameStage.DealersTurn && dealer.Score >= player.Score && dealer.Score <= 21)
            {
                throw new RoundEndException(dealer);
            }

        }

        private void Pay(bool isDealerWin)
        {
            if (isDealerWin)
            {
                Dealer.Money += Player.Bet;
            }
            else
            {
                Player.Money += Player.Bet * 2;
                Dealer.Money -= Player.Bet;
                if (Player.CardSet.Count == 2 && Player.Score == 21)
                {
                    Player.Money += Player.Bet / 2;
                    Dealer.Money -= Player.Bet / 2;
                }
            }
        }


        private void CardRequest_Click(object sender, RoutedEventArgs e)
        {
            if (!(stage == GameStage.PlayersTurn))
                return;

            try
            {
                Player.PickCard(Dealer.GiveCard());
                CheckWinner(Player, Dealer);
            }
            catch (RoundEndException ex)
            {
                Pay(ex.IsDealerWin);
                MessageBox.Show(ex.Message);
                IsGameOver();
                PrepareToNewRound();
            }
        }


        private void Enough_Click(object sender, RoutedEventArgs e)
        {
            if (!(stage == GameStage.PlayersTurn))
                return;

            try
            {
                stage = GameStage.DealersTurn;
                while (true)
                {
                    Dealer.MakeAutoMove(Player.Score);
                    CheckWinner(Player, Dealer);
                }
            }
            catch (RoundEndException ex)
            {
                Pay(ex.IsDealerWin);
                MessageBox.Show(ex.Message);
                IsGameOver();
                PrepareToNewRound();
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Show();
        }

        private void Bet_Click(object sender, MouseButtonEventArgs e)
        {
            if (!(stage == GameStage.BetWaiting))
                return;

            stage = GameStage.PlayersTurn;
            Player.MakeBet(int.Parse((sender as Image).Tag.ToString()));

            StartRound();
        }
    }
}
