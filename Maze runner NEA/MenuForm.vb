Public Class MenuForm
    Public Sub MenuForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Menu"
    End Sub

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim EasyMazeInstance = New MazeForm
        EasyMazeInstance.gridSize = 25

        EasyMazeInstance.Show()
        Hide()
    End Sub

    Public Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim MediumMazeInstance = New MazeForm
        MediumMazeInstance.gridSize = 45

        MediumMazeInstance.Show()
        Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim HardMazeInstance = New MazeForm
        HardMazeInstance.gridSize = 65

        HardMazeInstance.Show()
        Hide()
    End Sub
End Class