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
            Error();
            tbResult.Text = Interactions.Crypt(tbText.Text, tbKey.Text, (bool)rbEncrypt.IsChecked);
        }

        private void mOpen_Click(object sender, RoutedEventArgs e)
        {
            tbText.Text = Interactions.Open();
        }

        private void mSave_Click(object sender, RoutedEventArgs e)
        {
            Error();
            Interactions.Save(tbResult.Text);
        }

        private void tbText_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            tbText.BorderBrush = new SolidColorBrush(Color.FromRgb(154, 196, 236));
            tbText.Background = Brushes.White;
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
            tbKey.BorderBrush = Brushes.Gray;
            tbKey.Background = Brushes.White;
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
            tbText.BorderBrush = new SolidColorBrush(Color.FromRgb(154, 196, 236));
            tbText.Background = Brushes.White;
        }

        public void Error()
        {
            SolidColorBrush lightRed = new SolidColorBrush(Color.FromRgb(224, 102, 102));
            SolidColorBrush pink = new SolidColorBrush(Color.FromRgb(224, 204, 204));
            if (tbText.Text == "Введите свой текст" && tbKey.Text == "Ключ")
            {
                tbText.BorderBrush = lightRed;
                tbText.Background = pink;
                tbKey.BorderBrush = lightRed;
                tbKey.Background = pink;
            }
            else if (tbText.Text == "Введите свой текст")
            {
                tbText.BorderBrush = lightRed;
                tbText.Background = pink;

            }
            else if (tbKey.Text == "Ключ")
            {
                tbKey.BorderBrush = lightRed;
                tbKey.Background = pink;
            }
        }
    }
}
