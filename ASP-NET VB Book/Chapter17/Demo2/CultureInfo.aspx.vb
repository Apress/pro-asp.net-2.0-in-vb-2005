Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Globalization

Public partial Class CultureInfo_aspx : Inherits System.Web.UI.Page
	' Page events are wired up automatically to methods 
	' with the following names:
	' Page_Load, Page_AbortTransaction, Page_CommitTransaction,
	' Page_DataBinding, Page_Disposed, Page_Error, Page_Init, 
	' Page_Init Complete, Page_Load, Page_LoadComplete, Page_PreInit
	' Page_PreLoad, Page_PreRender, Page_PreRenderComplete, 
	' Page_SaveStateComplete, Page_Unload

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
	  Dim ci As CultureInfo
	  If (Not Request.UserLanguages Is Nothing) AndAlso (Request.UserLanguages.Length > 0) Then
		ci = New CultureInfo(Request.UserLanguages(0))
		System.Threading.Thread.CurrentThread.CurrentUICulture = ci
		'System.Threading.Thread.CurrentThread.CurrentCulture = ci;
	  Else
		ci = System.Threading.Thread.CurrentThread.CurrentUICulture
	  End If

	  Dim MessageBuilder As StringBuilder = New StringBuilder()
	  MessageBuilder.Append("Current culture info: ")
	  MessageBuilder.Append("<BR>")
	  MessageBuilder.AppendFormat("-) Name: {0}", ci.Name)
	  MessageBuilder.Append("<BR>")
	  MessageBuilder.AppendFormat("-) ISO Name: {0}", ci.ThreeLetterISOLanguageName)
	  MessageBuilder.Append("<BR>")
	  MessageBuilder.Append("-) Currency Symbol: " & ci.NumberFormat.CurrencySymbol)
	  MessageBuilder.Append("<BR>")
	  MessageBuilder.Append("-) Long Date Pattern: " & ci.DateTimeFormat.LongDatePattern)

	  LegendCI.Text = MessageBuilder.ToString()

	  Response.Write("Date format: " & DateTime.Now.ToString())
	  Try
		DateTime.Parse("31.01.2005")
		Response.Write("<br>Parsing succeeded!")
	  Catch
		Response.Write("<br>Parsing FAILED!")
	  End Try

	  Try
		Dim conn As SqlConnection = New SqlConnection("server=localhost;Trusted_Connection=yes;database=TestDatabase")
		conn.Open()

		Dim cmd As SqlCommand = conn.CreateCommand()
		cmd.CommandText = "INSERT INTO TestDate(EntryDate) VALUES(@MyDate)"
		cmd.Parameters.Add("@MyDate", DateTime.Parse("31.01.2005"))
		cmd.ExecuteNonQuery()
		Response.Write("<br>Insert succeeded!")
	  Catch ex As Exception
		Response.Write("<br>Insert FAILED: " & ex.Message)
	  End Try
	End Sub
End Class
