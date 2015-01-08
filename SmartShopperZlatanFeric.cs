using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication11
{
    class Program

    {
        public int counter;
        public int money;
        public int runtimes;
        public int numprices;
        public string lines;
        public int[] storeprices;

       
        public void getResult(int size, int money, int[] pricearray)
        {

            int sum = 0;
            //traverse array and add items up
            //u only need to add the first index once.. i.e. 0 + 1, 0 + 2, 0 + 3, 1 + 2, 1 + 3, 2 + 3, done
            for (int j = 0; j < size; j++)
            {                
                for (int k = j + 1; k < pricearray.Length; k++)
                {

                    sum = 0;
                    sum = pricearray[j] + pricearray[k];
                   
                    if (sum == money) Console.WriteLine("{0},{1}", j + 1, k + 1);


                }

            }

        }
      
        static void Main(string[] args)
        {

            Program hm = new Program();

            string[] batch = new string[16000];

            //Read the contents from the test file

            StreamReader file = new StreamReader("C:\\Users\\Zlatan\\Desktop\\Class Stuff\\CodeChallenge\\VelirCodeContest\\TextFile1.txt");
            
            while ((hm.lines = file.ReadLine())!= null)
            {
                //Store each string in string array
                batch[hm.counter++] = hm.lines;
                
            }

            file.Close();

          


            
            //Get first integer indicating how many times the algorithm will repeat
            Int32.TryParse(batch[0], out hm.runtimes);

            //Main loop
            for (int n = 0; n < hm.runtimes; n++)
            {


                Int32.TryParse(batch[1 + 3 * n], out hm.money);
                Int32.TryParse(batch[2 + 3 * n], out hm.numprices);

                hm.storeprices = new int[hm.numprices];
                int counter = 0;

                string[] words = batch[3 + 3 * n].Split(' ');

                foreach (string word in words)
                {
                    Int32.TryParse(word, out hm.storeprices[counter]);
                    counter++;
                }


                     hm.getResult(hm.numprices, hm.money, hm.storeprices);
              
            }
        }
    }
}
