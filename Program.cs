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
      int breadTotal = 0;
      int pastryTotal = 0;
      int finalTotal = 0; 
      string userOrder = "Current order: ";
      string itemChoice = "";
      string itemNumber = "";
      List<Breads> BreadOrder = new List<Breads>();
      List<Pastries> PastryOrder = new List<Pastries>();
     
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
        int itemNumberParsed = 0;
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
            Console.WriteLine("How many would you like to add to your order? (numerical values only):");
            itemNumber = Console.ReadLine();
            if(Regex.IsMatch(itemNumber, @"^\d+$") == false)
            {
              Console.ForegroundColor = ConsoleColor.Red;
              Console.WriteLine("Please enter a valid input.");
              Console.ResetColor();
            } else
            {
              itemNumberParsed = int.Parse(itemNumber);
              userOrder += itemNumber + " " + itemChoice;
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
            userOrder += ", ";
          } else if (continueShop == "n")
          {
            stringCheck = true;
            shopping = false;
         } else 
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please enter a valid choice.");
            Console.ResetColor();
          }
        }
        Console.WriteLine(userOrder);

        if(itemChoice == "bread")
        {
          for(int i = 0; i < itemNumberParsed; i++)
          {
            BreadOrder.Add(addBreads(itemChoice));
            Console.WriteLine(BreadOrder[i].Bread);
          }
        } else if(itemChoice == "pastry")
        {
          for(int j = 0; j < itemNumberParsed; j++)
          {
            PastryOrder.Add(addPastries(itemChoice));
            Console.WriteLine(PastryOrder[j].Pastry);
          }
        }


      } 
      int breadDiscount = 0;
      int originalBread = BreadOrder.Count;
      pastryTotal = PastryOrder.Count * 2;

      if( (BreadOrder.Count) / 2 >= 1  )
      {
        if(BreadOrder.Count % 2 == 0)
        {
          BreadOrder.Add(addBreads(itemChoice));
        }
        breadDiscount = (BreadOrder.Count / 2) - 1;
        breadTotal = (BreadOrder.Count * 5) - (breadDiscount * 5);
        Console.WriteLine("Your order qualifies for one of our sales!"); 
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine("You have received " + (breadDiscount - BreadOrder.Count - originalBread) + " breads from your order for free, plus " + (BreadOrder.Count - originalBread) + " extra!");
      }
        
        Console.WriteLine("Total breads you are getting: " + BreadOrder.Count + " (" + breadDiscount + " are free)."); 
        Console.WriteLine("Bread order total cost: " + breadTotal);
      
        System.Threading.Thread.Sleep(2000);
        if( (PastryOrder.Count) / 3 >= 1  )
        {
          int pastryDiscount;
          pastryDiscount = PastryOrder.Count / 3;
          pastryTotal -= pastryDiscount;
          Console.WriteLine("Your order qualifies for one of our sales!"); 
        System.Threading.Thread.Sleep(1000);
        }

        
        Console.WriteLine("Pastry order total cost: " + pastryTotal);
        Console.WriteLine("Order total cost: " + finalTotal);

        finalTotal = breadTotal + pastryTotal;


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

