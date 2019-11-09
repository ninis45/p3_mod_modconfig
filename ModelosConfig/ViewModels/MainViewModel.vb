Imports ModeloCI
Imports Telerik.Windows.Controls
Imports Prism.Mvvm
Imports System.Windows.Forms.Integration

Public Class MainViewModel
    Inherits BindableBase

    Public grfProductividad As New grfProductividad()
    Public grfCorrelacion As New grfCorrelacion()
    Public grfVpl As New grfVlp()
    Public grfGas As New grfGas()
    Public grfDiag As New grfDiag()
    Public grfWc As New grfWc()
    Public usrTrayectoria As New usrTrayectoria()



    'Private MPrsp As Crea.Modelo
    Private db As New Entities_ModeloCI()

    Private AgujeroModel As AgujeroModel
    'Private Estabilidad As ModelosEstabilidad.Main
    Property Mecanicos As List(Of Tuberia)
    Property NewMecanicos As List(Of Tuberia)

    Public Property IdUsuario As String

    Sub New(ByVal IdAgujero As String, ByVal Fecha As String, ByVal IdUsuario As String)

        Me.IdUsuario = IdUsuario

        'IDAGUJERO                                    LIFTMETHOD           FECHA P.
        '55A5DD64-F543-4B5F-874A-8E1C49CDEF4A             1               2016-01-25    
        '57EB0E3D-1A72-45B3-A3BF-377B504A238B             2               2019-02-19
        '677069CB-7862-43BD-B3D8-7E41B5895ED1             1               2018-08-10
        'DDB3A31F-0143-42E3-819B-9B4A4B631D33             2               2019-03-25
        '24ACEE43-3CC1-4E8E-9535-76D049D2DDCC  
        '817A460B-3856-4837-98A4-ACF6F622D33F             1               2019-02-11              MAALOB-492
        '1A9B6D8D-50ED-4719-BA34-37D8337B7A22             1               2018-08-11              BALAM-41
        '56B74925-CE90-4E2D-8FAC-9933EBC4899D             1               2018-01-02              KU-288
        'A97B64BE-A958-40BF-80F6-6A4B0B67B87A             1               2018-08-03              RABASA 125




        'Me.Estabilidad = Estabilidad
        Me.IdAgujero = IdAgujero '"56B74925-CE90-4E2D-8FAC-9933EBC4899D"
        FechaPrueba = Fecha ' "2018-01-02"





        'Mecanicos = AgujeroModel.Mecanicos
        Panel = "| Panel de Modelos"



        'Dim mecanico As New Mecanico(db.VW_TR.Where(Function(w) w.IDAGUJERO = IdAgujero).OrderByDescending(Function(o) o.PROFUNDIDADINICIO).ToList(), db.VW_TP.Where(Function(w) w.IDAGUJERO = IdAgujero).OrderByDescending(Function(w) w.PROFUNDIDAD).ToList())


        'Dim tuberias = mecanico.GetTuberias()

    End Sub
    Function Refresh() As VW_EDO_GENERAL
        Return AgujeroModel.GetEdoGeneral()
    End Function
    Sub LoadAgujero()
        Estatus = 0
        Prog = ""
        Intentos = Nothing
        'Resteamos mensajes
        '===============================================
        Infos.Clear()
        Success.Clear()

        'Consultamos el Agujero
        '============================================
        AgujeroModel = New AgujeroModel(IdAgujero)
        IdPozo = AgujeroModel.IdPozo
        LiftMethod = AgujeroModel.LiftMethod
        Pozo = "Modelo del Pozo: " + AgujeroModel.Pozo
        Configuraciones = New List(Of CONFIGURACION)
        'Buscar modelos realizados correctamente y por condiciones de operacion
        '==================================================================================================================================================
        Modelos = db.VW_MOD_POZO.Where(Function(w) w.IDAGUJERO = IdAgujero And w.ESTATUS = 3 And w.FUNCION = 6).OrderBy(Function(o) o.FECHAMODELO).ToList()
        Condiciones = db.VW_MOD_POZO.Where(Function(w) w.IDAGUJERO = IdAgujero And w.ESTATUS = 3 And w.FUNCION = 2).OrderBy(Function(o) o.FECHAMODELO).ToList()


        'Mecanicos = AgujeroModel.Mecanicos ' db.VW_EDO_MECANICO.Where(Function(w) w.IDAGUJERO = IdAgujero).OrderBy(Function(o) o.MD).ToList()
        ' Dim MecanicoModel As New MecanicoModel()


        Dim SAPs = db.CAT_SAP.Where(Function(w) w.PROSPER IsNot Nothing).ToDictionary(Function(d) d.PROSPER, Function(d) d.NOMBRE)

        If SAPs.ContainsKey(LiftMethod) Then
            Pozo += " - " + SAPs(LiftMethod)
        End If

        If AgujeroModel.VWGeneral IsNot Nothing Then

            IdModPozo = AgujeroModel.VWGeneral.IDMODPOZO
            'Me.VwGeneral = AgujeroModel.VWGeneral 'Se duplicaba la consulta



        Else
            IdModPozo = Nothing
            Infos.Add("Pozo sin modelo, para agregar uno, pulsa el botón [+] para abrir el formulario de captura.")
        End If



    End Sub

    Private _modelos As List(Of VW_MOD_POZO)
    Property Modelos As List(Of VW_MOD_POZO)
        Get
            Return _modelos
        End Get
        Set(value As List(Of VW_MOD_POZO))
            _modelos = value

            If _modelos IsNot Nothing AndAlso _modelos.Count > 0 Then
                Infos.Add("Actualmente existen modelos ejecutados correctamente, puedes consultarlo a través de la lista de lado derecho de este panel.")
            End If

            RaisePropertyChanged("Modelos")
        End Set
    End Property

    Private _condiciones As List(Of VW_MOD_POZO)
    Property Condiciones As List(Of VW_MOD_POZO)
        Get
            Return _condiciones
        End Get
        Set(value As List(Of VW_MOD_POZO))
            _condiciones = value

            If _condiciones IsNot Nothing AndAlso _modelos.Count > 0 Then
                Infos.Add("Actualmente existen modelos ejecutados por condiciones de operación, puedes consultarlo en este panel.")
            End If

            RaisePropertyChanged("Condiciones")
        End Set
    End Property

    Private _id_pozo As String
    Public Property IdPozo As String
        Get
            Return _id_pozo
        End Get
        Set(value As String)
            _id_pozo = value
            RaisePropertyChanged("IdPozo")
        End Set
    End Property
    Private _id_agujero As String
    Public Property IdAgujero() As String
        Get
            Return _id_agujero
        End Get
        Set(value As String)
            _id_agujero = value
            If _id_agujero Is Nothing Then
                'FlashData = New ModelosEstabilidad.FlashData() With {
                '    .Estatus = "info",
                '    .Message = "Selecciona el agujero para cargar los datos"
                '}

            Else
                LoadAgujero()

            End If


            GetMessages()
            RaisePropertyChanged("IdAgujero")
        End Set
    End Property
    Private _id_mod_pozo As String
    Public Property IdModPozo() As String
        Get
            Return _id_mod_pozo
        End Get
        Set(value As String)
            _id_mod_pozo = value
            If _id_mod_pozo IsNot Nothing Then

                VwGeneral = db.VW_EDO_GENERAL.Where(Function(w) w.IDMODPOZO = _id_mod_pozo).SingleOrDefault()






            End If
            'Reviar por depreciacion las configuraciones de estabilidad
            'Estabilidad.Load(_id_mod_pozo)
            RaisePropertyChanged("IdModPozo")

        End Set
    End Property
    Private _mod_pozo As MOD_POZO
    Public Property ModPozo As MOD_POZO
        Get
            Return _mod_pozo
        End Get
        Set(value As MOD_POZO)
            _mod_pozo = value
        End Set
    End Property
    Private _estatus As String
    Public Property Estatus As String
        Get
            Return _estatus
        End Get
        Set(value As String)
            _estatus = value
            RaisePropertyChanged("Estatus")
        End Set
    End Property
    Private _fecha_prueba As String
    Public Property FechaPrueba() As String
        Get
            Return _fecha_prueba
        End Get
        Set(value As String)
            _fecha_prueba = value
        End Set
    End Property
    Private _lift_method As Double
    Public Property LiftMethod() As Double
        Get
            Return _lift_method
        End Get
        Set(value As Double)
            _lift_method = value
            RaisePropertyChanged("LiftMethod")
        End Set
    End Property
    Private _configuraciones As List(Of CONFIGURACION)
    Property Configuraciones As List(Of CONFIGURACION)
        Get
            Return _configuraciones
        End Get
        Set(value As List(Of CONFIGURACION))
            _configuraciones = value
            RaisePropertyChanged("Configuraciones")
        End Set
    End Property
    Private _id_configuracion As String
    Property IdConfiguracion As String
        Get
            Return _id_configuracion
        End Get
        Set(value As String)
            _id_configuracion = value
            'Estabilidad.Load(_id_mod_pozo, _id_configuracion)
            RaisePropertyChanged("IdConfiguracion")
        End Set
    End Property
    Private _pozo As String
    Public Property Pozo As String
        Get
            Return _pozo
        End Get

        Set(value As String)
            _pozo = value
            RaisePropertyChanged("Pozo")
        End Set
    End Property
    Private _prog As String
    Public Property Prog As String
        Get


            Return _prog
        End Get
        Set(value As String)
            _prog = value
            RaisePropertyChanged("Prog")
        End Set
    End Property

    Private _intentos As List(Of EJECUCION_PROCESOS)
    Public Property Intentos As List(Of EJECUCION_PROCESOS)
        Get

            Return _intentos
        End Get
        Set(value As List(Of EJECUCION_PROCESOS))
            _intentos = value
            RaisePropertyChanged("Intentos")
        End Set
    End Property
    Private _panel As String
    Public Property Panel As String
        Get
            Return _panel
        End Get
        Set(value As String)
            _panel = value
            RaisePropertyChanged("Panel")
        End Set
    End Property



    Private _flash_data As ModelosEstabilidad.FlashData
    Public Property FlashData As ModelosEstabilidad.FlashData
        Get
            Return _flash_data
        End Get
        Set(value As ModelosEstabilidad.FlashData)
            _flash_data = value
        End Set
    End Property


    Private _infos As ObjectModel.ObservableCollection(Of String)
    Public Property Infos As ObjectModel.ObservableCollection(Of String)
        Get
            If _infos Is Nothing Then
                _infos = New ObjectModel.ObservableCollection(Of String)
            End If
            Return _infos
        End Get
        Set(value As ObjectModel.ObservableCollection(Of String))
            _infos = value

            RaisePropertyChanged("Infos")
        End Set
    End Property

    Private _success As ObjectModel.ObservableCollection(Of String)
    Public Property Success As ObjectModel.ObservableCollection(Of String)
        Get
            If _success Is Nothing Then
                _success = New ObjectModel.ObservableCollection(Of String)
            End If
            Return _success
        End Get
        Set(value As ObjectModel.ObservableCollection(Of String))
            _success = value

            RaisePropertyChanged("Success")
        End Set
    End Property

    Private _warnings As ObjectModel.ObservableCollection(Of ModelosEstabilidad.FlashData)
    Public Property Warnings As ObjectModel.ObservableCollection(Of ModelosEstabilidad.FlashData)
        Get
            If _warnings Is Nothing Then
                _warnings = New ObjectModel.ObservableCollection(Of ModelosEstabilidad.FlashData)
            End If
            Return _warnings
        End Get
        Set(value As ObjectModel.ObservableCollection(Of ModelosEstabilidad.FlashData))
            _warnings = value

            RaisePropertyChanged("Warnings")
        End Set
    End Property

    Private _errors As ObjectModel.ObservableCollection(Of String)
    Public Property Errors As ObjectModel.ObservableCollection(Of String)
        Get
            If _errors Is Nothing Then
                _errors = New ObjectModel.ObservableCollection(Of String)
            End If
            Return _errors
        End Get
        Set(value As ObjectModel.ObservableCollection(Of String))
            _errors = value

            RaisePropertyChanged("Errors")
        End Set
    End Property


    Private _vw_general As VW_EDO_GENERAL
    Public Property VwGeneral As VW_EDO_GENERAL
        Get
            Return _vw_general
        End Get
        Set(value As VW_EDO_GENERAL)
            _vw_general = value
            Intentos = Nothing
            Infos.Clear()
            Success.Clear()

            If _vw_general IsNot Nothing Then



                If _vw_general IsNot Nothing Then
                    Estatus = _vw_general.ESTATUS.GetValueOrDefault()
                    If Estatus = -1 Then
                        Estatus = 0
                    End If
                End If

                Select Case Estatus
                    Case 0
                        Prog = "Última configuración: " + _vw_general.FECHAMODELO
                    Case 1
                        Prog = "Programado: " + _vw_general.FECHA_PROGRAMACION
                    Case 2
                        Prog = "En ejecución: " + _vw_general.FECHAMODELO
                    Case 3
                        LoadCharts(_vw_general)
                        Success.Add("Modelo ejecutado correctamente")
                End Select
                If Prog <> "" Then Infos.Add(Prog)

            End If

            GetMessages()
            RaisePropertyChanged("VwGeneral")
        End Set
    End Property
    Sub GetMessages()

        Errors.Clear()
        Warnings.Clear()

        Dim Aforos As Integer = db.VW_AFORO.Where(Function(w) w.IDPOZO = IdPozo).Count()
        Dim Pvts As Integer = db.VW_PVT.Where(Function(w) w.IDAGUJERO = IdAgujero).Count()
        Dim Trays = db.VW_TRAYECTORIA.Where(Function(w) w.IDAGUJERO = IdAgujero).Count()

        If Intentos IsNot Nothing Then
            For Each i In Intentos
                Warnings.Add(New ModelosEstabilidad.FlashData() With {.Estatus = "error", .Message = i.ERRORS})
            Next
        End If
        'Se podria extraer al momento de crear el modelo - Posible depreciacion
        'If Mecanicos.Count = 0 Then
        '    Errors.Add("No hay estado mecánico para el Modelo, se recomienda revisar el módulo de Estado Mecanico a fin de generar un nuevo listado para el dicho modelo")
        'End If


        If Aforos = 0 Then
            Errors.Add("No hay registros de Aforo.")
        End If

        If Pvts = 0 Then
            Errors.Add("No hay registros de Pvt.")
        End If

        If Trays = 0 Then
            Errors.Add("No hay registros de Trayectoria.")
        End If



    End Sub
    Sub Initialize(ByVal hst_prod As WindowsFormsHost, ByVal hst_correla As WindowsFormsHost, ByVal hst_vpl As WindowsFormsHost, ByVal hst_gas As WindowsFormsHost, ByVal hst_diag As WindowsFormsHost, ByVal hst_wc As WindowsFormsHost)

        Inicial.Init(LiftMethod)


        hst_prod.Child = grfProductividad
        hst_correla.Child = grfCorrelacion
        hst_vpl.Child = grfVpl
        hst_gas.Child = grfGas
        hst_diag.Child = grfDiag
        hst_wc.Child = grfWc



        ' actualizar()

    End Sub
    Public Sub LoadCharts(ByVal mod_general As VW_EDO_GENERAL)




        If Estatus = 3 Then
            LoadIPR(mod_general)
            LoadCorrela(mod_general)
            LoadVLPIPR(mod_general)
            LoadGAS(mod_general)
            LoadDiag(mod_general)
            LoadWC(mod_general)
        End If

    End Sub

