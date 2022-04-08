using HackathonFrontWPF.MVVM.Model;
using HackathonFrontWPF.MVVM.View;
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
        public SwipeControl swipeControl { get; set; }
        public RegistrationControl regControl { get; set; }
        public RecipiesControl recipControl { get; set; }
        public UserControl previousControl { get; set; }
        public UserControl currentControl { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);

            // -------- MOCKUP INGREDIENT LIST ---------
            List<Ingredient> ingLst = new List<Ingredient>();
            ingLst.Add(new Ingredient("aaa", "url", 200, 2));
            ingLst.Add(new Ingredient("bbb", "url", 200, 2));
            ingLst.Add(new Ingredient("ccc", "url", 200, 2));
            ingLst.Add(new Ingredient("DDD", "url", 200, 2));
            // -------- MOCKUP INGREDIENT LIST ---------

            regControl = new RegistrationControl(this);
            //mainGrid.Children.Add(regControl);
            //Grid.SetRow(regControl, 1);


            swipeControl = new SwipeControl(ingLst, this);
            loadControl(regControl);
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

        public void loadControl(UserControl ctrl)
        {
            if (!mainGrid.Children.Contains(ctrl))
                mainGrid.Children.Add(ctrl);
            currentControl = ctrl;
            if (ctrl == swipeControl)
                btnBack.Visibility = Visibility.Hidden;
            Grid.SetRow(ctrl, 1);
        }

        public void removeControl(UserControl ctrl)
        {
            mainGrid.Children.Remove(ctrl);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            removeControl(currentControl);
            loadControl(previousControl);
        }
    }
}
