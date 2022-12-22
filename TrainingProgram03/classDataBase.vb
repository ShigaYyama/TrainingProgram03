Imports System.Threading
Imports Microsoft.Office.Interop
Imports Oracle.ManagedDataAccess.Client

Public Class classDataBase

    '接続先情報
    Shared strConnect As String = "Data Source=localhost/orclpdb; User ID=TEST_USER; Password=TEST_USER_PASS;"

    'データベースの起動→接続を確立
    Public Shared Sub Loading()

        Try

            Using Conn As New OracleConnection(strConnect)

                Conn.Open()
                MessageBox.Show("データベースとの接続が確認出来ました。" & vbLf & "処理を続行します。")
                Conn.Close()

            End Using

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Application.Exit()

        End Try

    End Sub

    'データベースを閉じる
    Public Shared Sub Closing()

        Dim Conn As New OracleConnection(strConnect)

        Conn.Close()
        MessageBox.Show("データベースから切断して" & vbLf & "処理を終了します。")

    End Sub

    'SQLの結果をエクセル出力
    Public Shared Sub OutPuting(cbo1 As Integer, cbo2 As Integer)

        Dim IntSelected As Integer = Tasks.CboSelected(cbo1, cbo2)
        Dim OraObje As String = Tasks.SelectSql(IntSelected)

        'データベースに接続(Oracle)
        Using Conn As New OracleConnection(strConnect)
            Conn.Open()

            Using OraComm As OracleCommand = New OracleCommand(OraObje, Conn)
                Using OraAdap As New OracleDataAdapter(OraComm)

                    'Oracleをエクセル出力用に読み込む
                    Using OraRead As OracleDataReader = OraComm.ExecuteReader()

                        Dim Dset As DataSet = New DataSet()
                        Dim Dtable As DataTable

                        'SQL出力結果をデータテーブルに出力
                        OraAdap.Fill(Dset, "ExportDataTable")
                        Dtable = Dset.Tables("ExportDataTable")

                        'エクセル用の変数設定
                        Dim ExcelApp As New Excel.Application()
                        Dim ExcelBooksOpen As Excel.Workbooks = ExcelApp.Workbooks
                        Dim ExcelBook As Excel.Workbook = ExcelBooksOpen.Add()
                        Dim OraSheet As Excel.Worksheet = CType(ExcelApp.Worksheets("sheet1"), Excel.Worksheet)

                        Try

                            '保存用のダイアログ表示
                            Using Dialog As New SaveFileDialog()

                                Dim Ret As DialogResult
                                Dialog.Title = "出力データの保存先を選択"
                                Dialog.Filter = "EXCELファイル|*.xlsx"
                                Ret = Dialog.ShowDialog()

                                If Ret = DialogResult.OK Then

                                    Dim FilePath As String = Dialog.FileName

                                    '出力先のエクセルのセル番号 = データテーブルの座標にセット
                                    'Forで行と列を繰り返して値を取得
                                    For x As Integer = 0 To Dtable.Columns.Count - 1
                                        OraSheet.Cells(1, 1 + x) = Dtable.Columns(x).ColumnName
                                    Next

                                    For x As Integer = 0 To Dtable.Rows.Count - 1
                                        For y As Integer = 0 To Dtable.Columns.Count - 1
                                            OraSheet.Cells(2 + x, 1 + y) = Dtable.Rows(x).Item(y).ToString
                                        Next
                                    Next

                                    ExcelBook.SaveAs(FilePath)

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

                    End Using
                End Using
            End Using
        End Using

    End Sub
End Class
