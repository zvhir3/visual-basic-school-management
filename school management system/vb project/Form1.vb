Imports System.Data.OleDb
Public Class Form1
    Dim dbProvider As String
    Dim dbSource As String
    Dim con As New OleDb.OleDbConnection

    Dim ds As New DataSet
    Dim da As OleDb.OleDbDataAdapter
    Dim i As Integer
    Dim len As Integer

    Sub Connection()
        conn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\database.mdb")
        conn.Open()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Connection()
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Please enter data!")
            TextBox1.Focus()
            Exit Sub
        ElseIf textbox1.Text = My.Settings.TeacherUser And TextBox2.Text = My.Settings.TeacherPass Then
            Call adminLogin()

        Else
            cmd = New OleDbCommand("select * from Table1 where Username='" & Rep(TextBox1.Text) & "' and Password= '" & Rep(TextBox2.Text) & "'", conn)

            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows() Then
                MsgBox("Login Success! ")

                Me.Visible = False
                Form2.Show()

                Form2.Label1.Text = rd("First Name")
                Clear()

            Else
                MsgBox(" Wrong Username and Password!")
                Clear()
            End If


        End If

    End Sub
    Private Sub adminLogin()
        MsgBox(" Welcome Admin")
        AdminForm.Show()
        Me.Hide()

        'frmMain.txtStatus.Text = Me.txtUsername.Text
    End Sub
    Sub Clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
End Class
