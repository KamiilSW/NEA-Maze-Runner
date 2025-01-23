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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MazeForm))
        Panel1 = New Panel()
        Button1 = New Button()
        Timer1 = New Timer(components)
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        Label2 = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
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
        Button1.BackColor = Color.MediumPurple
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point)
        Button1.ForeColor = SystemColors.ControlText
        Button1.Location = New Point(388, 26)
        Button1.Name = "Button1"
        Button1.Size = New Size(391, 111)
        Button1.TabIndex = 1
        Button1.Text = "Exit Maze"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Timer1
        ' 
        Timer1.Enabled = True
        Timer1.Interval = 1000
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Tahoma", 36F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(143, 211)
        Label1.Name = "Label1"
        Label1.Size = New Size(106, 72)
        Label1.TabIndex = 2
        Label1.Text = "80"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(300, 211)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(398, 227)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 3
        PictureBox1.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.MediumPurple
        Label2.BorderStyle = BorderStyle.FixedSingle
        Label2.FlatStyle = FlatStyle.Popup
        Label2.Font = New Font("Arial Narrow", 48F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.ForeColor = Color.DarkRed
        Label2.Location = New Point(388, 140)
        Label2.Name = "Label2"
        Label2.Size = New Size(321, 96)
        Label2.TabIndex = 4
        Label2.Text = "Difficulty"
        ' 
        ' MazeForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label2)
        Controls.Add(PictureBox1)
        Controls.Add(Label1)
        Controls.Add(Button1)
        Controls.Add(Panel1)
        Name = "MazeForm"
        Text = "Form1"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Public WithEvents Panel1 As New System.Windows.Forms.Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label

End Class
