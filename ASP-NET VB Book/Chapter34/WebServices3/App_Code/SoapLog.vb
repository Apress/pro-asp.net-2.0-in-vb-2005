Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Web.Services.Protocols
Imports System.IO

<AttributeUsage(AttributeTargets.Method)> _
Public Class SoapLogAttribute : Inherits System.Web.Services.Protocols.SoapExtensionAttribute
	Private m_Priority As Integer
	Private m_Name As String = "SoapLog"
	Private m_Level As Integer = 1

	Public Overrides Property Priority() As Integer
		Get
			Return m_Priority
		End Get
		Set
			m_Priority = Value
		End Set
	End Property

	Public Property Name() As String
		Get
			Return m_Name
		End Get
		Set
			m_Name = Value
		End Set
	End Property
	Public Property Level() As Integer
		Get
			Return m_Level
		End Get
		Set
			m_Level = Value
		End Set
	End Property

	Public Overrides ReadOnly Property ExtensionType() As Type
		Get
			Return GetType(SoapLog)
		End Get
	End Property

End Class

Public Class SoapLog : Inherits System.Web.Services.Protocols.SoapExtension
	Private oldStream As Stream
	Private newStream As Stream
	Private name As String
	Private level As Integer

	Public Overrides Overloads Function GetInitializer(ByVal methodInfo As System.Web.Services.Protocols.LogicalMethodInfo, ByVal attribute As System.Web.Services.Protocols.SoapExtensionAttribute) As Object
		Return CType(attribute, SoapLogAttribute)
	End Function

	Public Overrides Overloads Function GetInitializer(ByVal obj As Type) As Object
		Return New SoapLogAttribute()
	End Function

	Public Overrides Sub Initialize(ByVal initializer As Object)
		name = (CType(initializer, SoapLogAttribute)).Name
		level = (CType(initializer, SoapLogAttribute)).Level
	End Sub



	Public Overrides Sub ProcessMessage(ByVal message As System.Web.Services.Protocols.SoapMessage)
		Select Case message.Stage
			Case System.Web.Services.Protocols.SoapMessageStage.BeforeSerialize
				If level > 2 Then
					WriteToLog(message.Stage.ToString(), EventLogEntryType.Information)
				End If
			Case System.Web.Services.Protocols.SoapMessageStage.AfterSerialize
				LogOutputMessage(message)
			Case System.Web.Services.Protocols.SoapMessageStage.BeforeDeserialize
				LogInputMessage(message)
			Case System.Web.Services.Protocols.SoapMessageStage.AfterDeserialize
				If level > 2 Then
					WriteToLog(message.Stage.ToString(), EventLogEntryType.Information)
				End If
		End Select
	End Sub

	Public Overrides Function ChainStream(ByVal stream As Stream) As Stream
		oldStream = stream
		newStream = New MemoryStream()
		Return newStream
	End Function


	Private Sub CopyStream(ByVal fromstream As Stream, ByVal tostream As Stream)
		Dim reader As StreamReader = New StreamReader(fromstream)
		Dim writer As StreamWriter = New StreamWriter(tostream)

		writer.WriteLine(reader.ReadToEnd())
		writer.Flush()
	End Sub

	Private Sub LogInputMessage(ByVal message As SoapMessage)
		CopyStream(oldStream, newStream)
		message.Stream.Seek(0, SeekOrigin.Begin)
		LogMessage(message, newStream)
		message.Stream.Seek(0, SeekOrigin.Begin)
	End Sub

	Private Sub LogOutputMessage(ByVal message As SoapMessage)
		message.Stream.Seek(0, SeekOrigin.Begin)
		LogMessage(message, newStream)
		message.Stream.Seek(0, SeekOrigin.Begin)
		CopyStream(newStream, oldStream)
	End Sub

	Private Sub LogMessage(ByVal message As SoapMessage, ByVal stream As Stream)
		Dim eventMessage As String
		Dim reader As TextReader

		reader = New StreamReader(stream)
		eventMessage = reader.ReadToEnd()

		If level > 2 Then
			eventMessage = message.Stage.ToString() +Constants.vbLf & eventMessage
		End If

		If eventMessage.IndexOf("<soap:Fault>") > 0 Then
			'The SOAP body contains a fault
			If level > 0 Then
				WriteToLog(eventMessage, EventLogEntryType.Error)
			End If
		Else
			' The SOAP body contains a message
			If level > 1 Then
				WriteToLog(eventMessage, EventLogEntryType.Information)
			End If
		End If
	End Sub

	Private Sub WriteToLog(ByVal message As String, ByVal type As EventLogEntryType)
		Dim log As EventLog

		If (Not EventLog.SourceExists(name)) Then
			EventLog.CreateEventSource(name, "Web Service Log")
		End If


		log = New EventLog()
		log.Source = name

		log.WriteEntry(message, type)
	End Sub

End Class
