Public Class Form1
    Public window As ModelosConfig.MainWindow

    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().2019-03-27 13:31:05.157
        'DDB3A31F-0143-42E3-819B-9B4A4B631D33", "2019-03-27" Ayatzil 119
        '3C715081-51AE-4EB0-A2AC-714DBD55E303, "2019-05-16" Rabasa  124

        'A97B64BE-A958-40BF-80F6-6A4B0B67B87A  , "2018-08-03" RABASA 125
        '3E0083D2-9542-4296-A089-1012D0DFFB65  , "2019-06-03" RABAZA 127
        '9DD46D9A-C775-4B7C-9F11-54F43E5140C1 , RABASA 122
        '"56B74925-CE90-4E2D-8FAC-9933EBC4899D","2018-01-02"              KU-288
        'D26520B4-EE15-4D2E-A1B8-A1D782DEA4A7,  EK 101
        '10BE3254-304F-45F0-B86D-8184EDCAE730   AYATSIL 133 2019-03-25
        '508FE906-74C0-4290-BB3F-D2F719B10F47   MAALOB 492D   09/02/2019
        '2F9C28FD-FAAB-4835-96AC-18A838BBF960   ZAAP10  2019-02-09     





        window = New ModelosConfig.MainWindow("DDB3A31F-0143-42E3-819B-9B4A4B631D33", "2019-02-09")
        ElementHost1.Child = window
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        window.actualizar(TextBox1.Text, "2018-08-03")
        ElementHost1.Child = window
    End Sub
End Class
