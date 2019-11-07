Imports System.Windows.Forms.Integration
Imports ModeloCI
Imports Telerik.Windows.Controls

Public Class CondViewModel
    Inherits ViewModelBase

    Public grfGas As New grfGas()
    Public grfDiag As New grfDiag()


    Private db As New Entities_ModeloCI()

    Sub New(ByVal IdAgujero As String, ByVal LiftMethod As Integer)

        Me.LiftMethod = LiftMethod
        QuickLook = New Dictionary(Of Integer, ObjectModel.ObservableCollection(Of Series))

        Gas = New Dictionary(Of Integer, ObjectModel.ObservableCollection(Of Series))

        Me.VwModPozo = (From p In db.VW_MOD_POZO Where p.IDAGUJERO = IdAgujero And p.FUNCION = 2 And p.FECHAMODELO = (db.VW_MOD_POZO.Where(Function(w) w.IDAGUJERO = IdAgujero And w.FUNCION = 2).Max(Function(m) m.FECHAMODELO)) Select p).SingleOrDefault()




    End Sub



    Sub LoadBN(ByVal WfhPres As WindowsFormsHost, ByVal WfhGas As WindowsFormsHost)
        WfhGas.Child = grfGas
    End Sub
    Sub LoadBEC(ByVal WfhPres As WindowsFormsHost, ByVal WfhGas As WindowsFormsHost)
        WfhGas.Child = grfGas
        WfhPres.Child = grfDiag


    End Sub
