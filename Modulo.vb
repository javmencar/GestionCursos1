
Imports System
Imports System.Collections.Generic
Public Class Modulo
    Implements IComparable

    Private mid, mhoras As Integer
    Private mNombre As String

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
    Public Property Nombre As String
        Get
            Return mNombre
        End Get
        Set(ByVal Value As String)
            mNombre = Value
        End Set
    End Property

    
    Public Function CompareTo(ByVal obj As Object) As Integer _
            Implements IComparable.CompareTo
        ' A null value means that this object is greater.
        Dim mo As Modulo = TryCast(obj, Modulo)
        ' Si no es de ese tipo o es nulo, indicar que son iguales
        If mo Is Nothing Then
            Return 0
        End If
        Return Id.CompareTo(mo.Id)

    End Function
End Class
