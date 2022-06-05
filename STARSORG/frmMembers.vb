Imports System.Data.SqlClient
Imports System.IO
Public Class frmMembers
    Private objMembers As CMembers
    Private blnReloading As Boolean
    Private blnClearing As Boolean
    Private RoleInfo As frmRole ' declare all forms as object variable
    Private MainPage As frmMain
    Private MemberRoleInfo As frmMbrRole
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
        'nothing to do here
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
        intNextAction = ACTION_ADMIN
        Me.Hide()
    End Sub

    Private Sub tsbMemberRoles_Click(sender As Object, e As EventArgs) Handles tsbMemberRoles.Click
        intNextAction = ACTION_MBRROLE
        Me.Hide()
    End Sub
#End Region
    Private Sub txtBoxes_GotFocus(sender As Object, e As EventArgs) Handles txtPID.GotFocus, txtFName.GotFocus, txtLName.GotFocus, txtMI.GotFocus, txtEmail.GotFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.SelectAll()
    End Sub

    Private Sub txtBoxes_LostFocus(sender As Object, e As EventArgs) Handles txtPID.LostFocus, txtFName.LostFocus, txtLName.LostFocus, txtMI.LostFocus, txtEmail.LostFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.DeselectAll()
    End Sub
    Private Sub LoadMembers()
        Dim objReader As SqlDataReader
        lstMembers.Items.Clear()
        Try
            objReader = objMembers.GetAllMembers()
            Do While objReader.Read
                If Not (objReader.Item("PID").Equals("9999999")) And Not (objReader.Item("PID").Equals("0000001")) Then
                    lstMembers.Items.Add(objReader.Item("PID") + " " + objReader.Item("LName") + ", " + objReader.Item("FName"))
                End If
            Loop
            objReader.Close()
        Catch ex As Exception
            'currently CDB will display the error

        End Try
        If objMembers.CurrentObject.PID <> "" Then
            lstMembers.SelectedIndex = lstMembers.FindStringExact(objMembers.CurrentObject.PID)
        End If
        blnReloading = False
    End Sub
    Private Sub lstMembers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMembers.SelectedIndexChanged
        If blnClearing Then
            Exit Sub
        End If
        If Not blnReloading Then
            tslStatus.Text = ""

        End If
        If lstMembers.SelectedIndex = -1 Then 'nothing to do 
            Exit Sub

        End If

        LoadSelectedRecord()
        grpEdit.Enabled = True
        grpImage.Enabled = True

    End Sub
    Private Sub LoadSelectedRecord()
        Try
            objMembers.GetMemberbyPID(lstMembers.SelectedItem.ToString)
            With objMembers.CurrentObject
                txtPID.Text = .PID
                txtFName.Text = .FName
                txtLName.Text = .LName
                txtMI.Text = .MI
                txtEmail.Text = .Email
                mskPhone.Text = .Phone
                txtPhotoPath.Text = .PhotoPath
                If .PhotoPath = "" Then
                    pbPhoto.Image = Nothing
                    pbPhoto.Hide()
                    grpImage.Show()
                Else
                    pbPhoto.Show()
                    pbPhoto.Image = Image.FromFile(.PhotoPath)

                End If
            End With
        Catch exNotFound As FileNotFoundException
            tslStatus.Text = "Photograph was not found. Please load a new photograph."
        Catch exIOError As IOException
            tslStatus.Text = "Error loading photograph."
        Catch ex As Exception
            MessageBox.Show("Error loading Member values", "Program error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadSelectedSearchRecord()
        Try
            objMembers.GetMemberbyPID(lstSearch.SelectedItem.ToString)
            With objMembers.CurrentObject
                txtPID.Text = .PID
                txtFName.Text = .FName
                txtLName.Text = .LName
                txtMI.Text = .MI
                txtEmail.Text = .Email
                mskPhone.Text = .Phone
                txtPhotoPath.Text = .PhotoPath
                If .PhotoPath = "" Then
                    pbPhoto.Image = Nothing
                    pbPhoto.Hide()
                    grpImage.Show()
                Else
                    pbPhoto.Show()
                    pbPhoto.Image = Image.FromFile(.PhotoPath)
                End If
            End With
        Catch exNotFound As FileNotFoundException
            tslStatus.Text = "Photograph was not found. Please load a new photograph."
        Catch exIOError As IOException
            tslStatus.Text = "Error loading photograph."
        Catch ex As Exception
            MessageBox.Show("Error loading searched Member values", "Program error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim intResult As Integer
        Dim intSaveRoleResult As Integer
        Dim blnErrors As Boolean
        Dim objMRole As CMbrRoles
        If Not ValidateTextBoxLength(txtPID, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtFName, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtLName, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtEmail, errP) Then
            blnErrors = True
        End If
        If Not ValidateMaskedTextBoxLength(mskPhone, errP) Then
            blnErrors = True
        End If
        If blnErrors Then
            Exit Sub
        End If

        objMembers.GetMemberbyPID(txtPID.Text)
        If chkNewM.Checked And objMembers.CurrentObject.PID <> "" Then
            MessageBox.Show("Member with that Panther ID already exists. Please enter another Panther ID.")
            Exit Sub
        End If


        With objMembers.CurrentObject
            .PID = txtPID.Text
            .FName = txtFName.Text
            .LName = txtLName.Text
            .MI = txtMI.Text
            .Email = txtEmail.Text
            .Phone = mskPhone.Text
            .PhotoPath = txtPhotoPath.Text
        End With


        Try
            Me.Cursor = Cursors.WaitCursor
            intResult = objMembers.Save
            If intResult = 1 Then
                objMRole = New CMbrRoles
                objMRole.CurrentObject.RoleID = "Member"
                objMRole.CurrentObject.PID = txtPID.Text
                objMRole.CurrentObject.SemesterID = "fa17"
            End If
            Try
                intSaveRoleResult = objMRole.Save
                If intSaveRoleResult = 1 Then
                    tslStatus.Text = "Member Record Saved"
                Else

                    MessageBox.Show("Panther ID must be unique. Unable to save role record", "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    tslStatus.Text = "Error"
                End If
            Catch ex As Exception
                MessageBox.Show("Error Saving Member Role: " & ex.ToString, "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            If intResult = -1 Then
                    MessageBox.Show("Panther ID must be unique. Unable to save role record", "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    tslStatus.Text = "Error"
                End If
            Catch ex As Exception
                MessageBox.Show("Unable to save member record: " & ex.ToString, "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Default
        blnReloading = True

        LoadMembers()
        chkNewM.Checked = False
        grpMembers.Enabled = True

    End Sub
    Private Sub chkNewM_CheckedChanged(sender As Object, e As EventArgs) Handles chkNewM.CheckedChanged
        Dim chk As CheckBox
        chk = DirectCast(sender, CheckBox)
        If chk.Checked Then
            chkUpdateMember.Checked = False
            chkUpdateMember.Enabled = False
        Else
            chkUpdateMember.Enabled = True
        End If

        If blnClearing Then
            Exit Sub
        End If
        If chkNewM.Checked Then
            tslStatus.Text = ""
            txtPID.Clear()
            txtFName.Clear()
            txtLName.Clear()
            txtMI.Clear()
            txtEmail.Clear()
            mskPhone.Clear()
            pbPhoto.Image = Nothing
            lstMembers.SelectedIndex = -1
            grpImage.Enabled = True
            grpMembers.Enabled = True
            grpEdit.Enabled = True
            grpSearch.Enabled = True
            objMembers.CreateNewMember()
            txtPID.Focus()
        Else
            grpMembers.Enabled = False
            grpEdit.Enabled = False
            grpImage.Enabled = False
            objMembers.CurrentObject.IsNewMember = False
        End If
    End Sub

    Private Sub frmMembers_Load(sender As Object, e As EventArgs) Handles Me.Load
        objMembers = New CMembers
        RoleInfo = New frmRole
        MainPage = New frmMain
        MemberRoleInfo = New frmMbrRole
        tslStatus.Text = ""
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim objReader As SqlDataReader
        lstSearch.Items.Clear()
        Try
            objReader = objMembers.GetAllMembers()
            Do While objReader.Read
                If objReader.Item("LName").ToString.Contains(txtSearch.Text) Then
                    lstSearch.Items.Add(objReader.Item("PID") + " " + objReader.Item("LName") + ", " + objReader.Item("FName"))
                End If
            Loop
            objReader.Close()

        Catch ex As Exception
            MessageBox.Show("Error searching for Members", "Program error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub chkFind_CheckedChanged(sender As Object, e As EventArgs)
    '    If blnClearing Then
    '        Exit Sub
    '    End If
    '    If chkFind.Checked Then
    '        tslStatus.Text = ""
    '        txtSearch.Clear()
    '        grpEdit.Enabled = True
    '        grpMembers.Enabled = False
    '        txtSearch.Focus()
    '        grpSearch.Enabled = True
    '        grpImage.Enabled = True

    '    Else
    '        grpMembers.Enabled = True
    '        'chkFind.Enabled = True
    '        grpSearch.Enabled = False
    '        grpEdit.Enabled = True
    '    End If
    'End Sub
    Private Sub lstSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSearch.SelectedIndexChanged
        If blnClearing Then
            Exit Sub
        End If
        If Not blnReloading Then
            tslStatus.Text = ""

        End If
        If lstSearch.SelectedIndex = -1 Then
            Exit Sub

        End If
        'chkFind.Checked = False
        LoadSelectedSearchRecord()
        grpSearch.Enabled = True
    End Sub

    Private Sub frmMembers_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ClearScreenControls(Me)
        grpEdit.Enabled = False
        grpSearch.Enabled = False
        grpImage.Enabled = False
        grpMembers.Enabled = False
        LoadMembers()

    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim ofd As OpenFileDialog = New OpenFileDialog
        ofd.DefaultExt = ".jpg"
        ofd.Title = "Image Files "
        ofd.Filter = "Jpeg Files |*.jpg|All Files|*.*"
        If ofd.ShowDialog = DialogResult.OK Then
            pbPhoto.Image = Image.FromFile(ofd.FileName)
            txtPhotoPath.Text = ofd.FileName
        End If

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        blnClearing = True
        tslStatus.Text = ""
        chkNewM.Checked = False
        errP.Clear()
        If lstMembers.SelectedIndex <> -1 Then
            LoadSelectedRecord() 'reload what was selected in case user had messed up the form 
        Else 'disable editing area nothin was currently selected 
            grpEdit.Enabled = False
        End If
        blnClearing = False
        objMembers.CurrentObject.IsNewMember = False
        grpMembers.Enabled = True
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Dim MemberReport As New frmMemberReport
        If lstMembers.Items.Count = 0 Then
            MessageBox.Show("There are no records to print")
        End If
        Me.Cursor = Cursors.WaitCursor
        MemberReport.Display()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub chkUpdateMember_CheckedChanged(sender As Object, e As EventArgs) Handles chkUpdateMember.CheckedChanged
        Dim chk As CheckBox
        chk = DirectCast(sender, CheckBox)
        If chk.Checked Then
            chkNewM.Checked = False
            chkNewM.Enabled = False
            grpMembers.Enabled = True
            grpEdit.Enabled = True
            grpImage.Enabled = True
        Else
            chkNewM.Enabled = True
            grpMembers.Enabled = False
            grpEdit.Enabled = False
            grpImage.Enabled = False
        End If
    End Sub
End Class