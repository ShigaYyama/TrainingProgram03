Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing
Imports System.Reflection
Imports System.Text

Public Class Task

    '配列：課題シート名
    Shared ArryTask() As String = {"課題1", "課題2", "課題PL/SQL"}

    '配列：課題シート名
    Shared ArrySubTask1() As String = {"問題1", "問題2", "問題3", "問題4", "問題5", "問題6", "問題7"}
    Shared ArrySubTask2() As String = {"問題1"}
    Shared ArrySubTask3() As String = {"問題1"}


    'コンボボックス1に入れる値を配列で格納
    Public Shared Function cbo1SetItems() As String()

        Return ArryTask

    End Function

    'コンボボックス2に入れる値を配列で格納(コンボボックス1の値で条件分岐する条件式)
    Public Shared Function cbo2SetItems(cbo1 As String) As String()

        Dim cbo2 As String() = Nothing

        Select Case cbo1

            Case ArryTask(0)
                cbo2 = ArrySubTask1

            Case ArryTask(1)
                cbo2 = ArrySubTask2

            Case ArryTask(2)
                cbo2 = ArrySubTask3

            Case Else

        End Select

        Return cbo2

    End Function


    'SQL文を返すための準備
    Public Shared Function cboSelected(cbo1Index As Integer, cbo2Index As Integer) As Integer

        ' 選択されていない場合は-1を返す
        If cbo1Index < 0 Or cbo2Index < 0 Then
            Return -1
        End If

        Return cbo1Index * 10 + cbo2Index

    End Function



    'Public Shared Function selectSql(Subject As Integer) As String

    '    'コンボボックスの選択された値によって、Functionで返す値を条件分岐する
    '    Dim ExcSelect As String = Nothing

    '    Select Case Subject
    '            '回答文　課題1
    '        Case 0
    '            ExcSelect = Query1_1()
    '        Case 1
    '            ExcSelect = Query1_2()
    '        Case 2
    '            ExcSelect = Query1_3()
    '        Case 3
    '            ExcSelect = Query1_4()
    '        Case 4
    '            ExcSelect = Query1_5()
    '        Case 5
    '            ExcSelect = Query1_6()
    '        Case 6
    '            ExcSelect = Query1_7()
    '            '回答文　課題2
    '        Case 10
    '            ExcSelect = Query2_1()
    '            '回答文　課題PL/SQL
    '        Case 20
    '            ExcSelect = Query3_1()

    '    End Select

    '    Return ExcSelect

    'End Function


    '回答文　課題1
    Public Shared Function Query1_1(earn As Integer, order As String) As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT DISTINCT 顧客マスタ.顧客番号,顧客マスタ.氏名" & vbLf
        QueryComm &= "FROM 顧客マスタ" & vbLf
        QueryComm &= "INNER JOIN 売場トラン" & vbLf
        QueryComm &= "ON 顧客マスタ.顧客番号 = 売場トラン.顧客番号" & vbLf
        QueryComm &= "WHERE 売場トラン.売上金額>= " & earn & vbLf
        QueryComm &= "ORDER BY 顧客マスタ.顧客番号 " & order

        Query1_1 = QueryComm

    End Function
    Public Shared Function Query1_2(gender As String) As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT 顧客マスタ.性別,SUM(売場トラン.売上金額)AS 売上金額合計" & vbLf
        QueryComm &= "FROM 売場トラン" & vbLf
        QueryComm &= "INNER JOIN 顧客マスタ" & vbLf
        QueryComm &= "ON 顧客マスタ.顧客番号 = 売場トラン.顧客番号" & vbLf
        QueryComm &= "GROUP BY 顧客マスタ.性別" & vbLf
        QueryComm &= "HAVING 顧客マスタ.性別 IN ( " & gender & " )"

        Query1_2 = QueryComm

    End Function
    Public Shared Function Query1_3(area As String) As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT 顧客マスタ.氏名" & vbLf
        QueryComm &= "FROM 顧客マスタ" & vbLf
        QueryComm &= "INNER JOIN 売場トラン" & vbLf
        QueryComm &= "ON 顧客マスタ.顧客番号 = 売場トラン.顧客番号" & vbLf
        QueryComm &= "WHERE 売場トラン.売場 = '" & area & "'" & vbLf
        QueryComm &= "GROUP BY 顧客マスタ.氏名"

        Query1_3 = QueryComm

    End Function
    Public Shared Function Query1_4(day As Integer, order As String) As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT 氏名,TRUNC((" & day & " - TO_CHAR(生年月日, 'YYYYMMDD')) /10000, 0) AS 年齢" & vbLf
        QueryComm &= "FROM 顧客マスタ" & vbLf
        QueryComm &= "ORDER BY 顧客番号 " & order

        Query1_4 = QueryComm

    End Function

    Public Shared Function Query1_5(minNum As Integer, maxNum As Integer) As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT 氏名,連絡先１ AS 連絡先" & vbLf
        QueryComm &= "FROM 顧客マスタ" & vbLf
        QueryComm &= "WHERE 顧客番号" & vbLf
        QueryComm &= "BETWEEN '" & minNum & "' AND '" & maxNum & "'" & vbLf
        QueryComm &= "UNION SELECT 氏名,連絡先２ AS 連絡先" & vbLf
        QueryComm &= "FROM 顧客マスタ" & vbLf
        QueryComm &= "WHERE 顧客番号" & vbLf
        QueryComm &= "BETWEEN '" & minNum & "' AND '" & maxNum & "'"

        Query1_5 = QueryComm

    End Function

    Public Shared Function Query1_6(area As String) As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT 顧客マスタ.氏名,COUNT(売場トラン.売場) AS 回数" & vbLf
        QueryComm &= "FROM 顧客マスタ" & vbLf
        QueryComm &= "LEFT JOIN 売場トラン" & vbLf
        QueryComm &= "ON 顧客マスタ.顧客番号 = 売場トラン.顧客番号" & vbLf
        QueryComm &= "AND 売場トラン.売場 IN('" & area & "')" & vbLf
        QueryComm &= "GROUP BY 顧客マスタ.氏名"

        Query1_6 = QueryComm

    End Function
    Public Shared Function Query1_7(name As String) As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT 顧客マスタ.氏名,COUNT(売場トラン.売場) AS 回数" & vbLf
        QueryComm &= "FROM 顧客マスタ" & vbLf
        QueryComm &= "LEFT JOIN 売場トラン" & vbLf
        QueryComm &= "ON 顧客マスタ.顧客番号 = 売場トラン.顧客番号" & vbLf
        QueryComm &= "AND 売場トラン.売場 IN('レストラン')" & vbLf
        QueryComm &= "WHERE 顧客マスタ.氏名 LIKE '%" & name & "%'" & vbLf
        QueryComm &= "GROUP BY 顧客マスタ.氏名"

        Query1_7 = QueryComm

    End Function


    '回答文　課題2
    Public Shared Function Query2_1(minNum As Integer, maxNum As Integer) As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT ログイン情報.顧客番号,ログイン情報.LOGIN_ID,顧客マスタ.氏名" & vbLf
        QueryComm &= "FROM 顧客マスタ" & vbLf
        QueryComm &= "LEFT JOIN ログイン情報" & vbLf
        QueryComm &= "ON 顧客マスタ.顧客番号 = ログイン情報.顧客番号" & vbLf
        QueryComm &= "WHERE ログイン情報.顧客番号" & vbLf
        QueryComm &= "BETWEEN '" & minNum & "' AND '" & maxNum & "'"

        Query2_1 = QueryComm

    End Function

End Class







