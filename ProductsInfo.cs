using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG6221_ICE3_19014225
{
    class ProductsInfo<T>
    {
        // File located inside Main Project folder.
        private string path = System.IO.Path.GetFullPath(@"..\..\") + "productInfo.txt";

        //Objects are declared.
        private static object[] prodID;
        private static object[] prodName;
        private static object[] prodQuantity;
        private static object[] prodPrice;

        //Stacker is initialized 
        private int stackPointer = 0;
        private string Display;

        public ProductsInfo(int size)
        {
            prodID = new object[size];
            prodName = new object[size];
            prodQuantity = new object[size];
            prodPrice = new object[size];
        }

        public void push(object ID, object name, object quanity, object price)
        {
            prodID[stackPointer] = ID;
            prodName[stackPointer] = name;
            prodQuantity[stackPointer] = quanity;
            prodPrice[stackPointer] = price;
            saveInfo();
            stackPointer++;
        }

        private void saveInfo()     //Saves values from text boxes to File, if file does or does not exist. Is created.
        {
            try
            {
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("pd1");
                        sw.WriteLine("Bread");
                        sw.WriteLine(24);
                        sw.WriteLine(9);

                        sw.WriteLine("pd2");
                        sw.WriteLine("Milk");
                        sw.WriteLine(15);
                        sw.WriteLine(7);
                        sw.Close();

                    }
                }
                else
                {
                    using(StreamWriter sw = new StreamWriter(path,true))
                    {
                        sw.WriteLine(prodID[stackPointer]);
                        sw.WriteLine(prodName[stackPointer]);
                        sw.WriteLine(prodQuantity[stackPointer]);
                        sw.WriteLine(prodPrice[stackPointer]);
                        sw.Close();
                    }
                }
            }
            catch (Exception e)
            {
                //Displays message of error occurence.
                MessageBox.Show("An error occured " + e.ToString());
            }
        }

        public string read()
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("pd1");
                    sw.WriteLine("Bread");
                    sw.WriteLine(24);
                    sw.WriteLine(9);

                    sw.WriteLine("pd2");
                    sw.WriteLine("Milk");
                    sw.WriteLine(15);
                    sw.WriteLine(7);
                    sw.Close();
                }
            }
            Display = "";

            try
            {
                StreamReader sr = new StreamReader(path, true);
                for (int x = 0; x != File.ReadLines(path).Count() / 4; x++)
                {
                    prodID[x] = sr.ReadLine();
                    prodName[x] = sr.ReadLine();
                    prodQuantity[x] = sr.ReadLine();
                    prodPrice[x] = sr.ReadLine();

                    Display += "ID: " + prodID[x] + "\n";
                    Display += "Product: " + prodName[x] + "\n";
                    Display += "Quantity: " + prodQuantity[x] + "\n";
                    Display += "Price: R" + prodPrice[x] + "\n";
                    Display += "\n";
                }
                sr.Close();
            }
            catch  (Exception e)
            {
                MessageBox.Show("An error occured " + e.ToString());
            }
            return Display;
        }

    }
}
