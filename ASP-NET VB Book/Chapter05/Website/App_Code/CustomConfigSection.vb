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
Imports System.Web.Configuration


Public Class OrderService : Inherits ConfigurationSection
	<ConfigurationProperty("available", DefaultValue := False)> _
	Public Property Available() As Boolean
		Get
			Return CBool(MyBase.Item("available"))
		End Get
		Set
			MyBase.Item("available") = Value
		End Set
	End Property

    <ConfigurationProperty("pollTimeout", IsRequired:=True)> _
    Public Property PollTimeout() As TimeSpan
        Get
            Return CType(MyBase.Item("pollTimeout"), TimeSpan)
        End Get
        Set(ByVal value As TimeSpan)
            MyBase.Item("pollTimeout") = value
        End Set
    End Property

    <ConfigurationProperty("location", IsRequired:=True)> _
 Public Property Location() As String
        Get
            Return CStr(MyBase.Item("location"))
        End Get
        Set(ByVal value As String)
            MyBase.Item("location") = Value
        End Set
    End Property
End Class


