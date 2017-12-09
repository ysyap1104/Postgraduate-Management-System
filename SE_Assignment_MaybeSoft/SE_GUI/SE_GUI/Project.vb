Imports MySql.Data.MySqlClient
Public Class Project
    Private Project_ID As String
    Private Project_Title As String
    Private Project_Description As String
    Private colloquium As New List(Of Colloquium)

    Sub New(ByVal Project_ID As String, ByVal Project_Title As String, ByVal Project_Description As String)
        Me.Project_ID = Project_ID
        Me.Project_Title = Project_Title
        Me.Project_Description = Project_Description
    End Sub

    Public Function addColloquium(ByVal selectedColloquium As Colloquium)
        Me.colloquium.Add(selectedColloquium)
        Return Nothing
    End Function

    Public Function getColloquiumSize() As Integer
        Return colloquium.Count()
    End Function

    Public Function getColloquium(ByVal index As Integer) As Colloquium
        Return colloquium(index)
    End Function

    Public Function getProjectID() As String
        Return Project_ID
    End Function

    Public Function addProject(ByVal programmeID As String, ByVal staffID As String)
        Dim Query As String
        Try
            Query = " insert into managementsystem.project (Project_ID, Project_Title, Project_Description, Programme_ID, Staff_ID) values ('" & Project_ID & "', '" & Project_Title & "', '" & Project_Description & "', '" & programmeID & "', '" & staffID & "')"
            AcademicPage.command = New MySqlCommand(Query, AcademicPage.SQLConnection)
            AcademicPage.reader = AcademicPage.command.ExecuteReader
            AcademicPage.reader.Close()
            MessageBox.Show("Succesfully add")
        Catch ex As Exception
            MessageBox.Show("You can't add this project.")
        End Try

        Return Nothing
    End Function

    Public Function selectProject(ByVal studentID As String)
        Dim Query As String

        Try
            Query = " update managementsystem.project set Student_ID = '" & studentID & "' where Project_ID = '" & Project_ID & "'"
            LoginPage.command = New MySqlCommand(Query, LoginPage.SQLConnection)
            LoginPage.reader = LoginPage.command.ExecuteReader
            LoginPage.reader.Close()
            MessageBox.Show("Succesfully select")
        Catch ex As Exception
            MessageBox.Show("You can't select the project")
        End Try

        Return Nothing

    End Function
End Class
