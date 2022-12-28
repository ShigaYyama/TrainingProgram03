﻿Imports System.Data.SqlClient
Imports System.Threading

Public Class formOutput


    'アプリケーション起動時
    Private Sub formOutput_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'アプリケーションの2重起動確認（ミューテックス生成）
        AppSys.duplicateCheck()

        'データベース接続確認
        DataBase.loading()

        'コンボボックス1に課題名をセット
        For Each cbo1Items In Task.arryTask
            cboKadai1.Items.Add(cbo1Items)
        Next

        'グループボックスを全て非表示にする
        grbInvisible()


        '課題1-3,1-6のリストボックスに値を設定しておく
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

        'グループボックスを全て非表示にする
        grbInvisible()

    End Sub

    'コンボボックス2変更時
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKadai2.SelectedIndexChanged

        'グループボックスを一度全て非表示にする
        grbInvisible()

        '適したグループボックスを表示する
        grbOpen(cboKadai1.SelectedIndex, cboKadai2.SelectedIndex)

    End Sub

    '出力ボタン押下時
    Private Sub btnOutput_Click(sender As Object, e As EventArgs) Handles btnOutput.Click

        '課題に対応したSQL文を取り出し、フォームコントロールに対応してSQLを組み立てる
        Dim str As String = Nothing
        Dim query1 As String = Nothing
        Dim query2 As String = Nothing
        Dim query3 As String = Nothing

        'エラーをキャッチしたら、Boolean判別にて処理を中断
        If queryCreate(cboKadai1.SelectedIndex, cboKadai2.SelectedIndex, str, query1, query2, query3) = False Then
            Exit Sub

        End If

        'データベースに接続してエクセル出力
        DataBase.outPut(str, query1, query2, query3)

    End Sub

    '終了ボタン押下時
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        'ミューテックスを解放してフォームを閉じる
        AppSys.systemExit()

    End Sub

    'フォーム終了時
    Private Sub formOutput_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        'データベースとの接続を切断
        DataBase.closing()

    End Sub


    '以下、呼び出し用のプロシージャ

    'グループボックスを全て非表示
    Private Sub grbInvisible()

        grbKadai1_1.Visible = False
        grbKadai1_2.Visible = False
        grbKadai1_3.Visible = False
        grbKadai1_4.Visible = False
        grbKadai1_5.Visible = False
        grbKadai1_6.Visible = False
        grbKadai1_7.Visible = False
        grbKadai2_1.Visible = False

    End Sub


    '適したグループボックスを表示
    Public Shared Sub grbOpen(cbo1 As Integer, cbo2 As Integer)

        'コンボボックス1, コンボボックス2の値で、個別に割り振られた値を取得
        '(TaskクラスのcboSelectedを呼び出す)
        'それぞれの回答文ごとに返す値は以下の通り
        '回答文　課題1-1 = 0
        '回答文　課題1-2 = 1
        '回答文　課題1-3 = 2
        '回答文　課題1-4 = 3
        '回答文　課題1-5 = 4
        '回答文　課題1-6 = 5
        '回答文　課題1-7 = 6
        '回答文　課題2-1 = 10
        '回答文　課題PL/SQL-1 = 20
        Dim grbNum As Integer = Task.cboSelected(cbo1, cbo2)

        'コンボボックスの選択された値によって、返す値を条件分岐する
        Dim strGrb As String = Nothing

        Select Case grbNum
                '回答文　課題1
            Case 0
                strGrb = "grbKadai1_1"
            Case 1
                strGrb = "grbKadai1_2"
            Case 2
                strGrb = "grbKadai1_3"
            Case 3
                strGrb = "grbKadai1_4"
            Case 4
                strGrb = "grbKadai1_5"
            Case 5
                strGrb = "grbKadai1_6"
            Case 6
                strGrb = "grbKadai1_7"
                '回答文　課題2
            Case 10
                strGrb = "grbKadai2_1"

        End Select

        'コンボボックス1の値が空で無ければ、グループボックスを表示する
        If strGrb <> "" Then

            Dim searchGrb As Control() = formOutput.Controls.Find(strGrb, True)
            If searchGrb.Length > 0 Then
                CType(searchGrb(0), GroupBox).Visible = True

                CType(searchGrb(0), GroupBox).Location = New Point(40, 170)
            End If

        End If

    End Sub

    '！！！！！SQL実行文はまだ未完成です。Parameters.Addが正常作動していない状態です。！！！！！

    'SQL文
    Public Shared Function queryCreate(cbo1 As String, cbo2 As String, ByRef ansStr As String, ByRef ansQuery1 As String, ByRef ansQuery2 As String, ByRef ansQuery3 As String) As Boolean

        queryCreate = False
        Dim oraComm As String = Nothing

        'コンボボックス1,2の値で返した数値によって条件分岐
        Select Case Task.cboSelected(cbo1, cbo2)

            '回答文　課題1-1
            Case 0

                '例外処理：売上に、数値以外を入力した場合
                Dim i As Integer
                If Not Integer.TryParse(formOutput.txtUriage1_1.Text, i) Then
                    MessageBox.Show("数値を入力してください", "帳票出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                '例外処理：順序が選択されていない場合
                If formOutput.rbtJunjoAsc1_1.Checked = False And formOutput.rbtJunjoDesc1_1.Checked = False Then
                    MessageBox.Show("昇順又は降順を選択してください", "帳票出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                '処理内容
                Dim strOrder As String
                If formOutput.rbtJunjoAsc1_1.Checked = True Then
                    strOrder = "ASC"
                Else
                    strOrder = "DESC"
                End If

                oraComm &= "SELECT DISTINCT 顧客マスタ.顧客番号,顧客マスタ.氏名" & vbLf
                oraComm &= "FROM 顧客マスタ" & vbLf
                oraComm &= "INNER JOIN 売場トラン" & vbLf
                oraComm &= "ON 顧客マスタ.顧客番号 = 売場トラン.顧客番号" & vbLf
                oraComm &= "WHERE 売場トラン.売上金額>= :ANS1" & vbLf
                oraComm &= "ORDER BY 顧客マスタ.顧客番号 :ANS2"

                ansQuery1 = formOutput.txtUriage1_1.Text
                ansQuery2 = strOrder
                ansQuery3 = ""

            '回答文　課題1-2
            Case 1

                '例外処理：性別がいずれも選択されていない場合
                If formOutput.rbtSexM1_2.Checked = False And formOutput.rbtSexF1_2.Checked = False And formOutput.rbtSexMF1_2.Checked = False Then
                    MessageBox.Show("性別を選択してください", "帳票出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                '処理内容
                Dim strGender As String
                If formOutput.rbtSexM1_2.Checked = True Then
                    strGender = "'男'"
                ElseIf formOutput.rbtSexF1_2.Checked = True Then
                    strGender = "'女'"
                Else
                    strGender = "'男','女'"
                End If

                oraComm &= "SELECT 顧客マスタ.性別,SUM(売場トラン.売上金額)AS 売上金額合計" & vbLf
                oraComm &= "FROM 売場トラン" & vbLf
                oraComm &= "INNER JOIN 顧客マスタ" & vbLf
                oraComm &= "ON 顧客マスタ.顧客番号 = 売場トラン.顧客番号" & vbLf
                oraComm &= "GROUP BY 顧客マスタ.性別" & vbLf
                oraComm &= "HAVING 顧客マスタ.性別 IN ( :ANS1 )"

                ansQuery1 = strGender
                ansQuery2 = ""
                ansQuery3 = ""

            '回答文　課題1-3
            Case 2

                '処理内容
                Dim strArea As String
                strArea = formOutput.ltbSalseFloor1_3.SelectedItem

                oraComm &= "SELECT 顧客マスタ.氏名" & vbLf
                oraComm &= "FROM 顧客マスタ" & vbLf
                oraComm &= "INNER JOIN 売場トラン" & vbLf
                oraComm &= "ON 顧客マスタ.顧客番号 = 売場トラン.顧客番号" & vbLf
                oraComm &= "WHERE 売場トラン.売場 = '" & strArea & "'" & vbLf
                oraComm &= "GROUP BY 顧客マスタ.氏名"


            '回答文　課題1-4
            Case 3

                '例外処理：順序が選択されていない場合
                If formOutput.rbtJunjoAsc1_4.Checked = False And formOutput.rbtJunjoDesc1_4.Checked = False Then
                    MessageBox.Show("昇順又は降順を選択してください", "帳票出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                '処理内容
                Dim intDay As Integer
                intDay = CInt(formOutput.dtpBirthday1_4.Value.ToString("yyyyMMdd"))

                Dim strOrder As String
                If formOutput.rbtJunjoAsc1_1.Checked = True Then
                    strOrder = "ASC"
                Else
                    strOrder = "DESC"
                End If

                oraComm &= "SELECT 氏名,TRUNC((" & intDay & " - TO_CHAR(生年月日, 'YYYYMMDD')) /10000, 0) AS 年齢" & vbLf
                oraComm &= "FROM 顧客マスタ" & vbLf
                oraComm &= "ORDER BY 顧客番号 " & strOrder


            '回答文　課題1-5
            Case 4

                '例外処理：Noに、数値以外を入力した場合
                Dim i As Integer
                If Integer.TryParse(formOutput.txtNumberFrom1_5.Text, i) = False Or Integer.TryParse(formOutput.txtNumberTo1_5.Text, i) = False Then
                    MessageBox.Show("数値を入力してください", "帳票出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                '例外処理：Noに、数値以外を入力した場合
                Dim minNum As Integer = 10000
                Dim maxNum As Integer = 99999
                If CInt(formOutput.txtNumberFrom1_5.Text) < minNum Or CInt(formOutput.txtNumberFrom1_5.Text) > maxNum Then
                    MessageBox.Show("数値は" & minNum & "から" & maxNum & "の間で指定してください", "帳票出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                If CInt(formOutput.txtNumberTo1_5.Text) < minNum Or CInt(formOutput.txtNumberTo1_5.Text) > maxNum Then
                    MessageBox.Show("数値は" & minNum & "から" & maxNum & "の間で指定してください", "帳票出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                '処理内容
                Dim intMin, intMax As Integer
                intMin = formOutput.txtNumberFrom1_5.Text
                intMax = formOutput.txtNumberTo1_5.Text

                oraComm &= "SELECT 氏名,連絡先１ AS 連絡先" & vbLf
                oraComm &= "FROM 顧客マスタ" & vbLf
                oraComm &= "WHERE 顧客番号" & vbLf
                oraComm &= "BETWEEN '" & intMin & "' AND '" & intMax & "'" & vbLf
                oraComm &= "UNION SELECT 氏名,連絡先２ AS 連絡先" & vbLf
                oraComm &= "FROM 顧客マスタ" & vbLf
                oraComm &= "WHERE 顧客番号" & vbLf
                oraComm &= "BETWEEN '" & intMin & "' AND '" & intMax & "'"


            '回答文　課題1-6
            Case 5

                '処理内容
                Dim strArea As String
                strArea = formOutput.ltbSalesFloor1_6.SelectedItem

                oraComm &= "SELECT 顧客マスタ.氏名,COUNT(売場トラン.売場) AS 回数" & vbLf
                oraComm &= "FROM 顧客マスタ" & vbLf
                oraComm &= "LEFT JOIN 売場トラン" & vbLf
                oraComm &= "ON 顧客マスタ.顧客番号 = 売場トラン.顧客番号" & vbLf
                oraComm &= "AND 売場トラン.売場 IN('" & strArea & "')" & vbLf
                oraComm &= "GROUP BY 顧客マスタ.氏名"


            '回答文　課題1-7
            Case 6

                '処理内容
                Dim strName As String
                strName = formOutput.txtSearch1_7.Text

                oraComm &= "SELECT 顧客マスタ.氏名,COUNT(売場トラン.売場) AS 回数" & vbLf
                oraComm &= "FROM 顧客マスタ" & vbLf
                oraComm &= "LEFT JOIN 売場トラン" & vbLf
                oraComm &= "ON 顧客マスタ.顧客番号 = 売場トラン.顧客番号" & vbLf
                oraComm &= "AND 売場トラン.売場 IN('レストラン')" & vbLf
                oraComm &= "WHERE 顧客マスタ.氏名 LIKE '%" & strName & "%'" & vbLf
                oraComm &= "GROUP BY 顧客マスタ.氏名"


            '回答文　課題2-1
            Case 10

                '例外処理：Noに、数値以外を入力した場合
                Dim i As Integer
                If Integer.TryParse(formOutput.txtNumberFrom2_1.Text, i) = False Or Integer.TryParse(formOutput.txtNumberTo2_1.Text, i) = False Then
                    MessageBox.Show("数値を入力してください", "帳票出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                '例外処理：Noに、数値以外を入力した場合
                Dim minNum As Integer = 10000
                Dim maxNum As Integer = 99999
                If CInt(formOutput.txtNumberFrom2_1.Text) < minNum Or CInt(formOutput.txtNumberFrom2_1.Text) > maxNum Then
                    MessageBox.Show("数値は" & minNum & "から" & maxNum & "の間で指定してください", "帳票出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                If CInt(formOutput.txtNumberTo2_1.Text) < minNum Or CInt(formOutput.txtNumberTo2_1.Text) > maxNum Then
                    MessageBox.Show("数値は" & minNum & "から" & maxNum & "の間で指定してください", "帳票出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                '処理内容
                Dim intMin, intMax As Integer
                intMin = formOutput.txtNumberFrom2_1.Text
                intMax = formOutput.txtNumberTo2_1.Text

                oraComm &= "SELECT ログイン情報.顧客番号,ログイン情報.LOGIN_ID,顧客マスタ.氏名" & vbLf
                oraComm &= "FROM 顧客マスタ" & vbLf
                oraComm &= "LEFT JOIN ログイン情報" & vbLf
                oraComm &= "ON 顧客マスタ.顧客番号 = ログイン情報.顧客番号" & vbLf
                oraComm &= "WHERE ログイン情報.顧客番号" & vbLf
                oraComm &= "BETWEEN '" & intMin & "' AND '" & intMax & "'"


            '回答文　課題PLSQL
            Case 20

                'ストアドプロシージャ実行
                DataBase.doStored("RPG002")

                '処理内容を、セレクト文で値を取得
                oraComm &= "SELECT *" & vbLf
                oraComm &= "FROM TRN_URIAGE"

        End Select

        ansStr = oraComm
        Return True

    End Function


End Class
