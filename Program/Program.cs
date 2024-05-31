using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba7AOIS
{
  

    public class TwoDMatrix
    {
        private int matrixSize_;
        private bool[,] matrix_;

        public TwoDMatrix() : this(0) { }

        public TwoDMatrix(int size)
        {
            matrixSize_ = size;
            matrix_ = new bool[matrixSize_, matrixSize_];
            FullMatrix();
        }

        private void FullMatrix()
        {
            Random rand = new Random();
            for (int i = 0; i < matrixSize_; i++)
            {
                for (int j = 0; j < matrixSize_; j++)
                {
                    matrix_[i, j] = rand.Next(2) == 0;
                }
            }
        }

        private List<bool> MatchCoincidence(string key, List<string> listToCheck)
        {
            List<bool> checkMatch = new List<bool>();
            for (int i = 0; i < listToCheck.Count; i++)
            {
                checkMatch.Add(listToCheck[i].StartsWith(key));
            }

            // Debug output
            Console.WriteLine("Key: " + key);
            for (int i = 0; i < checkMatch.Count; i++)
            {
                Console.WriteLine("Word: " + listToCheck[i] + ", Match: " + checkMatch[i]);
            }

            return checkMatch;
        }


        private List<string> TransformToListOfStr(int startIndex, int finishIndex)
        {
            List<string> wordList = new List<string>();
            for (int i = startIndex; i < finishIndex; i++)
            {
                wordList.Add(FindWordWithIndex(i));
            }
            return wordList;
        }

        public void ChangeWord(string newWord, int resultIndex)
        {
            for (int i = 0; i < matrixSize_; i++)
            {
                matrix_[resultIndex, i] = newWord[i] == '0' ? false : true;
            }
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < matrixSize_; i++)
            {
                for (int j = 0; j < matrixSize_; j++)
                {
                    Console.Write(matrix_[i, j] ? "1 " : "0 ");
                }
                Console.WriteLine();
            }
        }

        public string FindWordWithIndex(int index)
        {
            string result = "";
            for (int i = 0; i < matrixSize_; i++)
            {
                result += matrix_[index, i] ? "1" : "0";
            }
            return result;
        }

        public string FindAddressWordWithIndex(int index)
        {
            string result = "";
            for (int j = 0; j < matrixSize_; j++)
            {
                result += matrix_[j, index] ? "1" : "0";
            }
            return result;
        }

        public string LogicFunctionUnequal(int firstIndex, int secondIndex, int resultIndex)
        {
            string result = "";
            string firstWord = FindWordWithIndex(firstIndex);
            string secondWord = FindWordWithIndex(secondIndex);
            for (int i = 0; i < matrixSize_; i++)
            {
                char symbol = firstWord[i] == secondWord[i] ? '0' : '1';
                result += symbol;
            }
            ChangeWord(result, resultIndex);
            return result;
        }

        public string LogicFunctionEqual(int firstIndex, int secondIndex, int resultIndex)
        {
            string result = "";
            string firstWord = FindWordWithIndex(firstIndex);
            string secondWord = FindWordWithIndex(secondIndex);
            for (int i = 0; i < matrixSize_; i++)
            {
                char symbol = firstWord[i] == secondWord[i] ? '1' : '0';
                result += symbol;
            }
            ChangeWord(result, resultIndex);
            return result;
        }

        public string LogicFormulaSecondArgumentProhibition(int firstIndex, int secondIndex, int resultIndex)
        {
            string result = "";
            string firstWord = FindWordWithIndex(firstIndex);
            string secondWord = FindWordWithIndex(secondIndex);
            for (int i = 0; i < matrixSize_; i++)
            {
                char symbol = (firstWord[i] == '0' && secondWord[i] == '1') ? '1' : '0';
                result += symbol;
            }
            ChangeWord(result, resultIndex);
            return result;
        }

        public string LogicFunctionImplicationOfTheSecondArgumentToTheFirst(int firstIndex, int secondIndex, int resultIndex)
        {
            string result = "";
            string firstWord = FindWordWithIndex(firstIndex);
            string secondWord = FindWordWithIndex(secondIndex);
            for (int i = 0; i < matrixSize_; i++)
            {
                char symbol = (firstWord[i] == '0' && secondWord[i] == '1') ? '0' : '1';
                result += symbol;
            }
            ChangeWord(result, resultIndex);
            return result;
        }

        public int FindMaxWord(List<string> listToCheck, int degree)
        {
            string key = "1";
            List<bool> checkMatch = new List<bool>(new bool[listToCheck.Count]);
            checkMatch = MatchCoincidence(key, listToCheck);
            int iterationCount = 0;

            while (checkMatch.FindAll(x => x).Count != 1)
            {
                iterationCount++;
                if (iterationCount > 100) // Prevent infinite loop for debugging purposes
                {
                    Console.WriteLine("Infinite loop detected. Exiting.");
                    break;
                }

                int matchCount = checkMatch.FindAll(x => x).Count;
                if (matchCount > 1)
                {
                    key += '1';
                }
                else if (matchCount == 0)
                {
                    key = key.Remove(key.Length - 1) + '0';
                    key += '1';
                }
                else
                {
                    break;
                }

                checkMatch = MatchCoincidence(key, listToCheck);
                Console.WriteLine("Current key: " + key); // Debugging output
            }

            int index = checkMatch.FindIndex(x => x);
            Console.WriteLine("Found index: " + index); // Debugging output

            if (index == -1) // If no match found, return the first element or handle appropriately
            {
                index = 0;
            }

            return index + degree;
        }




        public void Sort()
        {
            Console.WriteLine("Words in descending order: ");
            for (int i = 0; i < matrixSize_; i++)
            {
                List<string> wordList = TransformToListOfStr(i, matrixSize_);
                int indexMax = FindMaxWord(wordList, i);
                if (indexMax == -1)
                {
                    Console.WriteLine("No valid index found for degree " + i);
                    continue; // Skip to the next iteration if no valid index found
                }
                string wordToChange = FindWordWithIndex(i);
                Console.WriteLine(FindWordWithIndex(indexMax));
                ChangeWord(FindWordWithIndex(indexMax), i);
                ChangeWord(wordToChange, indexMax);
            }
        }


        private string ToBinary(int number)
        {
            return Convert.ToString(number, 2).PadLeft(5, '0');
        }

        private int BinaryToDecimal(string binary)
        {
            return Convert.ToInt32(binary, 2);
        }

        public void SummaOfFields()
        {
            List<string> wordList = TransformToListOfStr(0, matrixSize_);
            List<bool> checkMatch = new List<bool>(new bool[wordList.Count]);
            checkMatch = MatchCoincidence("111", wordList);
            for (int i = 0; i < matrixSize_; i++)
            {
                if (checkMatch[i])
                {
                    Console.Write("(" + i + ") " + FindWordWithIndex(i) + " -> ");
                    string currentWord = FindWordWithIndex(i);
                    int numA = BinaryToDecimal(currentWord.Substring(3, 4));
                    int numB = BinaryToDecimal(currentWord.Substring(7, 4));
                    int summa = numA + numB;
                    currentWord = currentWord.Remove(11, 5) + ToBinary(summa);
                    Console.WriteLine(currentWord);
                    ChangeWord(currentWord, i);
                }
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            int indexWord1, indexWord2, indexWordResult, indexAddress;
            TwoDMatrix matrix = new TwoDMatrix(16);
            matrix.PrintMatrix();
            Console.WriteLine("Enter index of word: ");
            indexWord1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Word: " + matrix.FindWordWithIndex(indexWord1) + Environment.NewLine);
            Console.WriteLine("Enter index of address word: ");
            indexAddress = int.Parse(Console.ReadLine());
            Console.WriteLine("Address word: " + matrix.FindAddressWordWithIndex(indexAddress) + Environment.NewLine);

            Console.WriteLine("Enter index of the first word: ");
            indexWord1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter index of the second word: ");
            indexWord2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter index of the column to write result: ");
            indexWordResult = int.Parse(Console.ReadLine());
            Console.WriteLine("Unequal: ");
            Console.WriteLine(matrix.FindWordWithIndex(indexWord1));
            Console.WriteLine(matrix.FindWordWithIndex(indexWord2));
            Console.WriteLine(matrix.LogicFunctionUnequal(indexWord1, indexWord2, indexWordResult));
            matrix.PrintMatrix();
            Console.WriteLine("Equal: ");
            Console.WriteLine(matrix.FindWordWithIndex(indexWord1));
            Console.WriteLine(matrix.FindWordWithIndex(indexWord2));
            Console.WriteLine(matrix.LogicFunctionEqual(indexWord1, indexWord2, indexWordResult));
            matrix.PrintMatrix();
            Console.WriteLine("Second argument prohibition: ");
            Console.WriteLine(matrix.FindWordWithIndex(indexWord1));
            Console.WriteLine(matrix.FindWordWithIndex(indexWord2));
            Console.WriteLine(matrix.LogicFormulaSecondArgumentProhibition(indexWord1, indexWord2, indexWordResult));
            matrix.PrintMatrix();
            Console.WriteLine("Second argument prohibition: ");
            Console.WriteLine(matrix.FindWordWithIndex(indexWord1));
            Console.WriteLine(matrix.FindWordWithIndex(indexWord2));
            Console.WriteLine(matrix.LogicFunctionImplicationOfTheSecondArgumentToTheFirst(indexWord1, indexWord2, indexWordResult));
            matrix.PrintMatrix();

            Console.WriteLine("Sort: ");
            matrix.Sort();
            matrix.PrintMatrix();
            Console.WriteLine("Addition of fields with a given match: ");
            matrix.SummaOfFields();
            matrix.PrintMatrix();
            Console.ReadLine();
        }
    }

}
