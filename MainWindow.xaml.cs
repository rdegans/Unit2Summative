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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Contacts contactTemp = new Contacts("placeholder", "placeholder", 1, 1, 1, "place holder");
            string[] contactNew = contactTemp.ReadFromFile();
            txtFirstName.Text = contactNew[0];
            txtLastName.Text = contactNew[1];
            txtYearBorn.Text = contactNew[2];
            txtMonthBorn.Text = contactNew[3];
            txtDayBorn.Text = contactNew[4];
            txtEmailAdress.Text = contactNew[5];
        }
        private void Window_Closed(object sender, EventArgs e)
        {

        }

        private void BtnGetAge_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int birthYear, birthMonth, birthDay;
                int.TryParse(txtDayBorn.Text, out birthDay);
                int.TryParse(txtMonthBorn.Text, out birthMonth);
                int.TryParse(txtYearBorn.Text, out birthYear);
                Contacts contactCurrent = new Contacts(txtFirstName.Text, txtLastName.Text, birthYear, birthMonth, birthDay, txtEmailAdress.Text);
                MessageBox.Show("Your age is " + contactCurrent.getAge() + " years old");
            }
            catch
            {
                MessageBox.Show("Please enter data for all fields and only enter number values for year born, month born and day born");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                int birthYear, birthMonth, birthDay;
                int.TryParse(txtDayBorn.Text, out birthDay);
                int.TryParse(txtMonthBorn.Text, out birthMonth);
                int.TryParse(txtYearBorn.Text, out birthYear);
                DateTime placeHolder = new DateTime(birthYear, birthMonth, birthDay);
                Contacts contactFinal = new Contacts(txtFirstName.Text, txtLastName.Text, birthYear, birthMonth, birthDay, txtEmailAdress.Text);
                contactFinal.SaveToFile();
            }
            catch
            {
                MessageBox.Show("Please enter data for all fields and only enter number values for year born, month born and day born");
            }
        }
    }
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
            string[] savedContact = sr.ReadLine().Split(',');
            sr.Close();
            return savedContact;
        }
        /// <summary>
        /// 
        /// </summary>
        public void SaveToFile()
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter("contact.txt");
            string[] userInput = new string[3];
            userInput[0] = firstName;
            userInput[1] = lastName;
            userInput[2] = emailAdress;
            string tempName;
            for (int i = 0; i<userInput.Length; i++)
            {
                tempName = "";
                for (int x = 0; x < userInput[i].Split(',').Length; i++)
                {
                    tempName += userInput[i].Split(',')[x];
                }
                userInput[i] = tempName;
            }
            sw.WriteLine(userInput[0] + "," + userInput[1] + "," + userInput[2] + "," + monthBorn + "," + dayBorn + "," + emailAdress);
            sw.Flush();
            sw.Close();
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
