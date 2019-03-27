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
            /*System.IO.StreamReader sr = new System.IO.StreamReader("contact.txt");
            System.IO.StreamWriter sw = new System.IO.StreamWriter("contact.txt");
            sw.Flush();
            string[] contactArray = sr.ReadLine().Split(',');
            Contacts contact = new Contacts(contactArray[0], contactArray[1], Convert.ToInt32(contactArray[2]), contactArray[3], Convert.ToInt32(contactArray[4]), contactArray[5]);*/
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            contact.SaveToFile();
        }
    }
    public class Contacts
    {
        public string firstName, lastName, emailAdress, monthBorn;
        public int yearBorn, dayBorn;
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
        public Contacts(string fN, string lN, int yB, string mB, int dB, string eA)
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
        public void ReadFromFile()
        {
            System.IO.StreamReader sr = new System.IO.StreamReader("contact.txt");
            string[] savedContact = sr.ReadLine().Split(',');
            sr.Close();
            public Contacts contact = new Contacts(savedContact[0], savedContact[1], Convert.ToInt32(savedContact[2]), savedContact[3], Convert.ToInt32(savedContact[4]), savedContact[5]);
            txtFirstName.Text = savedContact[0];
            txtLastName.Text = savedContact[1];
            txtYearBorn.Text = savedContact[2];
            txtMonthBorn.Text = savedContact[3];
            txtDayBorn.Text = savedContact[4];
            txtEmailAdress.Text = savedContact[5];
        }
        /// <summary>
        /// 
        /// </summary>
        public void SaveToFile()
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter("contact.txt");
            sw.WriteLine(txtFirstName.Text + "," + txtLastName.Text + "," + txtYearBorn.Text + "," + txtMonthBorn.Text + "," + txtDayBorn.Text + "," + txtEmailAdress.Text);
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
