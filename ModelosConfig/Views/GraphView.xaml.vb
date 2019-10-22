Imports System.Windows.Forms
Imports System.Windows.Forms.Integration

Public Class GraphView
    Private _main As Object
    Private _tchart As Steema.TeeChart.TChart
    Private _c As Steema.TeeChart.ChartController
    Private _wfh As WindowsFormsHost
    Private _usr As Object
    Private _cont As Object
    'Private tbl As TableLayoutPanel

    Sub New(ByVal tbl As TableLayoutPanel, tchart As Steema.TeeChart.TChart, c As Steema.TeeChart.ChartController, ByVal Main As Object) 'ByVal TChart As Steema.TeeChart.TChart

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        'Me._main = MainByVal Cont As WindowsFormsHost, ByVal TChart As Steema.TeeChart.TChart
        _tchart = tchart
        _c = c
        _wfh = New WindowsFormsHost()
        _main = Main
        ' _usr = Usr
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _wfh.Child = crearPanel()
        'Dim host As New WindowsFormsHost()
        '' host.Child = Me

        grdMain.Children.Add(_wfh)

        ' Me.tbl = tbl
    End Sub

    Function crearPanel() As Panel
        Dim panel1 As New Panel
        '_c.Dock = DockStyle.Top
        '_tchart.Dock = DockStyle.Fill
        panel1.Controls.Add(_c)
        panel1.Controls.Add(_tchart)
        Return panel1
    End Function




    Private Sub Window_Closed(sender As Object, e As EventArgs)
        _main.AddRebobinar()
        'Me.tbl.Controls.Add(_c, 0, 0)
        'Me.tbl.Controls.Add(_tchart, 0, 1)
        'AddHandler _tchart.MouseDoubleClick, AddressOf _main.ShowDetails

        ' _usr.Child = _usr
        ' grdMain.Children.Remove(_wfh)
        'Me.wfhGraph.Child

        '_cont.Parent = _usr

        'AddHandler _chart.MouseDoubleClick, AddressOf _main.ShowDetails
    End Sub
End Class
