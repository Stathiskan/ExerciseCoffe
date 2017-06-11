﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseCoffee
{
    class Program
    {
        public class Coffee
        {
            //First declare the new enum type CoffeeType
            public enum CoffeeType
            {
                Small = 100,
                Normal = 150,
                Double = 300
            }

            //Then declare a property of type CoffeeType.
            //Restrict set access to private.
            public CoffeeType Type { get; private set; }
            
            //Constructor
            public Coffee(CoffeeType type)
            {
                Type = type;
            }

            //Just return a formated string
            public override string ToString()
            {
                //return Type + " coffe is " + (int)Type + "ml.";
                //return string.Format("{0} coffee is {1} ml.", Type, (int)Type);
                return $"{Type} coffee is {(int)Type} ml.";
            }
        }

        public class Order {
            //List containing items of type Coffee
            private List<Coffee> items; // = new List<Coffee>();

            public Order()
            {
                items = new List<Coffee>();
            }

            //Function to add items into list
            public void Add(Coffee coffee)
            {
                items.Add(coffee);
            }

            //Function to calculate the total cost of the order
            public double CalculateCost()
            {
                double cost = 0;

                foreach (Coffee c in items)
                {
                    switch(c.Type)
                    {
                        case Coffee.CoffeeType.Small:
                            cost += 0.5;
                            break;
                        case Coffee.CoffeeType.Normal:
                            cost += 1.5;
                            break;
                        case Coffee.CoffeeType.Double:
                            cost += 2.5;
                            break;
                        default:
                            break;
                    }         
                }
                return cost;
            }
        }

        static void Main(string[] args)
        {
	        // Create new Coffee
            Coffee c1 = new Coffee(Coffee.CoffeeType.Small);
            // Print info
            Console.WriteLine(c1);
            // Create new Order
            Order order = new Order();
            // Add some coffees
            order.Add(c1);
            order.Add(new Coffee(Coffee.CoffeeType.Double));
            order.Add(new Coffee(Coffee.CoffeeType.Normal));
            // Calculate cost
            Console.WriteLine(order.CalculateCost());

            Console.ReadKey();
        }
    }
}
