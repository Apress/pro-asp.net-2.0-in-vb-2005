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
Imports System.IO

''' <summary>
''' Summary description for DynamicPanel
''' </summary>
Namespace DynamicControls

    Public Class DynamicPanel
        Inherits Panel
        Implements ICallbackEventHandler, ICallbackContainer


        Protected Overrides Sub OnInit(ByVal e As EventArgs)
            MyBase.OnInit(e)

            Dim script As String = "<script language='JavaScript'>" & ControlChars.CrLf & "       function RefreshPanel(result, context)" & ControlChars.CrLf & "       {" & ControlChars.CrLf & "         if (result != '')" & ControlChars.CrLf & "         {" & ControlChars.CrLf & "           var separator = result.indexOf('_'); " & ControlChars.CrLf & "           var elementName = result.substr(0, separator);" & ControlChars.CrLf & "           var panel = document.getElementById(elementName);" & ControlChars.CrLf & "           panel.innerHTML = result.substr(separator+1);" & ControlChars.CrLf & "         }" & ControlChars.CrLf & "       }" & ControlChars.CrLf & "    </script>"

            Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "RefreshPanel", script)

        End Sub

        Public Event Refreshing As EventHandler

        Public Function RaiseCallbackEvent(ByVal eventArgument As String) As String Implements ICallbackEventHandler.RaiseCallbackEvent
            ' Fire an event to notify the client a refresh has been requested.
            If Not RefreshingEvent Is Nothing Then
                RaiseEvent Refreshing(Me, EventArgs.Empty)
            End If

            EnsureChildControls()

            Using sw As StringWriter = New StringWriter()
                Using writer As HtmlTextWriter = New HtmlTextWriter(sw)
                    writer.Write(Me.ClientID & "_")
                    Me.RenderContents(writer)
                End Using
                Return sw.ToString()
            End Using
        End Function


        Public Function GetCallbackScript(ByVal buttonControl As IButtonControl, ByVal argument As String) As String Implements ICallbackContainer.GetCallbackScript
            Return Page.ClientScript.GetCallbackEventReference(Me, "", "RefreshPanel", "null")
        End Function

    End Class


End Namespace