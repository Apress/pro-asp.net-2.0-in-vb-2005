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
Imports System.IO

Public partial Class DynamicThemes_aspx : Inherits System.Web.UI.Page
	' Page events are wired up automatically to methods 
	' with the following names:
	' Page_Load, Page_AbortTransaction, Page_CommitTransaction,
	' Page_DataBinding, Page_Disposed, Page_Error, Page_Init, 
	' Page_Init Complete, Page_Load, Page_LoadComplete, Page_PreInit
	' Page_PreLoad, Page_PreRender, Page_PreRenderComplete, 
	' Page_SaveStateComplete, Page_Unload

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not Page.IsPostBack) Then
			' Fill the list box with available themes
			' by reading the folders in the App_Themes folder.
			Dim themeDir As DirectoryInfo = New DirectoryInfo(Server.MapPath("App_Themes"))
			lstThemes.DataTextField = "Name"
			lstThemes.DataSource = themeDir.GetDirectories()
			lstThemes.DataBind()
		End If
	End Sub

	Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)
		If Session("Theme") Is Nothing Then
			' No theme has been chosen. Choose a default
			' (or set a blank string to make sure no theme
			' is used).
			Page.Theme = ""
		Else
			Page.Theme = CStr(Session("Theme"))
		End If
	End Sub

	Protected Sub cmdApply_Click(ByVal sender As Object, ByVal e As EventArgs)
		' Set the chosen theme.
		Session("Theme") = lstThemes.SelectedValue

		' Refresh the page.
		Server.Transfer(Request.FilePath)

	End Sub
End Class
