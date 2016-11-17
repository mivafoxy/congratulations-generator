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
            //this.Background = new ImageBrush(new BitmapImage(new Uri("BD_Images/Theme/3.jpg", UriKind.RelativeOrAbsolute)));
            radioButton1.IsEnabled = false;
            radioButton2.IsEnabled = false;
            radioButton3.IsEnabled = false;
            radioButton4.IsEnabled = false;
            richTextBox1.AppendText(TableChanger.takePoem());
            richTextBox2.AppendText(TableChanger.takeCliche());
            Image1.Source = new BitmapImage(new Uri(TableChanger.generatePicture(), UriKind.Relative));
            Image2.Source = new BitmapImage(new Uri(TableChanger.takePicture(), UriKind.Relative));
            Image3.Source = new BitmapImage(new Uri(TableChanger.takePicture(), UriKind.Relative));
            Image4.Source = new BitmapImage(new Uri(TableChanger.takePicture(), UriKind.Relative));
            if (TableChanger.flagPictures == false) checkBox3.IsEnabled = false;
            if (TableChanger.flagCliche == false) checkBox2.IsEnabled = false;
            if (TableChanger.flagPoems == false) checkBox1.IsEnabled = false;
        }

        private void buttonPast_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wind = new MainWindow();
            this.Close();
            wind.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (checkBox1.IsChecked==true)
            {
                TextRange hpoet1 = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
                Congratulations.congratulation.gsPoem = hpoet1.Text;
            }
            else
            {
                Congratulations.congratulation.gsPoem = String.Empty;
            }

            if (checkBox2.IsChecked == true)
            {
                TextRange hpoet2 = new TextRange(richTextBox2.Document.ContentStart, richTextBox2.Document.ContentEnd);
                Congratulations.congratulation.gsCliche = hpoet2.Text;
            }
            else
            {
                Congratulations.congratulation.gsCliche = String.Empty;
            }

            if (checkBox3.IsChecked == true)
            {
                if (radioButton1.IsChecked == true) Congratulations.congratulation.gsImage = Image1.Source;
                if (radioButton2.IsChecked == true) Congratulations.congratulation.gsImage = Image2.Source;
                if (radioButton3.IsChecked == true) Congratulations.congratulation.gsImage = Image3.Source;
                if (radioButton4.IsChecked == true) Congratulations.congratulation.gsImage = Image4.Source;
            }
            else
            {
                Congratulations.congratulation.gsImage = null;
            }

            if (Congratulations.congratulation.gsPoem == String.Empty && Congratulations.congratulation.gsCliche == String.Empty && Congratulations.congratulation.gsImage == null)
            {
                MessageBox.Show("Вы не выбрали ни одного из элементов поздравления");
            }
            else
            {
                //Congratulations.congratulation.show();
                //MessageBox.Show(Image1.Source.ToString());
                TotalWindow totalWindow = new TotalWindow();
                totalWindow.Show();
            }
        }

        private void refreshButton1_Click(object sender, RoutedEventArgs e)
        {
            if (TableChanger.poemsList.listik == null || TableChanger.poemsList.listik.Count == 0) { return; }
            else
            {
                TableChanger.retryPoem();
                //string txt = TableChanger.reorganizatedPoem(TableChanger.poemsList.listik[TableChanger.poemsList.i].Content);
                string str = People.dataObj.getSalute() + " " + People.dataObj.getName() + " ! " + TableChanger.reorganizatedPoem(TableChanger.poemsList.listik[TableChanger.poemsList.i].Content);
                richTextBox1.Document.Blocks.Clear();
                this.richTextBox1.AppendText(str);
                TableChanger.poemsList.i++;
            }
        }

        private void refreshButton2_Click(object sender, RoutedEventArgs e)
        {
            if (TableChanger.clichesList.listik == null || TableChanger.clichesList.listik.Count == 0);
            else
            {
                TableChanger.retryCliche();
                string str = People.dataObj.getSalute() + " " + People.dataObj.getName() + " , " + TableChanger.clichesList.listik[TableChanger.clichesList.i].Content;
                richTextBox2.Document.Blocks.Clear();
                this.richTextBox2.AppendText(str);
                TableChanger.clichesList.i++;
            }
        }

        private void refreshButton3_Click(object sender, RoutedEventArgs e)
        {
            if (TableChanger.picturesList.listik == null || TableChanger.picturesList.listik.Count == 0) ;
            else
            {
                Image1.Source = new BitmapImage(new Uri(TableChanger.takePicture(), UriKind.Relative));
                Image2.Source = new BitmapImage(new Uri(TableChanger.takePicture(), UriKind.Relative));
                Image3.Source = new BitmapImage(new Uri(TableChanger.takePicture(), UriKind.Relative));
                Image4.Source = new BitmapImage(new Uri(TableChanger.takePicture(), UriKind.Relative));
            }
        }

        private void checkBox3_Click(object sender, RoutedEventArgs e)
        {
            if (checkBox3.IsChecked == true)
            {
                radioButton1.IsEnabled = true;
                radioButton2.IsEnabled = true;
                radioButton3.IsEnabled = true;
                radioButton4.IsEnabled = true;
            }
            else
            {
                radioButton1.IsEnabled = false;
                radioButton2.IsEnabled = false;
                radioButton3.IsEnabled = false;
                radioButton4.IsEnabled = false;
            }
        }
    }
}
