Imports System.Data.OleDb
Public Class Student_Information_Detail
    Dim ds As New DataSet
    Dim adt As New OleDbDataAdapter


    Dim cs As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\database.mdb"

    Sub Connection()
        conn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\database.mdb")
        conn.Open()
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form2.Show()
        sad = New OleDbCommand("select * from Table1 where Username='" & Rep(username.Text) & "'", conn)
        sd = sad.ExecuteReader
        sd.Read()
        Form2.Label1.Text = sd("First Name")
    End Sub

    Private Sub Student_Information_Detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        id.ReadOnly = True
        'username.ReadOnly = True
        'FirstName.ReadOnly = True
        'Lastname.ReadOnly = True
        ' ICNumber.ReadOnly = True
        ' Role.ReadOnly = True
        ' Gender.ReadOnly = True
        ' Address.ReadOnly = True
        ' Phone.ReadOnly = True
        'Email.ReadOnly = True

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        conn = New OleDbConnection(cs)
        conn.Open()

        If FirstName.Text = "" Or Lastname.Text = "" Or Gender.Text = "" Or Address.Text = "" Or Phone.Text = "" Or Email.Text = "" Or Role.Text = "" Or ICNumber.Text = "" Or Role.Text = "" Then
            MsgBox("Please enter complete details!")
            FirstName.Focus()
            Exit Sub
        Else



            cmd = New OleDbCommand("Update [Table1] set [Username] = '" & username.Text & "',
            [Password] = '" & password.Text & "',
            [First Name] = '" & FirstName.Text & "',
            [Last Name]= '" & Lastname.Text & "',
            [IC Number]='" & ICNumber.Text & "',
            [Role]='" & Role.Text & "',
            [Gender]='" & Gender.Text & "',
            [Address]='" & Address.Text & "',
            [Phone]='" & Phone.Text & "',
            [Email]='" & Email.Text & "'
            where ID=" & id.Text & "", conn)

            cmd.ExecuteReader()



            MsgBox("Account successfully updated")
        End If

    End Sub
End Class