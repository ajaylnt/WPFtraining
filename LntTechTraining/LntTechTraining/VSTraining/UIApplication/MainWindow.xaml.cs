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

namespace UIApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
     
    }

        //This is an event handler for the click event of the Button.  
        private void onClick(object sender, RoutedEventArgs e)
        {     
            // firstDemo();
            displayOutput();
        }

        private void displayOutput()
        {
            string message = string.Format("The Name entered is {0}\nThe Address entered is {1}\nThe Salary requested is {2}", txtName.Text, txtAddress.Text, txtSalary.Text);
            //Text is a property which contain the data that the user has entered into the controll...
            MessageBox.Show(message);
        }

        private static void firstDemo()
        {
            //MessageBox is a class that contain a function called Show to display a dialog box that draws the attention of the user to the center of the screen and will remain so till the user closes it. MeanWhile the user cannot shift the focus to the main window until the MessageBox is closed...
            var result = MessageBox.Show("Good Morning!!!!", "UI Application", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
                MessageBox.Show("OK was pressed");
            else
                MessageBox.Show("Cancel or ESC was pressed");
        }
    }
}
