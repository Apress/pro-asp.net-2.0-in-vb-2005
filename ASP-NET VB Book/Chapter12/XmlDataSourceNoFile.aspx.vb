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

Public partial Class XmlDataSourceNoFile : Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
	 sourceDVD.Data="<DvdList>" & ControlChars.CrLf & "     <DVD ID='1' Category='Science Fiction'>" & ControlChars.CrLf & "      <Title>The Matrix</Title>" & ControlChars.CrLf & "      <Director>Larry Wachowski</Director>" & ControlChars.CrLf & "      <Price>18.74</Price>" & ControlChars.CrLf & "      <Starring>" & ControlChars.CrLf & "         <Star>Keanu Reeves</Star>" & ControlChars.CrLf & "         <Star>Laurence Fishburne</Star>" & ControlChars.CrLf & "      </Starring>" & ControlChars.CrLf & "   </DVD>" & ControlChars.CrLf & "   </DvdList>"


	End Sub
End Class
