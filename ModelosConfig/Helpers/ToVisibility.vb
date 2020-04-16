Imports System.Globalization

Public Class ToVisibility
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert



        If value IsNot Nothing AndAlso value = parameter Then

            Return "Visibility"

        End If

        Return "Collapsed"


    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
        Return parameter
    End Function
End Class
