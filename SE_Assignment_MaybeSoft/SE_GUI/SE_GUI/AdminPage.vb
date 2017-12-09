Imports MySql.Data.MySqlClient

Public Class AdminPage
    ' Gui variable
    Dim accountBtnSize = 0
    Dim programBtnSize = 0
    Dim classBtnSize = 0
    Dim AnnouncementBtnSize = 0

    ' Database connection
    Public ServerString As String = "server=localhost;user id=root;database=managementsystem;"
    Public SQLConnection As MySqlConnection = New MySqlConnection
    Public command As MySqlCommand
    Public reader As MySqlDataReader
    Public Query As String

    Dim admin As Admin
    Dim student As Student
    Dim staff As AcademicStaff
    Dim programme As Programme
    Dim programmeList As New List(Of Programme)
    Dim subjectList As New List(Of Subject)
    Dim classList As New List(Of Classes)
    Dim selectedProg As Programme
    Dim selectedSub As Subject
    Dim selectedAnnouncement As Announcement


    'Header panel
    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        Me.Close()
        LoginPage.Close()
        AcademicPage.Close()
        CourseStudentPage.Close()
        ResearchStudentPage.Close()
    End Sub

    Private Sub MinimizeBtn_Click(sender As Object, e As EventArgs) Handles MinimizeBtn.Click
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
    End Sub

    'Logout button
    Private Sub LogoutBtn_Click(sender As Object, e As EventArgs) Handles LogoutBtn.Click

        MessageBox.Show("Logout Successfully")
        LoginPage.Show()
        Me.Hide()

    End Sub

    'Admin page load
    Private Sub AdminPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        Try
            'Select admin details who is logged in to this system from the database 
            Query = " select * FROM managementsystem.admin where Admin_ID= '" & LoginPage.Usernametxt.text & "' "
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            reader.Read()
            'Create a instance of admin who are currently logged in to this sytem
            admin = New Admin(reader.GetString("Admin_ID"), reader.GetString("Admin_Password"), reader.GetString("Admin_Department"))
            reader.Close()

        Catch ex As Exception
            MessageBox.Show("Error is occured")
        End Try


        IDhomelbl.Text = admin.getID()
        Deplbl.Text = "from " + admin.getDepartment()

    End Sub

    'Home panel
    Private Sub HomeBtn_Click(sender As Object, e As EventArgs) Handles HomeBtn.Click
        changePanel()
        pnlHome.Visible = True
        'Display welcome at home page
        IDhomelbl.Text = admin.getID()
        Deplbl.Text = "from " + admin.getDepartment()

    End Sub

    'Account page
    Private Sub AccountBtn_Click_1(sender As Object, e As EventArgs) Handles AccountBtn.Click
        pnlStuDropdown.Visible = True
        pnlProgramDropdown.Visible = False

        If accountBtnSize = 0 Then
            Me.pnlStuDropdown.Size = New Size(Me.pnlStuDropdown.Size.Width, accountBtnSize)
            Timer1.Start()
        Else
            accountBtnSize = 0
            Me.pnlStuDropdown.Size = New Size(Me.pnlStuDropdown.Size.Width, accountBtnSize)
        End If
    End Sub

    Private Sub staffbtn_Click(sender As Object, e As EventArgs) Handles staffbtn.Click
        changePanel()
        pnlStaffAcc.Visible = True

        Query = "select count(*) from managementsystem.academic_staff"
        command = New MySqlCommand(Query, SQLConnection)
        reader = command.ExecuteReader
        reader.Read()
        Dim count As Integer = reader.GetInt32("count(*)")
        reader.Close()

        If (count = 0) Then
            StaffID.Text = "L0"
        Else
            Query = " select Staff_ID FROM managementsystem.academic_staff ORDER BY Staff_ID DESC"
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            reader.Read()

            Dim LastStaff As String
            LastStaff = reader.GetValue(0)

            Dim LatestInteger As Integer
            LatestInteger = LastStaff.Substring(1, LastStaff.Length - 1)

            Dim newInteger As Integer
            newInteger = LatestInteger + 1

            StaffID.Text = "L" & newInteger.ToString()
            reader.Close()
        End If


    End Sub

    Private Sub stubtn_Click(sender As Object, e As EventArgs) Handles stubtn.Click
        changePanel()
        pnlStuAcc.Visible = True

        Query = "select count(*) from managementsystem.student"
        command = New MySqlCommand(Query, SQLConnection)
        reader = command.ExecuteReader
        reader.Read()
        Dim count As Integer = reader.GetInt32("count(*)")
        reader.Close()

        If (count = 0) Then
            IDlbl.Text = "S0"
        Else
            Query = " select Student_ID FROM managementsystem.student ORDER BY Student_ID DESC"
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            reader.Read()

            Dim LastStudent As String
            LastStudent = reader.GetValue(0)

            Dim LatestInteger As Integer
            LatestInteger = LastStudent.Substring(1, LastStudent.Length - 1)

            Dim newInteger As Integer
            newInteger = LatestInteger + 1

            IDlbl.Text = "S" & newInteger.ToString()
            reader.Close()

        End If
        ProgramChoice.Items.Clear()
        Query = "select * from managementsystem.programme"
        command = New MySqlCommand(Query, SQLConnection)
        reader = command.ExecuteReader
        While reader.Read()
            Dim Prog_name = reader.GetString(1)
            ProgramChoice.Items.Add(Prog_name)
        End While
        reader.Close()


    End Sub

    Private Sub viewEditStaffbtn_Click_1(sender As Object, e As EventArgs) Handles viewEditStaffbtn.Click
        changePanel()
        pnlEditStaff.Visible = True
    End Sub

    Private Sub viewEditStubtn_Click(sender As Object, e As EventArgs) Handles viewEditStubtn.Click
        changePanel()
        pnlEditStu.Visible = True

        Try
            Query = "Select programme_name from managementsystem.programme "
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader

            While reader.Read()
                ProgrammeChoice.Items.Add(reader.GetString("Programme_Name"))
            End While

        Catch ex As Exception
            MessageBox.Show("Invalid Error")
        End Try
        reader.Close()

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If accountBtnSize > 220 Then
            Timer1.Stop()
        Else
            accountBtnSize = accountBtnSize + 220
            Me.pnlStuDropdown.Size = New Size(Me.pnlStuDropdown.Size.Width, 220)
        End If
    End Sub

    'Add Student panel
    Private Sub TypeChoice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TypeChoice.SelectedIndexChanged
        If TypeChoice.Text = "Coursework" Then
            CourseMajorTxtbox.Enabled = True
            FieldResearchTxtbox.Enabled = False
        Else
            FieldResearchTxtbox.Enabled = True
            CourseMajorTxtbox.Enabled = False
        End If
    End Sub

    Private Sub AddStuBtn_Click(sender As Object, e As EventArgs) Handles AddStuBtn.Click
        Try
            Dim studentProgramme As Programme
            ''Select what program has been choosen by the student
            Query = "select * from managementsystem.programme where Programme_Name= '" & ProgramChoice.Text & "' "
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            reader.Read()
            studentProgramme = New Programme(reader.GetString("Programme_ID"), reader.GetString("Programme_Name"), reader.GetString("Programme_Type"), reader.GetString("Programme_Fee"))
            reader.Close()

            student = New Student(IDlbl.Text, StuPwTextBox.Text, StuLastNameTxtBox.Text, StuFirstNameTxtbox.Text, ICtxtbox.Text, GenderChoice.Text, AddresstxtBox.Text, ContactNoTextBox.Text, EmailAddressTextBox.Text, TypeChoice.Text, studentProgramme)
            If TypeChoice.Text = "Coursework" Then
                student.addCourseworkStudentAccount(admin.getID(), CourseMajorTxtbox.Text)
            Else
                student.addResearchStudentAccount(admin.getID(), FieldResearchTxtbox.Text)

            End If
        Catch ex As Exception
            MessageBox.Show("Invalid inputs.")
        End Try

    End Sub

    'Add Staff panel
    Private Sub Addstaffbtn_Click(sender As Object, e As EventArgs) Handles Addstaffbtn.Click
        Try
            staff = New AcademicStaff(StaffID.Text, StaffPwdtxtbox.Text, Staff_Lnametxtbox.Text, Staff_Fnametxtbox.Text, Staff_ICtxtbox.Text, Staff_gendertxtbox.Text, Staff_Addresstxtbox.Text, Staff_Contacttxtbox.Text, Staff_roomtxtbox.Text, StaffConsultdaytxtbox.Text, Staff_Consulttimetxtbox.Text, Staff_emailtxtbox.Text, Staff_Salarytxtbox.Text)
            staff.addStaffAcount(admin.getID())

        Catch ex As Exception
            MessageBox.Show("Invalid input")
        End Try
    End Sub

    'View and edit student panel
    Private Sub SearchIDBtn_Click(sender As Object, e As EventArgs) Handles SearchIDBtn.Click

        reader.Close()
        Try
            Query = "Select * from managementsystem.student, managementsystem.programme where Student.Programme_ID=Programme.Programme_ID and Student_ID = '" & SearchIDTxtbox.Text & "' "
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            reader.Read()

            StuIDTxtbox.Enabled = False
            StuIDTxtbox.Text = reader.GetString("Student_ID")
            StuPWTxtbox.Text = reader.GetString("Stu_Password")
            LNameTxtbox.Text = reader.GetString("Stu_Lname")
            FNameTxtbox.Text = reader.GetString("Stu_Fname")
            ProgrammeChoice.Text = reader.GetString("Programme_Name")
            StuTypeChoice.Text = reader.GetString("Stu_Type")
            GenderSelect.Text = reader.GetString("Stu_Gender")
            ContactNoTxtbox.Text = reader.GetString("Stu_Contact_No")
            editStudentAddress.Text = reader.GetString("Stu_Address")
            EmailTxtbox.Text = reader.GetString("Stu_Email")
            ICNoTxtbox.Text = reader.GetString("Stu_IC")


        Catch ex As Exception
            MessageBox.Show("Invalid Student ID")
        End Try
        reader.Close()
    End Sub

    Private Sub UpdateStuBtn_Click(sender As Object, e As EventArgs) Handles UpdateStuBtn.Click
        Try
            Query = "update managementsystem.student set Stu_Password= '" & StuPWTxtbox.Text & "', Stu_Lname= '" & LNameTxtbox.Text & "',Stu_Fname='" & FNameTxtbox.Text & "',Stu_IC='" & ICNoTxtbox.Text & "',Stu_Gender='" & GenderChoice.Text & "',Stu_Address='" & AddresstxtBox.Text & "',Stu_Contact_No='" & ContactNoTxtbox.Text & "',Stu_Email='" & EmailTxtbox.Text & "',Stu_Type='" & StuTypeChoice.Text & "' where Student_ID= '" & SearchIDTxtbox.Text & "' "
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            MessageBox.Show("Student Data Edited Succesfully")
        Catch ex As Exception
            MessageBox.Show("Error is occured")
        End Try

        SearchIDTxtbox.ResetText()
        StuIDTxtbox.ResetText()
        StuPWTxtbox.ResetText()
        LNameTxtbox.ResetText()
        FNameTxtbox.ResetText()
        ICNoTxtbox.ResetText()
        GenderChoice.ResetText()
        AddresstxtBox.ResetText()
        ContactNoTxtbox.ResetText()
        EmailTxtbox.ResetText()
        StuTypeChoice.ResetText()

    End Sub

    'View and edit staff panel
    Private Sub SearchStaffButton_Click(sender As Object, e As EventArgs) Handles SearchStaffButton.Click
        Try
            Query = "select Staff_ID,Staff_Password,Staff_Lname,Staff_Fname,Staff_IC,Staff_Gender,Staff_Address,Staff_Contact_No,Staff_Room,Staff_ConsultationDay,Staff_ConsultationTime,Staff_Email,Staff_Salary from managementsystem.academic_staff where Staff_ID='" & searchStaffTxtbox.Text & "'"
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            reader.Read()
            EditStaffIDTxtbox.Text = reader.GetString(0)
            EditStaffpwdTxtbox.Text = reader.GetString(1)
            EditStaffLastnameTxtbox.Text = reader.GetString(2)
            EditStaffFirstnameTxtbox.Text = reader.GetString(3)
            EditStaffICTxtbox.Text = reader.GetString(4)
            EditgenderChoice.Text = reader.GetString(5)
            EditStaffaddressTxtbox.Text = reader.GetString(6)
            EditStaffHpTxtbox.Text = reader.GetString(7)
            EditStaffRoomTxtbox.Text = reader.GetString(8)
            EditStaffConsultationDayTxtbox.Text = reader.GetString(9)
            EditConsultationTimeTxtbox.Text = reader.GetString(10)
            EditEmailTxtbox.Text = reader.GetString(11)
            EditSalaryTxtbox.Text = reader.GetString(12)
        Catch ex As Exception
            MessageBox.Show("Invalid Staff ID")
            searchStaffTxtbox.ResetText()
        End Try
        reader.Close()
    End Sub

    Private Sub EditStaffButton_Click(sender As Object, e As EventArgs) Handles EditStaffButton.Click
        Try
            Query = "update managementsystem.academic_staff set Staff_Password= '" & EditStaffpwdTxtbox.Text & "', Staff_Lname= '" & EditStaffLastnameTxtbox.Text & "',Staff_Fname='" & EditStaffFirstnameTxtbox.Text & "',Staff_IC='" & EditStaffICTxtbox.Text & "',Staff_Gender='" & EditgenderChoice.Text & "',Staff_Address='" & EditStaffaddressTxtbox.Text & "',Staff_Contact_No='" & EditStaffHpTxtbox.Text & "',Staff_Room='" & EditStaffRoomTxtbox.Text & "',Staff_ConsultationDay='" & EditStaffConsultationDayTxtbox.Text & "',Staff_ConsultationTime='" & EditConsultationTimeTxtbox.Text & "',Staff_Email='" & EditEmailTxtbox.Text & "',Staff_Salary='" & EditSalaryTxtbox.Text & "' where Staff_ID = '" & searchStaffTxtbox.Text & "'"
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            MessageBox.Show("Staff Data Edited")
        Catch ex As Exception
            MessageBox.Show("Invaid Inputs.")
        End Try

        reader.Close()
        EditStaffIDTxtbox.ResetText()
        EditStaffpwdTxtbox.ResetText()
        EditStaffLastnameTxtbox.ResetText()
        EditStaffFirstnameTxtbox.ResetText()
        EditStaffICTxtbox.ResetText()
        EditgenderChoice.ResetText()
        EditStaffaddressTxtbox.ResetText()
        EditStaffHpTxtbox.ResetText()
        EditStaffRoomTxtbox.ResetText()
        EditStaffConsultationDayTxtbox.ResetText()
        EditConsultationTimeTxtbox.ResetText()
        EditEmailTxtbox.ResetText()
        EditSalaryTxtbox.ResetText()
        searchStaffTxtbox.ResetText()
    End Sub

    'Programme
    Private Sub ProgramcreationBtn_Click(sender As Object, e As EventArgs) Handles ProgramcreationBtn.Click
        pnlProgramDropdown.Visible = True
        pnlStuDropdown.Visible = False
        If programBtnSize = 0 Then
            Me.pnlProgramDropdown.Size = New Size(Me.pnlProgramDropdown.Size.Width, programBtnSize)
            Timer2.Start()
        Else
            programBtnSize = 0
            Me.pnlProgramDropdown.Size = New Size(Me.pnlProgramDropdown.Size.Width, programBtnSize)
        End If
    End Sub

    Private Sub addProgrambtn_Click(sender As Object, e As EventArgs) Handles addProgrambtn.Click
        changePanel()
        pnlProg.Visible = True

        Query = "select count(*) from managementsystem.programme"
        command = New MySqlCommand(Query, SQLConnection)
        reader = command.ExecuteReader
        reader.Read()
        Dim count As Integer = reader.GetInt32("count(*)")
        reader.Close()

        If (count = 0) Then
            ProgramIDlbl.Text = "P0"
        Else
            Query = " select Programme_ID FROM managementsystem.programme ORDER BY Programme_ID DESC"
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            reader.Read()
            Dim LastProgramme As String
            LastProgramme = reader.GetValue(0)

            Dim LatestInteger As Integer
            LatestInteger = LastProgramme.Substring(1, LastProgramme.Length - 1)

            Dim newInteger As Integer
            newInteger = LatestInteger + 1

            ProgramIDlbl.Text = "P" & newInteger.ToString()
            reader.Close()
        End If


    End Sub

    Private Sub editProgrambtn_Click(sender As Object, e As EventArgs) Handles editProgrambtn.Click
        changePanel()
        pnlEditProgramme.Visible = True

        ProgrammeListCB.Items.Clear()
        'Select programmes from database
        Query = "select * from managementsystem.Programme ORDER BY Programme_ID DESC"
        command = New MySqlCommand(Query, SQLConnection)
        reader = command.ExecuteReader
        While reader.Read()
            Dim programmeNameDB = reader.GetString("Programme_Name")
            ProgrammeListCB.Items.Add(programmeNameDB)
        End While
        reader.Close()
    End Sub

    Private Sub Timer2_Tick_1(sender As Object, e As EventArgs) Handles Timer2.Tick
        If programBtnSize > 100 Then
            Timer2.Stop()
        Else
            programBtnSize = programBtnSize + 100
            Me.pnlProgramDropdown.Size = New Size(Me.pnlProgramDropdown.Size.Width, 100)
        End If
    End Sub

    'Add programme panel
    Private Sub ProgrammetypeCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProgrammetypeCB.SelectedIndexChanged
        If ProgrammetypeCB.Text = "Coursework" Then
            ProgFeeTxtbox.Enabled = False
            ProgFeeTxtbox.Text = 0
        Else
            ProgFeeTxtbox.ResetText()
            ProgFeeTxtbox.Enabled = True
        End If
    End Sub

    Private Sub Addtolistbtn_Click(sender As Object, e As EventArgs) Handles Addtolistbtn.Click
        Try
            programmeList.Add(New Programme(ProgramIDlbl.Text, ProgNameTxtbox.Text, ProgrammetypeCB.Text, ProgFeeTxtbox.Text))
            ProgListDataGridView.Rows.Add(ProgramIDlbl.Text, ProgNameTxtbox.Text, ProgrammetypeCB.Text, ProgFeeTxtbox.Text)
            Dim lastProgramme As String = ProgramIDlbl.Text
            Dim lastInteger As Integer = lastProgramme.Substring(1, lastProgramme.Length - 1)
            Dim newInteger As Integer = lastInteger + 1
            ProgramIDlbl.Text = "P" & newInteger.ToString()
            ProgNameTxtbox.ResetText()
            ProgrammetypeCB.Enabled = True
            ProgrammetypeCB.SelectedItem = Nothing
            ProgFeeTxtbox.ResetText()
        Catch ex As Exception
            MessageBox.Show("Invalid inputs")
        End Try
    End Sub

    Private Sub AddProgrammeBtn_Click(sender As Object, e As EventArgs) Handles AddProgrammeBtn.Click
        Try
            Dim i As Integer = 0
            While i < programmeList.Count()
                programmeList.Item(i).addProgramme(admin.getID())
                i = i + 1
            End While
            MessageBox.Show("Succesfully added")
        Catch ex As Exception
            MessageBox.Show("Invalid inputs")
        End Try
    End Sub

    'Edit programme panel
    Private Sub ProgrammeListCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProgrammeListCB.SelectedIndexChanged

        Query = "select * from managementsystem.programme where Programme_Name='" & ProgrammeListCB.Text & "'"
        command = New MySqlCommand(Query, SQLConnection)
        reader = command.ExecuteReader
        reader.Read()
        progIDlbl2.Text = reader.GetString("Programme_ID")
        progTypelbl.Text = reader.GetString("Programme_Type")
        Prognametxtbox2.Text = reader.GetString("Programme_Name")
        reader.Close()

    End Sub

    Private Sub editProgrammeBtn_Click(sender As Object, e As EventArgs) Handles editProgrammeBtn.Click
        If ProgrammeListCB.Text = "" Then
            MessageBox.Show("Please select a programme to edit")
        Else
            Query = "update managementsystem.programme set Programme_Name='" & Prognametxtbox2.Text & "' where Programme_ID='" & progIDlbl2.Text & "'  "
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            reader.Close()
            MessageBox.Show("Edit successfully")
            progIDlbl2.ResetText()
            progTypelbl.ResetText()
            Prognametxtbox2.ResetText()
            ProgrammeListCB.Items.Clear()
            'Select all updated programmes from database after editing
            Query = "select * from managementsystem.Programme"
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            While reader.Read()
                Dim programmeNameDB = reader.GetString("Programme_Name")
                ProgrammeListCB.Items.Add(programmeNameDB)
            End While
            reader.Close()
        End If
    End Sub

    'Subject
    Private Sub SubjectCreationBtn_Click(sender As Object, e As EventArgs) Handles SubjectCreationBtn.Click
        changePanel()
        pnlSub.Visible = True

        ProgNameCB.Items.Clear()

        'Select programmes from database
        Query = "select * from managementsystem.Programme"
        command = New MySqlCommand(Query, SQLConnection)
        reader = command.ExecuteReader
        While reader.Read()
            Dim progNamefromDB = reader.GetString("Programme_Name")
            ProgNameCB.Items.Add(progNamefromDB)
        End While
        reader.Close()

    End Sub

    'Add subject panel
    Private Sub AddSubToListBtn_Click(sender As Object, e As EventArgs) Handles AddSubToListBtn.Click
        Try
            SubListDataGridView.Rows.Add(ProgNameCB.Text, SubIDTxtbox.Text, SubNameTxtbox.Text, SubCHTxtbox.Text, SubFeeTxtbox.Text)
            subjectList.Add(New Subject(SubIDTxtbox.Text, SubNameTxtbox.Text, SubCHTxtbox.Text, SubFeeTxtbox.Text))
        Catch ex As Exception
            MessageBox.Show("Invalid Inputs")
        End Try
        ProgNameCB.Enabled = False
    End Sub

    Private Sub FinalAddSubBtn_Click(sender As Object, e As EventArgs) Handles FinalAddSubBtn.Click
        Try
            selectedProg.setProgrammeSub(subjectList)
            Dim i As Integer = 0
            While i < selectedProg.getSubjectSize()
                selectedProg.getProgrammeSub(i).addSubject(selectedProg.getProgrammeID())
                i = i + 1
            End While

            Dim totalCost As Double = selectedProg.getProgrammeFee()
            Dim j As Integer = 0
            While j < subjectList.Count
                totalCost = totalCost + subjectList(j).getFees()
                j = j + 1
            End While
            Dim Query As String
            Query = "update managementsystem.programme set Programme_Fee='" & totalCost & "' where Programme_ID='" & selectedProg.getProgrammeID() & "'  "
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error is occured")
        End Try
    End Sub

    Private Sub ProgNameDD_onItemSelected(sender As Object, e As EventArgs) Handles ProgNameCB.SelectedIndexChanged

        'Get selected programme details and then store inside an object
        Query = "select * from managementsystem.programme where Programme_Name='" & ProgNameCB.SelectedItem() & "' "
        command = New MySqlCommand(Query, SQLConnection)
        reader = command.ExecuteReader
        reader.Read()
        selectedProg = New Programme(reader.GetString("Programme_ID"), reader.GetString("Programme_Name"), reader.GetString("Programme_Type"), reader.GetDouble("Programme_Fee"))
        reader.Close()

    End Sub

    'Class
    Private Sub Classcreationbtn_Click(sender As Object, e As EventArgs) Handles Classcreationbtn.Click
        changePanel()
        pnlClass.Visible = True
        ProgNameCB2.Items.Clear()

        'Select programmes from database
        Query = "select * from managementsystem.Programme"
        command = New MySqlCommand(Query, SQLConnection)
        reader = command.ExecuteReader
        While reader.Read()
            Dim progNamefromDB = reader.GetString("Programme_Name")
            ProgNameCB2.Items.Add(progNamefromDB)
        End While
        reader.Close()
    End Sub

    'Add Class panel
    Private Sub AddClassToListBtn_Click(sender As Object, e As EventArgs) Handles AddClassToListBtn.Click
        Try
            ClassListDataGrid.Rows.Add(ClassIDTxtbox.Text, DayCB.Text, TimeCB.Text, VenueCB.Text, ClassSizeTxtbox.Text)
            classList.Add(New Classes(ClassIDTxtbox.Text, DayCB.Text, TimeCB.Text, VenueCB.Text, ClassSizeTxtbox.Text))
            ProgNameCB2.Enabled = False
            SubNameCB.Enabled = False
        Catch ex As Exception
            MessageBox.Show("Invalid Inputs.")
        End Try
    End Sub

    Private Sub ProgNameCB2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProgNameCB2.SelectedIndexChanged

        SubNameCB.Items.Clear()

        'Select subject from database
        Query = "select * from managementsystem.Subject, managementsystem.Programme where Subject.Programme_ID = Programme.Programme_ID and Programme.Programme_Name = '" & ProgNameCB2.SelectedItem() & "' "
        command = New MySqlCommand(Query, SQLConnection)
        reader = command.ExecuteReader
        While reader.Read()
            Dim subNamefromDB = reader.GetString("Subject_Name")
            SubNameCB.Items.Add(subNamefromDB)
        End While
        reader.Close()


    End Sub

    Private Sub SubNameCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SubNameCB.SelectedIndexChanged

        'Get selected subject details and then store inside an object
        Query = "select * from managementsystem.Subject where Subject_Name='" & SubNameCB.SelectedItem() & "' "
        command = New MySqlCommand(Query, SQLConnection)
        reader = command.ExecuteReader
        reader.Read()
        selectedSub = New Subject(reader.GetString("Subject_ID"), reader.GetString("Subject_Name"), reader.GetInt16("Subject_Credit_Hour"), reader.GetDouble("Subject_Fee"))
        reader.Close()

    End Sub

    Private Sub FinalAddClassBtn_Click(sender As Object, e As EventArgs) Handles FinalAddClassBtn.Click
        Try
            selectedSub.setSubjectClass(classList)
            Dim i As Integer = 0
            While i < selectedSub.getClassSize()
                selectedSub.getSubjectClass(i).addClass(selectedSub.getSubID())
                i = i + 1
            End While
        Catch ex As Exception
            MessageBox.Show("Invalid Inputs")
        End Try
    End Sub

    'Annoucement
    Private Sub AnnouncementBtn_Click(sender As Object, e As EventArgs) Handles AnnouncementBtn.Click
        pnlProgramDropdown.Visible = False
        pnlStuDropdown.Visible = False
        pnlAnnouncementDropDown.Visible = True
        If AnnouncementBtnSize = 0 Then
            Me.pnlAnnouncementDropDown.Size = New Size(Me.pnlAnnouncementDropDown.Size.Width, AnnouncementBtnSize)
            Timer4.Start()
        Else
            AnnouncementBtnSize = 0
            Me.pnlAnnouncementDropDown.Size = New Size(Me.pnlAnnouncementDropDown.Size.Width, AnnouncementBtnSize)
        End If
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        If AnnouncementBtnSize > 100 Then
            Timer4.Stop()
        Else
            AnnouncementBtnSize = AnnouncementBtnSize + 100
            Me.pnlAnnouncementDropDown.Size = New Size(Me.pnlAnnouncementDropDown.Size.Width, 100)
        End If
    End Sub

    'Add Announcement
    Private Sub AddAnnounceBtn_Click(sender As Object, e As EventArgs) Handles AddAnnounceBtn.Click
        changePanel()
        pnlAnnoucement.Visible = True

        Query = "select count(*) from managementsystem.announcement"
        command = New MySqlCommand(Query, SQLConnection)
        reader = command.ExecuteReader
        reader.Read()
        Dim count As Integer = reader.GetInt32("count(*)")
        reader.Close()

        If (count = 0) Then
            AnnoucementID.Text = "A0"
        Else
            Query = " select Announcement_ID FROM managementsystem.Announcement ORDER BY Announcement_ID DESC"
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            reader.Read()

            Dim lastAnnouncement As String
            lastAnnouncement = reader.GetString("Announcement_ID")

            Dim lastInteger As Integer
            lastInteger = lastAnnouncement.Substring(1, lastAnnouncement.Length - 1)

            Dim newInteger As Integer
            newInteger = lastInteger + 1

            AnnoucementID.Text = "A" + newInteger.ToString()

            reader.Close()
        End If

    End Sub

    'Drop announcement
    Private Sub DropAnnounceBtn_Click(sender As Object, e As EventArgs) Handles DropAnnounceBtn.Click
        changePanel()
        pnlDropAnnouncement.Visible = True
    End Sub

    'Add Announcement btn
    Private Sub addAnnouncementBtn_Click(sender As Object, e As EventArgs) Handles addAnnouncementBtn.Click
        Try
            Dim announcement As Announcement
            announcement = New Announcement(AnnoucementID.Text, AnnoucementDetailsTxtbox.Text)
            announcement.addAnnoucement(admin.getID())
        Catch ex As Exception
            MessageBox.Show("Invalid inputs.")
        End Try

        'Clear text box
        SearchAnnouncementIDTxtbox.ResetText()
        AnnouncementDetailsTxtbox.ResetText()
    End Sub

    ''Drop Announcement btn
    Private Sub dropBtn_Click(sender As Object, e As EventArgs) Handles dropBtn.Click
        Try
            selectedAnnouncement.dropAnnouncement()
        Catch ex As Exception
            MessageBox.Show("Invalid inputs.")
        End Try
        'Clear text box
        SearchAnnouncementIDTxtbox.ResetText()
        AnnouncementDetailsTxtbox.ResetText()
    End Sub

    ''Search Announcement ID
    Private Sub SearchAnnouncementIDBtn_Click(sender As Object, e As EventArgs) Handles SearchAnnouncementIDBtn.Click

        Try
            Query = "Select * from managementsystem.announcement where Announcement_ID = '" & SearchAnnouncementIDTxtbox.Text & "'"
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            While (reader.Read())
                AnnouncementDetailsTxtbox.Text = reader.GetString("Announcement_Details")
                selectedAnnouncement = New Announcement(reader.GetString("Announcement_ID"), reader.GetString("Announcement_Details"))
            End While
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error is occured")
        End Try

    End Sub

    '' Transaction
    Private Sub TransactionBtn_Click(sender As Object, e As EventArgs) Handles TransactionBtn.Click
        changePanel()
        pnlTransaction.Visible = True

        Query = "select count(*) from managementsystem.transaction"
        command = New MySqlCommand(Query, SQLConnection)
        reader = command.ExecuteReader
        reader.Read()
        Dim count As Integer = reader.GetInt32("count(*)")
        reader.Close()

        If (count = 0) Then
            transactionIDlbl1.Text = "T0"
        Else
            Query = " select Transaction_ID FROM managementsystem.transaction ORDER BY Transaction_ID DESC"
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            reader.Read()
            Dim LastTransaction As String
            LastTransaction = reader.GetString("Transaction_ID")
            Dim LatestInteger As Integer
            LatestInteger = LastTransaction.Substring(1, LastTransaction.Length - 1)
            Dim newInteger As Integer
            newInteger = LatestInteger + 1
            transactionIDlbl1.Text = "T" & newInteger.ToString()
            reader.Close()
        End If
    End Sub

    ''Search Student ID in transaction panel
    Private Sub searchBtn1_Click(sender As Object, e As EventArgs) Handles searchBtn1.Click
        Try
            Query = "Select * from managementsystem.student where Student_ID = '" & stuIDtxtbox1.Text & "' "
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            reader.Read()
            stuID3.Text = reader.GetString("Student_ID")
            stuFnamelbl1.Text = reader.GetString("Stu_Fname")
            stuLname1.Text = reader.GetString("Stu_Lname")
            outstandingFeeslbl.Text = reader.GetString("Stu_OutstandingFee")
        Catch ex As Exception
            MessageBox.Show("Invalid Student ID")
        End Try
        reader.Close()
    End Sub

    ''Finish Payment
    Private Sub paymentbtn_Click(sender As Object, e As EventArgs) Handles paymentbtn.Click
        Try
            Dim stuTransaction As Transaction
            stuTransaction = New Transaction(transactionIDlbl1.Text, referenceIDtxtbox.Text, amountTxtbox.Text)
            stuTransaction.performPayment(admin.getID(), stuID3.Text)
            Query = "update managementsystem.student set Stu_OutstandingFee = '" & outstandingFeeslbl.Text & "'-'" & stuTransaction.getTransactionAmount() & "'  where Student_ID = '" & stuID3.Text & "'"
            command = New MySqlCommand(Query, SQLConnection)
            reader = command.ExecuteReader
            reader.Close()
            Dim LastTransaction As String
            LastTransaction = transactionIDlbl1.Text
            Dim LatestInteger As Integer
            LatestInteger = LastTransaction.Substring(1, LastTransaction.Length - 1)
            Dim newInteger As Integer
            newInteger = LatestInteger + 1
            transactionIDlbl1.Text = "T" & newInteger.ToString()
            stuID3.ResetText()
            stuFnamelbl1.ResetText()
            stuLname1.ResetText()
            outstandingFeeslbl.ResetText()
            amountTxtbox.ResetText()
            referenceIDtxtbox.ResetText()
        Catch ex As Exception
            MessageBox.Show("Error is occured.")
        End Try

    End Sub

    'Change panel
    Private Sub changePanel()
        pnlHome.Visible = False
        pnlProg.Visible = False
        pnlStuAcc.Visible = False
        pnlEditStu.Visible = False
        pnlEditStaff.Visible = False
        pnlStaffAcc.Visible = False
        pnlEditProgramme.Visible = False
        pnlSub.Visible = False
        pnlClass.Visible = False
        pnlStuDropdown.Visible = False
        pnlProgramDropdown.Visible = False
        pnlAnnoucement.Visible = False
        pnlDropAnnouncement.Visible = False
        pnlTransaction.Visible = False
    End Sub

End Class



