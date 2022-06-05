Module modGlobal
    'contains all variables, constants, procedures, and functions that need to be accessed in more than one form
    Public Const ACTION_NONE As Integer = 0
    Public Const ACTION_HOME As Integer = 1
    Public Const ACTION_MEMBER As Integer = 2
    Public Const ACTION_ROLE As Integer = 3
    Public Const ACTION_EVENT As Integer = 4
    Public Const ACTION_RSVP As Integer = 5
    Public Const ACTION_COURSE As Integer = 6
    Public Const ACTION_SEMESTER As Integer = 7
    Public Const ACTION_HELP As Integer = 8
    Public Const ACTION_TUTOR As Integer = 9
    Public Const ACTION_LOGOUT As Integer = 10
    Public Const ACTION_MBRROLE As Integer = 11
    Public Const ACTION_STARTUP As Integer = 12
    Public Const ACTION_ADMIN As Integer = 13

    'add security admin form on toolstrip
    Public intNextAction As Integer
    Public ReadOnly NULL_DATE As Date = New Date(1990, 1, 1)
    Public modPrivilege As String
    Public modUserID As String
    Public modPID As String
    Public blnIsLoggedIn As Boolean
    Public myDB As New CDB

End Module
