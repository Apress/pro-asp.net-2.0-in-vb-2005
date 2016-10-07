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

<Serializable()> _
Public Class Address
    Private m_Name As String
	Public Property Name() As String
		Get
            Return m_Name
		End Get
		Set
            m_Name = Value
		End Set
	End Property

    Private m_Street As String
	Public Property Street() As String
		Get
            Return m_Street
		End Get
		Set
            m_Street = Value
		End Set
	End Property

    Private m_City As String
	Public Property City() As String
		Get
            Return m_City
		End Get
		Set
            m_City = Value
		End Set
	End Property

    Private m_Zip As String
	Public Property ZipCode() As String
		Get
            Return m_Zip
		End Get
		Set
            m_Zip = Value
		End Set
	End Property

    Private m_State As String
	Public Property State() As String
		Get
            Return m_State
		End Get
		Set
            m_State = Value
		End Set
	End Property

    Private m_Country As String
    Public Property Country() As String
        Get
            Return m_Country
        End Get
        Set(ByVal value As String)
            m_Country = value
        End Set
    End Property

    Public Sub New(ByVal strName As String, ByVal strStreet As String, ByVal strCity As String, ByVal strZip As String, ByVal strState As String, ByVal strCountry As String)
        Name = strName
        Street = strStreet
        City = strCity
        ZipCode = strZip
        State = strState
        Country = strCountry
    End Sub

	Public Sub New()
	End Sub
End Class
