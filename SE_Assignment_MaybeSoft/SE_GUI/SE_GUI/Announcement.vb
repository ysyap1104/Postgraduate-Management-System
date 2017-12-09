Imports MySql.Data.MySqlClient
Public Class Announcement
    Private Announcement_ID As String
    Private Announcement_Details As String

    Sub New(ByVal Annoucement_ID As String, ByVal Annoucement_Details As String)
        Me.Announcement_ID = Annoucement_ID
        Me.Announcement_Details = Annoucement_Details
    End Sub

    Public Function addAnnoucement(ByVal adminID As String)

        Dim Query As String
        Try
            Query = " insert into managementsystem.Announcement values ('" & Announcement_ID & "', '" & adminID & "', '" & Announcement_Details & "')"
            AdminPage.command = New MySqlCommand(Query, AdminPage.SQLConnection)
            AdminPage.reader = AdminPage.command.ExecuteReader
            AdminPage.reader.Close()
            MessageBox.Show("Succesfully add")
        Catch ex As Exception
            MessageBox.Show("Error is ocurred")
        End Try

        Return Nothing
    End Function

    Public Function dropAnnouncement()
        Dim Query As String
        Try
            Query = "delete from managementsystem.announcement where Announcement_ID = '" & Announcement_ID & "' "
            AdminPage.command = New MySqlCommand(Query, AdminPage.SQLConnection)
            AdminPage.reader = AdminPage.command.ExecuteReader
            AdminPage.reader.Close()
            MessageBox.Show("Succesfully drop")
        Catch ex As Exception
            MessageBox.Show("Error is ocurred")
        End Try

        Return Nothing
    End Function

End Class
