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
    /// Interaction logic for MainShowcasePage.xaml
    /// </summary>
    public partial class MainShowcasePage : Page
    {
        public MainShowcasePage()
        {
            InitializeComponent();
        }
        private void NavigateToAnotherPage(object sender, RoutedEventArgs e)
        {
            // Your navigation logic here
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender == null) { return; }

            (sender as Border).BorderBrush = Brushes.AliceBlue;
        }

        private void IconButtonLeftClick(object sender, RoutedEventArgs e)
        {
            string? toolTip = "";
            // Handle the button click event here
            if (sender is Button button)
            {

                if (button != null) { toolTip = button.ToolTip.ToString(); }
                
                if (!string.IsNullOrEmpty(toolTip)) { 
                    if (ProjectsInfo.TryGetIconData(toolTip, out var data))
                    {
                        ProjectDescriptionPage projectPage = new ProjectDescriptionPage 
                        (
                            data.ImageSource,
                            data.Description,
                            toolTip
                        );

                        NavigationService.Navigate(projectPage);
                    }
                }
                else
                {
                    // Handle the case where icon data is not found
                    MessageBox.Show("No data found for the specified ToolTip.");
                }

            }
        }


        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Border).BorderBrush = Brushes.Transparent;
        }


        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = (sender as Image)!;
            image.Opacity = 0.6;


        }


        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Image)!.Opacity = 1;
        }

    }
}
