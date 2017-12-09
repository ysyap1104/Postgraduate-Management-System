Imports MySql.Data.MySqlClient
Public Class Enrollment
    Private Enroll_Class As Classes

    Sub New(ByVal Enroll_Class As Classes)
        Me.Enroll_Class = Enroll_Class
    End Sub

    Public Function enroll(ByVal Student_ID As String, ByVal Subject_ID As String, ByVal Class_ID As String)
        Try
            Dim Query As String
            Query = " insert into managementsystem.enrollment values ('" & Student_ID & "', '" & Subject_ID & "' , '" & Class_ID & "', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)"
            LoginPage.command = New MySqlCommand(Query, LoginPage.SQLConnection)
            LoginPage.reader = LoginPage.command.ExecuteReader
            LoginPage.reader.Close()
            MessageBox.Show("Succesfully added")
        Catch ex As Exception
            MessageBox.Show("Failed to enroll")
        End Try
        Return Nothing
    End Function

    Public Function getEnrollClass() As Classes
        Return Enroll_Class
    End Function


End Class
