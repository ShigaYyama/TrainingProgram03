<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formOutput
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboKadai1 = New System.Windows.Forms.ComboBox()
        Me.cboKadai2 = New System.Windows.Forms.ComboBox()
        Me.btnOutput = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grbKadai1_1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUriage1_1 = New System.Windows.Forms.TextBox()
        Me.rbtJunjoDesc1_1 = New System.Windows.Forms.RadioButton()
        Me.rbtJunjoAsc1_1 = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grbKadai1_2 = New System.Windows.Forms.GroupBox()
        Me.rbtSexMF1_2 = New System.Windows.Forms.RadioButton()
        Me.rbtSexF1_2 = New System.Windows.Forms.RadioButton()
        Me.rbtSexM1_2 = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.grbKadai1_3 = New System.Windows.Forms.GroupBox()
        Me.ltbSalseFloor1_3 = New System.Windows.Forms.ListBox()
        Me.grbKadai2_1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtNumberTo2_1 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNumberFrom2_1 = New System.Windows.Forms.TextBox()
        Me.grbKadai1_7 = New System.Windows.Forms.GroupBox()
        Me.txtSearch1_7 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.grbKadai1_6 = New System.Windows.Forms.GroupBox()
        Me.ltbSalesFloor1_6 = New System.Windows.Forms.ListBox()
        Me.grbKadai1_5 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNumberTo1_5 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNumberFrom1_5 = New System.Windows.Forms.TextBox()
        Me.grbKadai1_4 = New System.Windows.Forms.GroupBox()
        Me.dtpBirthday1_4 = New System.Windows.Forms.DateTimePicker()
        Me.rbtJunjoDesc1_4 = New System.Windows.Forms.RadioButton()
        Me.rbtJunjoAsc1_4 = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.grbKadai1_1.SuspendLayout()
        Me.grbKadai1_2.SuspendLayout()
        Me.grbKadai1_3.SuspendLayout()
        Me.grbKadai2_1.SuspendLayout()
        Me.grbKadai1_7.SuspendLayout()
        Me.grbKadai1_6.SuspendLayout()
        Me.grbKadai1_5.SuspendLayout()
        Me.grbKadai1_4.SuspendLayout()
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
        'cboKadai2
        '
        Me.cboKadai2.FormattingEnabled = True
        Me.cboKadai2.Location = New System.Drawing.Point(39, 159)
        Me.cboKadai2.Name = "cboKadai2"
        Me.cboKadai2.Size = New System.Drawing.Size(237, 26)
        Me.cboKadai2.TabIndex = 2
        '
        'btnOutput
        '
        Me.btnOutput.Location = New System.Drawing.Point(563, 595)
        Me.btnOutput.Name = "btnOutput"
        Me.btnOutput.Size = New System.Drawing.Size(125, 40)
        Me.btnOutput.TabIndex = 3
        Me.btnOutput.Text = "出力"
        Me.btnOutput.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(735, 595)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(125, 40)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "終了"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grbKadai1_1
        '
        Me.grbKadai1_1.Controls.Add(Me.Label4)
        Me.grbKadai1_1.Controls.Add(Me.txtUriage1_1)
        Me.grbKadai1_1.Controls.Add(Me.rbtJunjoDesc1_1)
        Me.grbKadai1_1.Controls.Add(Me.rbtJunjoAsc1_1)
        Me.grbKadai1_1.Controls.Add(Me.Label3)
        Me.grbKadai1_1.Controls.Add(Me.Label2)
        Me.grbKadai1_1.Location = New System.Drawing.Point(39, 266)
        Me.grbKadai1_1.Name = "grbKadai1_1"
        Me.grbKadai1_1.Size = New System.Drawing.Size(604, 226)
        Me.grbKadai1_1.TabIndex = 9
        Me.grbKadai1_1.TabStop = False
        Me.grbKadai1_1.Text = "課題1-問題1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(459, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 18)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "円以上"
        '
        'txtUriage1_1
        '
        Me.txtUriage1_1.Location = New System.Drawing.Point(188, 86)
        Me.txtUriage1_1.Name = "txtUriage1_1"
        Me.txtUriage1_1.Size = New System.Drawing.Size(247, 25)
        Me.txtUriage1_1.TabIndex = 4
        '
        'rbtJunjoDesc1_1
        '
        Me.rbtJunjoDesc1_1.AutoSize = True
        Me.rbtJunjoDesc1_1.Location = New System.Drawing.Point(305, 153)
        Me.rbtJunjoDesc1_1.Name = "rbtJunjoDesc1_1"
        Me.rbtJunjoDesc1_1.Size = New System.Drawing.Size(69, 22)
        Me.rbtJunjoDesc1_1.TabIndex = 3
        Me.rbtJunjoDesc1_1.TabStop = True
        Me.rbtJunjoDesc1_1.Text = "降順"
        Me.rbtJunjoDesc1_1.UseVisualStyleBackColor = True
        '
        'rbtJunjoAsc1_1
        '
        Me.rbtJunjoAsc1_1.AutoSize = True
        Me.rbtJunjoAsc1_1.Location = New System.Drawing.Point(188, 154)
        Me.rbtJunjoAsc1_1.Name = "rbtJunjoAsc1_1"
        Me.rbtJunjoAsc1_1.Size = New System.Drawing.Size(69, 22)
        Me.rbtJunjoAsc1_1.TabIndex = 2
        Me.rbtJunjoAsc1_1.TabStop = True
        Me.rbtJunjoAsc1_1.Text = "昇順"
        Me.rbtJunjoAsc1_1.UseVisualStyleBackColor = True
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
        'grbKadai1_2
        '
        Me.grbKadai1_2.Controls.Add(Me.rbtSexMF1_2)
        Me.grbKadai1_2.Controls.Add(Me.rbtSexF1_2)
        Me.grbKadai1_2.Controls.Add(Me.rbtSexM1_2)
        Me.grbKadai1_2.Controls.Add(Me.Label7)
        Me.grbKadai1_2.Location = New System.Drawing.Point(671, 21)
        Me.grbKadai1_2.Name = "grbKadai1_2"
        Me.grbKadai1_2.Size = New System.Drawing.Size(368, 186)
        Me.grbKadai1_2.TabIndex = 10
        Me.grbKadai1_2.TabStop = False
        Me.grbKadai1_2.Text = "課題1-問題2"
        '
        'rbtSexMF1_2
        '
        Me.rbtSexMF1_2.AutoSize = True
        Me.rbtSexMF1_2.Location = New System.Drawing.Point(118, 134)
        Me.rbtSexMF1_2.Name = "rbtSexMF1_2"
        Me.rbtSexMF1_2.Size = New System.Drawing.Size(69, 22)
        Me.rbtSexMF1_2.TabIndex = 4
        Me.rbtSexMF1_2.TabStop = True
        Me.rbtSexMF1_2.Text = "男女"
        Me.rbtSexMF1_2.UseVisualStyleBackColor = True
        '
        'rbtSexF1_2
        '
        Me.rbtSexF1_2.AutoSize = True
        Me.rbtSexF1_2.Location = New System.Drawing.Point(202, 81)
        Me.rbtSexF1_2.Name = "rbtSexF1_2"
        Me.rbtSexF1_2.Size = New System.Drawing.Size(51, 22)
        Me.rbtSexF1_2.TabIndex = 3
        Me.rbtSexF1_2.TabStop = True
        Me.rbtSexF1_2.Text = "女"
        Me.rbtSexF1_2.UseVisualStyleBackColor = True
        '
        'rbtSexM1_2
        '
        Me.rbtSexM1_2.AutoSize = True
        Me.rbtSexM1_2.Location = New System.Drawing.Point(118, 83)
        Me.rbtSexM1_2.Name = "rbtSexM1_2"
        Me.rbtSexM1_2.Size = New System.Drawing.Size(51, 22)
        Me.rbtSexM1_2.TabIndex = 2
        Me.rbtSexM1_2.TabStop = True
        Me.rbtSexM1_2.Text = "男"
        Me.rbtSexM1_2.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 85)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 18)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "性別："
        '
        'grbKadai1_3
        '
        Me.grbKadai1_3.Controls.Add(Me.ltbSalseFloor1_3)
        Me.grbKadai1_3.Location = New System.Drawing.Point(671, 222)
        Me.grbKadai1_3.Name = "grbKadai1_3"
        Me.grbKadai1_3.Size = New System.Drawing.Size(368, 186)
        Me.grbKadai1_3.TabIndex = 11
        Me.grbKadai1_3.TabStop = False
        Me.grbKadai1_3.Text = "課題1-問題3"
        '
        'ltbSalseFloor1_3
        '
        Me.ltbSalseFloor1_3.FormattingEnabled = True
        Me.ltbSalseFloor1_3.ItemHeight = 18
        Me.ltbSalseFloor1_3.Location = New System.Drawing.Point(24, 56)
        Me.ltbSalseFloor1_3.Name = "ltbSalseFloor1_3"
        Me.ltbSalseFloor1_3.Size = New System.Drawing.Size(186, 94)
        Me.ltbSalseFloor1_3.TabIndex = 0
        '
        'grbKadai2_1
        '
        Me.grbKadai2_1.Controls.Add(Me.Label8)
        Me.grbKadai2_1.Controls.Add(Me.txtNumberTo2_1)
        Me.grbKadai2_1.Controls.Add(Me.Label9)
        Me.grbKadai2_1.Controls.Add(Me.txtNumberFrom2_1)
        Me.grbKadai2_1.Location = New System.Drawing.Point(1470, 425)
        Me.grbKadai2_1.Name = "grbKadai2_1"
        Me.grbKadai2_1.Size = New System.Drawing.Size(522, 186)
        Me.grbKadai2_1.TabIndex = 19
        Me.grbKadai2_1.TabStop = False
        Me.grbKadai2_1.Text = "課題2-問題1"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(281, 101)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 18)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "～"
        '
        'txtNumberTo2_1
        '
        Me.txtNumberTo2_1.Location = New System.Drawing.Point(340, 98)
        Me.txtNumberTo2_1.Name = "txtNumberTo2_1"
        Me.txtNumberTo2_1.Size = New System.Drawing.Size(155, 25)
        Me.txtNumberTo2_1.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 101)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 18)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "No："
        '
        'txtNumberFrom2_1
        '
        Me.txtNumberFrom2_1.Location = New System.Drawing.Point(72, 98)
        Me.txtNumberFrom2_1.Name = "txtNumberFrom2_1"
        Me.txtNumberFrom2_1.Size = New System.Drawing.Size(155, 25)
        Me.txtNumberFrom2_1.TabIndex = 0
        '
        'grbKadai1_7
        '
        Me.grbKadai1_7.Controls.Add(Me.txtSearch1_7)
        Me.grbKadai1_7.Controls.Add(Me.Label10)
        Me.grbKadai1_7.Location = New System.Drawing.Point(1610, 25)
        Me.grbKadai1_7.Name = "grbKadai1_7"
        Me.grbKadai1_7.Size = New System.Drawing.Size(318, 164)
        Me.grbKadai1_7.TabIndex = 18
        Me.grbKadai1_7.TabStop = False
        Me.grbKadai1_7.Text = "課題1-問題7"
        '
        'txtSearch1_7
        '
        Me.txtSearch1_7.Location = New System.Drawing.Point(114, 86)
        Me.txtSearch1_7.Name = "txtSearch1_7"
        Me.txtSearch1_7.Size = New System.Drawing.Size(157, 25)
        Me.txtSearch1_7.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(27, 89)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 18)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "検索："
        '
        'grbKadai1_6
        '
        Me.grbKadai1_6.Controls.Add(Me.ltbSalesFloor1_6)
        Me.grbKadai1_6.Location = New System.Drawing.Point(1074, 425)
        Me.grbKadai1_6.Name = "grbKadai1_6"
        Me.grbKadai1_6.Size = New System.Drawing.Size(368, 186)
        Me.grbKadai1_6.TabIndex = 17
        Me.grbKadai1_6.TabStop = False
        Me.grbKadai1_6.Text = "課題1-問題6"
        '
        'ltbSalesFloor1_6
        '
        Me.ltbSalesFloor1_6.FormattingEnabled = True
        Me.ltbSalesFloor1_6.ItemHeight = 18
        Me.ltbSalesFloor1_6.Location = New System.Drawing.Point(24, 56)
        Me.ltbSalesFloor1_6.Name = "ltbSalesFloor1_6"
        Me.ltbSalesFloor1_6.Size = New System.Drawing.Size(186, 94)
        Me.ltbSalesFloor1_6.TabIndex = 0
        '
        'grbKadai1_5
        '
        Me.grbKadai1_5.Controls.Add(Me.Label6)
        Me.grbKadai1_5.Controls.Add(Me.txtNumberTo1_5)
        Me.grbKadai1_5.Controls.Add(Me.Label5)
        Me.grbKadai1_5.Controls.Add(Me.txtNumberFrom1_5)
        Me.grbKadai1_5.Location = New System.Drawing.Point(1074, 222)
        Me.grbKadai1_5.Name = "grbKadai1_5"
        Me.grbKadai1_5.Size = New System.Drawing.Size(522, 186)
        Me.grbKadai1_5.TabIndex = 16
        Me.grbKadai1_5.TabStop = False
        Me.grbKadai1_5.Text = "課題1-問題5"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(281, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 18)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "～"
        '
        'txtNumberTo1_5
        '
        Me.txtNumberTo1_5.Location = New System.Drawing.Point(340, 98)
        Me.txtNumberTo1_5.Name = "txtNumberTo1_5"
        Me.txtNumberTo1_5.Size = New System.Drawing.Size(155, 25)
        Me.txtNumberTo1_5.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 101)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 18)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "No："
        '
        'txtNumberFrom1_5
        '
        Me.txtNumberFrom1_5.Location = New System.Drawing.Point(72, 98)
        Me.txtNumberFrom1_5.Name = "txtNumberFrom1_5"
        Me.txtNumberFrom1_5.Size = New System.Drawing.Size(155, 25)
        Me.txtNumberFrom1_5.TabIndex = 0
        '
        'grbKadai1_4
        '
        Me.grbKadai1_4.Controls.Add(Me.dtpBirthday1_4)
        Me.grbKadai1_4.Controls.Add(Me.rbtJunjoDesc1_4)
        Me.grbKadai1_4.Controls.Add(Me.rbtJunjoAsc1_4)
        Me.grbKadai1_4.Controls.Add(Me.Label11)
        Me.grbKadai1_4.Location = New System.Drawing.Point(1074, 25)
        Me.grbKadai1_4.Name = "grbKadai1_4"
        Me.grbKadai1_4.Size = New System.Drawing.Size(368, 186)
        Me.grbKadai1_4.TabIndex = 15
        Me.grbKadai1_4.TabStop = False
        Me.grbKadai1_4.Text = "課題1-問題4"
        '
        'dtpBirthday1_4
        '
        Me.dtpBirthday1_4.Location = New System.Drawing.Point(27, 68)
        Me.dtpBirthday1_4.Name = "dtpBirthday1_4"
        Me.dtpBirthday1_4.Size = New System.Drawing.Size(220, 25)
        Me.dtpBirthday1_4.TabIndex = 7
        '
        'rbtJunjoDesc1_4
        '
        Me.rbtJunjoDesc1_4.AutoSize = True
        Me.rbtJunjoDesc1_4.Location = New System.Drawing.Point(227, 131)
        Me.rbtJunjoDesc1_4.Name = "rbtJunjoDesc1_4"
        Me.rbtJunjoDesc1_4.Size = New System.Drawing.Size(69, 22)
        Me.rbtJunjoDesc1_4.TabIndex = 6
        Me.rbtJunjoDesc1_4.TabStop = True
        Me.rbtJunjoDesc1_4.Text = "降順"
        Me.rbtJunjoDesc1_4.UseVisualStyleBackColor = True
        '
        'rbtJunjoAsc1_4
        '
        Me.rbtJunjoAsc1_4.AutoSize = True
        Me.rbtJunjoAsc1_4.Location = New System.Drawing.Point(110, 132)
        Me.rbtJunjoAsc1_4.Name = "rbtJunjoAsc1_4"
        Me.rbtJunjoAsc1_4.Size = New System.Drawing.Size(69, 22)
        Me.rbtJunjoAsc1_4.TabIndex = 5
        Me.rbtJunjoAsc1_4.TabStop = True
        Me.rbtJunjoAsc1_4.Text = "昇順"
        Me.rbtJunjoAsc1_4.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(24, 135)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 18)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "順序："
        '
        'formOutput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2009, 651)
        Me.Controls.Add(Me.grbKadai2_1)
        Me.Controls.Add(Me.grbKadai1_7)
        Me.Controls.Add(Me.grbKadai1_6)
        Me.Controls.Add(Me.grbKadai1_5)
        Me.Controls.Add(Me.grbKadai1_4)
        Me.Controls.Add(Me.grbKadai1_3)
        Me.Controls.Add(Me.grbKadai1_2)
        Me.Controls.Add(Me.grbKadai1_1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnOutput)
        Me.Controls.Add(Me.cboKadai2)
        Me.Controls.Add(Me.cboKadai1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "formOutput"
        Me.Text = "帳票出力"
        Me.grbKadai1_1.ResumeLayout(False)
        Me.grbKadai1_1.PerformLayout()
        Me.grbKadai1_2.ResumeLayout(False)
        Me.grbKadai1_2.PerformLayout()
        Me.grbKadai1_3.ResumeLayout(False)
        Me.grbKadai2_1.ResumeLayout(False)
        Me.grbKadai2_1.PerformLayout()
        Me.grbKadai1_7.ResumeLayout(False)
        Me.grbKadai1_7.PerformLayout()
        Me.grbKadai1_6.ResumeLayout(False)
        Me.grbKadai1_5.ResumeLayout(False)
        Me.grbKadai1_5.PerformLayout()
        Me.grbKadai1_4.ResumeLayout(False)
        Me.grbKadai1_4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cboKadai1 As ComboBox
    Friend WithEvents cboKadai2 As ComboBox
    Friend WithEvents btnOutput As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents grbKadai1_1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtUriage1_1 As TextBox
    Friend WithEvents rbtJunjoDesc1_1 As RadioButton
    Friend WithEvents rbtJunjoAsc1_1 As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents grbKadai1_2 As GroupBox
    Friend WithEvents rbtSexMF1_2 As RadioButton
    Friend WithEvents rbtSexF1_2 As RadioButton
    Friend WithEvents rbtSexM1_2 As RadioButton
    Friend WithEvents Label7 As Label
    Friend WithEvents grbKadai1_3 As GroupBox
    Friend WithEvents ltbSalseFloor1_3 As ListBox
    Friend WithEvents grbKadai2_1 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtNumberTo2_1 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtNumberFrom2_1 As TextBox
    Friend WithEvents grbKadai1_7 As GroupBox
    Friend WithEvents txtSearch1_7 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents grbKadai1_6 As GroupBox
    Friend WithEvents ltbSalesFloor1_6 As ListBox
    Friend WithEvents grbKadai1_5 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtNumberTo1_5 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNumberFrom1_5 As TextBox
    Friend WithEvents grbKadai1_4 As GroupBox
    Friend WithEvents dtpBirthday1_4 As DateTimePicker
    Friend WithEvents rbtJunjoDesc1_4 As RadioButton
    Friend WithEvents rbtJunjoAsc1_4 As RadioButton
    Friend WithEvents Label11 As Label
End Class
