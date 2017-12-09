Imports MySql.Data.MySqlClient
Public Class Classes
    Private Class_ID As String
    Private Day As String
    Private Time As String
    Private Venue As String
    Private Class_Size As Integer

    'Default constructor
    Sub New(ByVal Class_ID As String, ByVal day As String, ByVal time As String, ByVal venue As String, ByVal Class_Size As Integer)
        Me.Class_ID = Class_ID
        Me.Day = day
        Me.Time = time
        Me.Venue = venue
        Me.Class_Size = Class_Size
    End Sub

    Public Function addClass(ByVal Subject_ID)

        Dim Query As String
        Try
            Query = " insert into managementsystem.Class values ('" & Class_ID & "', '" & Subject_ID & "','" & Day & "' , '" & Time & "', '" & Venue & "', '" & Class_Size & "')"
            AdminPage.command = New MySqlCommand(Query, AdminPage.SQLConnection)
            AdminPage.reader = AdminPage.command.ExecuteReader
            AdminPage.reader.Close()
            MessageBox.Show("Succesfully added")
        Catch ex As Exception
            MsgBox("Failed to add")
        End Try

        Return Nothing
    End Function

    Public Function getClassID() As String
        Return Class_ID
    End Function

    Public Function getClassSize() As Integer
        Return Class_Size
    End Function

End Class
