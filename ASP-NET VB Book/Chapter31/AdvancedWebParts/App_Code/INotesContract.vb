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

Namespace APress.WebParts.Samples
	Public Interface INotesContract
		Property Notes() As String
		ReadOnly Property SubmittedDate() As DateTime
	End Interface
End Namespace
