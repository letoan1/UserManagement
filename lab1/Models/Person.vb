Imports System.Data.SqlClient

Public Class Person
    Public id As Integer
    Public fullName As String
    Public dateOfBirth As Date
    Public address As String
    Public department As String
    Public position As String
    Public note As String

    Public Sub New(ByVal id As Integer, ByVal fullName As String, ByVal dateOfBirth As Date, ByVal address As String, ByVal department As String, ByVal position As String, ByVal note As String)
        Me.id = id
        Me.fullName = fullName
        Me.dateOfBirth = dateOfBirth
        Me.address = address
        Me.department = department
        Me.position = position
        Me.note = note
    End Sub

    Public Shared Function FromCsvRow(ByVal row As String()) As Person
        Dim id As Integer
        If Not Integer.TryParse(row(0), id) Then
            Return Nothing
        End If

        Dim fullName As String = row(1).Trim()
        If fullName.Length = 0 Then
            Return Nothing
        End If

        Dim dateOfBirth As Date
        If Not Date.TryParse(row(2), dateOfBirth) Then
            Return Nothing
        End If

        Dim address As String = row(3).Trim()
        Dim department As String = row(4).Trim()
        Dim position As String = row(5).Trim()
        Dim note As String = row(6).Trim()

        Return New Person(id, fullName, dateOfBirth, address, department, position, note)
    End Function
End Class


Public Class DataAccess
    Private Shared Connect As SqlConnection

    Public Shared Sub ConnectionDatabase()
        Dim connectionString As String = "Data Source=DNCPU0136;Initial Catalog=UserManagement;Integrated Security=True"
        Connect = New SqlConnection(connectionString)
        Connect.Open()
    End Sub
    Public Shared Sub Disconnect()
        If Connect IsNot Nothing AndAlso Connect.State = ConnectionState.Open Then
            Connect.Close()
        End If
    End Sub


    Public Shared Sub InsertPerson(ByVal person As Person)
        Dim query As String = "INSERT INTO users (id, fullName, dateOfBirth, address, department, position, note) VALUES (@id, @fullName, @dateOfBirth, @address, @department, @position, @note)"

        Dim transaction As SqlTransaction = Connect.BeginTransaction()

        Try
            Using command As New SqlCommand(query, Connect, transaction)
                command.Parameters.AddWithValue("@id", person.id)
                command.Parameters.AddWithValue("@fullName", person.fullName)
                command.Parameters.AddWithValue("@dateOfBirth", person.dateOfBirth)
                command.Parameters.AddWithValue("@address", person.address)
                command.Parameters.AddWithValue("@department", person.department)
                command.Parameters.AddWithValue("@position", person.position)
                command.Parameters.AddWithValue("@note", person.note)
                command.ExecuteNonQuery()
            End Using
            transaction.Commit()
        Catch ex As Exception
            transaction.Rollback()
            Throw ex
        End Try
    End Sub

    Public Shared Sub UpdatePerson(ByVal person As Person)
        Dim query As String = "UPDATE users SET fullName = @fullName, dateOfBirth = @dateOfBirth, address = @address, department = @department, position = @position, note = @note WHERE ID = @id"

        Dim transaction As SqlTransaction = Connect.BeginTransaction()

        Try
            Using command As New SqlCommand(query, Connect, transaction)
                command.Parameters.AddWithValue("@id", person.id)
                command.Parameters.AddWithValue("@fullName", person.fullName)
                command.Parameters.AddWithValue("@dateOfBirth", person.dateOfBirth)
                command.Parameters.AddWithValue("@address", person.address)
                command.Parameters.AddWithValue("@department", person.department)
                command.Parameters.AddWithValue("@position", person.position)
                command.Parameters.AddWithValue("@note", person.note)
                command.ExecuteNonQuery()
            End Using

            transaction.Commit()
        Catch ex As Exception
            transaction.Rollback()
            Throw ex
        End Try
    End Sub

    Public Shared Sub DeletePerson(ByVal id As Integer)
        Dim query As String = "DELETE FROM users WHERE id = @id"

        Using command As New SqlCommand(query, Connect)
            command.Parameters.AddWithValue("@id", id)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Shared Function GetAllPersons() As List(Of Person)
        Dim query As String = "SELECT * FROM users"
        Dim command As New SqlCommand(query, Connect)
        Dim adapter As New SqlDataAdapter(command)
        Dim dataset As New DataSet()
        adapter.Fill(dataset)

        Dim persons As New List(Of Person)()
        For Each row As DataRow In dataset.Tables(0).Rows
            Dim person As New Person(Convert.ToInt32(row("id")), row("fullName").ToString(), Convert.ToDateTime(row("dateOfBirth")), row("address").ToString(), row("department").ToString(), row("position").ToString(), row("note").ToString())
            persons.Add(person)
        Next

        Return persons
    End Function
End Class