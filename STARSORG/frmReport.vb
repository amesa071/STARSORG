Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient
Public Class frmReport
    Private ds As DataSet
    Private da As SqlDataAdapter
    Private Role As CRole
    Private Sub frmReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.rpvReport.RefreshReport()
    End Sub
    Public Sub Display()
        Role = New CRole
        '  rpvReport.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory & "Reports\rptRoleReport.rdlc"
        rpvReport.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory & "Reports\rptRoles2.rdlc"
        ds = New DataSet
        da = Role.GetReportData()
        da.Fill(ds)
        rpvReport.LocalReport.DataSources.Add(New ReportDataSource("dsRoles2", ds.Tables(0)))
        rpvReport.SetDisplayMode(DisplayMode.PrintLayout)
        rpvReport.RefreshReport()
        Me.Cursor = Cursors.Default
        Me.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class