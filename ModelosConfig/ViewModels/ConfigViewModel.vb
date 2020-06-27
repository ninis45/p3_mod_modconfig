Imports ModeloCI
Imports Prism.Mvvm
Imports Telerik.Windows.Controls
Imports System.Windows.Forms.Integration
Imports System.ServiceModel
Imports ModelosConfig.Generales
Imports System.IO
Public Class ConfigViewModel
    Inherits BindableBase

    Private db As New Entities_ModeloCI()
    'Variables
    Property CreatedOn As DateTime




    Property Tuberias As List(Of Tuberia)

    'Property MV As Double = 0

    Private ModModel As ModModel



    'Objetos y componentes
    Public usrTrayectoria As New usrTrayectoria()
    Public usrTemperatura As New usrTemperatura()
    Public usrAforo As New usrAforo()
    Public usrPvt As New usrPvt()
    Public Property FormView As ConfigView
    Public Property IdAgujero As String
    Public Property IsSaved As Boolean

    Private MaxTp As Double
    Private MaxMd As Double






    Sub New(ByVal IdAgujero As String, ByVal IdModPozo As String, ByVal WfhTrayectoria As WindowsFormsHost, ByVal WfhTemperatura As WindowsFormsHost, ByVal WfhAforo As WindowsFormsHost, ByVal WfhPvt As WindowsFormsHost, ByVal WfhMec As WindowsFormsHost)
        ModModel = New ModModel(IdAgujero, IdModPozo)
        WfhTrayectoria.Child = usrTrayectoria
        WfhTemperatura.Child = usrTemperatura
        WfhAforo.Child = usrAforo
        WfhPvt.Child = usrPvt

        Me.IdAgujero = IdAgujero
        Titulo = "Detalles " + ModModel.VwGeneral.NOMBRE
        'If IsReadOnly = True Then
        '    Titulo = "Detalles " + ModModel.VwGeneral.NOMBRE
        'Else
        '    Titulo = "Copiando configuracion " + ModModel.VwGeneral.NOMBRE
        'End If


        Warnings = New ObjectModel.ObservableCollection(Of String)
        Errors = New ObjectModel.ObservableCollection(Of String)


        If ModModel.ModTuberias.Count > 0 Then
            LoadMecanico(ModModel.ModTuberias)
        End If
        Trayectorias = New List(Of VW_TRAYECTORIA)() 'db.VW_TRAYECTORIA.Where(Function(w) w.IDAGUJERO = ModModel.IdAgujero).OrderBy(Function(o) o.PROFUNDIDADMD).ToList()

        If ModModel.IdModPozo IsNot Nothing Then
            Me.IdModPozo = ModModel.VwGeneral.IDMODPOZO
            Me.LiftMethod = ModModel.VwGeneral.LIFTMETHOD

            Me.EnabledEquip = ModModel.Equipment


            ModTrayectorias = New ObjectModel.ObservableCollection(Of MOD_POZO_TRAYEC)(ModModel.ModTrayectorias) ' db.MOD_POZO_TRAYEC.Where(Function(w) w.IDMODPOZO = IdModPozo).OrderBy(Function(o) o.PROFUNDIDADMD).ToList()
            ModTemperaturas = New ObjectModel.ObservableCollection(Of MOD_POZO_TEMP)(ModModel.ModTemperaturas)
            LoadMecanico(ModModel.ModTuberias)
            SetData()

        Else
            Throw New Exception("No hay modelo registrado")

        End If



        'Listado para los COMBOS
        '========================================================================================================================
        Bombas = db.VW_BOMBA.OrderBy(Function(o) o.PROSPER).ToList()
        Motores = db.MOTORES.OrderBy(Function(o) o.PROSPER).ToList()
        'AFOROS
        '************************************************************************************************************************
        Aforos = db.VW_AFORO.Where(Function(w) w.ENDRECORD Is Nothing And w.IDPOZO = ModModel.IdPozo).OrderByDescending(Function(o) o.FECHA).ToList()
        Formaciones = db.VW_PVT.Where(Function(w) w.IDAGUJERO = IdAgujero).ToList()


        'COMANDOS
        '***********************************************************************************************************************
        CommandSave = New DelegateCommand(AddressOf OnSave)
        OnLoadAforo = New DelegateCommand(AddressOf LoadAforo)
        CommandUp = New DelegateCommand(AddressOf OnUp)
        CommandDown = New DelegateCommand(AddressOf OnDown)
        CommandResetMec = New DelegateCommand(AddressOf OnLoadMecanico)
        CommandResetTray = New DelegateCommand(AddressOf OnLoadTrayectoria)


        VisibleSave = False


        db.Entry(ModGeneral).State = System.Data.Entity.EntityState.Detached
        If ModBNC IsNot Nothing Then db.Entry(ModBNC).State = System.Data.Entity.EntityState.Detached
        If ModBEC IsNot Nothing Then db.Entry(ModBEC).State = System.Data.Entity.EntityState.Detached

        'EnabledPvt = False

    End Sub

    Sub New(ByVal IdAgujero As String, ByVal LiftMethod As String, ByVal IdUsuario As String, ByVal WfhTrayectoria As WindowsFormsHost, ByVal WfhTemperatura As WindowsFormsHost, ByVal WfhAforo As WindowsFormsHost, ByVal WfhPvt As WindowsFormsHost, ByVal WfhMec As WindowsFormsHost, ByVal FechaPrueba As String)
        ModModel = New ModModel(db, IdAgujero, FechaPrueba, IdUsuario, LiftMethod)
        WfhTrayectoria.Child = usrTrayectoria
        WfhTemperatura.Child = usrTemperatura
        WfhAforo.Child = usrAforo
        WfhPvt.Child = usrPvt
        Me.IdAgujero = IdAgujero
        Me.FechaPrueba = FechaPrueba
        Me.LiftMethod = ModModel.LiftMethod
        Titulo = "Nueva configuración"
        Warnings = New ObjectModel.ObservableCollection(Of String)
        Errors = New ObjectModel.ObservableCollection(Of String)

        'EQUIPAMIENTO
        '***********************************************************************************************************************

        Tuberias = ModModel.Tuberias 'Mecanico.GetTuberias() 17 feb 2019
        If ModModel.ModTuberias.Count > 0 Then
            LoadMecanico(ModModel.ModTuberias)
        Else
            LoadMecanico()
        End If

        Trayectorias = db.VW_TRAYECTORIA.Where(Function(w) w.IDAGUJERO = ModModel.IdAgujero).OrderBy(Function(o) o.PROFUNDIDADMD).ToList()




        If ModModel.IdModPozo IsNot Nothing Then


            Me.IdModPozo = ModModel.IdModPozo
            Me.IdPozo = ModModel.IdPozo
            Me.Comenta = ModModel.Comenta
            Me.ModArchivo = ModModel.ArchivoProsper
            Me.EnabledEquip = ModModel.Equipment
            Me.LiftMethod = ModModel.LiftMethod










            'If ModTrayectorias.Count > 0 Then
            '    Me.MV = ModTrayectorias(ModTrayectorias.Count - 1).PROFUNDIDADMV
            'End If

            If ModModel.VwGeneral.ESTATUS.GetValueOrDefault() <> 3 AndAlso MessageBox.Show("Una forma ha sido inicializada, desea continuar modificando?", "Campos inteligentes", MessageBoxButton.YesNo) = MessageBoxResult.Yes Then
                Titulo = "Última modificacion " + ModModel.CreatedOn
                SetData()

            Else
                ' Titulo = "Nueva configuración"
                Me.IdModPozo = Nothing
                ResetData()
            End If


        Else

            'Me.LiftMethod = LiftMethod
            Me.EnabledPvt = True
            ResetData()



        End If

        'ModModel.LiftMethod

        If ModTrayectorias.Count = 0 Then
            LoadTrayectoria()
        End If

        'COMANDOS
        '***********************************************************************************************************************
        CommandSave = New DelegateCommand(AddressOf OnSave)
        OnLoadAforo = New DelegateCommand(AddressOf LoadAforo)
        CommandUp = New DelegateCommand(AddressOf OnUp)
        CommandDown = New DelegateCommand(AddressOf OnDown)
        CommandResetMec = New DelegateCommand(AddressOf OnLoadMecanico)
        CommandResetTray = New DelegateCommand(AddressOf OnLoadTrayectoria)








        'Listado para los COMBOS
        '========================================================================================================================
        Bombas = db.VW_BOMBA.OrderBy(Function(o) o.PROSPER).ToList()
        Motores = db.MOTORES.OrderBy(Function(o) o.PROSPER).ToList()
        'AFOROS
        '************************************************************************************************************************
        Aforos = db.VW_AFORO.Where(Function(w) w.ENDRECORD Is Nothing And w.IDPOZO = ModModel.IdPozo).OrderByDescending(Function(o) o.FECHA).ToList()
        Formaciones = db.VW_PVT.Where(Function(w) w.IDAGUJERO = IdAgujero).ToList()




        Titulo += " | " + Settings.GetBy("prosper_version")



    End Sub

    Public Sub SetData()

        ModGeneral = db.MOD_POZO_GENERAL.Where(Function(w) w.IDMODPOZO = IdModPozo).SingleOrDefault()

        If ModGeneral Is Nothing Then
            ModGeneral = New MOD_POZO_GENERAL()
        End If


        ModPvt = ModModel.ModPvt
        ModTrayectorias = New ObjectModel.ObservableCollection(Of MOD_POZO_TRAYEC)(ModModel.ModTrayectorias)
        ModTemperaturas = New ObjectModel.ObservableCollection(Of MOD_POZO_TEMP)(ModModel.ModTemperaturas)

        Select Case LiftMethod
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


        'PROXIMO A REMOVER
        '=====================================================================================================
        If ModModel.ModPvt IsNot Nothing AndAlso ModPvt.IDPVTGENERAL <> "NA" Then
            Me.Formacion = db.VW_PVT.Where(Function(w) w.IDAGUJERO = ModModel.IdAgujero And w.IDPVTGENERAL = ModModel.ModPvt.IDPVTGENERAL).SingleOrDefault()
        End If

        ModArchivo = ModModel.ArchivoProsper

        'CARGA DE GRAFICAS DE LOS COMPONENTES
        '******************************************************************************************************

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
    Public Sub ResetData()
        Me.ModArchivo = Nothing
        Me.Comenta = ""
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
        Select Case LiftMethod
            Case 1
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
            Case 2
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
        End Select




        ModTrayectorias = New ObjectModel.ObservableCollection(Of MOD_POZO_TRAYEC)
        ModTemperaturas = New ObjectModel.ObservableCollection(Of MOD_POZO_TEMP)

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
    Private _warnings As ObjectModel.ObservableCollection(Of String)
    Public Property Warnings As ObjectModel.ObservableCollection(Of String)
        Get
            Return _warnings
        End Get
        Set(value As ObjectModel.ObservableCollection(Of String))
            _warnings = value
            RaisePropertyChanged("Warnings")
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
    Private _mod_pvt As MOD_POZO_PVT
    Public Property ModPvt As MOD_POZO_PVT
        Get
            Return _mod_pvt
        End Get
        Set(value As MOD_POZO_PVT)
            _mod_pvt = value

            'If _mod_pvt Is Nothing Then _mod_pvt = New MOD_POZO_PVT()
            RaisePropertyChanged("ModPvt")
        End Set
    End Property
    Private _new_archivo_pvt As String
    Public Property NewArchivoPvt As String
        Get
            Return _new_archivo_pvt
        End Get
        Set(value As String)
            _new_archivo_pvt = value
            If _new_archivo_pvt Is Nothing And ModArchivo Is Nothing Then
                EnabledPvt = True
                EnabledEquip = False
            Else
                EnabledPvt = False
            End If

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

            If _mod_archivo Is Nothing Then
                EnabledPvt = True
                EnabledEquip = False
            Else
                EnabledPvt = False
            End If

            'ModModel.ArchivoProsper = _mod_archivo
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

            If _lift_method > 0 And value <> _lift_method Then
                Dim q = MessageBox.Show("El Sistema de Producción Artificial es diferente.¿Desea cambiarla?", "Campos Inteligentes", MsgBoxStyle.YesNo, MessageBoxImage.Question)
                If q = MessageBoxResult.Yes Then
                    _lift_method = value
                End If
            Else
                _lift_method = value
            End If




            'Select Case _lift_method
            '    Case 1
            '        ModBNC = db.MOD_POZO_BNC.Where(Function(w) w.IDMODPOZO = IdModPozo).SingleOrDefault()


            '        If ModBNC.IDMODPOZOBNC > 0 Then
            '            Method = ModBNC.METHOD.GetValueOrDefault()
            '            Entry = ModBNC.ENTRY.GetValueOrDefault()
            '        Else
            '            ModBNC = New MOD_POZO_BNC() With {
            '            .CO2 = 0,
            '            .GRAVITY = 0,
            '            .GLRINY = 0,
            '            .GLRATE = 0,
            '            .ENTRY = 0,
            '            .DIAMVAL = 0,
            '            .H2S = 0,
            '            .METHOD = 0,
            '            .N2 = 0,
            '            .QGIMAX = 0,
            '            .QGIMIN = 0,
            '            .RANGESYSTEM = 0,
            '            .VALVEDEPTH = 0,
            '            .TRPRES = 0
            '        }
            '        End If


            '    Case 2
            '        'FileBEC = ModModel.FilePath
            '        ModBEC = db.MOD_POZO_BEC.Where(Function(w) w.IDMODPOZO = IdModPozo).SingleOrDefault()

            '        If ModBEC.IDMODPOZOBEC Is Nothing Then
            '            ModBEC = New MOD_POZO_BEC() With {
            '            .IDMODPOZOBEC = 0,
            '            .BOMBA_BEC = 0,
            '            .CABLE_BEC = 0,
            '            .CORRIENTE_BEC = 0,
            '            .DESGASTE_BEC = 0,
            '            .EFISEPGAS_BEC = 0,
            '            .ETAPAS_BEC = 0,
            '            .FRECMAX = 0,
            '            .FRECMIN = 0,
            '            .LONGCABLE_BEC = 0,
            '            .MOTOR_BEC = 0,
            '            .ODMAX_BEC = 0,
            '            .POTENCIAMOTOR_BEC = 0,
            '            .POTENCIA_BEC = 0,
            '            .PREDES_BEC = 0,
            '            .PRESUC_BEC = 0,
            '            .PROF_BEC = 0,
            '            .REDUCGAS_BEC = 0,
            '            .VOLTSUP_BEC = 0,
            '            .FREC_BEC = 0
            '        }

            '        End If
            'End Select

            RaisePropertyChanged("LiftMethod")
        End Set
    End Property



    Private _formacion As VW_PVT
    Public Property Formacion As VW_PVT
        Get
            Return _formacion
        End Get
        Set(value As VW_PVT)
            _formacion = value

            If _formacion Is Nothing Then _formacion = New VW_PVT()



            If ModPvt IsNot Nothing Then
                If ModPvt.IDPVTGENERAL <> _formacion.IDPVTGENERAL AndAlso MessageBox.Show("Se van a perder los datos de esta sección: Pvt.¿Desea continuar?", "Campos Inteligentes", MessageBoxButton.YesNo) = MessageBoxResult.No Then
                    Return
                End If

                ModPvt.API = _formacion.API
                ModPvt.CO2 = _formacion.CO2
                ModPvt.DRG = _formacion.DRG
                ModPvt.GOR = _formacion.GOR
                ModPvt.H2S = _formacion.H2S
                ModPvt.N2 = _formacion.N2
                ModPvt.WSAL = _formacion.SALINIDAD
                ModPvt.IDPVTGENERAL = _formacion.IDPVTGENERAL
            Else
                ModPvt = New MOD_POZO_PVT() With {
                    .API = _formacion.API,
                    .CO2 = _formacion.CO2,
                    .DRG = _formacion.DRG,
                    .GOR = _formacion.GOR,
                    .H2S = _formacion.H2S,
                    .N2 = _formacion.N2,
                    .WSAL = _formacion.SALINIDAD,
                    .IDPVTGENERAL = _formacion.IDPVTGENERAL
                }

            End If





            Pvts = db.VW_PVT_GRAFICA.Where(Function(w) w.IDPVTGENERAL = _formacion.IDPVTGENERAL And w.TEMPERATURA = _formacion.TEMP).OrderBy(Function(o) o.PPRUEBA).ToList()


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

    'Private _messages_pvt As ModelosEstabilidad.FlashData
    'Public Property MessagesPVT As ModelosEstabilidad.FlashData
    '    Get
    '        Return _messages_pvt
    '    End Get
    '    Set(value As ModelosEstabilidad.FlashData)
    '        _messages_pvt = value
    '        RaisePropertyChanged("MessagesPVT")
    '    End Set
    'End Property

    Private _mod_temperaturas As ObjectModel.ObservableCollection(Of MOD_POZO_TEMP)
    Property ModTemperaturas As ObjectModel.ObservableCollection(Of MOD_POZO_TEMP)
        Get
            Return _mod_temperaturas
        End Get
        Set(value As ObjectModel.ObservableCollection(Of MOD_POZO_TEMP))
            _mod_temperaturas = value
            RaisePropertyChanged("ModTemperaturas")
        End Set
    End Property

    Private _mod_trayectorias As ObjectModel.ObservableCollection(Of MOD_POZO_TRAYEC)
    Public Property ModTrayectorias As ObjectModel.ObservableCollection(Of MOD_POZO_TRAYEC)
        Get
            Return _mod_trayectorias
        End Get
        Set(value As ObjectModel.ObservableCollection(Of MOD_POZO_TRAYEC))
            _mod_trayectorias = value
            RaisePropertyChanged("ModTrayectorias")
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

    Private _trayectorias As List(Of VW_TRAYECTORIA)
    Public Property Trayectorias As List(Of VW_TRAYECTORIA)
        Get
            Return _trayectorias
        End Get
        Set(value As List(Of VW_TRAYECTORIA))
            _trayectorias = value
            RaisePropertyChanged("Trayectorias")
        End Set
    End Property


