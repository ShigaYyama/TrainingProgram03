Public Class Forms

    Public Shared Sub grbInvisible(groupBox As GroupBox)

        groupBox.Visible = False

    End Sub

    Public Shared Function grbOpen(subject) As String

        'コンボボックスの選択された値によって、Functionで返す値を条件分岐する
        Dim strGrb As String = Nothing

        Select Case subject
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

        Return strGrb

    End Function
End Class
