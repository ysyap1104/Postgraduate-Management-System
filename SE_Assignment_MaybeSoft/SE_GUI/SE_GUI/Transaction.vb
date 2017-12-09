Imports MySql.Data.MySqlClient

Public Class Transaction
    Private Transaction_ID As String
    Private Reference_ID As String
    Private Amount As Double

    Sub New(ByVal Transaction_ID As String, ByVal Reference_ID As String, ByVal Amount As Double)
        Me.Transaction_ID = Transaction_ID
        Me.Reference_ID = Reference_ID
        Me.Amount = Amount
    End Sub


    Public Function performPayment(ByVal Admin_ID As String, ByVal Student_ID As String)
        Dim Query As String
        Try
            Query = " insert into managementsystem.Transaction values ('" & Transaction_ID & "','" & Student_ID & "' , '" & Admin_ID & "', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP,'" & Reference_ID & "', '" & Amount & "')"
            AdminPage.command = New MySqlCommand(Query, AdminPage.SQLConnection)
            AdminPage.reader = AdminPage.command.ExecuteReader
            AdminPage.reader.Close()
            MessageBox.Show("Payment Success")
        Catch ex As Exception
            MessageBox.Show("Invalid Data")
        End Try
        Return Nothing
    End Function

    Public Function getTransactionAmount() As Double
        Return Amount
    End Function
End Class

