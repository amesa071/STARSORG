Imports System.Data.SqlClient
Public Class CEvents
    'Represents the EVENT table and its associated business rules
    Private _Event As CEvent
    'constructor
    Public Sub New()
        'instantiate the CEvent object
        _Event = New CEvent
    End Sub
    Public ReadOnly Property CurrentObject() As CEvent
        Get
            Return _Event
        End Get
    End Property
    Public Sub Clear()
        _Event = New CEvent
    End Sub
    Public Sub CreateNewEvent()
        'call this when clearing the edit portion of the screen to add a new event
        Clear()
        _Event.IsNewEvent = True
    End Sub
    Public Function Save() As Integer
        Return _Event.Save()
    End Function
    Public Function GetAllEvents() As SqlDataReader
        Dim objDR As SqlDataReader
        objDR = myDB.GetDataReaderBySP("sp_getALLEvents", Nothing)
        Return objDR
    End Function
    Public Function GetEventByEventID(strID As String) As CEvent
        Dim params As New ArrayList
        'Dim objDR as SqlDataReader
        params.Add(New SqlParameter("eventID", strID))
        FillObject(myDB.GetDataReaderBySP("sp_getEventByEventID", params))
        Return _Event
    End Function
    Public Function FillObject(objDR As SqlDataReader) As CEvent
        If objDR.Read Then
            With _Event
                .EventID = objDR.Item("EventID")
                .EventDescription = objDR.Item("EventDescription")
                .EventTypeID = objDR.Item("EventTypeID")
                .SemesterID = objDR.Item("SemesterID")
                .StartDate = objDR.Item("StartDate")
                .EndDate = objDR.Item("EndDate")
                .Location = objDR.Item("Location")
            End With
        Else 'no record was returned
            'nothing to do here
        End If
        objDR.Close()
        Return _Event
    End Function
End Class
