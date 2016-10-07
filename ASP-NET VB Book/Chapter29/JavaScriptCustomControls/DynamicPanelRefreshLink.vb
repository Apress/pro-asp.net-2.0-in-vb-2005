Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

''' <summary>
''' Summary description for DynamicPanelRefreshLink
''' </summary>
Namespace DynamicControls

	Public Class DynamicPanelRefreshLink : Inherits LinkButton
		Public Sub New()
			PanelID = ""
		End Sub

		Public Property PanelID() As String
			Get
				Return CStr(ViewState("DynamicPanelID"))
			End Get
			Set
				ViewState("DynamicPanelID") = Value
			End Set
		End Property

		Protected Overrides Sub AddAttributesToRender(ByVal writer As HtmlTextWriter)
			If (Not DesignMode) Then
				Dim pnl As DynamicPanel = CType(Page.FindControl(PanelID), DynamicPanel)
				If Not pnl Is Nothing Then
					writer.AddAttribute("onclick", pnl.GetCallbackScript(Me, ""))
					writer.AddAttribute("href", "#")
				End If
			End If
		End Sub



	End Class
End Namespace