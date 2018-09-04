using System;
using System.Collections.Generic;

class HigherLower
{
  private int guessNumber;
  private int maxNumber;
  private int minNumber;

  public void InitializeGame()
  {
    guessNumber = 50;
    maxNumber = 100;
    minNumber = 0;
  }

  public void GameFlow()
  {
    Console.WriteLine("Is your number higher or lower than " + guessNumber + "? (Higher/Lower/Correct)");
    string input = Console.ReadLine().ToLower();
    Guess(input);
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

  private void Guess(string userInput)
  {
    if (userInput == "higher")
    {
      minNumber = guessNumber;
      guessNumber = ceilingAverage(maxNumber, minNumber);
      GameFlow();
    }
    else if (userInput == "lower")
    {
      maxNumber = guessNumber;
      guessNumber = ceilingAverage(maxNumber, minNumber);
      GameFlow();
    }
    else if (userInput == "correct")
    {
      Console.WriteLine("Great! I guessed your number. Would you like to play again? (Yes/No)");
      string playAgain = Console.ReadLine();
      playAgain = playAgain.ToLower();
      if (playAgain == "yes")
      {
        InitializeGame();
        GameFlow();
      }
    }
    else
    {
      Console.WriteLine("Please enter a valid option.");
      GameFlow();
    }
  }
}

class Program
{
  static void Main()
  {
    HigherLower newGame = new HigherLower();
    newGame.InitializeGame();
    newGame.GameFlow();
  }
}