#Region "GRAFICAS"
    '============================================================
    'Datos Chart1 
    Sub LoadIPR(ByVal model As VW_EDO_GENERAL)
        Dim PTest1(2), RTEOTest1(2) As Double


        PTest1(0) = 0
        PTest1(1) = model.PTEST.GetValueOrDefault()
        PTest1(2) = model.PTEST.GetValueOrDefault()
        RTEOTest1(0) = model.QTEST.GetValueOrDefault()
        RTEOTest1(1) = model.QTEST.GetValueOrDefault()
        RTEOTest1(2) = 0




        Dim vlp = db.VLP_IPR.Where(Function(w) w.IDMODPOZO = model.IDMODPOZO And w.ENDRECORD Is Nothing).SingleOrDefault()
        Dim vlp_detalles = db.VLP_IPR_DETALLE.Where(Function(w) w.IDVLPIPR = vlp.IDVLPIPR And w.ENDRECORD Is Nothing).OrderBy(Function(o) o.IPR_RTEL).ToList()


        Dim IPR_RTEL(vlp_detalles.Count - 1) As Double
        Dim IPR_WPF(vlp_detalles.Count - 1) As Double

        Dim NdatAux As Integer
        NdatAux = 19
        Dim Xaux(vlp_detalles.Count - 1), Yaux(vlp_detalles.Count - 1) As Double

        For i = 0 To vlp_detalles.Count - 1
            IPR_RTEL(i) = vlp_detalles(i).IPR_RTEL
            IPR_WPF(i) = vlp_detalles(i).IPR_PWF


            Xaux(i) = vlp_detalles(i).VLP_RTEL
            Yaux(i) = vlp_detalles(i).VLP_PWF
        Next i

        'line1
        grfProductividad.TChart1.Series(0).Title = vlp.TITULO2 'IPR
        grfProductividad.TChart1.Series(0).Add(IPR_RTEL, IPR_WPF)

        'line2
        grfProductividad.TChart1.Series(1).Add(RTEOTest1, PTest1)
        grfProductividad.TChart1.Series(1).Legend.Visible = False

        'line3
        grfProductividad.TChart1.Series(2).Add(Xaux, Yaux)
        grfProductividad.TChart1.Series(2).Title = vlp.TITULO1







    End Sub
    'Datos Chart2
    Sub LoadCorrela(ByVal model As VW_EDO_GENERAL)
        Dim PTest1(2), PrfTest1(2) As Double
        Dim PTest2(1), PrfTest2(1) As Double
        Dim xaux As New Dictionary(Of String, ArrayList)
        Dim yaux As New Dictionary(Of String, ArrayList)


        Dim cat_correlas = db.CAT_CORRELACION.Where(Function(w) w.ENDRECORD Is Nothing).OrderBy(Function(o) o.NUM).ToDictionary(Function(d) d.IDCATCORRELACION, Function(d) d.NOMBRE)
        Dim correlaciones = (From correlas In db.VW_CORRELACIONES Where correlas.IDMODPOZO = model.IDMODPOZO Order By correlas.IDCORRELACION, correlas.PROFMD).ToList() 'db.VW_CORRELACIONES.Where(Function(w) w.IDMODPOZO = IdModPozo).OrderBy(Function(o) o.IDCORRELACION).OrderBy(Function(o) o.IDCORRELACION).OrderBy(Function(o) o.PROFMD).ToList()



        For Each correlacion In correlaciones
            If xaux.ContainsKey(correlacion.IDCATCORRELACION) = False Then



                xaux.Add(correlacion.IDCATCORRELACION, New ArrayList())
                yaux.Add(correlacion.IDCATCORRELACION, New ArrayList())
            End If
            xaux(correlacion.IDCATCORRELACION).Add(Math.Round(correlacion.PRES, 2))
            yaux(correlacion.IDCATCORRELACION).Add(Math.Round(correlacion.PROFMD, 2))
        Next


        Select Case model.LIFTMETHOD
            Case 1 'BN



                PrfTest1(0) = AgujeroModel.ModTuberias(AgujeroModel.ModTuberias.Count - 1).MD 'nivel medio de disparo
                PrfTest1(1) = AgujeroModel.ModTuberias(AgujeroModel.ModTuberias.Count - 1).MD '100'.NivMedDisp.Val


                PTest1(0) = 0
                PTest1(1) = model.PTEST
                PTest1(2) = model.PTEST

                PrfTest1(2) = 0


            Case 2 'BEC
                PrfTest1(0) = model.PROF_BEC '.Prof_BEC.Val Esperar nuevo formulario
                PrfTest1(1) = model.PROF_BEC '.Prof_BEC.Val Esperar nuevo formulario

                PTest1(0) = 0
                PTest1(1) = model.PREDES_BEC
                PTest1(2) = model.PREDES_BEC

                PrfTest1(2) = 0
        End Select






        'punto.Add(PrfTest1, PTest1)
        'grfCorrelacion.TChart1.Series.Add(punto)

        'Dim punto = New Points()
        'punto.Title = "Punto de operación"
        'punto.Color = Colors.Red
        'punto.Pointer.Style = PointerStyles.Circle
        'punto.Add(PTest1, PrfTest1)
        grfCorrelacion.TChart1.Series(0).Add(PTest1, PrfTest1) 'Revisar el PrfTest1 esta erroneo
        grfCorrelacion.TChart1.Series(0).Legend.Text = "Punto de operación"


        ''grfCorrelacion.TChart1.Series(0).Legend.Color = 
        '' grfCorrelacion.TChart1.Series(0).Legend.Visible = False



        For i = 0 To xaux.Count - 1

            grfCorrelacion.TChart1.Series(i + 1).Title = cat_correlas(xaux.Keys(i))



            Dim x = xaux.Values(i).ToArray(GetType(Double))
            Dim y = yaux.Values(i).ToArray(GetType(Double))
            grfCorrelacion.TChart1.Series(i + 1).Add(x, y)
        Next i




    End Sub
    'Datos TChart3
    Sub LoadVLPIPR(ByVal model As VW_EDO_GENERAL)

        '================CONSULTAS==================
        'Dim vlp_gastos = db.VLP_IPR_GASTO_INYECCION.Where(Function(w) w.IDMODPOZO = IdModPozo And w.ENDRECORD Is Nothing).OrderBy(Function(o) o.QL).ToList()
        Dim vlp_gastos = db.VW_VLP_GASTOS.Where(Function(w) w.IDMODPOZO = model.IDMODPOZO).OrderBy(Function(o) o.XAUX).ToList()
        ' (From vlp In db.VW_VLP_GASTOS Where vlp.IDMODPOZO = IdModPozo Order By vlp.TITULO).ToList() ' db.VW_VLP_GASTOS.Where(Function(w) w.IDMODPOZO = IdModPozo).ToList()
        '===========TERMINA CONSULTAS===============
        Dim xaux As New Dictionary(Of String, ArrayList)
        Dim yaux As New Dictionary(Of String, ArrayList)

        Dim NumGraf As Integer = 4
        Dim NumDat As Integer = 20

        Dim RTEOTest1(2), PTest1(2) As Double


        RTEOTest1(0) = 0
        RTEOTest1(1) = model.QTEST
        RTEOTest1(2) = model.QTEST

        PTest1(0) = model.PTEST
        PTest1(1) = model.PTEST
        PTest1(2) = 0

        grfVpl.TChart1.Series(0).Legend.Visible = False


        Dim NdatAux As Integer
        NdatAux = NumDat - 1



        For Each gasto In vlp_gastos
            If gasto.IS_VLP And xaux.ContainsKey(gasto.TITULO.ToString()) = False Then
                xaux.Add(gasto.TITULO.ToString(), New ArrayList())
                yaux.Add(gasto.TITULO.ToString(), New ArrayList())
                Exit For
            End If

        Next


        For Each gasto In vlp_gastos

            If xaux.ContainsKey(gasto.TITULO.ToString()) = False And gasto.IS_VLP = 0 Then
                xaux.Add(gasto.TITULO.ToString(), New ArrayList())
                yaux.Add(gasto.TITULO.ToString(), New ArrayList())
            End If

            xaux(gasto.TITULO.ToString()).Add(gasto.XAUX)
            yaux(gasto.TITULO.ToString()).Add(gasto.YAUX)

        Next


        Select Case model.LIFTMETHOD
            Case 1
                'line1
                ' grfVpl.TChart1.Series(0).Add(RTEOTest1, PTest1) 'eliminar de la grafica definitivamente



                grfVpl.TChart1.Text = "VLP/IPR-Sensibilidad de QgIny"
                grfVpl.TChart1.Axes.Left.Title.Text = "Presión de Fondo Fluyendo [Kg/cm2]"
                grfVpl.TChart1.Axes.Bottom.Title.Text = "Gasto de Líquido [STBPD]"

                grfVpl.TChart1.Series(12).Add(model.QTEST, model.PTEST)
                grfVpl.TChart1.Series(12).Visible = True
               ' grfVpl.TChart1.Series(12).Title = "Punto de operación"
                'Dim punto As New Steema.TeeChart.WPF.Styles.Points With {
                '     .Color = Colors.Black,
                '     .Title = "Punto de operación"
                '}
                'punto.Pointer.HorizSize = 10
                'punto.Pointer.VertSize = 10
                'punto.Pointer.Style = PointerStyles.Circle

                'punto.Add(5, 5)




            Case 2
                grfVpl.TChart1.Text = "VLP/Presión de Descargar Sensibilizando Frecuencia"
                grfVpl.TChart1.Axes.Left.Title.Text = "Presión de Descarga [Kg/cm2]"
                grfVpl.TChart1.Axes.Bottom.Title.Text = "Gasto de Líquido [STBPD]"

                grfVpl.TChart1.Series(12).Visible = False
        End Select

        Dim titulos As List(Of String) = xaux.Keys.ToList()

        For i = 0 To titulos.Count - 1

            Dim x = xaux.Values(i).ToArray(GetType(Double))
            Dim y = yaux.Values(i).ToArray(GetType(Double))
            grfVpl.TChart1.Series(i + 1).Title = titulos(i) 'xaux.Keys(i)
            grfVpl.TChart1.Series(i + 1).Add(x, y)

        Next i
    End Sub
    'Datos Tchart4
    Sub LoadGAS(ByVal model As VW_EDO_GENERAL)
        Dim comportamientos = (From com In db.COMPORTAMIENTO_GAS Join det In db.COMPORTAMIENTO_GAS_DETALLES On com.IDCOMPORTAMIENTOGAS Equals det.IDCOMPORTAMIENTOGAS Where com.IDMODPOZO = model.IDMODPOZO).ToList()

        Dim xaux As New Dictionary(Of String, ArrayList)
        Dim yaux As New Dictionary(Of String, ArrayList)

        'Reseteamos gráficas
        For i = 0 To 8
            grfGas.TChart1.Series(i).Clear()
        Next


        For Each com In comportamientos

            If com.det.YAUX > 0 Then
                If xaux.ContainsKey(com.com.TITULO.ToString()) = False Then
                    xaux.Add(com.com.TITULO.ToString(), New ArrayList())
                    yaux.Add(com.com.TITULO.ToString(), New ArrayList())
                End If
                xaux(com.com.TITULO.ToString()).Add(com.det.XAUX)
                yaux(com.com.TITULO.ToString()).Add(com.det.YAUX)
            End If


        Next

        Select Case model.LIFTMETHOD
            Case 1
                grfGas.TChart1.Text = "Comportamiento del Gas de BN"
                grfGas.TChart1.Axes.Left.Title.Text = "Gasto de Líquido [STBPD]"
                grfGas.TChart1.Axes.Bottom.Title.Text = "Gasto de Inyección de gas [MMSCFPD]"

                Dim QgiTest1(1), QliqTest1(1) As Double
                Dim QgiTest2(1), QliqTest2(1) As Double

                Dim GlRate As Double = model.GLRATE

                QgiTest1(0) = GlRate
                QgiTest1(1) = GlRate
                QliqTest1(0) = model.QTEST
                QliqTest1(1) = model.QTEST
                QgiTest2(0) = 0
                QgiTest2(1) = GlRate
                QliqTest2(0) = model.QTEST
                QliqTest2(1) = model.QTEST

                grfGas.TChart1.Series(0).Add(QgiTest1, QliqTest1)
                grfGas.TChart1.Series(1).Add(QgiTest2, QliqTest2)
                grfGas.TChart1.Series(2).Title = "Qgi"

                Dim x = xaux.Values(0).ToArray(GetType(Double))
                Dim y = yaux.Values(0).ToArray(GetType(Double))
                grfGas.TChart1.Series(2).Add(x, y)

                grfGas.TChart1.Series(0).Legend.Visible = False
                grfGas.TChart1.Series(1).Title = "Punto de operación"

                For i = 3 To 7
                    grfGas.TChart1.Series(i).Legend.Visible = False
                Next

                grfGas.TChart1.Series(8).Legend.Visible = False
            Case 2
                grfGas.TChart1.Text = "Carta de la Bomba "
                grfGas.TChart1.Axes.Left.Title.Text = "Carga de la Bomba (m)"
                grfGas.TChart1.Axes.Bottom.Title.Text = "Gasto de Líquido [RBPD]"

                Dim titulos As List(Of String) = xaux.Keys.ToList()



                For i = 0 To titulos.Count - 1

                    Dim x = xaux.Values(i).ToArray(GetType(Double))
                    Dim y = yaux.Values(i).ToArray(GetType(Double))
                    grfGas.TChart1.Series(i).Title = titulos(i) 'xaux.Keys(i)
                    grfGas.TChart1.Series(i).Add(x, y)

                Next i

                grfGas.TChart1.Series(7).Legend.Visible = False
                'grfGas.TChart1.Series(8).Add(model.Qpromedio.GetValueOrDefault(), model.General.GetValueOrDefault())REVISAR URGENTEMENTE HAY Q MODIFICAR VALORES

        End Select
    End Sub
    'Datos Tchart5
    Sub LoadDiag(ByVal model As VW_EDO_GENERAL)
        Dim diagnosticos = db.VW_DIAGNOSTICOS.Where(Function(w) w.IDMODPOZO = model.IDMODPOZO).OrderBy(Function(o) o.YAUX).ToList()
        Dim xaux As New Dictionary(Of String, ArrayList)
        Dim yaux As New Dictionary(Of String, ArrayList)

        For i = 0 To 3
            grfDiag.TChart1.Series(i).Clear()
        Next


        For Each diag In diagnosticos
            If xaux.ContainsKey(diag.TITULO.ToString()) = False Then
                xaux.Add(diag.TITULO.ToString(), New ArrayList())
                yaux.Add(diag.TITULO.ToString(), New ArrayList())
            End If
            xaux(diag.TITULO.ToString()).Add(diag.XAUX)
            yaux(diag.TITULO.ToString()).Add(diag.YAUX)

        Next

        Select Case model.LIFTMETHOD
            Case 1
                grfDiag.TChart1.Text = "Diagnóstico de BNC (Quick Look)"
                Dim titulos As List(Of String) = xaux.Keys.ToList()



                For i = 0 To titulos.Count - 1

                    Dim x = xaux.Values(i).ToArray(GetType(Double))
                    Dim y = yaux.Values(i).ToArray(GetType(Double))
                    grfDiag.TChart1.Series(i).Title = titulos(i) 'xaux.Keys(i)
                    grfDiag.TChart1.Series(i).Add(x, y)

                Next i

                'grfDiag.TChart1.Series(3).Legend.Visible = False
            Case 2
                grfDiag.TChart1.Text = "Diagnóstico de BEC"

                Dim titulos As List(Of String) = xaux.Keys.ToList()



                For i = 0 To titulos.Count - 1

                    Dim x = xaux.Values(i).ToArray(GetType(Double))
                    Dim y = yaux.Values(i).ToArray(GetType(Double))
                    grfDiag.TChart1.Series(i).Title = titulos(i) 'xaux.Keys(i)
                    grfDiag.TChart1.Series(i).Add(x, y)

                Next i

                grfDiag.TChart1.Series(3).Legend.Visible = False
        End Select

    End Sub
    'Datos Tchart6
    Sub LoadWC(ByVal model As VW_EDO_GENERAL)
        Dim productividad = db.VW_PRODUCTIVIDAD.Where(Function(w) w.IDMODPOZO = model.IDMODPOZO And w.ENDRECORD Is Nothing).OrderBy(Function(o) o.WC_RES).ToList()

        Dim xaux As New Dictionary(Of String, ArrayList)
        Dim yaux As New Dictionary(Of String, ArrayList)

        For Each prod In productividad
            If xaux.ContainsKey(prod.TITULO.ToString()) = False Then
                xaux.Add(prod.TITULO.ToString(), New ArrayList())
                yaux.Add(prod.TITULO.ToString(), New ArrayList())
            End If
            xaux(prod.TITULO.ToString()).Add(prod.WC_RES)
            yaux(prod.TITULO.ToString()).Add(prod.QGI_RES)

        Next

        Select Case model.LIFTMETHOD
            Case 1
                grfWc.TChart1.Text = "Sen. de Corte de Agua-Gasto de Gas de Inyección"
                grfWc.TChart1.Axes.Left.Title.Text = "Gasto de Líquido [STBPD]"
                grfWc.TChart1.Axes.Bottom.Title.Text = "Corte de Agua [%]"
                Dim titulos As List(Of String) = xaux.Keys.ToList()



                For i = 0 To titulos.Count - 1

                    Dim x = xaux.Values(i).ToArray(GetType(Double))
                    Dim y = yaux.Values(i).ToArray(GetType(Double))
                    grfWc.TChart1.Series(i).Title = titulos(i) 'xaux.Keys(i)
                    grfWc.TChart1.Series(i).Add(x, y)

                Next i
            Case 2

                grfWc.TChart1.Text = "Sensibilidad de Corte de Agua-Frecuencia de BEC"
                grfWc.TChart1.Axes.Left.Title.Text = "Gasto de Líquido [STBPD]"
                grfWc.TChart1.Axes.Bottom.Title.Text = "Corte de Agua [%]"


                Dim titulos As List(Of String) = xaux.Keys.ToList()



                For i = 0 To titulos.Count - 1

                    Dim x = xaux.Values(i).ToArray(GetType(Double))
                    Dim y = yaux.Values(i).ToArray(GetType(Double))
                    grfWc.TChart1.Series(i).Title = titulos(i) 'xaux.Keys(i)
                    grfWc.TChart1.Series(i).Add(x, y)

                Next i
        End Select

    End Sub

#End Region
End Class
