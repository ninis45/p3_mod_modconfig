Class MainWindow

    Dim Context As MainViewModel
    Private SelectedMod As Integer = 0

    Sub New(ByVal IdAgujero As String, ByVal Fecha As String, ByVal IdUsuario As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        'Dim estabilidad As New ModelosEstabilidad.Main() 'Verificar si se puede cambiar al Contexto

        Context = New MainViewModel(IdAgujero, Fecha, IdUsuario)
        Me.DataContext = Context

        Context.Initialize(hstProductividad, hstCorrelacion, hstVpl, hstGas, hstDiag, hstWc)

        btnAfter.IsEnabled = False
        btnBefore.IsEnabled = False


        If Context.Estatus = 3 Then
            SelectedMod = Context.Modelos.Count - 1
            If Context.Modelos.Count > 1 Then
                btnAfter.IsEnabled = True
            End If
        Else
            If Context.Modelos.Count > 1 Then
                btnBefore.IsEnabled = True
            End If
        End If



    End Sub
    Public Sub actualizar(ByVal IdAgujero As String, ByVal Fecha As String, ByVal IdUsuario As String)




        Context.IdAgujero = IdAgujero
        Context.FechaPrueba = Fecha
        Context.IdUsuario = IdUsuario

        btnAfter.IsEnabled = False
        btnBefore.IsEnabled = False
        If Context.Estatus = 3 Then
            SelectedMod = Context.Modelos.Count - 1
            If Context.Modelos.Count > 1 Then
                btnAfter.IsEnabled = True
            End If
        Else
            If Context.Modelos.Count > 1 Then
                btnBefore.IsEnabled = True
            End If
        End If

    End Sub

    Private Sub SetConfig(sender As Object, e As RoutedEventArgs)
        Dim db As New ModeloCI.Entities_ModeloCI()
        Try
            Dim ConfigView As New ConfigView(Context.IdAgujero, Context.LiftMethod, Context.IdUsuario, Context.FechaPrueba)


            ConfigView.ShowDialog()
            'Dim ModModel As New ModModel(Context.IdAgujero, Context.IdUsuario)

            If ConfigView.ContextConfig.IsSaved Then
                Context.IdModPozo = ConfigView.ContextConfig.IdModPozo 'Revisar para que no haya doble consulta en VWGeneral
                Context.VwGeneral = db.VW_EDO_GENERAL.Where(Function(w) w.IDMODPOZO = ConfigView.ContextConfig.IdModPozo).SingleOrDefault()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try



    End Sub

    Private Sub ShowConfig(sender As Object, e As RoutedEventArgs)
        Dim db As New ModeloCI.Entities_ModeloCI()
        Dim ConfigView As New ConfigView(Context.IdAgujero, Context.IdModPozo)


        ConfigView.ShowDialog()
        'Dim ModModel As New ModModel(Context.IdAgujero, Context.IdUsuario)

        'If ConfigView.ContextConfig.IsSaved Then
        '    Context.IdModPozo = ConfigView.ContextConfig.IdModPozo 'Revisar para que no haya doble consulta en VWGeneral
        '    Context.VwGeneral = db.VW_EDO_GENERAL.Where(Function(w) w.IDMODPOZO = ConfigView.ContextConfig.IdModPozo).SingleOrDefault()
        'End If


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

    Private Sub OpenCond(sender As Object, e As MouseButtonEventArgs)
        Dim GridView As Telerik.Windows.Controls.RadGridView = sender
        Dim VwModPozo As ModeloCI.VW_MOD_POZO = GridView.SelectedItem

        Dim CondView As New CondView(VwModPozo.IDMODPOZO)


        CondView.ShowDialog()
    End Sub

    Private Sub BtnAfter_Click(sender As Object, e As RoutedEventArgs) Handles btnAfter.Click
        SelectedMod -= 1
        btnBefore.IsEnabled = True
        If SelectedMod <= 0 Then
            SelectedMod = 0
            btnAfter.IsEnabled = False

        Else
            btnAfter.IsEnabled = True
        End If
        Context.IdModPozo = Context.Modelos(SelectedMod).IDMODPOZO
    End Sub

    Private Sub BtnBefore_Click(sender As Object, e As RoutedEventArgs) Handles btnBefore.Click
        SelectedMod += 1
        btnAfter.IsEnabled = True
        If SelectedMod > Context.Modelos.Count - 2 Then
            SelectedMod = Context.Modelos.Count - 1
            btnBefore.IsEnabled = False
        Else
            btnBefore.IsEnabled = True
        End If
        Context.IdModPozo = Context.Modelos(SelectedMod).IDMODPOZO
    End Sub

    Private Sub BtnCopy_Click(sender As Object, e As RoutedEventArgs) Handles btnCopy.Click
        Dim db As New ModeloCI.Entities_ModeloCI()
        Try
            Dim ConfigView As New ConfigView(Context.IdAgujero, Context.IdModPozo)

            ConfigView.Title = "Copiar configuracion "
            ConfigView.ShowDialog()


            'If ConfigView.ContextConfig.IsSaved Then
            '    Context.IdModPozo = ConfigView.ContextConfig.IdModPozo 'Revisar para que no haya doble consulta en VWGeneral
            '    Context.VwGeneral = db.VW_EDO_GENERAL.Where(Function(w) w.IDMODPOZO = ConfigView.ContextConfig.IdModPozo).SingleOrDefault()
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub

    Private Sub BtnNew_Click(sender As Object, e As RoutedEventArgs) Handles btnNew.Click
        Dim db As New ModeloCI.Entities_ModeloCI()
        Try
            Dim ConfigView As New ConfigView(Context.IdAgujero, Context.LiftMethod, Context.IdUsuario, Context.FechaPrueba)


            ConfigView.ShowDialog()


            'If ConfigView.ContextConfig.IsSaved Then
            '    Context.IdModPozo = ConfigView.ContextConfig.IdModPozo 'Revisar para que no haya doble consulta en VWGeneral
            '    Context.VwGeneral = db.VW_EDO_GENERAL.Where(Function(w) w.IDMODPOZO = ConfigView.ContextConfig.IdModPozo).SingleOrDefault()
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try
    End Sub

    Private Sub BtnView_Click(sender As Object, e As RoutedEventArgs) Handles btnView.Click
        Dim db As New ModeloCI.Entities_ModeloCI()
        Dim ConfigView As New ConfigView(Context.IdAgujero, Context.IdModPozo)

        ConfigView.ContextConfig.IsReadOnly = True


        ConfigView.ShowDialog()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As RoutedEventArgs) Handles btnRefresh.Click
        Context.IdAgujero = Context.IdAgujero
        btnAfter.IsEnabled = False
        btnBefore.IsEnabled = False
        If Context.Estatus = 3 Then
            SelectedMod = Context.Modelos.Count - 1
            If Context.Modelos.Count > 1 Then
                btnAfter.IsEnabled = True
            End If
        Else
            If Context.Modelos.Count > 1 Then
                btnBefore.IsEnabled = True
            End If
        End If
    End Sub
End Class
