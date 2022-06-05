Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class frmMemberRoleReport
    Private ds As DataSet
    Private da As SqlDataAdapter
    Private MemberRole As CMbrRole
    Private Sub frmMemberRoleReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.rpvMemberRoleReport.RefreshReport()
    End Sub

    Public Sub Display()
        MemberRole = New CMbrRole
        rpvMemberRoleReport.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory & "Reports\rptMemberRoles.rdlc"
        ds = New DataSet
        da = MemberRole.GetReportData()
        da.Fill(ds)
        rpvMemberRoleReport.LocalReport.DataSources.Add(New ReportDataSource("dsMemberRoles", ds.Tables(0)))
        rpvMemberRoleReport.SetDisplayMode(DisplayMode.PrintLayout)
        rpvMemberRoleReport.RefreshReport()
        Me.Cursor = Cursors.Default
        Me.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class