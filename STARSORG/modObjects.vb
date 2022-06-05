Module modObjects
    Public Sub ClearScreenControls(ByVal objContainer As Control)
        'this procedure will clear all controls on the container passed in as the argument.
        'not all control types have been implemented. Add as you need.
        Dim obj As Control
        Dim strControlType As String
        For Each obj In objContainer.Controls
            strControlType = TypeName(obj) 'typename returns the class name of the control
            Select Case strControlType
                Case "TextBox"
                    Dim cntrl As TextBox
                    cntrl = DirectCast(obj, TextBox)
                    cntrl.Clear()
                    'or cntrl.Text = ""
                    'or cntrl.Text = vbNullString
                Case "CheckBox"
                    Dim cntrl As CheckBox
                    cntrl = DirectCast(obj, CheckBox)
                    cntrl.Checked = False
                    'or cntrl.CheckedState = CheckedState.Unchecked
                Case "ComboBox"
                    Dim cntrl As ComboBox
                    cntrl = DirectCast(obj, ComboBox)
                    cntrl.SelectedIndex = -1 'clear only the selection, not it's list
                Case "RadioButton"
                    Dim cntrl As RadioButton
                    cntrl = DirectCast(obj, RadioButton)
                    cntrl.Checked = False
                Case "ListBox"
                    Dim cntrl As ListBox
                    cntrl = DirectCast(obj, ListBox)
                    cntrl.SelectedIndex = -1 'clear only the selection, not it's list
                Case "MaskedTextBox"
                    Dim cntrl As MaskedTextBox
                    cntrl = DirectCast(obj, MaskedTextBox)
                    cntrl.Clear()
                Case "GroupBox"
                    'must recurse through its control collection
                    Dim cntrl As GroupBox
                    cntrl = DirectCast(obj, GroupBox)
                    ClearScreenControls(cntrl)
                Case Else
                    'do nothing or add some error trapping code if needed

            End Select
        Next
    End Sub

End Module
