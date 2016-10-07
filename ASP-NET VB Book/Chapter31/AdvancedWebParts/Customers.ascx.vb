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

Public partial Class Customers : Inherits System.Web.UI.UserControl : Implements IWebPart
	#Region "IWebPart Members"

	Private _CatalogImageUrl As String
	Public Property CatalogIconImageUrl() As String Implements IWebPart.CatalogIconImageUrl
		Get
			Return _CatalogImageUrl
		End Get
		Set
			_CatalogImageUrl = Value
		End Set
	End Property

	Private _Description As String
	Public Property Description() As String Implements IWebPart.Description
		Get
			Return _Description
		End Get
		Set
			_Description = Value
		End Set
	End Property

	Public ReadOnly Property Subtitle() As String Implements IWebPart.Subtitle
		Get
			Return "Internal Customer List"
		End Get
	End Property

	Private _TitleImage As String
	Public Property TitleIconImageUrl() As String Implements IWebPart.TitleIconImageUrl
		Get
			If _TitleImage Is Nothing Then
				Return "CustomersSmall.jpg"
			Else
				Return _TitleImage
			End If
		End Get
		Set
			_TitleImage = Value
		End Set
	End Property

	Private _TitleUrl As String
	Public Property TitleUrl() As String Implements IWebPart.TitleUrl
		Get
			Return _TitleUrl
		End Get
		Set
			_TitleUrl = Value
		End Set
	End Property

	Public Property Title() As String Implements IWebPart.Title
		Get
			If ViewState("Title") Is Nothing Then
				Return String.Empty
			Else
				Return CStr(ViewState("Title"))
			End If
		End Get
		Set
			ViewState("Title") = Value
		End Set
	End Property

	#End Region

	Private _MyValue As String = String.Empty

	<Personalizable()> _
	Public Property MyValue() As String
		Get
			Return _MyValue
		End Get
		Set
			_MyValue = Value
		End Set
	End Property
End Class
