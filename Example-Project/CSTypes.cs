using System;
using System.Linq;
using System.Collections.Generic;

namespace CSTypes
{
    class Dictionary <T> 
    {
        public readonly List<string> Key = new List<string>(); //List for holding Keys
        public readonly List<T> Val = new List<T>(); //List for holding the Values (Can be of any type, only one per object)

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
            return this.Key.Count();
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

        /*  Implementation of the .Equals Function
            <S> must be the same type as the Compared dictionary, for example:
        
            Dictionary<int> mydict = new Dictionary<int>();
            Dictionary<string> mydict2 = new Dictionary<string>();
            if(mydict.Equals<string>(mydict2)){...}
        */
        public bool Equals <S> (Dictionary<S> dict){
            if(dict == null || GetType() != dict.GetType() || dict.Count() != this.Count() || typeof(S).ToString() != typeof(T).ToString()){
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
}