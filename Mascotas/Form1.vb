Imports MySql.Data.MySqlClient

'Matias Techera
'El boton Editar y Eliminar por algua razon no me funcionaron

Public Class Form1

    Sub ActualizarSelect()

        Dim ds As DataSet = New DataSet
        Dim adaptador As MySqlDataAdapter = New MySqlDataAdapter

        Dim conexion As MySqlConnection = New MySqlConnection
        Dim cmd As New MySqlCommand

        conexion.ConnectionString = "server=localhost; database=veterinaria;Uid=root;Pwd=;"

        Try
            conexion.Open()
            'MsgBox("nos conectamos")
            cmd.Connection = conexion

            cmd.CommandText = "SELECT * FROM perros ORDER BY id ASC"
            adaptador.SelectCommand = cmd
            adaptador.Fill(ds, "Tabla")
            grdmascotas.DataSource = ds
            grdmascotas.DataMember = "Tabla"

            conexion.Close()

        Catch ex As Exception
            MsgBox("No ha conectado con la base de Datos.")
        End Try


    End Sub
    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        End

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarSelect()

    End Sub

    Private Sub btnagregar_Click(sender As Object, e As EventArgs) Handles btnagregar.Click
        Dim ds As DataSet = New DataSet
        Dim adaptador As MySqlDataAdapter = New MySqlDataAdapter
        Dim conexion As MySqlConnection = New MySqlConnection
        Dim cmd As New MySqlCommand
        conexion.ConnectionString = "server=localhost; database=veterinaria;Uid=root;Pwd=;"

        Try

            conexion.Open()
            'MsgBox("Nos conectamos")
            cmd.Connection = conexion
            cmd.CommandText = "INSERT INTO perros(nombremascota,raza,color) VALUES(@nombremascota,@raza,@color)"
            cmd.Prepare()
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@nombremascota", txtnombre.Text)
            cmd.Parameters.AddWithValue("@raza", txtraza.Text)
            cmd.Parameters.AddWithValue("@color", txtcolor.Text)
            cmd.ExecuteNonQuery()
            txtnombre.Clear()
            txtraza.Clear()
            txtcolor.Clear()
            conexion.Close()



            'MsgBox("Su mascota a sido ingresada correctamente")
            ActualizarSelect()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub grdmascotas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdmascotas.CellContentClick
        If (grdmascotas.SelectedRows.Count > 0) Then
            txtnombre.Text = grdmascotas.Item("nombre", grdmascotas.SelectedRows(0).Index).Value
            txtraza.Text = grdmascotas.Item("raza", grdmascotas.SelectedRows(0).Index).Value
            txtcolor.Text = grdmascotas.Item("color", grdmascotas.SelectedRows(0).Index).Value
            txtid.Text = grdmascotas.Item("id", grdmascotas.SelectedRows(0).Index).Value



        End If

    End Sub

    Private Sub btneditar_Click(sender As Object, e As EventArgs) Handles btneditar.Click
        Dim ds As DataSet = New DataSet
        Dim adaptador As MySqlDataAdapter = New MySqlDataAdapter
        Dim conexion As MySqlConnection = New MySqlConnection
        Dim cmd As New MySqlCommand
        conexion.ConnectionString = "server=localhost; database=veterinaria;Uid=root;Pwd=;"
        Try
            conexion.Open()

            cmd.Connection = conexion
            cmd.CommandText = "UPDATE perros SET nombremascota=@nombremascota, raza=@raza, color=@color WHERE id=@id"
            cmd.Prepare()
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@nombremascota", txtnombre.Text)
            cmd.Parameters.AddWithValue("@raza", txtraza.Text)
            cmd.Parameters.AddWithValue("@color", txtcolor.Text)
            cmd.Parameters.AddWithValue("@id", txtid.Text)
            cmd.ExecuteNonQuery()
            txtnombre.Clear()
            txtraza.Clear()
            txtcolor.Clear()
            txtid.Clear()
            conexion.Close()

            'MsgBox("Su mascota a sido editada correctamente")
            ActualizarSelect()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub btneliminar_Click(sender As Object, e As EventArgs) Handles btneliminar.Click
        Dim ds As DataSet = New DataSet
        Dim adaptador As MySqlDataAdapter = New MySqlDataAdapter
        Dim conexion As MySqlConnection = New MySqlConnection
        Dim cmd As New MySqlCommand
        conexion.ConnectionString = "server=localhost; database=veterinaria;Uid=root;Pwd=;"
        Try
            conexion.Open()
            'MsgBox("Nos conectamos")
            cmd.Connection = conexion
            cmd.CommandText = "DELETE perros WHERE nombremascota=@nombremascota AND raza=@raza AND color=@color AND id=@id"
            cmd.Prepare()
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@nombremascota", txtnombre.Text)
            cmd.Parameters.AddWithValue("@raza", txtraza.Text)
            cmd.Parameters.AddWithValue("@color", txtcolor.Text)
            cmd.Parameters.AddWithValue("@id", txtid.Text)
            cmd.ExecuteNonQuery()
            txtnombre.Clear()
            txtraza.Clear()
            txtcolor.Clear()
            txtid.Clear()
            conexion.Close()

            'MsgBox("Su mascota a sido eliminada correctamente")
            ActualizarSelect()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub txtid_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub txtid_TextChanged_1(sender As Object, e As EventArgs) Handles txtid.TextChanged

    End Sub
End Class
