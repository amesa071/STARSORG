Imports System.Data.SqlClient
Public Class frmRSVP
    Private objRSVPs As CRSVPs
    Private objEvents As CEvents
    Private blnClearing As Boolean
    Private blnReloading As Boolean
    Private objMembers As CMembers
    Private objSecurities As CSecurities
    'Private PantherID As String = "6166569"
    Private PantherID As String = "0000001"
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
        'nothing to do here
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
    Private Sub LoadRSVPs()
        Dim objReader As SqlDataReader
        lstRSVPEvents.Items.Clear()
        Try
            objReader = objEvents.GetAllEvents()
            Do While objReader.Read
                'IF STATEMENT HERE
                'if the date for the event is later than today's date do this
                If Date.Compare(objReader.Item("EndDate").Date, Today) <> -1 Then
                    lstRSVPEvents.Items.Add(objReader.Item("EventID"))
                End If
            Loop
            objReader.Close()
            LoadCurrentUser()
        Catch ex As Exception
            'currently CDB will display the error
        End Try
        If objEvents.CurrentObject.EventID <> "" Then
            lstRSVPEvents.SelectedIndex = lstRSVPEvents.FindStringExact(objEvents.CurrentObject.EventID)
        End If
        blnReloading = False
    End Sub
    Private Sub frmRSVP_Load(sender As Object, e As EventArgs) Handles Me.Load
        objRSVPs = New CRSVPs
        objEvents = New CEvents
        objMembers = New CMembers
        objSecurities = New CSecurities
        tslStatus.Text = ""

    End Sub

    Private Sub frmRSVP_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'refresh the list each time this form is shown
        clearScreenControls(Me)
        LoadRSVPs()
        grpEventList.Enabled = True
        SetUserConfig(modPrivilege)
    End Sub

    Private Sub LoadCurrentUser()
        Try
            If modPID = "0000001" Then
                grpMemberDetails.Enabled = True
            Else
                grpMemberDetails.Enabled = False
                objMembers.GetMemberbyPID(modPID)
                With objMembers.CurrentObject
                    txtFname.Text = .FName
                    txtLname.Text = .LName
                    txtEmail.Text = .Email
                End With
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading Event values: " & ex.ToString, "Program error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnRSVP_Click(sender As Object, e As EventArgs) Handles btnRSVP.Click
        Dim intResult As Integer
        Dim blnErrors As Boolean
        errP.Clear()
        'first do validation
        If Not ValidateListBox(lstRSVPEvents, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtFname, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtLname, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtEmail, errP) Then
            blnErrors = True
        End If
        If blnErrors Then
            Exit Sub
        End If
        With objRSVPs.CurrentObject
            .EventID = lstRSVPEvents.SelectedItem.ToString
            .FName = txtFname.Text
            .LName = txtLname.Text
            .Email = txtEmail.Text
        End With
        Try
            Me.Cursor = Cursors.WaitCursor
            intResult = objRSVPs.Save
            If intResult = 1 Then
                tslStatus.Text = "RSVP record saved"
            End If
            If intResult = -1 Then 'ID not unique
                MessageBox.Show("An error has occured. Unable to save RSVP record", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                tslStatus.Text = "Error"
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to save Event record", ex.ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Default
        blnReloading = True
        LoadRSVPs() 'reload so that a newly saved record will appear
    End Sub
    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Dim RSVPReport As New frmRSVPReport

        If lstRSVPEvents.Items.Count = 0 Then
            MessageBox.Show("There are no records to print")
            Exit Sub
        End If
        If Not ValidateListBox(lstRSVPEvents, errP) Then
            MessageBox.Show("You must select an event to get its report", "No Event Selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        RSVPReport.Display(lstRSVPEvents.SelectedItem.ToString)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        tslStatus.Text = ""
        txtEmail.Text = ""
        txtFname.Text = ""
        txtLname.Text = ""
        errP.Clear()
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