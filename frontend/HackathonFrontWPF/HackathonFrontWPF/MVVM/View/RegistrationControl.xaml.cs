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
        SolidColorBrush redBrush=(SolidColorBrush) new BrushConverter().ConvertFrom("#7a040d");
        SolidColorBrush greenBrush= (SolidColorBrush)new BrushConverter().ConvertFrom("#a7c958");

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
            if(btnGluten.Fill!=redBrush)
                btnGluten.Fill= redBrush;
            else
                btnGluten.Fill = greenBrush;
        }

        private void btnSoy_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isSoy = !isSoy;
            if (btnSoy.Fill != redBrush)
                btnSoy.Fill = redBrush;
            else
                btnSoy.Fill = greenBrush;
        }

        private void btnMilk_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isMilk = !isMilk;
            if (btnMilk.Fill != redBrush)
                btnMilk.Fill = redBrush;
            else
                btnMilk.Fill = greenBrush;
        }

        private void btnNuts_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isNuts = !isNuts;
            if (btnNuts.Fill != redBrush)
                btnNuts.Fill = redBrush;
            else
                btnNuts.Fill = greenBrush;
        }

        private void btnVegetarian_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isVegetarian = !isVegetarian;
            if (btnVegetarian.Fill != redBrush)
                btnVegetarian.Fill = redBrush;
            else
                btnVegetarian.Fill = greenBrush;
        }

        private void btnVegan_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isVegan = !isVegan;
            if (btnVegan.Fill != redBrush)
                btnVegan.Fill = redBrush;
            else
                btnVegan.Fill = greenBrush;
        }

        private void btnKosher_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isKosher= !isKosher;
            if (btnKosher.Fill != redBrush)
                btnKosher.Fill = redBrush;
            else
                btnKosher.Fill = greenBrush;
        }
    }
}
