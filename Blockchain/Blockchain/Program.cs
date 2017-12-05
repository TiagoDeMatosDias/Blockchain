﻿using System;
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
            List<Block> Blockchain = new List<Block>();
            Block block = new Block();
            block.Genesys();
            Blockchain.Add(block);
                        
            Console.WriteLine("Index: " + Blockchain[0].Index);
            Console.WriteLine("TimeStamp: " + Blockchain[0].Timestamp);
            Console.WriteLine("Data: " + Blockchain[0].Data);
            Console.WriteLine("Previous Hash: " + Blockchain[0].Previous_hash);
            Console.WriteLine("Hash: " + Blockchain[0].Hash);
            Console.ReadLine();

            for (int i = 0; i < 6; i++)
            {
                block.next_block(Blockchain[i]);
                Blockchain.Add(block);
                Console.WriteLine("Index: " + Blockchain[i+1].Index);
                Console.WriteLine("TimeStamp: " + Blockchain[i + 1].Timestamp);
                Console.WriteLine("Data: " + Blockchain[i + 1].Data);
                Console.WriteLine("Previous Hash: " + Blockchain[i + 1].Previous_hash);
                Console.WriteLine("Hash: " + Blockchain[i + 1].Hash);
                Console.ReadLine();
            }



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
            this.hash = GetHash(this.index.ToString() + this.timestamp + this.data + this.previous_hash);
        }

        public Block Genesys()
        {
            init(0, DateTime.Now, "The Times 03/Jan/2009 Chancellor on brink of second bailout for banks", "0000000000000000000000000000000000000000000000000000000000000000");
            return this;
        }

        public Block next_block(Block last_block)
        {
            init(last_block.Index + 1, DateTime.Now, "Block: " + (last_block.Index + 1), last_block.hash);
            return this;
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
