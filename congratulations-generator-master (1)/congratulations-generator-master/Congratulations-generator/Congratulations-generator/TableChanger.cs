using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Congratulations_generator
{
    public struct UltraPoems
    {
       public List<Poems> listik ;
       public int i;
    };

    public struct UltraCliches
    {
        public List<Cliche> listik;
        public int i;
    };

    public struct UltraPictures
    {
        public List<Pictures> listik;
        public int i;
    }
  public  class TableChanger
    {
      public static UltraPoems poemsList = new UltraPoems();
      public static UltraCliches clichesList = new UltraCliches();
      public static UltraPictures picturesList = new UltraPictures();
      public static bool flagPictures = true;
      public static bool flagCliche = true;
      public static bool flagPoems = true;

      static  private bool ageNumber(string pAge)
      {
          try
          {
              pAge = pAge.Substring(0, pAge.IndexOf(' '));
          }
          catch (Exception e)
          {

          }
          //if (pAge != null && pAge != String.Empty && pAge.Count() == 0)
          if (pAge != null)
              if (pAge != String.Empty) 
          {
              if (pAge.Equals("55+") == true)
              {
                  if (People.dataObj.getAge() == "55+") return true;
                  else return false;
              }
              else
              {
                  string[] number = pAge.Split('-');
                  int age1=(Convert.ToInt32(number[0]));
                  int age2 = 0;
                  if (number.Count()==1) age2 = age1;
                  else
                  {
                      if (number[1].Equals("55+") == true) age2 = 55;
                      else age2 = (Convert.ToInt32(number[1]));
                  }  
                  int ageP = 0;
                  if (People.dataObj.getAge() == "55+") ageP = 55;
                  else ageP = (Convert.ToInt32(People.dataObj.getAge()));
                  //MessageBox.Show(age1 + " " + age2 + " " + ageP);
                  if ((age2 >= ageP) && (age1 <= ageP)) return true;
                  else return false;
              }
          }
          return true;
      }

      public static void retryPoem()
      {
          if (poemsList.i == poemsList.listik.Count) poemsList.i = 0;
      }

      public static void retryCliche()
      {
          if (clichesList.i == clichesList.listik.Count) clichesList.i = 0;
      }

      public static void retryPicture()
      {
          if (picturesList.i == picturesList.listik.Count) picturesList.i = 0;
      }
      public static string takeCliche()
      {
          clichesList.listik = new List<Cliche>();
          clichesList.i = 0;

          string result = "";
          string holiday = People.dataObj.getHoliday();
          string interests = People.dataObj.getInterests();
          string sex = People.dataObj.getSex();

          humanBaseEntities context = new humanBaseEntities();
          IQueryable<Cliche> custs = context.Cliche
                                                 .Where(c => (((c.Holiday == holiday) || (c.Holiday == null)) && ((c.Interests == interests) || (c.Interests == null)) && ((c.Sex == sex) || (c.Sex == null))))
                                                 .Select(c => c);
          foreach (Cliche cust in custs)
          {
              if (ageNumber(cust.Age) == true) clichesList.listik.Add(cust);
          }

          /*
          foreach (Poems a in poemsList.listik)
          {
              MessageBox.Show(a.Content);
          }
          */
          if (clichesList.listik == null || clichesList.listik.Count == 0)
          {
              MessageBox.Show("По вашему запросу (клише)поздравления не найдены");
              flagCliche = false;
              return null;
          }
          else
          {
              clichesList.i++;
              result = People.dataObj.getSalute() + " " + People.dataObj.getName() + " , " + clichesList.listik.First().Content;
          }
          //clichesList.i++;
          return result;
      }


      public static string reorganizatedPoem(string content)
      {
          string[] masresult = content.Split('/'); 
          string result=String.Empty;
          foreach(string ms in masresult)
          {
              result = result + "\r" + ms;
          }

          string[] stresult = result.Split('*');
          string newresult = String.Empty;
          
          foreach (string ms in stresult)
          {
              newresult = newresult + ms + "\n";
          }

          //MessageBox.Show(result);
          return newresult; 
      }


      public static string takePicture()
      {
          if (picturesList.listik == null || picturesList.listik.Count == 0) return "Images/NoPhoto.jpg";
          else
          {
              retryPicture();
              string result = picturesList.listik[picturesList.i].Content;
              picturesList.i++;
              return result;
          }
      }

      public static string generatePicture()
      {
          picturesList.listik = new List<Pictures>();
          picturesList.i = 0;

          string result = "";
          string holiday = People.dataObj.getHoliday();
          string interests = People.dataObj.getInterests();
          string sex = People.dataObj.getSex();

          humanBaseEntities context = new humanBaseEntities();
          IQueryable<Pictures> custs = context.Pictures
                                                 .Where(c => (((c.Holiday == holiday) || (c.Holiday == null)) && ((c.Interests == interests) || (c.Interests == null)) && ((c.Sex == sex) || (c.Sex == null))))
                                                 .Select(c => c);
          foreach (Pictures cust in custs)
          {
              if (ageNumber(cust.Age) == true) picturesList.listik.Add(cust);
          }

          if (picturesList.listik == null || picturesList.listik.Count == 0) 
          {
              MessageBox.Show("По вашему запросу картинки не найдены :(");
              flagPictures = false;
              return "Images/NoPhoto.jpg";
          }
          else
          {
              retryPicture();
              result = picturesList.listik[picturesList.i].Content;
              picturesList.i++;
          }
          return result;
      }

        public static string takePoem()
        {
            poemsList.listik = new List<Poems>();
            poemsList.i = 0;

            string result = "";
            string holiday = People.dataObj.getHoliday();
            string interests = People.dataObj.getInterests();
            string sex = People.dataObj.getSex();

            humanBaseEntities context = new humanBaseEntities();
            IQueryable<Poems> custs = context.Poems
                                                   .Where(c => (((c.Holiday == holiday)) && ((c.Interests == interests) || (c.Interests == null)) && ((c.Sex == sex) || (c.Sex == null))))
                                                   .Select(c => c);
            //MessageBox.Show(custs.First().Content);
           /* foreach (Poems cust in custs)
            {
                MessageBox.Show(cust.Content);
            }*/
            foreach (Poems cust in custs)
            {
                if (ageNumber(cust.Age) == true) poemsList.listik.Add(cust);
            }

            /*
            foreach (Poems a in poemsList.listik)
            {
                MessageBox.Show(a.Content);
            }*/
           
            if (poemsList.listik == null || poemsList.listik.Count == 0)
            {
                MessageBox.Show("По вашему запросу поздравления в стихотворной форме не найдены");
                flagPoems = false;
                return null;
            }
            else
            {
                //poemsList.i++;
                result = People.dataObj.getSalute() + " " + People.dataObj.getName() + " ! " + reorganizatedPoem(poemsList.listik[poemsList.i].Content);
            }
            poemsList.i++;
            //MessageBox.Show((++poemsList.i).ToString());
            return result;
        }
    }
}
