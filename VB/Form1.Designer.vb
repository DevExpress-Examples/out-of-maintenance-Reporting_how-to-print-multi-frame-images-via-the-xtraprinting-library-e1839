Namespace PrintImageFrames

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.printingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
            Me.button1 = New System.Windows.Forms.Button()
            Me.button2 = New System.Windows.Forms.Button()
            Me.checkBox1 = New System.Windows.Forms.CheckBox()
            CType(Me.printingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'button1
            '
            Me.button1.Location = New System.Drawing.Point(52, 12)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(108, 23)
            Me.button1.TabIndex = 0
            Me.button1.Text = "Print sample GIF"
            Me.button1.UseVisualStyleBackColor = True
            '
            'button2
            '
            Me.button2.Location = New System.Drawing.Point(53, 41)
            Me.button2.Name = "button2"
            Me.button2.Size = New System.Drawing.Size(108, 23)
            Me.button2.TabIndex = 1
            Me.button2.Text = "Print sample TIFF"
            Me.button2.UseVisualStyleBackColor = True
            '
            'checkBox1
            '
            Me.checkBox1.AutoSize = True
            Me.checkBox1.Location = New System.Drawing.Point(52, 81)
            Me.checkBox1.Name = "checkBox1"
            Me.checkBox1.Size = New System.Drawing.Size(109, 17)
            Me.checkBox1.TabIndex = 2
            Me.checkBox1.Text = "With PageBreaks"
            Me.checkBox1.UseVisualStyleBackColor = True
            '
            'Form1
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(203, 120)
            Me.Controls.Add(Me.checkBox1)
            Me.Controls.Add(Me.button2)
            Me.Controls.Add(Me.button1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            CType(Me.printingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region
        Private printingSystem1 As DevExpress.XtraPrinting.PrintingSystem

        Private WithEvents button1 As System.Windows.Forms.Button

        Private WithEvents button2 As System.Windows.Forms.Button

        Private checkBox1 As System.Windows.Forms.CheckBox
    End Class
End Namespace
