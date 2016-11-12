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
        //static People anketa;
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

        private int returnLastId()
        {
            humanBaseEntities context = new humanBaseEntities();
            IQueryable<Human> custs = context.Human
                                                   .OrderByDescending(c => c.Id)
                                                   .Select(c => c);
            if (custs == null || custs.Count() == 0) return 1;
            return custs.First().Id + 1;
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

        private bool checkLog()
        {
            if(textBoxName==null||textBoxName.Text == string.Empty)
            {
                MessageBox.Show("Не введено поле 'Имя'");
                return false;
            }

            if (textBoxCall == null || textBoxCall.Text == string.Empty)
            {
                MessageBox.Show("Не введено поле 'Обращение'");
                return false;
            }

            for (int i = 0; i < textBoxCall.Text.ToCharArray().Length; i++)
            {
                if(textBoxCall.Text.ToCharArray()[i]>'0' && textBoxCall.Text.ToCharArray()[i]<'9')
                {
                    MessageBox.Show("Не корректное 'Обращение'");
                    return false;
                }
            }

            if (textBoxAge.Text == string.Empty || textBoxAge==null)
            {
                MessageBox.Show("Не выбран возраст");
                return false;
            }

            if (comboBoxHoliday.Text == string.Empty || comboBoxHoliday == null)
            {
                MessageBox.Show("Не выбран праздник");
                return false;
            }

            return true;
        }

        private void recordData(string sex)
        {
            List<Human> lct = new List<Human>
             {
                 new Human
                 {
                     Id=returnLastId(),
                     Name=textBoxName.Text,
                     Solute=textBoxCall.Text,
                     Age=Convert.ToInt32(textBoxAge.Text),
                     Sex = sex,
                     Interests=comboBoxInterests.Text,
                     Holiday = comboBoxHoliday.Text
                 }
             };

            MainWindow.insertToDataBase(lct);
            People.dataObj = new People(textBoxName.Text, textBoxCall.Text, Convert.ToInt32(textBoxAge.Text), sex, comboBoxInterests.Text, comboBoxHoliday.Text);
            //anketa.showPeople();
            //MessageBox.Show(textBoxName.Text);

            OutputWindow outputWindow = new OutputWindow();
            //место для функции корректировки данных
            //место для функции генирации стартового поздравления и картинок
            //не забыть закрыть первую форму при корректном заполнении
            //оставлять старые данные при возврате к анкете
            mainWindow.Close();
            outputWindow.richTextBox2.AppendText("Робит!!");
            outputWindow.Show();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (checkLog())
            {
                if (radioButtonMan.IsChecked == true)
                {
                    recordData("Мужской");
                }
                else if (radioButtonWoman.IsChecked == true)
                {
                    recordData("Женский");
                }
                else
                {
                    MessageBox.Show("Не выбран пол");
                    return;
                }
            }
            //clearFun(); 
        }
    }
}
