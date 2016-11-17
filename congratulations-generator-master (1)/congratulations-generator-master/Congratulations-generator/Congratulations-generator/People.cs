using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Congratulations_generator
{
    class People
    {
       public  static People dataObj;
       private string name;
       private string salute;
       private string age;
       private string sex;
       private string interests;
       private string holiday;

       public string getName()
       {
           return name;
       }

       public string getSalute()
       {
           return salute;
       }

       public string getAge()
       {
           return age;
       }

       public string getSex()
       {
           return sex;
       }

       public string getInterests()
       {
           return interests;
       }

       public string getHoliday()
       {
           return holiday;
       }
        public People(string kName,string kSalute, string kAge,string kSex, string kInterests, string kHoliday )
       {
           name = kName;
           salute = kSalute;
           age = kAge;
           sex = kSex;
           interests = kInterests;
           holiday = kHoliday;
       }
       public void showPeople()
       {
           MessageBox.Show(name + " " + salute + " " + age.ToString() + " " + sex + " " + interests + " " + holiday);
       }
    }
}
