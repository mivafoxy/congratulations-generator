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
using System.Windows.Shapes;

namespace Congratulations_generator
{
    /// <summary>
    /// Логика взаимодействия для OutputWindow.xaml
    /// </summary>
    public partial class OutputWindow : Window
    {

        public OutputWindow()
        {
            InitializeComponent();
            Image1.Source = new BitmapImage(new Uri("Images/pepe1.jpg", UriKind.Relative));
            Image2.Source = new BitmapImage(new Uri("Images/pepe2.png", UriKind.Relative));
            Image3.Source = new BitmapImage(new Uri("Images/pepe3.png", UriKind.Relative));
            Image4.Source = new BitmapImage(new Uri("Images/pepe4.jpg", UriKind.Relative));
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void buttonPast_Click(object sender, RoutedEventArgs e)
        {

        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
