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
            Contacts contactFinal = new Contacts(txtFirstName.Text, txtLastName.Text, Convert.ToInt32(txtYearBorn.Text), Convert.ToInt32(txtMonthBorn.Text), Convert.ToInt32(txtDayBorn), txtEmailAdress.Text);
            contactFinal.SaveToFile();
        }
    }
    public class Contacts
    {
        public string firstName, lastName, emailAdress;
        public int yearBorn, monthBorn, dayBorn;
        public DateTime birthDay = new DateTime();
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
            //sw.WriteLine(firstName + "," + lastName + "," + yearBorn + "," + monthBorn + "," + dayBorn + "," + emailAdress);
            sw.WriteLine("itworked");
            sw.Flush();
            sw.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getAge()
        { 
            return "Hi";
            //account for month name or month #
            //year born will always be int
            //day born will always be int
        }
    }
}
