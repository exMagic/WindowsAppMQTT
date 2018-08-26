Imports MyMqtt

Public Class Form1


    Dim mm As MyMqttClass = New MyMqttClass

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = mm.ConnectMe().ToString()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim isBup = mm.Send(TextBox1.Text)
        If isBup Then
            Label1.Text = "poszlo"
        End If
        'Label1.Text = mm.Start().ToString()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label3.Text = mm.checkMsg
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label4.Text = mm.checkMsg
    End Sub
End Class
