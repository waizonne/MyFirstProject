﻿Public Class Form2

    Dim i As Integer
    Dim i2 As Integer

    Dim thread As System.Threading.Thread
    Dim thread2 As System.Threading.Thread

    Private Sub countup()
        Do Until i = 100000
            i = i + 1
            Label1.Text = i
            Me.Refresh()
        Loop
        i = 0
    End Sub

    Private Sub countup2()
        Do Until i2 = 100000
            i2 = i2 + 1
            Label2.Text = i2
            Me.Refresh()
        Loop
        i2 = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        thread = New System.Threading.Thread(AddressOf countup)
        thread.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        thread2 = New System.Threading.Thread(AddressOf countup2)
        thread2.Start()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CheckForIllegalCrossThreadCalls = False
    End Sub
End Class