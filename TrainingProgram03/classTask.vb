Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing
Imports System.Reflection
Imports System.Text
Imports Microsoft.Office.Interop.Excel

Public Class Task

    '配列：課題シート名
    Public Shared arryTask() As String = {"課題1", "課題2", "課題PL/SQL"}

    '配列：課題シート名
    Shared arrySubTask() As String = {"問題1", "問題2", "問題3", "問題4", "問題5", "問題6", "問題7"}


    'コンボボックス1に入れる値を配列で格納
    Public Shared Sub cbo1SelectItem()

        For Each cbo1Items In arryTask
            formOutput.cboKadai1.Items.Add(cbo1Items)
        Next

    End Sub

    'コンボボックス2に入れる値を配列で格納(コンボボックス1の値で条件分岐する条件式)
    Public Shared Function cbo2SetItems(cbo1 As String)

        Dim cbo2 As String() = Nothing

        Select Case cbo1

            Case arryTask(0)
                cbo2 = arrySubTask

            Case arryTask(1)
                cbo2 = arrySubTask.Take(1).ToArray

            Case arryTask(2)
                cbo2 = arrySubTask.Take(1).ToArray

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

End Class







