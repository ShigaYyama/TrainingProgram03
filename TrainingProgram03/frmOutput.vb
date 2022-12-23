Imports System.Threading

Public Class formOutput

    'アプリケーション起動時
    Private Sub formOutput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmGrb.grbKadai1_1.Visible = False

        'アプリケーションの2重起動確認
        App.DuplicateCheck()

        'データベース接続確認
        DataBase.Loading()

        'コンボボックス1に課題名をセット
        For Each cbo1Items In Task.cbo1SetItems()
            cboKadai1.Items.Add(cbo1Items)
        Next

        grbKadai1_1.Visible = False
        grbKadai1_2.Visible = False
        grbKadai1_3.Visible = False
        grbKadai1_4.Visible = False
        grbKadai1_5.Visible = False
        grbKadai1_6.Visible = False
        grbKadai1_7.Visible = False
        grbKadai2_1.Visible = False

    End Sub

    'コンボボックス1変更時
    Private Sub cboKadai1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKadai1.SelectedIndexChanged
        '選択されたコンボボックス（cboKadai1）のシートに内にある問題の一覧を、コンボボックス（cboKadai2）に設定

        cboKadai2.Items.Clear()
        For Each cbo2Items In Task.cbo2SetItems(cboKadai1.Text)
            cboKadai2.Items.Add(cbo2Items)
        Next

    End Sub

    'コンボボックス2変更時
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKadai2.SelectedIndexChanged

        grbKadai1_1.Visible = False
        grbKadai1_2.Visible = False
        grbKadai1_3.Visible = False
        grbKadai1_4.Visible = False
        grbKadai1_5.Visible = False
        grbKadai1_6.Visible = False
        grbKadai1_7.Visible = False
        grbKadai2_1.Visible = False

        Dim strGrb As Control() = Me.Controls.Find(Forms.grbOpen(Task.cboSelected(cboKadai1.SelectedIndex, cboKadai2.SelectedIndex)), True)
        If strGrb.Length > 0 Then
            CType(strGrb(0), GroupBox).Visible = True
        End If

        CType(strGrb(0), GroupBox).Location = New Point(40, 170)
    End Sub

    '出力ボタン押下時
    Private Sub btnOutput_Click(sender As Object, e As EventArgs) Handles btnOutput.Click

        Dim strOrder As String

        If rbtJunjoAsc1_1.Checked = True Then
            strOrder = "ASC"
        Else
            strOrder = "DESC"
        End If

        Dim oraComm As String = Task.Query1_1(cboKadai1.SelectedIndex, strOrder)

        DataBase.outPuting(oraComm)

    End Sub

    '終了ボタン押下時
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Application.Exit()

    End Sub

    'フォーム終了時
    Private Sub formOutput_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        'データベースとの接続を切断
        DataBase.Closing()

    End Sub
End Class
