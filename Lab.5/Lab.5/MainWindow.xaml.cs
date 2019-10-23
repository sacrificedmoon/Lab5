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

//Sofia Lindgren & Robin Nurmisto

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
            Users.users.Add(new Users(userInputName, userInputMail));
            RefreshListBoxes();
            ClearTextFields();
        }

        private void MakeAdminButton_Click(object sender, RoutedEventArgs e)
        {
            if(UserListBox.SelectedIndex > -1)
            {
                var selected = Users.users[UserListBox.SelectedIndex];
                Users.admins.Add(selected);
                Users.users.Remove(selected);
            }
            ClearTextFields();
            RefreshListBoxes();
        }

        private void RemoveAdminButton_Click(object sender, RoutedEventArgs e)
        {
            if(AdminListBox.SelectedIndex > -1)
            {
                var selected = Users.admins[AdminListBox.SelectedIndex];
                Users.users.Add(selected);
                Users.admins.Remove(selected);
            }
            ClearTextFields();
            RefreshListBoxes();
        }

        private void EditUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selected = Users.users[UserListBox.SelectedIndex];
            userInputName = NameBox.Text;
            userInputMail = EmailBox.Text;
            if (selected != null)
            {
                selected.Name = userInputName;
                selected.Mail = userInputMail;
                RefreshListBoxes();
                ClearTextFields();
                UserListBox.UnselectAll();
            }
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selected = Users.users[UserListBox.SelectedIndex];
            Users.users.Remove(selected);
            ClearTextFields();
            RefreshListBoxes();
        }

        private void UserListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserListBox.SelectedItem != null)
            {
                AdminListBox.UnselectAll();
                ClearTextFields();
                var selected = (UserListBox.SelectedItem as Users);
                NameBox.Text = selected.Name;
                EmailBox.Text = selected.Mail;
                MakeAdminButton.IsEnabled = true;
                EditUserButton.IsEnabled = true;
                DeleteUserButton.IsEnabled = true;
            }
            else
            {
                MakeAdminButton.IsEnabled = false;
                EditUserButton.IsEnabled = false;
                DeleteUserButton.IsEnabled = false;
            }
        }

        private void AdminListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AdminListBox.SelectedItem != null)
            {
                UserListBox.UnselectAll();
                ClearTextFields();
                var selected = (AdminListBox.SelectedItem as Users);
                NameBox.Text = selected.Name;
                EmailBox.Text = selected.Mail;
                RemoveAdminButton.IsEnabled = true;
            }
            else
            {
                RemoveAdminButton.IsEnabled = false;
            }
        }
    }
}
