Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class frmRSVPReport
    Private ds As DataSet
    Private da As SqlDataAdapter
    Private RSVP As CRSVP
    Private Sub frmRSVPReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.rpvRSVPReport.RefreshReport()
    End Sub
    Public Sub Display(strID As String)
        RSVP = New CRSVP
        rpvRSVPReport.LocalReport.ReportPath = AppDomain.CurrentDomain.BaseDirectory & "Reports\rptRSVPReport.rdlc"
        ds = New DataSet
        da = RSVP.GetReportData(strID)
        da.Fill(ds)
        rpvRSVPReport.LocalReport.DataSources.Add(New ReportDataSource("dsRSVP", ds.Tables(0)))
        rpvRSVPReport.SetDisplayMode(DisplayMode.PrintLayout)
        rpvRSVPReport.RefreshReport()
        Me.Cursor = Cursors.Default
        Me.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class