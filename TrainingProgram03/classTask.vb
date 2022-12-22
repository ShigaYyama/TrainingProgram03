Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing
Imports System.Reflection
Imports System.Text
Imports Oracle.ManagedDataAccess.Client
Imports OracleInternal.Json

Public Class classTask

    '配列：課題シート名
    Shared ArryTask() As String = {"課題1", "課題2", "課題PL/SQL"}

    '配列：課題シート名
    Shared ArrySubTask1() As String = {"問題1", "問題2", "問題3", "問題4", "問題5", "問題6", "問題7"}
    Shared ArrySubTask2() As String = {"問題1"}
    Shared ArrySubTask3() As String = {"問題1"}


    'コンボボックス1に入れる値を配列で格納
    Public Shared Function Cbo1SetItems() As String()

        Return ArryTask

    End Function

    'コンボボックス2に入れる値を配列で格納(コンボボックス1の値で条件分岐する条件式)
    Public Shared Function Cbo2SetItems(cbo1 As String) As String()

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


    'SQL文を返すための準備(大村さん修正)
    Public Shared Function CboSelected(cbo1Index As Integer, cbo2Index As Integer) As Integer

        ' 選択されていない場合は-1を返す
        If cbo1Index < 0 Or cbo2Index < 0 Then
            Return -1
        End If

        Return cbo1Index * 10 + cbo2Index

    End Function



    Public Shared Function SelectSql(Subject As Integer) As String

        'コンボボックスの選択された値によって、Functionで返す値を条件分岐する
        Dim ExcSelect As String = Nothing

        Select Case Subject
                '回答文　課題①
            Case 0
                ExcSelect = Query1_1()
            Case 1
                ExcSelect = Query1_2()
            Case 2
                ExcSelect = Query1_3()
            Case 3
                ExcSelect = Query1_4()
            Case 4
                ExcSelect = Query1_5()
            Case 5
                ExcSelect = Query1_6()
            Case 6
                ExcSelect = Query1_7()
                '回答文　課題②
            Case 10
                ExcSelect = Query2_1()
            Case 11
                ExcSelect = Query2_2()
            Case 12
                ExcSelect = Query2_3()
            Case 13
                ExcSelect = Query2_4()
            Case 14
                ExcSelect = Query2_5()
                '回答文　課題③
            Case 20
                ExcSelect = Query3_1()
            Case 21
                ExcSelect = Query3_2()
                '回答文　課題④
            Case 30
                ExcSelect = Query4_1()
            Case 31
                ExcSelect = Query4_2()
            Case 32
                ExcSelect = Query4_3()
            Case 33
                ExcSelect = Query4_4()
            Case 34
                ExcSelect = Query4_5()
            Case 35
                ExcSelect = Query4_6()
            Case 36
                ExcSelect = Query4_7()
            Case 37
                ExcSelect = Query4_8()
            Case 38
                ExcSelect = Query4_9()
                '回答文　課題⑤
            Case 40
                ExcSelect = Query5_1()
                '回答文　課題⑥
            Case 50
                ExcSelect = Query6_1()

        End Select

        Return ExcSelect

    End Function


    '回答文　課題①
    Public Shared Function Query1_1() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT DISTINCT 顧客マスタ.顧客番号,顧客マスタ.氏名" & vbLf
        QueryComm &= "FROM 顧客マスタ" & vbLf
        QueryComm &= "INNER JOIN 売場トラン" & vbLf
        QueryComm &= "ON 顧客マスタ.顧客番号 = 売場トラン.顧客番号" & vbLf
        QueryComm &= "WHERE 売場トラン.売上金額>= 10000" & vbLf
        QueryComm &= "ORDER BY 顧客マスタ.顧客番号 ASC"

        Query1_1 = QueryComm

    End Function
    Public Shared Function Query1_2() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT 顧客マスタ.性別,SUM(売場トラン.売上金額)AS 売上金額合計" & vbLf
        QueryComm &= "FROM 売場トラン" & vbLf
        QueryComm &= "INNER JOIN 顧客マスタ" & vbLf
        QueryComm &= "ON 顧客マスタ.顧客番号 = 売場トラン.顧客番号" & vbLf
        QueryComm &= "GROUP BY 顧客マスタ.性別"

        Query1_2 = QueryComm

    End Function
    Public Shared Function Query1_3() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT 顧客マスタ.氏名" & vbLf
        QueryComm &= "FROM 顧客マスタ" & vbLf
        QueryComm &= "INNER JOIN 売場トラン" & vbLf
        QueryComm &= "ON 顧客マスタ.顧客番号 = 売場トラン.顧客番号" & vbLf
        QueryComm &= "WHERE 売場トラン.売場 = '食品'" & vbLf
        QueryComm &= "GROUP BY 顧客マスタ.氏名'"

        Query1_3 = QueryComm

    End Function
    Public Shared Function Query1_4() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT 氏名,TRUNC((20220506 - TO_CHAR(生年月日, 'YYYYMMDD')) /10000, 0) AS 年齢" & vbLf
        QueryComm &= "FROM 顧客マスタ" & vbLf
        QueryComm &= "ORDER BY 顧客番号 ASC"

        Query1_4 = QueryComm

    End Function

    Public Shared Function Query1_5() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT 氏名,連絡先１ AS 連絡先" & vbLf
        QueryComm &= "FROM 顧客マスタ" & vbLf
        QueryComm &= "UNION SELECT 氏名,連絡先２ AS 連絡先" & vbLf
        QueryComm &= "FROM 顧客マスタ"

        Query1_5 = QueryComm

    End Function

    Public Shared Function Query1_6() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT 顧客マスタ.氏名,COUNT(売場トラン.売場) AS 回数" & vbLf
        QueryComm &= "FROM 顧客マスタ" & vbLf
        QueryComm &= "LEFT JOIN 売場トラン" & vbLf
        QueryComm &= "ON 顧客マスタ.顧客番号 = 売場トラン.顧客番号" & vbLf
        QueryComm &= "AND 売場トラン.売場 IN('レストラン')" & vbLf
        QueryComm &= "GROUP BY 顧客マスタ.氏名"

        Query1_6 = QueryComm

    End Function
    Public Shared Function Query1_7() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT 顧客マスタ.氏名,COUNT(売場トラン.売場) AS 回数" & vbLf
        QueryComm &= "FROM 顧客マスタ" & vbLf
        QueryComm &= "LEFT JOIN 売場トラン" & vbLf
        QueryComm &= "ON 顧客マスタ.顧客番号 = 売場トラン.顧客番号" & vbLf
        QueryComm &= "AND 売場トラン.売場 IN('レストラン')" & vbLf
        QueryComm &= "WHERE 顧客マスタ.氏名 LIKE '%山%'" & vbLf
        QueryComm &= "GROUP BY 顧客マスタ.氏名"

        Query1_7 = QueryComm

    End Function

    '回答文　課題②
    Public Shared Function Query2_1() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT  s_no," & vbLf
        QueryComm &= "CASE WHEN s_name THEN NULL WHEN '未入力' THEN s_name END" & vbLf
        QueryComm &= "FROM ex_tbl"

        Query2_1 = QueryComm

    End Function

    Public Shared Function Query2_2() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT  s_no," & vbLf
        QueryComm &= "CURRENT_DATE()" & vbLf
        QueryComm &= "FROM ex_tbl"

        Query2_2 = QueryComm

    End Function

    Public Shared Function Query2_3() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT *" & vbLf
        QueryComm &= "FROM 売場トラン"

        Query2_3 = QueryComm

    End Function

    Public Shared Function Query2_4() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT *" & vbLf
        QueryComm &= "FROM 売場トラン"

        Query2_4 = QueryComm

    End Function

    Public Shared Function Query2_5() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT *" & vbLf
        QueryComm &= "FROM 売場トラン"

        Query2_5 = QueryComm

    End Function

    '回答文　課題③
    Public Shared Function Query3_1() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT ログイン情報.顧客番号,ログイン情報.LOGIN_ID,顧客マスタ.氏名" & vbLf
        QueryComm &= "FROM 顧客マスタ" & vbLf
        QueryComm &= "LEFT JOIN ログイン情報" & vbLf
        QueryComm &= "ON 顧客マスタ.顧客番号 = ログイン情報.顧客番号" & vbLf
        QueryComm &= "WHERE ログイン情報.顧客番号" & vbLf
        QueryComm &= "IN ('10001','10004')"

        Query3_1 = QueryComm

    End Function
    Public Shared Function Query3_2() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT ログイン情報.顧客番号,ログイン情報.LOGIN_ID,顧客マスタ.氏名" & vbLf
        QueryComm &= "FROM 顧客マスタ" & vbLf
        QueryComm &= "INNER JOIN ログイン情報" & vbLf
        QueryComm &= "ON 顧客マスタ.顧客番号 = ログイン情報.顧客番号" & vbLf
        QueryComm &= "WHERE EXISTS( SELECT 顧客番号,LOGIN_ID" & vbLf
        QueryComm &= "FROM ログイン情報" & vbLf
        QueryComm &= "WHERE 顧客番号" & vbLf
        QueryComm &= "IN ('10001','10004'))"

        Query3_2 = QueryComm

    End Function

    '回答文　課題④
    Public Shared Function Query4_1() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT *" & vbLf
        QueryComm &= "FROM アイテムトラン" & vbLf
        QueryComm &= "INNER JOIN 売場マスタ" & vbLf
        QueryComm &= "ON アイテムトラン.売場番号 = 売場マスタ.売場番号"

        Query4_1 = QueryComm

    End Function

    Public Shared Function Query4_2() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT *" & vbLf
        QueryComm &= "FROM アイテムトラン" & vbLf
        QueryComm &= "INNER JOIN アイテムマスタ" & vbLf
        QueryComm &= "ON アイテムトラン.種類番号 = アイテムマスタ.種類番号"

        Query4_2 = QueryComm

    End Function

    Public Shared Function Query4_3() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "INSERT INTO アイテムマスタ" & vbLf
        QueryComm &= "SELECT アイテムトラン.種類番号,'ハム',アイテムマスタ.在庫状態,アイテムマスタ.区分１,アイテムマスタ.区分２" & vbLf
        QueryComm &= "FROM アイテムトラン" & vbLf
        QueryComm &= "INNER JOIN アイテムマスタ" & vbLf
        QueryComm &= "ON アイテムトラン.種類番号 = アイテムマスタ.種類番号" & vbLf
        QueryComm &= "WHERE アイテムトラン.種類番号" & vbLf
        QueryComm &= "IN 2"

        Query4_3 = QueryComm

    End Function

    Public Shared Function Query4_4() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT *" & vbLf
        QueryComm &= "FROM アイテムトラン" & vbLf
        QueryComm &= "INNER JOIN アイテムマスタ" & vbLf
        QueryComm &= "ON アイテムトラン.種類番号 = アイテムマスタ.種類番号" & vbLf
        QueryComm &= "INNER JOIN 売場マスタ" & vbLf
        QueryComm &= "ON アイテムトラン.売場番号 = 売場マスタ.売場番号" & vbLf
        QueryComm &= "WHERE アイテムマスタ.区分１" & vbLf
        QueryComm &= "IS NOT NULL"

        Query4_4 = QueryComm

    End Function

    Public Shared Function Query4_5() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT *" & vbLf
        QueryComm &= "FROM アイテムトラン" & vbLf
        QueryComm &= "LEFT JOIN 売場マスタ" & vbLf
        QueryComm &= "ON アイテムトラン.売場番号 = 売場マスタ.売場番号"

        Query4_5 = QueryComm

    End Function

    Public Shared Function Query4_6() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT *" & vbLf
        QueryComm &= "FROM アイテムトラン" & vbLf
        QueryComm &= "LEFT JOIN アイテムマスタ" & vbLf
        QueryComm &= "ON アイテムトラン.種類番号 = アイテムマスタ.種類番号"

        Query4_6 = QueryComm

    End Function

    Public Shared Function Query4_7() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "INSERT INTO アイテムマスタ" & vbLf
        QueryComm &= "SELECT アイテムトラン.種類番号,'ハム',アイテムマスタ.在庫状態,アイテムマスタ.区分１,アイテムマスタ.区分２" & vbLf
        QueryComm &= "FROM アイテムトラン" & vbLf
        QueryComm &= "LEFT JOIN アイテムマスタ" & vbLf
        QueryComm &= "ON アイテムトラン.種類番号 = アイテムマスタ.種類番号" & vbLf
        QueryComm &= "WHERE アイテムトラン.種類番号" & vbLf
        QueryComm &= "IN 2"

        Query4_7 = QueryComm

    End Function

    Public Shared Function Query4_8() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT *" & vbLf
        QueryComm &= "FROM アイテムトラン" & vbLf
        QueryComm &= "LEFT JOIN アイテムマスタ" & vbLf
        QueryComm &= "ON アイテムトラン.種類番号 = アイテムマスタ.種類番号" & vbLf
        QueryComm &= "LEFT JOIN 売場マスタ" & vbLf
        QueryComm &= "ON アイテムトラン.売場番号 = 売場マスタ.売場番号" & vbLf
        QueryComm &= "WHERE アイテムマスタ.区分１" & vbLf
        QueryComm &= "IS NOT NULL"

        Query4_8 = QueryComm

    End Function

    Public Shared Function Query4_9() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT アイテムトラン.種類番号," & vbLf
        QueryComm &= "CASE アイテムマスタ.在庫状態" & vbLf
        QueryComm &= "WHEN 'A' THEN '在庫あり'" & vbLf
        QueryComm &= "WHEN 'B' THEN '予約注文'" & vbLf
        QueryComm &= "WHEN 'C' THEN '在庫なし'" & vbLf
        QueryComm &= "ELSE '未定' END" & vbLf
        QueryComm &= "FROM アイテムトラン" & vbLf
        QueryComm &= "INNER JOIN アイテムマスタ" & vbLf
        QueryComm &= "ON アイテムトラン.種類番号 = アイテムマスタ.種類番号"

        Query4_9 = QueryComm

    End Function

    '回答文　課題⑤
    Public Shared Function Query5_1() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "CREATE TABLE USER_MASTER" & vbLf
        QueryComm &= "(" & vbLf
        QueryComm &= "USER_ID      VARCHAR2(8) NOT NULL PRIMARY KEY," & vbLf
        QueryComm &= "DEPT_NO      VARCHAR2(8)," & vbLf
        QueryComm &= "USER_NAME    VARCHAR2(32)," & vbLf
        QueryComm &= "CREATED_ON   DATE DEFAULT SYSDATE," & vbLf
        QueryComm &= "MODIFIED_ON  DATE" & vbLf
        QueryComm &= ")"

        Query5_1 = QueryComm

    End Function

    '回答文　課題⑥
    Public Shared Function Query6_1() As String

        Dim QueryComm As String = Nothing

        QueryComm &= "SELECT 階数," & vbLf
        QueryComm &= "LISTAGG(売場, ',') WITHIN GROUP (ORDER BY 連番) 売場リスト" & vbLf
        QueryComm &= "FROM 売場階数トラン" & vbLf
        QueryComm &= "GROUP BY 階数"

        Query6_1 = QueryComm

    End Function


End Class







