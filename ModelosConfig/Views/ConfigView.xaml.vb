Imports System.Collections.ObjectModel
Imports System.IO
Imports System.ServiceModel
Imports ModeloCI
Imports Telerik.Windows.Controls

Public Class ConfigView


    Public ContextConfig As ConfigViewModel
    Public Tab As Integer
    Private GraphMec As UC_EstadoMecanico.EstadoMecanico
    Private GraphMec2 As UC_EstadoMecanico.EstadoMecanico
    Private EndPointModelo As EndpointAddress = New EndpointAddress(Settings.GetBy("point_modelo"))
    Sub New(ByVal IdAgujero As String, ByVal IdModPozo As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        GraphMec = New UC_EstadoMecanico.EstadoMecanico()
        GraphMec2 = New UC_EstadoMecanico.EstadoMecanico()

        ContextConfig = New ConfigViewModel(IdAgujero, IdModPozo, Me.wfhTrayectoria, Me.wfhTemperatura, Me.wfhAforos, Me.wfhPvts, Me.wfhMecanico)
        Me.DataContext = ContextConfig
        wfhMecanico2.Child = GraphMec2
        GraphMec2.BackColor = System.Drawing.Color.White
        GraphMec2.ColorAD = System.Drawing.Color.BurlyWood
        GraphMec2.ColorEmpacador = System.Drawing.Color.Orange
        GraphMec2.ColorFondoAD = System.Drawing.Color.Brown
        GraphMec2.ColorFondoTP = System.Drawing.Color.Teal
        GraphMec2.ColorFondoTR = System.Drawing.Color.Gray
        GraphMec2.ColorRetenedor = System.Drawing.Color.SlateBlue
        GraphMec2.ColorTP = System.Drawing.Color.Teal
        GraphMec2.ColorTR = System.Drawing.Color.Gray
        GraphMec2.EdoMec = New UC_EstadoMecanico.EdoMecNucleo
        GraphMec2.GrosorLineAD = 1.0!
        GraphMec2.GrosorLineaTP = 1.0!
        GraphMec2.GrosorLineTR = 1.0!
        GraphMec2.Letra = New System.Drawing.Font("Arial", 7.0!)
        GraphMec2.Location = New System.Drawing.Point(0, 0)
        GraphMec2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        GraphMec2.Name = "EstadoMecanico1"
        GraphMec2.PatronFondoAD = System.Drawing.Drawing2D.HatchStyle.Horizontal
        GraphMec2.PatronFondoTP = System.Drawing.Drawing2D.HatchStyle.Horizontal
        GraphMec2.PatronFondoTR = System.Drawing.Drawing2D.HatchStyle.LargeConfetti
        GraphMec2.Size = New System.Drawing.Size(100, 200)
        GraphMec2.TabIndex = 0
        GraphMec2.Titulos = True
        GraphMec2.Tope = 0
        GraphMec2.Limpiar()
        GraphMec2.Refresh()

        LoadMecanico(ContextConfig.IdAgujero)

    End Sub
    Sub New(ByVal IdAgujero As String, ByVal LiftMethod As Double, ByVal IdUsuario As String, ByVal FechaPrueba As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        GraphMec = New UC_EstadoMecanico.EstadoMecanico()
        GraphMec2 = New UC_EstadoMecanico.EstadoMecanico()





        ContextConfig = New ConfigViewModel(IdAgujero, LiftMethod, IdUsuario, Me.wfhTrayectoria, Me.wfhTemperatura, Me.wfhAforos, Me.wfhPvts, Me.wfhMecanico, FechaPrueba)
        ContextConfig.FormView = Me

        Me.DataContext = ContextConfig
        Me.Tab = 0

        wfhMecanico2.Child = GraphMec2
        GraphMec2.BackColor = System.Drawing.Color.White
        GraphMec2.ColorAD = System.Drawing.Color.BurlyWood
        GraphMec2.ColorEmpacador = System.Drawing.Color.Orange
        GraphMec2.ColorFondoAD = System.Drawing.Color.Brown
        GraphMec2.ColorFondoTP = System.Drawing.Color.Teal
        GraphMec2.ColorFondoTR = System.Drawing.Color.Gray
        GraphMec2.ColorRetenedor = System.Drawing.Color.SlateBlue
        GraphMec2.ColorTP = System.Drawing.Color.Teal
        GraphMec2.ColorTR = System.Drawing.Color.Gray
        GraphMec2.EdoMec = New UC_EstadoMecanico.EdoMecNucleo
        GraphMec2.GrosorLineAD = 1.0!
        GraphMec2.GrosorLineaTP = 1.0!
        GraphMec2.GrosorLineTR = 1.0!
        GraphMec2.Letra = New System.Drawing.Font("Arial", 7.0!)
        GraphMec2.Location = New System.Drawing.Point(0, 0)
        GraphMec2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        GraphMec2.Name = "EstadoMecanico1"
        GraphMec2.PatronFondoAD = System.Drawing.Drawing2D.HatchStyle.Horizontal
        GraphMec2.PatronFondoTP = System.Drawing.Drawing2D.HatchStyle.Horizontal
        GraphMec2.PatronFondoTR = System.Drawing.Drawing2D.HatchStyle.LargeConfetti
        GraphMec2.Size = New System.Drawing.Size(100, 200)
        GraphMec2.TabIndex = 0
        GraphMec2.Titulos = True
        GraphMec2.Tope = 0
        GraphMec2.Limpiar()
        GraphMec2.Refresh()

        LoadMecanico(ContextConfig.IdAgujero)


    End Sub
    Private Sub CloseConfig(sender As Object, e As RoutedEventArgs)

        Me.Close()

    End Sub
    Private Sub SetStepNext(sender As Object, e As RoutedEventArgs)



        If ContextConfig.Tab = 5 And ContextConfig.EnabledEquip = True Then
            ContextConfig.Tab += 3


        End If

        If ContextConfig.Tab = 8 And ContextConfig.LiftMethod = 2 Then
            ContextConfig.Tab += 1
        End If


        ContextConfig.Tab = ContextConfig.Tab + 1




    End Sub
    Private Sub SetStepAfter(sender As Object, e As RoutedEventArgs)

        Dim Tmp As Integer = ContextConfig.Tab - 1

        If ContextConfig.Tab = 10 And ContextConfig.LiftMethod = 2 Then
            ContextConfig.Tab -= 1

        End If

        If (ContextConfig.Tab = 9 Or ContextConfig.Tab = 10) And ContextConfig.EnabledEquip = True Then
            ContextConfig.Tab = 6
        End If

        If ContextConfig.Tab > 2 Then
            ContextConfig.Tab = ContextConfig.Tab - 1
        Else
            ContextConfig.Tab = 1
        End If


    End Sub

    Private Sub DeleteFile(sender As Object, e As RoutedEventArgs)
        ContextConfig.ModArchivo = Nothing
    End Sub

    Private Sub ClearFile(sender As Object, e As RoutedEventArgs)
        ContextConfig.NewArchivoPvt = Nothing
    End Sub
    Private Sub SelectFile(sender As Object, e As RoutedEventArgs)
        Dim Dialog As New System.Windows.Forms.OpenFileDialog()

        Dialog.Filter = "" '"All files (*.Out)|*.Out"
        'Dialog.ShowDialog()
        If Dialog.ShowDialog() = Forms.DialogResult.OK Then
            ContextConfig.NewArchivoPvt = Dialog.FileName

            If File.Exists(ContextConfig.NewArchivoPvt) Then
                ContextConfig.IsBusy = True

                Try
                    ' Dim factory = New ChannelFactory(Of Interfaces.IModelo)(New BasicHttpBinding() With {.SendTimeout = TimeSpan.Parse("0:30:00"), .MaxBufferSize = 20000000, .MaxReceivedMessageSize = 20000000}, EndPointModelo)
                    'Dim server As Interfaces.IModelo = factory.CreateChannel()

                    'Dim result = server.Monitor("OpenServer")
                    'Dim Errors As List(Of String)
                    Task.Factory.StartNew(Function() SendPvt()).ContinueWith(Sub(r)
                                                                                 ContextConfig.IsBusy = False
                                                                                 If r.IsCompleted Then

                                                                                     Dim Errors = r.Result
                                                                                     If Errors.Count > 0 Then
                                                                                         Dim StrErrors As String = ""
                                                                                         For i = 0 To Errors.Count - 1
                                                                                             'ContextConfig.Errors.Add(Errors(i))
                                                                                             StrErrors += " - " + Errors(i) & Chr(13)
                                                                                         Next

                                                                                         If StrErrors <> "" Then
                                                                                             MessageBox.Show(StrErrors, "Campos inteligentes", MessageBoxButton.OK, MessageBoxImage.Error)
                                                                                             ContextConfig.NewArchivoPvt = Nothing
                                                                                         End If


                                                                                     End If



                                                                                     'ContextConfig.Errors = CType(Errors,List(Of String))
                                                                                     'ContextConfig.Errors.Add(Errors(0))
                                                                                 End If

                                                                             End Sub, TaskScheduler.FromCurrentSynchronizationContext)
                    'Dim result = server.Reading(File.ReadAllBytes(ContextConfig.NewArchivoPvt), ContextConfig.NewArchivoPvt)
                Catch ex As Exception
                    ContextConfig.IsBusy = False
                    MessageBox.Show(ex.Message, "Campos inteligentes", MessageBoxButton.OK, MessageBoxImage.Warning)
                End Try

            End If
        End If

    End Sub
    Private Function SendPvt() As List(Of String)
        Dim httpBinding As New BasicHttpBinding() With {
            .SendTimeout = TimeSpan.Parse("1:30:00"),
            .MaxBufferSize = 2147483647,
            .MaxReceivedMessageSize = 2147483647,
            .MaxBufferPoolSize = 2147483647,
            .MessageEncoding = WSMessageEncoding.Text,
            .TransferMode = TransferMode.Streamed
        }
        httpBinding.ReaderQuotas.MaxDepth = 128
        httpBinding.ReaderQuotas.MaxStringContentLength = 2147483647
        httpBinding.ReaderQuotas.MaxArrayLength = 2147483647
        httpBinding.ReaderQuotas.MaxBytesPerRead = 2147483647

        'httpBinding.Security.Mode = BasicHttpSecurityMode.None
        'httpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None
        'httpBinding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None
        'httpBinding.Security.Transport.Realm = ""
        'httpBinding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName
        'httpBinding.Security.Message.AlgorithmSuite = Security.SecurityAlgorithmSuite.Default


        Dim factory = New ChannelFactory(Of Interfaces.IModelo)(httpBinding, EndPointModelo)
        Dim server As Interfaces.IModelo = factory.CreateChannel()
        Try
            ''Dim BytesSend = File.RewArchiadAllBytes(ContextConfig.NevoPvt)
            Return server.Reading(ContextConfig.LiftMethod, File.ReadAllBytes(ContextConfig.NewArchivoPvt), ContextConfig.NewArchivoPvt)
        Catch ex As Exception
            MessageBox.Show(ex.Message & Chr(13) & "El archivo PVT(.Out) no pudo ser verificado y validado.", "Campos inteligentes", MessageBoxButton.OK, MessageBoxImage.Warning)
            'MessageBox.Show("El archivo PVT(.Out) no pudo ser verificado y validado.", "Campos inteligentes", MessageBoxButton.OK, MessageBoxImage.Warning)
            'Return New List(Of String) From {ex.Message}
        End Try

        Return New List(Of String)
    End Function

    Private Sub LoadMecanico(ByVal IdAgujero As String)
        Dim db As New Entities_ModeloCI()

        Dim tipos = db.CAT_TIPO_TUBERIA.ToDictionary(Function(d) d.NUMERO, Function(d) d.IDTIPOTUBERIA)
        Dim tps = db.VW_TP.Where(Function(w) w.IDAGUJERO = IdAgujero).ToList()
        Dim trs = db.VW_TR.Where(Function(w) w.IDAGUJERO = IdAgujero).ToList()
        GraphMec.Limpiar()
        If trs.Count > 0 Then

            GraphMec.BackColor = System.Drawing.Color.White
            GraphMec.ColorAD = System.Drawing.Color.BurlyWood
            GraphMec.ColorEmpacador = System.Drawing.Color.Orange
            GraphMec.ColorFondoAD = System.Drawing.Color.Brown
            GraphMec.ColorFondoTP = System.Drawing.Color.Teal
            GraphMec.ColorFondoTR = System.Drawing.Color.Gray
            GraphMec.ColorRetenedor = System.Drawing.Color.SlateBlue
            GraphMec.ColorTP = System.Drawing.Color.Teal
            GraphMec.ColorTR = System.Drawing.Color.Gray
            GraphMec.EdoMec = New UC_EstadoMecanico.EdoMecNucleo
            GraphMec.GrosorLineAD = 1.0!
            GraphMec.GrosorLineaTP = 1.0!
            GraphMec.GrosorLineTR = 1.0!
            GraphMec.Letra = New System.Drawing.Font("Arial", 7.0!)
            GraphMec.Location = New System.Drawing.Point(0, 0)
            GraphMec.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            GraphMec.Name = "EstadoMecanico1"
            GraphMec.PatronFondoAD = System.Drawing.Drawing2D.HatchStyle.Horizontal
            GraphMec.PatronFondoTP = System.Drawing.Drawing2D.HatchStyle.Horizontal
            GraphMec.PatronFondoTR = System.Drawing.Drawing2D.HatchStyle.LargeConfetti
            GraphMec.Size = New System.Drawing.Size(100, 200)
            GraphMec.TabIndex = 0
            GraphMec.Titulos = True
            GraphMec.Tope = 0
            GraphMec.Limpiar()


            For Each tr In trs
                If tr.COMPONENTE.Contains("AGUJERO DESCUBIERTO") Then
                    GraphMec.agregaAgujeroDescubierto(tr.DIAMEXT.GetValueOrDefault(), tr.PROFUNDIDADINICIO + ((tr.PROFUNDIDADFIN - tr.PROFUNDIDADINICIO) / 2))
                Else
                    GraphMec.agregaTR(tr.DIAMEXT, tr.DIAMINT.GetValueOrDefault(), tr.PROFUNDIDADINICIO, tr.PROFUNDIDADFIN, tr.TITULO, tr.DIAMETRONOMINAL, "")
                End If
            Next
            For Each tp In tps
                GraphMec.agregaTP(tp.DIAMEXT, tp.DIAMEXT, tp.PROFUNDIDAD, tp.TITULO, tp.TITULO, tp.DIAMETRONOMINAL, tp.TITULO)
            Next




            GraphMec.Refresh()

        End If

        wfhMecanico.Child = GraphMec


    End Sub

    Private Sub LoadMecanico2(ByVal IdAgujero As String)
        Dim db As New Entities_ModeloCI()

        Dim tipos = db.CAT_TIPO_TUBERIA.ToDictionary(Function(d) d.NUMERO, Function(d) d.IDTIPOTUBERIA)

        Dim ADes = ContextConfig.ModMecanicos.Where(Function(w) w.ModPozoTuberia.IDTIPOTUBERIA = tipos(4) And w.ModPozoTuberia.ETIQUETA.Contains("AGUJERO DESCUBIERTO")).OrderBy(Function(o) o.ModPozoTuberia.MD).ToList()
        Dim Trs = ContextConfig.ModMecanicos.Where(Function(w) w.ModPozoTuberia.IDTIPOTUBERIA = tipos(4)).OrderBy(Function(o) o.ModPozoTuberia.MD).ToList()
        Dim Tps = ContextConfig.ModMecanicos.Where(Function(w) w.ModPozoTuberia.IDTIPOTUBERIA = tipos(1)).OrderBy(Function(o) o.ModPozoTuberia.MD).ToList()

        GraphMec2.Limpiar()

        If Trs.Count > 0 Then



            Dim inc As Integer = 0
            For i = 0 To Trs.Count - 1

                'Dim Cidiam As Double = Trs(i).ModPozoTuberia.CIDIAM.GetValueOrDefault()
                Dim Diam = Trs(i).ModPozoTuberia ' Trs(i).ModPozoTuberia.TIDIAM ''(From det In db.TR_DETALLE Join img In db.CAT_TR_IMAGEN On det.IDCATTRIMAGEN Equals img.IDCATTRIMAGEN Where det.DIAMINT = Math.Round(Cidiam, 2) And img.COMPONENTE.Contains("TUBERIA DE REVESTIMIENTO") Select det).SingleOrDefault '.Where(Function(w) w.DIAMINT = Trs(i).ModPozoTuberia.CIDIAM And w.COMPONENTE.Contains("TUBERIA DE REVESTIMIENTO")).SingleOrDefault()



                ' If Diam Is Nothing Then Diam = New TR_DETALLE()


                If Trs(i).ModPozoTuberia.ETIQUETA.Contains("AGUJERO DESCUBIERTO") Then
                    ' GraphMec2.agregaAgujeroDescubierto(IIf(Diam.DIAMEXT Is Nothing, 1, Diam.DIAMEXT), Trs(i).ModPozoTuberia.MD)
                Else
                    If inc = 0 Then
                        GraphMec2.agregaTR(IIf(Trs(i).ModPozoTuberia.CIDIAM.GetValueOrDefault() > 0, Trs(i).ModPozoTuberia.CIDIAM.GetValueOrDefault(), 1), IIf(Diam.CIDIAM Is Nothing, 1, Diam.CIDIAM), 0, Trs(i).ModPozoTuberia.MD, Trs(i).ModPozoTuberia.ETIQUETA, IIf(Diam.ETIQUETA Is Nothing, "ND", Diam.ETIQUETA), "Forma")
                    Else
                        GraphMec2.agregaTR(IIf(Trs(i).ModPozoTuberia.CIDIAM.GetValueOrDefault() > 0, Trs(i).ModPozoTuberia.CIDIAM.GetValueOrDefault(), 1), IIf(Diam.CIDIAM Is Nothing, 1, Diam.CIDIAM), Trs(i - 1).ModPozoTuberia.MD, Trs(i).ModPozoTuberia.MD, Trs(i).ModPozoTuberia.ETIQUETA, IIf(Diam.ETIQUETA Is Nothing, "ND", Diam.ETIQUETA), "Forma")
                    End If

                    inc += 1

                End If












            Next
            For i = 0 To Tps.Count - 1
                'Dim Tidiam As Double = Tps(i).ModPozoTuberia.TIDIAM.GetValueOrDefault()
                'Dim Diam = (From det In db.TP Join img In db.VW_COMPONENTE On det.idTuberiaDetalle Equals img.IDCOMPONENTE Where img.diamInt = Math.Round(Tidiam, 2) And img.COMPONENTE.Contains("Tubería de Producción") Select img, det).SingleOrDefault() '.Where(Function(w) w.DIAMINT = Trs(i).ModPozoTuberia.CIDIAM And w.COMPONENTE.Contains("TUBERIA DE REVESTIMIENTO")).SingleOrDefault()

                ' If Diam Is Nothing Then Diam = New TP()

                'If Diam IsNot Nothing Then GraphMec2.agregaTP(Tps(i).ModPozoTuberia.TODIAM, Tps(i).ModPozoTuberia.TIDIAM, Tps(i).ModPozoTuberia.MD, Tps(i).ModPozoTuberia.ETIQUETA, Tps(i).ModPozoTuberia.ETIQUETA, IIf(Diam.det.diamExt, "ND", Diam.det.diamExt), "Forma")

                GraphMec2.agregaTP(Tps(i).ModPozoTuberia.TODIAM, Tps(i).ModPozoTuberia.TIDIAM, Tps(i).ModPozoTuberia.MD, Tps(i).ModPozoTuberia.ETIQUETA, Tps(i).ModPozoTuberia.ETIQUETA, Tps(i).ModPozoTuberia.TODIAM.GetValueOrDefault(), "Forma")
            Next


            GraphMec2.Refresh()
        End If

    End Sub

    Private Sub MenuItemListado(sender As Object, e As RoutedEventArgs)
        grdListado.Visibility = Visibility.Visible
    End Sub
    Private Sub MenuItemMecanico(sender As Object, e As RoutedEventArgs)
        grdListado.Visibility = Visibility.Collapsed
        'LoadMecanico(ContextConfig.IdAgujero)
        LoadMecanico2(ContextConfig.IdAgujero)
    End Sub

    Private Sub DownloadFile(sender As Object, e As RoutedEventArgs)
        Dim stream As Stream
        Dim saveFileDialog As New System.Windows.Forms.SaveFileDialog()
        Dim FileNames = ContextConfig.ModArchivo.nombreArchivo.Split("\".ToCharArray())
        saveFileDialog.Filter = "All files (*.Out)|*.Out"
        saveFileDialog.FileName = FileNames(FileNames.Count - 1)




        If saveFileDialog.ShowDialog() = Forms.DialogResult.OK Then
            File.WriteAllBytes(saveFileDialog.FileName, ContextConfig.ModArchivo.archivo)
            'Dim file As System.IO.FileStream = CType(saveFileDialog.OpenFile(), System.IO.FileStream)
            'Dim str As StreamWriter = New StreamWriter(saveFileDialog.FileName)

            'Str.Write(ContextConfig.ModArchivo.archivo)
            '' file.Write(ContextConfig.ModArchivo.archivo)

            ''File.WriteAllBytes(saveFileDialog.FileName, ContextConfig.ModArchivo.archivo)
            'Using (StreamWriter sw = New StreamWriter(savefile.FileName))

            'Dim sw As StreamWriter = New StreamWriter(saveFileDialog.FileName)
            'sw.WriteLine(ContextConfig.ModArchivo.archivo)

        End If
    End Sub


End Class
