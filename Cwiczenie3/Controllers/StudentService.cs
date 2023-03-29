using System.Data.SqlClient;
using Cwiczenie3;

namespace Cwiczenia3
{
    public class StudentService : IGetStudent
    {
        private const string _connString = "Data Source=db-mssql;Intitial Catalog=2019sbd;Integrated Security=True";
        private const string _localConnString = "Data Source=localhost;Initial Catalog=2019sbd;User ID={USERNAME};Password={Password}";
        public async Task<IList<Student>> GetStudentsListAsync(string name)
        {
            List<Student> students = new();
            await using SqlConnection sqlConnection = new(_connString);
            await using SqlCommand sqlCommand = new();

            string sql;
            if (string.IsNullOrWhiteSpace(name))
            {
                sql = "Select * From Animal";
            }
            else 
            {
                sql = $"Select * From Animal WHERE Title LIKE @name"; 
                sqlCommand.Parameters.AddWithValue("name", name);
            }


            sqlCommand.CommandText= sql;
            sqlCommand.Connection = sqlConnection;


            await sqlConnection.OpenAsync();

        
            await using SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while(await sqlDataReader.ReadAsync()) {
                Student student = new Student
                {
                    IdStudent = int.Parse(sqlDataReader.GetValue("IdStudent").toString(),
                    Name = sqlDataReader("Name").toString()
                };
                students.Add(student);
             }

            await sqlConnection.CloseAsync();
            return students;
        }
    }
}
