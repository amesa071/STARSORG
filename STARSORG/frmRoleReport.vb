Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class frmRoleReport
    Private ds As DataSet
    Private sqlDa As SqlDataAdapter
    Private Role As CRole
    Private Sub frmRoleReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.rpvRoleReport.RefreshReport()
    End Sub

    Public Sub Display()
        Role = New CRole
        rpvRoleReport.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory & "Reports\rptRoles.rdlc"
        ds = New DataSet
        sqlDa = Role.GetReportData
        sqlDa.Fill(ds)
        rpvRoleReport.LocalReport.DataSources.Add(New ReportDataSource("dsRoles", ds.Tables(0)))
        rpvRoleReport.SetDisplayMode(DisplayMode.PrintLayout)
        rpvRoleReport.RefreshReport()
        Me.Cursor = Cursors.Default
        Me.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class