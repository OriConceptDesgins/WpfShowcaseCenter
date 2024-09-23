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

namespace WpfShowcaseCenter
{
    /// <summary>
    /// Interaction logic for ProjectDescriptionPage.xaml
    /// </summary>
    public partial class ProjectDescriptionPage : Page
    {
        public string ImageSource { get; set; }
        public string Description { get; set; }
        public string TitleText { get; set; }
        public ProjectDescriptionPage(string imageSource, string description, string title)
        {
            InitializeComponent();
            ImageSource = imageSource;
            Description = description;
            TitleText = title;
            ProjectDescription.Text = Description;
            ProjectTitle.Content = TitleText;
        }
    }
}
