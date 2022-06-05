Imports System.Data.SqlClient
'in this case, security represents a set of credentials
Public Class CSecurity
    Private _mstrPID As String
    Private _mstrUserID As String
    Private _mstrPassword As String
    Private _mstrSecRole As String
    Private _isNewCredentials As Boolean

    Public Sub New()
        _mstrPID = ""
        _mstrUserID = ""
        _mstrPassword = ""
        _mstrSecRole = ""
    End Sub

#Region "Exposed properties"
    Public Property PID As String
        Get
            Return _mstrPID
        End Get
        Set(strVal As String)
            _mstrPID = strVal
        End Set
    End Property

    Public Property UserID As String
        Get
            Return _mstrUserID
        End Get
        Set(strVal As String)
            _mstrUserID = strVal
        End Set
    End Property

    Public Property Password As String
        Get
            Return _mstrPassword
        End Get
        Set(strVal As String)
            _mstrPassword = strVal
        End Set
    End Property

    Public Property SecurityRole As String
        Get
            Return _mstrSecRole
        End Get
        Set(strVal As String)
            _mstrSecRole = strVal
        End Set
    End Property

    Public Property isNewCredentials As Boolean
        Get
            Return _isNewCredentials
        End Get
        Set(blnVal As Boolean)
            _isNewCredentials = blnVal
        End Set
    End Property

    Public ReadOnly Property GetSaveParameters 'for creating new credentials
        Get
            Dim params As New ArrayList
            params.Add(New SqlParameter("secRole", _mstrSecRole))
            params.Add(New SqlParameter("PID", _mstrPID))
            params.Add(New SqlParameter("userID", _mstrUserID))
            params.Add(New SqlParameter("password", _mstrPassword))
            'basically, this is creating a parameter in an arraylist of parameters to slot into the stored procedures parameter(s)
            'for ex. params.Add(New SqlParameter("param1", someStrInClass)) tells the program
            '"I want the someStrInClass variable to be the parameter named param1 in sp_thisIsAProcedure(param1, param2)"
            Return params
        End Get
    End Property
#End Region

    Public Function ChangePassword() As Integer 'to be used in change password login form
        Dim params As New ArrayList
        params.Add(New SqlParameter("userID", _mstrUserID))
        Dim strResult As String = myDB.GetSingleValueFromSP("sp_checkUserIDExists", params) 'Return -1 If userid exists
        If strResult = "1" Then 'found a record
            params = New ArrayList
            params.Add(New SqlParameter("userID", _mstrUserID))
            params.Add(New SqlParameter("password", _mstrPassword))
            params.Add(New SqlParameter("secRole", _mstrSecRole))
            Return myDB.ExecSP("sp_updatePassword", params) 'returns true/1 if successful
        End If
        Return -1 'DOES NOT EXIST
    End Function

    Public Function CreateNewCredentials() As Integer 'to be used in the admin form
        Dim params As New ArrayList
        params.Add(New SqlParameter("userID", _mstrUserID))
        Dim strResult As String = myDB.GetSingleValueFromSP("sp_checkUserIDExists", params)
        If strResult = 0 Then
            Return myDB.ExecSP("sp_updateCredentials", GetSaveParameters)
        End If
        Return -1 'userID exists
        'DOES NOT EXIST
    End Function

    Public Function UpdateCredentials() As Integer 'to be used in the admin form
        Dim params As New ArrayList
        params.Add(New SqlParameter("userID", _mstrUserID))
        Dim strResult As String = myDB.GetSingleValueFromSP("sp_checkUserIDExists", params) 'Return -1 If userid exists
        If strResult = "1" Then 'found a record
            Return myDB.ExecSP("sp_updateCredentials", GetSaveParameters)
        End If
        Return -1
        'DOES NOT EXIST
    End Function

    Public Function DeleteCredentials() As Integer
        Dim params As New ArrayList
        params.Add(New SqlParameter("PID", _mstrPID))
        Return myDB.ExecSP("sp_deleteCredentials", params)
    End Function

End Class
