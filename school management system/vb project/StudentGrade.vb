Imports System.Data.OleDb
Public Class StudentGrade
    Dim ds As New DataSet
    Dim adt As New OleDbDataAdapter


    Dim cs As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\database.mdb"

    Sub Connection()
        conn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\database.mdb")
        conn.Open()
    End Sub

    Private Sub StudentGrade_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        TextBox1.ReadOnly = True
        TextBox2.ReadOnly = True
        TextBox3.ReadOnly = True
        TextBox4.ReadOnly = True
        TextBox5.ReadOnly = True
        TextBox6.ReadOnly = True
        TextBox7.ReadOnly = True
        TextBox8.ReadOnly = True
        TextBox9.ReadOnly = True
        TextBox10.ReadOnly = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form2.Show()

        Form2.Label1.Text = rd("First Name")

    End Sub
End Class