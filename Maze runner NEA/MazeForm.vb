Imports System.Configuration
Imports System.Data.SqlClient

Public Class MazeForm
    Public gridSize As Integer
    Public cellSize As Integer
    Dim counter As Integer = 0
    Dim wallsList As New List(Of PictureBox)
    Dim unvisitedCells As New List(Of PictureBox)
    Dim Stack As New Stack(Of PictureBox)
    Dim CellsOnEdge As New List(Of PictureBox)
    Dim allCells As New List(Of PictureBox)
    Public pathCell As PictureBox = Nothing
    Public avatar As New Avatar()
    Dim exitCell As PictureBox
    Public startCell As PictureBox = Nothing
    Dim topEdgeHasWalls As Boolean = True
    Dim bottomEdgeHasWalls As Boolean = True
    Dim leftEdgeHasWalls As Boolean = True
    Dim rightEdgeHasWalls As Boolean = True
    Dim borderWallsListX As New List(Of Integer)
    Dim borderWallsListY As New List(Of Integer)
    Public Shared trailColour As Color
    Private Sub MazeForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Maze"
        Me.WindowState = FormWindowState.Maximized
        Me.BackColor = Color.Black
        Me.KeyPreview = True

        If gridSize = 21 Then
            cellSize = 35
        ElseIf gridSize = 31 Then
            cellSize = 23
        ElseIf gridSize = 45 Then
            cellSize = 17
        ElseIf gridSize = 49 Then
            cellSize = 16
        End If

        Panel1.Location = New Point(Me.Width / 4, 10 + cellSize)
        Panel1.Size = New Size(gridSize * cellSize, gridSize * cellSize)
        Me.Controls.Add(Panel1)

        For Each cell In Panel1.Controls
            cell.Dispose()
            cell.Remove()
        Next
        Panel1.Controls.Clear()

        Dim isAWall As Boolean = True

        For i As Integer = 0 To gridSize - 1
            For j As Integer = 0 To gridSize - 1
                Dim cell As New PictureBox()

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

        pathCell = createRandomPathCell(Nothing)
        GenerateMaze(pathCell)
        AddEdgeWalls()
        FixBackground()
        FindExit()
        FindStartCell()
        CalibrateWallsList()
        avatar.AvatarInitilization(Panel1, startCell, cellSize)
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
    Function createRandomPathCell(currentCell)
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
    Sub FindStartCell()
        Dim random As New Random()

        Do
            Dim randInt As Integer = random.Next(allCells.Count)
            startCell = allCells.Item(randInt)
        Loop Until startCell.BackColor = Color.Black
    End Sub
    Sub AddEdgeWalls()
        Dim panelWidth As Integer = Panel1.Width
        Dim panelHeight As Integer = Panel1.Height
        Dim panelXOffset As Integer = Panel1.Location.X
        Dim panelYOffset As Integer = Panel1.Location.Y

        For x As Integer = 0 To gridSize - 1
            Dim topCellIndex As Integer = x
            Dim bottomCellIndex As Integer = (gridSize - 1) * gridSize + x

            If allCells(topCellIndex).BackColor <> Color.DarkSlateGray Then
                topEdgeHasWalls = False
            End If
            If allCells(bottomCellIndex).BackColor <> Color.DarkSlateGray Then
                bottomEdgeHasWalls = False
            End If
        Next

        For y As Integer = 0 To gridSize - 1
            Dim leftCellIndex As Integer = y * gridSize
            Dim rightCellIndex As Integer = (y * gridSize) + (gridSize - 1)

            If allCells(leftCellIndex).BackColor <> Color.DarkSlateGray Then
                leftEdgeHasWalls = False
            End If
            If allCells(rightCellIndex).BackColor <> Color.DarkSlateGray Then
                rightEdgeHasWalls = False
            End If
        Next

        If Not topEdgeHasWalls Then
            For x As Integer = 0 To gridSize - 1
                Dim wall As New PictureBox()
                Me.Controls.Add(wall)
                wall.Size = New Size(cellSize, cellSize)
                wall.Location = New Point(panelXOffset + (x * cellSize), panelYOffset - cellSize)
                wall.BackColor = Color.DarkSlateGray
                borderWallsListX.Add(wall.Location.X)
                borderWallsListY.Add(wall.Location.Y)
            Next
        End If

        If Not bottomEdgeHasWalls Then
            For x As Integer = 0 To gridSize - 1
                Dim wall As New PictureBox()
                Me.Controls.Add(wall)
                wall.Size = New Size(cellSize, cellSize)
                wall.Location = New Point(panelXOffset + (x * cellSize), panelYOffset + panelHeight)
                wall.BackColor = Color.DarkSlateGray
                borderWallsListX.Add(wall.Location.X)
                borderWallsListY.Add(wall.Location.Y)
            Next
        End If

        If Not leftEdgeHasWalls Then
            For y As Integer = 0 To gridSize - 1
                Dim wall As New PictureBox()
                Me.Controls.Add(wall)
                wall.Size = New Size(cellSize, cellSize)
                wall.Location = New Point(panelXOffset - cellSize, panelYOffset + (y * cellSize))
                wall.BackColor = Color.DarkSlateGray
                borderWallsListX.Add(wall.Location.X)
                borderWallsListY.Add(wall.Location.Y)
            Next
        End If

        If Not rightEdgeHasWalls Then
            For y As Integer = 0 To gridSize - 1
                Dim wall As New PictureBox()
                Me.Controls.Add(wall)
                wall.Size = New Size(cellSize, cellSize)
                wall.Location = New Point(panelXOffset + panelWidth, panelYOffset + (y * cellSize))
                wall.BackColor = Color.DarkSlateGray
                borderWallsListX.Add(wall.Location.X)
                borderWallsListY.Add(wall.Location.Y)
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
    Public Sub MazeForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim avatarPictureBox = avatar.Avatar
        Dim targetLocation = Nothing
        CalibrateWallsList()

        If e.KeyCode = Keys.W Then
            targetLocation = New Point(avatarPictureBox.Location.X, avatarPictureBox.Location.Y - cellSize)
            If ThereIsABorderWallInTheWay(targetLocation) Then
                Exit Sub
            End If


            For Each wall As Control In wallsList
                If wall.Location = targetLocation Then
                    Exit Sub
                End If
            Next

            avatarPictureBox.Location = New Point(avatarPictureBox.Location.X, avatarPictureBox.Location.Y - cellSize)
        ElseIf e.KeyCode = Keys.S Then
            targetLocation = New Point(avatarPictureBox.Location.X, avatarPictureBox.Location.Y + cellSize)
            If ThereIsABorderWallInTheWay(targetLocation) Then
                Exit Sub
            End If


            For Each wall As Control In wallsList
                If wall.Location = targetLocation Then
                    Exit Sub
                End If
            Next

            avatarPictureBox.Location = New Point(avatarPictureBox.Location.X, avatarPictureBox.Location.Y + cellSize)
        ElseIf e.KeyCode = Keys.A Then
            targetLocation = New Point(avatarPictureBox.Location.X - cellSize, avatarPictureBox.Location.Y)
            If ThereIsABorderWallInTheWay(targetLocation) Then
                Exit Sub
            End If


            For Each wall As Control In wallsList
                If wall.Location = targetLocation Then
                    Exit Sub
                End If
            Next

            avatarPictureBox.Location = New Point(avatarPictureBox.Location.X - cellSize, avatarPictureBox.Location.Y)
        ElseIf e.KeyCode = Keys.D Then
            targetLocation = New Point(avatarPictureBox.Location.X + cellSize, avatarPictureBox.Location.Y)
            If ThereIsABorderWallInTheWay(targetLocation) Then
                Exit Sub
            End If


            For Each wall As Control In wallsList
                If wall.Location = targetLocation Then
                    Exit Sub
                End If
            Next

            avatarPictureBox.Location = New Point(avatarPictureBox.Location.X + cellSize, avatarPictureBox.Location.Y)
        End If

        CheckIfExitReached(avatarPictureBox)
        CreateTrail(avatarPictureBox)
    End Sub
    Function ThereIsABorderWallInTheWay(targetLocation As Point) As Boolean
        For i = 0 To borderWallsListX.Count - 1
            If targetLocation = New Point(borderWallsListX.Item(i) - Panel1.Location.X, borderWallsListY.Item(i) - Panel1.Location.Y) Then
                Return True
                Exit Function
            End If
        Next

        Return False
    End Function
    Public level As Integer
    Sub CheckIfExitReached(avatarPictureBox)
        If avatarPictureBox.Location = exitCell.Location Then
            If gridSize = 21 Then
                LoginForm.score += 1
            ElseIf gridSize = 31 Then
                LoginForm.score += 2
            ElseIf gridSize = 45 Then
                LoginForm.score += 3
            ElseIf gridSize = 49 Then
                LoginForm.score += 4
            End If

            level = LoginForm.score \ 10

            UpdateScoreInDatabase(LoginForm.userName, LoginForm.score)

            MenuForm.Label1.Text = "Score " + Str(LoginForm.score)
            Me.Hide()
            MenuForm.Show()
        End If
    End Sub
    Sub CreateTrail(avatarPictureBox)
        For Each cell In allCells
            If cell.Location = avatarPictureBox.Location Then
                cell.BackColor = trailColour
                Exit For
            End If
        Next
    End Sub
    Private Sub UpdateScoreInDatabase(userName As String, newScore As Integer)
        ' Retrieve the connection string from App.config
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("DatabaseConnection").ConnectionString

        ' SQL query to update the score for the given username
        Dim query As String = "UPDATE Users SET Score = @NewScore WHERE UserName = @UserName"

        ' Using block to ensure connection is properly closed
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                ' Add parameters to prevent SQL Injection
                command.Parameters.AddWithValue("@UserName", userName)
                command.Parameters.AddWithValue("@NewScore", newScore)

                Try
                    ' Open the database connection
                    connection.Open()

                    ' Execute the query
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    ' Check if the update was successful
                    'If rowsAffected > 0 Then
                    '    MessageBox.Show("Score updated successfully in the database!")
                    'Else
                    '    MessageBox.Show("No matching username found. Score was not updated.")
                    'End If

                Catch ex As Exception
                    ' Handle any errors that may occur
                    MessageBox.Show("Error updating score: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub
End Class