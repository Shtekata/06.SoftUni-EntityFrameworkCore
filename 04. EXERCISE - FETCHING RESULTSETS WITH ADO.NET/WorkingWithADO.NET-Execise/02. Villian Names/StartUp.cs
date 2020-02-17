using System;
using System.Data.SqlClient;

namespace _02._Villian_Names
{
    class StartUp
    {
        private const string connectionString = @"server=.\sqlexpress01;database=MinionsDB;integrated security=true";
        private static SqlConnection connection = new SqlConnection(connectionString);
        static void Main(string[] args)
        {
            connection.Open();
            using (connection)
            {
                var commandText = @"select v.Name,COUNT(mv.MinionId)Count from Villains v
                                    right join MinionsVillains mv on mv.VillainId=v.Id
                                    group by v.Name
                                    having COUNT(mv.MinionId) > 3
                                    order by Count desc";
                var command = new SqlCommand(commandText, connection);
                var reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]} - {reader[1]}");
                    }
                }
            }
        }
    }
}
