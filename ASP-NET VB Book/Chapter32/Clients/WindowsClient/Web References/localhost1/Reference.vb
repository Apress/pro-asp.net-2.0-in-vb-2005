﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.26
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.26.
'
Namespace localhost1
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.26"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="StatefulServiceSoap", [Namespace]:="http://tempuri.org/")>  _
    Partial Public Class StatefulService
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private StoreNameOperationCompleted As System.Threading.SendOrPostCallback
        
        Private GetNameOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.Settings.Default.WindowsClient_localhost1_StatefulService
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event StoreNameCompleted As StoreNameCompletedEventHandler
        
        '''<remarks/>
        Public Event GetNameCompleted As GetNameCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/StoreName", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Sub StoreName(ByVal name As String)
            Me.Invoke("StoreName", New Object() {name})
        End Sub
        
        '''<remarks/>
        Public Overloads Sub StoreNameAsync(ByVal name As String)
            Me.StoreNameAsync(name, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub StoreNameAsync(ByVal name As String, ByVal userState As Object)
            If (Me.StoreNameOperationCompleted Is Nothing) Then
                Me.StoreNameOperationCompleted = AddressOf Me.OnStoreNameOperationCompleted
            End If
            Me.InvokeAsync("StoreName", New Object() {name}, Me.StoreNameOperationCompleted, userState)
        End Sub
        
        Private Sub OnStoreNameOperationCompleted(ByVal arg As Object)
            If (Not (Me.StoreNameCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent StoreNameCompleted(Me, New System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetName", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetName() As String
            Dim results() As Object = Me.Invoke("GetName", New Object(-1) {})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GetNameAsync()
            Me.GetNameAsync(Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GetNameAsync(ByVal userState As Object)
            If (Me.GetNameOperationCompleted Is Nothing) Then
                Me.GetNameOperationCompleted = AddressOf Me.OnGetNameOperationCompleted
            End If
            Me.InvokeAsync("GetName", New Object(-1) {}, Me.GetNameOperationCompleted, userState)
        End Sub
        
        Private Sub OnGetNameOperationCompleted(ByVal arg As Object)
            If (Not (Me.GetNameCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetNameCompleted(Me, New GetNameCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.26")>  _
    Public Delegate Sub StoreNameCompletedEventHandler(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.26")>  _
    Public Delegate Sub GetNameCompletedEventHandler(ByVal sender As Object, ByVal e As GetNameCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.26"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GetNameCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
End Namespace
