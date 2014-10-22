Imports System.Collections.Generic
Public Class Curso
    Implements IComparable


    Private mid, mhoras As Integer
    Private mCodCur, mNombre As String
    Private mModulos As List(Of Modulo)
    Public Property Id As Integer
        Get
            Return mid
        End Get
        Set(ByVal Value As Integer)
            mid = Value
        End Set
    End Property
    Public Property horas As Integer
        Get
            Return mhoras
        End Get
        Set(ByVal Value As Integer)
            mhoras = Value
        End Set
    End Property
    Public Property CodCur() As String
        Get
            Return mCodCur
        End Get
        Set(ByVal Value As String)
            mCodCur = Value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return mNombre
        End Get
        Set(ByVal Value As String)
            mNombre = Value
        End Set
    End Property
    Public ReadOnly Property modulos As List(Of Modulo)
        Get
            Return mModulos
        End Get
    End Property


    Public Sub añadirModulos(ByVal m As Modulo)
        If Me.mModulos Is Nothing Then
            Me.mModulos = New List(Of Modulo)
        End If
        Me.mModulos.Add(m)

    End Sub
    Public Sub ordenarModulos()
        If Not IsNothing(Me.mModulos) Then
            Dim m1, m2 As Modulo
            Dim k As Integer = mModulos.Count
            For i As Integer = 0 To Me.mModulos.Count - 2
                If mModulos(i).Id > mModulos(i + 1).Id Then

                End If

            Next
        End If

    End Sub

    Public Function ValoresAString() As String
        Dim s, comilla, e, coma As String
        comilla = "'"
        e = " "
        coma = ","
        s = comilla & Me.CodCur & comilla & coma & e & comilla & Me.Nombre & comilla & coma & e & Me.horas
        Return s
    End Function

    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo

    End Function
End Class
