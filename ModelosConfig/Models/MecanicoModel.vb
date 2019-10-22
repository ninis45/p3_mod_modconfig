Imports ModeloCI
Public Class MecanicoModel
    'Property ID As String
    'Property Etiqueta As String
    'Property MD As Double
    'Property TODIAM As Double
    'Property TIDIAM As Double
    'Property CIDIAM As Double
    Property AE As Double
    Property DE As Double
    Property DH As Double
    Property Orden As Integer
    Property ModPozoTuberia As MOD_POZO_TUBERIA
    Property NewTuberia As List(Of Tuberia)
    Private VwMecanicos As List(Of MOD_POZO_TUBERIA)
    Private TipoTuberias As Dictionary(Of Integer, String)
    Private db As New ModeloCI.Entities_ModeloCI()
    Sub New()

    End Sub
    Sub New(ByVal Tuberia As List(Of Tuberia))

        Me.VwMecanicos = New List(Of MOD_POZO_TUBERIA)
        Me.TipoTuberias = db.CAT_TIPO_TUBERIA.Where(Function(w) w.ENDRECORD Is Nothing).ToDictionary(Function(d) d.NUMERO, Function(d) d.IDTIPOTUBERIA)
        For Each t In Tuberia
            Me.VwMecanicos.Add(New MOD_POZO_TUBERIA() With {.MD = t.MD, .CIDIAM = t.CIDIAM, .CIROUG = t.CIROUG, .ETIQUETA = t.Label, .TIDIAM = t.TIDIAM, .TIROUG = t.TIROUG, .TODIAM = t.TODIAM, .TOROUG = t.TOROUG, .IDTIPOTUBERIA = TipoTuberias(t.Type)})
        Next
    End Sub
    Sub New(ByVal VwMecanicos As List(Of MOD_POZO_TUBERIA))
        Me.TipoTuberias = db.CAT_TIPO_TUBERIA.Where(Function(w) w.ENDRECORD Is Nothing).ToDictionary(Function(d) d.NUMERO, Function(d) d.IDTIPOTUBERIA)
        Me.VwMecanicos = VwMecanicos
    End Sub
    Sub Reset()
        'Dim db As New Entities_ModeloCI()
        'VwMecanicos.Clear()
        'Dim Mecanico As New Mecanico(db.VW_TR.Where(Function(w) w.IDAGUJERO = IdAgujero).ToList(), db.VW_TP.Where(Function(w) w.IDAGUJERO = IdAgujero).ToList(), False)
        If NewTuberia.Count > 0 Then
            For Each t In NewTuberia
                Me.VwMecanicos.Add(New MOD_POZO_TUBERIA() With {.MD = t.MD, .CIDIAM = t.CIDIAM, .CIROUG = t.CIROUG, .ETIQUETA = t.Label, .TIDIAM = t.TIDIAM, .TIROUG = t.TIROUG, .TODIAM = t.TODIAM, .TOROUG = t.TOROUG})
            Next
        End If
    End Sub

    Function GetList() As List(Of MecanicoModel)
        Dim List As New List(Of MecanicoModel)

        If VwMecanicos.Count > 0 Then
            For Each Mecanico In VwMecanicos
                Dim AE = (3.14 * ((Mecanico.CIDIAM ^ 2) - (Mecanico.TODIAM ^ 2))) / 4
                Dim DE = ((AE * 4) / 3.14) ^ (1 / 2)
                Dim DH = Mecanico.CIDIAM - Mecanico.TODIAM

                Mecanico.ORDEN = IIF(Mecanico.ORDEN Is Nothing, 0, Mecanico.ORDEN)

                List.Add(New MecanicoModel() With {.ModPozoTuberia = Mecanico, .Orden = Mecanico.ORDEN, .AE = AE, .DE = DE, .DH = DH})
            Next
        End If

        Return List
    End Function

    Function GetMaxTp() As Double

        Return VwMecanicos.Where(Function(w) w.IDTIPOTUBERIA = TipoTuberias(1)).Max(Function(m) m.MD)
    End Function

End Class
