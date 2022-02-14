using System;
using System.Linq;
using System.Collections.Generic;

namespace CSTypes
{
    class Dictionary <T> 
    {
        public readonly List<string> Key = new List<string>(); //List for holding Keys
        public readonly List<T> Val = new List<T>(); //List for holding the Values (Can be of any type, only one per Queueect)

        //Add a Key-Value pair
        public void Add(string key, T val){
            this.Key.Add(key);
            this.Val.Add(val);
        }

        //Get the Value of the supplied Key
        public T Get(string key){
            try
            {
                int indexOfKey = this.Key.FindIndex(a => a.Contains(key));
                return this.Val.ElementAt(indexOfKey);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new ArgumentException("Index is out of range / given key does not exist", nameof(key), ex);
            }
        }

        //Get the Key of the supplied Value
        public string GetKey(T val){
            try
            {
                int indexOfVal;
                for (int i = 0; i < this.Val.Count(); i++){
                    if (this.Val[i].Equals(val)){
                        indexOfVal = i;
                        return this.Key.ElementAt(indexOfVal);
                    }
                }
                throw new ArgumentException("Given Value does not exist", nameof(val));
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new ArgumentException("Index is out of range", nameof(val), ex);
            }
        }

        //Implementation of a .Count method, that returns how many Key-Value Pairs are within a dictionary
        public int Count(){
            try
            {
                return this.Key.Count();
            }
            catch
            {
                return 0;
            }
        }

        //Implementation of a .RemoveAt method, that removes elements at a certain index
        public void RemoveAt(int index){
            try
            {
                this.Key.RemoveAt(index);
                this.Val.RemoveAt(index);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new ArgumentException("Index is out of range", nameof(index), ex);
            }
        }

        //Implementation of a .RemoveItem method, that removes a Key-Value pair by a given Key
        public void RemoveItem(string key){
            try
            {
                int indexOfKey = this.Key.FindIndex(a => a.Contains(key));
                this.RemoveAt(indexOfKey);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new ArgumentException("Given Key does not exist.", nameof(key), ex);
            }
        }

        //Implementation of a .RemoveItemByVal method, that removes Key-Value pairs by a given Value
        public void RemoveItemByVal(T val){
            try
            {
                int indexOfVal;
                for (int i = 0; i < this.Val.Count(); i++){
                    if (this.Val[i].Equals(val)){
                        indexOfVal = i;
                        this.RemoveAt(indexOfVal);
                    }
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new ArgumentException("Given Value does not exist", nameof(val), ex);
            }
        }

        //Implementation of a method that prints all of the Values
        public void PrintAll(){
            for (int i = 0; i < this.Key.Count(); i++){
                Console.WriteLine(this.Key[i] + " : " + this.Val[i].ToString());
            }
        }

        //Implementation of a method to return a string with all Contents of the Dictionary
        //Possible Argument: EscapeChar - the Escape Character that can be added after every line (like \n) (not neccessary)
        public string getFormatedDict(string EscapeChar = ""){
            string Full = "";

            for (int i = 0; i < this.Key.Count(); i++){
                if(i == this.Key.Count() - 1){
                    Full += this.Key[i] + " : " + this.Val[i].ToString();
                }
                else{
                    Full += this.Key[i] + " : " + this.Val[i].ToString() + EscapeChar;
                }
            }
            return Full;
        }

        //Override of the .ToString function to redirect to the getFormatedDict method with an escape Character of ", " (comma + whitespace)
        public override string ToString(){
            string FullStr = this.getFormatedDict(", ");
            return FullStr;
        }

        //Implementation of the .Equals Function
        public bool Equals(Dictionary<T> dict){
            if(dict == null || GetType() != dict.GetType() || dict.Count() != this.Count()){
                return false;
            }
            

            //Checking if all Elements match
            for (int i = 0; i < this.Key.Count(); i++){
                if(!this.Key[i].Equals(dict.Key[i])){
                    return false;
                }
            }
            for (int i = 0; i < this.Val.Count(); i++){
                if(!this.Val[i].Equals(dict.Val[i])){
                    return false;
                }
            }
            return true;
        }

        //Implementation of a destructor that just null-ifies the dictionary when it goes out of scope
        ~Dictionary(){
            for (int i = 0; i < this.Key.Count(); i++){
                this.Key[i] = null;
                this.Val[i] = default(T);
            }
        }
    }

    class FIFOQueue <T>
    {
        public readonly List<T> Queue = new List<T>(); //The list that holds the entire Queue

        //A function to add a Value to the Queue
        public void Add(T val){
            this.Queue.Add(val);
        }

        //A function to retrieve the first Element of the Queue and then delete it (similar to pop())
        public T Pop(){
            try
            {
                T temp = this.Queue[0];
                this.Queue.RemoveAt(0);
                return temp;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new ArgumentException("Index was out of Range or Queue was empty", ex);
            }
        }

        //A function to retrieve the first Element of the Queue without deleting it
        public T Get(){
            try
            {
                return this.Queue[0];
            }
            catch (ArgumentOutOfRangeException ex)
            {              
                throw new ArgumentException("Queue was empty", ex);
            }
        }

        //Override of the .ToString method, returns the entire Queue seperated by Commas
        public override string ToString(){
            string full = "";
            for (int i = 0; i < this.Queue.Count(); i++)
            {
                if(i == this.Queue.Count() - 1){
                    full += this.Queue[i].ToString();
                }
                else{
                    full += this.Queue[i].ToString() + ",";
                }
            }

            return full;
        }

        //Implementation of a .Count method that returns how many elements there are in the Queue
        public int Count(){
            try
            {
                return this.Queue.Count();
            }
            catch
            {
                return 0;
            }
        }

        //Implementation of a .Equals method
        public bool Equals(FIFOQueue<T> Queue)
        {            
            if (Queue == null || GetType() != Queue.GetType() || this.Count() != Queue.Count()){
                return false;
            }
            
            for (int i = 0; i < this.Queue.Count(); i++){
                if(!this.Queue[i].Equals(Queue.Queue[i])){
                    return false;
                }
            }

            return true;
        }

        //Destructor that empties the List to default(T) when the Class goes out of scope
        ~FIFOQueue(){
            for (int i = 0; i < this.Queue.Count(); i++)
            {
                this.Queue[i] = default(T)
            }
        }        
    }
}