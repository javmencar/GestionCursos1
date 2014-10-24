Imports System.Collections.Generic

Public Class Alumno


    Implements IComparable


    Private mId, mEdad, mTallaZapato As Integer
    Private mDNI, mNombre, mApellido1, mApellido2, mLugNac, mDomicilio, mCP, mPoblacion As String
    Private mTel1, mTel2, mNumSS, mNivelEstudios, mExpSector, mTallaCamiseta, mTallaPantalon As String
    Private mEntrevistador, mValoracion, mApto As String
    Private mFnac, mInFecha, mFecEntr As Date
    Private mInInaem As Boolean

    Public Property Id As Integer
        Get
            Return mid
        End Get
        Set(ByVal Value As Integer)
            mid = Value
        End Set
    End Property
    Public Property Edad As Integer
        Get
            Return mEdad
        End Get
        Set(ByVal Value As Integer)
            mEdad = Value
        End Set
    End Property
    Public Property TallaZapato As Integer
        Get
            Return mTallaZapato
        End Get
        Set(ByVal Value As Integer)
            mTallaZapato = Value
        End Set
    End Property
    Public Property DNI As String
        Get
            Return mDNI
        End Get
        Set(ByVal Value As String)
            mDNI = Value
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
    Public Property Apellido1 As String
        Get
            Return mApellido1
        End Get
        Set(ByVal Value As String)
            mApellido1 = Value
        End Set
    End Property
    Public Property Apellido2 As String
        Get
            Return mApellido2
        End Get
        Set(ByVal Value As String)
            mApellido2 = Value
        End Set
    End Property
    Public Property LugNac As String
        Get
            Return mLugNac
        End Get
        Set(ByVal Value As String)
            mLugNac = Value
        End Set
    End Property
    Public Property Domicilio As String
        Get
            Return mDomicilio
        End Get
        Set(ByVal Value As String)
            mDomicilio = Value
        End Set
    End Property
    Public Property CP As String
        Get
            Return mCP
        End Get
        Set(ByVal Value As String)
            mCP = Value
        End Set
    End Property
    Public Property Poblacion As String
        Get
            Return mPoblacion
        End Get
        Set(ByVal Value As String)
            mPoblacion = Value
        End Set
    End Property

    
    Public Property Tel1 As String
        Get
            Return mTel1
        End Get
        Set(ByVal Value As String)
            mTel1 = Value
        End Set
    End Property
    Public Property Tel2 As String
        Get
            Return mTel2
        End Get
        Set(ByVal Value As String)
            mTel2 = Value
        End Set
    End Property
    Public Property NumSS As String
        Get
            Return mNumSS
        End Get
        Set(ByVal Value As String)
            mNumSS = Value
        End Set
    End Property
    Public Property NivelEstudios As String
        Get
            Return mNivelEstudios
        End Get
        Set(ByVal Value As String)
            mNivelEstudios = Value
        End Set
    End Property
   
    Public Property ExpSector As String
        Get
            Return mExpSector
        End Get
        Set(ByVal Value As String)
            mExpSector = Value
        End Set
    End Property
    Public Property TallaCamiseta As String
        Get
            Return mTallaCamiseta
        End Get
        Set(ByVal Value As String)
            mTallaCamiseta = Value
        End Set
    End Property

    Public Property TallaPantalon As String
        Get
            Return mTallaPantalon
        End Get
        Set(ByVal Value As String)
            mTallaPantalon = Value
        End Set
    End Property
    Public Property Entrevistador As String
        Get
            Return mEntrevistador
        End Get
        Set(ByVal Value As String)
            mEntrevistador = Value
        End Set
    End Property
    Public Property Valoracion As String
        Get
            Return mValoracion
        End Get
        Set(ByVal Value As String)
            mValoracion = Value
        End Set
    End Property
    Public Property Apto As String
        Get
            Return mApto
        End Get
        Set(ByVal Value As String)
            mApto = Value
        End Set
    End Property
   
    ' Private mFnac, mInFecha, mFecentr As Date
    Public Property Fnac As Date
        Get
            Return mFnac
        End Get
        Set(ByVal Value As Date)
            mFnac = Value
        End Set
    End Property
    Public Property InFecha As Date
        Get
            Return mInFecha
        End Get
        Set(ByVal Value As Date)
            mInFecha = Value
        End Set
    End Property
    Public Property FecEntr As Date
        Get
            Return mFecentr
        End Get
        Set(ByVal Value As Date)
            mFecentr = Value
        End Set
    End Property
    Public Property InInaem As Boolean
        Get
            Return mInInaem
        End Get
        Set(ByVal Value As Boolean)
            mInInaem = Value
        End Set
    End Property

    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        Return ""
    End Function
End Class
