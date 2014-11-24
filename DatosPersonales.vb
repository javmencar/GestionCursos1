Imports System.Collections.Generic

Public Class DatosPersonales
    Private mId, mEdad, mTallaZapato As Integer
    Private mDNI, mNombre, mApellido1, mApellido2, mLugNac, mDomicilio, mCP, mPoblacion As String
    Private mTel1, mTel2, mNumSS, mNivelEstudios, mExpSector, mTallaCamiseta, mTallaPantalon As String
    Private mEntrevistador, mValoracion, mApto, mPathFoto As String
    Private mFnac, mInFecha, mFecEntr As Date
    Private mInInaem As Boolean
    Private mcoleccion As Collection
    Private mlistado As List(Of String)

    Public Property Id As String
        Get
            Return CStr(mId)
        End Get
        Set(ByVal Value As String)
            mId = CInt(Value)
        End Set
    End Property
    Public Property Edad As String
        Get
            Return CStr(mEdad)
        End Get
        Set(ByVal Value As String)
            mEdad = CInt(Value)
        End Set
    End Property
    Public Property TallaZapato As String
        Get
            Return CStr(mTallaZapato)
        End Get
        Set(ByVal Value As String)
            mTallaZapato = CInt(Value)
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
    Public Property Fnac As String
        Get
            Return CStr(mFnac)
        End Get
        Set(ByVal Value As String)
            mFnac = Convert.ToDateTime(Value)
        End Set
    End Property
    Public Property InFecha As String
        Get
            Return CStr(mInFecha)
        End Get
        Set(ByVal Value As String)
            mInFecha = Convert.ToDateTime(Value)
        End Set
    End Property
    Public Property FecEntr As String
        Get
            Return CStr(mFecEntr)
        End Get
        Set(ByVal Value As String)
            mFecEntr = Convert.ToDateTime(Value)
        End Set
    End Property
    Public Property InInaem As String
        Get
            If mInInaem = True Then
                Return "True"
            Else : Return "False"
            End If
        End Get
        Set(ByVal Value As String)
            If Value = "True" Then
                mInInaem = True
            Else
                mInInaem = False
            End If
        End Set
    End Property

    Public Property PathFoto As String
        Get
            Return CStr(mPathFoto)
        End Get
        Set(ByVal Value As String)
            mPathFoto = Value
        End Set
    End Property
    Public ReadOnly Property listadoNombres As List(Of String)
        Get
            Return mlistado
        End Get
    End Property
    Private Function ListadoNombreDeLasPropiedades() As List(Of String)
        '  Dim lista As New List(Of String)
        mlistado = New List(Of String)
        'With lista
        With mlistado
            .Add("Id")
            .Add("DNI")
            .Add("Nombre")
            .Add("Apellido1")
            .Add("Apellido2")
            .Add("Fnac")
            .Add("LugNac")
            .Add("Edad")
            .Add("Domicilio")
            .Add("CP")
            .Add("Poblacion")
            .Add("Tel1")
            .Add("Tel2")
            .Add("NumSS")
            .Add("InInaem")
            .Add("InFecha")
            .Add("NivelEstudios")
            .Add("ExpSector")
            .Add("TallaCamiseta")
            .Add("TallaPantalon")
            .Add("TallaZapato")
            .Add("Entrevistador")
            .Add("FecEntr")
            .Add("Valoracion")
            .Add("Apto")
            .Add("PathFoto")
        End With
        Return mlistado
    End Function
    Public ReadOnly Property listaValores As Collection
        Get
            Return mcoleccion
        End Get
    End Property
    Private Function colec() As Collection
        Dim c As New Collection
        With c
            .Add(Id)
            .Add(DNI)
            .Add(Nombre)
            .Add(Apellido1)
            .Add(Apellido2)
            .Add(Fnac)
            .Add(LugNac)
            .Add(Edad)
            .Add(Domicilio)
            .Add(CP)
            .Add(Poblacion)
            .Add(Tel1)
            .Add(Tel2)
            .Add(NumSS)
            .Add(InInaem)
            .Add(InFecha)
            .Add(NivelEstudios)
            .Add(ExpSector)
            .Add(TallaCamiseta)
            .Add(TallaPantalon)
            .Add(TallaZapato)
            .Add(Entrevistador)
            .Add(FecEntr)
            .Add(Valoracion)
            .Add(Apto)
            .Add(PathFoto)
        End With
        Return c
    End Function
    Public Sub cargarlistas()
        mcoleccion = colec()
        mlistado = ListadoNombreDeLasPropiedades()
    End Sub
End Class
