Imports ModeloCI

Public Class Mecanico
    Private Altura As Double
    Private MaxTr As Double = 0
    Private MaxTp As Double = 0
    Private ADescubierto As Boolean
    'Private Tuberias As New List(Of MOD_POZO_TUBERIA)
    Private Cima As MOD_POZO_TUBERIA
    Private Tr_remove As Integer

    Private ComponentsTP() As String = {"TUBERIA DE PRODUCCION", "VALVULA DE TORMENTA"}
    Private ComponentsTR() As String = {"TUBERIA DE REVESTIMIENTO", "COLGADOR VERSAFLEX", "CONDUCTOR", "TUBO COaNDUCTOR", "LINER (DESCONTINUADO)", "PATA DE MULA", "CEDAZO", "TR 30", "TR Prueba", "ZAPATA RANURADA", "AGUJERO DESCUBIERTO"}
    Private TiposTuberias As Dictionary(Of Integer, String)

    Property Tps As New List(Of Tuberia)
    Property Trs As New List(Of Tuberia)


    Property Tuberias As New List(Of Tuberia) 'Resumen de tuberias seleccionadas despues del criterio


    Sub New(ByVal VwTrs As List(Of VW_TR), ByVal VwTps As List(Of VW_TP), Optional ByVal Err As Boolean = True)
        'Depreciado temporalmente talvez no sea necesario, marca error al cargar los datos iniciales del ViewModel
        If Err And (VwTrs.Count = 0) Then
            Throw New Exception("No hay tuberias de revestimiento, se necesita al menos uno para iniciar.")
        End If






        'Verificar que las Trs esten ordenados por Profundidad Inicio
        'Extraccion de TRS hasta llegar a base 0
        '=========================================================================================================
        'If VwTrs.Count > 0 Then
        For i = 0 To VwTrs.Count - 1

            If ComponentsTR.Contains(VwTrs(i).COMPONENTE) = False Then
                Continue For
            End If

            If i = 0 Then
                Dim Md As Double = ((VwTrs(i).PROFUNDIDADFIN - VwTrs(i).PROFUNDIDADINICIO) / 2) + VwTrs(i).PROFUNDIDADINICIO
                Trs.Add(New Tuberia() With {.Label = VwTrs(i).TITULO, .MD = Md, .CIDIAM = VwTrs(i).DIAMINT.GetValueOrDefault(), .CIROUG = 0.0006, .Type = 4})
            Else
                Trs.Add(New Tuberia() With {.Label = VwTrs(i).TITULO, .MD = VwTrs(i - 1).PROFUNDIDADINICIO, .CIDIAM = VwTrs(i).DIAMINT, .CIROUG = 0.0006, .Type = 4})
            End If



            If VwTrs(i).PROFUNDIDADINICIO = 0 Then
                Exit For
            End If
        Next
        'End If


        'Extraccion de TPS
        '========================================================================================================================
        If VwTps.Count > 0 Then

            If VwTps.Where(Function(w) w.COMPONENTE.ToLower().Contains("capsula")).Count > 0 Then MaxTp = (From tp In VwTps Where tp.COMPONENTE.Contains("CAPSULA") Select tp).Max(Function(m) m.PROFUNDIDAD) ''IIf(VwTps.Count > 0, (From tp In VwTps Where tp.COMPONENTE.Contains("CAPSULA") Select tp).Max(Function(m) m.PROFUNDIDAD), 0)
            For i = 0 To VwTps.Count - 1

                Dim TrActive = (From Tr In VwTrs Where Tr.PROFUNDIDADINICIO < VwTps(i).PROFUNDIDAD And Tr.PROFUNDIDADFIN > VwTps(i).PROFUNDIDAD).OrderByDescending(Function(o) o.PROFUNDIDADFIN).ToList()



                Dim label = VwTps(i).TITULO
                Dim cidiam As Double = 0 'Temporalmente ihabilitado para ser insertado despues
                Dim ciroug As Double = 0.0006
                Dim tidiam As Double = VwTps(i).DIAMINT.GetValueOrDefault()
                Dim tiroug As Double = 0.0006
                Dim todiam As Double = VwTps(i).DIAMEXT
                Dim toroug As Double = 0.0006
                Dim md As Double = VwTps(i).PROFUNDIDAD
                Dim type As Integer = -1


                Select Case VwTps(i).COMPONENTE.ToLower().Trim()
                    Case "E.M.R. Elevacion de la Mesa Rotaria"
                        type = 0
                        ciroug = 0
                        tidiam = 0
                        tiroug = 0
                        todiam = 0
                        toroug = 0
                        md = 0

                    Case "PORTA SENSORES"
                        type = 1
                    Case "TUBO"
                        type = 1
                    Case "COLA EXTENDIDA "
                        type = 1
                    Case "COPLE ESPACIADOR"
                        type = 1
                    Case "TUBERIA FLEXIBLE"
                        type = 1
                    Case "ESPACIADOR DE SEGURIDAD"
                        type = 1
                    Case "EXTENSION "
                        type = 1
                    Case "TUBO DENTADO"
                        type = 1
                    Case "TUBO MADRINA"
                        type = 1
                    Case "TFTV"
                        type = 1
                    Case "TUBERIA DE PRODUCCION"
                        type = 1
                    Case "EXTUBERIA"
                        type = 1
                    Case "COLA EXTENDIDA"
                        type = 1
                    Case "VALVULA DE SEGURIDAD"
                        type = 2
                    Case "VALVULA DE CHARNELA"
                        type = 2
                    Case "VALVULA DE TORMENTA"
                        type = 2
                    Case Else
                        type = -1
                End Select

                If type >= 0 Then

                    Tps.Add(New Tuberia() With {.Label = label, .MD = md, .CIDIAM = cidiam, .CIROUG = ciroug, .TIDIAM = tidiam, .TIROUG = tiroug, .TODIAM = todiam, .TOROUG = toroug, .Type = type})
                End If


            Next i

            'En caso de no haber capsula buscamos la maxima profundidad
            '===============================================================
            If MaxTp = 0 And Tps.Count > 0 Then
                MaxTp = (From Tp In Tps Select Tp).Max(Function(m) m.MD) 'VwTps(0).PROFUNDIDAD
            End If

            Dim Emr As Boolean = False

            For i = 0 To Tps.Count - 1
                Dim ini As Double = 0
                If Tps.Count - 1 > i Then
                    ini = Tps(i + 1).MD
                End If


                Dim fin = Tps(i).MD

                If Tps(i).Type = 0 Then
                    Tuberias.Add(Tps(i))
                    Emr = True
                Else
                    AddCuts(Tps(i), ini, fin)
                End If




            Next
            'Por si no se encuentra definido alguna EMR
            If VwTps.Count > 0 And Emr = False Then
                Tuberias.Add(New Tuberia() With {.Label = "E.M.R.", .MD = 0, .CIDIAM = 0, .CIROUG = 0, .TIDIAM = 0, .TIROUG = 0, .TODIAM = 0, .TOROUG = 0, .Type = 0})
            End If
        End If



        For i = 0 To Trs.Count - 1
            If Trs(i).MD > MaxTp Then
                Tuberias.Add(Trs(i))
            End If
        Next



    End Sub

    Sub AddCuts(ByVal Tp As Tuberia, ByVal Ini As Double, ByVal Fin As Double)
        Dim TotalTrs As Integer = Trs.Count
        Dim NextTr As Integer = 0
        Dim Insert As Boolean = False


        While TotalTrs > NextTr
            Dim IniTr = 0
            Dim FinTr = Trs(NextTr).MD

            If TotalTrs > NextTr + 1 Then
                IniTr = Trs(NextTr + 1).MD
            End If

            'Primer TP
            If Insert = False Then
                If FinTr > Fin And Fin > IniTr Then
                    Insert = True
                    Tp.CIDIAM = Trs(NextTr).CIDIAM
                    Tuberias.Add(Tp)

                End If

                If Ini > IniTr Then
                    Insert = False
                End If

                NextTr += 1

            Else

                Tuberias.Add(New Tuberia() With {.CIDIAM = Trs(NextTr).CIDIAM, .CIROUG = Tp.CIROUG, .Label = Tp.Label, .MD = Trs(NextTr).MD, .TIDIAM = Tp.TIDIAM, .TIROUG = Tp.TIROUG, .TODIAM = Tp.TODIAM, .TOROUG = Tp.TOROUG, .Type = Tp.Type})

                If Ini > IniTr Then
                    Insert = False
                End If

                NextTr += 1
            End If
        End While
    End Sub

    Function GetTuberias() As List(Of Tuberia)

        If Me.Tuberias.Count > 0 Then
            Return Me.Tuberias.OrderBy(Function(o) o.MD).ToList()
        Else
            Return New List(Of Tuberia)
        End If
    End Function





End Class

''' <summary>
''' 
''' </summary>
Public Class Tuberia
    Public Property CIDIAM As Double 'Diametro Interior de la TR
    Public Property CIROUG As Double 'Rugosidad Interior de la TR
    Public Property TIDIAM As Double 'Diametro Interior de la TP
    Public Property TIROUG As Double 'Rugosidad Interior de la TP
    Public Property TODIAM As Double 'Diametro Exterior de la TP
    Public Property TOROUG As Double 'Rugosidad Exterior de la TP
    Public Property MD As Double
    Public Property Label As String
    Public Property Type As Integer '0 = No aplica | 1 = TP | 2 = VT | 3 = RESTRICCION | 4 = TR 



End Class
