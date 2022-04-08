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

namespace HackathonFrontWPF.MVVM.View
{
    /// <summary>
    /// Interaction logic for SingleRecipeControl.xaml
    /// </summary>
    public partial class SingleRecipeControl : UserControl
    {
        public Recipy recipy { get; set; }
        public SingleRecipeControl(Recipy rec)
        {
            InitializeComponent();
            recipy = rec;
            txtName.Text = recipy.Name;
            txtTime.Text = recipy.Time.ToString() + "mins";
            txtPrice.Text = recipy.Price.ToString();
        }
    }
}
