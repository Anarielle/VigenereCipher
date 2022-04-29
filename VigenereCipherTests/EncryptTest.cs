using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VigenereCipher;

namespace VigenereCipherTests
{
    [TestClass]
    public class EncryptTest
    {
        [TestMethod]
        public void TestEncrypt()
        {
            //Arrange
            string text = "Карл у Клары украл кораллы";
            string key = "кларнет";
            string expected = "Хлрь б Пюкьы дшхтц цобнрюё";
            Cipher cipher = new Cipher();

            //Act
            string actual = cipher.Encrypt(text, key);

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
            string actual = cipher.Encrypt(text, key);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSymbolInKey()
        {
            //Arrange
            string text = "Равным образом, повышение уровня гражданского сознания обеспечивает широкому кругу (специалистов) участие в формировании поставленных обществом задач!";
            string key = "рыба!1";
            string expected = "Быгнлз пббыиоэ, кпвлуёнща фряэоя улбжфыосыйдо вйинрийя яьёсаашитыёт идсоыйну ылфгд (мреждблщмуот) ошавнйе т ппрэдсотыоищ кпсгыглхиоыё йвщхмувяз иафыш!";
            Cipher cipher = new Cipher();

            //Act
            string actual = cipher.Encrypt(text, key);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestWhiteSpaceInKey()
        {
            //Arrange
            string text = "Следует отметить, что разбавленное изрядной долей эмпатии, рациональное мышление предполагает независимые способы реализации глубокомысленных рассуждений.";
            string key = "уровень погружения";
            string expected = "Еьуёшто юбпхёпчй, асв бойёнюыурювл нхщючюэл иьзфш аэгжчцс, пужчртнзльсх авэщнмьх ютйслюъгуулч ынжутчунъчф атяехёи щдуьчйедеш содфхпьхъеьуптис аофвжнитцзэ.";
            Cipher cipher = new Cipher();

            //Act
            string actual = cipher.Encrypt(text, key);

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
            string actual = cipher.Encrypt(text, key);

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
            string actual = cipher.Encrypt(text, key);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
