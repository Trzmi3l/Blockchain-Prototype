using BlockchainPrototype.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
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
            FileStream fs = new FileStream(PATH + DB_NAME + "/"  + "Blocks/" + _.Height + ".dat", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, _);
            } 
            catch(SerializationException ex)
            {
                Console.WriteLine("Failed to serialize block");

            } 
            finally
            {
                fs.Close();
            }
        }

 
    }
}


