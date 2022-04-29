using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VigenereCipher;

namespace VigenereCipherTests
{
    [TestClass]
    public class DecryptTest
    {
        [TestMethod]
        public void TestDecrypt()
        {
            //Arrange
            string text = "Хлрь б Пюкьы дшхтц цобнрюё";
            string key = "кларнет";
            string expected = "Карл у Клары украл кораллы";
            Cipher cipher = new Cipher();

            //Act
            string actual = cipher.Decrypt(text, key);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEng()
        {
            //Arrange
            string text = "Nulla et dui tempus ex. Et. Cras non amet, sapie.";
            string key = "Привет";
            string expected = "Nulla et dui tempus ex. Et. Cras non amet, sapie.";
            Cipher cipher = new Cipher();

            //Act
            string actual = cipher.Decrypt(text, key);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSymbolInKey()
        {
            //Arrange
            string text = "Быгнлз пббыиоэ, кпвлуёнща фряэоя улбжфыосыйдо вйинрийя яьёсаашитыёт идсоыйну ылфгд (мреждблщмуот) ошавнйе т ппрэдсотыоищ кпсгыглхиоыё йвщхмувяз иафыш!";            
            string key = "рыба!1";
            string expected = "Равным образом, повышение уровня гражданского сознания обеспечивает широкому кругу (специалистов) участие в формировании поставленных обществом задач!";
            Cipher cipher = new Cipher();

            //Act
            string actual = cipher.Decrypt(text, key);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestWhiteSpaceInKey()
        {
            //Arrange
            string text = "Еьуёшто юбпхёпчй, асв бойёнюыурювл нхщючюэл иьзфш аэгжчцс, пужчртнзльсх авэщнмьх ютйслюъгуулч ынжутчунъчф атяехёи щдуьчйедеш содфхпьхъеьуптис аофвжнитцзэ.";            
            string key = "уровень погружения";
            string expected = "Следует отметить, что разбавленное изрядной долей эмпатии, рациональное мышление предполагает независимые способы реализации глубокомысленных рассуждений.";
            Cipher cipher = new Cipher();

            //Act
            string actual = cipher.Decrypt(text, key);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEngInKey()
        {
            //Arrange
            string text = "Следует отметить, что разбавленное изрядной долей эмпатии, рациональное мышление предполагает независимые способы реализации глубокомысленных рассуждений.";
            string key = "Integer";
            string expected = "Следует отметить, что разбавленное изрядной долей эмпатии, рациональное мышление предполагает независимые способы реализации глубокомысленных рассуждений.";
            Cipher cipher = new Cipher();

            //Act
            string actual = cipher.Decrypt(text, key);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestEngInBoth()
        {
            //Arrange
            string text = "Nulla et dui tempus ex. Et. Cras non amet, sapie.";
            string key = "Integer";
            string expected = "Nulla et dui tempus ex. Et. Cras non amet, sapie.";
            Cipher cipher = new Cipher();

            //Act
            string actual = cipher.Decrypt(text, key);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
