using OldPhonePad_Iron_CoChallenge.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldPhonePad_Iron_CoChallenge.Tests.Class
{
    [TestClass]
    public class PhoneKeypadTests
    {
        [TestMethod]
        public void TestSingleLetterE()
        {
            Assert.AreEqual("E", PhoneKeypad.OldPhonePad("33#"));
        }

        [TestMethod]
        public void TestWithBackspace()
        {
            Assert.AreEqual("B", PhoneKeypad.OldPhonePad("227*#"));
        }

        [TestMethod]
        public void TestHello()
        {
            Assert.AreEqual("HELLO", PhoneKeypad.OldPhonePad("4433555 555666#"));
        }

        [TestMethod]
        public void TestComplexInput()
        {
            Assert.AreEqual("TURING", PhoneKeypad.OldPhonePad("8 88777444664#"));
        }

        [TestMethod]
        public void TestLongInput()
        {
            Assert.AreEqual("IRON SOFT", PhoneKeypad.OldPhonePad("444777666 66077776663338#"));
        }

        [TestMethod]
        public void TestEmptyAfterBackspaces()
        {
            Assert.AreEqual("", PhoneKeypad.OldPhonePad("4433555 555666*******#"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMissingTerminator()
        {
            PhoneKeypad.OldPhonePad("4433555");
        }

        [TestMethod]
        public void TestSpecialCharacters()
        {
            Assert.AreEqual("&'(", PhoneKeypad.OldPhonePad("1 11 111#"));
        }

        [TestMethod]
        public void TestSpaces()
        {
            Assert.AreEqual("AB C", PhoneKeypad.OldPhonePad("2 22 0 222#"));
        }

        [TestMethod]
        public void TestLastExample()
        {
            Assert.AreEqual("TURING", PhoneKeypad.OldPhonePad("8 88777444666*664#"));
        }
    }
}
