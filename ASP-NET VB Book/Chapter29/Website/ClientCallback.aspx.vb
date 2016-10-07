Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Data.SqlClient
Imports System.Text
Imports System.Web.Configuration

Public partial Class ClientCallback : Inherits System.Web.UI.Page : Implements ICallbackEventHandler
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not Page.IsPostBack) Then
			Dim callbackRef As String = Page.ClientScript.GetCallbackEventReference(Me, "document.all['lstRegions'].value", "ClientCallback", "null")

			lstRegions.Attributes("onClick") = callbackRef

		End If
	End Sub

	Public Overridable Function RaiseCallbackEvent(ByVal eventArgument As String) As String Implements ICallbackEventHandler.RaiseCallbackEvent
		Dim con As SqlConnection = New SqlConnection(WebConfigurationManager.ConnectionStrings("Northwind").ConnectionString)
		Dim cmd As SqlCommand = New SqlCommand("SELECT * FROM Territories WHERE RegionID=@RegionID", con)
		cmd.Parameters.Add(New SqlParameter("@RegionID", SqlDbType.Int, 4))
		cmd.Parameters("@RegionID").Value = Int32.Parse(eventArgument)

		Dim results As StringBuilder = New StringBuilder()
		Try
			con.Open()
			Dim reader As SqlDataReader = cmd.ExecuteReader()

			Do While reader.Read()
				results.Append(reader("TerritoryDescription"))
				results.Append("|")
				results.Append(reader("TerritoryID"))
				results.Append("||")
			Loop
			reader.Close()
		Catch err As SqlException
			' Hide errors.
		Finally
			con.Close()
		End Try
		Return results.ToString()
	End Function
	Protected Sub cmdOK_Click(ByVal sender As Object, ByVal e As EventArgs)
		lblInfo.Text = "You selected territory ID #" & Request.Form("lstTerritories")
	End Sub
End Class
