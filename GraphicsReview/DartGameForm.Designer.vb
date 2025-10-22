<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DartGameForm
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
        Me.ButtonGroupBox = New System.Windows.Forms.GroupBox()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.ClearButton = New System.Windows.Forms.Button()
        Me.DartBoardPictureBox = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.CoordsStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.RoundLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.RoundNumberLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ThrowButton = New System.Windows.Forms.Button()
        Me.RoundButton = New System.Windows.Forms.Button()
        Me.ReviewButton = New System.Windows.Forms.Button()
        Me.ReviewRoundComboBox = New System.Windows.Forms.ComboBox()
        Me.DartLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DartNumberLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ButtonGroupBox.SuspendLayout()
        CType(Me.DartBoardPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonGroupBox
        '
        Me.ButtonGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonGroupBox.Controls.Add(Me.ExitButton)
        Me.ButtonGroupBox.Controls.Add(Me.ClearButton)
        Me.ButtonGroupBox.Location = New System.Drawing.Point(498, 341)
        Me.ButtonGroupBox.Name = "ButtonGroupBox"
        Me.ButtonGroupBox.Size = New System.Drawing.Size(290, 100)
        Me.ButtonGroupBox.TabIndex = 0
        Me.ButtonGroupBox.TabStop = False
        '
        'ExitButton
        '
        Me.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ExitButton.Location = New System.Drawing.Point(166, 42)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(99, 29)
        Me.ExitButton.TabIndex = 5
        Me.ExitButton.Text = "Exit"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'ClearButton
        '
        Me.ClearButton.Location = New System.Drawing.Point(26, 42)
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(99, 29)
        Me.ClearButton.TabIndex = 4
        Me.ClearButton.Text = "Clear"
        Me.ClearButton.UseVisualStyleBackColor = True
        '
        'DartBoardPictureBox
        '
        Me.DartBoardPictureBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DartBoardPictureBox.BackColor = System.Drawing.Color.White
        Me.DartBoardPictureBox.Location = New System.Drawing.Point(12, 12)
        Me.DartBoardPictureBox.Name = "DartBoardPictureBox"
        Me.DartBoardPictureBox.Size = New System.Drawing.Size(776, 323)
        Me.DartBoardPictureBox.TabIndex = 1
        Me.DartBoardPictureBox.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CoordsStatusLabel, Me.RoundLabel, Me.RoundNumberLabel, Me.DartLabel, Me.DartNumberLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 427)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 26)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'CoordsStatusLabel
        '
        Me.CoordsStatusLabel.Name = "CoordsStatusLabel"
        Me.CoordsStatusLabel.Size = New System.Drawing.Size(70, 20)
        Me.CoordsStatusLabel.Text = "MouseXY"
        '
        'RoundLabel
        '
        Me.RoundLabel.Name = "RoundLabel"
        Me.RoundLabel.Size = New System.Drawing.Size(55, 20)
        Me.RoundLabel.Text = "Round:"
        '
        'RoundNumberLabel
        '
        Me.RoundNumberLabel.Name = "RoundNumberLabel"
        Me.RoundNumberLabel.Size = New System.Drawing.Size(17, 20)
        Me.RoundNumberLabel.Text = "0"
        '
        'ThrowButton
        '
        Me.ThrowButton.Location = New System.Drawing.Point(12, 350)
        Me.ThrowButton.Name = "ThrowButton"
        Me.ThrowButton.Size = New System.Drawing.Size(99, 29)
        Me.ThrowButton.TabIndex = 1
        Me.ThrowButton.Text = "Throw"
        Me.ThrowButton.UseVisualStyleBackColor = True
        '
        'RoundButton
        '
        Me.RoundButton.Location = New System.Drawing.Point(12, 383)
        Me.RoundButton.Name = "RoundButton"
        Me.RoundButton.Size = New System.Drawing.Size(224, 29)
        Me.RoundButton.TabIndex = 3
        Me.RoundButton.Text = "Start Next Round"
        Me.RoundButton.UseVisualStyleBackColor = True
        '
        'ReviewButton
        '
        Me.ReviewButton.Location = New System.Drawing.Point(137, 350)
        Me.ReviewButton.Name = "ReviewButton"
        Me.ReviewButton.Size = New System.Drawing.Size(99, 29)
        Me.ReviewButton.TabIndex = 2
        Me.ReviewButton.Text = "Review"
        Me.ReviewButton.UseVisualStyleBackColor = True
        '
        'ReviewRoundComboBox
        '
        Me.ReviewRoundComboBox.FormattingEnabled = True
        Me.ReviewRoundComboBox.Location = New System.Drawing.Point(242, 353)
        Me.ReviewRoundComboBox.Name = "ReviewRoundComboBox"
        Me.ReviewRoundComboBox.Size = New System.Drawing.Size(106, 24)
        Me.ReviewRoundComboBox.TabIndex = 4
        '
        'DartLabel
        '
        Me.DartLabel.Name = "DartLabel"
        Me.DartLabel.Size = New System.Drawing.Size(41, 20)
        Me.DartLabel.Text = "Dart:"
        '
        'DartNumberLabel
        '
        Me.DartNumberLabel.Name = "DartNumberLabel"
        Me.DartNumberLabel.Size = New System.Drawing.Size(17, 20)
        Me.DartNumberLabel.Text = "0"
        '
        'DartGameForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.CancelButton = Me.ExitButton
        Me.ClientSize = New System.Drawing.Size(800, 453)
        Me.Controls.Add(Me.ReviewRoundComboBox)
        Me.Controls.Add(Me.ReviewButton)
        Me.Controls.Add(Me.RoundButton)
        Me.Controls.Add(Me.ThrowButton)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.DartBoardPictureBox)
        Me.Controls.Add(Me.ButtonGroupBox)
        Me.MinimumSize = New System.Drawing.Size(325, 500)
        Me.Name = "DartGameForm"
        Me.Text = "Dart Game"
        Me.ButtonGroupBox.ResumeLayout(False)
        CType(Me.DartBoardPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonGroupBox As GroupBox
    Friend WithEvents ClearButton As Button
    Friend WithEvents ExitButton As Button
    Friend WithEvents DartBoardPictureBox As PictureBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents CoordsStatusLabel As ToolStripStatusLabel
    Friend WithEvents ThrowButton As Button
    Friend WithEvents RoundButton As Button
    Friend WithEvents ReviewButton As Button
    Friend WithEvents RoundLabel As ToolStripStatusLabel
    Friend WithEvents RoundNumberLabel As ToolStripStatusLabel
    Friend WithEvents ReviewRoundComboBox As ComboBox
    Friend WithEvents DartLabel As ToolStripStatusLabel
    Friend WithEvents DartNumberLabel As ToolStripStatusLabel
End Class
