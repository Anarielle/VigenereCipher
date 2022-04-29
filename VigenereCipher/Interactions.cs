using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VigenereCipher
{
    public class Interactions
    {
        public static string Open()
        {
            string text = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                string path = openFileDialog.FileName;
                using (StreamReader sr = new StreamReader(path))
                {
                    text = File.ReadAllText(path, Encoding.Default);
                }
            }
            return text;
        }
        public static void Save(string result)
        {
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Выполните шифрацию или дешифрацию текста, чтобы сохранить его");
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "txt files (*.txt)|*.txt";
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, result);
                }
            }
        }

        public static string Crypt(string text, string key, bool encrypt)
        {
            Cipher cipher = new Cipher();
            if (text == "Введите свой текст" || key == "Ключ")
            {
               return "";
            }
            else
            {
                if (encrypt)
                {
                    return cipher.Encrypt(text, key);
                }
                else
                {
                    return cipher.Decrypt(text, key);
                }
            }
        }
    }
}
