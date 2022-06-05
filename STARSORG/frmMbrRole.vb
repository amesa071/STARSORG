Imports System.Data.SqlClient
Public Class frmMbrRole
    Private objMRole As CMbrRoles
    Private objMembers As CMembers
    Private objSemesters As CSemesters
    Private objRoles As CRoles
    Private intRoleCount As Integer = 0
    Private blnReloading As Boolean
    Private blnClearing As Boolean
    Private arrChecked As ArrayList
    Private arrRoles As ArrayList
    Dim strPID As String
    Dim strSID As String

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
        intNextAction = ACTION_ADMIN
        Me.Hide()
    End Sub

    Private Sub tsbMemberRoles_Click(sender As Object, e As EventArgs) Handles tsbMemberRoles.Click
        'nothing to do here
        Me.Hide()
    End Sub
#End Region

    Private Sub LoadMembers()
        Dim objReader As SqlDataReader
        lstMembers.Items.Clear()
        Try
            objReader = objMembers.GetAllMembers()
            Do While objReader.Read
                lstMembers.Items.Add(objReader.Item("PID") + " " + objReader.Item("LName") + ", " + objReader.Item("FName"))
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
    Private Sub LoadSemesters()
        Dim objReader As SqlDataReader
        lstSemesters.Items.Clear()
        Try
            objReader = objSemesters.GetAllSemesters()
            Do While objReader.Read
                lstSemesters.Items.Add(objReader.Item("SemesterID"))
            Loop
            objReader.Close()
        Catch ex As Exception
            'currently CDB will display the error

        End Try
        If objSemesters.CurrentObject.SemesterID <> "" Then
            lstSemesters.SelectedIndex = lstSemesters.FindStringExact(objSemesters.CurrentObject.SemesterID)
        End If
        blnReloading = False
    End Sub
    Private Sub lstBoxes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMembers.SelectedIndexChanged, lstSemesters.SelectedIndexChanged
        If lstMembers.SelectedIndex <> -1 And lstSemesters.SelectedIndex <> -1 Then
            strPID = lstMembers.SelectedItem.ToString.Substring(0, 7)
            strSID = lstSemesters.SelectedItem.ToString
            If blnClearing Then
                Exit Sub
            End If
            If Not blnReloading Then
                tslStatus.Text = ""
            End If
            If lstMembers.SelectedIndex = -1 Then 'nothing to do 
                Exit Sub
            End If
            For i As Integer = 0 To intRoleCount - 1
                chklstRoles.SetItemChecked(i, False)
            Next
            Try
                RefreshSelectedRoles()
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.ToString, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub RefreshSelectedRoles()
        Dim objReader As SqlDataReader
        For i As Integer = 0 To arrRoles.Count - 1
            arrChecked(i) = False
        Next
        objReader = objMRole.GetMemberRoleByPIDAndSemsterID(strPID, strSID)
        Do While objReader.Read
            Dim Role As String
            For Each Role In arrRoles
                If objReader.Item("RoleID") = Role Then
                    arrChecked(arrRoles.IndexOf(Role)) = True
                    chklstRoles.SetItemChecked(arrRoles.IndexOf(Role), True)
                End If

            Next
        Loop
        objReader.Close()
    End Sub

    Private Sub frmMbrRole_Load(sender As Object, e As EventArgs) Handles Me.Load
        objMembers = New CMembers
        objSemesters = New CSemesters
        objRoles = New CRoles
        objMRole = New CMbrRoles
        arrRoles = New ArrayList
        arrChecked = New ArrayList
        tslStatus.Text = ""
    End Sub

    Private Sub frmMbrRole_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ClearScreenControls(Me)
        chklstRoles.Items.Clear()

        LoadMembers()
        LoadSemesters()
        LoadCheckedListBox()
    End Sub
    Private Sub LoadCheckedListBox()
        Dim objReader As SqlDataReader
        Try
            objReader = objRoles.GetAllRoles()
            Do While objReader.Read
                chklstRoles.Items.Add(objReader.Item("RoleID"))
                arrRoles.Add(objReader.Item("RoleID"))
                arrChecked.Add(False)
            Loop
            objReader.Close()
        Catch ex As Exception

        End Try
        blnReloading = False
        intRoleCount = chklstRoles.Items.Count
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim i As Integer
        Dim arrSaved(chklstRoles.Items.Count - 1) As Boolean
        Dim intResult As Integer

        For i = 0 To arrSaved.Length - 1
            arrSaved(i) = chklstRoles.GetItemChecked(i)
        Next

        Try
            For i = 0 To intRoleCount - 1
                If arrChecked(i) <> arrSaved(i) Then
                    If arrChecked(i) = True Then

                        objMRole.CurrentObject.RoleID = arrRoles(i)
                        objMRole.CurrentObject.PID = strPID
                        objMRole.CurrentObject.SemesterID = strSID
                        intResult = objMRole.Delete()
                        If intResult = -1 Then
                            MessageBox.Show("Failed to Delete", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        'The three lines below can be used for assignning a new member a member role.
                        objMRole.CurrentObject.RoleID = arrRoles(i)
                        objMRole.CurrentObject.PID = strPID
                        objMRole.CurrentObject.SemesterID = strSID
                        intResult = objMRole.Save()
                        If intResult = -1 Then
                            MessageBox.Show("Failed to Save", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End If
            Next
            tslStatus.Text = "Member Role Updated"
            RefreshSelectedRoles()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.ToString, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Dim MemberRoleReport As New frmMemberRoleReport
        If lstMembers.Items.Count = 0 Then
            MessageBox.Show("There are no records to print")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        MemberRoleReport.Display()
        Me.Cursor = Cursors.Default
    End Sub
End Class