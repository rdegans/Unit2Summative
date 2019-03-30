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
using System.ComponentModel;
using System.IO;

namespace _184863Unit2Summative
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string[] contactNew = new string[6]; //array to temporarily store the contacts
           try //if there are six items in the data
            {
                Contacts contactTemp = new Contacts("placeholder", "placeholder", 1, 1, 1, "place holder"); //create a place holder class to apply the read from file method to
                //this was kind of a paradox, because we were populating the class with the readfrom file, but using the read from file on the class, so we had to make a placeholder
                //we couldn't find another way to do it, it is only slightly less efficient, and it works, so we went with it
                contactNew = contactTemp.ReadFromFile();//read from file
                txtFirstName.Text = contactNew[0];//set the text boxes to the saved contacts
                txtLastName.Text = contactNew[1];
                txtYearBorn.Text = contactNew[2];
                txtMonthBorn.Text = contactNew[3];
                txtDayBorn.Text = contactNew[4];
                txtEmailAdress.Text = contactNew[5];
            }
            catch //exception for if there are not six items in the data
            {
                txtFirstName.Text = "Enter your data here"; //fill the fields temporarily and force the user to fix the problem before being able to close the window
                txtLastName.Text = "Enter your data here";
                txtYearBorn.Text = "Enter your data here";
                txtMonthBorn.Text = "Enter your data here";
                txtDayBorn.Text = "Enter your data here";
                txtEmailAdress.Text = "Enter your data here";
            }
        }
        private void BtnGetAge_Click(object sender, RoutedEventArgs e) //click event for get age button
        {
            try //if the data is all in int form and proper date form
            {
                int birthYear, birthMonth, birthDay; //declare the variables for age
                int.TryParse(txtDayBorn.Text, out birthDay); //convert to int
                int.TryParse(txtMonthBorn.Text, out birthMonth);
                int.TryParse(txtYearBorn.Text, out birthYear);
                Contacts contactCurrent = new Contacts(txtFirstName.Text, txtLastName.Text, birthYear, birthMonth, birthDay, txtEmailAdress.Text); //create a new class
                MessageBox.Show("Your age is " + contactCurrent.getAge() + " years old"); //print the age using the get age method
            }
            catch (Exception ex) //if the format of the data is wrong
            {
                MessageBox.Show("Please enter valid data for all fields and only enter number values for year born, month born and day born"); //prompt the user to fix it and do not run the method
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) //event for when the user tries to close the window
        {
            try //check for formatting errors in the data ex. negative dates, letters for dates
            {
                int birthYear, birthMonth, birthDay; //declare the variables
                int.TryParse(txtDayBorn.Text, out birthDay); //convert to int
                int.TryParse(txtMonthBorn.Text, out birthMonth);
                int.TryParse(txtYearBorn.Text, out birthYear);
                DateTime placeHolder = new DateTime(birthYear, birthMonth, birthDay); //create a placeholder date time that will cause the catch if the dates are incorrect ex. year -1 or feb 30th
                Contacts contactFinal = new Contacts(txtFirstName.Text, txtLastName.Text, birthYear, birthMonth, birthDay, txtEmailAdress.Text); //create a new class
                string[] userInput = new string[6]; //string array to store the user input to be manipulated
                userInput[0] = birthYear.ToString(); //populate the array
                userInput[1] = birthMonth.ToString();
                userInput[2] = birthDay.ToString();
                userInput[3] = txtFirstName.Text;
                userInput[4] = txtLastName.Text;
                userInput[5] = txtEmailAdress.Text;
                for (int i = 0; i<userInput.Length; i++) //check each position in the array
                {
                    if (userInput[i].Length == 0) //check for data
                    {
                        e.Cancel = true;
                        MessageBox.Show("Please fill in all fields"); //if the field is blank, prompt the user to fix it and don't let them close the window
                    }
                    if (userInput[i].Contains(',')) //check for commas
                    {
                        e.Cancel = true;
                        MessageBox.Show("Please do not enter commas"); //if there are commas, prompt the user to fix it and don't let them close the window
                    }
                    else
                    {
                        contactFinal.SaveToFile(); //if the user is cooperating and all the data is formatted correctly save the file as normal
                    }
                }
            }
            catch (Exception ex) //if the fields are formatted incorectly
            {
                MessageBox.Show("Please enter valid data for all fields and only enter number values for year born, month born and day born");
                e.Cancel = true;//prompt the user to fix it and do not let them close the window
            }
        }
    }
}
