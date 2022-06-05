Imports System.Data.SqlClient
Public Class frmAdmin
    Private objMembers As CMembers
    Dim objSecurities As CSecurities = New CSecurities
    'Private objSecurities As CSecurities
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

    Private Sub tsbHome_Click(sender As Object, e As EventArgs) Handles tsbHome.Click
        intNextAction = ACTION_HOME
        Me.Hide()
    End Sub

    Private Sub tsbCourse_Click(sender As Object, e As EventArgs) Handles tsbCourse.Click
        intNextAction = ACTION_COURSE
        Me.Hide()
    End Sub

    Private Sub tsbEvent_Click(sender As Object, e As EventArgs) Handles tsbEvent.Click
        intNextAction = ACTION_EVENT
        Me.Hide()
    End Sub

    Private Sub tsbHelp_Click(sender As Object, e As EventArgs) Handles tsbHelp.Click
        intNextAction = ACTION_HELP
        Me.Hide()
    End Sub

    Private Sub tsbLogout_Click(sender As Object, e As EventArgs) Handles tsbLogout.Click
        intNextAction = ACTION_LOGOUT
        Me.Hide()
    End Sub

    Private Sub tsbMember_Click(sender As Object, e As EventArgs) Handles tsbMember.Click
        intNextAction = ACTION_MEMBER
        Me.Hide()
    End Sub

    Private Sub tsbRole_Click(sender As Object, e As EventArgs) Handles tsbRole.Click
        intNextAction = ACTION_ROLE
        Me.Hide()
    End Sub

    Private Sub tsbRSVP_Click(sender As Object, e As EventArgs) Handles tsbRSVP.Click
        intNextAction = ACTION_RSVP
        Me.Hide()
    End Sub

    Private Sub tsbSemester_Click(sender As Object, e As EventArgs) Handles tsbSemester.Click
        intNextAction = ACTION_SEMESTER
        Me.Hide()
    End Sub

    Private Sub tsbTutor_Click(sender As Object, e As EventArgs) Handles tsbTutor.Click
        intNextAction = ACTION_TUTOR
        Me.Hide()
    End Sub

    Private Sub tsbAdmin_Click(sender As Object, e As EventArgs) Handles tsbAdmin.Click
        'nothing to do here
    End Sub

    Private Sub tsbMemberRoles_Click(sender As Object, e As EventArgs) Handles tsbMemberRoles.Click
        intNextAction = ACTION_MBRROLE
        Me.Hide()
    End Sub
