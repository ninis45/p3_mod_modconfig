Imports System.Collections.ObjectModel
Imports ModeloCI
Imports Telerik.Windows.Controls

Public Class ConfigView


    Public ContextConfig As ConfigViewModel

    Sub New(ByVal IdAgujero As String, ByVal LiftMethod As Double, ByVal Errors As ObservableCollection(Of ModelosEstabilidad.FlashData), ByVal FechaPrueba As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ContextConfig = New ConfigViewModel(IdAgujero, LiftMethod, Errors, Me.wfhTrayectoria, Me.wfhTemperatura, Me.wfhAforos, Me.wfhPvts, FechaPrueba)
        ContextConfig.FormView = Me
        Me.DataContext = ContextConfig

    End Sub
    Private Sub CloseConfig(sender As Object, e As RoutedEventArgs)

        Me.Close()

    End Sub

    Shadows Sub Closing(ByVal ContextMain As MainViewModel, ByVal ContextConfig As ConfigViewModel)
        Dim db As New Entities_ModeloCI()



        ContextMain.IdModPozo = ContextConfig.IdModPozo

    End Sub

    Private Sub TextBox_TextChanged(sender As Object, e As TextChangedEventArgs)

    End Sub

    Private Sub ComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)

    End Sub
    Private Sub DeleteFile(sender As Object, e As RoutedEventArgs)
        ContextConfig.ModArchivo = Nothing
    End Sub
    Private Sub OpenDialogBEC(sender As Object, e As RoutedEventArgs)
        Dim Dialog As New RadOpenFileDialog()
        'File.Owner = Owner
        Dialog.Filter = "All files (*.Out)|*.Out"
        Dialog.ShowDialog()

        If Dialog.DialogResult = True Then
            ContextConfig.FileBEC = Dialog.FileName

        End If
    End Sub
End Class
