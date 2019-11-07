Imports ModeloCI
Imports Prism.Mvvm
Imports Telerik.Windows.Controls
Imports System.Windows.Forms.Integration
Imports System.ServiceModel
Imports System.IO
Public Class ConfigViewModel
    Inherits BindableBase

    Private db As New Entities_ModeloCI()
    'Variables
    Property CreatedOn As DateTime
    Property ModTrayectorias As List(Of MOD_POZO_TRAYEC)

    Property ModTemperaturas As List(Of MOD_POZO_TEMP)

    Property Tuberias As List(Of Tuberia)

    Property MV As Double = 0

    Private ModModel As ModModel



    'Objetos y componentes
    Public usrTrayectoria As New usrTrayectoria()
    Public usrTemperatura As New usrTemperatura()
    Public usrAforo As New usrAforo()
    Public usrPvt As New usrPvt()
    Public Property FormView As ConfigView
    Public Property IdAgujero As String
    Private MaxTp As Double



    Sub New(ByVal IdAgujero As String, ByVal LiftMethod As String, ByVal IdUsuario As String, ByVal Errors As ObjectModel.ObservableCollection(Of String), ByVal WfhTrayectoria As WindowsFormsHost, ByVal WfhTemperatura As WindowsFormsHost, ByVal WfhAforo As WindowsFormsHost, ByVal WfhPvt As WindowsFormsHost, ByVal FechaPrueba As String)
        ModModel = New ModModel(db, IdAgujero, FechaPrueba, IdUsuario, LiftMethod)
        WfhTrayectoria.Child = usrTrayectoria
        WfhTemperatura.Child = usrTemperatura
        WfhAforo.Child = usrAforo
        WfhPvt.Child = usrPvt
        Me.Errors = Errors
        Me.IdAgujero = IdAgujero

        Titulo = "Nueva configuración"



        If ModModel.IdModPozo IsNot Nothing Then

            Titulo = "Última configuración " + ModModel.CreatedOn
            Me.IdModPozo = ModModel.IdModPozo
            Me.IdPozo = ModModel.IdPozo
            Me.Comenta = ModModel.Comenta
            Me.ArchivoPvt = ModModel.ArchivoPvt

            ModTrayectorias = db.MOD_POZO_TRAYEC.Where(Function(w) w.IDMODPOZO = IdModPozo).OrderBy(Function(o) o.PROFUNDIDADMD).ToList()
            ModTemperaturas = db.MOD_POZO_TEMP.Where(Function(w) w.IDMODPOZO = IdModPozo).OrderBy(Function(o) o.TEMPERATURA).ToList()

            Me.LiftMethod = ModModel.LiftMethod




            If ModTrayectorias.Count > 0 Then
                Me.MV = ModTrayectorias(ModTrayectorias.Count - 1).PROFUNDIDADMV
            End If

            If LiftMethod <> ModModel.LiftMethod Then
                Dim q = MsgBox("El Sistema de Producción artificial es diferente.¿Desea cambiarla?", MsgBoxStyle.YesNo)
                If q = MsgBoxResult.Yes Then
                    Me.LiftMethod = LiftMethod
                End If
            End If
            SetData()

        Else
            Me.LiftMethod = LiftMethod
            ModGeneral = New MOD_POZO_GENERAL() With {
                .CO2 = 0,
                .COMPACT = 0,
                .COMPLETION = 0,
                .DIAMVALBNC = 0,
                .DIETZ = 0,
                .DRAINAGE = 0,
                .EMULSION = 0,
                .ENTRY = 0,
                .FLOWTYPE = 0,
                .FLUID = 0,
                .GASCONING = 0,
                .GLRATE = 0,
                .GLRINY = 0,
                .GRAVELPACK = 0,
                .GRAVITY = 0,
                .H2S = 0,
                .HTC = 4,
                .IPRMETHOD = 0,
                .HYDRATE = 0,
                .INFLOWTYPE = 0,
                .IRElK = 0,
                .LIFTYPE = 0,
                .METHOD = 0,
                .MGSKINMETHOD = 0,
                .MGSKINMODEL = 0,
                .N2 = 0,
                .OUTPUTRES = 0,
                .PREDICT = 0,
                .PRES = 0,
                .PTEST = 0,
                .PVTMODEL = 0,
                .QGINYMAX = 0,
                .QGINYMIN = 0,
                .QTEST = 0,
                .RESPERM = 0,
                .RANGESYSTEM = 0,
                .RGATOTALAFORO = 0,
                .SEPARATOR = 0,
                .SKIN = 0,
                .TEMPMODEL = 0,
                .THICKNESS = 0,
                .THPD = 0,
                .THTE = 0,
                .THTD = 0,
                .TOTGOR = 0,
                .TRES = 0,
                .TRPRES = 0,
                .VALVEDEPTH = 0,
                .VISMOD = 0,
                .WATVIS = 0,
                .WBR = 0,
                .WC = 0,
                .WELLTYPE = 0,
                .PI = 0,
                .DATGENDATE = DateTime.Now
            }


        End If
        'COMANDOS
        '***********************************************************************************************************************
        CommandSave = New DelegateCommand(AddressOf OnSave)
        OnLoadAforo = New DelegateCommand(AddressOf LoadAforo)
        CommandUp = New DelegateCommand(AddressOf OnUp)
        CommandDown = New DelegateCommand(AddressOf OnDown)
        CommandResetMec = New DelegateCommand(AddressOf OnLoadMecanico)

        'ESTADO MECANICO OJO HAY QUE REVISAR
        '***********************************************************************************************************************
        Dim ModTuberias = db.MOD_POZO_TUBERIA.Where(Function(w) w.IDAGUJERO = IdAgujero).OrderBy(Function(o) o.MD).ToList()



        If ModTuberias.Count > 0 Then
            LoadMecanico(ModTuberias)
        Else
            LoadMecanico()
        End If

        Bombas = db.VW_BOMBA.OrderBy(Function(o) o.PROSPER).ToList()
        Motores = db.MOTORES.OrderBy(Function(o) o.PROSPER).ToList()





        'AFOROS
        '************************************************************************************************************************
        Aforos = db.VW_AFORO.Where(Function(w) w.ENDRECORD Is Nothing And w.IDPOZO = ModModel.IdPozo).OrderByDescending(Function(o) o.FECHA).ToList()
        Formaciones = db.VW_PVT.Where(Function(w) w.IDAGUJERO = IdAgujero).ToList()
        'Formacion = Nothing 'db.VW_FORMACION.Where(Function(w) w.IDAGUJERO = IdAgujero).SingleOrDefault()








    End Sub

    Public Sub SetData()

        ModGeneral = db.MOD_POZO_GENERAL.Where(Function(w) w.IDMODPOZO = IdModPozo).SingleOrDefault()

        If ModGeneral Is Nothing Then
            ModGeneral = New MOD_POZO_GENERAL()
        End If


        If ModModel.ModPvt IsNot Nothing Then
            Me.Formacion = db.VW_PVT.Where(Function(w) w.IDAGUJERO = ModModel.IdAgujero And w.IDPVTGENERAL = ModModel.ModPvt.IDPVTGENERAL).SingleOrDefault()
        End If

        ModArchivo = ModModel.ArchivoProsper

        'CARGA DE GRAFICAS DE LOS COMPONENTES
        '******************************************************************************************************
        Dim Trayectorias = db.VW_TRAYECTORIA.Where(Function(w) w.IDAGUJERO = ModModel.IdAgujero).ToList()


        If Trayectorias.Count > 0 Then
            For i = 0 To Trayectorias.Count - 1
                usrTrayectoria.TChart1.Series(0).Add(Trayectorias(i).DESPLAZAMIENTO, Trayectorias(i).PROFMV)
                usrTrayectoria.TChart1.Series(2).Add(Trayectorias(i).DESPLAZAMIENTO, Trayectorias(i).DESVIACION) 'Falta desviacion
                usrTrayectoria.TChart1.Series(4).Add(Trayectorias(i).DESPLAZAMIENTO, Trayectorias(i).SEVERIDAD)
            Next i

        End If

        If ModTrayectorias.Count > 0 Then
            For i = 0 To ModTrayectorias.Count - 1
                usrTrayectoria.TChart1.Series(1).Add(ModTrayectorias(i).DESP, ModTrayectorias(i).PROFUNDIDADMV)
                usrTrayectoria.TChart1.Series(3).Add(ModTrayectorias(i).DESP, ModTrayectorias(i).DESV)
                usrTrayectoria.TChart1.Series(5).Add(ModTrayectorias(i).DESP, ModTrayectorias(i).SEVERIDAD)
            Next
        End If


        If ModTemperaturas.Count > 0 Then
            For i = 0 To ModTemperaturas.Count - 1
                usrTemperatura.TChart1.Series(0).Add(ModTemperaturas(i).PROFUNDIDADMD, ModTemperaturas(i).TEMPERATURA)
            Next
        End If
        usrTemperatura.TChart1.Series(0).Legend.Visible = False

    End Sub


    Private _mecanico As MecanicoModel
    Public Property Mecanico As MecanicoModel
        Get
            Return _mecanico
        End Get
        Set(value As MecanicoModel)
            _mecanico = value
            RaisePropertyChanged("Mecanico")
        End Set
    End Property
    Private _errors As ObjectModel.ObservableCollection(Of String)
    Public Property Errors As ObjectModel.ObservableCollection(Of String)
        Get
            Return _errors
        End Get
        Set(value As ObjectModel.ObservableCollection(Of String))
            _errors = value
            RaisePropertyChanged("Errors")
        End Set
    End Property
    Private _infos As List(Of String)
    Public Property Infos As List(Of String)
        Get
            Return _infos
        End Get
        Set(value As List(Of String))
            _infos = value
            RaisePropertyChanged("Infos")
        End Set
    End Property


    Private _on_load_aforo As ICommand
    Public Property OnLoadAforo As ICommand
        Get
            Return _on_load_aforo
        End Get
        Set(value As ICommand)
            _on_load_aforo = value
        End Set
    End Property


    Private _formaciones As List(Of VW_PVT)
    Public Property Formaciones As List(Of VW_PVT)
        Get
            Return _formaciones
        End Get
        Set(value As List(Of VW_PVT))
            _formaciones = value
        End Set
    End Property
    Private _aforos As List(Of VW_AFORO)
    Public Property Aforos As List(Of VW_AFORO)
        Get
            Return _aforos
        End Get
        Set(value As List(Of VW_AFORO))
            _aforos = value


            If Aforos.Count > 0 Then
                'For i = 0 To Aforos.Count - 1
                Dim FECHA = Aforos.Select(Function(X) X.FECHA).ToArray()
                usrAforo.TChart1.Series(0).Add(FECHA, Aforos.Select(Function(X) X.PRODLIQ.GetValueOrDefault()).ToArray())
                usrAforo.TChart1.Series(1).Add(FECHA, Aforos.Select(Function(X) X.PRODGASFORM.GetValueOrDefault()).ToArray())
                usrAforo.TChart1.Series(2).Add(FECHA, Aforos.Select(Function(X) X.VOLGASINY.GetValueOrDefault()).ToArray())
                usrAforo.TChart1.Series(3).Add(FECHA, Aforos.Select(Function(X) X.FRACAGUA.GetValueOrDefault()).ToArray())
                usrAforo.TChart1.Series(4).Add(FECHA, Aforos.Select(Function(X) X.TEMP.GetValueOrDefault()).ToArray())

                usrAforo.MovingAverage1.Series = usrAforo.TChart1.Series(0)
                usrAforo.MovingAverage2.Series = usrAforo.TChart1.Series(1)
                usrAforo.MovingAverage3.Series = usrAforo.TChart1.Series(2)
                usrAforo.MovingAverage4.Series = usrAforo.TChart1.Series(3)
                usrAforo.MovingAverage5.Series = usrAforo.TChart1.Series(4)

                'usrAforo.MovingAverage1.Series.RefreshSeries()
                'Next i
            End If


            'usrAforo.TChart1.Series(0).Add(Aforos(i).FECHA.GetValueOrDefault(), Aforos(i).PRODLIQ)
            'usrAforo.TChart1.Series(1).Add(Aforos(i).FECHA.GetValueOrDefault(), Aforos(i).PRODGASFORM)
            'usrAforo.TChart1.Series(2).Add(Aforos(i).FECHA.GetValueOrDefault(), Aforos(i).VOLGASINY)
            'usrAforo.TChart1.Series(3).Add(Aforos(i).FECHA.GetValueOrDefault(), Aforos(i).FRACAGUA)
            'usrAforo.TChart1.Series(4).Add(Aforos(i).FECHA.GetValueOrDefault(), Aforos(i).TEMP)
            RaisePropertyChanged("Aforos")
        End Set
    End Property
    Private _id_mod_pozo As String
    Public Property IdModPozo() As String
        Get
            Return _id_mod_pozo
        End Get
        Set(value As String)
            _id_mod_pozo = value
            ' LoadCharts(_id_mod_pozo)
            ' Estabilidad.Load(_id_mod_pozo)
            RaisePropertyChanged("IdModPozo")
        End Set
    End Property
    'Modelo BNC
    Private _mod_bnc As MOD_POZO_BNC
    Public Property ModBNC As MOD_POZO_BNC
        Get
            If _mod_bnc Is Nothing Then
                _mod_bnc = New MOD_POZO_BNC()
            End If

            Return _mod_bnc
        End Get
        Set(value As MOD_POZO_BNC)
            _mod_bnc = value
            RaisePropertyChanged("ModBNC")
        End Set
    End Property
    'Modelo BEC
    Private _mod_bec As MOD_POZO_BEC
    Public Property ModBEC() As MOD_POZO_BEC
        Get
            If _mod_bec Is Nothing Then
                _mod_bec = New MOD_POZO_BEC()
            End If
            Return _mod_bec
        End Get
        Set(value As MOD_POZO_BEC)


            _mod_bec = value
            RaisePropertyChanged("ModBEC")
        End Set
    End Property
    'Modelo General
    Private _mod_general As MOD_POZO_GENERAL
    Public Property ModGeneral() As MOD_POZO_GENERAL
        Get
            If _mod_general Is Nothing Then
                _mod_general = New MOD_POZO_GENERAL()
            End If

            Return _mod_general
        End Get
        Set(value As MOD_POZO_GENERAL)
            _mod_general = value

            RaisePropertyChanged("ModGeneral")
        End Set
    End Property

    Private _archivo_pvt As String
    Public Property ArchivoPvt As String
        Get
            Return _archivo_pvt
        End Get
        Set(value As String)
            _archivo_pvt = value

            If _archivo_pvt Is Nothing Then
                EnabledPvt = True
            Else
                EnabledPvt = False
            End If
            RaisePropertyChanged("ArchivoPvt")
        End Set
    End Property

    Private _new_archivo_pvt As String
    Public Property NewArchivoPvt As String
        Get
            If _new_archivo_pvt Is Nothing And ArchivoPvt Is Nothing Then
                EnabledPvt = True
            Else
                EnabledPvt = False
            End If
            Return _new_archivo_pvt
        End Get
        Set(value As String)
            _new_archivo_pvt = value
            RaisePropertyChanged("NewArchivoPvt")
        End Set
    End Property

    Private _mod_archivo As ARCHIVOS_PROSPER
    Public Property ModArchivo As ARCHIVOS_PROSPER
        Get
            Return _mod_archivo
        End Get
        Set(value As ARCHIVOS_PROSPER)
            _mod_archivo = value

            ModModel.ArchivoProsper = _mod_archivo
            RaisePropertyChanged("ModArchivo")
        End Set
    End Property

    Private _titulo As String
    Public Property Titulo As String
        Get
            Return _titulo
        End Get
        Set(value As String)
            _titulo = value
            RaisePropertyChanged("Titulo")
        End Set
    End Property
    Private _lift_method As Integer
    Property LiftMethod As String
        Get
            Return _lift_method
        End Get
        Set(value As String)
            _lift_method = value

            Select Case _lift_method
                Case 1
                    ModBNC = db.MOD_POZO_BNC.Where(Function(w) w.IDMODPOZO = IdModPozo).SingleOrDefault()


                    If ModBNC.IDMODPOZOBNC > 0 Then
                        Method = ModBNC.METHOD.GetValueOrDefault()
                        Entry = ModBNC.ENTRY.GetValueOrDefault()
                    Else
                        ModBNC = New MOD_POZO_BNC() With {
                        .CO2 = 0,
                        .GRAVITY = 0,
                        .GLRINY = 0,
                        .GLRATE = 0,
                        .ENTRY = 0,
                        .DIAMVAL = 0,
                        .H2S = 0,
                        .METHOD = 0,
                        .N2 = 0,
                        .QGIMAX = 0,
                        .QGIMIN = 0,
                        .RANGESYSTEM = 0,
                        .VALVEDEPTH = 0,
                        .TRPRES = 0
                    }
                    End If


                Case 2
                    'FileBEC = ModModel.FilePath
                    ModBEC = db.MOD_POZO_BEC.Where(Function(w) w.IDMODPOZO = IdModPozo).SingleOrDefault()

                    If ModBEC.IDMODPOZOBEC Is Nothing Then
                        ModBEC = New MOD_POZO_BEC() With {
                        .IDMODPOZOBEC = 0,
                        .BOMBA_BEC = 0,
                        .CABLE_BEC = 0,
                        .CORRIENTE_BEC = 0,
                        .DESGASTE_BEC = 0,
                        .EFISEPGAS_BEC = 0,
                        .ETAPAS_BEC = 0,
                        .FRECMAX = 0,
                        .FRECMIN = 0,
                        .LONGCABLE_BEC = 0,
                        .MOTOR_BEC = 0,
                        .ODMAX_BEC = 0,
                        .POTENCIAMOTOR_BEC = 0,
                        .POTENCIA_BEC = 0,
                        .PREDES_BEC = 0,
                        .PRESUC_BEC = 0,
                        .PROF_BEC = 0,
                        .REDUCGAS_BEC = 0,
                        .VOLTSUP_BEC = 0,
                        .FREC_BEC = 0
                    }

                    End If
            End Select

            RaisePropertyChanged("LiftMethod")
        End Set
    End Property
    ''Modelo BNC
    'Private _mod_bnc As MOD_POZO_BNC
    'Public Property ModBNC() As MOD_POZO_BNC
    '    Get
    '        Return _mod_bnc
    '    End Get
    '    Set(value As MOD_POZO_BNC)
    '        _mod_bnc = value
    '    End Set
    'End Property
    ''Modelo BEC
    'Private _mod_bec As MOD_POZO_BEC
    'Public Property ModBEC() As MOD_POZO_BEC
    '    Get
    '        Return _mod_bec
    '    End Get
    '    Set(value As MOD_POZO_BEC)
    '        _mod_bec = value
    '        RaisePropertyChanged("ModBEC")
    '    End Set
    'End Property
    ''Modelo General
    'Private _mod_general As MOD_POZO_GENERAL
    'Public Property ModGeneral() As MOD_POZO_GENERAL
    '    Get


    '        Return _mod_general
    '    End Get
    '    Set(value As MOD_POZO_GENERAL)
    '        _mod_general = value

    '        RaisePropertyChanged("ModGeneral")
    '    End Set
    'End Property



    ''VARIABLES GLOBALES
    'Private _fluid As Double
    'Public Property Fluid() As Double
    '    Get
    '        Return _fluid
    '    End Get
    '    Set(value As Double)
    '        _fluid = value
    '        RaisePropertyChanged("Fluid")
    '    End Set
    'End Property
    'Private _output_res As Double
    'Public Property OutputRes() As Double
    '    Get
    '        Return _output_res
    '    End Get
    '    Set(value As Double)
    '        _output_res = value
    '        RaisePropertyChanged("OutputRes")
    '    End Set
    'End Property
    'Private _pvt_model As Double
    'Public Property PvtModel() As Double
    '    Get
    '        Return _pvt_model
    '    End Get
    '    Set(value As Double)
    '        _pvt_model = value
    '        RaisePropertyChanged("PvtModel")
    '    End Set
    'End Property
    'Private _completion As Double
    'Public Property Completion() As Double
    '    Get
    '        Return _completion
    '    End Get
    '    Set(value As Double)
    '        _completion = value
    '        RaisePropertyChanged("Completion")
    '    End Set
    'End Property
    'Private _separator As Double
    'Public Property Separator() As Double
    '    Get
    '        Return _separator

    '    End Get
    '    Set(value As Double)
    '        _separator = value
    '        RaisePropertyChanged("Separator")
    '    End Set
    'End Property
    'Private _gravel_pack As Double
    'Public Property GravelPack() As Double
    '    Get
    '        Return _gravel_pack
    '    End Get
    '    Set(value As Double)
    '        _gravel_pack = value
    '        RaisePropertyChanged("GravelPack")
    '    End Set
    'End Property
    'Private _emulsion As Double
    'Public Property Emulsion() As Double
    '    Get
    '        Return _emulsion
    '    End Get
    '    Set(value As Double)
    '        _emulsion = value
    '        RaisePropertyChanged("Emulsion")
    '    End Set
    'End Property
    'Private _inflow_type As Double
    'Public Property InflowType() As Double
    '    Get
    '        Return _inflow_type
    '    End Get
    '    Set(value As Double)
    '        _inflow_type = value
    '        RaisePropertyChanged("InflowType")
    '    End Set
    'End Property
    'Private _hydrate As Double
    'Public Property Hydrate() As Double
    '    Get
    '        Return _hydrate
    '    End Get
    '    Set(value As Double)
    '        _hydrate = value
    '        RaisePropertyChanged("Hydrate")
    '    End Set
    'End Property
    'Private _gas_coning As Double
    'Public Property GasConing() As Double
    '    Get
    '        Return _gas_coning
    '    End Get
    '    Set(value As Double)
    '        _gas_coning = value
    '        RaisePropertyChanged("GasConing")
    '    End Set
    'End Property
    'Private _wat_vis As Double
    'Public Property WatVis() As Double
    '    Get
    '        Return _wat_vis
    '    End Get
    '    Set(value As Double)
    '        _wat_vis = value
    '        RaisePropertyChanged("WatVis")
    '    End Set
    'End Property
    'Private _vis_mod As Double
    'Public Property VisMod() As Double
    '    Get
    '        Return _vis_mod
    '    End Get
    '    Set(value As Double)
    '        _vis_mod = value
    '        RaisePropertyChanged("VisMod")
    '    End Set
    'End Property
    'Private _ipr_method As Double
    'Public Property IprMethod() As Double
    '    Get
    '        Return _ipr_method
    '    End Get
    '    Set(value As Double)
    '        _ipr_method = value
    '        RaisePropertyChanged("IprMethod")
    '    End Set
    'End Property
    'Private _flow_type As Double
    'Public Property FlowType() As Double
    '    Get
    '        Return _flow_type
    '    End Get
    '    Set(value As Double)
    '        _flow_type = value
    '        RaisePropertyChanged("FlowType")
    '    End Set
    'End Property
    'Private _compact As Double
    'Public Property Compact() As Double
    '    Get
    '        Return _compact
    '    End Get
    '    Set(value As Double)
    '        _compact = value
    '        RaisePropertyChanged("Compact")
    '    End Set
    'End Property
    'Private _well_type As Double
    'Public Property WellType() As Double
    '    Get
    '        Return _well_type
    '    End Get
    '    Set(value As Double)
    '        _well_type = value
    '        RaisePropertyChanged("WellType")
    '    End Set
    'End Property
    'Private _irelk As Double
    'Public Property Irelk() As Double
    '    Get
    '        Return _irelk
    '    End Get
    '    Set(value As Double)
    '        _irelk = value
    '        RaisePropertyChanged("Irelk")
    '    End Set
    'End Property
    'Private _lift_method As Double
    'Public Property LiftMethod() As Double
    '    Get
    '        Return _lift_method
    '    End Get
    '    Set(value As Double)
    '        _lift_method = value
    '        RaisePropertyChanged("LiftMethod")
    '    End Set
    'End Property
    'Private _mg_skin_method As Double
    'Public Property MgSkinMethod() As Double
    '    Get
    '        Return _mg_skin_method
    '    End Get
    '    Set(value As Double)
    '        _mg_skin_method = value
    '        RaisePropertyChanged("MgSkinMethod")
    '    End Set
    'End Property
    'Private _lift_type As Double
    'Public Property LiftType() As Double
    '    Get
    '        Return _lift_type
    '    End Get
    '    Set(value As Double)
    '        _lift_type = value
    '        RaisePropertyChanged("LiftType")
    '    End Set
    'End Property
    'Private _mg_skin_model As Double
    'Public Property MgSkinModel() As Double
    '    Get
    '        Return _mg_skin_model
    '    End Get
    '    Set(value As Double)
    '        _mg_skin_model = value
    '        RaisePropertyChanged("MgSkinModel")
    '    End Set
    'End Property
    'Private _predict As Double
    'Public Property Predict() As Double
    '    Get
    '        Return _predict
    '    End Get
    '    Set(value As Double)
    '        _predict = value
    '        RaisePropertyChanged("Predict")
    '    End Set
    'End Property
    'Private _temp_model As Double
    'Public Property TempModel() As Double
    '    Get
    '        Return _temp_model
    '    End Get
    '    Set(value As Double)
    '        _temp_model = value
    '        RaisePropertyChanged("TempModel")
    '    End Set
    'End Property


    ''BNC
    'Private _entry As Double
    'Public Property Entry() As Double
    '    Get
    '        Return _entry
    '    End Get
    '    Set(value As Double)
    '        _entry = value
    '        RaisePropertyChanged("Entry")
    '    End Set
    'End Property
    'Private _method As Double
    'Public Property Method() As Double
    '    Get
    '        Return _method
    '    End Get
    '    Set(value As Double)
    '        _method = value
    '        RaisePropertyChanged("Method")
    '    End Set
    'End Property
    'Private _gravity As Double
    'Public Property Gravity() As Double
    '    Get
    '        Return _gravity
    '    End Get
    '    Set(value As Double)
    '        _gravity = value
    '        RaisePropertyChanged("Gravity")
    '    End Set
    'End Property
    'Private _range_system As Double
    'Public Property RangeSystem() As Double
    '    Get
    '        Return _range_system
    '    End Get
    '    Set(value As Double)
    '        _range_system = value
    '        RaisePropertyChanged("RangeSystem")
    '    End Set
    'End Property
    'Private _h2s As Double
    'Public Property H2s() As Double
    '    Get
    '        Return _h2s
    '    End Get
    '    Set(value As Double)
    '        _h2s = value
    '        RaisePropertyChanged("H2s")
    '    End Set
    'End Property
    'Private _co2 As Double
    'Public Property Co2() As Double
    '    Get
    '        Return _co2
    '    End Get
    '    Set(value As Double)
    '        _co2 = value
    '        RaisePropertyChanged("Co2")
    '    End Set
    'End Property
    'Private _n2 As Double
    'Public Property N2() As Double
    '    Get
    '        Return _n2
    '    End Get
    '    Set(value As Double)
    '        _n2 = value
    '        RaisePropertyChanged("N2")
    '    End Set
    'End Property
    'Private _glriny As Double
    'Public Property GlRiny() As Double
    '    Get
    '        Return _glriny
    '    End Get
    '    Set(value As Double)
    '        _glriny = value
    '        RaisePropertyChanged("GlRiny")
    '    End Set
    'End Property
    'Private _glrate As Double
    'Public Property GlRate() As Double
    '    Get
    '        Return _glrate
    '    End Get
    '    Set(value As Double)
    '        _glrate = value
    '        RaisePropertyChanged("GlRate")
    '    End Set
    'End Property
    'Private _valve_depth As Double
    'Public Property ValveDepth() As Double
    '    Get
    '        Return _valve_depth
    '    End Get
    '    Set(value As Double)
    '        _valve_depth = value
    '        RaisePropertyChanged("ValveDepth")
    '    End Set
    'End Property
    'Private _diam_val As Double
    'Public Property DiamVal() As Double
    '    Get
    '        Return _diam_val
    '    End Get
    '    Set(value As Double)
    '        _diam_val = value
    '        RaisePropertyChanged("DiamVal")
    '    End Set
    'End Property
    'Private _qgi_min As Double
    'Public Property QgiMin() As Double
    '    Get
    '        Return _qgi_min
    '    End Get
    '    Set(value As Double)
    '        _qgi_min = value
    '        RaisePropertyChanged("QgiMin")
    '    End Set
    'End Property
    'Private _qgi_max As Double
    'Public Property QgiMax() As Double
    '    Get
    '        Return _qgi_max
    '    End Get
    '    Set(value As Double)
    '        _qgi_max = value
    '        RaisePropertyChanged("QgiMax")
    '    End Set
    'End Property


    'Comandos

    Private _del_mecanico As Boolean
    Public Property DelMecanico As Boolean
        Get
            Return _del_mecanico
        End Get
        Set(value As Boolean)
            _del_mecanico = value
            RaisePropertyChanged("DelMecanico")
        End Set
    End Property

    Private _del_trayectoria As Boolean
    Public Property DelTrayectoria As Boolean
        Get
            Return _del_trayectoria
        End Get
        Set(value As Boolean)
            _del_trayectoria = value
            RaisePropertyChanged("DelTrayectoria")
        End Set
    End Property

    Private _del_temperatura As Boolean
    Public Property DelTemperatura As Boolean
        Get
            Return _del_temperatura
        End Get
        Set(value As Boolean)
            _del_temperatura = value
            RaisePropertyChanged("DelTemperatura")
        End Set
    End Property

    Private _formacion As VW_PVT
    Public Property Formacion As VW_PVT
        Get
            Return _formacion
        End Get
        Set(value As VW_PVT)
            _formacion = value

            If _formacion IsNot Nothing Then
                Pvts = db.VW_PVT_GRAFICA.Where(Function(w) w.IDPVTGENERAL = _formacion.IDPVTGENERAL And w.TEMPERATURA = _formacion.TEMP).OrderBy(Function(o) o.PPRUEBA).ToList()
                ModModel.IdPvt = _formacion.IDPVTGENERAL
                ' ModGeneral.IDPVT = _formacion.IDPVTGENERAL

            Else

            End If

            RaisePropertyChanged("Formacion")
        End Set
    End Property
    Private _pvts As List(Of VW_PVT_GRAFICA)
    Public Property Pvts As List(Of VW_PVT_GRAFICA)
        Get
            Return _pvts
        End Get
        Set(value As List(Of VW_PVT_GRAFICA))
            _pvts = value

            If Pvts IsNot Nothing Then

                For i = 0 To Pvts.Count - 1
                    usrPvt.TChart1.Series(0).Add(Pvts(i).PPRUEBA, Pvts(i).PB)
                    usrPvt.TChart1.Series(1).Add(Pvts(i).PPRUEBA, Pvts(i).RS)
                    usrPvt.TChart1.Series(2).Add(Pvts(i).PPRUEBA, Pvts(i).BO)
                    usrPvt.TChart1.Series(3).Add(Pvts(i).PPRUEBA, Pvts(i).VISCOSIDADACEITE)
                Next
            End If
            RaisePropertyChanged("Pvts")
        End Set
    End Property

    Private _messages_pvt As ModelosEstabilidad.FlashData
    Public Property MessagesPVT As ModelosEstabilidad.FlashData
        Get
            Return _messages_pvt
        End Get
        Set(value As ModelosEstabilidad.FlashData)
            _messages_pvt = value
            RaisePropertyChanged("MessagesPVT")
        End Set
    End Property

    Private _mod_mecanicos As ObjectModel.ObservableCollection(Of MecanicoModel)
    Public Property ModMecanicos As ObjectModel.ObservableCollection(Of MecanicoModel)
        Get
            Return _mod_mecanicos
        End Get
        Set(value As ObjectModel.ObservableCollection(Of MecanicoModel))
            _mod_mecanicos = value


            RaisePropertyChanged("ModMecanicos")
        End Set
    End Property

    Private _bombas As List(Of VW_BOMBA)
    Public Property Bombas As List(Of VW_BOMBA)
        Get
            Return _bombas
        End Get
        Set(value As List(Of VW_BOMBA))
            _bombas = value
            RaisePropertyChanged("Bombas")
        End Set
    End Property
    Private _motores As List(Of MOTORES)
    Public Property Motores As List(Of MOTORES)
        Get
            Return _motores
        End Get
        Set(value As List(Of MOTORES))
            _motores = value
            RaisePropertyChanged("Motores")
        End Set
    End Property

