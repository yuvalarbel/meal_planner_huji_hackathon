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
using HackathonFrontWPF.MVVM.Model;

namespace HackathonFrontWPF.MVVM.View
{
    /// <summary>
    /// Interaction logic for IngredientControl.xaml
    /// </summary>
    public partial class IngredientControl : UserControl
    {
        public Ingredient ingredient { get; set; }
        public IngredientControl(Ingredient ing)
        {
            InitializeComponent();
            txtName.Text = ing.Name;
            ingredient= ing;
        }
    }
}
