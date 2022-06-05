<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMembers
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpMembers = New System.Windows.Forms.GroupBox()
        Me.lstMembers = New System.Windows.Forms.ListBox()
        Me.grpNew = New System.Windows.Forms.GroupBox()
        Me.chkNewM = New System.Windows.Forms.CheckBox()
        Me.grpEdit = New System.Windows.Forms.GroupBox()
        Me.mskPhone = New System.Windows.Forms.MaskedTextBox()
        Me.txtPhotoPath = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLName = New System.Windows.Forms.TextBox()
        Me.txtMI = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtFName = New System.Windows.Forms.TextBox()
        Me.txtPID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grpSearch = New System.Windows.Forms.GroupBox()
        Me.lstSearch = New System.Windows.Forms.ListBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.errP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpImage = New System.Windows.Forms.GroupBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkUpdateMember = New System.Windows.Forms.CheckBox()
        Me.tsbHome = New System.Windows.Forms.ToolStripButton()
        Me.tsbMember = New System.Windows.Forms.ToolStripButton()
        Me.tsbRole = New System.Windows.Forms.ToolStripButton()
        Me.tsbMemberRoles = New System.Windows.Forms.ToolStripButton()
        Me.tsbEvent = New System.Windows.Forms.ToolStripButton()
        Me.tsbRSVP = New System.Windows.Forms.ToolStripButton()
        Me.tsbCourse = New System.Windows.Forms.ToolStripButton()
        Me.tsbSemester = New System.Windows.Forms.ToolStripButton()
        Me.tsbTutor = New System.Windows.Forms.ToolStripButton()
        Me.tsbLogout = New System.Windows.Forms.ToolStripButton()
        Me.tsbHelp = New System.Windows.Forms.ToolStripButton()
        Me.tsbAdmin = New System.Windows.Forms.ToolStripButton()
        Me.pbPhoto = New System.Windows.Forms.PictureBox()
        Me.grpMembers.SuspendLayout()
        Me.grpNew.SuspendLayout()
        Me.grpEdit.SuspendLayout()
        Me.grpSearch.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.errP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpImage.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(911, 56)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Members"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpMembers
        '
        Me.grpMembers.Controls.Add(Me.lstMembers)
        Me.grpMembers.Location = New System.Drawing.Point(43, 379)
        Me.grpMembers.Name = "grpMembers"
        Me.grpMembers.Size = New System.Drawing.Size(256, 204)
        Me.grpMembers.TabIndex = 6
        Me.grpMembers.TabStop = False
        Me.grpMembers.Text = "Members"
        '
        'lstMembers
        '
        Me.lstMembers.FormattingEnabled = True
        Me.lstMembers.Location = New System.Drawing.Point(12, 17)
        Me.lstMembers.Name = "lstMembers"
        Me.lstMembers.Size = New System.Drawing.Size(238, 186)
        Me.lstMembers.TabIndex = 4
        '
        'grpNew
        '
        Me.grpNew.Controls.Add(Me.chkNewM)
        Me.grpNew.Location = New System.Drawing.Point(43, 135)
        Me.grpNew.Name = "grpNew"
        Me.grpNew.Size = New System.Drawing.Size(271, 43)
        Me.grpNew.TabIndex = 7
        Me.grpNew.TabStop = False
        '
        'chkNewM
        '
        Me.chkNewM.AutoSize = True
        Me.chkNewM.Location = New System.Drawing.Point(6, 19)
        Me.chkNewM.Name = "chkNewM"
        Me.chkNewM.Size = New System.Drawing.Size(111, 17)
        Me.chkNewM.TabIndex = 0
        Me.chkNewM.Text = "Add New Member"
        Me.chkNewM.UseVisualStyleBackColor = True
        '
        'grpEdit
        '
        Me.grpEdit.Controls.Add(Me.mskPhone)
        Me.grpEdit.Controls.Add(Me.txtPhotoPath)
        Me.grpEdit.Controls.Add(Me.Label4)
        Me.grpEdit.Controls.Add(Me.txtLName)
        Me.grpEdit.Controls.Add(Me.txtMI)
        Me.grpEdit.Controls.Add(Me.txtEmail)
        Me.grpEdit.Controls.Add(Me.Label8)
        Me.grpEdit.Controls.Add(Me.Label7)
        Me.grpEdit.Controls.Add(Me.Label6)
        Me.grpEdit.Controls.Add(Me.Label5)
        Me.grpEdit.Controls.Add(Me.btnCancel)
        Me.grpEdit.Controls.Add(Me.btnSave)
        Me.grpEdit.Controls.Add(Me.txtFName)
        Me.grpEdit.Controls.Add(Me.txtPID)
        Me.grpEdit.Controls.Add(Me.Label3)
        Me.grpEdit.Controls.Add(Me.Label2)
        Me.grpEdit.Location = New System.Drawing.Point(332, 180)
        Me.grpEdit.Name = "grpEdit"
        Me.grpEdit.Size = New System.Drawing.Size(323, 402)
        Me.grpEdit.TabIndex = 0
        Me.grpEdit.TabStop = False
        Me.grpEdit.Text = "Edit Role"
        '
        'mskPhone
        '
        Me.mskPhone.Location = New System.Drawing.Point(99, 241)
        Me.mskPhone.Mask = "(999) 000-0000"
        Me.mskPhone.Name = "mskPhone"
        Me.mskPhone.Size = New System.Drawing.Size(197, 20)
        Me.mskPhone.TabIndex = 10
        '
        'txtPhotoPath
        '
        Me.txtPhotoPath.Location = New System.Drawing.Point(99, 280)
        Me.txtPhotoPath.MaxLength = 100
        Me.txtPhotoPath.Multiline = True
        Me.txtPhotoPath.Name = "txtPhotoPath"
        Me.txtPhotoPath.Size = New System.Drawing.Size(198, 22)
        Me.txtPhotoPath.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 280)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "PhotoPath"
        '
        'txtLName
        '
        Me.txtLName.Location = New System.Drawing.Point(99, 109)
        Me.txtLName.MaxLength = 100
        Me.txtLName.Multiline = True
        Me.txtLName.Name = "txtLName"
        Me.txtLName.Size = New System.Drawing.Size(198, 22)
        Me.txtLName.TabIndex = 7
        '
        'txtMI
        '
        Me.txtMI.Location = New System.Drawing.Point(99, 154)
        Me.txtMI.MaxLength = 100
        Me.txtMI.Multiline = True
        Me.txtMI.Name = "txtMI"
        Me.txtMI.Size = New System.Drawing.Size(198, 22)
        Me.txtMI.TabIndex = 8
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(99, 199)
        Me.txtEmail.MaxLength = 100
        Me.txtEmail.Multiline = True
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(198, 22)
        Me.txtEmail.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 199)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Email"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 154)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Middle Initial"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Last Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "First Name"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(170, 318)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(127, 29)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(20, 318)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(119, 29)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtFName
        '
        Me.txtFName.Location = New System.Drawing.Point(99, 64)
        Me.txtFName.MaxLength = 100
        Me.txtFName.Multiline = True
        Me.txtFName.Name = "txtFName"
        Me.txtFName.Size = New System.Drawing.Size(198, 22)
        Me.txtFName.TabIndex = 6
        '
        'txtPID
        '
        Me.txtPID.Location = New System.Drawing.Point(99, 23)
        Me.txtPID.MaxLength = 15
        Me.txtPID.Name = "txtPID"
        Me.txtPID.Size = New System.Drawing.Size(198, 20)
        Me.txtPID.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 239)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Phone"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Panther ID"
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.lstSearch)
        Me.grpSearch.Controls.Add(Me.btnSearch)
        Me.grpSearch.Controls.Add(Me.txtSearch)
        Me.grpSearch.Location = New System.Drawing.Point(43, 193)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(271, 180)
        Me.grpSearch.TabIndex = 10
        Me.grpSearch.TabStop = False
        Me.grpSearch.Text = "Search by Last Name"
        '
        'lstSearch
        '
        Me.lstSearch.FormattingEnabled = True
        Me.lstSearch.Location = New System.Drawing.Point(24, 78)
        Me.lstSearch.Name = "lstSearch"
        Me.lstSearch.Size = New System.Drawing.Size(218, 82)
        Me.lstSearch.TabIndex = 3
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(77, 43)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(102, 29)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(24, 19)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(220, 20)
        Me.txtSearch.TabIndex = 1
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 595)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(988, 22)
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tslStatus
        '
        Me.tslStatus.AutoSize = False
        Me.tslStatus.Name = "tslStatus"
        Me.tslStatus.Size = New System.Drawing.Size(951, 17)
        Me.tslStatus.Text = "ToolStripStatusLabel1"
        '
        'errP
        '
        Me.errP.ContainerControl = Me
        '
        'grpImage
        '
        Me.grpImage.Controls.Add(Me.btnBrowse)
        Me.grpImage.Controls.Add(Me.pbPhoto)
        Me.grpImage.Location = New System.Drawing.Point(661, 135)
        Me.grpImage.Name = "grpImage"
        Me.grpImage.Size = New System.Drawing.Size(293, 402)
        Me.grpImage.TabIndex = 14
        Me.grpImage.TabStop = False
        Me.grpImage.Text = "Photograph"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(6, 367)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(119, 29)
        Me.btnBrowse.TabIndex = 14
        Me.btnBrowse.Text = "Browse Image"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnReport
        '
        Me.btnReport.Location = New System.Drawing.Point(829, 553)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(119, 29)
        Me.btnReport.TabIndex = 15
        Me.btnReport.Text = "Report"
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbHome, Me.ToolStripSeparator7, Me.tsbMember, Me.ToolStripSeparator3, Me.tsbRole, Me.ToolStripSeparator5, Me.tsbMemberRoles, Me.ToolStripSeparator11, Me.tsbEvent, Me.ToolStripSeparator6, Me.tsbRSVP, Me.ToolStripSeparator4, Me.tsbCourse, Me.ToolStripSeparator1, Me.tsbSemester, Me.ToolStripSeparator10, Me.tsbTutor, Me.tsbLogout, Me.ToolStripSeparator9, Me.tsbHelp, Me.ToolStripSeparator2, Me.ToolStripSeparator8, Me.tsbAdmin})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(988, 50)
        Me.ToolStrip1.TabIndex = 16
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.AutoSize = False
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(10, 50)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.AutoSize = False
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(10, 50)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.AutoSize = False
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(10, 50)
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 50)
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.AutoSize = False
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(10, 50)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.AutoSize = False
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(10, 50)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.AutoSize = False
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(10, 50)
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.AutoSize = False
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(10, 50)
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator9.AutoSize = False
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(10, 50)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator2.AutoSize = False
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(10, 50)
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.AutoSize = False
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(10, 50)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkUpdateMember)
        Me.GroupBox1.Location = New System.Drawing.Point(332, 131)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(323, 43)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Check Below If Updating Member Information"
        '
        'chkUpdateMember
        '
        Me.chkUpdateMember.AutoSize = True
        Me.chkUpdateMember.Location = New System.Drawing.Point(6, 19)
        Me.chkUpdateMember.Name = "chkUpdateMember"
        Me.chkUpdateMember.Size = New System.Drawing.Size(157, 17)
        Me.chkUpdateMember.TabIndex = 0
        Me.chkUpdateMember.Text = "Update Member Information"
        Me.chkUpdateMember.UseVisualStyleBackColor = True
        '
        'tsbHome
        '
        Me.tsbHome.AutoSize = False
        Me.tsbHome.BackgroundImage = Global.STARSORG.My.Resources.Resources._home
        Me.tsbHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbHome.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbHome.Name = "tsbHome"
        Me.tsbHome.Size = New System.Drawing.Size(48, 48)
        Me.tsbHome.Text = "HOME"
        '
        'tsbMember
        '
        Me.tsbMember.AutoSize = False
        Me.tsbMember.BackgroundImage = Global.STARSORG.My.Resources.Resources._member
        Me.tsbMember.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbMember.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbMember.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbMember.Name = "tsbMember"
        Me.tsbMember.Size = New System.Drawing.Size(48, 48)
        Me.tsbMember.Text = "MEMBER"
        '
        'tsbRole
        '
        Me.tsbRole.AutoSize = False
        Me.tsbRole.BackgroundImage = Global.STARSORG.My.Resources.Resources._roles
        Me.tsbRole.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbRole.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRole.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRole.Name = "tsbRole"
        Me.tsbRole.Size = New System.Drawing.Size(48, 48)
        Me.tsbRole.Text = "ROLE"
        '
        'tsbMemberRoles
        '
        Me.tsbMemberRoles.AutoSize = False
        Me.tsbMemberRoles.BackgroundImage = Global.STARSORG.My.Resources.Resources._member_role
        Me.tsbMemberRoles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbMemberRoles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbMemberRoles.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbMemberRoles.Name = "tsbMemberRoles"
        Me.tsbMemberRoles.Size = New System.Drawing.Size(48, 48)
        Me.tsbMemberRoles.Text = "MEMBER ROLES"
        '
        'tsbEvent
        '
        Me.tsbEvent.AutoSize = False
        Me.tsbEvent.BackgroundImage = Global.STARSORG.My.Resources.Resources._events
        Me.tsbEvent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbEvent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbEvent.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEvent.Name = "tsbEvent"
        Me.tsbEvent.Size = New System.Drawing.Size(48, 48)
        Me.tsbEvent.Text = "EVENTS"
        '
        'tsbRSVP
        '
        Me.tsbRSVP.AutoSize = False
        Me.tsbRSVP.BackgroundImage = Global.STARSORG.My.Resources.Resources._rsvp
        Me.tsbRSVP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbRSVP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRSVP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRSVP.Name = "tsbRSVP"
        Me.tsbRSVP.Size = New System.Drawing.Size(48, 48)
        Me.tsbRSVP.Text = "RSVP"
        '
        'tsbCourse
        '
        Me.tsbCourse.AutoSize = False
        Me.tsbCourse.BackgroundImage = Global.STARSORG.My.Resources.Resources._courses
        Me.tsbCourse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbCourse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbCourse.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCourse.Name = "tsbCourse"
        Me.tsbCourse.Size = New System.Drawing.Size(48, 48)
        Me.tsbCourse.Text = "COURSES"
        '
        'tsbSemester
        '
        Me.tsbSemester.AutoSize = False
        Me.tsbSemester.BackgroundImage = Global.STARSORG.My.Resources.Resources._semesters
        Me.tsbSemester.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbSemester.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSemester.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSemester.Name = "tsbSemester"
        Me.tsbSemester.Size = New System.Drawing.Size(48, 48)
        Me.tsbSemester.Text = "SEMESTERS"
        '
        'tsbTutor
        '
        Me.tsbTutor.AutoSize = False
        Me.tsbTutor.BackgroundImage = Global.STARSORG.My.Resources.Resources._tutors
        Me.tsbTutor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbTutor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbTutor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbTutor.Name = "tsbTutor"
        Me.tsbTutor.Size = New System.Drawing.Size(48, 48)
        Me.tsbTutor.Text = "TUTORS"
        '
        'tsbLogout
        '
        Me.tsbLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbLogout.AutoSize = False
        Me.tsbLogout.BackgroundImage = Global.STARSORG.My.Resources.Resources._logout
        Me.tsbLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbLogout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbLogout.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbLogout.Name = "tsbLogout"
        Me.tsbLogout.Size = New System.Drawing.Size(48, 48)
        Me.tsbLogout.Text = "LOG OUT"
        '
        'tsbHelp
        '
        Me.tsbHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbHelp.AutoSize = False
        Me.tsbHelp.BackgroundImage = Global.STARSORG.My.Resources.Resources._help
        Me.tsbHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbHelp.Name = "tsbHelp"
        Me.tsbHelp.Size = New System.Drawing.Size(48, 48)
        Me.tsbHelp.Text = "HELP"
        '
        'tsbAdmin
        '
        Me.tsbAdmin.AutoSize = False
        Me.tsbAdmin.BackgroundImage = Global.STARSORG.My.Resources.Resources._admin
        Me.tsbAdmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.tsbAdmin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAdmin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAdmin.Name = "tsbAdmin"
        Me.tsbAdmin.Size = New System.Drawing.Size(48, 48)
        Me.tsbAdmin.Text = "ADMINISTRATION"
        '
        'pbPhoto
        '
        Me.pbPhoto.Location = New System.Drawing.Point(6, 23)
        Me.pbPhoto.Name = "pbPhoto"
        Me.pbPhoto.Size = New System.Drawing.Size(281, 324)
        Me.pbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbPhoto.TabIndex = 13
        Me.pbPhoto.TabStop = False
        '
        'frmMembers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(988, 617)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.btnReport)
        Me.Controls.Add(Me.grpImage)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.grpSearch)
        Me.Controls.Add(Me.grpEdit)
        Me.Controls.Add(Me.grpNew)
        Me.Controls.Add(Me.grpMembers)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmMembers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Members"
        Me.grpMembers.ResumeLayout(False)
        Me.grpNew.ResumeLayout(False)
        Me.grpNew.PerformLayout()
        Me.grpEdit.ResumeLayout(False)
        Me.grpEdit.PerformLayout()
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.errP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpImage.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents grpMembers As GroupBox
    Friend WithEvents grpNew As GroupBox
    Friend WithEvents chkNewM As CheckBox
    Friend WithEvents grpEdit As GroupBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents txtFName As TextBox
    Friend WithEvents txtPID As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtLName As TextBox
    Friend WithEvents txtMI As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents grpSearch As GroupBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tslStatus As ToolStripStatusLabel
    Friend WithEvents errP As ErrorProvider
    Friend WithEvents lstMembers As ListBox
    Friend WithEvents lstSearch As ListBox
    Friend WithEvents pbPhoto As PictureBox
    Friend WithEvents grpImage As GroupBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPhotoPath As TextBox
    Friend WithEvents mskPhone As MaskedTextBox
    Friend WithEvents btnReport As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsbHome As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents tsbMember As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tsbRole As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents tsbMemberRoles As ToolStripButton
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents tsbEvent As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents tsbRSVP As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tsbCourse As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsbSemester As ToolStripButton
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents tsbTutor As ToolStripButton
    Friend WithEvents tsbLogout As ToolStripButton
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents tsbHelp As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents tsbAdmin As ToolStripButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chkUpdateMember As CheckBox
End Class
