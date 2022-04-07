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
        public List<Ingredient> ingredientLst { get; set; }
        public List<Ingredient> hasIngredientLst { get; set; }
        public List<IngredientControl> ingredientControlLst { get; set; }
        public SwipeControl(List<Ingredient> ings)
        {
            InitializeComponent();
            ingredientLst = ings;
            hasIngredientLst = new List<Ingredient>();
            ingredientControlLst = new List<IngredientControl>();

            generateIngredientControls();

        }

        void generateIngredientControls()
        {
            for (int i = 0; i < 3; i++)
            {
                Ingredient currIng = (Ingredient)ingredientLst[i];
                IngredientControl currCtrl = new IngredientControl(currIng);
                currCtrl.rectSwipeRight.MouseDown += (s, e) => updateIngredients(currCtrl);
                ingredientControlLst.Add(currCtrl);
                ingredientStack.Children.Add(currCtrl);
            }
        }

        void updateIngredients(IngredientControl ctrl)
        {
            object j = ctrl.ingredient;
            hasIngredientLst.Add(ctrl.ingredient);
            ingredientStack.Children.Remove(ctrl);
        }
    }
}
