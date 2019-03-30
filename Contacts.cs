/* Name: Riley de Gans
 * Date: March 29th, 2019
 * Description: A program that formats and stores contacts from a form
 */
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
        public string firstName, lastName, emailAdress; //declare variables for class
        public int yearBorn, monthBorn, dayBorn;
        /// <summary>
        /// create a contact object
        /// </summary>
        /// <param name="fN"></param>
        /// <param name="lN"></param>
        /// <param name="yB"></param>
        /// <param name="mB"></param>
        /// <param name="dB"></param>
        /// <param name="eA"></param>
        public Contacts(string fN, string lN, int yB, int mB, int dB, string eA)
        {
            firstName = fN; //assign variables for class
            lastName = lN;
            yearBorn = yB;
            monthBorn = mB;
            dayBorn = dB;
            emailAdress = eA;
        }
        /// <summary>
        /// read the data from the file contact.txt and check for various exceptions
        /// </summary>
        public string[] ReadFromFile() //method to read and return contact info from the text file contact.txt
        {
            string[] savedContact = new string [6]; //declare the string array that will be returned
            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader("contact.txt"); //create stream reader to read from text file
                savedContact = new string[6];
                try
                {
                    savedContact = sr.ReadLine().Split(','); //attempt to split the data by commas
                }
                catch
                {
                    for (int i = 0; i < savedContact.Length; i++) //if there are no commas, enter place holder data for the user and force them to add new data to the text file before closing
                    {
                        savedContact[i] = "Enter your data here";
                    }
                }
                sr.Close();
            }
            catch (FileNotFoundException ex) //if the file does not exist, do the same thing as if there are no commas
            {
                for (int i = 0; i < savedContact.Length; i++)
                {
                    savedContact[i] = "Enter your data here";
                }
            }
            return savedContact;
        }
        /// <summary>
        /// save the data to the file contact.txt and check for various exceptions
        /// </summary>
        public void SaveToFile() //method to save the data to the text file contact.txt as a comma sepperated line
        {
            try //attempt to performt the action
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter("contact.txt"); //create stream writer
                sw.WriteLine(firstName + "," + lastName + "," + yearBorn + "," + monthBorn + "," + dayBorn + "," + emailAdress); //write the values from the class that the method is being used on
                sw.Flush();
                sw.Close();
            }
            catch (FileNotFoundException) //exception for if the file does not exist
            {
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double getAge() //method to get the age of the user from their entered birth day
        {
            DateTime birthDay = new DateTime(yearBorn, monthBorn, dayBorn); //create date time class with the values the user gave
            DateTime currentDay = DateTime.Today; //create a date time class for today
            return Math.Floor(currentDay.Subtract(birthDay).Days / 365.25); //returns the age in years, by dividing the timespan in days by 3.25 and rounding down
        }
    }
}
