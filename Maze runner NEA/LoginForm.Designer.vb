<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Label1 = New Label()
        TextBox1 = New TextBox()
        Button1 = New Button()
        Label2 = New Label()
        Label3 = New Label()
        Button2 = New Button()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        PictureBox3 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Tahoma", 72F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(618, 70)
        Label1.Name = "Label1"
        Label1.Size = New Size(595, 145)
        Label1.TabIndex = 0
        Label1.Text = "Username"
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Tahoma", 72F, FontStyle.Regular, GraphicsUnit.Point)
        TextBox1.Location = New Point(346, 328)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(708, 152)
        TextBox1.TabIndex = 1
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Tahoma", 72F, FontStyle.Regular, GraphicsUnit.Point)
        Button1.Location = New Point(477, 248)
        Button1.Name = "Button1"
        Button1.Size = New Size(397, 157)
        Button1.TabIndex = 2
        Button1.Text = "Enter"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(122, 430)
        Label2.Name = "Label2"
        Label2.Size = New Size(0, 20)
        Label2.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("SimSun", 120F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(-4, 143)
        Label3.Name = "Label3"
        Label3.Size = New Size(1195, 200)
        Label3.TabIndex = 6
        Label3.Text = "MAZE RUNNER"
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Tahoma", 72F, FontStyle.Regular, GraphicsUnit.Point)
        Button2.Location = New Point(32, 328)
        Button2.Name = "Button2"
        Button2.Size = New Size(707, 183)
        Button2.TabIndex = 7
        Button2.Text = "Exit Game"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(61, 35)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(907, 726)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 8
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(255))
        PictureBox2.Location = New Point(552, 151)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(40, 423)
        PictureBox2.TabIndex = 9
        PictureBox2.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(255))
        PictureBox3.Location = New Point(364, 388)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(273, 40)
        PictureBox3.TabIndex = 10
        PictureBox3.TabStop = False
        ' 
        ' LoginForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1144, 572)
        Controls.Add(PictureBox3)
        Controls.Add(Label3)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Controls.Add(Button2)
        Controls.Add(Label2)
        Controls.Add(Button1)
        Controls.Add(TextBox1)
        Controls.Add(Label1)
        Name = "LoginForm"
        Text = "LoginForm"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
End Class