#End Region

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lstPrivileges.Items.Clear()
        lstPrivileges.Items.Add("ADMIN")
        lstPrivileges.Items.Add("OFFICER")
        lstPrivileges.Items.Add("MEMBER")
        lstPrivileges.Items.Add("GUEST")
        tslStatus.Text = ""

    End Sub
    Private Sub LoadMembers()
        Dim objReader As SqlDataReader 'a data reader is an excel spread sheet, so to speak.
        lstMembers.Items.Clear()
        Try
            objReader = objMembers.GetAllMembers()
            Do While objReader.Read 'while there is data to be read
                If Not (objReader.Item("PID").Equals("9999999")) And Not (objReader.Item("PID").Equals("0000001")) Then
                    lstMembers.Items.Add(objReader.Item("LName") & ", " & objReader.Item("FName") & ": " & objReader.Item("PID"))
                End If
            Loop
            objReader.Close()
        Catch ex As Exception
            'currently CBD will display the error
        End Try

    End Sub

    Private Sub frmAdmin_Load(sender As Object, e As EventArgs) Handles Me.Load
        objMembers = New CMembers
        'objSecurities = New CSecurities
    End Sub

    Private Sub frmAdmin_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadMembers()
    End Sub

    Private Sub lstPrivileges_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPrivileges.SelectedIndexChanged
        tslStatus.Text = ""
    End Sub

    Private Sub lstMembers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMembers.SelectedIndexChanged
        objSecurities.Clear()
        tslStatus.Text = ""
        txtUserID.Text = ""
        txtPassword.Text = ""
        txtConfirmPassword.Text = ""
        chkUpdatingCredentials.Enabled = True
        chkUpdatingCredentials.Checked = False
        Dim strPID As String
        strPID = lstMembers.SelectedItem.ToString.Substring(lstMembers.SelectedItem.ToString.Length - 7)
        objSecurities.GetCredentialsByPID(strPID)

        txtUserID.Text = objSecurities.CurrentObject.UserID
        txtPassword.Text = objSecurities.CurrentObject.Password
        If objSecurities.CurrentObject.SecurityRole = "" Then
            lstPrivileges.SelectedIndex = -1
            chkUpdatingCredentials.Checked = True
            chkUpdatingCredentials.Enabled = False
        Else
            For Each item In lstPrivileges.Items
                If objSecurities.CurrentObject.SecurityRole = item.ToString Then
                    lstPrivileges.SelectedItem = item
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        errP.Clear()
        objSecurities.Clear()
        Dim strPID As String
        Dim intResult As Integer
        Dim blnErrors As Boolean
        Dim blnUserIDChanged As Boolean
        Dim blnNewUser As Boolean
        Dim blnIsUpdatingCredentials As Boolean
        If chkUpdatingCredentials.Checked Then
            blnIsUpdatingCredentials = True
        End If
        'validate input first
        errP.Clear()
        If Not ValidateTextBoxLength(txtUserID, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtPassword, errP) Then
            blnErrors = True
        End If
        If blnIsUpdatingCredentials Then
            If Not ValidateTextBoxLength(txtConfirmPassword, errP) Then
                blnErrors = True
            End If
        End If
        If Not ValidateListBox(lstMembers, errP) Then
            blnErrors = True
        End If
        If Not ValidateListBox(lstPrivileges, errP) Then
            blnErrors = True
        End If
        If blnErrors Then
            Exit Sub
        End If


        'load objSecurities object with credentials of selected member.
        strPID = lstMembers.SelectedItem.ToString.Substring(lstMembers.SelectedItem.ToString.Length - 7)
        objSecurities.GetCredentialsByPID(strPID)

        'check if user id has been changed
        If objSecurities.CurrentObject.UserID = "" Then
            blnNewUser = True
        End If
        If blnIsUpdatingCredentials Then
            If Not txtPassword.Text = txtConfirmPassword.Text Then
                MessageBox.Show("Passwords do not match, please try again.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If blnNewUser Then
                If Not objSecurities.CheckUserIDExists(txtUserID.Text) Then
                    objSecurities.CurrentObject.UserID = txtUserID.Text
                    objSecurities.CurrentObject.Password = txtConfirmPassword.Text
                    objSecurities.CurrentObject.SecurityRole = lstPrivileges.SelectedItem.ToString
                    objSecurities.CurrentObject.PID = strPID
                    intResult = objSecurities.CreateNewCredentials()
                    If intResult = 1 Then
                        tslStatus.Text = "Credentials stored successfully."
                    Else
                        tslStatus.Text = "Error Saving Credentials: intResult is " & intResult
                    End If
                Else
                    MessageBox.Show("UserID already exists, please try another UserID.", "UserID Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Else
                If Not objSecurities.CurrentObject.UserID = txtUserID.Text And objSecurities.CurrentObject.UserID.Length > 0 Then
                    blnUserIDChanged = True
                End If
                If blnUserIDChanged Then
                    If Not objSecurities.CheckUserIDExists(txtUserID.Text) Then
                        objSecurities.CurrentObject.UserID = txtUserID.Text
                        objSecurities.CurrentObject.Password = txtConfirmPassword.Text
                        objSecurities.CurrentObject.SecurityRole = lstPrivileges.SelectedItem.ToString
                        intResult = objSecurities.CreateNewCredentials()
                        If intResult = 1 Then
                            tslStatus.Text = "Credentials stored successfully."
                            Exit Sub
                        Else
                            tslStatus.Text = "Error Saving Credentials: intResult is " & intResult
                        End If
                    Else
                        MessageBox.Show("UserID already exists, please try another UserID", "UserID Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Else
                    objSecurities.CurrentObject.Password = txtConfirmPassword.Text
                    objSecurities.CurrentObject.SecurityRole = lstPrivileges.SelectedItem.ToString
                    intResult = objSecurities.ChangePassword()
                    If intResult = 1 Then 'returns 1 if successful
                        tslStatus.Text = "Password has been changed."
                        Exit Sub
                    Else
                        tslStatus.Text = "Error Saving Credentials: intResult is " & intResult
                    End If
                End If
            End If
        Else
            objSecurities.CurrentObject.UserID = txtUserID.Text
            objSecurities.CurrentObject.Password = txtPassword.Text
            objSecurities.CurrentObject.SecurityRole = lstPrivileges.SelectedItem.ToString
            intResult = objSecurities.UpdateCredentials()
            If intResult = 1 Then
                tslStatus.Text = "Credentials stored successfully."
            Else
                tslStatus.Text = "Error Saving Credentials: intResult is " & intResult
            End If

            Exit Sub
        End If
        chkUpdatingCredentials.Checked = False
        txtConfirmPassword.Text = ""

        Me.Cursor = Cursors.Default
        ' blnReloading = True
    End Sub

    Private Sub chkUpdatingCredentials_CheckedChanged(sender As Object, e As EventArgs) Handles chkUpdatingCredentials.CheckedChanged
        Dim ctrl As New CheckBox
        ctrl = DirectCast(sender, CheckBox)
        If ctrl.Checked = True Then
            grpUserCredentials.Enabled = True
        Else
            Dim strPID As String
            strPID = lstMembers.SelectedItem.ToString.Substring(lstMembers.SelectedItem.ToString.Length - 7)
            objSecurities.GetCredentialsByPID(strPID)
            grpUserCredentials.Enabled = False
            txtUserID.Text = objSecurities.CurrentObject.UserID
            txtPassword.Text = objSecurities.CurrentObject.Password
            txtConfirmPassword.Text = ""
        End If
    End Sub

    Private Sub btnRevokeCredentials_Click(sender As Object, e As EventArgs) Handles btnRevokeCredentials.Click
        errP.Clear()
        Dim blnErrors As Boolean
        If Not ValidateListBox(lstMembers, errP) Then
            blnErrors = True
        End If
        If blnErrors Then
            Exit Sub
        End If
        If objSecurities.CurrentObject.UserID = "" Then
            MessageBox.Show("User does not have any credentials to revoke.", "No Credentials to Revoke", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim intResult As Integer
        Dim intDeleteResult As Integer
        intResult = MessageBox.Show("Are you sure you wish to revoke " & lstMembers.SelectedItem.ToString.Substring(0, lstMembers.SelectedItem.ToString.Length - 9) & "'s credentials? This cannot be undone.", "Revoke Credentials?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If intResult = DialogResult.Yes Then
            intDeleteResult = objSecurities.DeleteCredentials()
            If intDeleteResult = 1 Then
                tslStatus.Text = "Credentials revoked."
                txtUserID.Text = ""
                txtPassword.Text = ""
                txtConfirmPassword.Text = ""
                lstPrivileges.SelectedIndex = -1
            Else
                tslStatus.Text = "Error Revoking Credentials: intDeleteResult is " & intResult
            End If
        End If
    End Sub

    Private Sub txtBoxes_GotFocus(sender As Object, e As EventArgs) Handles txtConfirmPassword.GotFocus, txtPassword.GotFocus, txtUserID.GotFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.SelectAll() 'highlight the contents for replacement typing
    End Sub

    Private Sub txtBoxes_LostFocus(sender As Object, e As EventArgs) Handles txtConfirmPassword.LostFocus, txtPassword.LostFocus, txtUserID.LostFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.DeselectAll() 'highlight the contents for replacement typing
    End Sub
End Class