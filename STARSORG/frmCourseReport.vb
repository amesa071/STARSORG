Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class frmCourseReport
    Private ds As DataSet
    Private da As SqlDataAdapter
    Private Course As CCourse
    Private Sub frmCourseReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.rpvCourseReport.RefreshReport()
    End Sub
    Public Sub Display()
        Course = New CCourse
        rpvCourseReport.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory & "Reports\rptCourses.rdlc"
        ds = New DataSet
        da = Course.GetReportData
        da.Fill(ds)
        rpvCourseReport.LocalReport.DataSources.Add(New ReportDataSource("dsCourses", ds.Tables(0)))
        rpvCourseReport.SetDisplayMode(DisplayMode.PrintLayout)
        rpvCourseReport.RefreshReport()
        Me.Cursor = Cursors.Default
        Me.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class