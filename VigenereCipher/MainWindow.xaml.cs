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
            Cipher cipher = new Cipher();
            if (tbText.Text == "Введите свой текст" || tbKey.Text == "Ключ")
            {
                MessageBox.Show("пусто");
            }

            else
            {
                if (rbEncrypt.IsChecked == true)
                {
                    tbResult.Text = cipher.Encrypt(tbText.Text, tbKey.Text);
                }
                if (rbDecrypt.IsChecked == true)
                {
                    tbResult.Text = cipher.Decrypt(tbText.Text, tbKey.Text);
                }
            }
        }

        private void mOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            openFileDialog.ShowDialog();
            string path = openFileDialog.FileName;

            Encoding currentEncoding;
            using (StreamReader sr = new StreamReader(path))
            {
                currentEncoding = sr.CurrentEncoding;
            }
            tbText.Text = File.ReadAllText(path, Encoding.Default);
        }

        private void mSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbResult.Text == "")
            {
                MessageBox.Show("Выпроните шифрацию или дешифрацию текста, чтобы сохранить его");
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "txt files (*.txt)|*.txt";
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, tbResult.Text);
                }
            }
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
