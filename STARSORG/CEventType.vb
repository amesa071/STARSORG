Imports System.Data.SqlClient
Public Class CEventType
    'Represents a single record in the ROLE table
    Private _mstrEventTypeID As String
    Private _mstrEventTypeDescription As String
    Private _isNewEventType As Boolean
    'constructor
    Public Sub New()
        _mstrEventTypeID = ""
        _mstrEventTypeDescription = ""
    End Sub
#Region "Exposed Properties"
    Public Property EventTypeID As String
        Get
            Return _mstrEventTypeID
        End Get
        Set(strVal As String)
            _mstrEventTypeID = strVal
        End Set
    End Property
    Public Property EventTypeDescription As String
        Get
            Return _mstrEventTypeDescription
        End Get
        Set(strVal As String)
            _mstrEventTypeDescription = strVal
        End Set
    End Property
    Public Property IsNewEventType As Boolean
        Get
            Return _isNewEventType
        End Get
        Set(blnVal As Boolean)
            _isNewEventType = blnVal
        End Set
    End Property
    Public ReadOnly Property GetSaveParameters() As ArrayList
        Get
            Dim params As New ArrayList
            params.Add(New SqlParameter("eventTypeID", _mstrEventTypeID))
            params.Add(New SqlParameter("eventTypeDescription", _mstrEventTypeDescription))
            Return params
        End Get
    End Property
#End Region
    Public Function Save() As Integer
        'return -1 if the ID already exists (and we cannot create a new record with duplicate ID)
        If IsNewEventType Then
            Dim params As New ArrayList
            params.Add(New SqlParameter("eventTypeID", _mstrEventTypeID))
            Dim strResult As String = myDB.GetSingleValueFromSP("sp_CheckEventTypeIDExists", params)
            If Not strResult = 0 Then
                Return -1 'not unique
            End If
        End If
        'if not a new role, or it is new and has a unique ID, then do the save (update or insert)
        Return myDB.ExecSP("sp_saveEventType", GetSaveParameters())
    End Function
End Class
