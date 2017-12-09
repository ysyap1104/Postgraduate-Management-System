<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginPage
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginPage))
        Me.BunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.UsernameHelp = New System.Windows.Forms.PictureBox()
        Me.pwdhelp = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LoginBtn = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.Passwordtxt = New Bunifu.Framework.UI.BunifuTextbox()
        Me.Usernametxt = New Bunifu.Framework.UI.BunifuTextbox()
        Me.Header = New System.Windows.Forms.Panel()
        Me.MinimizeBtn = New System.Windows.Forms.PictureBox()
        Me.CloseBtn = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.AnnouncementDetailsLbl2 = New System.Windows.Forms.Label()
        Me.AnnouncementDetailslbl1 = New System.Windows.Forms.Label()
        Me.AnnouncementIDLbl2 = New System.Windows.Forms.Label()
        Me.AnnouncementIDLbl1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BunifuDragControl1 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.MetroUserControl1 = New MetroFramework.Controls.MetroUserControl()
        Me.MetroToolTip1 = New MetroFramework.Components.MetroToolTip()
        Me.Panel1.SuspendLayout()
        CType(Me.UsernameHelp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pwdhelp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Header.SuspendLayout()
        CType(Me.MinimizeBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CloseBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BunifuElipse1
        '
        Me.BunifuElipse1.ElipseRadius = 5
        Me.BunifuElipse1.TargetControl = Me
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.UsernameHelp)
        Me.Panel1.Controls.Add(Me.pwdhelp)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.LoginBtn)
        Me.Panel1.Controls.Add(Me.Passwordtxt)
        Me.Panel1.Controls.Add(Me.Usernametxt)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(255, 404)
        Me.Panel1.TabIndex = 0
        '
        'UsernameHelp
        '
        Me.UsernameHelp.Image = CType(resources.GetObject("UsernameHelp.Image"), System.Drawing.Image)
        Me.UsernameHelp.Location = New System.Drawing.Point(203, 163)
        Me.UsernameHelp.Name = "UsernameHelp"
        Me.UsernameHelp.Size = New System.Drawing.Size(32, 32)
        Me.UsernameHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.UsernameHelp.TabIndex = 10
        Me.UsernameHelp.TabStop = False
        Me.MetroToolTip1.SetToolTip(Me.UsernameHelp, "Correct username is required ")
        '
        'pwdhelp
        '
        Me.pwdhelp.Image = CType(resources.GetObject("pwdhelp.Image"), System.Drawing.Image)
        Me.pwdhelp.Location = New System.Drawing.Point(203, 212)
        Me.pwdhelp.Name = "pwdhelp"
        Me.pwdhelp.Size = New System.Drawing.Size(32, 32)
        Me.pwdhelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pwdhelp.TabIndex = 11
        Me.pwdhelp.TabStop = False
        Me.MetroToolTip1.SetToolTip(Me.pwdhelp, "Password is case sensitive")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(22, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(215, 74)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Login To " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Your Account"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LoginBtn
        '
        Me.LoginBtn.Activecolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.LoginBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.LoginBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LoginBtn.BorderRadius = 0
        Me.LoginBtn.ButtonText = "            LOGIN"
        Me.LoginBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LoginBtn.DisabledColor = System.Drawing.Color.Gray
        Me.LoginBtn.Iconcolor = System.Drawing.Color.Transparent
        Me.LoginBtn.Iconimage = CType(resources.GetObject("LoginBtn.Iconimage"), System.Drawing.Image)
        Me.LoginBtn.Iconimage_right = Nothing
        Me.LoginBtn.Iconimage_right_Selected = Nothing
        Me.LoginBtn.Iconimage_Selected = Nothing
        Me.LoginBtn.IconMarginLeft = 0
        Me.LoginBtn.IconMarginRight = 0
        Me.LoginBtn.IconRightVisible = True
        Me.LoginBtn.IconRightZoom = 0R
        Me.LoginBtn.IconVisible = True
        Me.LoginBtn.IconZoom = 60.0R
        Me.LoginBtn.IsTab = False
        Me.LoginBtn.Location = New System.Drawing.Point(11, 271)
        Me.LoginBtn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.LoginBtn.Name = "LoginBtn"
        Me.LoginBtn.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.LoginBtn.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.LoginBtn.OnHoverTextColor = System.Drawing.Color.White
        Me.LoginBtn.selected = False
        Me.LoginBtn.Size = New System.Drawing.Size(226, 46)
        Me.LoginBtn.TabIndex = 7
        Me.LoginBtn.Text = "            LOGIN"
        Me.LoginBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LoginBtn.Textcolor = System.Drawing.Color.White
        Me.LoginBtn.TextFont = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Passwordtxt
        '
        Me.Passwordtxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Passwordtxt.BackgroundImage = CType(resources.GetObject("Passwordtxt.BackgroundImage"), System.Drawing.Image)
        Me.Passwordtxt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Passwordtxt.ForeColor = System.Drawing.Color.White
        Me.Passwordtxt.Icon = CType(resources.GetObject("Passwordtxt.Icon"), System.Drawing.Image)
        Me.Passwordtxt.Location = New System.Drawing.Point(10, 208)
        Me.Passwordtxt.Name = "Passwordtxt"
        Me.Passwordtxt.Size = New System.Drawing.Size(227, 42)
        Me.Passwordtxt.TabIndex = 3
        Me.Passwordtxt.text = "Password"
        '
        'Usernametxt
        '
        Me.Usernametxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Usernametxt.BackgroundImage = CType(resources.GetObject("Usernametxt.BackgroundImage"), System.Drawing.Image)
        Me.Usernametxt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Usernametxt.ForeColor = System.Drawing.Color.White
        Me.Usernametxt.Icon = CType(resources.GetObject("Usernametxt.Icon"), System.Drawing.Image)
        Me.Usernametxt.Location = New System.Drawing.Point(10, 159)
        Me.Usernametxt.Name = "Usernametxt"
        Me.Usernametxt.Size = New System.Drawing.Size(227, 42)
        Me.Usernametxt.TabIndex = 2
        Me.Usernametxt.text = "Username"
        '
        'Header
        '
        Me.Header.BackColor = System.Drawing.Color.SeaGreen
        Me.Header.Controls.Add(Me.MinimizeBtn)
        Me.Header.Controls.Add(Me.CloseBtn)
        Me.Header.Controls.Add(Me.PictureBox3)
        Me.Header.Controls.Add(Me.Label3)
        Me.Header.Dock = System.Windows.Forms.DockStyle.Top
        Me.Header.Location = New System.Drawing.Point(255, 0)
        Me.Header.Margin = New System.Windows.Forms.Padding(2)
        Me.Header.Name = "Header"
        Me.Header.Size = New System.Drawing.Size(584, 45)
        Me.Header.TabIndex = 1
        '
        'MinimizeBtn
        '
        Me.MinimizeBtn.Image = CType(resources.GetObject("MinimizeBtn.Image"), System.Drawing.Image)
        Me.MinimizeBtn.Location = New System.Drawing.Point(498, 2)
        Me.MinimizeBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimizeBtn.Name = "MinimizeBtn"
        Me.MinimizeBtn.Size = New System.Drawing.Size(40, 41)
        Me.MinimizeBtn.TabIndex = 12
        Me.MinimizeBtn.TabStop = False
        '
        'CloseBtn
        '
        Me.CloseBtn.Image = CType(resources.GetObject("CloseBtn.Image"), System.Drawing.Image)
        Me.CloseBtn.Location = New System.Drawing.Point(542, 2)
        Me.CloseBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.Size = New System.Drawing.Size(40, 41)
        Me.CloseBtn.TabIndex = 11
        Me.CloseBtn.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(4, 2)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(40, 41)
        Me.PictureBox3.TabIndex = 13
        Me.PictureBox3.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(39, 7)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(433, 30)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Postgraduate Management System"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.SeaGreen
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Location = New System.Drawing.Point(260, 94)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(568, 299)
        Me.Panel3.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Panel2.Controls.Add(Me.AnnouncementDetailsLbl2)
        Me.Panel2.Controls.Add(Me.AnnouncementDetailslbl1)
        Me.Panel2.Controls.Add(Me.AnnouncementIDLbl2)
        Me.Panel2.Controls.Add(Me.AnnouncementIDLbl1)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(562, 293)
        Me.Panel2.TabIndex = 0
        '
        'AnnouncementDetailsLbl2
        '
        Me.AnnouncementDetailsLbl2.AutoSize = True
        Me.AnnouncementDetailsLbl2.Font = New System.Drawing.Font("Century Gothic", 12.2!)
        Me.AnnouncementDetailsLbl2.ForeColor = System.Drawing.Color.White
        Me.AnnouncementDetailsLbl2.Location = New System.Drawing.Point(15, 199)
        Me.AnnouncementDetailsLbl2.Name = "AnnouncementDetailsLbl2"
        Me.AnnouncementDetailsLbl2.Size = New System.Drawing.Size(0, 21)
        Me.AnnouncementDetailsLbl2.TabIndex = 26
        '
        'AnnouncementDetailslbl1
        '
        Me.AnnouncementDetailslbl1.AutoSize = True
        Me.AnnouncementDetailslbl1.Font = New System.Drawing.Font("Century Gothic", 12.2!)
        Me.AnnouncementDetailslbl1.ForeColor = System.Drawing.Color.White
        Me.AnnouncementDetailslbl1.Location = New System.Drawing.Point(15, 62)
        Me.AnnouncementDetailslbl1.Name = "AnnouncementDetailslbl1"
        Me.AnnouncementDetailslbl1.Size = New System.Drawing.Size(0, 21)
        Me.AnnouncementDetailslbl1.TabIndex = 25
        '
        'AnnouncementIDLbl2
        '
        Me.AnnouncementIDLbl2.AutoSize = True
        Me.AnnouncementIDLbl2.Font = New System.Drawing.Font("Century Gothic", 12.2!)
        Me.AnnouncementIDLbl2.ForeColor = System.Drawing.Color.White
        Me.AnnouncementIDLbl2.Location = New System.Drawing.Point(15, 162)
        Me.AnnouncementIDLbl2.Name = "AnnouncementIDLbl2"
        Me.AnnouncementIDLbl2.Size = New System.Drawing.Size(15, 21)
        Me.AnnouncementIDLbl2.TabIndex = 24
        Me.AnnouncementIDLbl2.Text = " "
        '
        'AnnouncementIDLbl1
        '
        Me.AnnouncementIDLbl1.AutoSize = True
        Me.AnnouncementIDLbl1.Font = New System.Drawing.Font("Century Gothic", 12.2!)
        Me.AnnouncementIDLbl1.ForeColor = System.Drawing.Color.White
        Me.AnnouncementIDLbl1.Location = New System.Drawing.Point(15, 23)
        Me.AnnouncementIDLbl1.Name = "AnnouncementIDLbl1"
        Me.AnnouncementIDLbl1.Size = New System.Drawing.Size(0, 21)
        Me.AnnouncementIDLbl1.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(260, 62)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(201, 30)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Announcement"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BunifuDragControl1
        '
        Me.BunifuDragControl1.Fixed = True
        Me.BunifuDragControl1.Horizontal = True
        Me.BunifuDragControl1.TargetControl = Me.Header
        Me.BunifuDragControl1.Vertical = True
        '
        'MetroUserControl1
        '
        Me.MetroUserControl1.Location = New System.Drawing.Point(0, 0)
        Me.MetroUserControl1.Name = "MetroUserControl1"
        Me.MetroUserControl1.Size = New System.Drawing.Size(150, 150)
        Me.MetroUserControl1.TabIndex = 0
        Me.MetroUserControl1.UseSelectable = True
        '
        'MetroToolTip1
        '
        Me.MetroToolTip1.Style = MetroFramework.MetroColorStyle.White
        Me.MetroToolTip1.StyleManager = Nothing
        Me.MetroToolTip1.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'LoginPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(839, 404)
        Me.Controls.Add(Me.Header)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "LoginPage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.UsernameHelp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pwdhelp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Header.ResumeLayout(False)
        Me.Header.PerformLayout()
        CType(Me.MinimizeBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CloseBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents Header As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LoginBtn As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents Passwordtxt As Bunifu.Framework.UI.BunifuTextbox
    Friend WithEvents Usernametxt As Bunifu.Framework.UI.BunifuTextbox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents MinimizeBtn As PictureBox
    Friend WithEvents CloseBtn As PictureBox
    Friend WithEvents BunifuDragControl1 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents MetroUserControl1 As MetroFramework.Controls.MetroUserControl
    Friend WithEvents UsernameHelp As PictureBox
    Friend WithEvents MetroToolTip1 As MetroFramework.Components.MetroToolTip
    Friend WithEvents pwdhelp As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents AnnouncementDetailsLbl2 As Label
    Friend WithEvents AnnouncementDetailslbl1 As Label
    Friend WithEvents AnnouncementIDLbl2 As Label
    Friend WithEvents AnnouncementIDLbl1 As Label
End Class
