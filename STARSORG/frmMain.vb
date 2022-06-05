Imports System.Data.SqlClient
Public Class frmMain
    Private RoleInfo As frmRole
    Private AdminScreen As frmAdmin
    Private LogIn As frmLogIn
    Private RSVP As frmRSVP
    Private Events As frmEvent
    Private Courses As frmCourse
    Private Semesters As frmSemester
    Private Members As frmMembers
    Private MemberRoles As frmMbrRole
    'Private MemberRoles As frmMemberRoles
    'Private Member As frmMember
    '

#Region "Toolbar Stuff"
    Private Sub tsbProxy_MouseEnter(sender As Object, e As EventArgs) Handles tsbCourse.MouseEnter, tsbEvent.MouseEnter, tsbHelp.MouseEnter, tsbHome.MouseEnter, tsbMember.MouseEnter, tsbRole.MouseEnter, tsbRSVP.MouseEnter, tsbSemester.MouseEnter, tsbTutor.MouseEnter, tsbLogout.MouseEnter, tsbAdmin.MouseEnter, tsbMemberRoles.MouseEnter
        'we need to do this only because we are not putting our images in the image property but instead in the background image property
        Dim tsbProxy As ToolStripButton
        tsbProxy = DirectCast(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Text
    End Sub

    Private Sub tsbProxy_MouseLeave(sender As Object, e As EventArgs) Handles tsbCourse.MouseLeave, tsbEvent.MouseLeave, tsbHelp.MouseLeave, tsbHome.MouseLeave, tsbMember.MouseLeave, tsbRole.MouseLeave, tsbRSVP.MouseLeave, tsbSemester.MouseLeave, tsbTutor.MouseLeave, tsbLogout.MouseLeave, tsbAdmin.MouseLeave, tsbMemberRoles.MouseLeave
        'we need to do this only because we are not putting our images in the image property but instead in the background image property
        Dim tsbProxy As ToolStripButton
        tsbProxy = DirectCast(sender, ToolStripButton)
        tsbProxy.DisplayStyle = ToolStripItemDisplayStyle.Image
    End Sub

    Private Sub tsbRole_Click(sender As Object, e As EventArgs) Handles tsbRole.Click
        Me.Hide()
        RoleInfo.ShowDialog()
        'next line of code wont run until role is closed
        Me.Show()
        PerformNextAction()
    End Sub

    Private Sub tsbRSVP_Click(sender As Object, e As EventArgs) Handles tsbRSVP.Click
        Me.Hide()
        RSVP.ShowDialog()
        'next line of code wont run until admin is closed
        Me.Show()
        PerformNextAction()
    End Sub

    Private Sub tsbEvent_Click(sender As Object, e As EventArgs) Handles tsbEvent.Click
        Me.Hide()
        Events.ShowDialog()
        'next line of code wont run until admin is closed
        Me.Show()
        PerformNextAction()
    End Sub

    Private Sub tsbAdmin_Click(sender As Object, e As EventArgs) Handles tsbAdmin.Click
        Me.Hide()
        AdminScreen.ShowDialog()
        'next line of code wont run until admin is closed
        Me.Show()
        PerformNextAction()
    End Sub

    Private Sub tsbSemester_Click(sender As Object, e As EventArgs) Handles tsbSemester.Click
        Me.Hide()
        Semesters.ShowDialog()
        'next line of code wont run until admin is closed
        Me.Show()
        PerformNextAction()
    End Sub

    Private Sub tsbCourse_Click(sender As Object, e As EventArgs) Handles tsbCourse.Click
        Me.Hide()
        Courses.ShowDialog()
        'next line of code wont run until admin is closed
        Me.Show()
        PerformNextAction()
    End Sub

    Private Sub tsbMember_Click(sender As Object, e As EventArgs) Handles tsbMember.Click
        Me.Hide()
        Members.ShowDialog()
        'Next line Of code wont run until admin Is closed
        Me.Show()
        PerformNextAction()
    End Sub
    Private Sub tsbMemberRoles_Click(sender As Object, e As EventArgs) Handles tsbMemberRoles.Click
        Me.Hide()
        MemberRoles.ShowDialog()
        'Next line Of code wont run until admin Is closed
        Me.Show()
        PerformNextAction()
    End Sub

    Private Sub PerformNextAction()
        'get the next action selected on the child form and then simulate the click of the button here
        Select Case intNextAction
            Case ACTION_COURSE
                tsbCourse.PerformClick()
            Case ACTION_EVENT
                tsbEvent.PerformClick()
            Case ACTION_HELP

            Case ACTION_HOME

            Case ACTION_LOGOUT
                tsbLogout.PerformClick()
            Case ACTION_MBRROLE
                tsbMemberRoles.PerformClick()
            Case ACTION_MEMBER
                tsbMember.PerformClick()
            Case ACTION_NONE

            Case ACTION_ROLE
                tsbRole.PerformClick()
            Case ACTION_RSVP
                tsbRSVP.PerformClick()
            Case ACTION_SEMESTER
                tsbSemester.PerformClick()
            Case ACTION_TUTOR
            Case ACTION_ADMIN
                tsbAdmin.PerformClick()
            Case Else
                MessageBox.Show("Unexpected case value in PerformNextAction()", "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select
    End Sub
#End Region

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        'initialize everything here
        'instantiate a form object for each form in the application
        RoleInfo = New frmRole
        LogIn = New frmLogIn
        AdminScreen = New frmAdmin
        RSVP = New frmRSVP
        Events = New frmEvent
        Courses = New frmCourse
        Semesters = New frmSemester
        Members = New frmMembers
        MemberRoles = New frmMbrRole
        'MemberRoles = New frmMemberRoles
        'Member = New frmMember

    End Sub

    Private Sub EndProgram()
        'close each form except main
        Dim f As Form
        Me.Cursor = Cursors.WaitCursor
        For Each f In Application.OpenForms
            If f.Name <> Me.Name Then
                If Not f Is Nothing Then
                    f.Close()
                End If
            End If
        Next
        'close the database connection
        If Not objSQLConn Is Nothing Then
            objSQLConn.Close()
            objSQLConn.Dispose()
        End If
        Me.Cursor = Cursors.Default
        Application.Exit()
    End Sub

    Private Sub tsbLogout_Click(sender As Object, e As EventArgs) Handles tsbLogout.Click
        EndProgram()
    End Sub

    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If blnIsLoggedIn = False Then
            LogIn.ShowDialog()
            ' set blnIsLoggedIn = True in login form
            If blnIsLoggedIn = False Then
                EndProgram()
                Exit Sub
            End If
            SetUserConfig(modPrivilege) 'this enables/disables buttons based on user privilege
            tslStatus.Text = "Currently logged in: " & modUserID
        End If
    End Sub

    Public Sub SetUserConfig(strPrivilege As String)
        'enables/disables buttons according to user security level
        Select Case strPrivilege
            Case "ADMIN"
                'do nothing, admins have access to all forms
            Case "OFFICER"
                tsbAdmin.Enabled = False
            Case "MEMBER"
                tsbAdmin.Enabled = False
                tsbCourse.Enabled = False
                tsbEvent.Enabled = False
                tsbMember.Enabled = False
                tsbMemberRoles.Enabled = False
                tsbRole.Enabled = False
                tsbSemester.Enabled = False
                tsbTutor.Enabled = False
            Case "GUEST"
                tsbAdmin.Enabled = False
                tsbCourse.Enabled = False
                tsbEvent.Enabled = False
                tsbMember.Enabled = False
                tsbMemberRoles.Enabled = False
                tsbRole.Enabled = False
                tsbSemester.Enabled = False
                tsbTutor.Enabled = False
            Case Else
                MessageBox.Show("Error getting privilege.", "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select
    End Sub


End Class
