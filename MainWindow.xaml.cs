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
            System.IO.StreamReader sr = new System.IO.StreamReader("contact.txt");
            System.IO.StreamWriter sw = new System.IO.StreamWriter("contact.txt");
            sw.Flush();
            string[] contactArray = sr.ReadLine().Split(',');
            Contacts contact = new Contacts(contactArray[0], contactArray[1], Convert.ToInt32(contactArray[2]), contactArray[3], Convert.ToInt32(contactArray[4]), contactArray[5]);
        }
    }
    public class Contacts
    {
        public string firstName, lastName, emailAdress, monthBorn;
        public int yearBorn, dayBorn;
        public DateTime birthDay = new DateTime();
        public Contacts(string fN, string lN, int yB, string mB, int dB, string eA)
        {
            firstName = fN;
            lastName = lN;
            yearBorn = yB;
            monthBorn = mB;
            dayBorn = dB;
            emailAdress = eA;
        }
        public string ReadFromFile ()
        {
            return "Hi";
        }
        public void SaveToFile()
        {

        }
        public string getAge()
        {
            return "Hi";
        }
    }

}
