using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for TotalWindow.xaml
    /// </summary>
    public partial class TotalWindow : Window
    {
        public TotalWindow()
        {
            InitializeComponent();
            richTextBox1.AppendText(Congratulations.congratulation.gsPoem + "\r" + Congratulations.congratulation.gsCliche);
            if (Congratulations.congratulation.gsImage != null) resultImage.Source = Congratulations.congratulation.gsImage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonVK_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Enter");
            Process.Start("https://vk.com");
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://ok.ru");
        }

        private void buttonFB_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://ru-ru.facebook.com");
        }

    }
}
