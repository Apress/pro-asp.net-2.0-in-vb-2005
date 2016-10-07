Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls


Public partial Class CreateChart : Inherits System.Web.UI.Page

	' The data that will be used to create the pie chart.
	Private pieSlices As ArrayList = New ArrayList()

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
		' Retrieve the pie slices that are defined so far.
		If Not Session("ChartData") Is Nothing Then
			pieSlices = CType(Session("ChartData"), ArrayList)
		End If
	End Sub

	Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		' Create a new pie slice.
		Dim pieSlice As PieSlice = New PieSlice(txtLabel.Text, Single.Parse(txtValue.Text))
		pieSlices.Add(pieSlice)

		' Bind the list box to the new data.
		lstPieSlices.DataSource = pieSlices
		lstPieSlices.DataBind()
	End Sub

	Protected Sub CreateChart_PreRender(ByVal sender As Object, ByVal e As System.EventArgs)
		' Before rendering the page, store the current collection
		' of pie slices.
		Session("ChartData") = pieSlices
	End Sub
End Class
