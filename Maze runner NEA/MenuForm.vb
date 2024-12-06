Public Class MenuForm
    Private Sub MenuForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Name = "Menu"
    End Sub

    Public form1Instance As MazeForm = Nothing

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If form1Instance Is Nothing Then
            form1Instance = New MazeForm()
        End If

        form1Instance.Show()
        Me.Hide()
    End Sub
End Class