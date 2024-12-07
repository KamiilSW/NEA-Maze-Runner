Public Class MenuForm
    Private Sub MenuForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Menu"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim EasyMazeInstance As MazeForm = New MazeForm()

        EasyMazeInstance.Show()
        Me.Hide()
    End Sub
End Class