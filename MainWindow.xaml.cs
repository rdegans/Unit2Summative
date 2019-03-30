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
            Contacts contactTemp = new Contacts("placeholder", "placeholder", 1, 1, 1, "place holder");
            string[] contactNew = contactTemp.ReadFromFile();
            txtFirstName.Text = contactNew[0];
            txtLastName.Text = contactNew[1];
            txtYearBorn.Text = contactNew[2];
            txtMonthBorn.Text = contactNew[3];
            txtDayBorn.Text = contactNew[4];
            txtEmailAdress.Text = contactNew[5];
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
                MessageBox.Show("Please enter data for all fields and only enter number values for year born, month born and day born" + Environment.NewLine + ex);
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
            catch (Exception ex)
            {
                MessageBox.Show("Please enter valid data for all fields and only enter number values for year born, month born and day born" + Environment.NewLine + ex);
            }
        }
    }
}
