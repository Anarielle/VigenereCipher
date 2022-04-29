using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereCipher
{
    public class Cipher
    {
        public static string[] vigenerSquare =
        {
             "абвгдеёжзийклмнопрстуфхцчшщъыьэюя",
             "бвгдеёжзийклмнопрстуфхцчшщъыьэюяа",
             "вгдеёжзийклмнопрстуфхцчшщъыьэюяаб",
             "гдеёжзийклмнопрстуфхцчшщъыьэюяабв",
             "деёжзийклмнопрстуфхцчшщъыьэюяабвг",
             "еёжзийклмнопрстуфхцчшщъыьэюяабвгд",
             "ёжзийклмнопрстуфхцчшщъыьэюяабвгде",
             "жзийклмнопрстуфхцчшщъыьэюяабвгдеё",
             "зийклмнопрстуфхцчшщъыьэюяабвгдеёж",
             "ийклмнопрстуфхцчшщъыьэюяабвгдеёжз",
             "йклмнопрстуфхцчшщъыьэюяабвгдеёжзи",
             "клмнопрстуфхцчшщъыьэюяабвгдеёжзий",
             "лмнопрстуфхцчшщъыьэюяабвгдеёжзийк",
             "мнопрстуфхцчшщъыьэюяабвгдеёжзийкл",
             "нопрстуфхцчшщъыьэюяабвгдеёжзийклм",
             "опрстуфхцчшщъыьэюяабвгдеёжзийклмн",
             "прстуфхцчшщъыьэюяабвгдеёжзийклмно",
             "рстуфхцчшщъыьэюяабвгдеёжзийклмноп",
             "стуфхцчшщъыьэюяабвгдеёжзийклмнопр",
             "туфхцчшщъыьэюяабвгдеёжзийклмнопрс",
             "уфхцчшщъыьэюяабвгдеёжзийклмнопрст",
             "фхцчшщъыьэюяабвгдеёжзийклмнопрсту",
             "хцчшщъыьэюяабвгдеёжзийклмнопрстуф",
             "цчшщъыьэюяабвгдеёжзийклмнопрстуфх",
             "чшщъыьэюяабвгдеёжзийклмнопрстуфхц",
             "шщъыьэюяабвгдеёжзийклмнопрстуфхцч",
             "щъыьэюяабвгдеёжзийклмнопрстуфхцчш",
             "ъыьэюяабвгдеёжзийклмнопрстуфхцчшщ",
             "ыьэюяабвгдеёжзийклмнопрстуфхцчшщъ",
             "ьэюяабвгдеёжзийклмнопрстуфхцчшщъы",
             "эюяабвгдеёжзийклмнопрстуфхцчшщъыь",
             "юяабвгдеёжзийклмнопрстуфхцчшщъыьэ",
             "яабвгдеёжзийклмнопрстуфхцчшщъыьэю"
        };

        public string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        public string Encrypt(string text, string key)
        {
            string[] textArr = text.Split(' ');
            int row;
            int collumn;
            int countLength = 0;
            string newText = "";
            string newKey = "";

            foreach (var item in key)
            {
                if (alphabet.Contains(Char.ToLower(item)))
                {
                    newKey += item;
                }
            }
            if(newKey.Length == 0)
            {
                return text;
            }
            for (int i = 0; i < textArr.Length; i++)
            {
                char[] word = textArr[i].ToCharArray();
                for (int j = 0; j < word.Length; j++)
                {
                    if (alphabet.Contains(Char.ToLower(word[j])))
                    {
                        collumn = alphabet.IndexOf(Char.ToLower(word[j]));
                        row = alphabet.IndexOf(Char.ToLower(newKey[countLength % newKey.Length]));
                        if (char.IsUpper(word[j]))
                        {
                            newText += Char.ToUpper(vigenerSquare[row][collumn]);
                        }
                        else
                        {
                            newText += Char.ToLower(vigenerSquare[row][collumn]);
                        }
                        countLength++;
                    }
                    else
                    {
                        newText += word[j];
                    }
                }
                if (i != textArr.Length - 1)
                {
                    newText += ' ';
                }
            }
            return newText;
        }
        public string Decrypt(string text, string key)
        {
            string[] textArr = text.Split(' ');
            int row;
            int collumn;
            int countLength = 0;
            string newText = "";
            string newKey = "";

            foreach (var item in key)
            {
                if (alphabet.Contains(Char.ToLower(item)))
                {
                    newKey += item;
                }
            }
            if (newKey.Length == 0)
            {
                return text;
            }

            for (int i = 0; i < textArr.Length; i++)
            {
                char[] word = textArr[i].ToCharArray();
                for (int j = 0; j < word.Length; j++)
                {
                    if (alphabet.Contains(Char.ToLower(word[j])))
                    {
                        row = alphabet.IndexOf(Char.ToLower(newKey[countLength % newKey.Length]));
                        collumn = vigenerSquare[row].IndexOf(Char.ToLower(word[j]));
                        if (char.IsUpper(word[j]))
                        {
                            newText += Char.ToUpper(alphabet[collumn]);
                        }
                        else
                        {
                            newText += Char.ToLower(alphabet[collumn]);
                        }
                        countLength++;
                    }
                    else
                    {
                        newText += word[j];
                    }
                }
                if (i != textArr.Length - 1)
                {
                    newText += ' ';
                }
            }
            return newText;
        }
    }
}
