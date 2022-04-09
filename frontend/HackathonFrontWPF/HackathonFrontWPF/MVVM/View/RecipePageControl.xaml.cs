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
using System.Diagnostics;
using HackathonFrontWPF.MVVM.Model;

namespace Hack
{
    /// <summary>
    /// Interaction logic for RecipePageControl.xaml
    /// </summary>
    public partial class RecipePageControl : UserControl
    {
        public Recipy recipy{ get; set; }
        public RecipePageControl(Recipy rec)
        {
            InitializeComponent();

            recipy = rec;
            imgBowl.Source = new BitmapImage(new Uri(rec.Image_path));
            //txtDescription.Text = recipy.Description;
            txtName.Text = recipy.Name;
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
