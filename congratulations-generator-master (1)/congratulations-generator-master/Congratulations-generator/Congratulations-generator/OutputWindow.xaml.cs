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
            //People.dataObj.showPeople();
            /*
            Image1.Source = new BitmapImage(new Uri("Images/pepe1.jpg", UriKind.Relative));
            Image2.Source = new BitmapImage(new Uri("Images/pepe2.png", UriKind.Relative));
            Image3.Source = new BitmapImage(new Uri("Images/pepe3.png", UriKind.Relative));
            Image4.Source = new BitmapImage(new Uri("Images/pepe4.jpg", UriKind.Relative));*/
            if (People.dataObj.getHoliday() == "Новый Год")
            {
                this.richTextBox1.AppendText(People.dataObj.getSalute() + " " + People.dataObj.getName() + " , " + returnPoemNE(1) + "\n\n\n" + People.dataObj.getSalute() + " " + People.dataObj.getName() + " , " + returnClicheNE(1));
                Image1.Source = new BitmapImage(new Uri(returnWayPictureNE(1), UriKind.Relative));
                Image2.Source = new BitmapImage(new Uri(returnWayPictureNE(2), UriKind.Relative));
                Image3.Source = new BitmapImage(new Uri(returnWayPictureNE(3), UriKind.Relative));
                Image4.Source = new BitmapImage(new Uri(returnWayPictureNE(4), UriKind.Relative));
                return;
            }
            if (People.dataObj.getHoliday() == "День Рождение")
            {
                this.richTextBox1.AppendText(People.dataObj.getSalute() + " " + People.dataObj.getName() + " , " + returnPoemB(1) + "\n\n\n" + People.dataObj.getSalute() + " " + People.dataObj.getName() + " , " + returnClicheB(1));
                Image1.Source = new BitmapImage(new Uri(returnWayPictureB(1), UriKind.Relative));
                Image2.Source = new BitmapImage(new Uri(returnWayPictureB(2), UriKind.Relative));
                Image3.Source = new BitmapImage(new Uri(returnWayPictureB(3), UriKind.Relative));
                Image4.Source = new BitmapImage(new Uri(returnWayPictureB(4), UriKind.Relative));
                return;
            }
            Image1.Source = new BitmapImage(new Uri("Images/pepe1.jpg", UriKind.Relative));
            Image2.Source = new BitmapImage(new Uri("Images/pepe2.png", UriKind.Relative));
            Image3.Source = new BitmapImage(new Uri("Images/pepe3.png", UriKind.Relative));
            Image4.Source = new BitmapImage(new Uri("Images/pepe4.jpg", UriKind.Relative));
        }

        private string returnPoemNE(int i)
        {
            humanBaseEntities context = new humanBaseEntities();
            IQueryable<New_Year_Poem> custs = context.New_Year_Poem
                                                   .Where (c=> c.Id==i)
                                                   .Select(c => c);
            //MessageBox.Show(custs.First().Picture);
            return custs.First().Name;
        }

        private string returnClicheNE(int i)
        {
            humanBaseEntities context = new humanBaseEntities();
            IQueryable<New_Year_Cliche> custs = context.New_Year_Cliche
                                                   .Where(c => c.Id == i)
                                                   .Select(c => c);
            //MessageBox.Show(custs.First().Picture);
            return custs.First().Name;
        }

        private string returnPoemB(int i)
        {
            humanBaseEntities context = new humanBaseEntities();
            IQueryable<Birthday_Poem> custs = context.Birthday_Poem
                                                   .Where(c => c.Id == i)
                                                   .Select(c => c);
            //MessageBox.Show(custs.First().Picture);
            return custs.First().Name;
        }

        private string returnClicheB(int i)
        {
            humanBaseEntities context = new humanBaseEntities();
            IQueryable<Birthday_Cliche> custs = context.Birthday_Cliche
                                                   .Where(c => c.Id == i)
                                                   .Select(c => c);
            //MessageBox.Show(custs.First().Picture);
            return custs.First().Name;
        }

        private string returnWayPictureNE(int i)
        {
            humanBaseEntities context = new humanBaseEntities();
            IQueryable<New_Year_Picture> custs = context.New_Year_Picture
                                                   .Where(c => c.Id == i)
                                                   .Select(c => c);
            //MessageBox.Show(custs.First().Picture);
            return custs.First().Picture;
        }

        private string returnWayPictureB(int i)
        {
            humanBaseEntities context = new humanBaseEntities();
            IQueryable<Birthday_Picture> custs = context.Birthday_Picture
                                                   .Where(c => c.Id == i)
                                                   .Select(c => c);
            //MessageBox.Show(custs.First().Picture);
            return custs.First().Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

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
            TotalWindow totalWindow = new TotalWindow();
            totalWindow.Show();
        }
    }
}
