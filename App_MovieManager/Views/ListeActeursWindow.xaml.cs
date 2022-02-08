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

namespace App_MovieManager.Views
{
    /// <summary>
    /// Logique d'interaction pour ListeActeursWindow.xaml
    /// </summary>
    public partial class ListeActeursWindow : Window
    {
        public ListeActeursWindow()
        {
            InitializeComponent();
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.MaximizeWindow(this);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void EmptyTextboxOnFocus(object sender, RoutedEventArgs e)
        {
            TextBox tbox = (TextBox)sender;
            tbox.Text = string.Empty;
            tbox.GotFocus -= EmptyTextboxOnFocus;
        }

        private void ResetTextboxLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tbox = (TextBox)sender;
            tbox.Text = "Rechercher...";
            tbox.LostFocus += ResetTextboxLostFocus;
        }
    }
}
