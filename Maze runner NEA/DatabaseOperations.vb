Imports System.Data.SqlClient

Public Class DatabaseOperations
    Sub InsertValue(value As Integer)
        Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\minek\source\repos\Maze runner NEA\Maze runner NEA\Database1.mdf;Integrated Security=True"

        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim query As String = "INSERT INTO MyTable (score) VALUES (@value)"

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@value", value)
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Sub UpdateValue(id As Integer, newValue As Integer)
        Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\minek\source\repos\Maze runner NEA\Maze runner NEA\Database1.mdf;Integrated Security=True"

        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim query As String = "UPDATE MyTable SET score = @newValue WHERE ID = @id"

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@newValue", newValue)
                command.Parameters.AddWithValue("@id", id)
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Function GetValue(id As Integer) As Integer
        Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\minek\source\repos\Maze runner NEA\Maze runner NEA\Database1.mdf;Integrated Security=True"

        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim query As String = "SELECT score FROM MyTable WHERE ID = @id"

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@id", id)
                Dim result = command.ExecuteScalar()
                Return If(result IsNot Nothing, Convert.ToInt32(result), 0)
            End Using
        End Using
    End Function
End Class
