Imports System.Data.SqlClient
Public Class CSecurities
    'represents all fields in the security table
    Private _Security As New CSecurity

    Public Sub New()
        _Security = New CSecurity
    End Sub

    Public ReadOnly Property CurrentObject() As CSecurity
        Get
            Return _Security
        End Get
    End Property

    Public Sub Clear()
        _Security = New CSecurity
    End Sub

    Public Function CreateNewCredentials() As Integer
        'returns 1 if successful
        _Security.isNewCredentials = True
        Return _Security.CreateNewCredentials()
    End Function
    Public Function UpdateCredentials() As Integer
        'returns 1 if successful
        _Security.isNewCredentials = True
        Return _Security.UpdateCredentials()
    End Function

    Public Function DeleteCredentials() As Integer
        Return _Security.DeleteCredentials
    End Function

    Public Function CheckCredentials() As Boolean
        Dim objDR As SqlDataReader
        Dim params As New ArrayList
        params.Add(New SqlParameter("userID", _Security.UserID))
        params.Add(New SqlParameter("password", _Security.Password))
        objDR = myDB.GetDataReaderBySP("sp_checkCredentialsExist", params)
        If objDR.Read Then
            FillObject(objDR)
            objDR.Close()
            Return True
        Else
            objDR.Close()
            Return False
        End If
    End Function

    Public Function GetCredentialsByPID(strPID As String) As CSecurity
        Dim objDR As SqlDataReader
        Dim params As New ArrayList
        params.Add(New SqlParameter("PID", strPID))
        objDR = myDB.GetDataReaderBySP("sp_getCredentialsByPID", params)
        If objDR.Read Then
            FillObject(objDR)
        End If
        objDR.Close()
        Return _Security
    End Function

    Public Function CheckUserIDExists(strUserID As String) As Boolean
        Dim params As New ArrayList
        params.Add(New SqlParameter("UserID", strUserID))
        Dim intResult As Integer = myDB.GetSingleValueFromSP("sp_checkUserIDExists", params)
        If intResult = 1 Then
            Return True
        End If
        Return False
    End Function

    Public Function ChangePassword() As Integer 'for only changing a password (frmChangePassword)
        Return _Security.ChangePassword()
    End Function

    Private Sub FillObject(objDR As SqlDataReader)
        With _Security
            .UserID = objDR.Item("UserID")
            .Password = objDR.Item("Password")
            .PID = objDR.Item("PID")
            .SecurityRole = objDR.Item("SecRole")
        End With
        'Return _Security
    End Sub
End Class
