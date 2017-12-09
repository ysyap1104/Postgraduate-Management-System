Imports MySql.Data.MySqlClient
Public Class Student
    Protected Student_ID As String
    Protected Stu_Password As String
    Protected Stu_Lname As String
    Protected Stu_Fname As String
    Protected Stu_IC As String
    Protected Stu_Gender As String
    Protected Stu_Address As String
    Protected Stu_Contact_No As String
    Protected Stu_Email As String
    Protected Stu_OutstandingFee As Double
    Protected Stu_Type As String
    Protected Stu_Programme As Programme
    Protected Stu_enrollments As List(Of Enrollment)

    Sub New(ByVal Student_ID As String, ByVal Stu_Password As String, ByVal Stu_Lname As String, ByVal Stu_Fname As String, ByVal Stu_IC As String, ByVal Stu_Gender As String, ByVal Stu_Address As String, ByVal Stu_Contact_No As String, ByVal Stu_Email As String, ByVal Stu_OutstandingFee As Double, ByVal Stu_Type As String, ByVal Stu_Programme As Programme)
        Me.Student_ID = Student_ID
        Me.Stu_Password = Stu_Password
        Me.Stu_Lname = Stu_Lname
        Me.Stu_Fname = Stu_Fname
        Me.Stu_IC = Stu_IC
        Me.Stu_Gender = Stu_Gender
        Me.Stu_Address = Stu_Address
        Me.Stu_Contact_No = Stu_Contact_No
        Me.Stu_Email = Stu_Email
        Me.Stu_OutstandingFee = Stu_OutstandingFee
        Me.Stu_Type = Stu_Type
        Me.Stu_Programme = Stu_Programme
    End Sub

    Sub New(ByVal Student_ID As String, ByVal Stu_Password As String, ByVal Stu_Lname As String, ByVal Stu_Fname As String, ByVal Stu_IC As String, ByVal Stu_Gender As String, ByVal Stu_Address As String, ByVal Stu_Contact_No As String, ByVal Stu_Email As String, ByVal Stu_Type As String, ByVal Stu_Programme As Programme)
        Me.Student_ID = Student_ID
        Me.Stu_Password = Stu_Password
        Me.Stu_Lname = Stu_Lname
        Me.Stu_Fname = Stu_Fname
        Me.Stu_IC = Stu_IC
        Me.Stu_Gender = Stu_Gender
        Me.Stu_Address = Stu_Address
        Me.Stu_Contact_No = Stu_Contact_No
        Me.Stu_Email = Stu_Email
        Me.Stu_Type = Stu_Type
        Me.Stu_Programme = Stu_Programme
    End Sub

    Sub New(ByVal Student_ID As String, ByVal Stu_Password As String)

        Me.Student_ID = Student_ID
        Me.Stu_Password = Stu_Password

    End Sub

    Public Function addResearchStudentAccount(ByVal adminID As String, ByVal field_research As String)
        Dim programmeFee As Double
        programmeFee = Stu_Programme.getProgrammeFee
        Dim Query As String
        Try
            Query = " insert into managementsystem.student (Student_ID,Stu_Password,Stu_Lname,Stu_Fname,Stu_IC,Stu_Gender,Stu_Address,Stu_Contact_No,Stu_Email,Stu_OutstandingFee,Stu_Type,Admin_ID,Programme_ID) values ('" & Student_ID & "','" & Stu_Password & "' , '" & Stu_Lname & "', '" & Stu_Fname & "', '" & Stu_IC & "', '" & Stu_Gender & "','" & Stu_Address & "','" & Stu_Contact_No & "','" & Stu_Email & "','" & programmeFee & "','" & Stu_Type & "','" & adminID & "','" & Stu_Programme.getProgrammeID() & "')"
            AdminPage.command = New MySqlCommand(Query, AdminPage.SQLConnection)
            AdminPage.reader = AdminPage.command.ExecuteReader
            AdminPage.reader.Close()

            Query = "insert into managementsystem.research (Student_ID, field_research) values ('" & Student_ID & "', '" & field_research & "') "
            AdminPage.command = New MySqlCommand(Query, AdminPage.SQLConnection)
            AdminPage.reader = AdminPage.command.ExecuteReader
            AdminPage.reader.Close()


            MessageBox.Show("Succesfully add")
        Catch ex As Exception
            MessageBox.Show("Error is ocurred")
        End Try

        Return Nothing

    End Function

    Public Function addCourseworkStudentAccount(ByVal adminID As String, ByVal course_major As String)
        Try
            Dim Query As String

            Query = " insert into managementsystem.student (Student_ID,Stu_Password,Stu_Lname,Stu_Fname,Stu_IC,Stu_Gender,Stu_Address,Stu_Contact_No,Stu_Email,Stu_Type,Admin_ID,Programme_ID) values ('" & Student_ID & "','" & Stu_Password & "' , '" & Stu_Lname & "', '" & Stu_Fname & "', '" & Stu_IC & "', '" & Stu_Gender & "','" & Stu_Address & "','" & Stu_Contact_No & "','" & Stu_Email & "','" & Stu_Type & "','" & adminID & "','" & Stu_Programme.getProgrammeID() & "')"
            AdminPage.command = New MySqlCommand(Query, AdminPage.SQLConnection)
            AdminPage.reader = AdminPage.command.ExecuteReader
            AdminPage.reader.Close()

            Query = "insert into managementsystem.coursework values('" & Student_ID & "','" & course_major & "' )"
            AdminPage.command = New MySqlCommand(Query, AdminPage.SQLConnection)
            AdminPage.reader = AdminPage.command.ExecuteReader
            AdminPage.reader.Close()

            MessageBox.Show("Succesfully add")
        Catch ex As Exception
            MessageBox.Show("Error is ocurred")
        End Try

        Return Nothing

    End Function

    Public Function verifyLogin() As Boolean

        Dim Query As String
        Try
            Query = " select * from managementsystem.student where Student_ID= '" & Student_ID & "' and Stu_Password ='" & Stu_Password & "' "
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

    Public Function getStuType() As String

        Dim Query As String
        Try
            Query = " select Stu_Type from managementsystem.student where student_ID= '" & Student_ID & "' "
            LoginPage.command = New MySqlCommand(Query, LoginPage.SQLConnection)
            LoginPage.reader = LoginPage.command.ExecuteReader
            LoginPage.reader.Read()
            Stu_Type = LoginPage.reader.GetString("Stu_Type")
            LoginPage.reader.Close()
            Return Stu_Type

        Catch ex As Exception
            MessageBox.Show("Error is occured")
        End Try

        Return Nothing
    End Function

    Public Function getStuID() As String
        Return Student_ID
    End Function

    Public Function getLname() As String
        Return Stu_Lname
    End Function

    Public Function getFname() As String
        Return Stu_Fname
    End Function

    Public Function setEnrollment(ByVal enrollment As List(Of Enrollment))
        Stu_enrollments = enrollment
        Return Nothing
    End Function

    Public Function getNumEnrollment() As Integer
        Return Stu_enrollments.Count()
    End Function

    Public Function getEnrollment(ByVal index As Integer) As Enrollment
        Return Stu_enrollments(index)
    End Function

    Public Function getOutstandingFee() As Double
        Return Stu_OutstandingFee
    End Function

    Public Function setOutStandingFee(ByVal fee As Double)
        Me.Stu_OutstandingFee = fee
        Return Nothing
    End Function

End Class
