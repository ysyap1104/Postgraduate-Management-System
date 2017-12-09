Imports MySql.Data.MySqlClient

Public Class Admin
    Private Admin_ID As String
    Private Admin_Password As String
    Private Admin_Department As String

    Sub New(ByVal Admin_ID As String, Admin_Password As String, Admin_Department As String)
        Me.Admin_ID = Admin_ID
        Me.Admin_Password = Admin_Password
        Me.Admin_Department = Admin_Department
    End Sub

    Sub New(ByVal Admin_ID As String, Admin_Password As String)
        Me.Admin_ID = Admin_ID
        Me.Admin_Password = Admin_Password
    End Sub

    Public Function getID() As String
        Return Admin_ID
    End Function

    Public Function getPW() As String
        Return Admin_Password
    End Function

    Public Function getDepartment() As String
        Return Admin_Department
    End Function

    Public Function verifyLogin() As Boolean

        Dim Query As String
        Try
            Query = " select * from managementsystem.admin where Admin_ID= '" & Admin_ID & "' and Admin_Password ='" & Admin_Password & "' "
            LoginPage.command = New MySqlCommand(Query, LoginPage.SQLConnection)
            LoginPage.reader = LoginPage.command.ExecuteReader

            If LoginPage.reader.Read() Then
                LoginPage.reader.Close()
                Return True
            Else
                LoginPage.reader.Close()
                Return False
            End If

        Catch ex As Exception
            MessageBox.Show("Error is occured")
        End Try


        Return Nothing
    End Function




End Class
