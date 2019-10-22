Imports System.Windows.Forms.Integration

Public Class grfCorrelacion
    Private Sub ShowDetails(sender As Object, e As Forms.MouseEventArgs) Handles TChart1.MouseDoubleClick

        'Dim chart As Steema.TeeChart.TChart = CType(sender, Steema.TeeChart.TChart)

        ' Dim fh = Me.Parent

        RemoveHandler TChart1.MouseDoubleClick, AddressOf ShowDetails
        Dim details As New GraphView(TableLayoutPanel1, TChart1, ChartController1, Me)
        details.ShowDialog()

        '' Dim host As WindowsFormsHost = CType(Me.Parent, WindowsFormsHost)

        'Dim host As New WindowsFormsHost()
        'host.Child = Me
        'details.grdMain.Children.Add(host)



        'Dim dep As DependencyObject = CType(sender, DependencyObject)

        'While 
        'DependencyObject dep = (DependencyObject)e.OriginalSource;
        '    While ((dep!= null) && !(dep Is GridViewCell))
        '    {
        '        dep = VisualTreeHelper.GetParent(dep);
        '    }
        '    If (dep Is GridViewCell) Then
        '                    {

        '    }

        'RemoveHandler chart.MouseDoubleClick, AddressOf ShowDetails

        ' details.grdMain ' chart.Parent.Parent

        'details.grdMain.Children.Remove(host)


        'Me.Parent = host.Child


        'details.Close()
    End Sub

    Sub AddRebobinar()
        Me.TableLayoutPanel1.Controls.Add(ChartController1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(TChart1, 0, 1)
        AddHandler TChart1.MouseDoubleClick, AddressOf ShowDetails
    End Sub

End Class