#Region "Deshabilitadores"
    Private _enabled_pvt As Boolean
    Public Property EnabledPvt As Boolean
        Get
            Return _enabled_pvt
        End Get
        Set(value As Boolean)
            _enabled_pvt = value
            RaisePropertyChanged("EnabledPvt")
        End Set
    End Property
#End Region

#Region "Comandos"
    Public Property CommandResetMec As ICommand
    Public Property CommandUp As ICommand
    Public Property CommandDown As ICommand
    Public Property CommandSave As ICommand
#End Region

#Region "Variables"

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

    Private _fecha_prueba As String
    Public Property FechaPrueba() As String
        Get
            Return _fecha_prueba
        End Get
        Set(value As String)
            _fecha_prueba = value
        End Set
    End Property


    Private _list_mecanicos As List(Of VW_EDO_MECANICO)


    Private _pres As Double
    Public Property Pres As Double
        Get
            Return _pres
        End Get
        Set(value As Double)
            _pres = value

            RaisePropertyChanged("Pres")

        End Set
    End Property
    Private _tres As Double
    Public Property Tres As Double
        Get
            Return _tres
        End Get
        Set(value As Double)
            _tres = value
            RaisePropertyChanged("Tres")

        End Set
    End Property
    'Depreciado temporalmente, se encuentra en ModGeneral.Wc
    Private _wc As Double
    Public Property Wc As Double
        Get
            Return _wc
        End Get
        Set(value As Double)
            _wc = value
            RaisePropertyChanged("Wc")

        End Set
    End Property
    Private _totgor As Double
    Public Property Totgor As Double
        Get
            Return _totgor
        End Get
        Set(value As Double)
            _totgor = value
            RaisePropertyChanged("Totgor")

        End Set
    End Property
    Private _qtest As Double
    Public Property Qtest As Double
        Get
            Return _qtest
        End Get
        Set(value As Double)
            _qtest = value
            RaisePropertyChanged("Qtest")

        End Set
    End Property
    Private _ptest As Double
    Public Property Ptest As Double
        Get
            Return _ptest
        End Get
        Set(value As Double)
            _ptest = value
            RaisePropertyChanged("Ptest")

        End Set
    End Property
    Private _resperm As Double
    Public Property Resperm As Double
        Get
            Return _resperm
        End Get
        Set(value As Double)
            _resperm = value
            RaisePropertyChanged("Resperm")

        End Set
    End Property
    Private _thickness As Double
    Public Property Thickness As Double
        Get
            Return _thickness
        End Get
        Set(value As Double)
            _thickness = value
            RaisePropertyChanged("Thickness")

        End Set
    End Property
    Private _drainage As Double
    Public Property Drainage As Double
        Get
            Return _drainage
        End Get
        Set(value As Double)
            _drainage = value
            RaisePropertyChanged("Drainage")
        End Set
    End Property
    Private _dietz As Double
    Public Property Dietz As Double
        Get
            Return _dietz
        End Get
        Set(value As Double)
            _dietz = value
            RaisePropertyChanged("Dietz")
        End Set
    End Property
    Private _wbr As Double
    Public Property Wbr As Double
        Get
            Return _wbr
        End Get
        Set(value As Double)
            _wbr = value
            RaisePropertyChanged("Wbr")
        End Set
    End Property
    Private _skin As Double
    Public Property Skin As Double
        Get
            Return _skin
        End Get
        Set(value As Double)
            _skin = value
            RaisePropertyChanged("Skin")
        End Set
    End Property
    Private _htc As Double
    Public Property Htc As Double
        Get
            Return _htc
        End Get
        Set(value As Double)
            _htc = value
            RaisePropertyChanged("Htc")
        End Set
    End Property
    Private _thpd As Double
    Public Property Thpd As Double
        Get
            Return _thpd
        End Get
        Set(value As Double)
            _thpd = value
            RaisePropertyChanged("Thpd")
        End Set
    End Property
    Private _thtd As Double
    Public Property Thtd As Double
        Get
            Return _thtd
        End Get
        Set(value As Double)
            _thtd = value
            RaisePropertyChanged("Thtd")
        End Set
    End Property
    Private _trpres As Double
    Public Property Trpres As Double
        Get
            Return _trpres
        End Get
        Set(value As Double)
            _trpres = value
            RaisePropertyChanged("Trpres")
        End Set
    End Property
    Private _rgatotalaforo As Double
    Public Property RgaTotalAforo As Double
        Get
            Return _rgatotalaforo
        End Get
        Set(value As Double)
            _rgatotalaforo = value
            RaisePropertyChanged("RgaTotalAforo")
        End Set
    End Property


    Private _comenta As String
    Public Property Comenta As String
        Get
            Return _comenta
        End Get
        Set(value As String)
            _comenta = value
            RaisePropertyChanged("Comenta")
        End Set
    End Property
    Private _fluid As Double
    Public Property Fluid() As Double
        Get
            Return _fluid
        End Get
        Set(value As Double)
            _fluid = value
            RaisePropertyChanged("Fluid")
        End Set
    End Property
    Private _output_res As Double
    Public Property OutputRes() As Double
        Get
            Return _output_res
        End Get
        Set(value As Double)
            _output_res = value
            RaisePropertyChanged("OutputRes")
        End Set
    End Property
    Private _pvt_model As Double
    Public Property PvtModel() As Double
        Get
            Return _pvt_model
        End Get
        Set(value As Double)
            _pvt_model = value
            RaisePropertyChanged("PvtModel")
        End Set
    End Property
    Private _completion As Double
    Public Property Completion() As Double
        Get
            Return _completion
        End Get
        Set(value As Double)
            _completion = value
            RaisePropertyChanged("Completion")
        End Set
    End Property
    Private _separator As Double
    Public Property Separator() As Double
        Get
            Return _separator

        End Get
        Set(value As Double)
            _separator = value
            RaisePropertyChanged("Separator")
        End Set
    End Property
    Private _gravel_pack As Double
    Public Property GravelPack() As Double
        Get
            Return _gravel_pack
        End Get
        Set(value As Double)
            _gravel_pack = value
            RaisePropertyChanged("GravelPack")
        End Set
    End Property
    Private _emulsion As Double
    Public Property Emulsion() As Double
        Get
            Return _emulsion
        End Get
        Set(value As Double)
            _emulsion = value
            RaisePropertyChanged("Emulsion")
        End Set
    End Property
    Private _inflow_type As Double
    Public Property InflowType() As Double
        Get
            Return _inflow_type
        End Get
        Set(value As Double)
            _inflow_type = value
            RaisePropertyChanged("InflowType")
        End Set
    End Property
    Private _hydrate As Double
    Public Property Hydrate() As Double
        Get
            Return _hydrate
        End Get
        Set(value As Double)
            _hydrate = value
            RaisePropertyChanged("Hydrate")
        End Set
    End Property
    Private _gas_coning As Double
    Public Property GasConing() As Double
        Get
            Return _gas_coning
        End Get
        Set(value As Double)
            _gas_coning = value
            RaisePropertyChanged("GasConing")
        End Set
    End Property
    Private _wat_vis As Double
    Public Property WatVis() As Double
        Get
            Return _wat_vis
        End Get
        Set(value As Double)
            _wat_vis = value
            RaisePropertyChanged("WatVis")
        End Set
    End Property
    Private _vis_mod As Double
    Public Property VisMod() As Double
        Get
            Return _vis_mod
        End Get
        Set(value As Double)
            _vis_mod = value
            RaisePropertyChanged("VisMod")
        End Set
    End Property
    Private _ipr_method As Double
    Public Property IprMethod As Double
        Get
            Return _ipr_method
        End Get
        Set(value As Double)
            _ipr_method = value
            RaisePropertyChanged("IprMethod")
        End Set
    End Property
    Private _flow_type As Double
    Public Property FlowType() As Double
        Get
            Return _flow_type
        End Get
        Set(value As Double)
            _flow_type = value
            RaisePropertyChanged("FlowType")
        End Set
    End Property
    Private _compact As Double
    Public Property Compact() As Double
        Get
            Return _compact
        End Get
        Set(value As Double)
            _compact = value
            RaisePropertyChanged("Compact")
        End Set
    End Property
    Private _well_type As Double
    Public Property WellType() As Double
        Get
            Return _well_type
        End Get
        Set(value As Double)
            _well_type = value
            RaisePropertyChanged("WellType")
        End Set
    End Property
    Private _irelk As Double
    Public Property Irelk() As Double
        Get
            Return _irelk
        End Get
        Set(value As Double)
            _irelk = value
            RaisePropertyChanged("Irelk")
        End Set
    End Property
    'Private _lift_method As Double
    'Public Property LiftMethod() As Double
    '    Get
    '        Return _lift_method
    '    End Get
    '    Set(value As Double)
    '        _lift_method = value
    '        RaisePropertyChanged("LiftMethod")
    '    End Set
    'End Property
    Private _mg_skin_method As Double
    Public Property MgSkinMethod() As Double
        Get
            Return _mg_skin_method
        End Get
        Set(value As Double)
            _mg_skin_method = value
            RaisePropertyChanged("MgSkinMethod")
        End Set
    End Property
    Private _lift_type As Double
    Public Property LiftType() As Double
        Get
            Return _lift_type
        End Get
        Set(value As Double)
            _lift_type = value
            RaisePropertyChanged("LiftType")
        End Set
    End Property
    Private _mg_skin_model As Double
    Public Property MgSkinModel() As Double
        Get
            Return _mg_skin_model
        End Get
        Set(value As Double)
            _mg_skin_model = value
            RaisePropertyChanged("MgSkinModel")
        End Set
    End Property
    Private _predict As Double
    Public Property Predict() As Double
        Get
            Return _predict
        End Get
        Set(value As Double)
            _predict = value
            RaisePropertyChanged("Predict")
        End Set
    End Property
    Private _temp_model As Double
    Public Property TempModel() As Double
        Get
            Return _temp_model
        End Get
        Set(value As Double)
            _temp_model = value
            RaisePropertyChanged("TempModel")
        End Set
    End Property
    Private _datgendate As DateTime
    Public Property Datgendate() As DateTime
        Get
            Return _datgendate
        End Get
        Set(value As DateTime)
            _datgendate = value
            RaisePropertyChanged("Datgendate")
        End Set
    End Property


    'BNC
    Private _entry As Double
    Public Property Entry() As Double
        Get
            Return _entry
        End Get
        Set(value As Double)
            _entry = value
            RaisePropertyChanged("Entry")
        End Set
    End Property
    Private _method As Double
    Public Property Method() As Double
        Get
            Return _method
        End Get
        Set(value As Double)
            _method = value
            RaisePropertyChanged("Method")
        End Set
    End Property
    Private _gravity As Double
    Public Property Gravity() As Double
        Get
            Return _gravity
        End Get
        Set(value As Double)
            _gravity = value
            RaisePropertyChanged("Gravity")
        End Set
    End Property
    Private _range_system As Double
    Public Property RangeSystem() As Double
        Get
            Return _range_system
        End Get
        Set(value As Double)
            _range_system = value
            RaisePropertyChanged("RangeSystem")
        End Set
    End Property
    Private _h2s As Double
    Public Property H2s() As Double
        Get
            Return _h2s
        End Get
        Set(value As Double)
            _h2s = value
            RaisePropertyChanged("H2s")
        End Set
    End Property
    Private _co2 As Double
    Public Property Co2() As Double
        Get
            Return _co2
        End Get
        Set(value As Double)
            _co2 = value
            RaisePropertyChanged("Co2")
        End Set
    End Property
    Private _n2 As Double
    Public Property N2() As Double
        Get
            Return _n2
        End Get
        Set(value As Double)
            _n2 = value
            RaisePropertyChanged("N2")
        End Set
    End Property
    Private _glriny As Double
    Public Property GlRiny() As Double
        Get
            Return _glriny
        End Get
        Set(value As Double)
            _glriny = value
            RaisePropertyChanged("GlRiny")
        End Set
    End Property
    Private _glrate As Double
    Public Property GlRate() As Double
        Get
            Return _glrate
        End Get
        Set(value As Double)
            _glrate = value
            RaisePropertyChanged("GlRate")
        End Set
    End Property
    Private _valve_depth As Double
    Public Property ValveDepth() As Double
        Get
            Return _valve_depth
        End Get
        Set(value As Double)
            _valve_depth = value
            RaisePropertyChanged("ValveDepth")
        End Set
    End Property
    Private _diam_val As Double
    Public Property DiamVal() As Double
        Get
            Return _diam_val
        End Get
        Set(value As Double)
            _diam_val = value
            RaisePropertyChanged("DiamVal")
        End Set
    End Property
    Private _qgi_min As Double
    Public Property QgiMin() As Double
        Get
            Return _qgi_min
        End Get
        Set(value As Double)
            _qgi_min = value
            RaisePropertyChanged("QgiMin")
        End Set
    End Property
    Private _qgi_max As Double
    Public Property QgiMax() As Double
        Get
            Return _qgi_max
        End Get
        Set(value As Double)
            _qgi_max = value
            RaisePropertyChanged("QgiMax")
        End Set
    End Property
    Private _thte As Double
    Public Property Thte() As Double
        Get
            Return _thte
        End Get
        Set(value As Double)
            _thte = value
            RaisePropertyChanged("Thte")
        End Set
    End Property


