Public Class MenuForm
    Public Shared score As Integer
    Public Sub MenuForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Load
        MenuForm_Load(sender, e)
    End Sub
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

        Label1.Text = "Level 0"
        Label1.BackColor = Color.DarkSlateGray
        Label1.ForeColor = Color.White
        Label1.Height = Label1.Height * 2
        Label1.Width = Label1.Width * 6
        Label1.Location = New Point((Me.Width / 2) - (Label1.Width * 2), 10)
        Label1.BringToFront()
    End Sub

    Sub CheckLevelToUpdateCosmetics()
        If MazeForm.level = 0 Then
            Avatar.avatarColour = Color.DarkGoldenrod
            MazeForm.trailColour = Color.Crimson
        ElseIf MazeForm.level = 1 Or MazeForm.level = 6 Then
            Avatar.avatarColour = Color.PeachPuff
            MazeForm.trailColour = Color.PowderBlue
        ElseIf MazeForm.level = 2 Or MazeForm.level = 7 Then
            Avatar.avatarColour = Color.Gold
            MazeForm.trailColour = Color.Red
        ElseIf MazeForm.level = 3 Or MazeForm.level = 8 Then
            Avatar.avatarColour = Color.AntiqueWhite
            MazeForm.trailColour = Color.Beige
        ElseIf MazeForm.level = 4 Or MazeForm.level = 9 Then
            Avatar.avatarColour = Color.BlueViolet
            MazeForm.trailColour = Color.BlanchedAlmond
        ElseIf MazeForm.level = 5 Or MazeForm.level = 10 Then
            Avatar.avatarColour = Color.DarkGoldenrod
            MazeForm.trailColour = Color.Crimson
        Else
            Avatar.avatarColour = Color.DarkGoldenrod
            MazeForm.trailColour = Color.Crimson
        End If
    End Sub

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CheckLevelToUpdateCosmetics()

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
        InsaneMazeInstance.trailColour = Color.Black

        InsaneMazeInstance.Show()
        Hide()
    End Sub
End Class