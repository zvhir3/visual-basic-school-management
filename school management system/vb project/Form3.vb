Imports System.Data.OleDb
Imports System.Threading
Imports System.Security.Cryptography
Imports System.Text
Public Class Form3
    Dim dbconn As New OleDbConnection
    Dim adt As New OleDbDataAdapter
    Dim ds As New DataSet

    Dim datatable As New DataTable
    Dim cmd As New OleDbCommand
    Public selected As String

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbconn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\database.mdb"

        TextBox2.ReadOnly = True
        TextBox3.ReadOnly = True



    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Try
            Dim sql = "select * from Table1 where ID like'" & TextBox1.Text & "'"
            adt = New OleDbDataAdapter(sql, dbconn)
            cmd = New OleDbCommand(sql)
            adt.Fill(ds, "Table1")
            'ds.tables(tableName).rows(rowNumber)(columnNumber).tostring

            TextBox1.Visible = False


            TextBox2.Text = ds.Tables("Table1").Rows(0)(3).ToString
            TextBox3.Text = ds.Tables("Table1").Rows(0)(4).ToString
            TextBox4.Text = ds.Tables("Table1").Rows(0)(11).ToString
            TextBox5.Text = ds.Tables("Table1").Rows(0)(12).ToString
            TextBox6.Text = ds.Tables("Table1").Rows(0)(13).ToString
            TextBox7.Text = ds.Tables("Table1").Rows(0)(14).ToString
            TextBox8.Text = ds.Tables("Table1").Rows(0)(15).ToString
            TextBox9.Text = ds.Tables("Table1").Rows(0)(16).ToString
            TextBox10.Text = ds.Tables("Table1").Rows(0)(17).ToString

            ds = New DataSet
        Catch ex As Exception
            MsgBox("No items match your search", MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub update_Click(sender As Object, e As EventArgs) Handles update.Click
        'Confirm dialogBox
        Dim dr As DialogResult
        dr = MessageBox.Show("Update information?", "Update", MessageBoxButtons.YesNo)
        If dr = DialogResult.No Then
            'NO CONDITION GOES HERE
        Else
            'YES CONDITION GOES HERE
            'Form restriction and validation
            If Len(Trim(TextBox1.Text)) = 0 Then
                MessageBox.Show("Please enter ID", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox1.Focus()
            ElseIf Len(Trim(TextBox2.Text)) = 0 Then
                MessageBox.Show("Please enter First Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox2.Focus()
            ElseIf Len(Trim(TextBox3.Text)) = 0 Then
                MessageBox.Show("Please enter Last Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox3.Focus()
            ElseIf Len(Trim(TextBox4.Text)) = 0 Then
                MessageBox.Show("Please enter Bahasa Melayu", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox4.Focus()
            ElseIf Len(Trim(TextBox5.Text)) = 0 Then
                MessageBox.Show("Please enter English", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox5.Focus()
            ElseIf Len(Trim(TextBox6.Text)) = 0 Then
                MessageBox.Show("Please enter Mathematic", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox6.Focus()
            ElseIf Len(Trim(TextBox7.Text)) = 0 Then
                MessageBox.Show("Please enter Science", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox7.Focus()
            ElseIf Len(Trim(TextBox8.Text)) = 0 Then
                MessageBox.Show("Please enter Pendidikan Jasmani", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox8.Focus()
            ElseIf Len(Trim(TextBox9.Text)) = 0 Then
                MessageBox.Show("Please enter Sejarah", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox9.Focus()
            ElseIf Len(Trim(TextBox10.Text)) = 0 Then
                MessageBox.Show("Please enter Geografi", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox10.Focus()

            Else
                adt = New OleDbDataAdapter("Update [Table1] set [First Name] = '" & TextBox2.Text & "',
            [Last Name] = '" & TextBox3.Text & "',
            [Bahasa Melayu] = '" & TextBox4.Text & "',
            [English]= '" & TextBox5.Text & "',
            [Mathematic]='" & TextBox6.Text & "',
            [Science]='" & TextBox7.Text & "',
            [Pendidikan Jasmani]='" & TextBox8.Text & "',
            [Sejarah]='" & TextBox9.Text & "',
            [Geografi]='" & TextBox10.Text & "'

            where ID=" & TextBox1.Text & "", dbconn)

                adt.Fill(ds)
                ds = New DataSet

                MsgBox("Updated")

            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
        AdminForm.Show()
    End Sub


End Class