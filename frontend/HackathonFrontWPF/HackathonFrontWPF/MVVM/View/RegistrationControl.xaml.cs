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

namespace Hack
{
    /// <summary>
    /// Interaction logic for RegistrationControl.xaml
    /// </summary>
    public partial class RegistrationControl : UserControl
    {
        public MainWindow mainWindow { get; set; }
        public bool isVegetarian { get; set; }
        public bool isVegan { get; set; }
        public bool isKosher { get; set; }
        public bool isGluten { get; set; }
        public bool isSoy { get; set; }
        public bool isMilk { get; set; }
        public bool isNuts { get; set; }

        public RegistrationControl(MainWindow main)
        {
            InitializeComponent();
            mainWindow = main;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.removeControl(this);
            mainWindow.loadControl(mainWindow.swipeControl);
        }

        private void btnGluten_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isGluten = !isGluten;
            if(btnGluten.Fill==Brushes.LightGreen)
                btnGluten.Fill=Brushes.PaleVioletRed;
            else
                btnGluten.Fill = Brushes.LightGreen;
        }

        private void btnSoy_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isSoy = !isSoy;
            if (btnSoy.Fill == Brushes.LightGreen)
                btnSoy.Fill = Brushes.PaleVioletRed;
            else
                btnSoy.Fill = Brushes.LightGreen;
        }

        private void btnMilk_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isMilk = !isMilk;
            if (btnMilk.Fill == Brushes.LightGreen)
                btnMilk.Fill = Brushes.PaleVioletRed;
            else
                btnMilk.Fill = Brushes.LightGreen;
        }

        private void btnNuts_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isNuts = !isNuts;
            if (btnNuts.Fill == Brushes.LightGreen)
                btnNuts.Fill = Brushes.PaleVioletRed;
            else
                btnNuts.Fill = Brushes.LightGreen;
        }

        private void btnVegetarian_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
