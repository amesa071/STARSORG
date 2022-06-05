Imports System.Data.SqlClient
Public Class frmCourse
    Private objCourses As CCourses
    Private blnClearing As Boolean
    Private blnReloading As Boolean
#Region "Toolbar stuff"
#Region "Textboxes"
    Private Sub txtBoxes_GotFocus(sender As Object, e As EventArgs) Handles txtDesc.GotFocus, txtCourseID.GotFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.SelectAll()
    End Sub

    Private Sub txtBoxes_LostFocus(sender As Object, e As EventArgs) Handles txtCourseID.LostFocus, txtDesc.LostFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.DeselectAll()
    End Sub
#End Region
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
        'nothing to do here
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
        intNextAction = ACTION_ADMIN
        Me.Hide()
    End Sub

    Private Sub tsbMemberRoles_Click(sender As Object, e As EventArgs) Handles tsbMemberRoles.Click
        intNextAction = ACTION_MBRROLE
        Me.Hide()
    End Sub
#End Region


    Private Sub LoadCourses()
        Dim objDR As SqlDataReader
        lstCourses.Items.Clear()
        Try
            objDR = objCourses.GetAllCourses()
            Do While objDR.Read
                lstCourses.Items.Add(objDR.Item("CourseID"))
            Loop
            objDR.Close()
        Catch ex As Exception
            'could have cdb throw the error and trap it here
        End Try
        If objCourses.CurrentObject.CourseID <> "" Then
            lstCourses.SelectedIndex = lstCourses.FindStringExact(objCourses.CurrentObject.CourseID)
        End If
        blnReloading = False
    End Sub

    Private Sub frmCourse_Load(sender As Object, e As EventArgs) Handles Me.Load
        objCourses = New CCourses
    End Sub

    Private Sub frmCourse_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'refesh the list each time this form is shown
        ClearScreenControls(Me)
        LoadCourses()
        grpEdit.Enabled = False
    End Sub

    Private Sub LoadSelectedRecord()
        Try
            objCourses.GetCourseByCourseID(lstCourses.SelectedItem.ToString)
            With objCourses.CurrentObject
                txtCourseID.Text = .CourseID
                txtDesc.Text = .CourseName
            End With
        Catch ex As Exception
            MessageBox.Show("Error loading Courses values:" & ex.ToString, "program error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lstCourses_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCourses.SelectedIndexChanged
        If blnClearing Then
            Exit Sub
        End If
        If blnReloading Then
            StatusStrip.Text = ""
            Exit Sub
        End If
        If lstCourses.SelectedIndex = -1 Then ' nothing to do
            Exit Sub
        End If
        chkNew.Checked = False
        LoadSelectedRecord()
        grpEdit.Enabled = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim intResult As Integer
        Dim blnErrors As Boolean
        StatusStrip.Text = ""
        'first do validation
        '----add your validation code here'
        If Not ValidateTextBoxLength(txtCourseID, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtDesc, errP) Then
            blnErrors = True
        End If
        If blnErrors Then
            Exit Sub
        End If
        'load the current object from teh textboxes
        With objCourses.CurrentObject
            .CourseID = txtCourseID.Text
            .CourseName = txtDesc.Text
        End With
        Try
            Me.Cursor = Cursors.WaitCursor
            intResult = objCourses.Save
            If intResult = 1 Then
                StatusStrip.Text = "Course record saved"
            End If
            If intResult = -1 Then
                MessageBox.Show("CourseD must be unique. Unable to save the Course record", "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                StatusStrip.Text = "Error"
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to save Course record: " & ex.ToString, "Databse error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            StatusStrip.Text = "Error"
        End Try
        Me.Cursor = Cursors.Default
        blnReloading = True
        LoadCourses() 'reload so that a newly saved record will appear
        chkNew.Checked = False
        grpCourses.Enabled = True ' in case it was disabled for a  new record
    End Sub

    Private Sub chkNew_CheckedChanged(sender As Object, e As EventArgs) Handles chkNew.CheckedChanged
        If blnClearing Then
            Exit Sub
        End If
        If chkNew.Checked Then
            StatusStrip.Text = ""
            txtCourseID.Clear()
            txtDesc.Clear()
            lstCourses.SelectedIndex = -1
            grpCourses.Enabled = False
            grpEdit.Enabled = True
            txtCourseID.Focus()
            objCourses.CreateNewCourse()
        Else
            grpCourses.Enabled = True
            grpEdit.Enabled = False
            objCourses.CurrentObject.IsNewCourse = False
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        blnClearing = True
        StatusStrip.Text = ""
        chkNew.Checked = False
        errP.Clear()
        If lstCourses.SelectedIndex <> -1 Then
            LoadSelectedRecord() 'reload what was selected in case user had messed up the form
        Else
            grpEdit.Enabled = False
        End If
        blnClearing = False
        objCourses.CurrentObject.IsNewCourse = False
        grpCourses.Enabled = True

    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Dim CourseReport As New frmCourseReport
        If lstCourses.Items.Count = 0 Then
            MessageBox.Show("There are no records to print")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        CourseReport.Display()
        Me.Cursor = Cursors.Default
    End Sub
End Class