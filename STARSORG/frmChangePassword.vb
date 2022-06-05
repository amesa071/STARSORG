Imports System.Data.SqlClient
Public Class frmChangePassword
    Private strPID As String
    Private objSecurities As CSecurities
    Private blnClearing As Boolean
    Private blnReloading As Boolean

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
    End Sub

    Private Sub frmChangePassword_Load(sender As Object, e As EventArgs) Handles Me.Load
        objSecurities = New CSecurities
    End Sub

    Private Sub btnChangePassword_Click(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        Dim blnErrors As Boolean
        'validate
        errP.Clear()
        If Not ValidateTextBoxLength(txtUserID, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtPassword, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtNewPassword, errP) Then
            blnErrors = True
        End If
        If Not ValidateTextBoxLength(txtConfirmPassword, errP) Then
            blnErrors = True
        End If
        If blnErrors Then
            Exit Sub
        End If
        If Not txtNewPassword.Text = txtConfirmPassword.Text Then
            MessageBox.Show("Passwords do not match, please try again.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        With objSecurities.CurrentObject
            .UserID = txtUserID.Text
            .Password = txtPassword.Text
        End With

        Try
            ChangePassword()
        Catch ex As Exception
            MessageBox.Show("Error verifying credentials: " & ex.ToString, "Verification Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'update password
    End Sub

    Private Sub ChangePassword()
        Me.Cursor = Cursors.WaitCursor
        If objSecurities.CheckCredentials() Then
            objSecurities.CurrentObject.Password = txtNewPassword.Text
            Dim intResult As Integer = objSecurities.ChangePassword()
            If intResult = 1 Then 'returns 1 if successful
                MessageBox.Show("Password has been changed. Please log in using your new password.", "Password Successfully Changed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Me.Close()
        Else
            MessageBox.Show("Incorrect login credentials, please try again.", "Incorrect Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Me.Cursor = Cursors.Default
    End Sub
End Class