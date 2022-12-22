﻿Public Class classApp

    '2重起動確認
    Public Shared Sub DuplicateCheck()

        'ミューテックスインスタンス生成
        Dim AppMutex As New System.Threading.Mutex(False, Application.ProductName)

        If AppMutex.WaitOne(0, False) Then

            MessageBox.Show("2重起動確認完了。問題ありません。")
        Else

            MessageBox.Show("既にアプリケーションが起動しています。")
            Application.Exit()
        End If

        'ガベージコレクションの対象から除外
        GC.KeepAlive(AppMutex)

        'ミューテックスオブジェクトを破棄
        AppMutex.Close()

    End Sub

End Class