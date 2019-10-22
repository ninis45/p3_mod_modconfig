Public Class grfWc
    Private Sub ShowDetails(sender As Object, e As EventArgs) Handles TChart1.MouseDoubleClick 'Handles MyBase.DoubleClick
        RemoveHandler TChart1.MouseDoubleClick, AddressOf ShowDetails
        Dim details As New GraphView(TableLayoutPanel1, TChart1, ChartController1, Me)
        details.ShowDialog()

    End Sub
    Sub AddRebobinar()
        Me.TableLayoutPanel1.Controls.Add(ChartController1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(TChart1, 0, 1)
        AddHandler TChart1.MouseDoubleClick, AddressOf ShowDetails
    End Sub
End Class
