namespace AdoNetTest
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    class Program
    {
        static void Main()
        {
            var list = new List<int>();

            list ??= new List<int>();

            static int LocalFunction(int x, int y) => x + y;
            LocalFunction(5, 5);

            using var connection = new SqlConnection(@"Server=.\SQLEXPRESS01;Database=SoftUni;Integrated Security=True;");

            connection.Open();

            //using (connection)
            //{
                var firstName = "Kevin";
                var department = "7";
                var command = new SqlCommand("select * from Employees where FirstName = @name and DepartmentId   = @department", connection);
                command.Parameters.AddWithValue("@name", firstName);
                command.Parameters.AddWithValue("@department", department);
                //var result = command.ExecuteScalar();
                //Console.WriteLine(result);

                var reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        //var firstName = reader["FirstName"];
                        //var lastName = reader["LastName"];
                        //var salary = reader["Salary"];
                        //Console.WriteLine($"{firstName} {lastName} {salary:f2}");

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write($"{reader[i]} ");
                        }
                        Console.WriteLine();
                    }
                //}

                //command.ExecuteNonQuery();
            }
        }
    }
}
