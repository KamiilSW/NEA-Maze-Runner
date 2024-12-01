Imports System.Runtime.CompilerServices
Public Class Avatar
    Public Avatar As PictureBox

    Public Sub New()
        Avatar = New PictureBox()
    End Sub

    Public Sub AvatarProperties(Panel1, startCell, cellSize)
        Form1.Panel1.Controls.Add(Avatar)
        Avatar.Location = Form1.startCell.Location
        Avatar.BackColor = Color.Purple
        Avatar.BringToFront()
        Avatar.Size = New Point(Form1.cellSize, Form1.cellSize)
    End Sub
End Class