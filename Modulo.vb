
Imports System
Imports System.Collections.Generic
Public Class Modulo
    Private mid, mhoras As Integer
    Private mNombre, mContenidos As String

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
    Public Property Contenidos As String
        Get
            Return mContenidos
        End Get
        Set(ByVal Value As String)
            mContenidos = Value
        End Set
    End Property
    
End Class
