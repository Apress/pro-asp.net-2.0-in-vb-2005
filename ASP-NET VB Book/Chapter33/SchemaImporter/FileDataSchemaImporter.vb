Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Text
Imports System.Xml.Serialization
Imports System.Xml.Schema
Imports System.Xml
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports System.Xml.Serialization.Advanced
Imports System.IO

Namespace SchemaImporter
	Public Class FileDataSchemaImporter : Inherits SchemaImporterExtension
		Public Overrides Overloads Function ImportSchemaType(ByVal name As String, ByVal ns As String, ByVal context As XmlSchemaObject, ByVal schemas As XmlSchemas, ByVal importer As XmlSchemaImporter, ByVal compileUnit As CodeCompileUnit, ByVal mainNamespace As CodeNamespace, ByVal options As CodeGenerationOptions, ByVal codeProvider As CodeDomProvider) As String
			' Uncomment these lines for debugging.
			' (Messages are displayed when you run wsdl.exe
			' and this schema importer is called.)
			'Console.WriteLine("ImportSchemaType");
			'Console.WriteLine(name);
			'Console.WriteLine(ns);
			'Console.WriteLine();

			If name.Equals("FileData") AndAlso ns.Equals("http://www.apress.com/ProASP.NET/FileData") Then
				mainNamespace.Imports.Add(New CodeNamespaceImport("FileDataComponent"))
				Return "FileData"
			End If
			Return Nothing
		End Function

		Public Overrides Overloads Function ImportSchemaType(ByVal type As XmlSchemaType, ByVal context As XmlSchemaObject, ByVal schemas As XmlSchemas, ByVal importer As XmlSchemaImporter, ByVal compileUnit As CodeCompileUnit, ByVal mainNamespace As CodeNamespace, ByVal options As CodeGenerationOptions, ByVal codeProvider As CodeDomProvider) As String
			Return Nothing
		End Function

		Public Overrides Function ImportAnyElement(ByVal any As XmlSchemaAny, ByVal mixed As Boolean, ByVal schemas As XmlSchemas, ByVal importer As XmlSchemaImporter, ByVal compileUnit As CodeCompileUnit, ByVal mainNamespace As CodeNamespace, ByVal options As CodeGenerationOptions, ByVal codeProvider As CodeDomProvider) As String
			Return Nothing
		End Function

		Public Overrides Function ImportDefaultValue(ByVal value As String, ByVal type As String) As CodeExpression
			Return Nothing
		End Function

	End Class
End Namespace