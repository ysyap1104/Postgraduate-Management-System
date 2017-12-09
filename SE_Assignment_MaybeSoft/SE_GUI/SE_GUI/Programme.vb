Imports MySql.Data.MySqlClient

Public Class Programme
    Private Programme_ID As String
    Private Programme_Name As String
    Private Programme_Type As String
    Private Programme_Fee As Double
    Private Programme_Sub As New List(Of Subject)

    Sub New(ByVal Programme_ID As String, ByVal Programme_Name As String, ByVal Programme_Type As String, ByVal Programme_Fee As Double)
        Me.Programme_ID = Programme_ID
        Me.Programme_Name = Programme_Name
        Me.Programme_Fee = Programme_Fee
        Me.Programme_Type = Programme_Type
    End Sub

    Sub New(ByVal Programme_ID As String, ByVal Programme_Name As String, ByVal Programme_Fee As Double, ByVal Programme_Sub As List(Of Subject))
        Me.Programme_ID = Programme_ID
        Me.Programme_Name = Programme_Name
        Me.Programme_Fee = Programme_Fee
        Me.Programme_Sub = Programme_Sub
    End Sub

    Sub New(ByVal Programme_ID As String, ByVal Programme_Name As String)
        Me.Programme_ID = Programme_ID
        Me.Programme_Name = Programme_Name
    End Sub

    Public Function getProgrammeID() As String
        Return Programme_ID
    End Function

    Public Function getProgrammeName() As String
        Return Programme_Name
    End Function

    Public Function getProgrammeFee() As Double
        Return Programme_Fee
    End Function

    Public Function addProgramme(ByVal adminID As String)

        Dim Query As String
        Try
            Query = " insert into managementsystem.programme values ('" & Programme_ID & "','" & Programme_Name & "' , '" & Programme_Type & "', '" & Programme_Fee & "', '" & adminID & "')"
            AdminPage.command = New MySqlCommand(Query, AdminPage.SQLConnection)
            AdminPage.reader = AdminPage.command.ExecuteReader
            AdminPage.reader.Close()
            MessageBox.Show("Succesfully added")
        Catch ex As Exception
            MsgBox("ID duplicate")
        End Try

        Return Nothing
    End Function

    Public Function getSubjectSize()
        Return Programme_Sub.Count()
    End Function

    Public Function setProgrammeSub(ByVal subjectList As List(Of Subject))

        Programme_Sub = subjectList

        Return Nothing
    End Function

    Public Function getProgrammeSub(ByVal index As Integer) As Subject
        Return Programme_Sub(index)
    End Function

End Class
