Imports System.Runtime.CompilerServices
Public Class Avatar
    Public Avatar As PictureBox

    Public Sub New()
        Avatar = New PictureBox()
    End Sub

    Public Sub AvatarInitilization(Panel1, startCell, cellSize)
        Panel1.Controls.Add(Avatar)
        Avatar.Location = startCell.Location
        Avatar.BackColor = Color.Purple
        Avatar.BringToFront()
        Avatar.Size = New Point(cellSize, cellSize)
    End Sub
End Class