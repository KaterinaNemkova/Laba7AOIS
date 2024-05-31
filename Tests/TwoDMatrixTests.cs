using Microsoft.VisualStudio.TestTools.UnitTesting;
using Laba7AOIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba7AOIS.Tests
{
    [TestClass()]
    public class TwoDMatrixTests
    {
        [TestMethod]
        public void FindWordWithIndexTest()
        {
            string result = "0000000000000000";
            TwoDMatrix matrix = new TwoDMatrix(16);
            for (int i = 0; i < 16; i++)
            {
                matrix.ChangeWord(result, i);
            }
            Assert.AreEqual(result, matrix.FindWordWithIndex(5));
        }

        [TestMethod]
        public void FindAddressWordWithIndexTest()
        {
            string result = "0000000000000000";
            TwoDMatrix matrix = new TwoDMatrix(16);
            for (int i = 0; i < 16; i++)
            {
                matrix.ChangeWord(result, i);
            }
            Assert.AreEqual(result, matrix.FindAddressWordWithIndex(5));
        }


        [TestMethod]
        public void LogicFunctionUnequalTest()
        {
            string result = "0011000000101100", str1 = "1001001001001001", str2 = "1010001001100101";
            TwoDMatrix matrix = new TwoDMatrix(16);
            matrix.ChangeWord(str1, 0);
            matrix.ChangeWord(str2, 1);
            matrix.LogicFunctionUnequal(0, 1, 2);
            Assert.AreEqual(result, matrix.FindWordWithIndex(2));
        }

        [TestMethod]
        public void LogicFunctionEqualTest()
        {
            string result = "1100111111010011", str1 = "1001001001001001", str2 = "1010001001100101";
            TwoDMatrix matrix = new TwoDMatrix(16);
            matrix.ChangeWord(str1, 0);
            matrix.ChangeWord(str2, 1);
            matrix.LogicFunctionEqual(0, 1, 2);
            Assert.AreEqual(result, matrix.FindWordWithIndex(2));
        }

        [TestMethod]
        public void LogicFormulaSecondArgumentProhibitionTest()
        {
            string result = "0010000000100100", str1 = "1001001001001001", str2 = "1010001001100101";
            TwoDMatrix matrix = new TwoDMatrix(16);
            matrix.ChangeWord(str1, 0);
            matrix.ChangeWord(str2, 1);
            matrix.LogicFormulaSecondArgumentProhibition(0, 1, 2);
            Assert.AreEqual(result, matrix.FindWordWithIndex(2));
        }

        [TestMethod]
        public void LogicFunctionImplicationOfTheSecondArgumentToTheFirstTest()
        {
            string result = "1101111111011011", str1 = "1001001001001001", str2 = "1010001001100101";
            TwoDMatrix matrix = new TwoDMatrix(16);
            matrix.ChangeWord(str1, 0);
            matrix.ChangeWord(str2, 1);
            matrix.LogicFunctionImplicationOfTheSecondArgumentToTheFirst(0, 1, 2);
            Assert.AreEqual(result, matrix.FindWordWithIndex(2));
        }


        [TestMethod]
        public void TestFindMaxWord()
        {
            TwoDMatrix matrix = new TwoDMatrix(4);
            var wordList = new System.Collections.Generic.List<string>() { "0010", "0001", "1010", "0101" };
            Assert.AreEqual(2, matrix.FindMaxWord(wordList, 0));
        }

        [TestMethod]
        public void SortTest()
        {
            string result = "1111111111111111";
            TwoDMatrix matrix = new TwoDMatrix(16);
            matrix.ChangeWord(result, 5);
            Assert.AreEqual(result, matrix.FindWordWithIndex(5));
            matrix.ChangeWord("0111111111111111", 0);
            matrix.ChangeWord("0011111111111111", 1);
            matrix.ChangeWord("0001111111111111", 2);
            matrix.ChangeWord("1010000000000000", 3);
            matrix.ChangeWord("0010010110111010", 4);
            matrix.ChangeWord("1000000000000000", 6);
            matrix.ChangeWord("1110001101101011", 7);
            matrix.ChangeWord("0000000000001010", 8);
            matrix.ChangeWord("0000111111111111", 9);
            matrix.ChangeWord("1110010011110011", 10);
            matrix.ChangeWord("1100100101100110", 11);
            matrix.ChangeWord("1010110100101010", 12);
            matrix.ChangeWord("0000011111111111", 13);
            matrix.ChangeWord("0000000000001101", 14);
            matrix.ChangeWord("1111000101110110", 15);
            matrix.Sort();
            Assert.AreEqual(result, matrix.FindWordWithIndex(0));
        }

        [TestMethod]
        public void SummaOfFieldsTest()
        {
            string result = "1110010000100011", str1 = "1010101010101010", str2 = "1110010000100000";
            TwoDMatrix matrix = new TwoDMatrix(16);
            matrix.ChangeWord(str1, 0);
            matrix.ChangeWord(str2, 1);
            Assert.AreEqual(str1, matrix.FindWordWithIndex(0));
            Assert.AreEqual(str2, matrix.FindWordWithIndex(1));
            matrix.SummaOfFields();
            Assert.AreEqual(str1, matrix.FindWordWithIndex(0));
            Assert.AreEqual(result, matrix.FindWordWithIndex(1));
        }

    }
}