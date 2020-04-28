Imports ModeloCI
Imports ModelosConfig.Generales
Imports System.Data
Imports System.IO
Public Class ModModel
    Private db As Entities_ModeloCI
    Public Property IdPozo As String
    Public Property IdAgujero As String
    Public Property IdModPozo As String
    Public Property LiftMethod As Integer
    Public Property Estatus As Integer
    Public Property FechaPrueba As String
    Public Property CreatedOn As DateTime
    Public Property Comenta As String
    Public Property Pozo As String
    Public Property IdUsuario As String
    Property VwGeneral As VW_EDO_GENERAL
    Property Formacion As VW_FORMACION
    Property Mecanicos As List(Of MOD_POZO_TUBERIA)

    Property ModTuberias As List(Of MOD_POZO_TUBERIA)
    Property Tuberias As List(Of Tuberia)
    Property ModTrayectorias As List(Of MOD_POZO_TRAYEC)
    Property Trayectorias As List(Of VW_TRAYECTORIA)
    Property ModTemperaturas As List(Of MOD_POZO_TEMP)

    Property DelTemps As Boolean = False
    Property DelTrays As Boolean = False
    Property DelMecas As Boolean = False

    Property ModGeneral As MOD_POZO_GENERAL
    Property ModBNC As MOD_POZO_BNC
    Property ModBEC As MOD_POZO_BEC
    Property ModPvt As MOD_POZO_PVT
    Property NewArchivoPvt As String
    Property ArchivoProsper As ARCHIVOS_PROSPER
    Property ArchivoPvt As String

    Property IdPvt As String

    Property Equipment As Boolean

    ' Private objconsulta As New BaseDatos("SERVER=192.168.0.136\CI_DESARROLLO;User=sa;Password=Sql2016; Database=CI;")
    'Public Sub New(ByVal IdAgujero As String, ByVal IdUsuario As String)
    '    Me.IdAgujero = IdAgujero
    '    Me.db = New Entities_ModeloCI()
    '    Me.IdUsuario = IdUsuario

    '    If IdUsuario Is Nothing Then
    '        Throw New Exception("Falta definir el usuario para las acciones necesarias")
    '    End If


    'End Sub

    Public Sub New(ByVal IdAgujero As String, ByVal IdModPozo As String)
        Me.db = New Entities_ModeloCI()
        Me.IdAgujero = IdAgujero
        Me.IdModPozo = IdModPozo

        Me.VwGeneral = GetModelo(IdModPozo)
        Me.ModTuberias = db.MOD_POZO_TUBERIA.Where(Function(w) w.IDAGUJERO = IdAgujero).ToList()

        If Me.VwGeneral IsNot Nothing Then
            'Posiblemente depreciado
            ArchivoProsper = (From f In db.ARCHIVOS_PROSPER Where f.borradoLogico Is Nothing And f.idModPozo = Me.VwGeneral.IDMODPOZO And f.fecha = (db.ARCHIVOS_PROSPER.Where(Function(w) w.borradoLogico Is Nothing And w.idModPozo = Me.VwGeneral.IDMODPOZO).Max(Function(m) m.fecha))).SingleOrDefault() ' db.ARCHIVOS_PROSPER.Where(Function(w) w.idModPozo = General.IDMODPOZO).SingleOrDefault()

            If ArchivoProsper IsNot Nothing Then
                Equipment = ArchivoProsper.equipment.GetValueOrDefault()
            End If

            Me.ModTemperaturas = db.MOD_POZO_TEMP.Where(Function(w) w.IDMODPOZO = IdModPozo).OrderBy(Function(o) o.TEMPERATURA).ToList()
            Me.ModTrayectorias = db.MOD_POZO_TRAYEC.Where(Function(w) w.IDMODPOZO = IdModPozo).OrderBy(Function(o) o.PROFUNDIDADMD).ToList()
        End If

        Dim Agujero As VW_AGUJEROS = db.VW_AGUJEROS.Where(Function(w) w.IDAGUJERO = IdAgujero).SingleOrDefault()

        If Agujero IsNot Nothing Then
            Me.IdPozo = Agujero.IDPOZO
        End If

    End Sub
    Public Sub New(ByVal db As Entities_ModeloCI, ByVal IdAgujero As String, ByVal FechaPrueba As String, ByVal IdUsuario As String, ByVal LiftMethod As Integer)
        Me.db = db
        Me.IdAgujero = IdAgujero
        Me.FechaPrueba = FechaPrueba

        Me.IdUsuario = IdUsuario
        Me.LiftMethod = LiftMethod
        Me.ModTuberias = db.MOD_POZO_TUBERIA.Where(Function(w) w.IDAGUJERO = IdAgujero).ToList()
        Me.Trayectorias = db.VW_TRAYECTORIA.Where(Function(w) w.IDAGUJERO = IdAgujero).ToList()

        'Buscamos Edo Mecanico
        '***************************************************
        Dim Mecanico As New Mecanico(db.VW_TR.Where(Function(w) w.IDAGUJERO = IdAgujero).OrderByDescending(Function(o) o.PROFUNDIDADFIN).ToList(), db.VW_TP.Where(Function(w) w.IDAGUJERO = IdAgujero).OrderByDescending(Function(w) w.PROFUNDIDAD).ToList(), False)
        Tuberias = Mecanico.GetTuberias()

        Me.VwGeneral = GetModelo()

        If Me.VwGeneral IsNot Nothing Then
            'Posiblemente depreciado
            ArchivoProsper = (From f In db.ARCHIVOS_PROSPER Where f.borradoLogico Is Nothing And f.idModPozo = Me.VwGeneral.IDMODPOZO And f.fecha = (db.ARCHIVOS_PROSPER.Where(Function(w) w.borradoLogico Is Nothing And w.idModPozo = Me.VwGeneral.IDMODPOZO).Max(Function(m) m.fecha))).SingleOrDefault() ' db.ARCHIVOS_PROSPER.Where(Function(w) w.idModPozo = General.IDMODPOZO).SingleOrDefault()

            If ArchivoProsper IsNot Nothing Then
                Equipment = ArchivoProsper.equipment.GetValueOrDefault()
            End If
        End If


        Dim Agujero As VW_AGUJEROS = db.VW_AGUJEROS.Where(Function(w) w.IDAGUJERO = IdAgujero).SingleOrDefault()

        If Agujero IsNot Nothing Then
            Me.IdPozo = Agujero.IDPOZO
        End If
        If IdUsuario Is Nothing Then
            Throw New Exception("Falta definir el usuario para las acciones necesarias")
        End If

    End Sub
    Public Function GetModelo(ByVal IdModPozo As String) As VW_EDO_GENERAL
        Dim VwEdoGeneral = db.VW_EDO_GENERAL.Where(Function(w) w.IDMODPOZO = IdModPozo).SingleOrDefault()

        If VwEdoGeneral IsNot Nothing Then
            IdModPozo = VwEdoGeneral.IDMODPOZO
            Estatus = VwEdoGeneral.ESTATUS.GetValueOrDefault()
            LiftMethod = VwEdoGeneral.LIFTMETHOD.GetValueOrDefault()
            CreatedOn = VwEdoGeneral.FECHAMODELO
            Pozo = VwEdoGeneral.NOMBRE

            GetEquipment(VwEdoGeneral.IDMODPOZO)
        End If

        Return VwEdoGeneral
    End Function
    Public Function GetModelo() As VW_EDO_GENERAL

        Dim General = (From edo_general In db.VW_EDO_GENERAL Where edo_general.IDAGUJERO = IdAgujero And edo_general.FUNCION = 6 And edo_general.LIFTMETHOD = LiftMethod And edo_general.FECHAMODELO = (db.MOD_POZO.Where(Function(w) w.IDAGUJERO = IdAgujero And w.FUNCION = 6 And edo_general.LIFTMETHOD = LiftMethod).Max(Function(m) m.FECHAMODELO))).SingleOrDefault() ' db.VW_EDO_GENERAL.Where(Function(w) w.IDAGUJERO = IdAgujero).SingleOrDefault()

        If General IsNot Nothing Then
            Me.VwGeneral = General
            Me.Comenta = General.OBSERVACIONES
            Me.ModPvt = db.MOD_POZO_PVT.Where(Function(w) w.IDMODPOZO = General.IDMODPOZO).SingleOrDefault()

            IdModPozo = VwGeneral.IDMODPOZO
            Estatus = VwGeneral.ESTATUS.GetValueOrDefault()
            LiftMethod = VwGeneral.LIFTMETHOD.GetValueOrDefault()
            CreatedOn = General.FECHAMODELO
            Pozo = VwGeneral.NOMBRE
            GetEquipment(General.IDMODPOZO)






        End If

        Return General
    End Function

    Public Sub GetEquipment(ByVal IdModPozo As String)
        Me.ModTemperaturas = db.MOD_POZO_TEMP.Where(Function(w) w.IDMODPOZO = IdModPozo).OrderBy(Function(o) o.TEMPERATURA).ToList()
        Me.ModTrayectorias = db.MOD_POZO_TRAYEC.Where(Function(w) w.IDMODPOZO = IdModPozo).OrderBy(Function(o) o.PROFUNDIDADMD).ToList()
        Me.ModPvt = db.MOD_POZO_PVT.Where(Function(w) w.IDMODPOZO = IdModPozo).SingleOrDefault()
    End Sub

    ''' <summary>
    ''' Se resetea la configuracion completa
    ''' </summary>
    Public Sub Reset()
        Dim Configuracion = db.CONFIGURACION_ADMINISTRADOR.Where(Function(w) w.IDMODPOZO = IdModPozo).SingleOrDefault()


        If Configuracion IsNot Nothing Then

            db.CONFIGURACION_ADMINISTRADOR.Remove(Configuracion)
            db.SaveChanges()

            Exit Sub


            Dim Intentos = db.EJECUCION_PROCESOS.Where(Function(w) w.IDCONFIGURACION = Configuracion.IDCONFIGURACION And w.ENDRECORD Is Nothing).ToList()

            If Intentos.Count > 0 Then

                For Each e In Intentos
                    e.ENDRECORD = DateTime.Now + ": " + e.IDEJECUCION
                    db.Entry(e).State = Entity.EntityState.Modified
                Next

                db.SaveChanges()
            End If

            Configuracion.FECHA_PROGRAMACION = Nothing
            Configuracion.ESTATUS = 0
            db.Entry(Configuracion).State = Entity.EntityState.Modified
            db.SaveChanges()
        End If
    End Sub
    Public Function Save(ByVal Comenta As String) As Boolean
        Try
            Dim ModPozo As MOD_POZO

            If Estatus = 3 Or IdModPozo Is Nothing Then

                ModPozo = New MOD_POZO() With {
                    .IDMODPOZO = Guid.NewGuid().ToString().ToUpper(),
                    .IDAGUJERO = IdAgujero,
                    .OBSERVACIONES = Comenta,
                    .FUNCION = 6,
                    .FECHAMODELO = DateTime.Now
                }

                'If ArchivoProsper IsNot Nothing And ArchivoPvt Is Nothing Then
                '    ModPozo.ARCHIVO = Nothing
                'End If

                db.MOD_POZO.Add(ModPozo)
                IdModPozo = ModPozo.IDMODPOZO

            Else


                ModPozo = db.MOD_POZO.Where(Function(w) w.IDMODPOZO = IdModPozo).SingleOrDefault()
                ModPozo.OBSERVACIONES = Comenta
                ModPozo.FECHAMODELO = DateTime.Now

                'If ArchivoPvt Is Nothing Then
                '    ModPozo.ARCHIVO = Nothing
                'End If


                db.Entry(ModPozo).State = System.Data.Entity.EntityState.Modified

            End If
            db.SaveChanges()
            Estatus = 0

            'Guardado de Archivo PVT
            '===================================================
            SavePvt(ModPozo.IDMODPOZO)







            Reset()


            'Actualizamos General
            '=================================================================
            'ModGeneral.IDPVT = IdPvt 'Luego se revisarás mas adelante

            If ModGeneral.IDMODPOZO <> IdModPozo Then
                db.Entry(ModGeneral).State = Entity.EntityState.Detached
                ModGeneral.IDMODPOZO = IdModPozo
                ModGeneral.IDMODPOZOGENERAL = Guid.NewGuid().ToString().ToUpper()
                ModGeneral.COMPANY = ht.Item("COMPANY")
                ModGeneral.ANALYST = ht.Item("ANALYST")
                ModGeneral.LOCATIONS = ht.Item("LOCATIONS")
                ModGeneral.WELL = Me.Pozo

                db.MOD_POZO_GENERAL.Add(ModGeneral)
            Else
                db.Entry(ModGeneral).State = System.Data.Entity.EntityState.Modified
            End If
            db.SaveChanges()


            Select Case ModGeneral.LIFTMETHOD
                Case 1
                    If ModBNC.IDMODPOZO = IdModPozo Then
                        db.Entry(ModBNC).State = System.Data.Entity.EntityState.Modified
                    Else
                        ModBNC.IDMODPOZO = IdModPozo
                        db.MOD_POZO_BNC.Add(ModBNC)
                    End If

                Case 2
                    If ModBEC.IDMODPOZO = IdModPozo Then
                        db.Entry(ModBEC).State = System.Data.Entity.EntityState.Modified
                    Else
                        db.Entry(ModBEC).State = Entity.EntityState.Detached
                        ModBEC.IDMODPOZOBEC = Guid.NewGuid().ToString().ToUpper()
                        ModBEC.IDMODPOZO = IdModPozo
                        db.MOD_POZO_BEC.Add(ModBEC)
                    End If
            End Select
            db.SaveChanges()



            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Sub SavePvt(ByVal IdModPozo As String)
        Dim Fil As Byte()

        ''Actualizamos PVT y moverlo a SavePvt()
        'If ModPvt Is Nothing Then
        '    ModPvt = New MOD_POZO_PVT() With {.CREATED_ON = DateTime.Now, .IDPVTGENERAL = Formacion.id}
        'End If


        'If IdPvt IsNot Nothing Then
        'ModPvt.IDPVTGENERAL = IdPvt

        If ModPvt IsNot Nothing AndAlso ModPvt.IDPVTGENERAL IsNot Nothing Then
            If ModPvt.IDMODPOZO <> IdModPozo Then
                db.Entry(ModPvt).State = Entity.EntityState.Detached
                ModPvt.IDMODPOZO = IdModPozo
                ModPvt.IDMODPOZOPVT = Guid.NewGuid().ToString().ToUpper()
                db.MOD_POZO_PVT.Add(ModPvt)
            Else
                db.Entry(ModPvt).State = System.Data.Entity.EntityState.Modified
            End If
            db.SaveChanges()
        End If

        'End If



        If ArchivoProsper Is Nothing Then


            Dim OldArchivoProsper = (From f In db.ARCHIVOS_PROSPER Where f.borradoLogico Is Nothing And f.idModPozo = IdModPozo And f.fecha = (db.ARCHIVOS_PROSPER.Where(Function(w) w.borradoLogico Is Nothing And w.idModPozo = IdModPozo).Max(Function(m) m.fecha))).SingleOrDefault() ' db.ARCHIVOS_PROSPER.Where(Function(w) w.idModPozo = General.IDMODPOZO).SingleOrDefault()


            If OldArchivoProsper IsNot Nothing Then
                OldArchivoProsper.borradoLogico = "Usuario: " + IdUsuario + ", Fecha Hora: " + DateTime.Now
                db.Entry(OldArchivoProsper).State = Entity.EntityState.Modified
                db.SaveChanges()
            End If



            If NewArchivoPvt IsNot Nothing And File.Exists(NewArchivoPvt) Then
                Fil = File.ReadAllBytes(NewArchivoPvt)

                'Guardamos una copia en el historial de archivos
                '============================================================
                db.ARCHIVOS_PROSPER.Add(New ARCHIVOS_PROSPER() With {
                        .equipment = Equipment,
                        .idModPozo = IdModPozo,
                        .fecha = DateTime.Now,
                        .nombreArchivo = NewArchivoPvt,
                        .archivo = Fil,
                        .idUsuario = IdUsuario
                })
            End If


        Else
            ArchivoProsper.equipment = Equipment

            If ArchivoProsper.idModPozo <> IdModPozo Then

                db.Entry(ArchivoProsper).State = Entity.EntityState.Detached

                ArchivoProsper.fecha = DateTime.Now
                ArchivoProsper.idModPozo = IdModPozo
                db.ARCHIVOS_PROSPER.Add(ArchivoProsper)
                db.SaveChanges()
            Else
                db.Entry(ArchivoProsper).State = Entity.EntityState.Modified
                db.SaveChanges()
            End If

        End If


    End Sub

    Function SaveMecanico() As Integer

        Try
            If Mecanicos.Count = 0 Then
                Throw New Exception("No hay estado mecánico")
            Else
                'Actualizamos orden

                Dim Ids As List(Of String) = New List(Of String)()
                For i = 0 To Mecanicos.Count - 1
                    Mecanicos(i).ORDEN = i

                    If Mecanicos(i).IDMODPOZOTUBERIA Is Nothing Then

                        Mecanicos(i).IDAGUJERO = IdAgujero
                        Mecanicos(i).IDMODPOZOTUBERIA = Guid.NewGuid().ToString().ToUpper()
                        db.MOD_POZO_TUBERIA.Add(Mecanicos(i))
                    Else
                        db.Entry(Mecanicos(i)).State = Entity.EntityState.Modified
                    End If

                    db.SaveChanges()
                    Ids.Add(Mecanicos(i).IDMODPOZOTUBERIA)
                Next


                Dim to_deletes = db.MOD_POZO_TUBERIA.Where(Function(w) w.IDAGUJERO = IdAgujero And Ids.Contains(w.IDMODPOZOTUBERIA) = False).ToList()

                to_deletes.ForEach(Function(e) db.MOD_POZO_TUBERIA.Remove(e))
                db.SaveChanges()


                Return Mecanicos.Count
            End If

            'Eliminamos tuberias
            'Dim mecanicos = db.MOD_POZO_TUBERIA.Where(Function(w) w.IDAGUJERO = IdAgujero).ToList()

            'If DelMecas AndAlso Mecanicos.Count > 0 Then
            '    Mecanicos.ForEach(Function(e) db.MOD_POZO_TUBERIA.Remove(e))
            '    db.SaveChanges()
            '    Mecanicos = New List(Of MOD_POZO_TUBERIA)()
            'End If


            'If Mecanicos.Count = 0 Then
            '    Dim Trs = db.VW_TR.Where(Function(w) w.IDAGUJERO = IdAgujero).OrderByDescending(Function(o) o.PROFUNDIDADINICIO).ToList()
            '    Dim Tps = db.VW_TP.Where(Function(w) w.IDAGUJERO = IdAgujero).OrderByDescending(Function(w) w.PROFUNDIDAD).ToList()
            '    Dim TipoTuberias = db.CAT_TIPO_TUBERIA.Where(Function(w) w.ENDRECORD Is Nothing).ToDictionary(Function(d) d.NUMERO, Function(d) d.IDTIPOTUBERIA)

            '    Dim mecanico As New Mecanico(Trs, Tps)

            '    Dim list_mecanicos = mecanico.GetTuberias()

            '    If list_mecanicos.Count = 0 Then
            '        Throw New Exception("No hay estado mecánico")
            '    End If

            '    Dim num As Integer = 0
            '    For Each tub In list_mecanicos
            '        db.MOD_POZO_TUBERIA.Add(New MOD_POZO_TUBERIA() With {
            '            .IDMODPOZOTUBERIA = Guid.NewGuid.ToString().ToUpper(),
            '            .IDAGUJERO = IdAgujero,
            '            .IDTIPOTUBERIA = TipoTuberias(tub.Type), ' tub.IDTIPOTUBERIA,
            '            .ETIQUETA = tub.Label,
            '            .CIDIAM = tub.CIDIAM,
            '            .CIROUG = tub.CIROUG,
            '            .MD = tub.MD,
            '            .TIDIAM = tub.TIDIAM,
            '            .TODIAM = tub.TODIAM,
            '            .TIROUG = tub.TIROUG,
            '            .TOROUG = tub.TOROUG,
            '            .ORDEN = num
            '        })

            '        num += 1
            '    Next
            '    db.SaveChanges()

            '    Return list_mecanicos.Count
            'Else
            '    'Actualizamos orden
            '    For i = 0 To Mecanicos.Count - 1
            '        Mecanicos(i).ORDEN = i

            '        If Mecanicos(i).IDMODPOZOTUBERIA Is Nothing Then
            '            Mecanicos(i).IDMODPOZOTUBERIA = Guid.NewGuid().ToString().ToUpper()
            '            db.MOD_POZO_TUBERIA.Add(Mecanicos(i))
            '        Else
            '            db.Entry(Mecanicos(i)).State = Entity.EntityState.Modified
            '        End If

            '        db.SaveChanges()
            '    Next


            '    Return Mecanicos.Count
            'End If


        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Function SaveTrayectorias(ByVal ModTrayectorias As List(Of MOD_POZO_TRAYEC)) As Double(,)
        Dim result(17, 4) As Double

        Try
            Dim ids As New List(Of String)

            For Each tray In ModTrayectorias
                If tray.IDMODPOZOTRAYEC Is Nothing Then
                    tray.IDMODPOZOTRAYEC = Guid.NewGuid().ToString().ToUpper()
                    db.MOD_POZO_TRAYEC.Add(tray)

                Else
                    If tray.IDMODPOZO <> IdModPozo Then
                        db.Entry(tray).State = Entity.EntityState.Detached
                        tray.IDMODPOZOTRAYEC = Guid.NewGuid().ToString().ToUpper()
                        tray.IDMODPOZO = IdModPozo
                        db.MOD_POZO_TRAYEC.Add(tray)
                    Else
                        db.Entry(tray).State = Entity.EntityState.Modified
                    End If


                End If

                ids.Add(tray.IDMODPOZOTRAYEC)

                'Eliminamos elementos
                Dim deletes = db.MOD_POZO_TRAYEC.Where(Function(w) w.IDMODPOZO = IdModPozo And ids.Contains(w.IDMODPOZOTRAYEC) = False).ToList()
                deletes.ForEach(Function(e) db.MOD_POZO_TRAYEC.Remove(e))
                ' db.SaveChanges()
            Next

            db.SaveChanges()

            'Dim mod_trayectorias = db.MOD_POZO_TRAYEC.Where(Function(w) w.IDMODPOZO = IdModPozo).OrderBy(Function(o) o.PROFUNDIDADMD).ToList()

            'If DelTrays Then
            '    mod_trayectorias.ForEach(Function(e) db.MOD_POZO_TRAYEC.Remove(e))
            '    db.SaveChanges()
            '    mod_trayectorias = New List(Of MOD_POZO_TRAYEC)()

            'End If


            'If mod_trayectorias.Count = 0 Then
            '    Dim Trayectorias = db.VW_TRAYECTORIA.Where(Function(w) w.IDAGUJERO = IdAgujero).OrderBy(Function(o) o.PROFUNDIDADMD).ToList()

            '    Dim mds(Trayectorias.Count - 1), mvs(Trayectorias.Count - 1), sevs(Trayectorias.Count - 1), dezps(Trayectorias.Count - 1), desvs(Trayectorias.Count - 1) As Double
            '    Dim tmp_trayectorias As New List(Of VW_TRAYECTORIA)







            '    If Trayectorias.Count > 0 Then
            '        'Indice 0 obligatorio inicialiar PMD a 0
            '        result(0, 0) = Trayectorias(0).PROFUNDIDADMD 'dt.Rows(0).Item(0)
            '        result(0, 1) = Trayectorias(0).PROFMV 'dt.Rows(0).Item(1)
            '        result(0, 2) = Trayectorias(0).SEVERIDAD
            '        result(0, 3) = Trayectorias(0).DESPLAZAMIENTO
            '        result(0, 4) = Trayectorias(0).DESVIACION
            '        Dim finMD As Double = max_md



            '        For i = 0 To Trayectorias.Count - 1
            '            mds(i) = Trayectorias(i).PROFUNDIDADMD
            '            mvs(i) = Trayectorias(i).PROFMV
            '            sevs(i) = Trayectorias(i).SEVERIDAD
            '            dezps(i) = Trayectorias(i).DESPLAZAMIENTO
            '            desvs(i) = Trayectorias(i).DESVIACION
            '            If Trayectorias(i).PROFUNDIDADMD <= max_md Then
            '                tmp_trayectorias.Add(Trayectorias(i))
            '            End If

            '        Next i
            '        'Interpolaciones
            '        Dim finMV As Double = Analisis.InterpolarProfundidadesVertical(mds, mvs, max_md)
            '        Dim finSV As Double = Analisis.InterpolarProfundidadesVertical(mvs, sevs, max_md)
            '        Dim finDP As Double = Analisis.InterpolarProfundidadesVertical(mvs, dezps, max_md)
            '        Dim finDV As Double = Analisis.InterpolarProfundidadesVertical(mvs, desvs, max_md)

            '        tmp_trayectorias = tmp_trayectorias.OrderBy(Function(o) o.SEVERIDAD).ToList()


            '        Dim indice As Integer = 1 '2
            '        Dim j As Integer = tmp_trayectorias.Count - 1
            '        Do While (indice < 17)
            '            result(indice, 0) = tmp_trayectorias(j).PROFUNDIDADMD 'View.Item(i).Item(0)
            '            result(indice, 1) = tmp_trayectorias(j).PROFMV 'View.Item(i).Item(1)
            '            result(indice, 2) = tmp_trayectorias(j).SEVERIDAD
            '            result(indice, 3) = tmp_trayectorias(j).DESPLAZAMIENTO
            '            result(indice, 4) = tmp_trayectorias(j).DESVIACION

            '            indice += 1
            '            j -= 1
            '        Loop

            '        ReDim Preserve result(indice, 4)
            '        result(indice, 0) = finMD
            '        result(indice, 1) = finMV 'El Único que se interpola
            '        result(indice, 2) = finSV
            '        result(indice, 3) = finDP
            '        result(indice, 4) = finDV
            '        Analisis.ordenarMatriz(result, 0)

            '        'Guardado de la trayectoria a la Base de Datos
            '        '====================================================

            '        For i = 0 To result.GetUpperBound(0)
            '            Dim insert_tray As New MOD_POZO_TRAYEC() With {
            '                .IDMODPOZOTRAYEC = Guid.NewGuid().ToString().ToUpper(),
            '                .IDMODPOZO = IdModPozo,
            '                .PROFUNDIDADMD = result(i, 0),
            '                .PROFUNDIDADMV = result(i, 1),
            '                .SEVERIDAD = result(i, 2),
            '                .DESP = result(i, 3),
            '                .DESV = result(i, 4)
            '            }


            '            db.MOD_POZO_TRAYEC.Add(insert_tray)

            '        Next i

            '        db.SaveChanges()


            '    End If




            'Else


            '    'Indice 0 obligatorio inicialiar PMD a 0
            '    For i = 0 To mod_trayectorias.Count - 1
            '        result(i, 0) = mod_trayectorias(i).PROFUNDIDADMD 'dt.Rows(0).Item(0)
            '        result(i, 1) = mod_trayectorias(i).PROFUNDIDADMV 'dt.Rows(0).Item(1)
            '    Next

            'End If


            Return result


        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Function SaveTemperatura(ByVal ModTemperaturas As List(Of MOD_POZO_TEMP)) As Boolean
        Try

            Dim ids As New List(Of String)

            For Each temp In ModTemperaturas
                If temp.IDMODPOZOTEMP Is Nothing Then
                    temp.IDMODPOZOTEMP = Guid.NewGuid().ToString().ToUpper()
                    db.MOD_POZO_TEMP.Add(temp)

                Else
                    If temp.IDMODPOZO <> IdModPozo Then
                        db.Entry(temp).State = Entity.EntityState.Detached
                        temp.IDMODPOZOTEMP = Guid.NewGuid().ToString().ToUpper()
                        temp.IDMODPOZO = IdModPozo
                        db.MOD_POZO_TEMP.Add(temp)
                    Else
                        db.Entry(temp).State = Entity.EntityState.Modified
                    End If


                End If

                ids.Add(temp.IDMODPOZOTEMP)

                'Eliminamos elementos
                Dim deletes = db.MOD_POZO_TEMP.Where(Function(w) w.IDMODPOZO = IdModPozo And ids.Contains(w.IDMODPOZOTEMP) = False).ToList()
                deletes.ForEach(Function(e) db.MOD_POZO_TEMP.Remove(e))
                ' db.SaveChanges()
            Next

            db.SaveChanges()


            'Dim temps = db.MOD_POZO_TEMP.Where(Function(w) w.IDMODPOZO = IdModPozo).ToList()

            'If DelTemps AndAlso temps.Count > 0 Then
            '    temps.ForEach(Function(e) db.MOD_POZO_TEMP.Remove(e))
            '    db.SaveChanges()

            '    temps = New List(Of MOD_POZO_TEMP)
            'End If


            'If temps.Count = 0 Then
            '    ' Dim tb As DataTable = objconsulta.getDatosFormacion(IdAgujero, FechaPrueba) 'Necesario para la temperatura
            '    Dim tp = GetFormacion(FechaPrueba)
            '    If tp.Count > 0 Then
            '        'Revisar por excepcion


            '        If tp("TEMP") > 0 Then
            '            Dim b = IIf(ModGeneral.THTE Is Nothing Or ModGeneral.THTE = 0, 25, ModGeneral.THTE)


            '            Dim a = (tp("TEMP") - b) / tp("PLANOREF") - puntos(0, 1) '((tb.Rows(0).Item(1) - b) / (tb.Rows(0).Item(2) - puntos(0, 1)))

            '            Dim temperaturas = GetTemperatura(puntos, a, b)

            '            For i = 0 To temperaturas.GetUpperBound(0)
            '                Dim mod_temperatura As New MOD_POZO_TEMP() With {
            '                    .IDMODPOZOTEMP = Guid.NewGuid().ToString().ToUpper(),
            '                    .IDMODPOZO = IdModPozo,
            '                    .PROFUNDIDADMD = temperaturas(i, 0),
            '                    .TEMPERATURA = temperaturas(i, 1)
            '                }
            '                db.MOD_POZO_TEMP.Add(mod_temperatura)
            '            Next

            '            db.SaveChanges()


            '            Return True
            '        Else
            '            Throw New Exception("Temperatura de la formación debe ser > 0")
            '        End If

            '    Else

            '        Throw New Exception("No hay datos en la fecha:" + FechaPrueba)
            '    End If
            'Else
            '    Return True
            'End If




        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function GetTemperatura(ByVal trayectoria(,) As Double, ByVal a As Double, b As Double) As Double(,)
        'REVISAR TALVEZ MARQUE FUERA DE INDICE
        Dim result(trayectoria.GetUpperBound(0), 1) As Double
        For i = 0 To trayectoria.GetUpperBound(0)  'Forzosamente se realiza a 17 registros, asi lo pide PROSPER
            result(i, 0) = trayectoria(i, 0)
            result(i, 1) = (trayectoria(i, 1) * a) + b
        Next i
        'Dim arreglo() As String = getArregloCol(arreglo_trayectoria, 1, 0)
        'Dim resultado(arreglo.Length - 1, 1) As String
        'For i = 0 To arreglo.Length - 1
        '    resultado(i, 0) = arreglo_trayectoria(i, 0) 'arreglo(i)
        '    resultado(i, 1) = (arreglo(i) * a) + b
        'Next
        Return result
    End Function
    Public Function GetFormacion() As Dictionary(Of String, Double)
        Dim result As New Dictionary(Of String, Double)
        Dim dt = DateTime.Parse(FechaPrueba)

        Dim disparos = (From di In db.VW_DISPAROS Join fo In db.VW_FORMACION On fo.IDAGUJERO Equals di.IDAGUJERO Where di.CIMAMD >= fo.CIMAREAL And di.BASEMD <= fo.BASECG And di.IDAGUJERO = IdAgujero And di.FECHAAPERTURA <= dt And di.FECHACIERRE >= dt).ToList() 'db.VW_DISPAROS.Where(Function(w) w.IDAGUJERO = IdAgujero And w.FECHAAPERTURA <= dt And w.FECHACIERRE >= dt).ToList()

        If disparos.Count = 0 Then
            Throw New Exception("No hay disparos para esta fecha: " + FechaPrueba)
        End If


        result.Add("TEMP", disparos(0).fo.TEMPERATURA)
        result.Add("PLANOREF", disparos(0).fo.PLANOREFERENCIA)

        Return result


    End Function


    ''Function ResetTuberias() As List(Of MecanicoModel)
    ''    Dim MecanicoModel As New MecanicoModel(Tuberias)
    ''    Return MecanicoModel.GetList()
    ''End Function
End Class
