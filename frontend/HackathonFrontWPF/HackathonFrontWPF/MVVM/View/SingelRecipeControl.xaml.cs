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

namespace my_user_control
{
    /// <summary>
    /// Interaction logic for Recipe.xaml
    /// </summary>
    public partial class Recipe : UserControl
    {
        public RecipeClass recipe { get; set; }
        public Recipe(RecipeClass rec)
        {
            InitializeComponent();
            recipe = rec;

            //Adjust for current recipe
            btn1.Content
        }
    }
}
