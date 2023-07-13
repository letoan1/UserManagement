Imports System.Data.SqlClient

Module Module1
    Public Connect As New SqlConnection("Data Source=DNCPU0136;Initial Catalog=UserManagement;Integrated Security=True")

    Public Sub ConnectDatabase()
        If Connect.State = ConnectionState.Open Then Connect.Close()
        Connect.Open()
    End Sub

    Public Sub DisconnectDatabase()
        Connect.Close()
    End Sub
End Module
