Public Class Form1
    Dim gridSize As Integer = 45
    Dim cellSize As Integer = 10
    Dim counter As Integer = 0
    Dim wallsList As New List(Of PictureBox)
    Dim unvisitedCells As New List(Of PictureBox)
    Dim Stack As New Stack(Of PictureBox)
    Dim CellsOnEdge As New List(Of PictureBox)
    Dim allCells As New List(Of PictureBox)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Maze"
        Me.BackColor = Color.DarkSlateGray
        Panel1.Location = New Point(540, 200) ' Puts the panel's location at this point
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

        Dim startCell As PictureBox = createRandomStartCell(Nothing)
        GenerateMaze(startCell)
        FixBackground()
        FindExit()
        FindStart(startCell)
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

    Sub BuildPathToNeighbour(currentCell, previousCell)
        ChangeCellColour(currentCell)
        BreakWallBetween(previousCell, currentCell)
        Stack.Push(currentCell)
    End Sub

    Dim random As New Random()
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

    Sub ChangeCellColour(currentCell)
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
        Dim exitCell As PictureBox
        Dim visitedNeighbours As New List(Of PictureBox)

        Do
            randInt = random.Next(CellsOnEdge.Count)

            exitCell = CellsOnEdge.Item(randInt)
        Loop Until exitCell.BackColor = Color.Black

        exitCell.BackColor = Color.Yellow
    End Sub

    Sub FindStart(startCell)
        startCell.BackColor = Color.Yellow
    End Sub
End Class