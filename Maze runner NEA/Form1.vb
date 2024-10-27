Public Class Form1
    Dim gridSize As Integer = 45
    Dim cellSize As Integer = 10
    Dim counter As Integer = 0
    Dim wallsList As New List(Of PictureBox)
    Dim unvisitedCells As New List(Of PictureBox)
    Dim visitedStack As New Stack(Of PictureBox)
    Dim CellsOnEdge As New List(Of PictureBox)
    Dim allCells As New List(Of PictureBox)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Location = New Point(10, 10) ' Puts the panel's location at this point
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
                    cell.BackColor = Color.Black
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
                    cell.BackColor = Color.Black
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

        ' Starts path creation
        GenerateMaze()
    End Sub

    Sub GenerateMaze()
        Dim unvisitedNeighbours As New List(Of PictureBox)
        Dim previousCell As PictureBox = Nothing
        Dim currentCell As PictureBox = FindStartCell(Nothing)
        CreateStartCell(currentCell)
        visitedStack.Push(currentCell)

        If unvisitedCells.Contains(currentCell) Then
            unvisitedCells.Remove(currentCell)
        End If

        Do While visitedStack.Count > 0 And unvisitedCells.Count > 0
            unvisitedNeighbours.Clear()

            previousCell = currentCell
            currentCell = FindUnvisitedNeighbourCell(currentCell, unvisitedNeighbours)

            If unvisitedNeighbours.Count > 0 Then
                BreakWallBetween(previousCell, currentCell)
                visitedStack.Push(currentCell)

                If unvisitedCells.Contains(currentCell) Then
                    unvisitedCells.Remove(currentCell)
                End If
            Else
                visitedStack.Pop()

                If visitedStack.Count > 0 Then
                    currentCell = visitedStack.Peek()
                Else
                    Exit Do
                End If
            End If
        Loop
    End Sub

    Dim random As New Random()
    Function FindStartCell(currentCell)
        Dim randInt As Integer = random.Next(unvisitedCells.Count)

        currentCell = unvisitedCells.Item(randInt)
        Return currentCell
    End Function

    Sub CreateStartCell(currentCell)
        currentCell.BackColor = Color.Lavender
    End Sub

    Function FindUnvisitedNeighbourCell(currentCell, unvisitedNeighbours)
        Dim x As Integer = currentCell.Location.X / cellSize
        Dim y As Integer = currentCell.Location.Y / cellSize

        Dim possibleMoves As Point() = {New Point(0, -2), New Point(0, 2), New Point(-2, 0), New Point(2, 0)}

        For Each move As Point In possibleMoves
            Dim moveX As Integer = x + move.X
            Dim moveY As Integer = y + move.Y

            If moveX < gridSize And moveY >= 0 And moveX >= 0 And moveY < gridSize Then
                Dim neighbourCell As PictureBox = allCells(moveY * gridSize + moveX)

                If neighbourCell.BackColor = Color.DarkSlateGray And Not visitedStack.Contains(neighbourCell) Then
                    unvisitedNeighbours.Add(neighbourCell)
                End If
            End If
        Next

        If unvisitedNeighbours.Count > 0 Then
            Return unvisitedNeighbours(random.Next(unvisitedNeighbours.Count))
        End If

        Return Nothing
    End Function

    Sub BreakWallBetween(previousCell, currentCell)
        Dim x As Integer = (previousCell.Location.X + currentCell.Location.X) / 2
        Dim y As Integer = (previousCell.Location.Y + currentCell.Location.Y) / 2

        Dim wallCell As PictureBox = allCells((y / cellSize) * gridSize + (x / cellSize))

        If wallCell IsNot Nothing Then
            wallCell.BackColor = Color.Lavender
        End If
    End Sub
End Class
