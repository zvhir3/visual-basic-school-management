Imports System.Data.OleDb
Imports System.Threading
Imports System.Security.Cryptography
Imports System.Text
Public Class AdminStu_details

    Dim dbconn As New OleDbConnection
    Dim adt As New OleDbDataAdapter
    Dim ds As New DataSet

    Dim datatable As New DataTable
    Dim cmd As New OleDbCommand
    Public selected As String



    Private Sub AdminStu_details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbconn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\database.mdb"
        showData()
        'customColumnWidth()

    End Sub

    Private Sub customColumnWidth() ' set custom column width
        'datagridName.Columns(columnNumber or columnName)
        Dim columnID As DataGridViewColumn = dgvInfo.Columns(0)
        columnID.Width = 100 'set columnwidth
        Dim columnSurname As DataGridViewColumn = dgvInfo.Columns(1)
        columnSurname.Width = 100 'set columnwidth
    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub
    Private Sub showData()
        Dim dbcommand As String
        dbcommand = "SELECT * FROM Table1"
        adt = New OleDbDataAdapter(dbcommand, dbconn)
        datatable = New DataTable
        adt.Fill(datatable)
        dgvInfo.DataSource = datatable
    End Sub

    Private Sub saveBtn_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub UpdateBtn_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ClearBtn_Click(sender As Object, e As EventArgs)

    End Sub
    Sub clearText() 'clear all text
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox12.Text = ""
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
    Public Shared Function GetUniqueKey(ByVal maxSize As Integer) As String
        Dim chars As Char() = New Char(61) {}
        chars = "123456789".ToCharArray()
        Dim data As Byte() = New Byte(0) {}
        Dim crypto As New RNGCryptoServiceProvider()
        crypto.GetNonZeroBytes(data)
        data = New Byte(maxSize - 1) {}
        crypto.GetNonZeroBytes(data)
        Dim result As New StringBuilder(maxSize)
        For Each b As Byte In data
            result.Append(chars(b Mod (chars.Length)))
        Next
        Return result.ToString()
    End Function

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Try
            Dim sql = "select * from Table1 where ID like'" & TextBox1.Text & "'"
            adt = New OleDbDataAdapter(sql, dbconn)
            cmd = New OleDbCommand(sql)
            adt.Fill(ds, "Table1")
            'ds.tables(tableName).rows(rowNumber)(columnNumber).tostring

            TextBox2.Text = ds.Tables("Table1").Rows(0)(1).ToString
            TextBox3.Text = ds.Tables("Table1").Rows(0)(2).ToString
            TextBox4.Text = ds.Tables("Table1").Rows(0)(3).ToString
            TextBox5.Text = ds.Tables("Table1").Rows(0)(4).ToString
            TextBox6.Text = ds.Tables("Table1").Rows(0)(5).ToString
            TextBox7.Text = ds.Tables("Table1").Rows(0)(6).ToString
            TextBox8.Text = ds.Tables("Table1").Rows(0)(7).ToString
            TextBox9.Text = ds.Tables("Table1").Rows(0)(8).ToString
            TextBox10.Text = ds.Tables("Table1").Rows(0)(9).ToString
            TextBox12.Text = ds.Tables("Table1").Rows(0)(10).ToString
            ds = New DataSet
        Catch ex As Exception
            MsgBox("No items match your search", MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub UpdateBtn_Click_1(sender As Object, e As EventArgs) Handles UpdateBtn.Click
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
                MessageBox.Show("Please enter Username", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox2.Focus()
            ElseIf Len(Trim(TextBox3.Text)) = 0 Then
                MessageBox.Show("Please enter Password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox3.Focus()
            ElseIf Len(Trim(TextBox4.Text)) = 0 Then
                MessageBox.Show("Please enter First Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox4.Focus()
            ElseIf Len(Trim(TextBox5.Text)) = 0 Then
                MessageBox.Show("Please enter Last Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox5.Focus()
            ElseIf Len(Trim(TextBox6.Text)) = 0 Then
                MessageBox.Show("Please enter IC Number", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox6.Focus()
            ElseIf Len(Trim(TextBox7.Text)) = 0 Then
                MessageBox.Show("Please enter Role", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox7.Focus()
            ElseIf Len(Trim(TextBox8.Text)) = 0 Then
                MessageBox.Show("Please enter Gender", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox8.Focus()
            ElseIf Len(Trim(TextBox9.Text)) = 0 Then
                MessageBox.Show("Please enter Address", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox9.Focus()
            ElseIf Len(Trim(TextBox10.Text)) = 0 Then
                MessageBox.Show("Please enter Phone", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox10.Focus()
            ElseIf Len(Trim(TextBox12.Text)) = 0 Then
                MessageBox.Show("Please enter Email", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox12.Focus()
            Else
                adt = New OleDbDataAdapter("Update [Table1] set [Username] = '" & TextBox2.Text & "',
            [Password] = '" & TextBox3.Text & "',
            [First Name] = '" & TextBox4.Text & "',
            [Last Name]= '" & TextBox5.Text & "',
            [IC Number]='" & TextBox6.Text & "',
            [Role]='" & TextBox7.Text & "',
            [Gender]='" & TextBox8.Text & "',
            [Address]='" & TextBox9.Text & "',
            [Phone]='" & TextBox10.Text & "',
            [Email]='" & TextBox12.Text & "'
            where ID=" & TextBox1.Text & "", dbconn)

                adt.Fill(ds)
                ds = New DataSet
                showData() ' refresh data in datagridview
                MsgBox("Updated")
                clearText() 'clear all text
            End If
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub DeleteBtn_Click_1(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        'Confirm dialogBox
        Dim dr As DialogResult
        dr = MessageBox.Show("Delete information?", "Delete", MessageBoxButtons.YesNo)
        If dr = DialogResult.No Then
            'NO CONDITION GOES HERE
        Else
            'YES CONDITION GOES HERE
            'Form restriction and validation
            If Len(Trim(TextBox1.Text)) = 0 Then
                MessageBox.Show("Please enter ID", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox1.Focus()
            ElseIf Len(Trim(TextBox2.Text)) = 0 Then
                MessageBox.Show("Please enter Username", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox2.Focus()
            ElseIf Len(Trim(TextBox3.Text)) = 0 Then
                MessageBox.Show("Please enter Password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox3.Focus()
            ElseIf Len(Trim(TextBox4.Text)) = 0 Then
                MessageBox.Show("Please enter First Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox4.Focus()
            ElseIf Len(Trim(TextBox5.Text)) = 0 Then
                MessageBox.Show("Please enter Last Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox5.Focus()
            ElseIf Len(Trim(TextBox6.Text)) = 0 Then
                MessageBox.Show("Please enter IC Number", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox6.Focus()
            ElseIf Len(Trim(TextBox7.Text)) = 0 Then
                MessageBox.Show("Please enter Role", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox7.Focus()
            ElseIf Len(Trim(TextBox8.Text)) = 0 Then
                MessageBox.Show("Please enter Gender", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox8.Focus()
            ElseIf Len(Trim(TextBox9.Text)) = 0 Then
                MessageBox.Show("Please enter Address", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox9.Focus()
            ElseIf Len(Trim(TextBox10.Text)) = 0 Then
                MessageBox.Show("Please enter Phone", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox10.Focus()
            ElseIf Len(Trim(TextBox12.Text)) = 0 Then
                MessageBox.Show("Please enter Email", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox12.Focus()
            Else
                adt = New OleDbDataAdapter("delete [Username]='" & TextBox2.Text & "',[Password]='" & TextBox3.Text & "',[First Name]='" & TextBox4.Text & "',[Last Name]='" & TextBox5.Text & "',[IC Number]='" & TextBox6.Text & "',[Role]='" & TextBox7.Text & "',[Gender]='" & TextBox8.Text & "',[Address]='" & TextBox9.Text & "',[Phone]='" & TextBox10.Text & "',[Email]='" & TextBox12.Text & "'from Table1 where  ID=" & TextBox1.Text & "", dbconn)
                adt.Fill(ds)
                ds = New DataSet
                showData() ' refresh data in datagridview
                MsgBox("Deleted")
                clearText() 'clear all text
            End If
        End If
    End Sub

    Private Sub ClearBtn_Click_1(sender As Object, e As EventArgs) Handles ClearBtn.Click
        Dim dr As DialogResult
        dr = MessageBox.Show("Clear text?", "Clear", MessageBoxButtons.YesNo)
        If dr = DialogResult.No Then
            'NO CONDITION GOES HERE
        Else
            'YES CONDITION GOES HERE
            clearText() 'clear all text
        End If
    End Sub

    Private Sub saveBtn_Click_1(sender As Object, e As EventArgs) Handles saveBtn.Click
        Dim dr As DialogResult
        dr = MessageBox.Show("Save information?", "Save", MessageBoxButtons.YesNo)
        If dr = DialogResult.No Then
        Else
            'If Len(Trim(TextBox1.Text)) = 0 Then
            'Mes'ox1.Focus()
            If Len(Trim(TextBox2.Text)) = 0 Then
                MessageBox.Show("Please enter Username", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox2.Focus()
            ElseIf Len(Trim(TextBox3.Text)) = 0 Then
                MessageBox.Show("Please enter Password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox3.Focus()
            ElseIf Len(Trim(TextBox4.Text)) = 0 Then
                MessageBox.Show("Please enter First Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox4.Focus()
            ElseIf Len(Trim(TextBox5.Text)) = 0 Then
                MessageBox.Show("Please enter Last Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox5.Focus()
            ElseIf Len(Trim(TextBox6.Text)) = 0 Then
                MessageBox.Show("Please enter IC Number", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox6.Focus()
            ElseIf Len(Trim(TextBox7.Text)) = 0 Then
                MessageBox.Show("Please enter Role", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox7.Focus()
            ElseIf Len(Trim(TextBox8.Text)) = 0 Then
                MessageBox.Show("Please enter Gender", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox8.Focus()
            ElseIf Len(Trim(TextBox9.Text)) = 0 Then
                MessageBox.Show("Please enter Address", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox9.Focus()
            ElseIf Len(Trim(TextBox10.Text)) = 0 Then
                MessageBox.Show("Please enter Phone", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox10.Focus()
            ElseIf Len(Trim(TextBox12.Text)) = 0 Then
                MessageBox.Show("Please enter Email", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox12.Focus()
            Else
                cmd = New OleDbCommand("select * from Table1 where ID=" & TextBox1.Text & "", conn)
                rd = cmd.ExecuteReader
                rd.Read()
                If Not rd.HasRows Then
                    'adt = New OleDbDataAdapter("insert into Table1 values ('" & Rep(TextBox1.Text) & "','" & Rep(TextBox2.Text) & "','" & Rep(TextBox3.Text) & "','" & Rep(TextBox4.Text) & "','" & Rep(TextBox5.Text) & "','" & Rep(TextBox6.Text) & "','" & Rep(TextBox7.Text) & "','" & Rep(TextBox8.Text) & "','" & Rep(TextBox9.Text) & "','" & Rep(TextBox10.Text) & "','" & Rep(TextBox12.Text) & "'", dbconn)
                    adt = New OleDbDataAdapter("insert into Table1 ([Username], [Password], [First Name], [Last Name], [IC Number], [Role], [Gender], [Address], [Phone], [Email]) values ('" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & TextBox9.Text & "','" & TextBox10.Text & "','" & TextBox12.Text & "')", dbconn)
                    adt.Fill(ds)
                    ds = New DataSet
                    showData() ' refresh data in datagridview
                    MsgBox("Saved")
                    clearText() 'clear all text
                Else
                    TextBox1.Text = ""
                    MsgBox("ID is already used")
                    clearText()

                End If
            End If
        End If
        TextBox1.Visible = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clearText()
        TextBox1.Text = GetUniqueKey(6)
        TextBox1.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AdminForm.Show()
        Me.Hide()



    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class