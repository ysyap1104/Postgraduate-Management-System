Imports MySql.Data.MySqlClient

Public Class LoginPage
    ' Database connection
    Public ServerString As String = "server=localhost;user id=root;database=managementsystem;"
    Public SQLConnection As MySqlConnection = New MySqlConnection
    Public command As MySqlCommand
    Public reader As MySqlDataReader

    Public Admin As Admin
    Public student As Student
    Public Lecturer As AcademicStaff
    Public announcementList As New List(Of Announcement)

    'Header panel
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub

    Private Sub MinimizeBtn_Click(sender As Object, e As EventArgs) Handles MinimizeBtn.Click
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
    End Sub

    'Login
    Private Sub LoginPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Database connection
        SQLConnection.ConnectionString = ServerString
        Try
            If SQLConnection.State = ConnectionState.Closed Then
                SQLConnection.Open()
                MsgBox("Succesfully connect to the database!")
            Else
                SQLConnection.Close()
                MsgBox("Failed to connect to the database!")
            End If
        Catch ex As Exception
            MsgBox("ex.ToString")
        End Try

        Dim Query As String
        Try
            Query = "select * from announcement order by announcement_ID DESC LIMIT 2 "
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader

            reader.Read()
            AnnouncementIDLbl1.Text = reader.GetString("Announcement_ID") + " :"
            AnnouncementDetailslbl1.Text = reader.GetString("Announcement_Details")

            reader.Read()
            AnnouncementIDLbl2.Text = reader.GetString("Announcement_ID") + " :"
            AnnouncementDetailsLbl2.Text = reader.GetString("Announcement_Details")

            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error is occured")
        End Try


    End Sub

    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click

        If Usernametxt.text.Substring(0, 1) = "A" Then

            Admin = New Admin(Usernametxt.text, Passwordtxt.text)

            If Admin.verifyLogin() = True Then
                MessageBox.Show("Login succesfully")
                AdminPage.Show()
                Me.Hide()
            Else
                MessageBox.Show("Your username or password is invalid")
            End If


        ElseIf Usernametxt.text.Substring(0, 1) = "S" Then

            student = New Student(Usernametxt.text, Passwordtxt.text)

            If student.verifyLogin() = True Then
                If student.getStuType() = "Coursework" Then
                    MessageBox.Show("Login succesfully")
                    CourseStudentPage.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Login succesfully")
                    ResearchStudentPage.Show()
                    Me.Hide()
                End If
            Else
                MessageBox.Show("Your username or password is invalid")
            End If

        ElseIf Usernametxt.text.Substring(0, 1) = "L" Then

            Lecturer = New AcademicStaff(Usernametxt.text, Passwordtxt.text)

            If Lecturer.verifyLogin() = True Then
                MessageBox.Show("Login succesfully")
                AcademicPage.Show()
                Me.Hide()
            Else
                MessageBox.Show("Your username or password is invalid")
            End If

        Else
            MessageBox.Show("Your username or password is invalid")
        End If

    End Sub

End Class
