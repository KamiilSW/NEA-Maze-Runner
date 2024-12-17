Public Class MenuForm
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

        Label1.Text = "Score " + Str(LoginForm.score)
        Label1.BackColor = Color.DarkSlateGray
        Label1.ForeColor = Color.White
        Label1.Height = Label1.Height * 2
        Label1.Width = Label1.Width * 6
        Label1.Location = New Point((Me.Width / 2) - (Label1.Width * 2), 10)
        Label1.BringToFront()
        Me.Show()
    End Sub

    Sub CheckLevelToUpdateCosmetics()
        If (LoginForm.score \ 10) = 0 Then
            Avatar.avatarColour = Color.Gray
            MazeForm.trailColour = Color.Aquamarine
        ElseIf (LoginForm.score \ 10) = 1 Or (LoginForm.score \ 10) = 6 Then
            Avatar.avatarColour = Color.PeachPuff
            MazeForm.trailColour = Color.PowderBlue
        ElseIf (LoginForm.score \ 10) = 2 Or (LoginForm.score \ 10) = 7 Then
            Avatar.avatarColour = Color.Gold
            MazeForm.trailColour = Color.Red
        ElseIf (LoginForm.score \ 10) = 3 Or (LoginForm.score \ 10) = 8 Then
            Avatar.avatarColour = Color.AntiqueWhite
            MazeForm.trailColour = Color.Beige
        ElseIf (LoginForm.score \ 10) = 4 Or (LoginForm.score \ 10) = 9 Then
            Avatar.avatarColour = Color.BlueViolet
            MazeForm.trailColour = Color.BlanchedAlmond
        ElseIf (LoginForm.score \ 10) = 5 Or (LoginForm.score \ 10) = 10 Then
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
        CheckLevelToUpdateCosmetics()

        Dim MediumMazeInstance = New MazeForm
        MediumMazeInstance.gridSize = 31

        MediumMazeInstance.Show()
        Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CheckLevelToUpdateCosmetics()

        Dim HardMazeInstance = New MazeForm
        HardMazeInstance.gridSize = 45

        HardMazeInstance.Show()
        Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        CheckLevelToUpdateCosmetics()

        Dim InsaneMazeInstance = New MazeForm
        InsaneMazeInstance.gridSize = 49
        MazeForm.trailColour = Color.DarkSlateGray

        InsaneMazeInstance.Show()
        Hide()
    End Sub
End Class