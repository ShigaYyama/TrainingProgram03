Imports System.Threading

Public Class formOutput


    'アプリケーション起動時
    Private Sub formOutput_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'アプリケーションの2重起動確認
        AppSys.duplicateCheck()

        'データベース接続確認
        DataBase.loading()

        'コンボボックス1に課題名をセット
        Task.cbo1SelectItem()

        'グループボックスを全て非表示にする
        Groups.grbInvisible()

        '課題1-3,1-6のリストボックスに値を設定しておく
        Groups.itemsAdd3_6()

    End Sub

    'コンボボックス1変更時
    Private Sub cboKadai1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKadai1.SelectedIndexChanged

        '選択されたコンボボックス（cboKadai1）のシートに内にある問題の一覧を、コンボボックス（cboKadai2）に設定
        Task.cbo2SetItems(cboKadai1.Text)

    End Sub

    'コンボボックス2変更時
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKadai2.SelectedIndexChanged

        'グループボックスを一度全て非表示にする
        Groups.grbInvisible()

        '適したグループボックスを表示する
        Groups.grbOpen(cboKadai1.SelectedIndex, cboKadai2.SelectedIndex)

    End Sub

    '出力ボタン押下時
    Private Sub btnOutput_Click(sender As Object, e As EventArgs) Handles btnOutput.Click

        '課題に対応したSQL文を取り出し、フォームコントロールに対応してSQLを組み立てる
        Dim str As String = Nothing
        Dim ansQuery As String
        'エラーをキャッチしたら、Boolean判別にて処理を中断
        If Task.queryCreate(cboKadai1.SelectedIndex, cboKadai2.SelectedIndex, str) = False Then
            Exit Sub
        Else
            ansQuery = str
        End If

        'データベースに接続してエクセル出力
        DataBase.outPut(ansQuery)

    End Sub

    '終了ボタン押下時
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        'アプリケーション終了
        Application.Exit()

    End Sub

    'フォーム終了時
    Private Sub formOutput_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        'データベースとの接続を切断
        DataBase.closing()

    End Sub
End Class
