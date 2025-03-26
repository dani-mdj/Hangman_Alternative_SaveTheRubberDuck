using RubberDuckConsole;

internal class DuckyConsole : IHangmanUI
{
    
    private Hangman hang;

    public DuckyConsole()
    {
        hang = new Hangman();
    }
    public void DrawBoard()
    {
        Console.Clear();
        Console.Write(ImageString());
        Console.WriteLine();
        DrawCountDown();
        DrawPassword();
        for (int i = 0; i < 73; i++)
        {
            Console.Write("_");
        }
        DrawLetters();
        
    }

    private void DrawLetters()
    {
        Console.WriteLine("\n\nAvailable Letters\n");
        for (int i = 0; i < 73; i++)
        {
            Console.Write("_");
        }
        Console.WriteLine("\n");
        char[] letters = hang.GetLetters();
        for (int i = 0; i < letters.Length; i++)
        {
            Console.Write($"{letters[i],5}");
            if (i == 12)
            {
                Console.WriteLine();
            }

        }
    }

    private void DrawPassword()
    {
        Console.WriteLine("Enter Your Password To Stop Countdown:\n");
        char[] word = hang.GetWord();

        foreach (char character in word)
        {
            foreach (char letter in hang.GetLetters())
            {
                if (letter == character)
                {
                    Console.Write("___ ");
                    break;
                }
                else if (letter == 'z')
                {
                    Console.Write($" {character} ");
                }
            }

        }
        Console.WriteLine();
    }

    private string ImageString()
    {
        string image = "                                                    \r\n"
                + "    ____              ____________                    _,,_______________\r\n"
                + "   ||  ||     _      (__((__((___()                  //|                |\r\n"
                + "   ||__||   >(.)__  (__((__((___()()________________// |  "
                + $"Attemps: { 11 - hang.GetTurns(), 2}"
                + "   |\r\n"
                + "   [ -=.]`)  (___/ (__((__((___()()()---------------'  |________________|\r\n"
                + "   ====== 0 \r\n";

        return image;
    }

    public void DrawCountDown()
    {
        Console.Write($"{hang.GetTurns()} TRIES REMAINING\n ");
    }

    public void Introduction()
    {
        Console.Clear();
        Console.WriteLine("OH NO!\n"
                + "You were so frustrated with your code you decided to blow up your computer!\n "
                + "However you realized you left behind your favorite rubber duck *gasp*!\n\n"
                + "You can't seem to remember the password to stop the explosion\n"
                + "but you allowed 11 tries to guess the letters.\n\n"
                + "You can do this! Save the Rubber Duck!\n\n"
                + "GOOD LUCK\n\n");

        for (int i = 0; i < 75; i++)
        {
            Console.Write("_");
        }
        Console.WriteLine("\nHit enter to begin");
        Console.ReadLine();
    }

    public bool PlayAgain()
    {
        Console.WriteLine("Want to play again? (y for yes, any key for quit)");
        String answer = Console.ReadLine();
        if (string.Equals(answer, "y", StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }
        else
        {
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine("Game by Danielle Jenson");
            return false;
        }
    }

    public bool PlayerTurn()
    {
        char guess = GetInput();
        bool isWinner = hang.DoTurn(guess);

        if (isWinner)
        {
            DrawBoard();
            Celebrate();
            return false;
        }
        else if (hang.GameOver())
        {
            Boom();
            return false;
        }
        else
        {
            return true;
        }
    }

    private void Boom()
    {
        Console.Clear();
        Console.WriteLine("          _ ._  _ , _ ._\r\n"
                + "        (_ ' ( `  )_  .__)\r\n"
                + "      ( (  (    )   `)  ) _)\r\n"
                + "     (__ (_   (_ . _) _) ,__)\r\n"
                + "         `~~`\\ ' . /`~~`\r\n"
                + "              ;   ;\r\n"
                + "              /   \\\r\n"
                + "_____________/_ __ \\_____________\n\n");
        Console.WriteLine($"Your password was \n{new String(hang.GetWord())}\ntry not to forget your duck next time.\n\n" );
    }

    private void Celebrate()
    {
        Console.WriteLine("\nYOU DID IT\nTHE RUBBER DUCK IS SAVED\n\n");
    }

    private char GetInput()
    {
        char guess = '8';
        Console.WriteLine("\n\nGuess a letter in your password:");
        bool notValidGuess = true;
        while (notValidGuess)
        {
            try
            {
                guess = Console.ReadLine()[0];
                if (Char.IsLetter(guess))
                {
                    notValidGuess = false;
                }
                else
                {
                    Console.WriteLine("This password can only contain letters. Enter a letter!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("invalid guess, guess a letter");
            }
        }
        return guess;
    }
}