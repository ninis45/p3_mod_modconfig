Imports ModeloCI
Imports ModelosConfig.Generales
Public Class AgujeroModel

    Public Property Pozo As String
    Public Property Numero As Integer
    Public Property IdPozo As String

    Public Property IdAgujero As String
    Public Property IdModPozo As String
    Public Property LiftMethod As Integer
    Public Property Estatus As Integer
    Public Property Configuracion As CONFIGURACION_ADMINISTRADOR
    Public Property VWGeneral As VW_EDO_GENERAL
    Public Property VWModPozo As VW_MOD_POZO

    Public Property ModTemperaturas As List(Of MOD_POZO_TEMP)
    Public Property Trayectorias As List(Of VW_TRAYECTORIA)
    Public Property ModTrayectorias As List(Of MOD_POZO_TRAYEC)
    'Public Property Mecanicos As List(Of Tuberia)

    Public Property ModTuberias As List(Of MOD_POZO_TUBERIA)
    Public Property Tuberias As List(Of Tuberia)
    Public Property FechaPrueba As String
    Public Property CreatedOn As DateTime


    Property DelTemps As Boolean = False
    Property DelTrays As Boolean = False
    Property DelMecas As Boolean = False


    Property Messages As List(Of FlashData)

    Private db As Entities_ModeloCI



    ' Public db As CIEntities
    Sub New(ByVal IdAgujero As String)

        Me.db = New Entities_ModeloCI()
        Me.IdAgujero = IdAgujero
        Me.Estatus = 0

        LoadAgujero()






    End Sub
    ''' <summary>
    ''' Recarga nuevamente el modelo
    ''' </summary>
    ''' 
    Sub Refresh(ByVal IdAgujero As String)
        Me.IdAgujero = IdAgujero
        LoadAgujero()
    End Sub
    Function LoadAgujero() As VW_AGUJEROS
        Dim result = db.VW_AGUJEROS.Where(Function(w) w.IDAGUJERO = IdAgujero).SingleOrDefault() '  (From ag In db.AGUJERO Join po In db.POZO On ag.IDPOZO Equals po.IDPOZO Where ag.IDAGUJERO = id_agujero).SingleOrDefault()

        If result Is Nothing Then
            Throw New Exception("No existe el agujero o fue borrado")
        End If

        Dim method = db.CAT_SAP.Find(result.IDCATSAP)
        Me.IdAgujero = result.IDAGUJERO
        Me.IdPozo = result.IDPOZO
        Me.Pozo = result.NOMBRE

        If method IsNot Nothing Then
            Me.LiftMethod = method.PROSPER
        Else
            Me.LiftMethod = 0
            Throw New Exception("No hay sistema artificial asignado")
        End If


        Me.VWModPozo = GetModPozo()
        '
        Me.ModTuberias = db.MOD_POZO_TUBERIA.Where(Function(w) w.IDMODPOZO = IdModPozo).OrderBy(Function(o) o.ORDEN).ToList() 'Mec.GetTuberias() 'db.VW_EDO_MECANICO.Where(Function(w) w.IDAGUJERO = IdAgujero).OrderBy(Function(o) o.MD).ToList()

        Return result



    End Function
    Function GetModPozo() As VW_MOD_POZO
        Dim VWModPozo As List(Of VW_MOD_POZO) = (From mpozo In db.VW_MOD_POZO Where IdAgujero = IdAgujero And mpozo.FUNCION = 6 And mpozo.FECHAMODELO = (db.VW_MOD_POZO.Where(Function(w) w.IDAGUJERO = IdAgujero And w.FUNCION = 6).Max(Function(m) m.FECHAMODELO)) Select mpozo).ToList()

        If VWModPozo.Count > 0 Then
            Return VWModPozo(0)
        Else
            Return New VW_MOD_POZO()
        End If

    End Function
    'DEPRECIADO TEMPORALMENTE
    Function GetEdoGeneral() As VW_EDO_GENERAL
        Dim General = (From edo_general In db.VW_EDO_GENERAL Where edo_general.IDAGUJERO = IdAgujero And edo_general.FUNCION = 6 And edo_general.FECHAMODELO = (db.MOD_POZO.Where(Function(w) w.IDAGUJERO = IdAgujero And w.FUNCION = 6).Max(Function(m) m.FECHAMODELO))).SingleOrDefault() ' db.VW_EDO_GENERAL.Where(Function(w) w.IDAGUJERO = IdAgujero).SingleOrDefault()


        If General IsNot Nothing Then
            Configuracion = db.CONFIGURACION_ADMINISTRADOR.Where(Function(w) w.IDMODPOZO = General.IDMODPOZO).SingleOrDefault()

        End If

        Return General
    End Function
    Function GetEdoGeneral(ByVal Estatus As Integer) As VW_EDO_GENERAL

        Dim General = (From edo_general In db.VW_EDO_GENERAL Where edo_general.ESTATUS = Estatus And edo_general.IDAGUJERO = IdAgujero And edo_general.FUNCION <> 1 And edo_general.FECHAMODELO = (db.MOD_POZO.Where(Function(w) w.IDAGUJERO = IdAgujero And w.FUNCION <> 1).Max(Function(m) m.FECHAMODELO))).SingleOrDefault() ' db.VW_EDO_GENERAL.Where(Function(w) w.IDAGUJERO = IdAgujero).SingleOrDefault()


        Return General
    End Function

    Function GetEdoGeneral(ByVal IdModPozo As String) As VW_EDO_GENERAL
        Dim General = db.VW_EDO_GENERAL.Where(Function(w) w.IDMODPOZO = IdModPozo).SingleOrDefault() '(From edo_general In db.VW_EDO_GENERAL Where edo_general.IDAGUJERO = IdAgujero And edo_general.FUNCION = 6 And edo_general.FECHAMODELO = (db.MOD_POZO.Where(Function(w) w.IDAGUJERO = IdAgujero And w.FUNCION = 6).Max(Function(m) m.FECHAMODELO))).SingleOrDefault() ' db.VW_EDO_GENERAL.Where(Function(w) w.IDAGUJERO = IdAgujero).SingleOrDefault()


        If General IsNot Nothing Then
            Configuracion = db.CONFIGURACION_ADMINISTRADOR.Where(Function(w) w.IDMODPOZO = General.IDMODPOZO).SingleOrDefault()
        End If

        Return General
    End Function


    'Function ResetTuberias() As List(Of MecanicoModel)
    '    Dim MecanicoModel As New MecanicoModel(Tuberias)
    '    Return MecanicoModel.GetList()
    'End Function
End Class

Public Class FlashData
    Public Property Message As String
    Public Property Estatus As String
End Class
