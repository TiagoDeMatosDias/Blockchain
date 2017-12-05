using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            Block block = new Block();
            block.init(0, DateTime.Now, "The Times 03/Jan/2009 Chancellor on brink of second bailout for banks", "0000000000000000000000000000000000000000000000000000000000000000");

            Console.WriteLine("Index: " + block.Index);
            Console.WriteLine("TimeStamp: " + block.Timestamp);
            Console.WriteLine("Data: " + block.Data);
            Console.WriteLine("Previous Hash: " + block.Previous_hash);
            Console.WriteLine("Hash: " + block.Hash);
            Console.ReadLine();
            


        }
    }


    class Block
    {
        int index;
        DateTime timestamp;
        string data;
        string previous_hash;
        string hash;

        public static string GetHash(string input)
        {
            HashAlgorithm algorithm = SHA256.Create(); 
            return BitConverter.ToString(algorithm.ComputeHash(Encoding.UTF8.GetBytes(input))).Replace("-", String.Empty);
        }
        
        public void init(int index, DateTime timestamp, string data, string previous_hash)
        {
            this.index = index;
            this.timestamp = timestamp;
            this.data = data;
            this.previous_hash = previous_hash;
            this.hash = GetHash(this.index.ToString()+this.timestamp+this.data+this.previous_hash);
        }

         public int Index
        {
            get { return index; }
        }

        public DateTime Timestamp
        {
            get { return timestamp; }
        }

        public string Data
        {
            get { return data; }
        }

        public string Previous_hash
        {
            get { return previous_hash; }
        }

        public string Hash
        {
            get { return hash; }
        }



    }

}
