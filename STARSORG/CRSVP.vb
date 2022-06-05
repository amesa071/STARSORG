Imports System.Data.SqlClient
Public Class CRSVP
    'Represents a single record in the EVENT_RSVP table

    Private _mstrEventID As String
    Private _mstrFName As String
    Private _mstrLName As String
    Private _mstrEmail As String
    Private _isNewRSVP As Boolean
    'constructor
    Public Sub New()
        _mstrEventID = ""
        _mstrFName = ""
        _mstrLName = ""
        _mstrEmail = ""
    End Sub
#Region "Exposed Properties"
    Public Property EventID As String
        Get
            Return _mstrEventID
        End Get
        Set(strVal As String)
            _mstrEventID = strVal
        End Set
    End Property
    Public Property FName As String
        Get
            Return _mstrFName
        End Get
        Set(strVal As String)
            _mstrFName = strVal
        End Set
    End Property
    Public Property LName As String
        Get
            Return _mstrLName
        End Get
        Set(strVal As String)
            _mstrLName = strVal
        End Set
    End Property
    Public Property Email As String
        Get
            Return _mstrEmail
        End Get
        Set(strVal As String)
            _mstrEmail = strVal
        End Set
    End Property

    Public Property IsNewRSVP As Boolean
        Get
            Return _isNewRSVP
        End Get
        Set(blnVal As Boolean)
            _isNewRSVP = blnVal
        End Set
    End Property
    Public ReadOnly Property GetSaveParameters() As ArrayList
        Get
            Dim params As New ArrayList
            params.Add(New SqlParameter("eventID", _mstrEventID))
            params.Add(New SqlParameter("FName", _mstrFName))
            params.Add(New SqlParameter("LName", _mstrLName))
            params.Add(New SqlParameter("Email", _mstrEmail))
            Return params
        End Get
    End Property
#End Region
    Public Function Save() As Integer
        ''return -1 if the ID already exists (and we cannot create a new record with duplicate ID)
        'If IsNewRSVP Then
        '    Dim params As New ArrayList
        '    params.Add(New SqlParameter("eventID", _mstrEventID))
        '    Dim strResult As String = myDB.GetSingleValueFromSP("sp_CheckRSVPExists", params)
        '    If Not strResult = 0 Then
        '        Return -1 'not unique
        '    End If
        'End If
        ''if not a new event, or it is new and has a unique ID, then do the save (update or insert)
        Return myDB.ExecSP("sp_saveRSVP", GetSaveParameters())
    End Function

    Public Function GetReportData(strID As String) As SqlDataAdapter
        Dim params As New ArrayList
        params.Add(New SqlParameter("eventID", strID))
        Return myDB.GetDataAdapterBySP("dbo.sp_getRSVPByEventID", params)
        'Return myDB.GetDataAdapterBySP("dbo.sp_getAllRSVPs", Nothing)
    End Function
End Class
