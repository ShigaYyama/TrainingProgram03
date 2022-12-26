Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing
Imports System.Reflection
Imports System.Text
Imports Microsoft.Office.Interop.Excel

Public Class Task

    '配列：課題シート名
    Public Shared ArryTask() As String = {"課題1", "課題2", "課題PL/SQL"}

    '配列：課題シート名
    Shared ArrySubTask1() As String = {"問題1", "問題2", "問題3", "問題4", "問題5", "問題6", "問題7"}


    'コンボボックス2に入れる値を配列で格納(コンボボックス1の値で条件分岐する条件式)
    Public Shared Function cbo2SetItems(cbo1 As String) As String()

        Dim cbo2 As String() = Nothing

        Select Case cbo1

            Case ArryTask(0)
                cbo2 = ArrySubTask1

            Case ArryTask(1)
                cbo2 = ArrySubTask1.Take(1).ToArray

            Case ArryTask(2)
                cbo2 = ArrySubTask1.Take(1).ToArray

            Case Else

        End Select

        Return cbo2

    End Function

    'SQL文を返すための値設定
    Public Shared Function cboSelected(cbo1Index As Integer, cbo2Index As Integer) As Integer

        ' 選択されていない場合は-1を返す
        If cbo1Index < 0 Or cbo2Index < 0 Then
            Return -1
        End If

        Return cbo1Index * 10 + cbo2Index

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

    End Function

    'SQL文
    Public Shared Function queryCreate(cbo1 As String, cbo2 As String) As String

        ', ByRef ansStr As String, ByRef ansBool As Boolean

        queryCreate = Nothing
        Dim oraComm As String = Nothing

        'コンボボックス1,2の値で返した数値によって条件分岐
        Select Case Task.cboSelected(cbo1, cbo2)

            '回答文　課題1-1
            Case 0

                '例外処理：売上に、数値以外を入力した場合
                Dim i As Integer
                If Not Integer.TryParse(formOutput.txtUriage1_1.Text, i) Then
                    MessageBox.Show("数値を入力してください", "帳票出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Function
                End If

                '例外処理：順序が選択されていない場合
                If formOutput.rbtJunjoAsc1_1.Checked = False And formOutput.rbtJunjoDesc1_1.Checked = False Then
                    MessageBox.Show("昇順又は降順を選択してください", "帳票出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Function
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
                oraComm &= "WHERE 売場トラン.売上金額>= " & formOutput.txtUriage1_1.Text & vbLf
                oraComm &= "ORDER BY 顧客マスタ.顧客番号 " & strOrder


            '回答文　課題1-2
            Case 1

                '例外処理：性別がいずれも選択されていない場合
                If formOutput.rbtSexM1_2.Checked = False And formOutput.rbtSexF1_2.Checked = False And formOutput.rbtSexMF1_2.Checked = False Then
                    MessageBox.Show("性別を選択してください", "帳票出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Function
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
                oraComm &= "HAVING 顧客マスタ.性別 IN ( " & strGender & " )"


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
                    Exit Function
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
                    Exit Function
                End If

                '例外処理：Noに、数値以外を入力した場合
                Dim minNum As Integer = 10000
                Dim maxNum As Integer = 99999
                If CInt(formOutput.txtNumberFrom1_5.Text) < minNum Or CInt(formOutput.txtNumberFrom1_5.Text) > maxNum Then
                    MessageBox.Show("数値は" & minNum & "から" & maxNum & "の間で指定してください", "帳票出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Function
                End If

                If CInt(formOutput.txtNumberTo1_5.Text) < minNum Or CInt(formOutput.txtNumberTo1_5.Text) > maxNum Then
                    MessageBox.Show("数値は" & minNum & "から" & maxNum & "の間で指定してください", "帳票出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Function
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
                    Exit Function
                End If

                '例外処理：Noに、数値以外を入力した場合
                Dim minNum As Integer = 10000
                Dim maxNum As Integer = 99999
                If CInt(formOutput.txtNumberFrom2_1.Text) < minNum Or CInt(formOutput.txtNumberFrom2_1.Text) > maxNum Then
                    MessageBox.Show("数値は" & minNum & "から" & maxNum & "の間で指定してください", "帳票出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Function
                End If

                If CInt(formOutput.txtNumberTo2_1.Text) < minNum Or CInt(formOutput.txtNumberTo2_1.Text) > maxNum Then
                    MessageBox.Show("数値は" & minNum & "から" & maxNum & "の間で指定してください", "帳票出力", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Function
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

                oraComm = "RPG002"


        End Select

        Return oraComm

    End Function

End Class







