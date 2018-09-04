using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class HigherLower
{
  // private int guessNumber;
  // private int maxNumber;
  // private int minNumber;
  private int compNumberPick;
  private int userNumGuess;

  public void InitializeGame()
  {
    // guessNumber = 50;
    // maxNumber = 100;
    // minNumber = 0;
    RandomNumber();
  }

  private void RandomNumber()
  {
    Random number = new Random();
    compNumberPick = number.Next(1, 101);
  }

  private bool IsNumber(string input)
  {
    return Regex.IsMatch(input, @"^\d+$");
  }

  public void GameFlow()
  {
    Console.WriteLine("Please enter a number between 1 and 100.");
    string stringUserInput = Console.ReadLine();
    if (IsNumber(stringUserInput))
    {
      int intUserInput = int.Parse(stringUserInput);
      if (intUserInput >= 1 && intUserInput <= 100)
      {
        userNumGuess = intUserInput;
        Guess();
      }
      else
      {
        Console.WriteLine("The number has to be between 1 and 100.");
        GameFlow();
      }  
    }
    else
    {
      Console.WriteLine("Invalid guess.");
      GameFlow();
    }
  }

  private string IsHigherLower()
  {
    if (userNumGuess > compNumberPick)
    {
      return "lower";
    }
    else if (userNumGuess < compNumberPick)
    {
      return "higher";
    }
    else if (userNumGuess == compNumberPick)
    {
      return "correct";
    }
    else
    {
      return "";
    }
  }
  //
  // private int ceilingAverage(int max, int min)
  // {
  //   if ((max + min) % 2 == 0)
  //   {
  //     return (max + min) / 2;
  //   }
  //   else
  //   {
  //     return ((max + 1) + min) / 2;
  //   }
  // }

  private void Guess()
  {
    if (IsHigherLower() == "higher")
    {
      Console.WriteLine("The number is " + IsHigherLower() + " than " + userNumGuess + ".");
      GameFlow();
    }
    else if (IsHigherLower() == "lower")
    {
      Console.WriteLine("The number is " + IsHigherLower() + " than " + userNumGuess + ".");
      GameFlow();
    }
    else if (IsHigherLower() == "correct")
    {
      Console.WriteLine("Great! You guessed my number which was " + compNumberPick + ". Would you like to play again? (Yes/No)");
      string playAgain = Console.ReadLine();
      playAgain = playAgain.ToLower();
      if (playAgain == "yes")
      {
        InitializeGame();
        GameFlow();
      }
    }
    else if (IsHigherLower() == "")
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
