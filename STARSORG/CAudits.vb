Imports System.Data.SqlClient
Public Class CAudits
    Private _Audit As CAudit

    Public Sub New()
        _Audit = New CAudit
    End Sub

    Public ReadOnly Property GetCurrentObject() As CAudit
        Get
            Return _Audit
        End Get
    End Property

    Public Sub Clear()
        _Audit = New CAudit
    End Sub

    Public Sub CreateNewAudit()
        Clear()
        _Audit.isNewAudit = True
    End Sub

    Public Function Save() As Integer
        Return _Audit.Save
    End Function

    Public Sub Successful(blnSuccess As Boolean)
        If blnSuccess = 1 Then
            _Audit.Successful = 1
        Else
            _Audit.Successful = 0
        End If
    End Sub
End Class
