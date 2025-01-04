﻿Public Class MenuForm
    Dim buttonColour As New Color
    Dim alternativeButtonColour As New Color
    Dim level As Integer
    Public Sub MenuForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Load
        MenuForm_Load(sender, e)
    End Sub
    Public Sub MenuForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Menu"
        Me.WindowState = FormWindowState.Maximized
        Button1.Width = Me.Width / 4
        Button1.Height = Me.Height - (Me.Height / 4)
        Button1.Location = New Point(Me.Location.X, Button1.Location.Y - 50)

        Button2.Width = Me.Width / 4
        Button2.Height = Me.Height - (Me.Height / 4)
        Button2.Location = New Point(Me.Location.X + Button2.Width, Button2.Location.Y - 50)

        Button3.Width = Me.Width / 4
        Button3.Height = Me.Height - (Me.Height / 4)
        Button3.Location = New Point(Me.Location.X + (Button3.Width * 2), Button4.Location.Y - 50)

        Button4.Width = Me.Width / 4
        Button4.Height = Me.Height - (Me.Height / 4)
        Button4.Location = New Point(Me.Location.X + (Button4.Width * 3), Button4.Location.Y - 50)

        Button5.Text = "Level " + Str(LoginForm.score \ 10)
        Button5.Location = New Point(Me.Location.X, (Button1.Location.Y + Button1.Height))
        Button5.Height = Me.Height - Button1.Height
        Button5.Width = Me.Width \ 2
        Button5.BringToFront()

        Button6.Text = "Close Program"
        Button6.Location = New Point(Button5.Location.X + Button5.Width, Button5.Location.Y)
        Button6.Height = Me.Height - Button1.Height
        Button6.Width = Me.Width / 2
        Button6.BringToFront()

        ChangeMenuColours()

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

    Sub ChangeMenuColours()
        If (LoginForm.score \ 10) = 0 Then
            Button1.BackColor = Color.Gray
            Button2.BackColor = Color.Gray
            Button3.BackColor = Color.Gray
            Button4.BackColor = Color.Gray
            Button5.BackColor = Color.Aquamarine
            Button6.BackColor = Color.Aquamarine
            Button5.ForeColor = Color.Black
            Button6.ForeColor = Color.Black
        ElseIf (LoginForm.score \ 10) = 1 Or (LoginForm.score \ 10) = 6 Then
            Button1.BackColor = Color.PeachPuff
            Button2.BackColor = Color.PeachPuff
            Button3.BackColor = Color.PeachPuff
            Button4.BackColor = Color.PeachPuff
            Button5.BackColor = Color.PowderBlue
            Button6.BackColor = Color.PowderBlue
            Button5.ForeColor = Color.Black
            Button6.ForeColor = Color.Black
        ElseIf (LoginForm.score \ 10) = 2 Or (LoginForm.score \ 10) = 7 Then
            Button1.BackColor = Color.Gold
            Button2.BackColor = Color.Gold
            Button3.BackColor = Color.Gold
            Button4.BackColor = Color.Gold
            Button5.BackColor = Color.Red
            Button6.BackColor = Color.Red
            Button5.ForeColor = Color.White
            Button6.ForeColor = Color.White
        ElseIf (LoginForm.score \ 10) = 3 Or (LoginForm.score \ 10) = 8 Then
            Button1.BackColor = Color.AntiqueWhite
            Button2.BackColor = Color.AntiqueWhite
            Button3.BackColor = Color.AntiqueWhite
            Button4.BackColor = Color.AntiqueWhite
            Button5.BackColor = Color.Beige
            Button6.BackColor = Color.Beige
            Button5.ForeColor = Color.Black
            Button6.ForeColor = Color.Black
        ElseIf (LoginForm.score \ 10) = 4 Or (LoginForm.score \ 10) = 9 Then
            Button1.BackColor = Color.BlueViolet
            Button2.BackColor = Color.BlueViolet
            Button3.BackColor = Color.BlueViolet
            Button4.BackColor = Color.BlueViolet
            Button5.BackColor = Color.BlanchedAlmond
            Button6.BackColor = Color.BlanchedAlmond
            Button5.ForeColor = Color.Black
            Button6.ForeColor = Color.Black
        Else
            Button1.BackColor = Color.DarkGoldenrod
            Button2.BackColor = Color.DarkGoldenrod
            Button3.BackColor = Color.DarkGoldenrod
            Button4.BackColor = Color.DarkGoldenrod
            Button5.BackColor = Color.Crimson
            Button6.BackColor = Color.Crimson
            Button5.ForeColor = Color.White
            Button6.ForeColor = Color.White
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
        Me.Close()
    End Sub
End Class