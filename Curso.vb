Imports System.Collections.Generic
Public Class Curso
    Private mid, mhoras As Integer
    Private mCodCur, mNombre As String
    Private mModulos As List(Of Modulo)
    Public Property Id As Integer
	'probando si funciona el control de versiones
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
        '   Call ordenarModulos()
    End Sub
    Public Sub ordenarModulos()
        If Not IsNothing(Me.mModulos) Then
            Dim m1 As Modulo
            Dim i, j As Integer
            j = Me.mModulos.Count
            For i = 0 To j - 2
                If mModulos(i).Id > mModulos(i + 1).Id Then
                    m1 = mModulos(i + 1)
                    mModulos(i + 1) = mModulos(i)
                    mModulos(i) = m1
                End If
            Next
        End If

    End Sub
    Public Function ValoresAString() As String
        Dim s As String
        s = String.Format("'{0}', '{1}', '{2}'", Me.CodCur, Me.Nombre, CStr(Me.horas))
        Return s
    End Function
End Class
