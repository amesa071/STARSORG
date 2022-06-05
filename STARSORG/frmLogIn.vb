Imports System.Data.SqlClient
Public Class frmLogIn
    Private strPID As String
    Private objSecurities As CSecurities
    Private ChangePassword As frmChangePassword
    Private blnClearing As Boolean
    Private blnReloading As Boolean

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        errP.Clear()
        Dim intResult As Integer
        'validate first
        Dim blnErrors As Boolean
        If Not ValidateTextBoxLength(txtUserID, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtPassword, errP) Then
            blnErrors = True
        End If
        If blnErrors Then
            Exit Sub
        End If


        With objSecurities.CurrentObject
            .UserID = txtUserID.Text
            .Password = txtPassword.Text
        End With
        Try
            CheckCredentials()
        Catch ex As Exception
            MessageBox.Show("Error logging in: " & ex.ToString, "Log In Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CheckCredentials()
        Me.Cursor = Cursors.WaitCursor
        If objSecurities.CheckCredentials() Then
            strPID = objSecurities.CurrentObject.PID
            blnIsLoggedIn = True
            modPID = strPID
            modPrivilege = objSecurities.CurrentObject.SecurityRole
            modUserID = objSecurities.CurrentObject.UserID
            LogNewAudit()
            Me.Close()
        Else
            MessageBox.Show("Incorrect login credentials, please try again.", "Incorrect Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogNewAudit()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LogNewAudit()
        Dim intResult As Integer
        Dim objAudit As CAudits
        Dim strDate As String
        objAudit = New CAudits
        'Dim dtmNow As DateTime
        strDate = DateTime.Now

        With objAudit.GetCurrentObject
            If blnIsLoggedIn = True Then
                .Successful = 1
                .PID = strPID
            Else
                .PID = "9999999"
            End If
            .AccessTimeStamp = strDate 'FormatDateTime(strDate, vbShortDate)
        End With
        Try
            Me.Cursor = Cursors.WaitCursor
            intResult = objAudit.Save
        Catch ex As Exception
            MessageBox.Show("Audit Error: " & ex.ToString, "Audit Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frmLogIn_Load(sender As Object, e As EventArgs) Handles Me.Load
        objSecurities = New CSecurities
        ChangePassword = New frmChangePassword
    End Sub

    Private Sub btnGuestLogIn_Click(sender As Object, e As EventArgs) Handles btnGuestLogIn.Click
        errP.Clear()
        strPID = "0000001"
        modPID = strPID
        modUserID = "GUEST"
        modPrivilege = "GUEST"
        objSecurities.Clear()
        With objSecurities.CurrentObject
            .PID = modPID
            .UserID = modUserID
            .SecurityRole = modPrivilege
        End With
        blnIsLoggedIn = True
        LogNewAudit()
        Me.Close()
    End Sub

    Private Sub btnChangePassword_Click(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        Me.Hide()
        ChangePassword.ShowDialog()
        Me.Show()
    End Sub

    Private Sub txtBoxes_GotFocus(sender As Object, e As EventArgs) Handles txtPassword.GotFocus, txtUserID.GotFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.SelectAll() 'highlight the contents for replacement typing
    End Sub

    Private Sub txtBoxes_LostFocus(sender As Object, e As EventArgs) Handles txtPassword.LostFocus, txtUserID.LostFocus
        Dim txtBox As TextBox
        txtBox = DirectCast(sender, TextBox)
        txtBox.DeselectAll() 'highlight the contents for replacement typing
    End Sub
End Class