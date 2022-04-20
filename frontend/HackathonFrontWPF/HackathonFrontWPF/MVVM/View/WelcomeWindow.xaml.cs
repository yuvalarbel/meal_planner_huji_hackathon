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
    /// Interaction logic for WelcomeWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : UserControl
    {
        public MainWindow mainWindow { get; set; }
        public WelcomeWindow(MainWindow main)
        {
            InitializeComponent();
            mainWindow = main;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.removeControl(this);
            mainWindow.loadControl(mainWindow.regControl);
        }
    }
}
