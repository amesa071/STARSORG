Imports System.Data.SqlClient
Public Class frmEvent
    Private objEvents As CEvents
    Private objEventTypes As CEventTypes
    Private objSemesters As CSemesters
    Private blnClearing As Boolean
    Private blnReloading As Boolean
#Region "ToolbarStuff"

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
        'nothing to do here
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
    Private Sub LoadEvents()
        Dim objReader As SqlDataReader
        lstEvents.Items.Clear()
        cboEventType.Items.Clear()
        cboSemesterID.Items.Clear()
        Try
            objReader = objEvents.GetAllEvents()
            Do While objReader.Read
                lstEvents.Items.Add(objReader.Item("EventID"))
            Loop
            objReader.Close()
            objReader = objEventTypes.GetAllEventTypes()
            Do While objReader.Read
                cboEventType.Items.Add(objReader.Item("EventTypeID"))
            Loop
            objReader.Close()
            objReader = objSemesters.GetAllSemesters()
            Do While objReader.Read
                cboSemesterID.Items.Add(objReader.Item("SemesterID"))
            Loop
            objReader.Close()
        Catch ex As Exception
            'currently CDB will display the error
        End Try
        If objEvents.CurrentObject.EventID <> "" Then
            lstEvents.SelectedIndex = lstEvents.FindStringExact(objEvents.CurrentObject.EventID)
        End If
        If objEventTypes.CurrentObject.EventTypeID <> "" Then
            cboEventType.SelectedIndex = cboEventType.FindStringExact(objEvents.CurrentObject.EventTypeID)
        End If
        If objEventTypes.CurrentObject.EventTypeID <> "" Then
            cboSemesterID.SelectedIndex = cboSemesterID.FindStringExact(objSemesters.CurrentObject.SemesterID)
        End If
        blnReloading = False
    End Sub

    Private Sub frmEvent_Load(sender As Object, e As EventArgs) Handles Me.Load
        objEvents = New CEvents
        objEventTypes = New CEventTypes
        objSemesters = New CSemesters
        tslStatus.Text = ""
    End Sub

    Private Sub frmEvent_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'refresh the list each time this form is shown
        clearScreenControls(Me)
        LoadEvents()
        grpEditEvent.Enabled = False
    End Sub
    Private Sub lstEvents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstEvents.SelectedIndexChanged
        If blnClearing Then
            tslStatus.Text = ""
        End If
        If lstEvents.SelectedIndex = -1 Then 'nothing to do
            Exit Sub
        End If
        chkNew.Checked = False
        LoadSelectedRecord()
        grpEditEvent.Enabled = True
    End Sub
    Private Sub LoadSelectedRecord()
        Try
            objEvents.GetEventByEventID(lstEvents.SelectedItem.ToString)
            With objEvents.CurrentObject
                txtEventID.Text = .EventID
                txtDesc.Text = .EventDescription
                cboEventType.SelectedItem = .EventTypeID
                cboSemesterID.SelectedItem = .SemesterID
                dtmStart.Value = .StartDate
                dtmEnd.Value = .EndDate
                txtLocation.Text = .Location
                If Date.Compare(.EndDate.Date, Today) = -1 Then
                    txtEventID.Enabled = False
                    txtDesc.Enabled = False
                    'cboEventType.Enabled = False
                    cboSemesterID.Enabled = False
                    dtmStart.Enabled = False
                    dtmEnd.Enabled = False
                    txtLocation.Enabled = False
                Else
                    txtEventID.Enabled = True
                    txtDesc.Enabled = True
                    'cboEventType.Enabled = False
                    cboSemesterID.Enabled = True
                    dtmStart.Enabled = True
                    dtmEnd.Enabled = True
                    txtLocation.Enabled = True
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Error loading Event values: " & ex.ToString, "Program error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim intResult As Integer
        Dim blnErrors As Boolean
        errP.Clear()
        'first do validation
        If Not ValidateTextBoxLength(txtEventID, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtDesc, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtLocation, errP) Then
            blnErrors = True
        End If
        If Not ValidateCombo(cboEventType, errP) Then
            blnErrors = True
        End If
        If Not ValidateCombo(cboSemesterID, errP) Then
            blnErrors = True
        End If
        If Date.Compare(dtmStart.Value, dtmEnd.Value) >= 0 Then
            errP.SetError(dtmStart, "Enter a start date that is earlier than the end date")
            errP.SetError(dtmEnd, "Enter an end date that is later than the start date")
            blnErrors = True
        End If
        If blnErrors Then
            Exit Sub
        End If
        With objEvents.CurrentObject
            .EventID = txtEventID.Text
            .EventDescription = txtDesc.Text
            .EventTypeID = cboEventType.SelectedItem.ToString
            .SemesterID = cboSemesterID.SelectedItem.ToString
            .StartDate = dtmStart.Value
            .EndDate = dtmEnd.Value
            .Location = txtLocation.Text
        End With
        Try
            Me.Cursor = Cursors.WaitCursor
            intResult = objEvents.Save
            If intResult = 1 Then
                tslStatus.Text = "Event record saved"
            End If
            If intResult = -1 Then 'ID not unique
                MessageBox.Show("EventID must be unique. Unable to save Event record", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                tslStatus.Text = "Error"
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to save Event record", ex.ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Default
        blnReloading = True
        LoadEvents() 'reload so that a newly saved record will appear
        chkNew.Checked = False
        grpEvents.Enabled = True 'in case it was disabled for a new record
    End Sub

    Private Sub chkNew_CheckedChanged(sender As Object, e As EventArgs) Handles chkNew.CheckedChanged
        If blnClearing Then
            Exit Sub
        End If
        If chkNew.Checked Then
            tslStatus.Text = ""
            txtEventID.Clear()
            txtDesc.Clear()
            txtLocation.Clear()
            lstEvents.SelectedIndex = -1
            grpEvents.Enabled = False
            grpEditEvent.Enabled = True
            objEvents.CreateNewEvent()
            txtEventID.Focus()
            cboEventType.SelectedIndex = -1
            cboSemesterID.SelectedIndex = -1
            txtEventID.Enabled = True
            txtDesc.Enabled = True
            'cboEventType.Enabled = False
            cboSemesterID.Enabled = True
            dtmStart.Enabled = True
            dtmEnd.Enabled = True
            txtLocation.Enabled = True
        Else
            grpEvents.Enabled = True
            grpEditEvent.Enabled = False
            objEvents.CurrentObject.IsNewEvent = False
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        blnClearing = True
        tslStatus.Text = ""
        chkNew.Checked = False
        errP.Clear()
        If lstEvents.SelectedIndex <> -1 Then
            LoadSelectedRecord() 'reload what was selected in case user had messed up the form
        Else 'disable edit area - nothing was currently selected
            grpEditEvent.Enabled = False
        End If
        blnClearing = False
        objEvents.CurrentObject.IsNewEvent = False
        grpEvents.Enabled = True

    End Sub
End Class