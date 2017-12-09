Imports MySql.Data.MySqlClient

Public Class Subject
    Private Subject_ID As String
    Private Subject_Name As String
    Private Subject_Credit_Hour As Integer
    Private Subject_Fee As Double
    Private Subject_Classes As New List(Of Classes)

    'Overloaded constructor
    Sub New(ByVal Subject_ID As String, ByVal Subject_Name As String, ByVal Subject_Credit_Hour As Integer, ByVal Subject_Fee As Double)
        Me.Subject_ID = Subject_ID
        Me.Subject_Name = Subject_Name
        Me.Subject_Credit_Hour = Subject_Credit_Hour
        Me.Subject_Fee = Subject_Fee
    End Sub

    'Default constructor
    Sub New(ByVal Subject_ID As String, ByVal Subject_Name As String, ByVal Subject_Credit_Hour As Integer, ByVal Subject_Fee As Double, ByVal Subject_Classes As List(Of Classes))
        Me.Subject_ID = Subject_ID
        Me.Subject_Name = Subject_Name
        Me.Subject_Credit_Hour = Subject_Credit_Hour
        Me.Subject_Fee = Subject_Fee
        Me.Subject_Classes = Subject_Classes
    End Sub

    Public Function getSubID() As String
        Return Subject_ID
    End Function

    Public Function getSubName() As String
        Return Subject_Name
    End Function

    Public Function addSubject(ByVal Programme_ID As String)

        Dim Query As String
        Try
            Query = " insert into managementsystem.Subject values ('" & Subject_ID & "','" & Subject_Name & "' , '" & Subject_Credit_Hour & "', '" & Subject_Fee & "', '" & Programme_ID & "')"
            AdminPage.command = New MySqlCommand(Query, AdminPage.SQLConnection)
            AdminPage.reader = AdminPage.command.ExecuteReader
            AdminPage.reader.Close()
            MessageBox.Show("Succesfully added")
        Catch ex As Exception
            MsgBox("Failed to add")
        End Try


        Return Nothing
    End Function

    Public Function setSubjectClass(ByVal classList As List(Of Classes))

        Subject_Classes = classList

        Return Nothing
    End Function

    Public Function getSubjectClass(ByVal index As Integer) As Classes
        Return Subject_Classes(index)
    End Function

    Public Function getClassSize() As Integer
        Return Subject_Classes.Count()
    End Function

    Public Function getFees() As Double
        Return Subject_Fee
    End Function
End Class
