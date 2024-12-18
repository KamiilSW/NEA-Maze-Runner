<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MazeForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Panel1 = New Panel()
        Button1 = New Button()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Location = New Point(12, 12)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(250, 125)
        Panel1.TabIndex = 0
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(685, 26)
        Button1.Name = "Button1"
        Button1.Size = New Size(94, 29)
        Button1.TabIndex = 1
        Button1.Text = "Exit Maze"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' MazeForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Button1)
        Controls.Add(Panel1)
        Name = "MazeForm"
        Text = "Form1"
        ResumeLayout(False)
    End Sub

    Public WithEvents Panel1 As New System.Windows.Forms.Panel
    Friend WithEvents Button1 As Button

End Class