#Region "Deshabilitadores / Habilitadores"


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

    Private _enabled_equip As Boolean
    Public Property EnabledEquip As Boolean
        Get
            Return _enabled_equip
        End Get
        Set(value As Boolean)
            _enabled_equip = value


            RaisePropertyChanged("EnabledEquip")
        End Set
    End Property

    Private _tab As Integer
    Public Property Tab As Integer
        Get
            Return _tab
        End Get
        Set(value As Integer)
            _tab = value

            If IsReadOnly = False Then

                If Tab > 8 Then
                    VisibleSave = True
                    GetErrors()
                Else
                    VisibleSave = False
                End If
            End If


            RaisePropertyChanged("Tab")
        End Set
    End Property
    Private _visible_save As Boolean
    Public Property VisibleSave As Boolean
        Get
            Return _visible_save
        End Get
        Set(value As Boolean)
            _visible_save = value
            RaisePropertyChanged("VisibleSave")

        End Set
    End Property
    Private _is_read_only As Boolean
    Public Property IsReadOnly As Boolean
        Get
            Return _is_read_only
        End Get
        Set(value As Boolean)
            _is_read_only = value
            RaisePropertyChanged("IsReadOnly")
        End Set
    End Property
    Private _is_busy As Boolean
    Public Property IsBusy As Boolean
        Get
            Return _is_busy
        End Get
        Set(value As Boolean)
            _is_busy = value
            RaisePropertyChanged("IsBusy")
        End Set
    End Property
