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
Imports System.Text.RegularExpressions
Imports System.Globalization
Imports System.Drawing
Imports System.Drawing.Design

Namespace CustomServerControlsLibrary
	<DefaultProperty("RichText")> _
	Public Class RichLabel : Inherits WebControl
		Public Sub New()
			MyBase.New()
			Text = ""
			Format = New RichLabelFormattingOptions(RichLabelTextType.Xml, "b")
		End Sub

		<Editor(GetType(ColorTypeEditor), GetType(UITypeEditor))> _
		Public Overrides Property BackColor() As Color
			Get
				Return MyBase.BackColor
			End Get
			Set
				MyBase.BackColor = Value
			End Set
		End Property


		Protected Overrides Sub RenderContents(ByVal output As HtmlTextWriter)
			Dim convertedText As String = ""
			Select Case Format.Type
				Case RichLabelTextType.Xml
					convertedText = RichLabel.ConvertXmlTextToHtmlText(Text, Format.HighlightTag)
				Case RichLabelTextType.Html
					convertedText = Text
			End Select
            output.Write(convertedText)

		End Sub

		<Category("Appearance"), Description("The content that will be displayed.")> _
		Public Property Text() As String
			Get
				Return CStr(ViewState("Text"))
			End Get
			Set
				ViewState("Text") = Value
			End Set
		End Property

		<Category("Appearance"), Description("Options for configuring how text is rendered."), TypeConverter(GetType(RichLabelFormattingOptionsConverter)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), PersistenceMode(PersistenceMode.InnerProperty)> _
		Public Property Format() As RichLabelFormattingOptions
			Get
				Return CType(ViewState("Format"), RichLabelFormattingOptions)
			End Get
			Set
				ViewState("Format") = Value
			End Set
		End Property

		' This is a static method, just in case you want to use it
		' idependent of any control object.
		Public Shared Function ConvertXmlTextToHtmlText(ByVal inputText As String, ByVal highlightTag As String) As String
			If inputText = "" Then
				Return ""
			Else
				' Replace all start and end tags.
				Dim startPattern As String = "<([^>]+)>"
				Dim regEx As Regex = New Regex(startPattern)
				Dim outputText As String = regEx.Replace(inputText, "&lt;<" & highlightTag & ">$1&gt;</" & highlightTag & ">")

				outputText = outputText.Replace(" ", "&nbsp;")
				outputText = outputText.Replace(Constants.vbCrLf, "<br>")

				Return outputText
			End If
		End Function
	End Class

	Public Class RichLabelFormattingOptionsConverter : Inherits ExpandableObjectConverter
		Private Overloads Function ToString(ByVal value As Object) As String
			Dim format As RichLabelFormattingOptions = CType(value, RichLabelFormattingOptions)
			Return String.Format("{0}, <{1}>", format.Type, format.HighlightTag)
		End Function

		Private Function FromString(ByVal value As Object) As RichLabelFormattingOptions
			Dim values As String() = (CStr(value)).Split(","c)
			If values.Length <> 2 Then
				Throw New ArgumentException("Could not convert the value")
			End If

			Try
				Dim type As RichLabelTextType = CType(System.Enum.Parse(GetType(RichLabelTextType), values(0), True), RichLabelTextType)
				Dim tag As String = values(1).Trim(New Char(){" "c,"<"c,">"c})
				Return New RichLabelFormattingOptions(type, tag)
			Catch
				Throw New ArgumentException("Could not convert the value")
			End Try
		End Function

		Public Overrides Overloads Function CanConvertFrom(ByVal context As ITypeDescriptorContext, ByVal sourceType As Type) As Boolean
			If sourceType Is GetType(String) Then
				Return True
			Else
				Return MyBase.CanConvertFrom(context, sourceType)
			End If
		End Function

		Public Overrides Overloads Function ConvertFrom(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object) As Object
			If TypeOf value Is String Then
				Return FromString(value)
			Else
				Return MyBase.ConvertFrom(context, culture, value)
			End If
		End Function

		Public Overrides Overloads Function CanConvertTo(ByVal context As ITypeDescriptorContext, ByVal destinationType As Type) As Boolean
			If destinationType Is GetType(String) Then
				Return True
			Else
				Return MyBase.CanConvertTo(context, destinationType)
			End If
		End Function

		Public Overrides Overloads Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
			If destinationType Is GetType(String) Then
				Return ToString(value)
			Else
				Return MyBase.ConvertTo(context, culture, value, destinationType)
			End If
		End Function

	End Class


	Public Enum RichLabelTextType
		Xml
		Html
	End Enum

	<Serializable()> _
	Public Class RichLabelFormattingOptions
        Private typLabel As RichLabelTextType

		<RefreshProperties(RefreshProperties.Repaint), NotifyParentProperty(True), Description("Type of content supplied in the text property")> _
		Public Property Type() As RichLabelTextType
			Get
                Return typLabel
            End Get
            Set(ByVal value As RichLabelTextType)
                typLabel = Value
            End Set
		End Property

        Private strHighLight As String

		<RefreshProperties(RefreshProperties.Repaint), NotifyParentProperty(True), Description("The HTML tag you want to use to mark up highlighted portions.")> _
		Public Property HighlightTag() As String
			Get
                Return strHighLight
            End Get
            Set(ByVal value As String)
                strHighLight = Value
            End Set
		End Property

        Public Sub New(ByVal typLabel As RichLabelTextType, ByVal strHighLight As String)
            Me.strHighLight = strHighLight
            Me.typLabel = typLabel
        End Sub

		Public Sub New()
		End Sub
	End Class
End Namespace

