Imports MySql.Data.MySqlClient
Public Class Colloquium
    Private Colloquium_ID As String
    Private Colloquium_Venue As String
    Private Colloquium_Date As String
    Private Colloquium_Time As String

    Sub New(ByVal Colloquium_ID As String, ByVal Colloquium_Venue As String, ByVal Colloquium_Date As String, ByVal Colloquium_Time As String)
        Me.Colloquium_ID = Colloquium_ID
        Me.Colloquium_Venue = Colloquium_Venue
        Me.Colloquium_Date = Colloquium_Date
        Me.Colloquium_Time = Colloquium_Time
    End Sub

    Public Function addColloquium(ByVal projectID As String)

        Dim Query As String
        Try
            Query = " insert into managementsystem.colloquium (Colloquium_ID, Colloquium_Venue, Colloquium_Date, Colloquium_Time, Project_ID) values ('" & Colloquium_ID & "', '" & Colloquium_Venue & "', '" & Colloquium_Date & "', '" & Colloquium_Time & "', '" & projectID & "')"
            AcademicPage.command = New MySqlCommand(Query, AcademicPage.SQLConnection)
            AcademicPage.reader = AcademicPage.command.ExecuteReader
            AcademicPage.reader.Close()
            MessageBox.Show("Succesfully add")
        Catch ex As Exception
            MessageBox.Show("You can't add colloquium")
        End Try

        Return Nothing
    End Function

    Public Function requestColloquium(ByVal studentID As String)

        Dim Query As String
        Try
            Query = "update colloquium set Student_ID = '" & studentID & "' where Colloquium_ID = '" & Colloquium_ID & "' "
            LoginPage.command = New MySqlCommand(Query, LoginPage.SQLConnection)
            LoginPage.reader = LoginPage.command.ExecuteReader
            LoginPage.reader.Close()
            MessageBox.Show("Succesfully request")
        Catch ex As Exception
            MessageBox.Show("You can't request colloquium")
        End Try

        Return Nothing
    End Function

    Public Function getColloquiumID()
        Return Colloquium_ID
    End Function

End Class
