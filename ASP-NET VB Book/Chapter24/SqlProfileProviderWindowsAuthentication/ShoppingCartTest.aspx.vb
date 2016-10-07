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

Public partial Class ShoppingCartTest : Inherits System.Web.UI.Page
	Private db As NorthwindDB = New NorthwindDB()
	Private ds As DataSet

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		' Update the product list.
		ds = db.GetCategoriesProductsDataSet()
		gridProducts.DataSource = ds.Tables("Products")
		gridProducts.DataBind()

		' Check for the shopping cart. If it doesn't
		' exist, create a new cart and make it available.
		'if (Profile.Cart == null)
		'{
		'	Profile.Cart = new ShoppingCart();
		'}
	End Sub
	Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs)
		' Show the shopping cart in the grid.
		gridCart.DataSource = Profile.Cart
		gridCart.DataBind()
	End Sub
	Protected Sub gridProducts_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		' Get the full record for the one selected row.
		Dim rows As DataRow() = ds.Tables("Products").Select("ProductID=" & gridProducts.SelectedDataKey.Values("ProductID").ToString())
		Dim row As DataRow = rows(0)

		' Search to see if an item of this type is already in the cart.
		Dim inCart As Boolean = False
		For Each item As ShoppingCartItem In Profile.Cart
			' Increment the number count.
			If item.ProductID = CInt(row("ProductID")) Then
				item.Units += 1
				inCart = True
				Exit For
			End If
		Next item

		' If the item isn't in the cart, add it.
		If (Not inCart) Then
			Dim item As ShoppingCartItem = New ShoppingCartItem(CInt(row("ProductID")), CStr(row("ProductName")), CDec(row("UnitPrice")), 1)
			Profile.Cart.Add(item)
		End If

		' Don't keep the item selected in the product list.
		gridProducts.SelectedIndex = -1
	End Sub

	Protected Sub gridCart_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		' The text box is the second control.
		' The first control in a template column
		' is always a blank LiteralControl.
		Dim txt As TextBox = CType(gridCart.Rows(gridCart.SelectedIndex).Cells(3).Controls(1), TextBox)
		Try
			' Update the appropriate cart item.
			Dim newCount As Integer = Integer.Parse(txt.Text)
			If newCount > 0 Then
				Profile.Cart(gridCart.SelectedIndex).Units = newCount
			Else If newCount = 0 Then
				Profile.Cart.RemoveAt(gridCart.SelectedIndex)
			End If
		Catch
			' Ignore invalid (non-numeric) entries.
		End Try

		' Clear the selection. (You could also set the selection
		' style so that the selected row doesn't appear to the user.)
		gridCart.SelectedIndex = -1
	End Sub
End Class
