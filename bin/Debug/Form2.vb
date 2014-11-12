Imports System.Data.SqlClient
'formulario borrable, es para hacer pruebas
Public Class Form2
    Dim cn As SqlConnection
    Dim cur As Curso
    Public arr As ArrayList
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New SqlConnection(ConeStr)
        Arr = New ArrayList
        arr.Add("5_modulo 5")
        arr.Add("3_modulo 3")
        arr.Add("1_modulo 1")
        arr.Add("4_modulo 4")
        arr.Add("2_modulo 2")

        For Each lin As String In arr
            Me.ListBox1.Items.Add(lin.ToString)
        Next

    End Sub
    Public Function cambiarPutoFormatoFecha(ByVal s As String) As Date
        Dim t As String = "311299990000"
        If s = "  /  /" Then s = t
        Dim fechacorrecta As Date = DateTime.ParseExact(s, "ddMMyyyy", Nothing)
        Return fechacorrecta
    End Function
    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim fecha As Date = cambiarFormatoFecha(Me.MaskedTextBox1.Text)
    '    MsgBox(fecha.ToShortDateString)


    'End Sub
    Public Function cambiarFormatoFecha(ByVal s As String) As Date
        MsgBox(s)
        Dim fechacorrecta As Date = DateTime.Parse(s)
        MsgBox(fechacorrecta)
        Return fechacorrecta
    End Function
    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '       prueba para ver como sacaba los valores de un objeto a string
    '    Dim i As Integer = CInt(Me.TextBox1.Text)
    '    Dim sql As String = "select cursos.codcur, cursos.nombre,cursos.horas from cursos where cursos.id=" & i
    '    cn.Open()
    '    Dim dr As SqlDataReader
    '    Dim cmd As New SqlCommand(sql, cn)
    '    dr = cmd.ExecuteReader
    '    cur = New Curso
    '    MsgBox(sql)
    '    Do While dr.Read
    '        cur.CodCur = dr(0)
    '        cur.Nombre = dr(1)
    '        cur.horas = dr(2)
    '    Loop
    '    cn.Close()

    '    Me.TextBox2.Text = cur.ValoresAString
    'End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    ''cur = New Curso
    '    'Try
    '    '    If 1 = 1 Then Throw New miExcepcion(String.Format("error al {0} en la linea  {1} en el formulario " & Me.Name.ToString, "", 0))
    '    'Catch ex As miExcepcion
    '    '    MsgBox(ex.ToString)
    '    '    Me.Name.ToString()
    '    'End Try
    '    '' Dim str As String = String.Format("error al insertar el registro en la linea  {0} en el formulario " & Me.ToString, 225)
    '    ''MsgBox(str)
    'End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    arr.Sort()
    '    Me.ListBox1.Items.Clear()
    '    For Each lin As String In arr
    '        Me.ListBox1.Items.Add(lin.ToString)
    '    Next
    'End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim vieja As String = Me.TextBox1.Text
    '    Dim dias, meses, años As String
    '    dias = vieja.Substring(0, 2)
    '    meses = vieja.Substring(3, 2)
    '    años = vieja.Substring(6, 4)
    '    Dim nueva As String = años & meses & dias
    '    MsgBox(nueva)
    'End Sub

   
    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim DP As New DatosPersonales
    '    Dim lista As List(Of String) = DP.ListadoNombreDeLasPropiedades
    '    Dim recogelista As String = ""
    '    For Each s As String In lista
    '        recogelista &= String.Format("' {0} ' {1}", s, vbCrLf)
    '    Next
    '    MsgBox(String.Format("Está creando una ficha con las siguientes incidencias: {0}{1}{0} ¿Esta seguro de que desea continuar? ", vbCrLf, recogelista), MsgBoxStyle.YesNo)
    'End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim numSS As String = CStr(Me.MaskedTextBox1.Text)
        numSS = numSS.Replace("/", "")

        Dim comprobado As Boolean = ValidaNumSSNumSS(numSS)
        If comprobado = True Then
            MsgBox("numero correcto")
        Else
            MsgBox("Numero erroneo")
        End If
    End Sub
    Public Function GetDCNumSegSocial(ByVal numSegSocial As String, _
                              ByVal esNumEmpresa As Boolean) As String
        If (numSegSocial.Length > 10) OrElse (numSegSocial.Length = 0) Then _
            Throw New System.ArgumentException()
        Dim regex As New System.Text.RegularExpressions.Regex("[^0-9]")
        If (regex.IsMatch(numSegSocial)) Then _
            Throw New System.ArgumentException()
        Try
            Dim dcProv As String = numSegSocial.Substring(0, 2)
            Dim numero As String = numSegSocial.Substring(2, numSegSocial.Length - 2)
            Select Case numero.Length
                Case 8
                    If (esNumEmpresa) Then
                        Return String.Empty
                    Else
                        If (numero.Chars(0) = "0"c) Then
                            numero = numero.Remove(0, 1)
                        End If
                    End If
                Case 7
                    If (esNumEmpresa) Then
                        If (numero.Chars(0) = "0"c) Then
                            numero = numero.Remove(0, 1)
                        End If
                    End If
                Case 6
                    If (Not (esNumEmpresa)) Then
                        numero = numero.PadLeft(7, "0"c)
                    End If
                Case Else
                    If (esNumEmpresa) Then
                        numero = numero.PadLeft(6, "0"c)
                    Else
                        numero = numero.PadLeft(7, "0"c)
                    End If
            End Select
            Dim naf As Int64 = Convert.ToInt64(dcProv & numero)
            naf = naf - (naf \ 97) * 97
            Return String.Format("{0:00}", naf)
        Catch
            Return String.Empty
        End Try
    End Function
    Public Function ValidaNumSSNumSS(ByVal NSS As String) As Boolean
        Dim CP As String = NSS.Substring(0, 2)
        If Not IsNumeric(CP) AndAlso (CInt(CP) < 1 Or CInt(CP) > 50) Then Return False
        Dim NssSCC As String = NSS.Substring(0, NSS.Length - 2)
        Dim dc As String = GetDCNumSegSocial(NssSCC, False)
        Dim s As String = NSS.Substring(NSS.Length - 2, 2)
        If s = dc Then Return True
        Return False
    End Function
End Class