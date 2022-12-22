Public Class formOutput


    Private Sub formOutput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grbKadai1_1.Visible = False

        classApp.DuplicateCheck()

        classTask.Cbo1SetItems()

    End Sub

    Private Sub btnOutput_Click(sender As Object, e As EventArgs) Handles btnOutput.Click
        classForms.gbInvisible(grbKadai1_1)
        grbKadai1_1.Visible = True
        grbKadai1_1.Location = New Point(40, 170)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

End Class
