Public Class Form1
    Public gridSize As Integer = 45
    Public cellSize As Integer = 15
    Dim counter As Integer = 0
    Dim wallsList As New List(Of PictureBox)
    Dim unvisitedCells As New List(Of PictureBox)
    Dim Stack As New Stack(Of PictureBox)
    Dim CellsOnEdge As New List(Of PictureBox)
    Dim allCells As New List(Of PictureBox)
    Public startCell As PictureBox = Nothing
    Public avatar As New Avatar()
    Dim exitCell As PictureBox
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Maze"
        Me.BackColor = Color.White
        Me.KeyPreview = True
        Panel1.Location = New Point(10 + cellSize, 10 + cellSize)
        Panel1.Size = New Size(gridSize * cellSize, gridSize * cellSize)
        Me.Controls.Add(Panel1)
        Dim isAWall As Boolean = True

        'Creates the grid.
        For i As Integer = 0 To gridSize - 1
            For j As Integer = 0 To gridSize - 1
                Dim cell As New PictureBox()

                ' Sets the cell's properties
                cell.Size = New Size(cellSize, cellSize)
                cell.Location = New Point(j * cellSize, i * cellSize)
                Panel1.Controls.Add(cell)
                counter += 1

                If counter > 30 Then
                    counter = 1
                    isAWall = True
                End If

                If isAWall = True Then
                    cell.BackColor = Color.DarkSlateGray
                    wallsList.Add(cell)
                    isAWall = False
                Else
                    cell.BackColor = Color.DarkSlateGray
                    isAWall = True
                    unvisitedCells.Add(cell)
                End If

                ' Add cells on the edge to the list
                If i = 0 OrElse i = gridSize - 1 OrElse j = 0 OrElse j = gridSize - 1 Then
                    CellsOnEdge.Add(cell)
                    cell.BackColor = Color.DarkSlateGray
                    wallsList.Add(cell)
                    unvisitedCells.Remove(cell)
                End If

                For n = 0 To allCells.Count - 1
                    If CellsOnEdge.Contains(allCells.Item(n)) Then
                        allCells.Remove(cell)
                    End If
                Next

                allCells.Add(cell)
            Next
        Next

        startCell = createRandomStartCell(Nothing)
        GenerateMaze(startCell)
        AddEdgeWalls()
        FixBackground()
        FindExit()
        avatar.AvatarProperties(Panel1, startCell, cellSize)
        CalibrateWallsList()
    End Sub

    Sub GenerateMaze(startCell)
        Dim previousCell As PictureBox = Nothing
        Dim currentCell As PictureBox = startCell
        Stack.Push(currentCell)

        Do
            previousCell = currentCell
            currentCell = FindOneUnvisitedNeighbourCell(currentCell)

            If currentCell IsNot Nothing Then
                BuildPathToNeighbour(currentCell, previousCell)
            Else
                Stack.Pop()

                If Stack.Count = 0 Then
                    Exit Do
                End If

                currentCell = Stack.Peek()
            End If
        Loop Until Stack.Count = 0
    End Sub

    Dim random As New Random()
    Sub BuildPathToNeighbour(currentCell, previousCell)
        VisitCell(currentCell)
        BreakWallBetween(previousCell, currentCell)
        Stack.Push(currentCell)
    End Sub
    Function createRandomStartCell(currentCell)
        Dim randInt As Integer = random.Next(unvisitedCells.Count)

        currentCell = unvisitedCells.Item(randInt)
        currentCell.BackColor = Color.Black

        Return currentCell
    End Function
    Function FindOneUnvisitedNeighbourCell(currentCell)
        Dim unvisitedNeighbours As New List(Of PictureBox)

        Dim x As Integer = currentCell.Location.X / cellSize
        Dim y As Integer = currentCell.Location.Y / cellSize

        Dim possibleMoves As Point() = {New Point(0, -2), New Point(0, 2), New Point(-2, 0), New Point(2, 0)}

        For Each move As Point In possibleMoves
            Dim moveX As Integer = x + move.X
            Dim moveY As Integer = y + move.Y

            If moveX < gridSize And moveY >= 0 And moveX >= 0 And moveY < gridSize Then
                Dim neighbourCell As PictureBox = allCells(moveY * gridSize + moveX)

                If neighbourCell.BackColor = Color.DarkSlateGray And Not Stack.Contains(neighbourCell) Then
                    unvisitedNeighbours.Add(neighbourCell)
                End If
            End If
        Next

        If unvisitedNeighbours.Count > 0 Then
            Return unvisitedNeighbours(random.Next(unvisitedNeighbours.Count))
        End If

        Return Nothing
    End Function
    Sub VisitCell(currentCell)
        currentCell.BackColor = Color.Black
    End Sub
    Sub BreakWallBetween(previousCell, currentCell)
        Dim x As Integer = (previousCell.Location.X + currentCell.Location.X) / 2
        Dim y As Integer = (previousCell.Location.Y + currentCell.Location.Y) / 2

        Dim wallCell As PictureBox = allCells((y / cellSize) * gridSize + (x / cellSize))

        If wallCell IsNot Nothing Then
            wallCell.BackColor = Color.Black
        End If
    End Sub
    Sub FixBackground()
        For i = 0 To allCells.Count - 1
            If allCells.Item(i).BackColor <> Color.Black Then
                allCells.Item(i).BackColor = Color.DarkSlateGray
            End If
        Next
    End Sub
    Sub FindExit()
        Dim randInt As Integer
        Dim visitedNeighbours As New List(Of PictureBox)

        Do
            randInt = random.Next(CellsOnEdge.Count)

            exitCell = CellsOnEdge.Item(randInt)
        Loop Until exitCell.BackColor = Color.Black

        exitCell.BackColor = Color.Yellow
    End Sub

    Sub AddEdgeWalls()
        Dim panelWidth As Integer = Panel1.Width
        Dim panelHeight As Integer = Panel1.Height
        Dim panelXOffset As Integer = Panel1.Location.X
        Dim panelYOffset As Integer = Panel1.Location.Y
        Dim topEdgeHasWalls As Boolean = True
        Dim bottomEdgeHasWalls As Boolean = True
        Dim leftEdgeHasWalls As Boolean = True
        Dim rightEdgeHasWalls As Boolean = True

        ' Check for walls along the top and bottom edges
        For x As Integer = 0 To gridSize - 1
            Dim topCellIndex As Integer = x
            Dim bottomCellIndex As Integer = (gridSize - 1) * gridSize + x

            If allCells(topCellIndex).BackColor <> Color.DarkSlateGray Then topEdgeHasWalls = False
            If allCells(bottomCellIndex).BackColor <> Color.DarkSlateGray Then bottomEdgeHasWalls = False
        Next

        ' Check for walls along the left and right edges
        For y As Integer = 0 To gridSize - 1
            Dim leftCellIndex As Integer = y * gridSize
            Dim rightCellIndex As Integer = (y * gridSize) + (gridSize - 1)

            If allCells(leftCellIndex).BackColor <> Color.DarkSlateGray Then leftEdgeHasWalls = False
            If allCells(rightCellIndex).BackColor <> Color.DarkSlateGray Then rightEdgeHasWalls = False
        Next

        ' Add missing walls outside the maze
        If Not topEdgeHasWalls Then
            For x As Integer = 0 To gridSize - 1
                Dim wall As New PictureBox()
                wall.Size = New Size(cellSize, cellSize)
                wall.Location = New Point(panelXOffset + (x * cellSize), panelYOffset - cellSize) ' Place above the maze
                wall.BackColor = Color.DarkSlateGray
                Me.Controls.Add(wall)
                wallsList.Add(wall)
            Next
        End If

        If Not bottomEdgeHasWalls Then
            For x As Integer = 0 To gridSize - 1
                Dim wall As New PictureBox()
                wall.Size = New Size(cellSize, cellSize)
                wall.Location = New Point(panelXOffset + (x * cellSize), panelYOffset + panelHeight) ' Place below the maze
                wall.BackColor = Color.DarkSlateGray
                Me.Controls.Add(wall)
                wallsList.Add(wall)
            Next
        End If

        If Not leftEdgeHasWalls Then
            For y As Integer = 0 To gridSize - 1
                Dim wall As New PictureBox()
                wall.Size = New Size(cellSize, cellSize)
                wall.Location = New Point(panelXOffset - cellSize, panelYOffset + (y * cellSize)) ' Place to the left of the maze
                wall.BackColor = Color.DarkSlateGray
                Me.Controls.Add(wall)
                wallsList.Add(wall)
            Next
        End If

        If Not rightEdgeHasWalls Then
            For y As Integer = 0 To gridSize - 1
                Dim wall As New PictureBox()
                wall.Size = New Size(cellSize, cellSize)
                wall.Location = New Point(panelXOffset + panelWidth, panelYOffset + (y * cellSize)) ' Place to the right of the maze
                wall.BackColor = Color.DarkSlateGray
                Me.Controls.Add(wall)
                wallsList.Add(wall)
            Next
        End If
    End Sub

    Sub CalibrateWallsList()
        wallsList.Clear()
        For Each cell In allCells
            If cell.BackColor = Color.DarkSlateGray Then
                wallsList.Add(cell)
            End If
        Next
    End Sub

    Public Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim avatarPictureBox = avatar.Avatar
        Dim targetLocation = Nothing

        If e.KeyCode = Keys.W Then
            targetLocation = New Point(avatarPictureBox.Location.X, avatarPictureBox.Location.Y - cellSize)

            For Each wall As Control In wallsList
                If wall.Location = targetLocation Then
                    Exit Sub
                End If
            Next

            avatarPictureBox.Location = New Point(avatarPictureBox.Location.X, avatarPictureBox.Location.Y - cellSize)
        ElseIf e.KeyCode = Keys.S Then
            targetLocation = New Point(avatarPictureBox.Location.X, avatarPictureBox.Location.Y + cellSize)

            For Each wall As Control In wallsList
                If wall.Location = targetLocation Then
                    Exit Sub
                End If
            Next

            avatarPictureBox.Location = New Point(avatarPictureBox.Location.X, avatarPictureBox.Location.Y + cellSize)
        ElseIf e.KeyCode = Keys.A Then
            targetLocation = New Point(avatarPictureBox.Location.X - cellSize, avatarPictureBox.Location.Y)


            For Each wall As Control In wallsList
                If wall.Location = targetLocation Then
                    Exit Sub
                End If
            Next

            avatarPictureBox.Location = New Point(avatarPictureBox.Location.X - cellSize, avatarPictureBox.Location.Y)
        ElseIf e.KeyCode = Keys.D Then
            targetLocation = New Point(avatarPictureBox.Location.X + cellSize, avatarPictureBox.Location.Y)

            For Each wall As Control In wallsList
                If wall.Location = targetLocation Then
                    Exit Sub
                End If
            Next

            avatarPictureBox.Location = New Point(avatarPictureBox.Location.X + cellSize, avatarPictureBox.Location.Y)
        End If

        CheckIfExitReached(avatarPictureBox)
    End Sub

    Sub CheckIfExitReached(avatarPictureBox)
        If avatarPictureBox.Location = exitCell.Location Then
            MessageBox.Show("You have won.")
        End If
    End Sub
End Class