#End Region

    Private Sub OnUp(ByVal sender As Object)
        Dim Index As Integer = ModMecanicos.IndexOf(Mecanico)

        If Index > 0 Then
            Dim Tmp = ModMecanicos(Index - 1)
            ModMecanicos(Index - 1) = Mecanico
            ModMecanicos(Index) = Tmp

            Mecanico = ModMecanicos(Index - 1)

        End If


        ' ModMecanicos = ObjectModel.ObservableCollection(Of MecanicoModel)(ModMecanicos.OrderBy(Function(o) o.Orden).ToList())

    End Sub
    Private Sub OnDown(ByVal sender As Object)
        Dim Index As Integer = ModMecanicos.IndexOf(Mecanico)

        If ModMecanicos.Count - 1 > Index Then
            Dim Tmp = ModMecanicos(Index + 1)
            ModMecanicos(Index + 1) = Mecanico
            ModMecanicos(Index) = Tmp

            Mecanico = ModMecanicos(Index + 1)

        End If
    End Sub

    Private Sub OnSave()

        Try
            If Valid() = False Then
                Exit Sub
            End If
            'Revisamos nuevamente que el modelo no haya cambiado a último momento


            Dim VwModelo = ModModel.GetModelo()
            Dim MaxMd As Double = 0


            If VwModelo IsNot Nothing Then

                If VwModelo.ESTATUS = 1 Then

                    MsgBox("La configuración ha sido programada por el Administrador, una vez ejecutado podra seguir actualizando")
                    Exit Sub
                End If

                If VwModelo.ESTATUS = 2 Then
                    Throw New Exception("Configuración bloqueada temporalmente")
                End If
            End If


            ModModel.DelMecas = DelMecanico
            ModModel.DelTrays = DelTrayectoria
            ModModel.DelTemps = DelTemperatura

            'If ModGeneral.THTE = 0 And DelTemperatura Then
            '    Dim result = MessageBox.Show("Actualmente ¿Desea cargar los datos?", MessageBoxButton.YesNoCancel)

            '    If result.Yes = MessageBoxResult.Yes Then

            '    End If
            'End If

            ModGeneral.LIFTMETHOD = Me.LiftMethod
            ModModel.ModGeneral = ModGeneral
            ModModel.NewArchivoPvt = NewArchivoPvt
            ModModel.ArchivoPvt = ArchivoPvt
            ' ModModel.Formacion = Formacion




            Select Case LiftMethod
                Case 1
                    ModModel.ModBNC = ModBNC
                Case 2
                    'ModModel.FilePath = FileBEC
                    ModModel.ModBEC = ModBEC
            End Select

            Dim result = ModModel.Save(Comenta)

            'Guardado de componentes
            If result Then

                ModModel.Mecanicos = New List(Of MOD_POZO_TUBERIA)

                For i = 0 To ModMecanicos.Count - 1
                    ModModel.Mecanicos.Add(ModMecanicos(i).ModPozoTuberia)
                Next


                If ModModel.SaveMecanico() > 0 Then
                    MaxMd = db.VW_EDO_MECANICO.Where(Function(w) w.IDAGUJERO = ModModel.IdAgujero).Max(Function(m) m.MD)

                    If MaxMd > 0 Then
                        Dim puntos = ModModel.SaveTrayectorias(MaxMd)
                        ModModel.SaveTemperatura(puntos)

                    End If

                End If
            End If
            'Termina componentes

            IdModPozo = ModModel.IdModPozo


            MsgBox("Configuración guardada")
            FormView.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try



    End Sub
    Public Sub LoadDeclinacion(ByVal Fecha As DateTime)
        'Consultamos la informacion de presion
        Try
            Dim SCDeclinacion As New SVDeclinacion.Service1Client()
            Dim EndPointDeclina As EndpointAddress = New EndpointAddress(Settings.GetBy("point_declina"))

            SCDeclinacion.Endpoint.Address = EndPointDeclina

            'Dim RPresion = SCDeclinacion.GethastPreTemModelo(Fecha, ModModel.IdAgujero, MV)


            'ModGeneral.THTE = RPresion("TemCabeza_Modelo")
            'ModGeneral.TRES = RPresion("temNMD_modelo")
            'ModGeneral.PRES = RPresion("presionNMD_modelo")


            Dim factory = New ChannelFactory(Of Interfaces.IDeclinacion)(New BasicHttpBinding(), EndPointDeclina)
            Dim server As Interfaces.IDeclinacion = factory.CreateChannel()

            Dim RPresion = server.GethastPreTemModelo(Fecha, ModModel.IdAgujero, MV)

            ModGeneral.THTE = RPresion("TemCabeza_Modelo")
            ModGeneral.TRES = RPresion("temNMD_modelo")
            ModGeneral.PRES = RPresion("presionNMD_modelo")

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub
    Public Sub LoadAforo(ByVal e As Object)

        Dim aforo = CType(e.Source.SelectedItem, VW_AFORO)

        If aforo Is Nothing Then
            Exit Sub
        End If

        Dim result = MessageBox.Show("¿Desea cargar los datos del aforo con fecha " + aforo.FECHA + " a la configuración?", "Confirmar datos", MessageBoxButton.YesNoCancel)

        Try
            If result = MessageBoxResult.Yes Then
                ' ModGeneral.IDAFORO = aforo.IDAFORO
                ModGeneral.WC = aforo.FRACAGUA 'Wc = aforo.FRACAGUA
                ModGeneral.QTEST = aforo.PRODLIQ 'Qtest = aforo.PRODLIQ
                ModGeneral.RGATOTALAFORO = (aforo.PRODGASFORM * 1000000) / (5.615 * aforo.PRODLIQ * (100 - ModGeneral.WC) / 100) 'RgaTotalAforo = aforo.PRODGASFORM
                ModGeneral.TOTGOR = (aforo.PRODGASFORM * 1000000) / (5.615 * aforo.PRODLIQ * (100 - ModGeneral.WC) / 100)
                ModGeneral.GLRINY = aforo.VOLGASINY 'GlRiny = aforo.VOLGASINY | Volumen de Gas Inyeccion
                ModGeneral.THPD = aforo.PTP1 'Thpd = aforo.PTP1
                ModBNC.TRPRES = aforo.PTR1 'Trpres = aforo.PTR1

                ModGeneral.THTD = IIf(aforo.TEMP > 0, aforo.TEMP, ModGeneral.THTD) 'Thtd = aforo.TEMP

                LoadDeclinacion(aforo.FECHA)
                ModGeneral = ModGeneral


            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try



    End Sub


    Private Function Valid() As Boolean

        If ModBNC.QGIMIN > 0 AndAlso ModBNC.QGIMIN > ModBNC.QGIMAX Then
            MsgBox("BNC: Qgi máximo debe ser mayor que Qgi mínimo", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        If Formacion Is Nothing Then
            MsgBox("PVT: Selecciona el registro de PVT para continuar y guardar los datos", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        Return True
    End Function
    Private Sub OnLoadMecanico()

        Dim result = MessageBox.Show("Los datos del estado mecánico para este modelo se van a eliminar y reiniciar con otros valores nuevos.¿Desea continuar con esta acción? ", "Campos inteligentes", MessageBoxButton.YesNo)

        If result = MessageBoxResult.Yes Then
            LoadMecanico()
        End If

    End Sub
    Private Sub LoadMecanico(ByVal ModTuberias As List(Of MOD_POZO_TUBERIA))
        Dim MecanicoModel As New MecanicoModel(ModTuberias)
        ModMecanicos = New ObjectModel.ObservableCollection(Of MecanicoModel)(MecanicoModel.GetList().OrderBy(Function(o) o.Orden))
        MaxTp = MecanicoModel.GetMaxTp()


        If ModBEC.PROF_BEC = 0 And MaxTp > 0 Then
            ModBEC.PROF_BEC = MaxTp
            ModBEC.LONGCABLE_BEC = ModBEC.PROF_BEC
        End If
    End Sub
    ''' <summary>
    ''' Recarga el estado mecanico nuevamente con los datos de TPs y TRs
    ''' </summary>
    Private Sub LoadMecanico()
        Try
            Dim Mecanico As New Mecanico(db.VW_TR.Where(Function(w) w.IDAGUJERO = IdAgujero).OrderByDescending(Function(o) o.PROFUNDIDADINICIO).ToList(), db.VW_TP.Where(Function(w) w.IDAGUJERO = IdAgujero).OrderByDescending(Function(w) w.PROFUNDIDAD).ToList(), True)

            Tuberias = Mecanico.GetTuberias()
            If ModMecanicos IsNot Nothing Then
                ModMecanicos.Clear()
            End If

            Dim MecanicoModel As New MecanicoModel(Tuberias)
            ModMecanicos = New ObjectModel.ObservableCollection(Of MecanicoModel)(MecanicoModel.GetList().OrderBy(Function(o) o.Orden))
            MaxTp = MecanicoModel.GetMaxTp()

            If ModBEC.PROF_BEC = 0 And MaxTp > 0 Then
                ModBEC.PROF_BEC = MaxTp
                ModBEC.LONGCABLE_BEC = ModBEC.PROF_BEC
            End If

        Catch ex As Exception
            Errors.Add(ex.Message)
        End Try

    End Sub


End Class
