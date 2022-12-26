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

        Dim addArray As String() = {"食品", "紳士服", "婦人服", "レストラン", "化粧品"}

        ltbSalseFloor1_3.Items.AddRange(addArray)
        ltbSalesFloor1_6.Items.AddRange(addArray)

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
        Dim oraComm As String = Nothing

        Select Case Task.cboSelected(cboKadai1.SelectedIndex, cboKadai2.SelectedIndex)

            '1-1
            Case 0

                Dim strOrder As String
                If rbtJunjoAsc1_1.Checked = True Then
                    strOrder = "ASC"
                Else
                    strOrder = "DESC"
                End If

                oraComm = Task.Query1_1(cboKadai1.SelectedIndex, strOrder)

            '1-2
            Case 1

                Dim strGender As String
                If rbtSexM1_2.Checked = True Then
                    strGender = "'男'"
                ElseIf rbtSexF1_2.Checked = True Then
                    strGender = "'女'"
                Else
                    strGender = "'男','女'"
                End If

                oraComm = Task.Query1_2(strGender)

            '1-3
            Case 2

                Dim strArea As String
                strArea = ltbSalseFloor1_3.SelectedItem

                oraComm = Task.Query1_3(strArea)

            '1-4
            Case 3

                Dim intDay As Integer
                intDay = CInt(dtpBirthday1_4.Value.ToString("yyyyMMdd"))

                Dim strOrder As String
                If rbtJunjoAsc1_1.Checked = True Then
                    strOrder = "ASC"
                Else
                    strOrder = "DESC"
                End If

                oraComm = Task.Query1_4(intDay, strOrder)

            '1-5
            Case 4

                Dim intMin, intMax As Integer
                intMin = txtNumberFrom1_5.Text
                intMax = txtNumberTo1_5.Text

                oraComm = Task.Query1_5(intMin, intMax)

            '1-6
            Case 5

                Dim strArea As String
                strArea = ltbSalesFloor1_6.SelectedItem

                oraComm = Task.Query1_6(strArea)

            '1-7
            Case 6

                Dim strName As String
                strName = txtSearch1_7.Text

                oraComm = Task.Query1_7(strName)

            '2-1
            Case 10

                Dim intMin, intMax As Integer
                intMin = txtNumberFrom2_1.Text
                intMax = txtNumberTo2_1.Text

                oraComm = Task.Query2_1(intMin, intMax)

            'Plsql
            Case 20

                oraComm = "RPG002"
                DataBase.outPutingPL(oraComm)
                Exit Sub

        End Select

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
