Imports ModeloCI
Imports System.Data
Public Class Settings

    Shared Sub SetBy(ByVal Slug As String, ByVal Value As String)

        Dim db As New Entities_ModeloCI()
        Dim setting = db.SETTINGS.Where(Function(w) w.SLUG = Slug).SingleOrDefault()


        If setting IsNot Nothing Then

            setting.VALUE = Value
            db.Entry(setting).State = Entity.EntityState.Modified
            db.SaveChanges()




        End If
    End Sub

    Shared Function GetBy(ByVal Slug As String) As String
        Dim db As New Entities_ModeloCI()
        Dim setting = db.SETTINGS.Where(Function(w) w.SLUG = Slug).SingleOrDefault()

        If setting IsNot Nothing Then
            Dim Value As String = setting.VALUE

            If setting.VALUE IsNot Nothing AndAlso setting.VALUE <> "" Then
                Value = setting.VALUE
            End If

            Return Value
        End If
        Return ""
    End Function

End Class
