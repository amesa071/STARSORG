<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMemberRoleReport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.CMbrRoleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.rpvMemberRoleReport = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.btnClose = New System.Windows.Forms.Button()
        CType(Me.CMbrRoleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CMbrRoleBindingSource
        '
        Me.CMbrRoleBindingSource.DataSource = GetType(STARSORG.CMbrRole)
        '
        'rpvMemberRoleReport
        '
        Me.rpvMemberRoleReport.AutoSize = True
        ReportDataSource1.Name = "dsMemberRoles"
        ReportDataSource1.Value = Me.CMbrRoleBindingSource
        Me.rpvMemberRoleReport.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpvMemberRoleReport.LocalReport.ReportEmbeddedResource = "STARSORG.rptMemberRoles.rdlc"
        Me.rpvMemberRoleReport.Location = New System.Drawing.Point(23, 23)
        Me.rpvMemberRoleReport.Name = "rpvMemberRoleReport"
        Me.rpvMemberRoleReport.ServerReport.BearerToken = Nothing
        Me.rpvMemberRoleReport.Size = New System.Drawing.Size(574, 278)
        Me.rpvMemberRoleReport.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(500, 317)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(97, 27)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmMemberRoleReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 356)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.rpvMemberRoleReport)
        Me.Name = "frmMemberRoleReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Member Role Report"
        CType(Me.CMbrRoleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rpvMemberRoleReport As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents CMbrRoleBindingSource As BindingSource
    Friend WithEvents btnClose As Button
End Class
