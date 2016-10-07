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
Imports System.Collections

<Serializable()> _
Public Class ShoppingCartItem
    Private m_ProductID As Integer
    Private m_ProductName As String
    Private m_UnitPrice As Decimal
    Private m_Units As Integer

	Public ReadOnly Property ProductID() As Integer
		Get
            Return m_ProductID
		End Get
	End Property
	Public ReadOnly Property ProductName() As String
		Get
            Return m_ProductName
		End Get
	End Property
	Public ReadOnly Property UnitPrice() As Decimal
		Get
            Return m_UnitPrice
		End Get
	End Property
	Public Property Units() As Integer
		Get
            Return m_Units
		End Get
		Set
            m_Units = Value
		End Set
	End Property
	Public ReadOnly Property Total() As Decimal
		Get
			Return Units * UnitPrice
		End Get
	End Property
    Public Sub New(ByVal strProductID As Integer, ByVal strProductName As String, ByVal strUnitPrice As Decimal, ByVal strUnits As Integer)
        Me.m_ProductID = strProductID
        Me.m_ProductName = strProductName
        Me.m_UnitPrice = strUnitPrice
        Me.m_Units = strUnits
    End Sub
End Class

<Serializable()> _
Public Class ShoppingCart : Inherits CollectionBase
	Public Default Property Item(ByVal index As Integer) As ShoppingCartItem
		Get
			Return (CType(List(index), ShoppingCartItem))
		End Get
		Set
			List(index) = Value
		End Set
	End Property
	Public Function Add(ByVal value As ShoppingCartItem) As Integer
		Return (List.Add(value))
	End Function
	Public Function IndexOf(ByVal value As ShoppingCartItem) As Integer
		Return (List.IndexOf(value))
	End Function
	Public Sub Insert(ByVal index As Integer, ByVal value As ShoppingCartItem)
		List.Insert(index, value)
	End Sub
	Public Sub Remove(ByVal value As ShoppingCartItem)
		List.Remove(value)
	End Sub
	Public Function Contains(ByVal value As ShoppingCartItem) As Boolean
		Return (List.Contains(value))
	End Function
End Class