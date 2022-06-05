Module modErrHandler
    'useful routines for input validation
    Public Function ValidateTextBoxLength(ByRef obj As TextBox, ByRef errP As ErrorProvider) As Boolean
        'this procedure validates that a textbox is not empty
        If obj.Text.Length = 0 Then
            errP.SetIconAlignment(obj, ErrorIconAlignment.MiddleLeft)
            errP.SetError(obj, "You must enter a value here")
            obj.Focus()
            Return False
        Else
            errP.SetError(obj, "")
            Return True
        End If
    End Function 'functions return value

    Public Function ValidateTextBoxNumeric(ByRef obj As TextBox, ByRef errp As ErrorProvider) As Boolean
        'this procedure validates that a textbox has a numeric value
        If Not IsNumeric(obj.Text) Then
            errp.SetIconAlignment(obj, ErrorIconAlignment.MiddleLeft)
            errp.SetError(obj, "You must enter a valid numeric value")
            obj.Focus()
            Return False
        Else
            errp.SetError(obj, "")
            Return True
        End If
    End Function

    Public Function ValidateTextBoxDate(ByRef obj As TextBox, ByRef errP As ErrorProvider) As Boolean
        'this procedure validates that a textbox has a valid date value
        If Not IsDate(obj.Text) Then
            errP.SetIconAlignment(obj, ErrorIconAlignment.MiddleLeft)
            errP.SetError(obj, "You must enter a valid date value")
            obj.Focus()
            Return False
        Else
            errP.SetError(obj, "")
            Return True
        End If
    End Function

    Public Function ValidateCombo(ByRef obj As ComboBox, ByRef errP As ErrorProvider) As Boolean
        'this procedure validates that a combobox has a selection
        If obj.SelectedIndex = -1 Then 'no selection was made
            errP.SetIconAlignment(obj, ErrorIconAlignment.MiddleLeft)
            errP.SetError(obj, "You must make a selection")
            obj.Focus()
            Return False
        Else
            errP.SetError(obj, "")
            Return True
        End If
    End Function

    Public Function ValidateMaskedTextBoxLength(ByRef obj As MaskedTextBox, ByRef errP As ErrorProvider) As Boolean
        'this procedure validates that a textbox has a valid date value
        If obj.Text.Length = 0 Then 'no selection was made
            errP.SetIconAlignment(obj, ErrorIconAlignment.MiddleLeft)
            errP.SetError(obj, "You must enter a value")
            obj.Focus()
            Return False
        Else
            errP.SetError(obj, "")
            Return True
        End If
    End Function

    Public Function ValidateListBox(ByRef obj As ListBox, ByRef errP As ErrorProvider) As Boolean
        'this procedure validates that a textbox has a valid date value
        If obj.SelectedIndex = -1 Then 'no selection was made
            errP.SetIconAlignment(obj, ErrorIconAlignment.MiddleLeft)
            errP.SetError(obj, "You must make a selection.")
            obj.Focus()
            Return False
        Else
            errP.SetError(obj, "")
            Return True
        End If
    End Function
End Module
