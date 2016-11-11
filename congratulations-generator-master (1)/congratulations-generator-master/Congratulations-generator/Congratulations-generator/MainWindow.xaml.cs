using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Congratulations_generator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static void insertToDataBase(List <Human> lct)
        {
            humanBaseEntities context = new humanBaseEntities();
            foreach (Human ct in lct)
                context.Human.Add(ct);

            context.SaveChanges();
        }
        public MainWindow()
        {
            InitializeComponent();
            createHobbiesComboBox();
            createcomboBoxHoliday();
            createtextBoxAge();
            Img1.Source = new BitmapImage(new Uri("Images/top.png", UriKind.Relative));
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }

        private int returnLastId()
        {
            humanBaseEntities context = new humanBaseEntities();
            IQueryable<Human> custs = context.Human
                                                   .OrderByDescending(c => c.Id)
                                                   .Select(c => c);
            return custs.First().Id;
        }

        private void createHobbiesComboBox()
        {
            humanBaseEntities context = new humanBaseEntities();
            IQueryable<Interests> custs = context.Interests
                .Select(c => c);
            foreach (Interests cust in custs)
            {
                comboBoxInterests.Items.Add(cust.Name);
            }
            //MessageBox.Show(cust.Name);
        }

        private void createcomboBoxHoliday()
        {
            humanBaseEntities context = new humanBaseEntities();
            IQueryable<Holiday> custs = context.Holiday
                .Select(c => c);
            foreach (Holiday cust in custs)
            {
                comboBoxHoliday.Items.Add(cust.Name);
            }
            //MessageBox.Show(cust.Name);
        }

        private void createtextBoxAge()
        {
            for (int i = 3; i <= 100; i++) textBoxAge.Items.Add(i);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Human> lct = new List<Human>
             {
                 new Human
                 {
                     Id=returnLastId()+1,
                     Name=textBoxName.Text,
                     Solute=textBoxCall.Text
                 }
             };
            MainWindow.insertToDataBase(lct);

            MessageBox.Show(textBoxName.Text);
            //clearFun();

            OutputWindow outputWindow = new OutputWindow();
            //место для функции корректировки данных
            //место для функции генирации стартового поздравления и картинок
            //не забыть закрыть первую форму при корректном заполнении
            outputWindow.richTextBox.AppendText("Hello,World!\n");
            outputWindow.richTextBox.AppendText("Hello,Life!\n\n\n\n\n\n\n\n\n\n");
            outputWindow.richTextBox.AppendText("Hello,Friends!\n");
            outputWindow.Show();
        }
    }
}
