using System;
using System.Collections.Generic;

class HigherLower
{
  private int guessNumber = 50;
  private int maxNumber = 100;
  private int minNumber = 0;
  private string _userInput;

  public void SetInput(string input)
  {
    _userInput = input;
  }

  public string GetInput()
  {
    return _userInput;
  }

  private int ceilingAverage(int max, int min)
  {
    if ((max + min) % 2 == 0)
    {
      return (max + min) / 2;
    }
    else
    {
      return ((max + 1) + min) / 2;
    }
  }

  public void Guess()
  {
    if (_userInput == "higher")
    {
      minNumber = guessNumber;
      guessNumber = ceilingAverage(maxNumber, minNumber);
      Console.WriteLine("Is your number higher or lower than " + guessNumber + "? (Higher/Lower/Correct)");

      string input = Console.ReadLine().ToLower();
      SetInput(input);

      Guess();
    }
    else if (_userInput == "lower")
    {
      maxNumber = guessNumber;
      guessNumber = ceilingAverage(maxNumber, minNumber);
      Console.WriteLine("Is your number higher or lower than " + guessNumber + "? (Higher/Lower/Correct)");

      string input = Console.ReadLine().ToLower();
      SetInput(input);

      Guess();
    }
    else if (_userInput == "correct")
    {
      Console.WriteLine("Great! I guessed your number. Would you like to play again? (Yes/No)");
      string playAgain = Console.ReadLine().ToLower();
      if (playAgain == "yes")
      {
        Program.Main();
      }
    }
    else
    {
      Console.WriteLine("Please enter a valid option.");
      string input = Console.ReadLine().ToLower();
      SetInput(input);

      Guess();
    }
  }
}

class Program
{
  public static void Main()
  {
    HigherLower newGame = new HigherLower();

    Console.WriteLine("Is your number higher or lower than 50?  (Higher/Lower/Correct)");
    string input = Console.ReadLine().ToLower();

    newGame.SetInput(input);
    newGame.Guess();
  }
}
