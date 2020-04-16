Imports System.Globalization

Public Class EstatusHelper
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
        Dim Estatus As String = "NA"

        Select Case value
            Case 1
                Estatus = "En cola"
            Case 2
                Estatus = "En proceso"
            Case 3
                Estatus = "Realizado"
            Case Else
                Estatus = "NA"
        End Select

        Return Estatus
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class
