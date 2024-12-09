Imports System.Runtime.CompilerServices
Public Class Avatar
    Public Avatar As PictureBox
    Public Shared avatarColour As Color

    Public Sub New()
        Avatar = New PictureBox()
    End Sub

    Public Sub AvatarInitilization(Panel1, startCell, cellSize)
        Panel1.Controls.Add(Avatar)
        Avatar.Location = startCell.Location
        Avatar.BackColor = avatarColour
        Avatar.BringToFront()
        Avatar.Size = New Point(cellSize, cellSize)
    End Sub
End Class