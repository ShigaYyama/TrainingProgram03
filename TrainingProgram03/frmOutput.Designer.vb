<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formOutput
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboKadai1 = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.btnOutput = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grbKadai1_1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grbKadai1_1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(69, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "帳票出力画面"
        '
        'cboKadai1
        '
        Me.cboKadai1.FormattingEnabled = True
        Me.cboKadai1.Location = New System.Drawing.Point(39, 91)
        Me.cboKadai1.Name = "cboKadai1"
        Me.cboKadai1.Size = New System.Drawing.Size(237, 26)
        Me.cboKadai1.TabIndex = 1
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(39, 159)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(237, 26)
        Me.ComboBox1.TabIndex = 2
        '
        'btnOutput
        '
        Me.btnOutput.Location = New System.Drawing.Point(551, 623)
        Me.btnOutput.Name = "btnOutput"
        Me.btnOutput.Size = New System.Drawing.Size(125, 40)
        Me.btnOutput.TabIndex = 3
        Me.btnOutput.Text = "出力"
        Me.btnOutput.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(805, 623)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(125, 40)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "終了"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grbKadai1_1
        '
        Me.grbKadai1_1.Controls.Add(Me.Label3)
        Me.grbKadai1_1.Controls.Add(Me.Label2)
        Me.grbKadai1_1.Location = New System.Drawing.Point(72, 250)
        Me.grbKadai1_1.Name = "grbKadai1_1"
        Me.grbKadai1_1.Size = New System.Drawing.Size(811, 279)
        Me.grbKadai1_1.TabIndex = 5
        Me.grbKadai1_1.TabStop = False
        Me.grbKadai1_1.Text = "課題1-問題1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(62, 158)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 18)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "順序："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(62, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "売上："
        '
        'formOutput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 688)
        Me.Controls.Add(Me.grbKadai1_1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnOutput)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.cboKadai1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "formOutput"
        Me.Text = "帳票出力"
        Me.grbKadai1_1.ResumeLayout(False)
        Me.grbKadai1_1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cboKadai1 As ComboBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents btnOutput As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents grbKadai1_1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
End Class
