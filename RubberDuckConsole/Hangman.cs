using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RubberDuckConsole
{
    internal class Hangman
    {
        private char[] word;
        private char[] letters = {'a', 'b', 'c', 'd',
            'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
            'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
            'w', 'x', 'y', 'z'};
        private string correctGuess = "";
        int turns = 11;
        int win;

        //constructor of the game - chooses the word from a bank of words
        public Hangman()
        {
            word = ChooseWord();
            SetWinCondition();
        }

        //getter and setters for items that require
        //--------------------------------------------

        public char[] GetWord()
        {
            return word;
        }

        public char[] GetLetters()
        {
            return letters;
        }

        public int GetTurns()
        {
            return turns;
        }
        //-------------------------------------------------------
        //method generates a random number in the range of number of words in the file
        private char[] ChooseWord()
        {
            int wordNumber = new Random().Next(1371);
            char[] word = GetWord(wordNumber);
            return word;
        }
        //retrieves the word from the file from given line number
        private char[] GetWord(int line)
        {
            string wordSt = "";
            try  {
                var lines = File.ReadAllLines("words.txt");
                wordSt = lines[line];
            }

        catch (IOException e) { throw new FileNotFoundException(); }

            return wordSt.ToLower().ToCharArray();
        }
        //determines if the guess is in the word or not 
        //and removes letter from available letters
        private void getResult(char guess)
        {
            for (int j = 0; j < word.Length; j++)
            {
                if (word[j] == guess && !(correctGuess.Contains("" + guess)))
                {
                    correctGuess += 1;
                }
            }
            for (int i = 0; i < letters.Length; i++)
            {
                if (guess == letters[i])
                {
                    letters[i] = ' ';
                }
            }
        }
        //back end of a turn - checks the guess then increments turn and checks for winner
        public bool DoTurn(char guess)
        {
            getResult(guess);
            turns -= 1;
            return CheckForWinner();
        }
        //determines if theres a winner by seeing if the number 
        //of correct guesses matches the number of unique letters in the word
        private bool CheckForWinner()
        {
            if (correctGuess.Length == win)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        //sets the win condition to be an array of unique letters in the word
        private void SetWinCondition()
        {
            string allLetters = "";
            foreach (char letter in word)
            {
                if (!(correctGuess.Contains("" + letter)))
                {
                    allLetters += "" + letter;
                }
            }
            win = allLetters.Length;
        }
        //checks if the game is lost by running out of turns
        public bool GameOver()
        {
            if (turns < 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
