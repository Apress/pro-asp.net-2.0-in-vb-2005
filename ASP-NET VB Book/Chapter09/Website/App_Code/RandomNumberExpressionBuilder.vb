Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports System.Web.Compilation
Imports System.CodeDom
Imports System.ComponentModel

Public Class RandomNumberExpressionBuilder : Inherits ExpressionBuilder
	Public Shared Function GetRandomNumber(ByVal lowerLimit As Integer, ByVal upperLimit As Integer) As String
		Dim rand As Random = New Random()
		Dim randValue As Integer = rand.Next(lowerLimit, upperLimit + 1)
		Return randValue.ToString()
	End Function

	Public Overrides Function GetCodeExpression(ByVal entry As BoundPropertyEntry, ByVal parsedData As Object, ByVal context As ExpressionBuilderContext) As CodeExpression
		' entry.Expression is the number string
		' (minus the RandomNumber: prefix).
		If (Not entry.Expression.Contains(",")) Then
			Throw New ArgumentException("Must include two numbers separated by a comma.")
		Else
			' Get the two numbers.
			Dim numbers As String() = entry.Expression.Split(","c)

			If numbers.Length <> 2 Then
				Throw New ArgumentException("Only include two numbers.")
			Else
				Dim lowerLimit, upperLimit As Integer
				If Int32.TryParse(numbers(0), lowerLimit) AndAlso Int32.TryParse(numbers(1), upperLimit) Then

					' So far all the operations have been performed in
					' normal code. That's because the two numbers are
					' specified in the expression, and so they won't
					' change each time the page is requested.
					' However, the random number should be allowed to
					' change each time, so you need to switch to CodeDOM.
					Dim type As Type = entry.DeclaringType
					Dim descriptor As PropertyDescriptor = TypeDescriptor.GetProperties(type)(entry.PropertyInfo.Name)
					Dim expressionArray As CodeExpression() = New CodeExpression(1){}
					expressionArray(0) = New CodePrimitiveExpression(lowerLimit)
					expressionArray(1) = New CodePrimitiveExpression(upperLimit)
					Return New CodeCastExpression(descriptor.PropertyType, New CodeMethodInvokeExpression(New CodeTypeReferenceExpression(MyBase.GetType()), "GetRandomNumber", expressionArray))
				Else
					Throw New ArgumentException("Use valid integers.")
				End If

			End If
		End If

	End Function
End Class


