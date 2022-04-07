using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using BlackJackLibrary;

namespace BlackJackGame
{
    /// <summary>
    /// Interaction logic for CardControl.xaml
    /// </summary>
    public partial class CardControl : UserControl
    {
        public static readonly DependencyProperty CurrentCardProperty;

        static CardControl()
        {
            CurrentCardProperty = DependencyProperty.Register("CurrentCard", typeof(Card), typeof(CardControl));
        }

        public Card CurrentCard
        {
            get
            {
                return (Card)GetValue(CurrentCardProperty);
            }

            set
            {
                SetValue(CurrentCardProperty, value);
            }
        }
        public CardControl()
        {
            InitializeComponent();
        }
    }
}
