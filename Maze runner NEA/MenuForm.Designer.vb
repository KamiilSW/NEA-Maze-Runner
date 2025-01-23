<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MenuForm))
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        Button5 = New Button()
        Button6 = New Button()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        PictureBox3 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.White
        Button1.Font = New Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point)
        Button1.ForeColor = SystemColors.ActiveCaptionText
        Button1.Location = New Point(-22, 176)
        Button1.Name = "Button1"
        Button1.Size = New Size(245, 228)
        Button1.TabIndex = 0
        Button1.Text = "Click here to Play" & vbCrLf & "Easy Maze " & vbCrLf & "(1 Point)"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.White
        Button2.Font = New Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point)
        Button2.ForeColor = SystemColors.ActiveCaptionText
        Button2.Location = New Point(229, 176)
        Button2.Name = "Button2"
        Button2.Size = New Size(245, 228)
        Button2.TabIndex = 1
        Button2.Text = "Click here to Play" & vbCrLf & "Medium Maze" & vbCrLf & "(2 Points)"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.White
        Button3.Font = New Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point)
        Button3.ForeColor = SystemColors.ActiveCaptionText
        Button3.Location = New Point(480, 176)
        Button3.Name = "Button3"
        Button3.Size = New Size(245, 228)
        Button3.TabIndex = 2
        Button3.Text = "Click here to Play" & vbCrLf & "Hard Maze" & vbCrLf & "(3 Points)"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Button4
        ' 
        Button4.BackColor = Color.White
        Button4.Font = New Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point)
        Button4.ForeColor = SystemColors.ActiveCaptionText
        Button4.Location = New Point(731, 176)
        Button4.Name = "Button4"
        Button4.Size = New Size(245, 228)
        Button4.TabIndex = 3
        Button4.Text = "Click here to Play" & vbCrLf & "Insane Maze" & vbCrLf & "(4 Points)"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Button5
        ' 
        Button5.BackColor = SystemColors.ButtonHighlight
        Button5.Font = New Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point)
        Button5.ForeColor = SystemColors.ActiveCaptionText
        Button5.Location = New Point(165, 76)
        Button5.Name = "Button5"
        Button5.Size = New Size(309, 193)
        Button5.TabIndex = 5
        Button5.Text = "Button5"
        Button5.TextImageRelation = TextImageRelation.TextBeforeImage
        Button5.UseVisualStyleBackColor = False
        ' 
        ' Button6
        ' 
        Button6.BackColor = SystemColors.ButtonHighlight
        Button6.Font = New Font("Segoe UI Semibold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point)
        Button6.Location = New Point(516, 97)
        Button6.Name = "Button6"
        Button6.Size = New Size(334, 162)
        Button6.TabIndex = 6
        Button6.Text = "Button6"
        Button6.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = SystemColors.ButtonHighlight
        Label1.FlatStyle = FlatStyle.System
        Label1.Font = New Font("Verdana", 94.8F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = SystemColors.ActiveCaptionText
        Label1.Location = New Point(-22, 386)
        Label1.Name = "Label1"
        Label1.Size = New Size(1771, 191)
        Label1.TabIndex = 7
        Label1.Text = "Maze Runner Menu"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = SystemColors.ButtonHighlight
        PictureBox1.Location = New Point(480, 29)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(370, 10)
        PictureBox1.TabIndex = 8
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.MediumPurple
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(403, 306)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(125, 62)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 9
        PictureBox2.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.MediumPurple
        PictureBox3.Location = New Point(120, 283)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(125, 62)
        PictureBox3.TabIndex = 10
        PictureBox3.TabStop = False
        ' 
        ' MenuForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaptionText
        ClientSize = New Size(953, 554)
        Controls.Add(PictureBox3)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Controls.Add(Label1)
        Controls.Add(Button6)
        Controls.Add(Button5)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Name = "MenuForm"
        Text = "Form2"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
End Class
