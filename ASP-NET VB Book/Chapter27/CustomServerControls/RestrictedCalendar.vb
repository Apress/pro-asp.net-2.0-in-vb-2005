Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.Design
Imports System.IO
Imports System.Drawing


Namespace CustomServerControlsLibrary
	<ControlBuilder(GetType(RestrictedCalendarBuilder)),PersistChildren(False),ParseChildren(False),Designer(GetType(RestrictedCalendarDesigner))> _
	Public Class RestrictedCalendar : Inherits Calendar
		Public Sub New()
			AllowWeekendSelection = True
			NonSelectableDates = New DateTimeCollection()

			' Configure the appearance of the calendar table.
			Me.CellPadding = 8
			Me.CellSpacing = 8
			Me.BackColor = Color.LightYellow
			Me.BorderStyle = BorderStyle.Groove
			Me.BorderWidth = Unit.Pixel(2)
			Me.ShowGridLines = True

			' Configure the font.
			Me.Font.Name = "Verdana"
			Me.Font.Size = FontUnit.XXSmall

			' Set calendar settings.
			Me.FirstDayOfWeek = FirstDayOfWeek.Monday
			Me.PrevMonthText = "<--"
			Me.NextMonthText = "-->"

			' Select the current date by default.
			Me.SelectedDate = DateTime.Today
		End Sub

		Public Property AllowWeekendSelection() As Boolean
			Get
				Return CBool(ViewState("AllowWeekendSelection"))
			End Get
			Set
				ViewState("AllowWeekendSelection") = Value
			End Set
		End Property

		<PersistenceMode(PersistenceMode.InnerDefaultProperty),DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
		Public Property NonSelectableDates() As DateTimeCollection
			Get
				Return CType(ViewState("NonSelectableDates"), DateTimeCollection)
			End Get
			Set
				ViewState("NonSelectableDates") = Value
			End Set
		End Property

		Protected Overrides Sub OnDayRender(ByVal cell As TableCell, ByVal day As CalendarDay)
			If day.IsWeekend AndAlso (Not AllowWeekendSelection) Then
				day.IsSelectable = False
			Else If NonSelectableDates.Contains(day.Date) Then
				day.IsSelectable = False
			End If

			' Let the base class raise this event.
			MyBase.OnDayRender(cell, day)
		End Sub

		Protected Overrides Sub AddParsedSubObject(ByVal obj As Object)
			If TypeOf obj Is DateTimeHelper Then

                Dim dteDate As DateTimeHelper = CType(obj, DateTimeHelper)
                NonSelectableDates.Add(DateTime.Parse(dteDate.Value))
			End If
		End Sub
	End Class


	Public Class DateTimeCollection : Inherits CollectionBase
		Public Default Property Item(ByVal index As Integer) As DateTime
			Get
				Return(CDate(List(index)))
			End Get
			Set
				List(index) = Value
			End Set
		End Property
		Public Function Add(ByVal value As DateTime) As Integer
			Return(List.Add(value))
		End Function
		Public Function IndexOf(ByVal value As DateTime) As Integer
			Return(List.IndexOf(value))
		End Function
		Public Sub Insert(ByVal index As Integer, ByVal value As DateTime)
			List.Insert(index, value)
		End Sub
		Public Sub Remove(ByVal value As DateTime)
			List.Remove(value)
		End Sub
		Public Function Contains(ByVal value As DateTime) As Boolean
			Return(List.Contains(value))
		End Function
	End Class


	Public Class RestrictedCalendarDesigner : Inherits ControlDesigner
		Public Overrides Function GetPersistenceContent() As String
			Dim sw As StringWriter = New StringWriter()
			Dim html As HtmlTextWriter = New HtmlTextWriter(sw)

			Dim calendar As RestrictedCalendar = TryCast(Me.Component, RestrictedCalendar)
			If Not calendar Is Nothing Then
				' for each color in the collection, output its
				' html known name (if it is a known color)
				' or its html hex string representation
				' in the format:
				'   <Color value='xxx' />

                For Each dteDate As DateTime In calendar.NonSelectableDates
                    html.WriteBeginTag("DateTime")
                    html.WriteAttribute("Value", dteDate.ToString())
                    html.WriteLine(HtmlTextWriter.SelfClosingTagEnd)
                Next

			End If

			Return sw.ToString()

		End Function
	End Class

	Public Class RestrictedCalendarBuilder : Inherits ControlBuilder
		Public Overrides Function GetChildControlType(ByVal tagName As String, ByVal attribs As IDictionary) As Type
			If String.Compare(tagName,"DateTime", True) = 0 Then
				Return GetType(DateTimeHelper)
			End If

			Return MyBase.GetChildControlType (tagName, attribs)
		End Function
	End Class

	Public Class DateTimeHelper
		Private val As String
		Public Property Value() As String
			Get
				Return val
			End Get
			Set
				val = Value
			End Set
		End Property
	End Class
End Namespace
