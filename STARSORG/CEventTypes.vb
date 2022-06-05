Imports System.Data.SqlClient
Public Class CEventTypes
    'Represents the EVENT_TYPE table and its associated business rules
    Private _EventType As CEventType
    'constructor
    Public Sub New()
        'instantiate the CEventType object
        _EventType = New CEventType
    End Sub
    Public ReadOnly Property CurrentObject() As CEventType
        Get
            Return _EventType
        End Get
    End Property
    Public Sub Clear()
        _EventType = New CEventType
    End Sub
    Public Sub CreateNewEventType()
        'call this when clearing the edit portion of the screen to add a new event type
        Clear()
        _EventType.IsNewEventType = True
    End Sub
    Public Function Save() As Integer
        Return _EventType.Save()
    End Function
    Public Function GetAllEventTypes() As SqlDataReader
        Dim objDR As SqlDataReader
        objDR = myDB.GetDataReaderBySP("sp_getALLEventTypes", Nothing)
        Return objDR
    End Function
    Public Function GetEventTypeByEventTypeID(strID As String) As CEventType
        Dim params As New ArrayList
        'Dim objDR as SqlDataReader
        params.Add(New SqlParameter("eventTypeID", strID))
        FillObject(myDB.GetDataReaderBySP("sp_getEventTypeByEventTypeID", params))
        Return _EventType
    End Function
    Public Function FillObject(objDR As SqlDataReader) As CEventType
        If objDR.Read Then
            With _EventType
                .EventTypeID = objDR.Item("EventTypeID")
                .EventTypeDescription = objDR.Item("EventTypeDescription")
            End With
        Else 'no record was returned
            'nothing to do here
        End If
        objDR.Close()
        Return _EventType
    End Function
End Class
