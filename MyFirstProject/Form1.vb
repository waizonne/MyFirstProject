Imports System.Data.SqlClient

Public Class Form1

    Dim con As New SqlConnection
    Dim cmd As New SqlCommand

    Dim getData As New Dialog1()
    Dim name As String
    Dim address As String
    Dim ace As String

    Dim temp As String


    Private Sub conn_Click(sender As Object, e As EventArgs) Handles conn.Click
        If BackgroundWorker2.IsBusy <> True Then
            BackgroundWorker2.RunWorkerAsync()
            Me.conn.Enabled = False
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'FirstDBDataSet.Member' table. You can move, or remove it, as needed.
        Me.MemberTableAdapter.Fill(Me.FirstDBDataSet.Member)

    End Sub

    Private Sub delete_Click(sender As Object, e As EventArgs) Handles delete.Click
        If BackgroundWorker1.IsBusy <> True Then
            BackgroundWorker1.RunWorkerAsync()
            Me.delete.Enabled = False
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            con.ConnectionString = "Data Source=INTER-SPARE-IT2;Initial Catalog=firstDB;Integrated Security=True"
            con.Open()
            cmd.Connection = con

            name = getData.TextBox1.Text
            address = getData.TextBox2.Text
            ace = getData.TextBox3.Text

            cmd.CommandText = "DELETE FROM Member WHERE name = '" + temp + "'"
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("Error while inserting record on table..." & ex.Message, "Insert Records")
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Me.MemberTableAdapter.Fill(Me.FirstDBDataSet.Member)
        delete.Enabled = True
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        'ProgressBar1.Value = e.ProgressPercentage()

    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        If getData.ShowDialog = DialogResult.OK Then

            Try
                con.ConnectionString = "Data Source=INTER-SPARE-IT2;Initial Catalog=firstDB;Integrated Security=True"
                con.Open()
                cmd.Connection = con

                name = getData.TextBox1.Text
                address = getData.TextBox2.Text
                ace = getData.TextBox3.Text

                cmd.CommandText = "INSERT INTO Member ([name], [address], [ace]) VALUES ('" + name + "', '" + address + "', " + ace + ")"
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                MessageBox.Show("Error while inserting record on table..." & ex.Message, "Insert Records")
            Finally
                con.Close()
            End Try
            getData.TextBox1.Text = ""
            getData.TextBox2.Text = ""
            getData.TextBox3.Text = ""
        End If
        'getData.Dispose()
    End Sub

    Private Sub BackgroundWorker2_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker2.ProgressChanged
        'ProgressBar1.Value = e.ProgressPercentage()
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        conn.Enabled = True
        Me.MemberTableAdapter.Fill(Me.FirstDBDataSet.Member)
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim value As Object = DataGridView1.CurrentRow.Cells(0).Value

        'DataGridView1.CurrentRow.Cells(0).Value

        If IsDBNull(value) Then
            temp = "" ' blank if dbnull values
        Else
            temp = CType(value, String)
        End If
    End Sub
End Class