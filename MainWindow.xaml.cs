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
using System.Xml.Linq;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XElement myRoot;
        XDocument mySeminaries;
            string path = "   C: \\Users\\m - sys\\Source\\Repos\\WpfApp1\\WpfApp1\\bin\\Debug\\seminaries.xml";
            public MainWindow()
        {
            InitializeComponent(); 
            //MessageBox.Show("fdgdfhg");
            //טעינת מסמך
             mySeminaries = XDocument.Load("seminaries.xml");
        // path = $@"C:\Users\m-sys\Source\Repos\WpfApp1\WpfApp1\bin\Debug\{TextBox1.Text}.xml";
       
            myRoot = mySeminaries.Root;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
       //  Show("Test");  
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           //שליפת תכונה
            MessageBox.Show(myRoot.Attribute("manager").Value);
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"מספר הכיתות הוא:{myRoot.Descendants("Class").Count()}");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var teachers = myRoot.Descendants("Class").Attributes("teacher");
            myGrid.DataContext = teachers.Select(x=>new { שם_המורה=x.Value,כמות_תלמידות=x.Parent.Elements("student").Count()}).ToList();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            XElement yud1 = new XElement("Class",
                new XElement("student",new XAttribute("name","מיכל לוי")),
                new XAttribute("name", "י1"), new XAttribute("teacher", "לוי"));
            XElement shnatonYud = myRoot.Descendants("Shnaton").Single(x => x.Attribute("classes").Value == "י");
            shnatonYud.Add(yud1);
            mySeminaries.Save(@"seminaries.xml");

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

        }
    }
}
