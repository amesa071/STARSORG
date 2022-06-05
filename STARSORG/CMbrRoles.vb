Imports System.Data.SqlClient
Public Class CMbrRoles
    Private _MemberRole As CMbrRole

    Public Sub New()
        _MemberRole = New CMbrRole
    End Sub
    Public ReadOnly Property CurrentObject() As CMbrRole
        Get
            Return _MemberRole
        End Get
    End Property
    'Public Sub Clear()
    '    _MemberRole = New CMbrRole
    'End Sub
    'Public Sub CreateNewRole()
    '    'call this when clearing the edit portion of the screen to add a new role
    '    Clear()
    '    _MemberRole.IsNewRole = True
    'End Sub
    Public Function Save() As Integer
        Return _MemberRole.Save()
    End Function
    Public Function Delete() As Integer
        Return _MemberRole.Delete()
    End Function

    Public Function GetMemberRoleByPIDAndSemsterID(strID As String, strSID As String) As SqlDataReader
        Dim params As New ArrayList
        Dim objReader As SqlDataReader

        params.Add(New SqlParameter("PID", strID))
        params.Add(New SqlParameter("SemesterID", strSID))
        objReader = (myDB.getDataReaderBySP("sp_getMemberRolesByPIDAndSemesterID", params))
        Return objReader
    End Function
    Private Function FillObject(objDR As SqlDataReader) As CMbrRole
        If objDR.Read Then
            With _MemberRole
                .PID = objDR.Item("PID")
                .RoleID = objDR.Item("RoleID")
                .SemesterID = objDR.Item("SemesterID")
            End With
        Else
            'nothing to do here
        End If
        objDR.Close()
        Return _MemberRole
    End Function
End Class
