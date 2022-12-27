Public Class Groups

    'グループボックスを全て非表示
    Public Shared Sub grbInvisible()

        With formOutput

            .grbKadai1_1.Visible = False
            .grbKadai1_2.Visible = False
            .grbKadai1_3.Visible = False
            .grbKadai1_4.Visible = False
            .grbKadai1_5.Visible = False
            .grbKadai1_6.Visible = False
            .grbKadai1_7.Visible = False
            .grbKadai2_1.Visible = False

        End With

    End Sub

    '課題1-3,1-6のリストボックスに値を設定
    Public Shared Sub itemsAdd3_6()

        Dim addArray As String() = {"食品", "紳士服", "婦人服", "レストラン", "化粧品"}

        With formOutput

            .ltbSalseFloor1_3.Items.AddRange(addArray)
            .ltbSalesFloor1_6.Items.AddRange(addArray)

        End With

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

        'コンボボックス1の値がPL/SQLで無ければ、グループボックスを表示する
        If formOutput.cboKadai1.Text <> Task.arryTask(2) Then

            Dim searchGrb As Control() = formOutput.Controls.Find(strGrb, True)
            If searchGrb.Length > 0 Then
                CType(searchGrb(0), GroupBox).Visible = True
            End If

            CType(searchGrb(0), GroupBox).Location = New Point(40, 170)

        End If

    End Sub

End Class
