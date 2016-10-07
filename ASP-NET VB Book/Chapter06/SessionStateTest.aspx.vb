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

Public partial Class SessionStateTest : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not Me.IsPostBack) Then
			' Create Furniture objects.
			Dim piece1 As Furniture = New Furniture("Econo Sofa", "Acme Inc.", 74.99D)
			Dim piece2 As Furniture = New Furniture("Pioneer Table", "Heritage Unit", 866.75D)
			Dim piece3 As Furniture = New Furniture("Retro Cabinet", "Sixties Ltd.", 300.11D)

			' Add objects to session state.
			Session("Furniture1") = piece1
			Session("Furniture2") = piece2
			Session("Furniture3") = piece3

			' Add rows to list control.
			lstItems.Items.Clear()
			lstItems.Items.Add(piece1.Name)
			lstItems.Items.Add(piece2.Name)
			lstItems.Items.Add(piece3.Name)
		End If

		' Display some basic information about the session.
		' This is useful for testing configuration settings.
		lblSession.Text = "Session ID: " & Session.SessionID
		lblSession.Text &= "<br>Number of Objects: "
		lblSession.Text += Session.Count.ToString()
		lblSession.Text &= "<br>Mode: " & Session.Mode.ToString()
		lblSession.Text &= "<br>Is Cookieless: "
		lblSession.Text += Session.IsCookieless.ToString()
		lblSession.Text &= "<br>Is New: "
		lblSession.Text += Session.IsNewSession.ToString()
		lblSession.Text &= "<br>Timeout (minutes): "
		lblSession.Text += Session.Timeout.ToString()

	End Sub
	Protected Sub cmdMoreInfo_Click(ByVal sender As Object, ByVal e As EventArgs)
		If lstItems.SelectedIndex = -1 Then
			lblRecord.Text = "No item selected."
		Else
			' Construct the right key name based on the index.
			Dim key As String = "Furniture" & (lstItems.SelectedIndex + 1).ToString()

			' Retrieve the Furniture object from session state.
			Dim piece As Furniture = CType(Session(key), Furniture)

			' Display the information for this object.
			If Not piece Is Nothing Then
				lblRecord.Text = "Name: " & piece.Name
				lblRecord.Text &= "<br>Manufacturer: "
				lblRecord.Text += piece.Description
				lblRecord.Text &= "<br>Cost: $" & piece.Cost.ToString()
			End If
		End If

	End Sub
End Class
Public Class Furniture
	Public Name As String
	Public Description As String
	Public Cost As Decimal

    Public Sub New(ByVal strName As String, ByVal strDescription As String, ByVal nCost As Decimal)
        Name = strName
        Description = strDescription
        Cost = nCost
    End Sub
End Class
