Imports System.Data.SqlClient
Public Class CCourse
    'Represents a single record in the ROLE table
    Private _mstrCourseID As String
    Private _mstrCourseName As String
    Private _isNewCourse As Boolean
    'constructor
    Public Sub New()
        _mstrCourseID = ""
        _mstrCourseName = ""
    End Sub
#Region "Exposed Properties"
    Public Property CourseID As String
        Get
            Return _mstrCourseID
        End Get
        Set(strVal As String)
            _mstrCourseID = strVal
        End Set
    End Property
    Public Property CourseName As String
        Get
            Return _mstrCourseName
        End Get
        Set(strVal As String)
            _mstrCourseName = strVal
        End Set
    End Property
    Public Property IsNewCourse As Boolean
        Get
            Return _isNewCourse
        End Get
        Set(blnVal As Boolean)
            _isNewCourse = blnVal
        End Set
    End Property
    Public ReadOnly Property GetSaveParameters() As ArrayList
        'this property's code will create the parameters for the stored procedure to save a record 
        Get
            Dim params As New ArrayList
            params.Add(New SqlParameter("courseID", _mstrCourseID))
            params.Add(New SqlParameter("courseName", _mstrCourseName))
            Return params
        End Get
    End Property
#End Region
    Public Function Save() As Integer
        'return -1 if the ID already exists (and we cannot create a new record with duplicate ID) 
        If IsNewCourse Then
            Dim params As New ArrayList
            params.Add(New SqlParameter("courseID", _mstrCourseID))
            Dim strResult As String = myDB.GetSingleValueFromSP("sp_CheckCourseIDExists", params)
            If Not strResult = 0 Then
                Return -1 'not UNIQUE!!
            End If
        End If
        'if not a new role, or it is new and has a unique ID,then do the save (update or insert)
        Return myDB.ExecSP("sp_SaveCourse", GetSaveParameters())
    End Function
    Public Function GetReportData() As SqlDataAdapter
        Return myDB.GetDataAdapterBySP("dbo.sp_getAllCourses", Nothing)
    End Function
End Class
