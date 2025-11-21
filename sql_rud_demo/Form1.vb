Imports MySql.Data.MySqlClient
Public Class Form1
    Dim conn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Private Sub ButtonConnect_Click(sender As Object, e As EventArgs) Handles ButtonConnect.Click
        conn = New MySqlConnection
        conn.ConnectionString = "server = localhost; userid=root; password=root; database=crud_demo.db;"

        Try
            conn.Open()
            MessageBox.Show("Connected")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn.Close()


        End Try

    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Dim query As String = "INSERT INTO `crud_demo.db`.`students_tbl` (`name`, `age`, `email`) VALUES (@name, @age, '@email');"
        Try
            Using conn As New MySqlConnection("server = localhost; userid=root; password=root; database=crud_demo.db;")
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@name", txtName.Text)
                    cmd.Parameters.AddWithValue("@age", txtAge.Text)
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Reacord insert successful")

                    txtName.Clear()
                    txtAge.Clear()
                    txtEmail.Clear()



                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class
