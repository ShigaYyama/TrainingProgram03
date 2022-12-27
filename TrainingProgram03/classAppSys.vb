Public Class AppSys

    '2重起動確認
    Public Shared Sub duplicateCheck()

        'ミューテックスインスタンス生成
        Dim AppMutex As New System.Threading.Mutex(False, Application.ProductName)

        '処理内容
        If AppMutex.WaitOne(0, False) Then
            MessageBox.Show("2重起動確認完了。問題ありません。")
        Else
            MessageBox.Show("既にアプリケーションが起動しています。", "アプリケーション2重起動", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End If

        'ガベージコレクションの対象から除外
        GC.KeepAlive(AppMutex)

        'ミューテックスオブジェクトを破棄
        AppMutex.Close()

    End Sub

End Class
