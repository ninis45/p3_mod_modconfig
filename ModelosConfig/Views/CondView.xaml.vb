Public Class CondView
    Private ContextCond As CondViewModel
    Sub New(ByVal IdAgujero As String, ByVal LiftMethod As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ContextCond = New CondViewModel(IdAgujero, LiftMethod)

        Select Case LiftMethod
            Case 1
                'ContextCond.LoadBN(wfhPres, wfhGas)
            Case 2
                'ContextCond.LoadBEC(wfhPres, wfhPump)
        End Select

        Me.DataContext = ContextCond
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

End Class
