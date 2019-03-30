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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.ComponentModel;

namespace _184863Unit2Summative
{
    public class Contacts
    {
        public string firstName, lastName, emailAdress;
        public int yearBorn, monthBorn, dayBorn;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fN"></param>
        /// <param name="lN"></param>
        /// <param name="yB"></param>
        /// <param name="mB"></param>
        /// <param name="dB"></param>
        /// <param name="eA"></param>
        public Contacts(string fN, string lN, int yB, int mB, int dB, string eA)
        {
            firstName = fN;
            lastName = lN;
            yearBorn = yB;
            monthBorn = mB;
            dayBorn = dB;
            emailAdress = eA;
        }
        /// <summary>
        /// 
        /// </summary>
        public string[] ReadFromFile()
        {
            string[] savedContact = new string [6];
            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("contact.txt");
                savedContact = new string[6];
                try
                {
                    savedContact = sr.ReadLine().Split(',');
                }
                catch
                {
                    for (int i = 0; i < savedContact.Length; i++)
                    {
                        savedContact[i] = "Enter your data here";
                    }
                }
                sr.Close();
            }
            catch (FileNotFoundException ex)
            {
                for (int i = 0; i < savedContact.Length; i++)
                {
                    savedContact[i] = "Enter your data here";
                }
            }
            return savedContact;
        }
        /// <summary>
        /// 
        /// </summary>
        public void SaveToFile()
        {
            try
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter("contact.txt");
                sw.WriteLine(firstName + "," + lastName + "," + yearBorn + "," + monthBorn + "," + dayBorn + "," + emailAdress);
                sw.Flush();
                sw.Close();
            }
            catch (FileNotFoundException /*e*/)
            {
               // MessageBox.Show(e.ToString());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double getAge()
        {

            DateTime birthDay = new DateTime(yearBorn, monthBorn, dayBorn);
            DateTime currentDay = DateTime.Today;
            return Math.Floor(currentDay.Subtract(birthDay).Days / 365.25);
        }
    }
}
