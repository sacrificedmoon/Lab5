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

namespace Lab._5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string userInputName;
        public string userInputMail;
        public MainWindow()
        {
            InitializeComponent();
            UserListBox.ItemsSource = Users.users;
            UserListBox.DisplayMemberPath = "Name";
            AdminListBox.ItemsSource = Users.admins;
            AdminListBox.DisplayMemberPath = "Name";
        }

        private void RefreshListBoxes()
        {
            UserListBox.Items.Refresh();
            AdminListBox.Items.Refresh();
        }
        private void ClearTextFields()
        {
            NameBox.Clear();
            EmailBox.Clear();
        }
        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            userInputName = NameBox.Text;
            userInputMail = EmailBox.Text;
            Users.users.Add(new Users(userInputName.Trim(), userInputMail.Replace(" ", "")));
            //Users user = new Users(NameBox.ToString(), EmailBox.ToString());
            RefreshListBoxes();
        }


        private void MakeAdminButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveAdminButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
