Imports ModeloCI
Public Class MecanicoModel

    Property AE As Double
    Property DE As Double
    Property DH As Double
    Property Orden As Integer
    Property ModPozoTuberia As MOD_POZO_TUBERIA
    Property NewTuberia As List(Of Tuberia)
    Private ModPozoTuberias As List(Of MOD_POZO_TUBERIA)

    Private db As New ModeloCI.Entities_ModeloCI()
    Private TipoTuberias As Dictionary(Of Integer, String) = db.CAT_TIPO_TUBERIA.Where(Function(w) w.ENDRECORD Is Nothing).ToDictionary(Function(d) d.NUMERO, Function(d) d.IDTIPOTUBERIA)
    Sub New()

    End Sub
    ''' <summary>
    ''' Prepara la lista para ModPozoTuberias
    ''' </summary>
    ''' <param name="Tuberia">Lista de tuberias extraidas por discriminación del Estado Mecanico completo</param>
    Sub New(ByVal Tuberia As List(Of Tuberia))

        'If Tuberia.Count = 0 Then
        '    Throw New Exception("No hay tuberías para el estado mecánico.")
        'End If

        Me.ModPozoTuberias = New List(Of MOD_POZO_TUBERIA)

        If Tuberia.Count > 0 Then
            For Each t In Tuberia
                Me.ModPozoTuberias.Add(New MOD_POZO_TUBERIA() With {.MD = t.MD, .CIDIAM = t.CIDIAM, .CIROUG = t.CIROUG, .ETIQUETA = t.Label, .TIDIAM = t.TIDIAM, .TIROUG = t.TIROUG, .TODIAM = t.TODIAM, .TOROUG = t.TOROUG, .IDTIPOTUBERIA = TipoTuberias(t.Type)})
            Next
        End If

    End Sub
    Sub New(ByVal ModPozoTuberias As List(Of MOD_POZO_TUBERIA))

        'If ModPozoTuberias.Count = 0 Then
        '    Throw New Exception("No hay tuberías para el estado mecánico.")
        'End If

        Me.ModPozoTuberias = ModPozoTuberias
    End Sub
    Sub Reset()
        If NewTuberia.Count > 0 Then
            For Each t In NewTuberia
                Me.ModPozoTuberias.Add(New MOD_POZO_TUBERIA() With {.MD = t.MD, .CIDIAM = t.CIDIAM, .CIROUG = t.CIROUG, .ETIQUETA = t.Label, .TIDIAM = t.TIDIAM, .TIROUG = t.TIROUG, .TODIAM = t.TODIAM, .TOROUG = t.TOROUG})
            Next
        End If
    End Sub

    ''' <summary>
    ''' Obtiene la lista del Estado Mecanico con los valores extras: AE,DE y DH
    ''' </summary>
    ''' <returns></returns>
    Function GetList() As List(Of MecanicoModel)
        Dim List As New List(Of MecanicoModel)

        If ModPozoTuberias.Count > 0 Then
            For Each Mecanico In ModPozoTuberias
                Dim AE = (3.14 * ((Mecanico.CIDIAM ^ 2) - (Mecanico.TODIAM ^ 2))) / 4
                Dim DE = ((AE * 4) / 3.14) ^ (1 / 2)
                Dim DH = Mecanico.CIDIAM - Mecanico.TODIAM

                Mecanico.ORDEN = IIf(Mecanico.ORDEN Is Nothing, 0, Mecanico.ORDEN)

                List.Add(New MecanicoModel() With {.ModPozoTuberia = Mecanico, .Orden = Mecanico.ORDEN, .AE = AE, .DE = DE, .DH = DH})
            Next
        End If

        Return List
    End Function

    ''' <summary>
    ''' Obtiene la maxima profundidad de la lista de Tuberias TPs.
    ''' </summary>
    ''' <returns></returns>
    Function GetMaxTp() As Double
        If ModPozoTuberias.Count > 0 Then
            Return ModPozoTuberias.Where(Function(w) w.IDTIPOTUBERIA = TipoTuberias(1)).Max(Function(m) m.MD)
        Else
            Return 0
        End If
    End Function

End Class
