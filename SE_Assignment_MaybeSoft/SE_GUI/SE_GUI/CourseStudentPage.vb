Imports MySql.Data.MySqlClient

Public Class CourseStudentPage
    Dim projectBtnSize = 0
    ' Database connection
    Public ServerString As String = "server=localhost;user id=root;database=managementsystem;"
    Public SQLConnection As MySqlConnection = New MySqlConnection
    Public command As MySqlCommand
    Public reader As MySqlDataReader
    Public Query As String
    Dim dbDataSet As New DataTable

    Dim Coursework_Student As CourseworkStudent
    Dim programme As Programme
    Dim enrollmentList As New List(Of Enrollment)
    Dim enrollSubject As Subject
    Dim enrollClass As Classes
    Dim selectedEnrollClasses As New List(Of Classes)
    Dim selectedEnrollSubjects As New List(Of Subject)
    Dim numAvailableSeat As Integer
    Dim selectedProject As Project

    'Header panel
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
        LoginPage.Close()
        AcademicPage.Close()
        ResearchStudentPage.Close()
        AdminPage.Close()
    End Sub

    Private Sub MinimizeBtn_Click(sender As Object, e As EventArgs) Handles MinimizeBtn.Click
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
    End Sub

    Private Sub LogoutBtn_Click(sender As Object, e As EventArgs) Handles LogoutBtn.Click
        MessageBox.Show("Logout Successfully")
        LoginPage.Show()
        Me.Hide()

    End Sub

    'Coursework student page load
    Private Sub CourseStudentPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        'Select coursework student details who is currently logged in to this system from the database 
        Query = "Select * from managementsystem.student, managementsystem.programme where Student.Programme_ID=Programme.Programme_ID and Student_ID = '" & LoginPage.Usernametxt.text & "' "
        command = New MySqlCommand(Query, SQLConnection)
        reader = command.ExecuteReader
        reader.Read()

        'Create an instance of programme
        programme = New Programme(reader.GetString("Programme_ID"), reader.GetString("Programme_Name"), reader.GetString("Programme_Type"), reader.GetDouble("Programme_Fee"))
        'Create an instance of student who are currently logged in to this sytem
        Coursework_Student = New CourseworkStudent(reader.GetString("Student_ID"), reader.GetString("Stu_Password"), reader.GetString("Stu_Lname"), reader.GetString("Stu_Fname"), reader.GetString("Stu_IC"), reader.GetString("Stu_Gender"), reader.GetString("Stu_Address"), reader.GetString("Stu_Contact_No"), reader.GetString("Stu_Email"), reader.GetString("Stu_OutstandingFee"), reader.GetString("Stu_Type"), programme)

        reader.Close()

        Namelbl.Text = Coursework_Student.getLname() + "  " + Coursework_Student.getFname()

    End Sub

    'Home panel
    Private Sub HomeBtn_Click(sender As Object, e As EventArgs) Handles HomeBtn.Click

        changePanel()
        pnlHome.Visible = True

        Namelbl.Text = Coursework_Student.getLname() + "  " + Coursework_Student.getFname()

    End Sub

    'View student profile
    Private Sub ProfileBtn_Click(sender As Object, e As EventArgs) Handles ProfileBtn.Click
        changePanel()
        pnlViewStuProfile.Visible = True

        Coursework_Student.viewCourseWorkStuProfile()
    End Sub

    'Enrollment 
    Private Sub EnrollBtn_Click(sender As Object, e As EventArgs) Handles EnrollBtn.Click
        SubjectIDCB.Items.Clear()
        changePanel()
        pnlEnroll.Visible = True

        Try
            Dim Query As String
            Query = "select * from managementsystem.programme, managementsystem.subject, managementsystem.student
                    where Student.Programme_ID = Programme.Programme_ID 
                    and Programme.Programme_ID = Subject.Programme_ID 
                    and Student_ID = '" & Coursework_Student.getStuID() & "'"
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            While reader.Read()
                SubjectIDCB.Items.Add(reader.GetString("Subject_ID"))
            End While
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error Is occured")
        End Try

    End Sub

    Private Sub SubjectIDCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SubjectIDCB.SelectedIndexChanged
        Try
            Dim Query As String
            Query = "Select * from managementsystem.subject where Subject_ID = '" & SubjectIDCB.SelectedItem() & "' "
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            reader.Read()
            SubjectNamelbl.Text = reader.GetString("Subject_Name")
            enrollSubject = New Subject(reader.GetString("Subject_ID"), reader.GetString("Subject_Name"), reader.GetInt16("Subject_Credit_Hour"), reader.GetDouble("Subject_Fee"))
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error is occured")
        End Try

        ClassIDCB.Items.Clear()
        Try
            Dim Query As String
            Query = "select * from managementsystem.class where Subject_ID = '" & enrollSubject.getSubID() & "'"
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            While reader.Read()
                ClassIDCB.Items.Add(reader.GetString("Class_ID"))
            End While
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error is occured")
        End Try


    End Sub

    Private Sub ClassIDCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ClassIDCB.SelectedIndexChanged
        Try
            Dim Query As String
            Query = "select count(*) from managementsystem.enrollment where Subject_ID = '" & SubjectIDCB.SelectedItem() & "' and Class_ID = '" & ClassIDCB.SelectedItem() & "'"
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            reader.Read()
            Dim totalEnroll As Integer = reader.GetInt16("count(*)")
            reader.Close()

            Query = "select * from managementsystem.class where Class_ID = '" & ClassIDCB.SelectedItem() & "' and Subject_ID = '" & SubjectIDCB.SelectedItem() & "' "
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            reader.Read()
            ClassDaylbl.Text = reader.GetString("Day")
            ClassTimelbl.Text = reader.GetString("Time")
            ClassVenuelbl.Text = reader.GetString("Venue")
            CurrentClassSizelbl.Text = reader.GetInt16("Class_Size") - totalEnroll
            numAvailableSeat = reader.GetInt16("Class_Size") - totalEnroll
            enrollClass = New Classes(reader.GetString("Class_ID"), reader.GetString("Day"), reader.GetString("Time"), reader.GetString("Venue"), reader.GetInt16("Class_Size"))
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error is occured")
        End Try
    End Sub

    Private Sub AddClassToList_Click(sender As Object, e As EventArgs) Handles AddClassToList.Click

        Try
            If (checkEnroll() = True) Then
                selectedEnrollSubjects.Add(enrollSubject)
                selectedEnrollClasses.Add(enrollClass)
                Dim index As Integer = selectedEnrollClasses.Count() - 1
                enrollmentList.Add(New Enrollment(selectedEnrollClasses(index)))
                EnrollmentListDataGridView.Rows.Add(SubjectNamelbl.Text, SubjectIDCB.SelectedItem(), ClassIDCB.SelectedItem(), ClassDaylbl.Text(), ClassVenuelbl.Text, ClassTimelbl.Text)
            Else
                MessageBox.Show("You can't enroll to this subject")
            End If

        Catch ex As Exception
            MessageBox.Show("Invalid inputs")
        End Try


        'Clear all the label and combo box

        SubjectNamelbl.ResetText()
        ClassIDCB.Items.Clear()
        ClassDaylbl.ResetText()
        ClassVenuelbl.ResetText()
        ClassTimelbl.ResetText()
        CurrentClassSizelbl.ResetText()

    End Sub

    Private Function checkEnroll() As Boolean

        Query = "select count(*) from managementsystem.enrollment where Student_ID = '" & Coursework_Student.getStuID() & "' and Subject_ID = '" & enrollSubject.getSubID() & "' "
        command = New MySqlCommand(Query, SQLConnection)
        reader = command.ExecuteReader
        reader.Read()
        Dim count As Integer = reader.GetInt16("count(*)")
        reader.Close()

        Dim canEnroll As Boolean
        If (count <= 0) Then
            If (numAvailableSeat > 0) Then
                canEnroll = True
                Dim i As Integer = 0
                While i < selectedEnrollSubjects.Count()
                    If (selectedEnrollSubjects(i).getSubID() = SubjectIDCB.SelectedItem()) Then
                        canEnroll = False
                    End If
                    i = i + 1
                End While

            Else
                canEnroll = False
            End If
        Else
            canEnroll = False
        End If

        Return canEnroll

    End Function

    Private Sub finalizeEnrollBtn_Click(sender As Object, e As EventArgs) Handles finalizeEnrollBtn.Click
        Coursework_Student.setEnrollment(enrollmentList)
        Dim i As Integer = 0
        While i < Coursework_Student.getNumEnrollment()
            Coursework_Student.getEnrollment(i).enroll(Coursework_Student.getStuID(), selectedEnrollSubjects(i).getSubID(), selectedEnrollClasses(i).getClassID())
            i = i + 1
        End While
        Dim totalFees As Double = Coursework_Student.getOutstandingFee()
        Dim j As Integer = 0
        While (j < selectedEnrollSubjects.Count())
            totalFees = totalFees + selectedEnrollSubjects(j).getFees
            j = j + 1
        End While
        Coursework_Student.setOutStandingFee(totalFees)
        Query = "update managementsystem.student set Stu_OutStandingFee = '" & totalFees & "' where Student_ID= '" & Coursework_Student.getStuID() & "' "
        command = New MySqlCommand(Query, SQLConnection)
        reader = command.ExecuteReader
        reader.Close()
    End Sub

    Private Sub dropClassFromListBtn_Click(sender As Object, e As EventArgs) Handles dropClassFromListBtn.Click
        Dim index As Integer = EnrollmentListDataGridView.CurrentCell.RowIndex
        EnrollmentListDataGridView.Rows.RemoveAt(index)
        selectedEnrollSubjects.RemoveAt(index)
        selectedEnrollClasses.RemoveAt(index)
        enrollmentList.RemoveAt(index)
    End Sub

    'Project
    Private Sub ProjectBtn_Click(sender As Object, e As EventArgs) Handles ProjectBtn.Click
        pnlProjectDropDown.Visible = True
        If projectBtnSize = 0 Then
            Me.pnlProjectDropDown.Size = New Size(Me.pnlProjectDropDown.Size.Width, projectBtnSize)
            Timer1.Start()
        Else
            projectBtnSize = 0
            Me.pnlProjectDropDown.Size = New Size(Me.pnlProjectDropDown.Size.Width, projectBtnSize)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If projectBtnSize > 100 Then
            Timer1.Stop()
        Else
            projectBtnSize = projectBtnSize + 100
            Me.pnlProjectDropDown.Size = New Size(Me.pnlProjectDropDown.Size.Width, 100)
        End If
    End Sub

    Private Sub SelectProjectBtn_Click_1(sender As Object, e As EventArgs) Handles SelectProjectBtn.Click
        changePanel()
        pnlProject.Visible = True
        Try
            Query = "select * from managementsystem.Project, managementsystem.student, managementsystem.programme 
                    where programme.Programme_ID = student.Programme_ID    
                    and student.Programme_ID = project.Programme_ID 
                    and student.student_ID = '" & Coursework_Student.getStuID() & "' "
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            While reader.Read()
                ProjectIDCB.Items.Add(reader.GetString("Project_ID"))
            End While
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error is occured")
        End Try
    End Sub

    Private Sub ProjectIDCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProjectIDCB.SelectedIndexChanged
        Try
            Query = "select * from managementsystem.Project where Project_ID='" & ProjectIDCB.SelectedItem() & "' "
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            reader.Read()
            ProjectTitle.Text = reader.GetString("Project_Title")
            ProjectDescription.Text = reader.GetString("Project_Description")
            selectedProject = New Project(reader.GetString("Project_ID"), reader.GetString("Project_Title"), reader.GetString("Project_Description"))
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error is occured.")
        End Try
    End Sub

    Private Sub SelectBtn_Click(sender As Object, e As EventArgs) Handles SelectBtn.Click
        Try
            selectedProject.selectProject(Coursework_Student.getStuID())
        Catch ex As Exception
            MessageBox.Show("Invalid inputs.")
        End Try
        'Clear text
        ProjectTitle.ResetText()
        ProjectDescription.ResetText()
    End Sub

    Private Sub ViewProjectBtn_Click(sender As Object, e As EventArgs) Handles ViewProjectBtn.Click
        changePanel()
        pnlViewProject.Visible = True

        Try
            Query = "select * from managementsystem.Project where Student_ID = '" & Coursework_Student.getStuID() & "' "
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            reader.Read()
            Project_ID.Text = reader.GetString("Project_ID")
            Project_Title.Text = reader.GetString("Project_Title")
            Project_Description.Text = reader.GetString("Project_Description")
            Staff_ID.Text = reader.GetString("Staff_ID")
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error is occured.")
        End Try
    End Sub

    ''View Class Enrolled
    Private Sub viewClassbtn_Click(sender As Object, e As EventArgs) Handles viewClassbtn.Click
        changePanel()
        enrolledClassDataGrid.Rows.Clear()
        pnlViewClass.Visible = True
        Query = "select * from managementsystem.enrollment ,managementsystem.class,managementsystem.subject where Student_ID= '" & Coursework_Student.getStuID() & "' AND enrollment.Subject_ID = class.Subject_ID and enrollment.Class_ID = class.Class_ID and class.Subject_ID = subject.Subject_ID"
        command = New MySqlCommand(Query, SQLConnection)
        reader = command.ExecuteReader
        While reader.Read()
            Dim subID As String = reader.GetString("Subject_ID")
            Dim subName As String = reader.GetString("Subject_Name")
            Dim classID As String = reader.GetString("Class_ID")
            Dim classDay As String = reader.GetString("Day")
            Dim classTime As String = reader.GetString("Time")
            Dim classVenue As String = reader.GetString("Venue")
            enrolledClassDataGrid.Rows.Add(subID, subName, classID, classDay, classTime, classVenue)
        End While
        reader.Close()
    End Sub

    ''Search Academic staff
    Private Sub SearchBtn_Click(sender As Object, e As EventArgs) Handles SearchBtn.Click
        changePanel()
        pnlSearch.Visible = True
        Dim SDA As New MySqlDataAdapter
        Dim bSource As New BindingSource
        dbDataSet.Rows.Clear()

        Query = "select Staff_ID,Staff_Fname,Staff_Contact_No,Staff_Room,Staff_ConsultationDay,Staff_ConsultationTime,Staff_Email from managementsystem.academic_staff"
        command = New MySqlCommand(Query, SQLConnection)
        SDA.SelectCommand = command
        SDA.Fill(dbDataSet)
        bSource.DataSource = dbDataSet
        searchStaffNameDataGrid.DataSource = bSource
        SDA.Update(dbDataSet)
        Dim i As Integer = 0
        While (i < 7)
            Dim column As DataGridViewColumn = searchStaffNameDataGrid.Columns(i)
            column.Width = 135
            i = i + 1
        End While
    End Sub

    ''Filter data grid view
    Private Sub academicStaffNametxt_OnValueChanged(sender As Object, e As EventArgs) Handles academicStaffNametxt.OnValueChanged
        Dim DV As New DataView(dbDataSet)
        DV.RowFilter = String.Format("Staff_Fname like '%{0}%'", academicStaffNametxt.Text)
        searchStaffNameDataGrid.DataSource = DV
    End Sub

    ''View Transaction Record
    Private Sub viewTransactionRecordbtn_Click(sender As Object, e As EventArgs) Handles viewTransactionRecordbtn.Click
        changePanel()
        pnlViewTransactionRecord.Visible = True
        transactionRecordDatagrid.Rows.Clear()
        Dim Query As String
        Try
            Query = "select * from transaction where Student_ID= '" & Coursework_Student.getStuID() & "' "
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            While reader.Read()
                Dim TransactionID As String = reader.GetString("Transaction_ID")
                Dim AdminID As String = reader.GetString("Admin_ID")
                Dim TransactionDate As String = reader.GetDateTime("Transaction_Date")
                Dim TransactionTime As String = reader.GetString("Transaction_Time")
                Dim ReferenceID As String = reader.GetString("Reference_ID")
                Dim Amount As Double = reader.GetString("Amount")
                transactionRecordDatagrid.Rows.Add(TransactionID, TransactionDate, TransactionTime, ReferenceID, Amount, AdminID)
            End While
            reader.Close()

        Catch ex As Exception
            MessageBox.Show("Error")
        End Try
    End Sub

    'Change panel
    Private Sub changePanel()
        pnlEnroll.Visible = False
        pnlHome.Visible = False
        pnlViewStuProfile.Visible = False
        pnlProject.Visible = False
        pnlViewProject.Visible = False
        pnlProjectDropDown.Visible = False
        pnlViewClass.Visible = False
        pnlSearch.Visible = False
        pnlViewTransactionRecord.Visible = False
    End Sub
End Class