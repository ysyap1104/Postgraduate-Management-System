Imports MySql.Data.MySqlClient
Public Class ResearchStudent
    Inherits Student

    Private Field_Research As String

    Sub New(ByVal Student_ID As String, ByVal Stu_Password As String, ByVal Stu_Lname As String, ByVal Stu_Fname As String, ByVal Stu_IC As String, ByVal Stu_Gender As String, ByVal Stu_Address As String, ByVal Stu_Contact_No As String, ByVal Stu_Email As String, ByVal Stu_OutstandingFee As Double, ByVal Stu_Type As String, ByVal Stu_Programme As Programme)
        MyBase.New(Student_ID, Stu_Password, Stu_Lname, Stu_Fname, Stu_IC, Stu_Gender, Stu_Address, Stu_Contact_No, Stu_Email, Stu_OutstandingFee, Stu_Type, Stu_Programme)
    End Sub

    Public Function viewResearchStuProfile()

        ResearchStudentPage.StuIDlbl2.Text = Student_ID
        ResearchStudentPage.StuPWlbl2.Text = Stu_Password
        ResearchStudentPage.LNamelbl2.Text = Stu_Lname
        ResearchStudentPage.FNamelbl2.Text = Stu_Fname
        ResearchStudentPage.StuProglbl2.Text = Stu_Programme.getProgrammeName()
        ResearchStudentPage.StuTypelbl2.Text = Stu_Type
        ResearchStudentPage.Genderlbl2.Text = Stu_Gender
        ResearchStudentPage.ContactNolbl2.Text = Stu_Contact_No
        ResearchStudentPage.Addresstxtbox.Text = Stu_Address
        ResearchStudentPage.Emaillbl2.Text = Stu_Email
        ResearchStudentPage.ICNolbl2.Text = Stu_IC
        ResearchStudentPage.OutStandingFee.Text = Stu_OutstandingFee

        Return Nothing
    End Function




End Class
