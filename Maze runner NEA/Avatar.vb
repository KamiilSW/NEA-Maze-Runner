Imports System.Runtime.CompilerServices
Public Class Avatar
    Public Avatar As PictureBox

    Public Sub New()
        Avatar = New PictureBox()
    End Sub

    Public Sub AvatarProperties(Panel1, startingCell, cellSize)
        MazeForm.Panel1.Controls.Add(Avatar)
        Avatar.Location = MazeForm.startingCell.Location
        Avatar.BackColor = Color.Purple
        Avatar.BringToFront()
        Avatar.Size = New Point(MazeForm.cellSize, MazeForm.cellSize)
    End Sub
End Class