#Region "Variables"
    Private _vw_mod_pozo As VW_MOD_POZO
    Public Property VwModPozo As VW_MOD_POZO
        Get
            Return _vw_mod_pozo
        End Get
        Set(value As VW_MOD_POZO)
            _vw_mod_pozo = value





            If _vw_mod_pozo IsNot Nothing Then
                Titulo = "Última condición de operación: " + _vw_mod_pozo.FECHAMODELO.ToString()
                Dim Diagnosticos = db.VW_DIAGNOSTICOS.Where(Function(w) w.IDMODPOZO = _vw_mod_pozo.IDMODPOZO).ToList()
                Dim Comportamientos = db.VW_GAS.Where(Function(w) w.IDMODPOZO = _vw_mod_pozo.IDMODPOZO).ToList()
                ModPozoQuick = db.MOD_POZO_QUICK.Where(Function(w) w.IDMODPOZO = _vw_mod_pozo.IDMODPOZO).SingleOrDefault()

                Select Case LiftMethod
                    Case 1
                        QuickLook.Add(0, New ObjectModel.ObservableCollection(Of Series)())
                        QuickLook.Add(1, New ObjectModel.ObservableCollection(Of Series)())
                        QuickLook.Add(2, New ObjectModel.ObservableCollection(Of Series)())
                        QuickLook.Add(3, New ObjectModel.ObservableCollection(Of Series)())
                        QuickLook.Add(4, New ObjectModel.ObservableCollection(Of Series)())

                        Gas.Add(0, New ObjectModel.ObservableCollection(Of Series))
                        Gas.Add(1, New ObjectModel.ObservableCollection(Of Series) From {
                                New Series() With {.Xaux = ModPozoQuick.QGI.GetValueOrDefault(), .Yaux = ModPozoQuick.QLIQ.GetValueOrDefault()}
                        })

                        'New Series() With {.Xaux = _mod_pozo_quick.QGI.GetValueOrDefault(), .Yaux = _mod_pozo_quick.QLIQ.GetValueOrDefault()}
                        If Diagnosticos.Count > 0 Then
                            For Each Di In Diagnosticos.Where(Function(w) w.TITULO = "Abajo - Arriba")
                                QuickLook(0).Add(New Series() With {.Xaux = Di.XAUX, .Yaux = Di.YAUX})
                            Next
                            For Each Di In Diagnosticos.Where(Function(w) w.TITULO = "Arriba - Abajo")
                                QuickLook(1).Add(New Series() With {.Xaux = Di.XAUX, .Yaux = Di.YAUX})
                            Next
                            For Each Di In Diagnosticos.Where(Function(w) w.TITULO = "Presión en la TR")
                                QuickLook(2).Add(New Series() With {.Xaux = Di.XAUX, .Yaux = Di.YAUX})
                            Next
                            For Each Di In Diagnosticos.Where(Function(w) w.TITULO = "Ptr teorica")
                                QuickLook(3).Add(New Series() With {.Xaux = Di.XAUX, .Yaux = Di.YAUX})
                            Next
                            For Each Di In Diagnosticos.Where(Function(w) w.TITULO = "Temperatura")
                                QuickLook(4).Add(New Series() With {.Xaux = Di.XAUX, .Yaux = Di.YAUX})
                            Next
                        End If

                        If Comportamientos.Count > 0 Then
                            For Each Dets In Comportamientos
                                Gas(0).Add(New Series() With {.Xaux = Dets.XAUX, .Yaux = Dets.YAUX})
                            Next
                        End If


                    Case 2
                        '40 Hz
                        QuickLook.Add(0, New ObjectModel.ObservableCollection(Of Series)())
                        QuickLook.Add(1, New ObjectModel.ObservableCollection(Of Series)())
                        QuickLook.Add(2, New ObjectModel.ObservableCollection(Of Series)())

                        '40 Hz, 50 Hz, 60 Hz, 70 Hz
                        Gas.Add(0, New ObjectModel.ObservableCollection(Of Series))
                        Gas.Add(1, New ObjectModel.ObservableCollection(Of Series))
                        Gas.Add(2, New ObjectModel.ObservableCollection(Of Series))
                        Gas.Add(3, New ObjectModel.ObservableCollection(Of Series))

                        'Rango minimo, maximo y eficiencia
                        Gas.Add(4, New ObjectModel.ObservableCollection(Of Series))
                        Gas.Add(5, New ObjectModel.ObservableCollection(Of Series))
                        Gas.Add(6, New ObjectModel.ObservableCollection(Of Series))

                        Gas.Add(7, New ObjectModel.ObservableCollection(Of Series) From {
                                New Series() With {.Xaux = ModPozoQuick.BC_PRATE, .Yaux = ModPozoQuick.BC_PHEAD}
                        })

                        If Comportamientos.Count > 0 Then
                            For Each Dets In Comportamientos.Where(Function(w) w.TITULO = "40 Hz").ToList()
                                Gas(0).Add(New Series() With {.Xaux = Dets.XAUX, .Yaux = Dets.YAUX})
                            Next
                            For Each Dets In Comportamientos.Where(Function(w) w.TITULO = "50 Hz").ToList()
                                Gas(1).Add(New Series() With {.Xaux = Dets.XAUX, .Yaux = Dets.YAUX})
                            Next
                            For Each Dets In Comportamientos.Where(Function(w) w.TITULO = "60 Hz").ToList()
                                Gas(2).Add(New Series() With {.Xaux = Dets.XAUX, .Yaux = Dets.YAUX})
                            Next
                            For Each Dets In Comportamientos.Where(Function(w) w.TITULO = "70 Hz").ToList()
                                Gas(3).Add(New Series() With {.Xaux = Dets.XAUX, .Yaux = Dets.YAUX})
                            Next


                            For Each Dets In Comportamientos.Where(Function(w) w.TITULO = "Rango Mínimo" And w.XAUX > 0).ToList()
                                Gas(4).Add(New Series() With {.Xaux = Dets.XAUX, .Yaux = Dets.YAUX})
                            Next
                            For Each Dets In Comportamientos.Where(Function(w) w.TITULO = "Rango Máximo" And w.XAUX > 0).ToList()
                                Gas(5).Add(New Series() With {.Xaux = Dets.XAUX, .Yaux = Dets.YAUX})
                            Next
                            For Each Dets In Comportamientos.Where(Function(w) w.TITULO = "Mejor Eficiencia" And w.XAUX > 0).ToList()
                                Gas(6).Add(New Series() With {.Xaux = Dets.XAUX, .Yaux = Dets.YAUX})
                            Next
                        End If

                        If Diagnosticos.Count > 0 Then
                            For Each Di In Diagnosticos.Where(Function(w) w.TITULO = "Abajo - Arriba")
                                QuickLook(0).Add(New Series() With {.Xaux = Di.XAUX, .Yaux = Di.YAUX})
                            Next
                            For Each Di In Diagnosticos.Where(Function(w) w.TITULO = "Arriba - Abajo")
                                QuickLook(1).Add(New Series() With {.Xaux = Di.XAUX, .Yaux = Di.YAUX})
                            Next
                            For Each Di In Diagnosticos.Where(Function(w) w.TITULO = "Temp [°C]")
                                QuickLook(2).Add(New Series() With {.Xaux = Di.XAUX, .Yaux = Di.YAUX})
                            Next
                        End If

                    Case Else

                End Select





            End If



            OnPropertyChanged("VwModPozo")
        End Set
    End Property


    Private _lift_method As Integer
    Public Property LiftMethod As Integer
        Get
            Return _lift_method
        End Get
        Set(value As Integer)
            _lift_method = value
            OnPropertyChanged("LiftMethod")
        End Set
    End Property


    Private _mod_pozo_quick As MOD_POZO_QUICK
    Public Property ModPozoQuick As MOD_POZO_QUICK
        Get
            Return _mod_pozo_quick
        End Get
        Set(value As MOD_POZO_QUICK)
            _mod_pozo_quick = value

            'If _mod_pozo_quick IsNot Nothing Then
            '    'SGasPoint = New ObjectModel.ObservableCollection(Of Series)() From {
            '    '    New Series() With {.Xaux = _mod_pozo_quick.QGI.GetValueOrDefault(), .Yaux = _mod_pozo_quick.QLIQ.GetValueOrDefault()}
            '    '}
            'End If

            OnPropertyChanged("ModPozoQuick")
        End Set
    End Property


    Private _gas As Dictionary(Of Integer, ObjectModel.ObservableCollection(Of Series))
    Public Property Gas As Dictionary(Of Integer, ObjectModel.ObservableCollection(Of Series))
        Get
            Return _gas
        End Get
        Set(value As Dictionary(Of Integer, ObjectModel.ObservableCollection(Of Series)))
            _gas = value

            OnPropertyChanged("Gas")
        End Set
    End Property

    Private _quick_look As Dictionary(Of Integer, ObjectModel.ObservableCollection(Of Series))
    Public Property QuickLook As Dictionary(Of Integer, ObjectModel.ObservableCollection(Of Series))
        Get
            Return _quick_look
        End Get
        Set(value As Dictionary(Of Integer, ObjectModel.ObservableCollection(Of Series)))
            _quick_look = value
            OnPropertyChanged("QuickLook")
        End Set
    End Property
    Private _sup As ObjectModel.ObservableCollection(Of Series)
    Public Property SUp As ObjectModel.ObservableCollection(Of Series)
        Get
            Return _sup
        End Get
        Set(value As ObjectModel.ObservableCollection(Of Series))
            _sup = value
            OnPropertyChanged("SUp")
        End Set
    End Property

    Private _sptrmed As ObjectModel.ObservableCollection(Of Series)
    Public Property SPtrMed As ObjectModel.ObservableCollection(Of Series)
        Get
            Return _sptrmed
        End Get
        Set(value As ObjectModel.ObservableCollection(Of Series))
            _sptrmed = value
            OnPropertyChanged("SPtrMed")
        End Set
    End Property

    Private _sptr_teo As ObjectModel.ObservableCollection(Of Series)
    Public Property SPtrTeo As ObjectModel.ObservableCollection(Of Series)
        Get
            Return _sptr_teo
        End Get
        Set(value As ObjectModel.ObservableCollection(Of Series))
            _sptr_teo = value
            OnPropertyChanged("SPtrTeo")
        End Set
    End Property
    Private _stemp As ObjectModel.ObservableCollection(Of Series)
    Public Property STemp As ObjectModel.ObservableCollection(Of Series)
        Get
            Return _stemp
        End Get
        Set(value As ObjectModel.ObservableCollection(Of Series))
            _stemp = value
            OnPropertyChanged("STemp")
        End Set
    End Property

    Private _sgas As ObjectModel.ObservableCollection(Of Series)
    Public Property SGas As ObjectModel.ObservableCollection(Of Series)
        Get
            Return _sgas
        End Get
        Set(value As ObjectModel.ObservableCollection(Of Series))
            _sgas = value
            OnPropertyChanged("SGas")
        End Set
    End Property

    Private _sgas_point As ObjectModel.ObservableCollection(Of Series)
    Public Property SGasPoint As ObjectModel.ObservableCollection(Of Series)
        Get
            Return _sgas_point
        End Get
        Set(value As ObjectModel.ObservableCollection(Of Series))
            _sgas_point = value
            OnPropertyChanged("SGasPoint")
        End Set
    End Property

    Private _titulo As String
    Public Property Titulo As String
        Get
            Return _titulo
        End Get
        Set(value As String)
            _titulo = value
            OnPropertyChanged("Titulo")
        End Set
    End Property
#End Region


End Class

Public Class Series
    Property Xaux As Double
    Property Yaux As Double
End Class
