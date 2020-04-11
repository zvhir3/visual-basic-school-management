Imports System.Data.OleDb
Public Class Form2
    Dim dbProvider As String
    Dim dbSource As String

    Sub Connection()
        conn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\database.mdb")
        conn.Open()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()

        Student_Information_Detail.Show()

        Student_Information_Detail.id.Text = rd("ID")
        Student_Information_Detail.username.Text = rd("Username")
        Student_Information_Detail.password.Text = rd("Password")
        Student_Information_Detail.FirstName.Text = rd("First Name")
        Student_Information_Detail.Lastname.Text = rd("Last Name")
        Student_Information_Detail.ICNumber.Text = rd("IC Number")
        Student_Information_Detail.Role.Text = rd("Role")
        Student_Information_Detail.Gender.Text = rd("Gender")
        Student_Information_Detail.Address.Text = rd("Address")
        Student_Information_Detail.Phone.Text = rd("Phone")
        Student_Information_Detail.Email.Text = rd("Email")





    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Close()
        Form1.Show()



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()

        StudentGrade.Show()

        StudentGrade.TextBox1.Text = rd("ID")
        StudentGrade.TextBox2.Text = rd("First Name")
        StudentGrade.TextBox3.Text = rd("Last Name")
        StudentGrade.TextBox4.Text = rd("Bahasa Melayu")
        StudentGrade.TextBox5.Text = rd("English")
        StudentGrade.TextBox6.Text = rd("Mathematic")
        StudentGrade.TextBox7.Text = rd("Science")
        StudentGrade.TextBox8.Text = rd("Pendidikan Jasmani")
        StudentGrade.TextBox9.Text = rd("Sejarah")
        StudentGrade.TextBox10.Text = rd("Geografi")

    End Sub
End Class