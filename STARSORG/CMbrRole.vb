Imports System.Data.SqlClient
Public Class CMbrRole
    Private _mstrPID As String
    Private _mstrRoleID As String
    Private _mstrSemesterID As String

    Public Sub New()
        _mstrPID = ""
        _mstrRoleID = ""
        _mstrSemesterID = ""
    End Sub


    Public Property PID As String
        Get
            Return _mstrPID
        End Get
        Set(strValue As String)
            _mstrPID = strValue
        End Set
    End Property
    Public Property SemesterID As String
        Get
            Return _mstrSemesterID
        End Get
        Set(strValue As String)
            _mstrSemesterID = strValue
        End Set
    End Property
    Public Property RoleID As String
        Get
            Return _mstrRoleID
        End Get
        Set(strValue As String)
            _mstrRoleID = strValue
        End Set
    End Property

    Public ReadOnly Property GetSaveParameters As ArrayList
        Get
            Dim params As New ArrayList
            params.Add(New SqlParameter("RoleID", _mstrRoleID))
            params.Add(New SqlParameter("PID", _mstrPID))
            params.Add(New SqlParameter("SemesterID", _mstrSemesterID))
            Return params
        End Get
    End Property

    Public Function Save() As Integer
        Return myDB.ExecSP("sp_SaveMemberRole", GetSaveParameters)

    End Function

    Public Function Delete() As Integer
        Return myDB.ExecSP("sp_deleteMemberRolesByPIDAndSemesterID", GetSaveParameters)
    End Function
    Public Function GetReportData() As SqlDataAdapter
        Return myDB.GetDataAdapterBySP("dbo.sp_getAllMemberRoles", Nothing)
    End Function
End Class
