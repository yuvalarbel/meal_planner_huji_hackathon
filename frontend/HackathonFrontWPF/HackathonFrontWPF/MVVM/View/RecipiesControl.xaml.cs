using Hack;
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
    /// Interaction logic for RecipiesControl.xaml
    /// </summary>
    public partial class RecipiesControl : UserControl
    {
        public MainWindow mainWindow { get; set; }
        public List<Recipy> recipyLst { get; set; }
        public List<SingleRecipeControl> recipyCtrlLst { get; set; }
        public RecipiesControl(List<Recipy> recipies, List<SingleRecipeControl> ctrls, MainWindow main)
        {
            InitializeComponent();
            mainWindow = main;
            recipyLst = recipies;
            recipyCtrlLst = ctrls;

            foreach (SingleRecipeControl ctrl in recipyCtrlLst)
            {
                stackRecipies.Children.Add(ctrl);
            }
        }
    }
}
