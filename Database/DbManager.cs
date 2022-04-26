using BlockchainPrototype.Exceptions;
using BlockchainPrototype.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace BlockchainPrototype.Database
{
    public class DbManager
    {
        private readonly static String PATH = AppDomain.CurrentDomain.BaseDirectory;
        private readonly static String DB_NAME = "DATABASE";
        private readonly static List<String> DB_SUBFOLDERS = new List<string>() { "Blocks", "Wallets", "Transactions"};
        
        public DbManager()
        {
            Task.Run(() => InitDb());
        }

        private static async Task InitDb()
        {
            foreach(var _ in DB_SUBFOLDERS)
            {
                Console.WriteLine(PATH + DB_NAME + "/"  + _);
                if (!Directory.Exists(PATH + DB_NAME + "/" +_))
                {
                    Directory.CreateDirectory(PATH + DB_NAME + "/" +_);
                }
            }
        }


        public void InsertBlock(Block _)
        {
            FileStream fs = new FileStream(PATH + DB_NAME + "/"  + "Blocks/" + _.Height + ".json", FileMode.Create);

            try
            {
                string dataToBinary = System.Text.Json.JsonSerializer.Serialize(_);
                fs.Write(Encoding.UTF8.GetBytes(dataToBinary));
            } 
            catch(SerializationException ex)
            {
                Console.WriteLine("Failed to serialize block");
                Console.WriteLine(ex.ToString());
            }finally
            {
                fs.Close();
            }
        }


        /// <summary>
        /// Get latest block
        /// </summary>
        /// <returns>Block</returns>
        public Block GetBlock()
        {
            DirectoryInfo df = new DirectoryInfo(PATH + DB_NAME + "/" + "Blocks");
            FileInfo file = df.GetFiles().OrderByDescending(f => f.LastWriteTime).First();
            string temp = File.ReadAllText(file.FullName);
            return JsonConvert.DeserializeObject<Block>(temp);
        }
        
        /// <summary>
        /// Get block of height
        /// </summary>
        public Block GetBlock(long height)
        {
            try
            {
                string temp = File.ReadAllText(PATH + DB_NAME + "/" + "Blocks" + "/" + height + ".json");
                return JsonConvert.DeserializeObject<Block>(temp);
            } catch(FileNotFoundException ex)
            {
                return null;
            }
            
        }
 
    }   
}


