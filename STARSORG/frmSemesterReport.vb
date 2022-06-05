Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class frmSemesterReport
    Private ds As DataSet
    Private da As SqlDataAdapter
    Private Semester As CSemester
    Private Sub frmSemesterReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.rpvSemesterReport.RefreshReport()
    End Sub
    Public Sub Display()
        Semester = New CSemester
        rpvSemesterReport.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory & "Reports\rptSemesters.rdlc"
        ds = New DataSet
        da = Semester.GetReportData
        da.Fill(ds)
        rpvSemesterReport.LocalReport.DataSources.Add(New ReportDataSource("dsSemesters", ds.Tables(0)))
        rpvSemesterReport.SetDisplayMode(DisplayMode.PrintLayout)
        rpvSemesterReport.RefreshReport()
        Me.Cursor = Cursors.Default
        Me.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class