Imports MySql.Data.MySqlClient
Public Class AcademicStaff
    Private Staff_ID As String
    Private Staff_Password As String
    Private Staff_Lname As String
    Private Staff_Fname As String
    Private Staff_IC As String
    Private Staff_Gender As String
    Private Staff_Address As String
    Private Staff_Contact_No As String
    Private Staff_Room As String
    Private Staff_ConsultDay As String
    Private Staff_ConsultTime As String
    Private Staff_Email As String
    Private Staff_Salary As Double

    'Constructor
    Sub New(ByVal Staff_ID As String, ByVal Staff_Password As String, ByVal Staff_Lname As String, ByVal Staff_Fname As String, ByVal Staff_IC As String, ByVal Staff_Gender As String, ByVal Staff_Address As String, ByVal Staff_Contact_No As String, ByVal Staff_Room As String, ByVal Staff_ConsultDay As String, ByVal Staff_ConsultTime As String, ByVal Staff_Email As String, ByVal Staff_Salary As Double)
        Me.Staff_ID = Staff_ID
        Me.Staff_Password = Staff_Password
        Me.Staff_Lname = Staff_Lname
        Me.Staff_Fname = Staff_Fname
        Me.Staff_IC = Staff_IC
        Me.Staff_Gender = Staff_Gender
        Me.Staff_Address = Staff_Address
        Me.Staff_Contact_No = Staff_Contact_No
        Me.Staff_Room = Staff_Room
        Me.Staff_ConsultDay = Staff_ConsultDay
        Me.Staff_ConsultTime = Staff_ConsultTime
        Me.Staff_Email = Staff_Email
        Me.Staff_Salary = Staff_Salary
    End Sub

    Sub New(ByVal Staff_ID As String, ByVal Staff_Password As String)
        Me.Staff_ID = Staff_ID
        Me.Staff_Password = Staff_Password
    End Sub

    Public Function addStaffAcount(ByVal adminID As String)

        Dim Query As String
        Query = " insert into managementsystem.academic_staff (Staff_ID,Staff_Password,Staff_Lname,Staff_Fname,Staff_IC,Staff_Gender,Staff_Address,Staff_Contact_No,Staff_Room,Staff_ConsultationDay,Staff_ConsultationTime,Staff_Email,Staff_Salary,Admin_ID) values ('" & Staff_ID & "','" & Staff_Password & "' , '" & Staff_Lname & "', '" & Staff_Fname & "', '" & Staff_IC & "', '" & Staff_Gender & "','" & Staff_Address & "','" & Staff_Contact_No & "','" & Staff_Room & "','" & Staff_ConsultDay & "','" & Staff_ConsultTime & "','" & Staff_Email & "','" & Staff_Salary & "','" & adminID & "')"
        AdminPage.command = New MySqlCommand(Query, AdminPage.SQLConnection)
        AdminPage.reader = AdminPage.command.ExecuteReader
        AdminPage.reader.Close()
        MessageBox.Show("Staff added")
        Return Nothing

    End Function

    Public Function viewStaffProfile()

        AcademicPage.StaffIDlbl.Text = Staff_ID
        AcademicPage.StaffLnamelbl.Text = Staff_Lname
        AcademicPage.StaffFnamelbl.Text = Staff_Fname
        AcademicPage.StaffIClbl.Text = Staff_IC
        AcademicPage.StaffGenderlbl.Text = Staff_Gender
        AcademicPage.Staffaddresslbl.Text = Staff_Address
        AcademicPage.StaffHplbl.Text = Staff_Contact_No
        AcademicPage.StaffRoomlbl.Text = Staff_Room
        AcademicPage.StaffConsultDaylbl.Text = Staff_ConsultDay
        AcademicPage.StaffConsultTimelbl.Text = Staff_ConsultTime
        AcademicPage.StaffEmaillbl.Text = Staff_Email
        AcademicPage.StaffSalarylbl.Text = Staff_Salary
        AcademicPage.reader.Close()
        Return Nothing

    End Function

    Public Function verifyLogin() As Boolean

        Dim Query As String
        Try
            Query = " select * from managementsystem.academic_staff where Staff_ID= '" & Staff_ID & "' and Staff_Password ='" & Staff_Password & "' "
            LoginPage.command = New MySqlCommand(Query, LoginPage.SQLConnection)
            LoginPage.reader = LoginPage.command.ExecuteReader

            If LoginPage.reader.Read() Then
                LoginPage.reader.Close()
                Return True
            Else
                LoginPage.reader.Close()
                Return False
            End If

        Catch ex As Exception
            MessageBox.Show("Error is occured")
        End Try


        Return Nothing
    End Function

    Public Function getID() As String
        Return Staff_ID
    End Function

    Public Function getLname() As String
        Return Staff_Lname
    End Function

    Public Function getFname() As String
        Return Staff_Fname
    End Function
End Class




