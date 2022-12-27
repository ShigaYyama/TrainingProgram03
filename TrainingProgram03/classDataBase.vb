Imports System.Threading
Imports Microsoft.Office.Interop
Imports Oracle.ManagedDataAccess.Client

Public Class DataBase

    '接続先情報
    Public Shared strConnect As String = "Data Source=localhost/orclpdb; User ID=TEST_USER; Password=TEST_USER_PASS;"

    'データベースの起動→接続を確立
    Public Shared Sub loading()

        'データベース接続に接続出来たら確認メッセージを表示
        Try

            Using conn As New OracleConnection(strConnect)

                conn.Open()
                MessageBox.Show("データベースとの接続が確認出来ました。" & vbLf & "処理を続行します。")
                conn.Close()

            End Using

            '接続が確認出来ない場合はアプリケーションを閉じる
        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Application.Exit()

        End Try

    End Sub


    'SQLの結果をエクセル出力
    Public Shared Sub outPut(oraObje As String)

        'データベースに接続(Oracle)
        Using conn As New OracleConnection(strConnect)
            conn.Open()

            'SQL文を実行
            Using oraComm As OracleCommand = New OracleCommand(oraObje, conn)

                'PL/SQL課題の場合はプロシージャを実行
                If oraObje = Task.ansStored Then

                    'ストアドプロシージャを実行
                    oraComm.CommandType = CommandType.StoredProcedure
                    oraComm.CommandText = oraObje

                    oraComm.ExecuteNonQuery()

                    'ストアドプロシージャ実行後、コマンドタイプを通常に戻す
                    oraComm.CommandType = CommandType.Text

                    'TRN_URIAGEテーブル全体をセレクトする
                    Dim trnSql As String
                    trnSql = "SELECT *" & vbLf
                    trnSql &= "FROM TRN_URIAGE"

                    oraComm.CommandText = trnSql

                End If

                Using oraAdap As New OracleDataAdapter(oraComm)

                    'Oracleをエクセル出力用に読み込む
                    Using oraRead As OracleDataReader = oraComm.ExecuteReader()

                        Dim dSet As DataSet = New DataSet()
                        Dim dTable As DataTable

                        'SQL出力結果をデータテーブルに出力
                        oraAdap.Fill(dSet, "ExportDataTable")
                        dTable = dSet.Tables("ExportDataTable")

                        'エクセル用の変数設定
                        Dim excelApp As New Excel.Application()
                        Dim excelBooksOpen As Excel.Workbooks = excelApp.Workbooks
                        Dim excelBook As Excel.Workbook = excelBooksOpen.Add()
                        Dim oraSheet As Excel.Worksheet = CType(excelApp.Worksheets("sheet1"), Excel.Worksheet)

                        Try

                            '保存用のダイアログ表示
                            Using dialog As New SaveFileDialog()

                                Dim ret As DialogResult
                                dialog.Title = "出力データの保存先を選択"
                                dialog.Filter = "EXCELファイル|*.xlsx"
                                ret = dialog.ShowDialog()

                                If ret = DialogResult.OK Then

                                    Dim filePath As String = dialog.FileName

                                    '出力先のエクセルのセル番号 = データテーブルの座標にセット
                                    'Forで行と列を繰り返して値を取得
                                    For x As Integer = 0 To dTable.Columns.Count - 1
                                        oraSheet.Cells(1, 1 + x) = dTable.Columns(x).ColumnName
                                    Next

                                    For x As Integer = 0 To dTable.Rows.Count - 1
                                        For y As Integer = 0 To dTable.Columns.Count - 1
                                            oraSheet.Cells(2 + x, 1 + y) = dTable.Rows(x).Item(y).ToString
                                        Next
                                    Next

                                    excelBook.SaveAs(FilePath)

                                Else
                                    MessageBox.Show("処理がキャンセルされました。")
                                    Exit Sub

                                End If
                                MessageBox.Show("書き込みが完了しました。")

                            End Using

                        Catch ex As Exception
                            MessageBox.Show(ex.Message)

                        Finally
                            ExcelApp.Quit()
                            Call System.Runtime.InteropServices.Marshal.ReleaseComObject(OraSheet)
                            Call System.Runtime.InteropServices.Marshal.ReleaseComObject(ExcelBook)
                            Call System.Runtime.InteropServices.Marshal.ReleaseComObject(ExcelApp)

                        End Try

                        'データベースから切断
                        conn.Close()

                    End Using
                End Using
            End Using
        End Using

    End Sub

    'データベースを閉じる
    Public Shared Sub closing()

        Dim conn As New OracleConnection(strConnect)

        'もしデータベースが開いたままであれば、データベースを閉じる
        If conn.State = 1 Then
            conn.Close()
        End If

        MessageBox.Show("データベースから切断して" & vbLf & "処理を終了します。")

    End Sub


End Class
