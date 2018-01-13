using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grapevine.Server;

namespace KoiAnime_REST_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateLoadConfig();
            using (var server = new RestServer(LoadSettings()))
            {   
                server.LogToConsole().Start();
                Console.ReadLine();
                server.Stop();
            }
        }

        static IServerSettings LoadSettings()
        {

            IServerSettings iSettings = new ServerSettings
            {
                Port = "5550",
                Host = "127.0.0.1"
            };
            return iSettings;

        }

        private static void CreateLoadConfig()
        {
            string username;
            string password;
            string databasename;
            string dbServerip;

            if (File.Exists(Directory.GetCurrentDirectory() + "\\KoiAnime_Server.cfg"))
            {
                var config = SharpConfig.Configuration.LoadFromFile("KoiAnime_Server.cfg");
                var databaseSection = config["DATABASE"];
                string dbServerIP = databaseSection["DBServerIP"].StringValue;
                string dbUserName = databaseSection["Username"].StringValue;
                string dbUserPassword = databaseSection["Password"].StringValue;
                string dbName = databaseSection["DatabaseName"].StringValue;
                Properties.Settings.Default.koianimeConnectionString = "server=" + dbServerIP + ";" + "user id=" + dbUserName + ";" + "persistsecurityinfo=False;" + "database=" + dbName + ";" + "password=" + dbUserPassword;
            }
            else
            {
                var config = new SharpConfig.Configuration();
                Console.WriteLine("KoiAnime Database Server Configurator v0.1\n--------------------------------\n");
                Console.Write("Write your IP address of server: ");
                dbServerip = Console.ReadLine();
                Console.Write("Write your UserName of the Database: ");
                username = Console.ReadLine();
                Console.Write("Write the password of the Username Database: ");
                password = Console.ReadLine();
                Console.Write("Write the name of the Database: ");
                databasename = Console.ReadLine();
                config["DATABASE"]["DBServerIP"].StringValue = dbServerip;
                config["DATABASE"]["Username"].StringValue = username;
                config["DATABASE"]["Password"].StringValue = password;
                config["DATABASE"]["DatabaseName"].StringValue = databasename;
                config.SaveToFile(Directory.GetCurrentDirectory() + "\\KoiAnime_Server.cfg");
                Properties.Settings.Default.koianimeConnectionString = "server=" + dbServerip + ";" + "user id=" + username + ";" + "persistsecurityinfo=False;" + "database=" + databasename + ";" + "password=" + password;
                Console.Clear();
            }

        }
    }
}
