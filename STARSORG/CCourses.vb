Imports System.Data.SqlClient
Public Class CCourses
    'Represents the COURSE table and its associated business rules
    Private _Course As CCourse
    'constructor
    Public Sub New()
        'instantiate the CCourse object
        _Course = New CCourse
    End Sub
    Public ReadOnly Property CurrentObject() As CCourse
        Get
            Return _Course
        End Get
    End Property
    Public Sub Clear()
        _Course = New CCourse
    End Sub
    Public Sub CreateNewCourse()
        'call this when clearing the edit portion of the screen to add a new course
        Clear()
        _Course.IsNewCourse = True
    End Sub
    Public Function Save() As Integer
        Return _Course.Save()
    End Function
    Public Function GetCourseByCourseID(strID As String) As CCourse
        Dim params As New ArrayList
        'Dim objDR As SqlDataReader
        params.Add(New SqlParameter("CourseID", strID))
        FillObject(myDB.GetDataReaderBySP("sp_getCourseByCourseID", params))
        Return _Course

    End Function
    Private Function FillObject(objDR As SqlDataReader) As CCourse
        If objDR.Read Then
            With _Course
                .CourseID = objDR.Item("CourseID")
                .CourseName = objDR.Item("CourseName")
            End With
        Else 'no record was returned
            'nothing to do here
        End If
        objDR.Close()
        Return _Course
    End Function
    Public Function GetAllCourses() As SqlDataReader
        Dim OBJdR As SqlDataReader
        OBJdR = myDB.GetDataReaderBySP("sp_getAllCourses", Nothing)
        Return OBJdR
    End Function
End Class
