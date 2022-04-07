using HackathonFrontWPF.MVVM.Model;
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
using WpfApp2;

namespace Hack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
            RegistrationControl regControl = new RegistrationControl();
            //mainGrid.Children.Add(regControl);
            //Grid.SetRow(regControl, 1);
            
            // -------- MOCKUP INGREDIENT LIST ---------
            List<Ingredient> ingLst = new List<Ingredient>();
            ingLst.Add(new Ingredient("aaa", "url", 200, 2));
            ingLst.Add(new Ingredient("bbb", "url", 200, 2));
            ingLst.Add(new Ingredient("ccc", "url", 200, 2));
            ingLst.Add(new Ingredient("aaa", "url", 200, 2));
            // -------- MOCKUP INGREDIENT LIST ---------

            SwipeControl swipeControl = new SwipeControl(ingLst);
            mainGrid.Children.Add(swipeControl);
            Grid.SetRow(swipeControl, 1);
        }


        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
