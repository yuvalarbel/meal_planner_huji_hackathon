using Hack;
using HackathonFrontWPF.MVVM.Model;
using HackathonFrontWPF.MVVM.View;
using System;
using System.Collections;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for SwipeControl.xaml
    /// </summary>
    public partial class SwipeControl : UserControl
    {

        public MainWindow mainWindow { get; set; }
        public List<Ingredient> ingredientLst { get; set; }
        public List<Ingredient> hasIngredientLst { get; set; }
        public List<IngredientControl> ingredientControlLst { get; set; }
        public List<Recipy> recipyLst { get; set; }
        public List<SingleRecipeControl> recipyControlLst { get; set; }

        public int currIngredientIndex { get; set; }
        public SwipeControl(List<Ingredient> ings, MainWindow main)
        {
            InitializeComponent();
            mainWindow = main;
            currIngredientIndex = 0;
            ingredientLst = ings;
            hasIngredientLst = new List<Ingredient>();
            ingredientControlLst = new List<IngredientControl>();
            recipyLst = new List<Recipy>();
            recipyControlLst = new List<SingleRecipeControl>();

            generateIngredientControls();
            generateRecipies();
        }


        void generateIngredientControls()
        {
            for (int i = 0; i < 3; i++)
            {
                generateIngredientControl();
            }
        }

        void updateIngredients(IngredientControl ctrl)
        {
            object j = ctrl.ingredient;
            hasIngredientLst.Add(ctrl.ingredient);
            ingredientStack.Children.Remove(ctrl);
            generateIngredientControl();
        }

        void generateIngredientControl()
        {
            if (currIngredientIndex < ingredientLst.Count)
            {
                Ingredient currIng = (Ingredient)ingredientLst[currIngredientIndex];
                IngredientControl currCtrl = new IngredientControl(currIng);
                currCtrl.rectSwipeRight.MouseDown += (s, e) => updateIngredients(currCtrl);
                ingredientControlLst.Add(currCtrl);
                ingredientStack.Children.Add(currCtrl);
                currIngredientIndex++;
            }
        }


        private void btnRecipes_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.removeControl(this);

            if (mainWindow.recipControl == null)
                mainWindow.recipControl = new RecipiesControl(recipyLst, recipyControlLst, mainWindow);

            mainWindow.btnBack.Visibility = Visibility.Visible;
            mainWindow.loadControl(mainWindow.recipControl);
            mainWindow.previousControl = this;
        }
        private void generateRecipies()
        {
            recipyLst.Add(new Recipy(40, "Chicken McNuggets", "Chickensdfsd", "url", null, 30, ""));
            recipyLst.Add(new Recipy(40, "Caeser's Salad", "Chickensdfsd", "url", null, 30, ""));
            recipyLst.Add(new Recipy(40, "Deez Nutz", "Chickensdfsd", "url", null, 30, ""));
            recipyLst.Add(new Recipy(40, "Root'n Toot'n Raspberry", "Chickensdfsd", "url", null, 30, ""));
            recipyLst.Add(new Recipy(40, "Tamar Im Egoz", "Chickensdfsd", "url", null, 30, ""));
            recipyLst.Add(new Recipy(40, "Krabby Patty", "Chickensdfsd", "url", null, 30, ""));

            foreach (Recipy rec in recipyLst)
            {
                SingleRecipeControl ctrl = new SingleRecipeControl(rec);
                ctrl.clickRect.MouseDown += (s, e) =>
                {
                    mainWindow.removeControl(ctrl);
                    mainWindow.loadControl(new RecipePageControl(rec));
                    mainWindow.previousControl = mainWindow.recipControl;
                };
                recipyControlLst.Add(ctrl);
            }
        }

    }
}
