Imports MyMqtt
Imports MySql.Data.MySqlClient
Imports System.Configuration



Public Class Form1


    Dim mm As MyMqttClass = New MyMqttClass

    Public ReadOnly Property ConnectionString As String
        Get
            Return ConfigurationManager.ConnectionStrings("ConnectionString").ToString()
        End Get
    End Property

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = mm.ConnectMe().ToString()
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        'SQL
        Dim connetcion As New MySqlConnection(ConnectionString)
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter("SELECT * FROM ewastepk_mg.vare", connetcion)

        adapter.Fill(table)

        BindingSource1.DataSource = table
        DataGridView1.DataSource = BindingSource1

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
    Dim index
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        For Each row As DataGridViewRow In DataGridView1.Rows
            Dim barcode = DataGridView1.Item(1, row.Index).Value
            Dim antallKolli = DataGridView1.Item(5, row.Index).Value
            If barcode = txtBarcode.Text And antallKolli = txtAntall.Text Then
                index = row.Index
            End If
        Next

        lblName.Text = DataGridView1.Item(2, index).Value
        lblMottat.Text = DataGridView1.Item(3, index).Value
        lblBestilt.Text = DataGridView1.Item(4, index).Value

    End Sub




    Friend TextToBePrinted As String

    Public Sub prt(ByVal text As String, ByVal printer As String)
        TextToBePrinted = text
        Dim prn As New Printing.PrintDocument
        Using (prn)
            prn.PrinterSettings.PrinterName = printer
            AddHandler prn.PrintPage,
               AddressOf Me.PrintPageHandler
            prn.Print()
            RemoveHandler prn.PrintPage,
               AddressOf Me.PrintPageHandler
        End Using
    End Sub

    Private Sub PrintPageHandler(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)
        Dim myFont As New Font("Courier New", 9)
        args.Graphics.DrawString(TextToBePrinted, New Font(myFont, FontStyle.Bold), Brushes.Black, 5, 5)
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        prt("elo jesien", "ZDesigner ZQ520 (CPCL)")
    End Sub
End Class
