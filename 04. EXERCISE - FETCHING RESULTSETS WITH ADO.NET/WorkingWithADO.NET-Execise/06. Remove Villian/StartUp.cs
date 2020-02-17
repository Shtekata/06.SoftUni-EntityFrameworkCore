using System;
using System.Data.SqlClient;

namespace _06._Remove_Villian
{
    class StartUp
    {
        private const string connectionString = @"server=.\sqlexpress01;database=MinionsDB;integrated security=true";
        private static SqlConnection connection = new SqlConnection(connectionString);
        private static SqlTransaction transaction;

        static void Main(string[] args)
        {
            var id = int.Parse(Console.ReadLine());
            connection.Open();
            using (connection)
            {
                transaction = connection.BeginTransaction();

                try
                {
                    var cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    cmd.Parameters.AddWithValue("@villianId", id);
                    cmd.CommandText = $"select Name from Villains where Id = @villianId";

                    var villiansName = cmd.ExecuteScalar();

                    if (villiansName == null)
                    {
                        throw new ArgumentException("No such villian was found.");
                    }

                    cmd.CommandText = $"delete from MinionsVillains where VillainId = @villianId";
                    var minionsCount = cmd.ExecuteScalar();

                    cmd.CommandText = $"delete from Villains where Id = @villianId";
                    cmd.ExecuteNonQuery();

                    transaction.Commit();

                    Console.WriteLine($"{villiansName} was deleted.{Environment.NewLine}{minionsCount} minions were released.");
                }
                catch (ArgumentException ae)
                {
                    try
                    {
                        Console.WriteLine(ae.Message);
                        transaction.Rollback();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                catch (Exception e)
                {
                    try
                    {
                        Console.WriteLine(e.Message);
                        transaction.Rollback();
                    }
                    catch (Exception re)
                    {
                        Console.WriteLine(re.Message);
                    }
                }
            }
        }
    }
}
