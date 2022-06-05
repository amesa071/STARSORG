Imports System.Data.SqlClient
Public Class CRSVPs
    'Represents the EVENT_RSVP table and its associated business rules
    Private _EventRSVP As CRSVP
    'constructor
    Public Sub New()
        'instantiate the CEvent object
        _EventRSVP = New CRSVP
    End Sub
    Public ReadOnly Property CurrentObject() As CRSVP
        Get
            Return _EventRSVP
        End Get
    End Property
    Public Sub Clear()
        _EventRSVP = New CRSVP
    End Sub
    Public Sub CreateNewRSVP()
        'call this when clearing the edit portion of the screen to add a new event
        Clear()
        _EventRSVP.IsNewRSVP = True
    End Sub
    Public Function Save() As Integer
        Return _EventRSVP.Save()
    End Function
    Public Function GetAllEvents() As SqlDataReader
        Dim objDR As SqlDataReader
        objDR = myDB.GetDataReaderBySP("sp_getALLEvents", Nothing)
        Return objDR
    End Function

    Public Function GetPIDByUserID(strID As String) As CRSVP
        Dim params As New ArrayList
        params.Add(New SqlParameter("userID", strID))
        FillObject(myDB.GetDataReaderBySP("sp_getPIDByUserID", params))
        Return _EventRSVP
    End Function
    'MIGHT NOT NEED THIS FUNCTION BELOW
    Public Function GetEventByEventID(strID As String) As CRSVP
        Dim params As New ArrayList
        'Dim objDR as SqlDataReader
        params.Add(New SqlParameter("eventID", strID))
        FillObject(myDB.GetDataReaderBySP("sp_getEventByEventID", params))
        Return _EventRSVP
    End Function
    Public Function FillObject(objDR As SqlDataReader) As CRSVP
        If objDR.Read Then
            With _EventRSVP
                .EventID = objDR.Item("EventID")
                .FName = objDR.Item("FName")
                .LName = objDR.Item("LName")
                .Email = objDR.Item("Email")
            End With
        Else 'no record was returned
            'nothing to do here
        End If
        objDR.Close()
        Return _EventRSVP
    End Function
End Class
