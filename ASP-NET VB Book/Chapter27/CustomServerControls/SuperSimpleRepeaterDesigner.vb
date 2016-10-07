Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.Web.UI.Design

Namespace CustomServerControlsLibrary

	Public Class SuperSimpleRepeaterDesigner : Inherits ControlDesigner

		Public Overrides Overloads Function GetDesignTimeHtml() As String
			Try
				Dim repeater As SuperSimpleRepeater2 = CType(MyBase.Component, SuperSimpleRepeater2)
				If repeater.ItemTemplate Is Nothing Then
					Return GetEmptyDesignTimeHtml()
				Else
					Dim designTimeHtml As String = String.Empty

						CType(Me.Component, Control).DataBind()
						designTimeHtml = MyBase.GetDesignTimeHtml()


				End If

				Return MyBase.GetDesignTimeHtml()
			Catch e As Exception
				Return GetErrorDesignTimeHtml(e)
			End Try
		End Function

		Protected Overrides Function GetEmptyDesignTimeHtml() As String
			Dim text As String = "Switch to design view to add a template to this control."
			Return CreatePlaceHolderDesignTimeHtml(text)
		End Function

		Protected Overrides Function GetErrorDesignTimeHtml(ByVal e As Exception) As String
			Dim text As String = String.Format("{0}{1}{2}{3}", "There was an error and the control can't be displayed.", "<BR>", "Exception: ", e.Message)
			Return CreatePlaceHolderDesignTimeHtml(text)
		End Function

	End Class
End Namespace
