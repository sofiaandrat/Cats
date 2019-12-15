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
using System.Windows.Shapes;
using System.Threading;

namespace Cats
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            RegistrationView Registration = new RegistrationView(email.Text, Password.Password, Login.Text);
            Login_in_use.Visibility = Visibility.Hidden;
            if (!Registration.CheckPresenter())
                Registration.Presenter();
            else
                Login_in_use.Visibility = Visibility.Visible;
        }
    }
}