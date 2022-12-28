Public Class AppSys

    'ミューテックスインスタンス生成
    Shared AppMutex As New System.Threading.Mutex(False, Application.ProductName)


    '2重起動確認
    Public Shared Sub duplicateCheck()

        '処理内容
        If AppMutex.WaitOne(0, False) = True Then
            MessageBox.Show("2重起動確認完了。問題ありません。")
        Else
            MessageBox.Show("既にアプリケーションが起動しています。", "アプリケーション2重起動", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End If

    End Sub

    'アプリケーション終了終了時
    Public Shared Sub systemExit()

        'ガベージコレクションの対象から除外
        GC.KeepAlive(AppMutex)

        'ミューテックスオブジェクトを破棄
        AppMutex.Close()

        'アプリケーション終了
        Application.Exit()

    End Sub

End Class
