Imports System.ServiceModel

Namespace Interfaces
    <ServiceContract(Name:="IService1")>
    Interface IDeclinacion

        <OperationContract>
        Function GethastPreTemModelo(ByVal fecha As DateTime, ByVal Idagujero As String, ByVal NiveMlP_mV As Double) As Dictionary(Of String, Double)


    End Interface
End Namespace

