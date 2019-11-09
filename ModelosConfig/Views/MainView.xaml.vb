Class MainWindow

    Dim Context As MainViewModel


    Sub New(ByVal IdAgujero As String, ByVal Fecha As String, ByVal IdUsuario As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        'Dim estabilidad As New ModelosEstabilidad.Main() 'Verificar si se puede cambiar al Contexto

        Context = New MainViewModel(IdAgujero, Fecha, IdUsuario)
        Me.DataContext = Context

        Context.Initialize(hstProductividad, hstCorrelacion, hstVpl, hstGas, hstDiag, hstWc)
        'GrdEstabilidad.Children.Add(estabilidad)


        'QLiq(0, 0) = 10
        'QLiq(1, 0) = 20

        'Dim boud = QLiq.GetUpperBound(1)

    End Sub
    Public Sub actualizar(ByVal IdAgujero As String, ByVal Fecha As String, ByVal IdUsuario As String)

        If Context Is Nothing Then
            ' Context = New ContextViewModel(IdAgujero, Fecha)
        Else
            Context.IdAgujero = IdAgujero
            Context.FechaPrueba = Fecha
            Context.IdUsuario = IdUsuario
        End If


    End Sub

    Private Sub ShowConfig(sender As Object, e As RoutedEventArgs)
        Dim db As New ModeloCI.Entities_ModeloCI()
        Dim ConfigView As New ConfigView(Context.IdAgujero, Context.LiftMethod, Context.IdUsuario, Context.Errors, Context.FechaPrueba)


        ConfigView.ShowDialog()
        'Dim ModModel As New ModModel(Context.IdAgujero, Context.IdUsuario)

        If ConfigView.ContextConfig.IsSaved Then
            Context.IdModPozo = ConfigView.ContextConfig.IdModPozo 'Revisar para que no haya doble consulta en VWGeneral
            Context.VwGeneral = db.VW_EDO_GENERAL.Where(Function(w) w.IDMODPOZO = ConfigView.ContextConfig.IdModPozo).SingleOrDefault()
        End If


    End Sub

    Private Sub ShowCond(sender As Object, e As RoutedEventArgs)
        Dim db As New ModeloCI.Entities_ModeloCI()
        Dim CondView As New CondView(Context.IdAgujero, Context.LiftMethod)


        CondView.ShowDialog()


    End Sub

    Private Sub ShowPozo(sender As Object, e As RoutedEventArgs)
        Dim PozoView As New PozoView()

        PozoView.DataContext = Context
        PozoView.ShowDialog()
    End Sub

    Private Sub OnExpanded(sender As Object, e As Telerik.Windows.RadRoutedEventArgs)


        'GrdMain.Visibility = Visibility.Collapsed
        Context.Panel = "| Panel de Estabilidad"


    End Sub

    Private Sub OnCollapsed(sender As Object, e As Telerik.Windows.RadRoutedEventArgs)

        'GrdMain.Visibility = Visibility.Visible
        Context.Panel = "| Panel de Modelos"
    End Sub
End Class
