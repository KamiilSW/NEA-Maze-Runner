Public Class MenuForm
    Public Sub MenuForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Menu"
        Me.WindowState = FormWindowState.Maximized
        Button1.Dock = DockStyle.Left
        Button1.Width = Me.Width / 4

        Button2.Dock = DockStyle.Left
        Button2.Width = Me.Width / 4
        Button2.Location = New Point(Button2.Location.X + Button1.Width, Button2.Location.Y)

        Button4.Dock = DockStyle.Right
        Button4.Width = Me.Width / 4

        Button3.Width = Me.Width / 4
        Button3.Height = Me.Height
        Button3.Location = New Point(Button4.Location.X - Button3.Width, Button4.Location.Y)
    End Sub

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim EasyMazeInstance = New MazeForm
        EasyMazeInstance.gridSize = 21

        EasyMazeInstance.Show()
        Hide()
    End Sub

    Public Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim MediumMazeInstance = New MazeForm
        MediumMazeInstance.gridSize = 31

        MediumMazeInstance.Show()
        Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim HardMazeInstance = New MazeForm
        HardMazeInstance.gridSize = 45

        HardMazeInstance.Show()
        Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim InsaneMazeInstance = New MazeForm
        InsaneMazeInstance.gridSize = 49
        InsaneMazeInstance.trailColor = Color.Black

        InsaneMazeInstance.Show()
        Hide()
    End Sub
End Class