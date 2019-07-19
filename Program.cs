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
      int breadCount = 0;
      int pastryCount = 0;
      int breadTotal = 0;
      int pastryTotal = 0;
      int finalTotal = 0;
      int breadDiscount = 0;
      double discountPercent = 0.33;
      string itemChoice = "";
      string itemNumber = "";
      List<Breads> BreadOrder = new List<Breads>();
      List<Pastries> PastryOrder = new List<Pastries>();

      Console.WriteLine("");
      Console.BackgroundColor = ConsoleColor.DarkGreen;
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine("Welcome to Holden's Bakery!");
      Console.ResetColor();
      Console.WriteLine("");
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
      Console.WriteLine("");
      System.Threading.Thread.Sleep(2000);
      Console.BackgroundColor = ConsoleColor.Black;
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.WriteLine("Please enter your order below.");
      Console.ResetColor();

      while (shopping == true)
      {
        int itemNumberParsed = 0;
        string continueShop;
        bool stringCheck = false;
        bool intCheck = false;

        Console.WriteLine("Type either 'bread' or 'pastry':");
        itemChoice = Console.ReadLine();
        if (itemChoice != "bread" && itemChoice != "pastry")
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("Please enter a valid choice.");
          Console.ResetColor();
          stringCheck = true;
        }
        else
        {
          while (intCheck == false)
          {
            Console.WriteLine("How many would you like to add to your order? (numerical values only):");
            itemNumber = Console.ReadLine();
            if (Regex.IsMatch(itemNumber, @"^\d+$") == false)
            {
              Console.ForegroundColor = ConsoleColor.Red;
              Console.WriteLine("Please enter a valid input.");
              Console.ResetColor();
            }
            else
            {
              itemNumberParsed = int.Parse(itemNumber);
              if (itemChoice == "bread")
              {
                breadCount += itemNumberParsed;
              }
              else if (itemChoice == "pastry")
              {
                pastryCount += itemNumberParsed;
              }
              intCheck = true;
            }
          }
        }

        while (stringCheck == false)
        {
          Console.WriteLine("Would you like to add any other items to your order? ( y / n ):");
          continueShop = Console.ReadLine();
          if (continueShop == "y")
          {
            stringCheck = true;
            shopping = true;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Current order: " + breadCount + " bread and " + pastryCount + " pastry");
            Console.ResetColor();
          }
          else if (continueShop == "n")
          {
            stringCheck = true;
            shopping = false;
          }
          else
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please enter a valid choice.");
            Console.ResetColor();
          }
        }

        if (itemChoice == "bread")
        {
          for (int i = 0; i < itemNumberParsed; i++)
          {
            BreadOrder.Add(addBreads(itemChoice));
          }
        }
        else if (itemChoice == "pastry")
        {
          for (int j = 0; j < itemNumberParsed; j++)
          {
            PastryOrder.Add(addPastries(itemChoice));
          }
        }
      }

      int originalBread = BreadOrder.Count;
      pastryTotal = PastryOrder.Count * 2;

      if ((BreadOrder.Count) / 2 >= 1)
      {
        double disc = 0;
        int discComp = 0;
        double breadC = BreadOrder.Count;
        disc = breadC * discountPercent;
        discComp = (int)Math.Floor(disc);
        breadDiscount = (int)Math.Round(disc);

        if (discComp < breadDiscount)
        {
          BreadOrder.Add(addBreads(itemChoice));
        }

        breadTotal = (BreadOrder.Count * 5) - (breadDiscount * 5);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Your bread order qualifies for one of our sales!");
        System.Threading.Thread.Sleep(1000);
        Console.Write("You have received " + (((originalBread * 5) / 5) - (breadTotal / 5)) + " bread from your order for free!");
        if ((BreadOrder.Count - originalBread) > 0)
        {
          Console.WriteLine(" (plus " + (BreadOrder.Count - originalBread) + " extra!!)");
        }
        else
        {
          Console.WriteLine("");
        }
        Console.ResetColor();
      }
      else
      {
        breadTotal = (BreadOrder.Count * 5);
      }

      Console.WriteLine("Total breads you are getting: " + BreadOrder.Count);
      Console.WriteLine("Bread order total cost: $" + breadTotal);

      System.Threading.Thread.Sleep(2000);
      if ((PastryOrder.Count) / 3 >= 1)
      {
        int pastryDiscount;
        pastryDiscount = PastryOrder.Count / 3;
        pastryTotal -= pastryDiscount;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Your pastry order qualifies for one of our sales!");
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine("You have received $" + pastryDiscount + " off your order for buying " + PastryOrder.Count + " pastries!");
        Console.ResetColor();
      }
      else
      {
        pastryTotal = PastryOrder.Count * 2;
      }

      Console.WriteLine("Total pastries you are getting: " + PastryOrder.Count);
      Console.WriteLine("Pastry order total cost: $" + pastryTotal);

      System.Threading.Thread.Sleep(2000);
      finalTotal = breadTotal + pastryTotal;
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("---------------------------------");
      Console.ResetColor();
      Console.WriteLine("Complete order: " + BreadOrder.Count + " bread and " + PastryOrder.Count + " pastry");
      Console.WriteLine("Total cost: $" + finalTotal);

      Console.WriteLine("");
      System.Threading.Thread.Sleep(1000);
      Console.BackgroundColor = ConsoleColor.DarkGreen;
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine("Thank you for shopping at Holden's Bakery! Please come again soon!!");
    }

    static Breads addBreads(string item)
    {
      Breads bread = new Breads(item);
      return bread;
    }

    static Pastries addPastries(string item)
    {
      Pastries pastry = new Pastries(item);
      return pastry;
    }
  }
}

