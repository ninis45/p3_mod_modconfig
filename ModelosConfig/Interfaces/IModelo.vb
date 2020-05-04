Imports System.ServiceModel
Namespace Interfaces
    <ServiceContract(Name:="IModelo")>
    Interface IModelo

        <OperationContract>
        Function Monitor(ByRef OpenServer As String) As List(Of String)


        <OperationContract>
        Function Dispose(ByRef OpenServer As String) As Boolean

        <OperationContract>
        Function Reading(ByVal LiftMethod As Integer, ByVal FileUpload As Byte(), ByVal FileName As String) As List(Of String)
    End Interface

End Namespace

