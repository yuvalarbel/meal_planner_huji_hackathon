using HackathonFrontWPF.MVVM.Model;
using HackathonFrontWPF.MVVM.View;
using Network;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using System.Threading;
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
            User user=new User("a","a","a",true,true,true,true,true,true,true);

            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(user);
            //var postResponse = await client.PostAsJsonAsync("http://172.29.120.240:8080/register_user", json);
            // create a List of Ingredient from postResponse
            //List<Ingredient> recipies = JsonConvert.DeserializeObject<List<Ingredient>>(postResponse.Content.ReadAsStringAsync().Result);

            List<Ingredient> ingLst = new List<Ingredient>();
            ingLst.Add(new Ingredient("Chicken", "C:/Users/User/Desktop/resources/ingredients/chicken.png", 200, 2));
            ingLst.Add(new Ingredient("Garlic", "C:/Users/User/Desktop/resources/ingredients/garlic.png", 200, 2));
            ingLst.Add(new Ingredient("Carrot", "C:/Users/User/Desktop/resources/ingredients/carrot.png", 200, 2));
            ingLst.Add(new Ingredient("Paprika", "C:/Users/User/Desktop/resources/ingredients/paprika.png", 200, 2));
            ingLst.Add(new Ingredient("Cheese", "C:/Users/User/Desktop/resources/ingredients/cheese.png", 200, 2));
            ingLst.Add(new Ingredient("Flour", "C:/Users/User/Desktop/resources/ingredients/flour.png", 200, 2));
            ingLst.Add(new Ingredient("Milk", "C:/Users/User/Desktop/resources/ingredients/milk.png", 200, 2));
            ingLst.Add(new Ingredient("Egg", "C:/Users/User/Desktop/resources/ingredients/egg1.png", 200, 2));
            // -------- MOCKUP INGREDIENT LIST ---------

            regControl = new RegistrationControl(this);
            //mainGrid.Children.Add(regControl);
            //Grid.SetRow(regControl, 1);


            swipeControl = new SwipeControl(ingLst, this);
            loadControl(new WelcomeWindow(this));
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
