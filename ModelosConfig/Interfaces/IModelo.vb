Imports System.ServiceModel
Namespace Interfaces
    <ServiceContract(Name:="IModelo")>
    Interface IModelo

        <OperationContract>
        Function Monitor(ByRef OpenServer As String) As List(Of String)

        <OperationContract>
        Function Reading(ByVal FileUpload As Byte(), ByVal FileName As String) As List(Of String)
    End Interface

End Namespace

