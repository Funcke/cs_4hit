using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace big_file
{
    class Program
    {
        private const int C = 10000;
        static void Main(string[] args)
        {
            Random a = new Random();
                                            
            List<int> randomList = new List<int>();
            int MyNumber = 0;
            for(int c = 0; c < C;)
            {
                MyNumber = a.Next(100, 10100);
                if (!randomList.Contains(MyNumber)) {
                    randomList.Add(MyNumber);
                    System.IO.File.Copy("index.jpg", "./destination/IMG_20180628" + MyNumber + ".jpg");
                    c++;
                }
            }

        }
    }
}
