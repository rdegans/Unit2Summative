
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
            System.IO.StreamReader sr = new System.IO.StreamReader("contact.txt");
            string[] savedContact = new string[6];
            try
            {
                savedContact = sr.ReadLine().Split(',');
            }
            catch (FileNotFoundException ex)
            {
                for (int i = 0; i < savedContact.Length; i++)
                {
                    savedContact[i] = "Enter your data here";
                }
            }
            catch
            {
                for (int i = 0; i < savedContact.Length; i++)
                {
                    savedContact[i] = "Enter your data here";
                }
            }
            sr.Close();
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
                string[] userInput = new string[3];
                userInput[0] = firstName;
                userInput[1] = lastName;
                userInput[2] = emailAdress;
                string tempName;
                /*for (int i = 0; i < userInput.Length; i++)
                {
                    tempName = "";
                    for (int x = 0; x < userInput[i].Split(',').Length; i++)
                    {
                        tempName += userInput[i].Split(',')[x];
                    }
                    userInput[i] = tempName;
                }*///cut commas
                sw.WriteLine(userInput[0] + "," + userInput[1] + "," + userInput[2] + "," + monthBorn + "," + dayBorn + "," + emailAdress);
                sw.Flush();
                sw.Close();
            }
            catch(FileNotFoundException e)
            {
                MessageBox.Show(e.ToString());
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

