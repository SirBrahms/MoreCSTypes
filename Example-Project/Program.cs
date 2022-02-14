using System;
using CSTypes;

namespace Example_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Dictionary-Testing 
            Dictionary<string> dict = new Dictionary<string>(); //Creating a dictionary of type string
            Dictionary<int> intdict = new Dictionary<int>(); //Creating a dictionary of type int
            dict.Add("A", "B"); //Adding a Key-Value pair (A = Key, B = Value)
            dict.Add("C", "D");
            dict.Add("E", "F");
            dict.Add("G", "H");
            dict.PrintAll(); //Print all of the Contents in the Array to the Console
            Console.WriteLine(dict.ToString()); //Testing the ToString Function

            intdict.Add("A", 2); //Adding a Key-Value pair (A = Key, 2 = Value)
            dict.Get("A"); //Get the Value of Key A (Value = B)
            dict.GetKey("B"); //Get the Key of Value B (Key = A)
            dict.Count(); //Get How many Key-Value pairs there are in this dictionary (1)
            //Testing the .Equals method
            if(intdict.Equals(dict)){
                Console.WriteLine("Failed");
            }
            
            //Testing Remove Functionality
            dict.RemoveAt(3); //Remove Key-Value pair at index 3
            dict.RemoveItem("E"); //Remove Key-Value pair with Key E (E, F)
            dict.RemoveItemByVal("D"); //Key-Value pair with Value D (C, D)
            dict.PrintAll();
            */

            /* FIFOQueue Testing
            FIFOQueue<string> queue1 = new FIFOQueue<string>(); //Creating a FIFOQueue of type string
            FIFOQueue<int> queue2 = new FIFOQueue<int>(); //Creating a FIFOQueue of type int
            FIFOQueue<Object> queue3 = new FIFOQueue<Object>(); //Creating a FIFOQueue of type Object

            queue1.Add("Hello");
            queue1.Add("Hello2");
            queue2.Add(1);
            queue2.Add(2);

            Console.WriteLine("Contents queue1: " + queue1.ToString()); //The .ToString method (will output Hello,Hello2)
            Console.WriteLine("Contents queue2:" + queue2.ToString()); //The .ToString method (will output 1,2)

            Console.WriteLine(queue1.Pop()); //Will return the first Value of the Queue and remove it (returns Hello)
            Console.WriteLine(queue2.Get()); //Will return the first Value of the Queue and keep it (returns 1)

            Console.WriteLine("Contents queue1 after .Pop(): " + queue1.ToString()); 
            Console.WriteLine("Contents queue2 after .Get(): " + queue2.ToString());

            //Testing .Equals functionality
            if(queue1.Equals(queue2)){
                Console.WriteLine("Failure");
            }

            Console.WriteLine("Count queue2: " + queue2.Count().ToString()); //Will print the Count of Elements in the Queue to the Console (2)
            Console.WriteLine("Count queue3: " + queue3.Count().ToString()); //Will print the Count of Elements in the Queue to the Console (empty Queues return 0)
            */

            /* Stack Testing */
            Stack<int> stck = new Stack<int>(); //Creating a Stack of type int
            Stack<string> stck2 = new Stack<string>(); //Creating a Stack of type string
            Stack<int> stckLim = new Stack<int>(2); //Creating a Stack with a limit of 2

            stck.Push(1); //Adding the Value 1 to the Stack
            stck.Push(2); //Adding the Value 2 to the Stack
            stck.Push(3); //Adding the Value 3 to the Stack

            Console.WriteLine(stck.Pop().ToString()); //Getting the first Element on the Stack (3), and then printing it to the Console
            Console.WriteLine(stck.ToString()); //Printing the entire Stack, seperated by commas, to the Console (1,2)

            Console.WriteLine(stckLim.isEmpty().ToString()); //Checking if the Stack is empty and printing it to the Console (true)
            stckLim.Push(1);
            stckLim.Push(2);
            Console.WriteLine(stckLim.isFull().ToString()); //Checking if the Stack is full and then printing it to the Console (true)


        }
    }
}
