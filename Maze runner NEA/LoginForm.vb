Imports System.Configuration
Imports System.Data.SqlClient

Public Class LoginForm
    Public Shared userName As String
    Public Shared score As String = 0
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Text = "Login"
        Label1.Location = New Point(Me.Width / 4, Me.Height / 2)
        TextBox1.Location = New Point(Me.Width / 4, (Me.Height / 2) + (Label1.Height + 5))
        Button1.Location = New Point(Me.Width / 4, (Me.Height / 2) + (Label1.Height * 2) + 5)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result As MsgBoxResult

        If TextBox1.Text IsNot Nothing And TextBox1.TextLength < 21 Then
            userName = TextBox1.Text
            result = MsgBox("Do you want your username to be " + userName + "?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Confirmation")
        Else
            Exit Sub
        End If

        If result = MsgBoxResult.Yes Then
            If IsUserNameExists(userName) = False Then
                SaveUserData(userName, score)
            End If

            UpdateUserScore(userName)

            Me.Hide()
            MenuForm.MenuForm_Load(sender, e)
        Else
            Exit Sub
        End If
    End Sub

    Private Sub SaveUserData(userName As String, score As Integer)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("DatabaseConnection").ConnectionString
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "INSERT INTO Users (UserName, Score) VALUES (@UserName, @Score)"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@UserName", userName)
                command.Parameters.AddWithValue("@Score", score)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function IsUserNameExists(userName As String) As Boolean
        ' Retrieve the connection string from App.config
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("DatabaseConnection").ConnectionString

        ' SQL query to check if the username exists
        Dim query As String = "SELECT COUNT(*) FROM Users WHERE UserName = @UserName"

        ' Initialize the result to False
        Dim exists As Boolean = False

        ' Using block to ensure the connection is properly closed
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                ' Add the parameter to prevent SQL Injection
                command.Parameters.AddWithValue("@UserName", userName)

                Try
                    ' Open the connection to the database
                    connection.Open()

                    ' Execute the query and get the count
                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())

                    ' If count > 0, the username exists
                    If count > 0 Then
                        exists = True
                    End If

                Catch ex As Exception
                    ' Log the exception or display a message
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using

        ' Return the result
        Return exists
    End Function

    Private Sub UpdateUserScore(userName As String)
        ' Retrieve the connection string from App.config
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("DatabaseConnection").ConnectionString

        ' SQL query to retrieve the score for the given username
        Dim query As String = "SELECT Score FROM Users WHERE UserName = @UserName"

        ' Using block to ensure connection is properly closed
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                ' Add parameter to prevent SQL Injection
                command.Parameters.AddWithValue("@UserName", userName)

                Try
                    ' Open the database connection
                    connection.Open()

                    ' Execute the query and retrieve the score
                    Dim result As Object = command.ExecuteScalar()

                    ' Check if a score was returned
                    If result IsNot Nothing Then
                        ' Update the Shared score variable with the retrieved score
                        score = result.ToString()
                        MessageBox.Show("Score updated successfully: " & score)
                    Else
                        ' If no record is found, display a message
                        score = 0
                    End If

                Catch ex As Exception
                    ' Handle any errors that may occur
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub
End Class