#End Region

#Region "Comandos"
    Public Property CommandResetMec As ICommand
    Public Property CommandResetTray As ICommand
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



    '''BNC
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


            If MessageBox.Show("¿Desea guardar los datos del siguiente modelo?", "Campos Inteligentes", MessageBoxButton.YesNo) = MessageBoxResult.No Then
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
                ModModel.Estatus = VwModelo.ESTATUS.GetValueOrDefault()
            End If




            'ModModel.DelMecas = DelMecanico
            'ModModel.DelTrays = DelTrayectoria
            'ModModel.DelTemps = DelTemperatura



            ModGeneral.LIFTMETHOD = Me.LiftMethod
            ModModel.ModGeneral = ModGeneral
            ModModel.NewArchivoPvt = NewArchivoPvt
            ModModel.ArchivoProsper = ModArchivo
            ModModel.Equipment = EnabledEquip
            ModModel.ModPvt = ModPvt





            Select Case LiftMethod
                Case 1
                    ModModel.ModBNC = ModBNC
                Case 2

                    ModModel.ModBEC = ModBEC
            End Select

            ModModel.IdModPozo = IdModPozo

            Dim result = ModModel.Save(Comenta)

            'Guardado de componentes
            If EnabledEquip = False And result Then

                ModModel.Mecanicos = New List(Of MOD_POZO_TUBERIA)

                If ModMecanicos IsNot Nothing Then
                    For i = 0 To ModMecanicos.Count - 1
                        ModModel.Mecanicos.Add(ModMecanicos(i).ModPozoTuberia)
                    Next
                    ModModel.SaveMecanico()

                    'If ModModel.SaveMecanico() > 0 Then
                    '    MaxMd = db.VW_EDO_MECANICO.Where(Function(w) w.IDAGUJERO = ModModel.IdAgujero).Max(Function(m) m.MD)

                    '    If MaxMd > 0 Then
                    '        Dim puntos = ModModel.SaveTrayectorias(MaxMd)
                    '        ModModel.SaveTemperatura(puntos)

                    '    End If

                    'End If
                End If
                If ModTrayectorias.Count > 0 Then
                    ModModel.SaveTrayectorias(ModTrayectorias.ToList())
                End If
                If ModTemperaturas.Count > 0 Then
                    ModModel.SaveTemperatura(ModTemperaturas.ToList())
                End If

            End If
            'Termina componentes

            IdModPozo = ModModel.IdModPozo


            MsgBox("Configuración guardada", MsgBoxStyle.Information)
            'FormView.Close()'Depreciado temporalmente hasta verificar que se realize en el Main 
            IsSaved = True
            FormView.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try



    End Sub
    Public Sub LoadDeclinacion(ByVal Fecha As DateTime)
        'Consultamos la informacion de presion
        Try
            Dim MV As Double = 0
            If ModTrayectorias.Count > 0 Then
                MV = ModTrayectorias(ModTrayectorias.Count - 1).PROFUNDIDADMV
            End If

            Dim EndPointDeclina As EndpointAddress = New EndpointAddress(Settings.GetBy("point_declina"))




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

        Dim result = MessageBox.Show("¿Desea cargar los datos del aforo con fecha " + aforo.FECHA + " a la configuración?", "Confirmar datos", MessageBoxButton.YesNo)

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

                ModGeneral.THTD = IIf(aforo.TEMP.GetValueOrDefault() > 0, aforo.TEMP, ModGeneral.THTD) 'Thtd = aforo.TEMP

                LoadDeclinacion(aforo.FECHA)
                ModGeneral.IDAFORO = aforo.IDAFORO
                ModGeneral = ModGeneral


            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try



    End Sub
    Private Function Valid() As Boolean

        Select Case LiftMethod
            Case 1
                If ModBNC.DIAMVAL = 0 Then
                    MsgBox("El diametro de la valvula no debe ser cero", MsgBoxStyle.Critical, "Error")
                    Return False
                End If
                If ModBNC.QGIMIN = ModBNC.QGIMAX Or ModBNC.QGIMIN > ModBNC.QGIMAX Then
                    MsgBox("BNC: Qgi máximo debe ser mayor que Qgi mínimo", MsgBoxStyle.Critical, "Error")
                    Return False
                End If
            Case 2
                If ModBEC.FRECMIN < 30 Then
                    MsgBox("La Frecuencia minima debe ser al menos 30 Hz", MsgBoxStyle.Critical, "Error")
                    Return False
                End If
                If ModBEC.FRECMIN > ModBEC.FRECMAX Then
                    MsgBox("La Frecuencia minima no debe ser mayor a la Frecuencia maxima", MsgBoxStyle.Critical, "Error")
                    Return False
                End If
        End Select




        Return True
    End Function
    Private Sub OnLoadMecanico()

        Dim result = MessageBox.Show("Los datos del estado mecánico para este modelo se van a eliminar y reiniciar con nuevos valores.¿Desea continuar con esta acción? ", "Campos inteligentes", MessageBoxButton.YesNo)

        If result = MessageBoxResult.Yes Then
            LoadMecanico()
        End If

    End Sub
    Private Sub OnLoadTrayectoria()

        Dim result = MessageBox.Show("Los datos de trayectoria para este modelo se van a reiniciar con nuevos valores de acuerdo con la lista del estado mecanico.¿Desea continuar con esta acción? ", "Campos inteligentes", MessageBoxButton.YesNo)

        If result = MessageBoxResult.Yes Then
            ModTrayectorias.Clear()
            LoadTrayectoria()
        End If
    End Sub
    ''' <summary>
    ''' Recarga el estado mecanico por defecto y asigna los otros valores
    ''' </summary>
    ''' <param name="ModTuberias"></param>
    Public Sub LoadMecanico(ByVal ModTuberias As List(Of MOD_POZO_TUBERIA))
        Dim MecanicoModel As New MecanicoModel(ModTuberias)
        ModMecanicos = New ObjectModel.ObservableCollection(Of MecanicoModel)(MecanicoModel.GetList().OrderBy(Function(o) o.Orden))
        MaxTp = MecanicoModel.GetMaxTp()
        MaxMd = ModMecanicos.Max(Function(m) m.ModPozoTuberia.MD)


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

            If ModBNC IsNot Nothing AndAlso ModBNC.NivMedDisp = 0 Then
                ModBNC.NivMedDisp = MaxTp
            End If

        Catch ex As Exception
            Errors.Add(ex.Message)
        End Try

    End Sub

    Private Sub LoadTrayectoria()
        Dim result(17, 4) As Double

        Dim mds(Trayectorias.Count - 1), mvs(Trayectorias.Count - 1), sevs(Trayectorias.Count - 1), dezps(Trayectorias.Count - 1), desvs(Trayectorias.Count - 1) As Double
        Dim tmp_trayectorias As New List(Of VW_TRAYECTORIA)







        If Trayectorias.Count > 0 And MaxMd > 0 Then
            'Indice 0 obligatorio inicialiar PMD a 0
            result(0, 0) = Trayectorias(0).PROFUNDIDADMD 'dt.Rows(0).Item(0)
            result(0, 1) = Trayectorias(0).PROFMV 'dt.Rows(0).Item(1)
            result(0, 2) = Trayectorias(0).SEVERIDAD
            result(0, 3) = Trayectorias(0).DESPLAZAMIENTO
            result(0, 4) = Trayectorias(0).DESVIACION
            Dim finMD As Double = MaxMd



            For i = 0 To Trayectorias.Count - 1
                mds(i) = Trayectorias(i).PROFUNDIDADMD
                mvs(i) = Trayectorias(i).PROFMV
                sevs(i) = Trayectorias(i).SEVERIDAD
                dezps(i) = Trayectorias(i).DESPLAZAMIENTO
                desvs(i) = Trayectorias(i).DESVIACION
                If Trayectorias(i).PROFUNDIDADMD <= MaxMd Then
                    tmp_trayectorias.Add(Trayectorias(i))
                End If

            Next i
            'Interpolaciones
            Dim finMV As Double = Analisis.InterpolarProfundidadesVertical(mds, mvs, MaxMd)
            Dim finSV As Double = Analisis.InterpolarProfundidadesVertical(mvs, sevs, MaxMd)
            Dim finDP As Double = Analisis.InterpolarProfundidadesVertical(mvs, dezps, MaxMd)
            Dim finDV As Double = Analisis.InterpolarProfundidadesVertical(mvs, desvs, MaxMd)

            tmp_trayectorias = tmp_trayectorias.OrderBy(Function(o) o.SEVERIDAD).ToList()


            Dim indice As Integer = 1 '2
            Dim j As Integer = tmp_trayectorias.Count - 1
            Do While (indice < 17)
                result(indice, 0) = tmp_trayectorias(j).PROFUNDIDADMD 'View.Item(i).Item(0)
                result(indice, 1) = tmp_trayectorias(j).PROFMV 'View.Item(i).Item(1)
                result(indice, 2) = tmp_trayectorias(j).SEVERIDAD
                result(indice, 3) = tmp_trayectorias(j).DESPLAZAMIENTO
                result(indice, 4) = tmp_trayectorias(j).DESVIACION

                indice += 1
                j -= 1
            Loop


            ReDim Preserve result(indice, 4)
            result(indice, 0) = finMD
            result(indice, 1) = finMV 'El Único que se interpola
            result(indice, 2) = finSV
            result(indice, 3) = finDP
            result(indice, 4) = finDV
            Analisis.ordenarMatriz(result, 0)


            'Guardado de la trayectoria a la Base de Datos
            '====================================================
            For i = 0 To result.GetUpperBound(0)
                Dim insert_tray As New MOD_POZO_TRAYEC() With {
                        .PROFUNDIDADMD = result(i, 0),
                        .PROFUNDIDADMV = result(i, 1),
                        .SEVERIDAD = result(i, 2),
                        .DESP = result(i, 3),
                        .DESV = result(i, 4)
                }

                ModTrayectorias.Add(insert_tray)



            Next i



            'If ModTemperaturas.Count = 0 Then
            LoadTemperatura(result)

            'End If


        End If
    End Sub
    Private Sub LoadTemperatura(ByVal puntos(,) As Double)
        Try
            Dim tp = ModModel.GetFormacion()
            If tp.Count > 0 Then
                'Revisar por excepcion

                ModTemperaturas.Clear()
                If tp("TEMP") > 0 Then
                    Dim b = IIf(ModGeneral.THTE Is Nothing Or ModGeneral.THTE = 0, 25, ModGeneral.THTE)


                    Dim a = (tp("TEMP") - b) / tp("PLANOREF") - puntos(0, 1) '((tb.Rows(0).Item(1) - b) / (tb.Rows(0).Item(2) - puntos(0, 1)))

                    Dim temperaturas = ModModel.GetTemperatura(puntos, a, b)

                    For i = 0 To temperaturas.GetUpperBound(0)
                        Dim mod_temperatura As New MOD_POZO_TEMP() With {
                            .PROFUNDIDADMD = temperaturas(i, 0),
                            .TEMPERATURA = temperaturas(i, 1)
                        }
                        ModTemperaturas.Add(mod_temperatura)

                    Next




                Else
                    Throw New Exception("Temperatura de la formación debe ser mayor a cero.")
                End If

            Else

                Throw New Exception("No hay datos en la fecha:" + FechaPrueba)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Temperatura", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try

    End Sub

    Public Sub GetErrors()
        'New ObjectModel.ObservableCollection(Of String)
        Errors.Clear()

        If Formacion Is Nothing And ModArchivo Is Nothing And (NewArchivoPvt = Nothing Or NewArchivoPvt = "") Then
            Errors.Add("No hay datos para generar el PVT, debes seleccionar alguna opcion en la pestaña PVT o cargar un archivo.Out.")
        End If

        'If Aforos.Count = 0 Then
        '    Errors.Add("No hay registros de Aforos. Se necesita al menos uno para continuar con el proceso.")
        'End If
        If ModBNC.QGIMIN > 0 AndAlso ModBNC.QGIMIN > ModBNC.QGIMAX Then
            ' MsgBox("BNC: Qgi máximo debe ser mayor que Qgi mínimo", MsgBoxStyle.Critical, "Error")
            Errors.Add("BNC: Qgi máximo debe ser mayor que Qgi mínimo")
        End If

        If ModGeneral.IDAFORO Is Nothing Then
            ' MsgBox("BNC: Qgi máximo debe ser mayor que Qgi mínimo", MsgBoxStyle.Critical, "Error")
            'Errors.Add("Es necesario seleccionar una fecha del Aforo para continuar con el proceso")
        End If


        'Errors = Errors

    End Sub




End Class
