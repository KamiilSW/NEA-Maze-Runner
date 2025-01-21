Public Class MenuForm
    Dim buttonColour As New Color
    Dim alternativeButtonColour As New Color
    Dim level As Integer
    Public Sub MenuForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Load
        MenuForm_Load(sender, e)
    End Sub
    Public Sub MenuForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Menu"
        Me.WindowState = FormWindowState.Maximized
        Me.BackColor = Color.White

        Label1.BringToFront()
        Label1.BackColor = Color.MediumPurple
        Label1.Location = New Point((Me.Width / 2) - (Label1.Width / 2), Me.Location.Y)

        PictureBox2.Location = New Point(Me.Width - (Me.Width / 3.5), Me.Location.Y + Label1.Height + PictureBox1.Height)
        PictureBox2.Width = Me.Width / 3.5
        PictureBox2.Height = Me.Height - Label1.Height - PictureBox1.Height

        PictureBox1.Location = New Point(Me.Location.X, Me.Location.Y + Label1.Height)
        PictureBox1.Width = Me.Width
        PictureBox1.BackColor = Color.White

        PictureBox3.Location = Me.Location
        PictureBox3.Width = Me.Width
        PictureBox3.Height = Label1.Height

        Button1.Width = (Me.Width - (Me.Width / 3.5)) / 4
        Button1.Height = Me.Height - (Me.Height / 4)
        Button1.Location = New Point(Me.Location.X, Button1.Location.Y - 50)
        Button1.BackColor = Color.MediumPurple

        Button2.Width = (Me.Width - (Me.Width / 3.5)) / 4
        Button2.Height = Me.Height - (Me.Height / 4)
        Button2.Location = New Point(Me.Location.X + Button2.Width, Button2.Location.Y - 50)
        Button2.BackColor = Color.MediumPurple

        Button3.Width = (Me.Width - (Me.Width / 3.5)) / 4
        Button3.Height = Me.Height - (Me.Height / 4)
        Button3.Location = New Point(Me.Location.X + (Button3.Width * 2), Button4.Location.Y - 50)
        Button3.BackColor = Color.MediumPurple

        Button4.Width = (Me.Width - (Me.Width / 3.5)) / 4
        Button4.Height = Me.Height - (Me.Height / 4)
        Button4.Location = New Point(Me.Location.X + (Button4.Width * 3), Button4.Location.Y - 50)
        Button4.BackColor = Color.MediumPurple

        Button5.Text = "Level " + Str(LoginForm.score \ 10)
        Button5.Location = New Point(Me.Location.X, (Button1.Location.Y + Button1.Height))
        Button5.Height = Me.Height - Button1.Height
        Button5.Width = (Me.Width - (Me.Width / 3.5)) / 2
        Button5.BackColor = Color.Purple
        Button5.BringToFront()

        Button6.Text = "Back to Login"
        Button6.Location = New Point(Button5.Location.X + Button5.Width, Button5.Location.Y)
        Button6.Height = Me.Height - Button1.Height
        Button6.Width = (Me.Width - (Me.Width / 3.5)) / 2
        Button6.BackColor = Color.Purple
        Button6.BringToFront()

        PictureBox3.BringToFront()
        Label1.BringToFront()
        PictureBox2.BringToFront()

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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        LoginForm.Show()
        Me.Close()
    End Sub
End Class