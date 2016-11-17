using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Congratulations_generator
{
    class Congratulations
    {
        public static Congratulations congratulation = new Congratulations();
        private string poem = String.Empty;
        private string cliche = String.Empty;
        System.Windows.Media.ImageSource image = null;

        public string gsPoem
        {
            get { return poem; }
            set
            {
                poem = value;
            }
        }

        public string gsCliche
        {
            get { return cliche; }
            set
            {
                cliche = value;
            }
        }

        public System.Windows.Media.ImageSource gsImage
        {
            get { return image; }
            set
            {
                image = value;
            }
        }

        public void show()
        {
            MessageBox.Show("Poem: " + gsPoem + "\r Cliche: " + gsCliche + "\r Image: " + gsImage);
        }
    }
}
