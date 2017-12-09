Imports MySql.Data.MySqlClient

Public Class CourseworkStudent
    Inherits Student

    Private Course_Major As String

    Sub New(ByVal Student_ID As String, ByVal Stu_Password As String, ByVal Stu_Lname As String, ByVal Stu_Fname As String, ByVal Stu_IC As String, ByVal Stu_Gender As String, ByVal Stu_Address As String, ByVal Stu_Contact_No As String, ByVal Stu_Email As String, ByVal Stu_OutstandingFee As Double, ByVal Stu_Type As String, ByVal Stu_Programme As Programme)
        MyBase.New(Student_ID, Stu_Password, Stu_Lname, Stu_Fname, Stu_IC, Stu_Gender, Stu_Address, Stu_Contact_No, Stu_Email, Stu_OutstandingFee, Stu_Type, Stu_Programme)
    End Sub

    Public Function getMajor() As String
        Return Course_Major
    End Function

    Public Function setMajor(ByVal course_major As String)
        Me.Course_Major = course_major
        Return Nothing
    End Function

    Public Function viewCourseWorkStuProfile()

        CourseStudentPage.StuIDlbl2.Text = Student_ID
        CourseStudentPage.StuPWlbl2.Text = Stu_Password
        CourseStudentPage.LNamelbl2.Text = Stu_Lname
        CourseStudentPage.FNamelbl2.Text = Stu_Fname
        CourseStudentPage.StuProglbl2.Text = Stu_Programme.getProgrammeName()
        CourseStudentPage.StuTypelbl2.Text = Stu_Type
        CourseStudentPage.Genderlbl2.Text = Stu_Gender
        CourseStudentPage.ContactNolbl2.Text = Stu_Contact_No
        CourseStudentPage.Addresstxtbox.Text = Stu_Address
        CourseStudentPage.Emaillbl2.Text = Stu_Email
        CourseStudentPage.ICNolbl2.Text = Stu_IC
        CourseStudentPage.OutStandingFee.Text = Stu_OutstandingFee

        Return Nothing
    End Function


End Class
