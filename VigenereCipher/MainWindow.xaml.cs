using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace VigenereCipher
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void bCrypt_Click(object sender, RoutedEventArgs e)
        {
            tbResult.Text = Interactions.Crypt(tbText.Text, tbKey.Text, (bool)rbEncrypt.IsChecked);
        }

        private void mOpen_Click(object sender, RoutedEventArgs e)
        {
            tbText.Text = Interactions.Open();
        }

        private void mSave_Click(object sender, RoutedEventArgs e)
        {
            Interactions.Save(tbResult.Text);
        }

        private void tbText_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (tbText.IsKeyboardFocused)
            {
                if (tbText.Text == "Введите свой текст")
                {
                    tbText.Clear();
                    tbText.Foreground = Brushes.Black;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(tbText.Text))
                {

                    tbText.Text = "Введите свой текст";
                    tbText.Foreground = Brushes.Gray;
                }
            }
        }

        private void tbKey_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (tbKey.IsKeyboardFocused)
            {
                if (tbKey.Text == "Ключ")
                {
                    tbKey.Clear();
                    tbKey.Foreground = Brushes.Black;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(tbKey.Text))
                {
                    tbKey.Foreground = Brushes.Gray;
                    tbKey.Text = "Ключ";
                }
            }
        }
        private void tbText_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbText.Foreground = Brushes.Black;
        }
    }
}
