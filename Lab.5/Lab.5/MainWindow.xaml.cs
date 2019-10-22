﻿using System;
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
        public System.Collections.IEnumerable ItemsSource { get; set; }
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
    }
}
