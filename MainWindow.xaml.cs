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
            string[] contactNew = new string[6];
           try
            {
                Contacts contactTemp = new Contacts("placeholder", "placeholder", 1, 1, 1, "place holder");
                contactNew = contactTemp.ReadFromFile();
                txtFirstName.Text = contactNew[0];
                txtLastName.Text = contactNew[1];
                txtYearBorn.Text = contactNew[2];
                txtMonthBorn.Text = contactNew[3];
                txtDayBorn.Text = contactNew[4];
                txtEmailAdress.Text = contactNew[5];
            }
            catch
            {
                txtFirstName.Text = "Enter your data here";
                txtLastName.Text = "Enter your data here";
                txtYearBorn.Text = "Enter your data here";
                txtMonthBorn.Text = "Enter your data here";
                txtDayBorn.Text = "Enter your data here";
                txtEmailAdress.Text = "Enter your data here";
            }
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
            catch (Exception ex)
            {
                MessageBox.Show("Please enter valid data for all fields and only enter number values for year born, month born and day born");
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
                string[] userInput = new string[6];
                userInput[0] = birthYear.ToString();
                userInput[1] = birthMonth.ToString();
                userInput[2] = birthDay.ToString();
                userInput[3] = txtFirstName.Text;
                userInput[4] = txtLastName.Text;
                userInput[5] = txtEmailAdress.Text;
                for (int i = 0; i<userInput.Length; i++)
                {
                    if (userInput[i].Length == 0)
                    {
                        e.Cancel = true;
                        MessageBox.Show("Please fill in all fields");
                    }
                    if (userInput[i].Contains(','))
                    {
                        e.Cancel = true;
                        MessageBox.Show("Please do not enter commas");
                    }
                    else
                    {
                        contactFinal.SaveToFile();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter valid data for all fields and only enter number values for year born, month born and day born");
                e.Cancel = true;
            }
        }
    }
}
