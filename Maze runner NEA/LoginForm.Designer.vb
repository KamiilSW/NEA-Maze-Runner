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
        Label1 = New Label()
        TextBox1 = New TextBox()
        Button1 = New Button()
        Label2 = New Label()
        Label3 = New Label()
        Button2 = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Tahoma", 48F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(618, 70)
        Label1.Name = "Label1"
        Label1.Size = New Size(397, 97)
        Label1.TabIndex = 0
        Label1.Text = "Username"
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Tahoma", 48F, FontStyle.Regular, GraphicsUnit.Point)
        TextBox1.Location = New Point(618, 170)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(449, 104)
        TextBox1.TabIndex = 1
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Tahoma", 48F, FontStyle.Regular, GraphicsUnit.Point)
        Button1.Location = New Point(618, 280)
        Button1.Name = "Button1"
        Button1.Size = New Size(283, 104)
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
        Label3.Font = New Font("SimSun", 90F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(12, 59)
        Label3.Name = "Label3"
        Label3.Size = New Size(899, 150)
        Label3.TabIndex = 6
        Label3.Text = "MAZE RUNNER"
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Tahoma", 48F, FontStyle.Regular, GraphicsUnit.Point)
        Button2.Location = New Point(244, 374)
        Button2.Name = "Button2"
        Button2.Size = New Size(448, 122)
        Button2.TabIndex = 7
        Button2.Text = "Exit Game"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' LoginForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1144, 572)
        Controls.Add(Button2)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Button1)
        Controls.Add(TextBox1)
        Controls.Add(Label1)
        Name = "LoginForm"
        Text = "LoginForm"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button2 As Button
End Class
