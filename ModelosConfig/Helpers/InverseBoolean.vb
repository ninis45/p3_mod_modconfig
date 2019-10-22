Imports System.Globalization
Public Class InverseBoolean
    Implements IValueConverter

    Public Function Convert(value As Object, ByVal targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert



        If targetType <> GetType(Boolean) Then
            Throw New InvalidOperationException("El tipo debe ser booleano")
        End If

        Return Not CType(value, Boolean)
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
        Return If(value Is Nothing, parameter, Binding.DoNothing)

    End Function
End Class
