Imports System.Data.SqlClient
Public Class CRoles
    'Represents the ROLE table and its associated business rules
    Private _Role As CRole
    'constructor
    Public Sub New()
        'instantiate the CRole object
        _Role = New CRole
    End Sub

    Public ReadOnly Property CurrentObject() As CRole
        Get
            Return _Role
        End Get
    End Property

    Public Sub Clear()
        _Role = New CRole
    End Sub

    Public Sub CreateNewRole()
        'call this when clearing the edit portion of the screen to add a new role
        Clear()
        _Role.isNewRole = True
    End Sub

    Public Function Save() As Integer
        Return _Role.Save
    End Function

    Public Function GetAllRoles() As SqlDataReader
        Dim objDR As SqlDataReader
        objDR = myDB.GetDataReaderBySP("sp_getAllRoles", Nothing)
        Return objDR
    End Function
    Public Function GetRoleByRoleID(strID As String) As CRole
        Dim params As New ArrayList
        params.Add(New SqlParameter("roleID", strID))
        FillObject(myDB.GetDataReaderBySP("sp_getRoleByRoleID", params))
        Return _Role
    End Function

    Private Function FillObject(objDR As SqlDataReader) As CRole
        If objDR.Read Then
            With _Role
                .RoleID = objDR.Item("RoleID")
                .RoleDescription = objDR.Item("RoleDescription")
            End With
        Else 'no record was returned
            'nothing to do here
        End If
        objDR.Close()
        Return _Role
    End Function
End Class
