Imports System.Data.SqlClient
Public Class CAudit
    Private _mstrPID As String
    Private _mdtmAccessTimeStamp As DateTime
    Private _mblnSuccess As Boolean
    Private _isNewAudit As Boolean


    Public Sub New()
        _mstrPID = "0000000"
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

    Public Property AccessTimeStamp As DateTime
        Get
            Return _mdtmAccessTimeStamp
        End Get
        Set(dtmVal As DateTime)
            _mdtmAccessTimeStamp = dtmVal
        End Set
    End Property

    Public Property Successful As Boolean
        Get
            Return _mblnSuccess
        End Get
        Set(blnVal As Boolean)
            _mblnSuccess = blnVal
        End Set
    End Property

    Public Property isNewAudit As Boolean
        Get
            Return _isNewAudit
        End Get
        Set(blnVal As Boolean)
            _isNewAudit = blnVal
        End Set
    End Property

    Public ReadOnly Property GetSaveParameters() As ArrayList
        Get
            Dim params As New ArrayList
            params.Add(New SqlParameter("PID", _mstrPID))
            params.Add(New SqlParameter("accessTimeStamp", _mdtmAccessTimeStamp))
            params.Add(New SqlParameter("success", _mblnSuccess))
            Return params
        End Get
    End Property

#End Region
    Public Function Save() As Integer
        Return myDB.ExecSP("sp_saveAudit", GetSaveParameters())
    End Function

End Class
