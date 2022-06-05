Imports System.Data.SqlClient
Public Class CSemesters
    'Represents the SEMESTER table and its associated business rules
    Private _Semester As CSemester
    'constructor
    Public Sub New()
        'instantiate the CSemester object
        _Semester = New CSemester
    End Sub
    Public ReadOnly Property CurrentObject() As CSemester
        Get
            Return _Semester
        End Get
    End Property
    Public Sub Clear()
        _Semester = New CSemester
    End Sub
    Public Sub CreateNewSemester()
        'call this when clearing the edit portion of the screen to add a new semester
        Clear()
        _Semester.IsNewSemester = True
    End Sub
    Public Function Save() As Integer
        Return _Semester.Save()
    End Function
    Public Function GetSemesterBySemesterID(strID As String) As CSemester
        Dim params As New ArrayList
        'Dim objDR As SqlDataReader
        params.Add(New SqlParameter("semesterID", strID))
        'objDR = myDB.GetDataReaderBySP("sp_getRoleByRoleID", params)
        FillObject(myDB.GetDataReaderBySP("sp_getSemesterBySemesterID", params))
        Return _Semester
    End Function
    Private Function FillObject(objDR As SqlDataReader) As CSemester

        If objDR.Read Then
            With _Semester
                .SemesterID = objDR.Item("SemesterID")
                .SemesterDescription = objDR.Item("SemesterDescription")
            End With
        Else 'no record was returned
            'nothing to do here
        End If

        objDR.Close()
        Return _Semester
    End Function
    Public Function GetAllSemesters() As SqlDataReader
        Dim objDR As SqlDataReader
        objDR = myDB.GetDataReaderBySP("sp_getAllSemesters", Nothing)
        Return objDR
    End Function
End Class
