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

Namespace CustomServerControlsLibrary
	Public Class LinkControl : Inherits Control
		Protected Overrides Sub Render(ByVal output As HtmlTextWriter)
			' Specify the URL for the upcoming anchor tag.
			output.AddAttribute(HtmlTextWriterAttribute.Href, "http://www.apress.com")

			' Add the style attributes.
			output.AddStyleAttribute(HtmlTextWriterStyle.FontSize, "20")
			output.AddStyleAttribute(HtmlTextWriterStyle.Color, "Blue")

			' Create the anchor tag.
			output.RenderBeginTag(HtmlTextWriterTag.A)

			' Write the text inside the tag.
			output.Write("Click to visit Apress")

			' Close the tag.
			output.RenderEndTag()

			' (At this point, you could continue writing more tags and attributes.)
		End Sub
	End Class
End Namespace

