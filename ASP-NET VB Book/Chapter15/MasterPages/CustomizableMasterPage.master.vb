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

Public partial Class CustomizableMasterPage_master : Inherits System.Web.UI.MasterPage
	' Page events are wired up automatically to methods 
	' with the following names:
	' Page_Load, Page_AbortTransaction, Page_CommitTransaction,
	' Page_DataBinding, Page_Disposed, Page_Error, Page_Init, 
	' Page_Init Complete, Page_Load, Page_LoadComplete, Page_PreInit
	' Page_PreLoad, Page_PreRender, Page_PreRenderComplete, 
	' Page_SaveStateComplete, Page_Unload
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		' A dead end.
		If (Not Page.IsPostBack) Then
			If Not Page.PreviousPage Is Nothing Then
				Dim previous As CustomizableMasterPage_master = TryCast(Page.PreviousPage.Master, CustomizableMasterPage_master)
				If Not previous Is Nothing Then
					BannerText = previous.BannerText
				End If
			End If
		End If
	End Sub

	Public Property BannerText() As String
		Get
			Return lblTitleContent.Text
		End Get
		Set
			lblTitleContent.Text = Value
		End Set
	End Property

End Class
