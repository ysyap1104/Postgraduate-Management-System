Imports MySql.Data.MySqlClient

Public Class AcademicPage
    ' Database connection

    Public ServerString As String = "server=localhost;user id=root;database=managementsystem;"
    Public SQLConnection As MySqlConnection = New MySqlConnection
    Public command As MySqlCommand
    Public reader As MySqlDataReader
    Dim Query As String

    Dim academicstaff As AcademicStaff
    Dim selectedProgramme As Programme
    Dim project As Project
    Dim selectedProject As Project
    Dim colloquium As Colloquium

    'Header panel
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
        LoginPage.Close()
        CourseStudentPage.Close()
        ResearchStudentPage.Close()
        AdminPage.Close()
    End Sub

    Private Sub MinimizeBtn_Click(sender As Object, e As EventArgs) Handles MinimizeBtn.Click
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
    End Sub

    Private Sub LogoutBtn_Click(sender As Object, e As EventArgs) Handles LogoutBtn.Click
        MessageBox.Show("Logout succesfully")
        LoginPage.Show()
        Me.Hide()

    End Sub

    'View profile
    Private Sub ProfileBtn_Click(sender As Object, e As EventArgs) Handles ProfileBtn.Click
        pnlHome.Visible = False
        pnlColloquium.Visible = False
        ViewStaffprofilepnl.Visible = True
        pnlAddProject.Visible = False
        academicstaff.viewStaffProfile()
        Staffaddresslbl.Enabled = False
    End Sub

    Private Sub AcademicPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Database connection
        SQLConnection.ConnectionString = ServerString
        Try
            If SQLConnection.State = ConnectionState.Closed Then
                SQLConnection.Open()

            Else
                SQLConnection.Close()

            End If
        Catch ex As Exception
        End Try
        Query = " select * FROM managementsystem.academic_staff where Staff_ID= '" & LoginPage.Usernametxt.text & "' "
        command = New MySqlCommand(Query, SQLConnection)
        reader = command.ExecuteReader
        reader.Read()
        'Create a instance of admin who are currently logged in to this sytem
        academicstaff = New AcademicStaff(reader.GetString("Staff_ID"), reader.GetString("Staff_Password"), reader.GetString("Staff_Lname"), reader.GetString("Staff_Fname"), reader.GetString("Staff_IC"), reader.GetString("Staff_Gender"), reader.GetString("Staff_Address"), reader.GetString("Staff_Contact_No"), reader.GetString("Staff_Room"), reader.GetString("Staff_ConsultationDay"), reader.GetString("Staff_ConsultationTime"), reader.GetString("Staff_Email"), reader.GetString("Staff_Salary"))
        reader.Close()

        Namelbl.Text = academicstaff.getLname() + "  " + academicstaff.getFname()

    End Sub

    Private Sub HomeBtn_Click(sender As Object, e As EventArgs) Handles HomeBtn.Click
        pnlHome.Visible = True
        ViewStaffprofilepnl.Visible = False
        pnlAddProject.Visible = False

        Namelbl.Text = academicstaff.getLname() + "  " + academicstaff.getFname()
    End Sub

    'Project
    Private Sub ProjectBtn_Click(sender As Object, e As EventArgs) Handles ProjectBtn.Click
        changePanel()
        pnlAddProject.Visible = True

        Try
            Query = "select count(*) from managementsystem.project"
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            reader.Read()
            Dim count As Integer = reader.GetInt32("count(*)")
            reader.Close()

            If (count = 0) Then
                ProjectID.Text = "P0"
            Else
                Query = " select Project_ID from managementsystem.Project ORDER BY Project_ID DESC"
                command = New MySqlCommand(Query, SQLConnection)
                reader = command.ExecuteReader
                reader.Read()

                Dim lastProjectID As String
                lastProjectID = reader.GetString("Project_ID")

                Dim lastInteger As Integer
                lastInteger = lastProjectID.Substring(1, lastProjectID.Length - 1)

                Dim newInteger As Integer
                newInteger = lastInteger + 1

                ProjectID.Text = "P" + newInteger.ToString()
                reader.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Error is occured")
        End Try
        ProjectProgrammeCB.Items.Clear()
        Try

            Dim Query As String
            Query = "select * from managementsystem.Programme"
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            While reader.Read()
                ProjectProgrammeCB.Items.Add(reader.GetString("Programme_Name"))
            End While
            reader.Close()

        Catch ex As Exception
            MessageBox.Show("Error is occured")
        End Try

    End Sub

    Private Sub ProjectProgrammeCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProjectProgrammeCB.SelectedIndexChanged
        Try
            Query = "select * from managementsystem.Programme where Programme_Name='" & ProjectProgrammeCB.SelectedItem() & "' "
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            reader.Read()

            selectedProgramme = New Programme(reader.GetString("Programme_ID"), reader.GetString("Programme_Name"))
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error is occured.")
        End Try
    End Sub

    Private Sub AddProjectBtn_Click(sender As Object, e As EventArgs) Handles AddProjectBtn.Click
        project = New Project(ProjectID.Text, ProjectTitleTxtbox.Text, ProjectDescriptionTxtbox.Text)
        Try
            project.addProject(selectedProgramme.getProgrammeID(), academicstaff.getID())
        Catch ex As Exception
            MessageBox.Show("Invalid inputs")
        End Try
    End Sub

    'Colloquium
    Private Sub ColloquiumBtn_Click(sender As Object, e As EventArgs) Handles ColloquiumBtn.Click
        changePanel()
        pnlColloquium.Visible = True
        ProjectIDCB.Items.Clear()
        Try
            Query = " select Project_ID FROM managementsystem.Project where Staff_ID = '" & academicstaff.getID() & "'"
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            While (reader.Read())
                ProjectIDCB.Items.Add(reader.GetString("Project_ID"))
            End While
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error is occured")
        End Try

        Try
            Query = "select count(*) from managementsystem.colloquium"
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            reader.Read()
            Dim count As Integer = reader.GetInt32("count(*)")
            reader.Close()

            If (count = 0) Then
                ColloquiumID.Text = "C0"
            Else
                Query = " select Colloquium_ID FROM managementsystem.Colloquium ORDER BY Colloquium_ID DESC"
                command = New MySqlCommand(Query, SQLConnection)
                reader = command.ExecuteReader
                reader.Read()

                Dim lastColloquiumID As String
                lastColloquiumID = reader.GetString("Colloquium_ID")

                Dim lastInteger As Integer
                lastInteger = lastColloquiumID.Substring(1, lastColloquiumID.Length - 1)

                Dim newInteger As Integer
                newInteger = lastInteger + 1

                ColloquiumID.Text = "C" + newInteger.ToString()
                reader.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Error is occcured")
        End Try

    End Sub

    Private Sub ProjectIDCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProjectIDCB.SelectedIndexChanged
        Try
            Query = "select * from managementsystem.project where Project_ID ='" & ProjectIDCB.SelectedItem() & "' "
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            reader.Read()
            Project_Title.Text = reader.GetString("Project_Title")
            selectedProject = New Project(reader.GetString("Project_ID"), reader.GetString("Project_Title"), reader.GetString("Project_Description"))
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error is occured")
        End Try
    End Sub

    Private Sub AddColloquiumBtn_Click(sender As Object, e As EventArgs) Handles AddColloquiumBtn.Click
        Try
            colloquium = New Colloquium(ColloquiumID.Text, ColloquiumVenueTxtbox.Text, ColloquiumDate.Value.Date, ColloquiumTimeCB.SelectedItem())
            selectedProject.addColloquium(colloquium)
            Dim i As Integer = selectedProject.getColloquiumSize() - 1
            selectedProject.getColloquium(i).addColloquium(selectedProject.getProjectID())
        Catch ex As Exception
            MessageBox.Show("Invalid inputs.")
        End Try

        'Clear text box
        ColloquiumVenueTxtbox.ResetText()

        Query = " select Colloquium_ID FROM managementsystem.Colloquium ORDER BY Colloquium_ID DESC"
        command = New MySqlCommand(Query, SQLConnection)
        reader = command.ExecuteReader
        reader.Read()

        Dim lastColloquiumID As String
        lastColloquiumID = reader.GetString("Colloquium_ID")

        Dim lastInteger As Integer
        lastInteger = lastColloquiumID.Substring(1, lastColloquiumID.Length - 1)

        Dim newInteger As Integer
        newInteger = lastInteger + 1

        ColloquiumID.Text = "C" + newInteger.ToString()
        reader.Close()

    End Sub

    'Change panel
    Private Function changePanel()
        pnlHome.Visible = False
        ViewStaffprofilepnl.Visible = False
        pnlAddProject.Visible = False
        pnlColloquium.Visible = False
        Return Nothing
    End Function

End Class