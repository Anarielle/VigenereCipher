using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VigenereCipher;

namespace VigenereCipherTests
{
    [TestClass]
    public class CryptTest
    {
        [TestMethod]
        public void TestDefaultKey()
        {
            //Arrange
            string text = "Равным образом, повышение уровня гражданского сознания обеспечивает широкому кругу (специалистов) участие в формировании поставленных обществом задач!";
            string key = "Ключ";
            bool encrypt = true;
            string expected = "";
            Cipher cipher = new Cipher();

            //Act
            string actual = Interactions.Crypt(text, key, encrypt);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDefaultText()
        {
            //Arrange
            string text = "Введите свой текст";
            string key = "кот";
            bool encrypt = true;
            string expected = "";
            Cipher cipher = new Cipher();

            //Act
            string actual = Interactions.Crypt(text, key, encrypt);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        public void DecryptTestDefaultKey()
        {
            //Arrange
            string text = "Равным образом, повышение уровня гражданского сознания обеспечивает широкому кругу (специалистов) участие в формировании поставленных обществом задач!";
            string key = "Ключ";
            bool encrypt = false;
            string expected = "";
            Cipher cipher = new Cipher();

            //Act
            string actual = Interactions.Crypt(text, key, encrypt);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DecryptTestDefaultText()
        {
            //Arrange
            string text = "Введите свой текст";
            string key = "кот";
            bool encrypt = false;
            string expected = "";
            Cipher cipher = new Cipher();

            //Act
            string actual = Interactions.Crypt(text, key, encrypt);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
