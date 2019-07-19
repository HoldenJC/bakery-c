using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Bakery.Goods; 

namespace Bakery
{
  public class Program
  {

    public static void Main()
    {
      bool shopping = true;
     
      Console.BackgroundColor = ConsoleColor.DarkGreen;
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine("Welcome to Holden's Bakery!");
      Console.ResetColor();
      System.Threading.Thread.Sleep(2000);
      Console.WriteLine("Our bakery currently offers bread and pastries.");
      System.Threading.Thread.Sleep(2000);
      Console.WriteLine("Bread costs $5 per loaf and pastries are $2 per.");
      System.Threading.Thread.Sleep(2000);
      Console.WriteLine("Currently we have 2 sales running:");
      System.Threading.Thread.Sleep(2000);
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("Buy 2 bread loafs, get 1 free.");
      Console.WriteLine("Save $1 per 3 pastries purchased.");
      System.Threading.Thread.Sleep(2000);
      Console.BackgroundColor = ConsoleColor.Black;
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.WriteLine("Please enter your order below.");
      Console.ResetColor();

      while(shopping == true)
      {
        string itemChoice;
        string itemNumber;
        int itemNumberParsed;
        string continueShop;
        bool stringCheck = false;
        bool intCheck = false;

        Console.WriteLine("Type either 'bread' or 'pastry':");
        itemChoice = Console.ReadLine();
        if(itemChoice != "bread" && itemChoice != "pastry")
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("Please enter a valid choice.");
          Console.ResetColor();
          stringCheck = true;
        } else
        {
          while(intCheck == false)
          {
            Console.WriteLine("How many would you like to add to your order?:");
            itemNumber = Console.ReadLine();
            if(Regex.IsMatch(itemNumber, @"^\d+$") == false)
            {
              Console.ForegroundColor = ConsoleColor.Red;
              Console.WriteLine("Please enter a valid choice.");
              Console.ResetColor();
            } else
            {
              itemNumberParsed = int.Parse(itemNumber);
              intCheck = true;
            }
          }
        }
        
        while(stringCheck == false)
        {
          Console.WriteLine("Would you like to add any other items to your order? ( y / n ):");
          continueShop = Console.ReadLine();
          if(continueShop == "y")
          {
            stringCheck = true;
            shopping = true;
          } else if (continueShop == "n")
          {
            stringCheck = true;
            shopping = false;
         } else 
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please enter a valid input ( 'y' or 'n' )");
            Console.ResetColor();
          }
        }
        



      } 
        

    }

  }


}

