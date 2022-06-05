Imports System.Data.SqlClient
Public Class CRole
    'represents a single record in the ROLE table
    'make one  class variable for ecery field in the table
    Private _mstrRoleID As String
    Private _mstrRoleDesctiption As String
    Private _isNewRole As Boolean 'to be used internally

    'contructor
    Public Sub New()
        _mstrRoleID = ""
        _mstrRoleDesctiption = ""
    End Sub

#Region "Exposed properties"
    Public Property RoleID As String
        Get
            Return _mstrRoleID
        End Get
        Set(strVal As String)
            _mstrRoleID = strVal
        End Set
    End Property

    Public Property RoleDescription As String
        Get
            Return _mstrRoleDesctiption
        End Get
        Set(strVal As String)
            _mstrRoleDesctiption = strVal
        End Set
    End Property

    Public Property isNewRole As Boolean
        Get
            Return _isNewRole
        End Get
        Set(blnVal As Boolean)
            _isNewRole = blnVal
        End Set
    End Property

    Public ReadOnly Property GetSaveParameters() As ArrayList
        'this property's code will create the parameters for the stored procedures to save a record
        Get
            Dim params As New ArrayList
            params.Add(New SqlParameter("roleID", _mstrRoleID))
            'basically, this is creating a parameter in an arraylist of parameters to slot into the stored procedures parameter(s)
            'for ex. params.Add(New SqlParameter("param1", someStrInClass)) tells the program
            '"I want the someStrInClass variable to be the parameter named param1 in sp_thisIsAProcedure(param1, param2)"
            params.Add(New SqlParameter("roleDescription", _mstrRoleDesctiption))
            Return params
        End Get
    End Property
#End Region

    Public Function Save() As Integer
        'return -1 if the ID already exists and we cannot create a new record with duplicate ID
        If isNewRole Then
            Dim params As New ArrayList
            params.Add(New SqlParameter("roleID", _mstrRoleID))
            Dim strResult As String = myDB.GetSingleValueFromSP("sp_checkRoleIDExists", params)
            If Not strResult = 0 Then
                Return -1 'not unique
            End If
            'if not a new role, or it is new and it has a unique id, then do the save (update or insert)
        End If
        Return myDB.ExecSP("sp_saveRole", GetSaveParameters())
    End Function

    Public Function GetReportData() As SqlDataAdapter
        Return myDB.GetDataAdapterBySP("dbo.sp_getAllRoles", Nothing)
    End Function
End Class
