Imports System.Data.OleDb
Module Module1
    Public conn As OleDbConnection
    'Public dbconn As New OleDbConnection
    Public cmd As OleDbCommand
    Public sad As OleDbCommand
    Public rd As OleDbDataReader
    Public asd As OleDbCommand
    Public sd As OleDbDataReader
    Public rf As OleDbCommand

    Public Function Rep(ByVal Kata As String) As String
        Rep = Replace(Kata, "'", "''")
    End Function

End Module