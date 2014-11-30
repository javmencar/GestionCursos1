Imports System.Collections 
Imports System.Windows.Forms

Public Class ListViewColumnSorter
    Implements System.Collections.IComparer

    Private ColumnToSort As Integer
    Private OrderOfSort As SortOrder
    Private ObjectCompare As CaseInsensitiveComparer

    Public Sub New() ' Inicializar la columna a '0'.
        ColumnToSort = 0

        ' Inicializar el tipo de orden en 'ninguno'. 
        OrderOfSort = SortOrder.None

        ' Inicializar el objeto CaseInsensitiveComparer. 
        ObjectCompare = New CaseInsensitiveComparer()
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        Dim compareResult As Integer
        Dim listviewX As ListViewItem
        Dim listviewY As ListViewItem

        ' Convertir el tipo de los objetos para compararlos con los objetos ListViewItem. 
        listviewX = CType(x, ListViewItem)
        listviewY = CType(y, ListViewItem)

        ' Comparar los dos elementos. 
        compareResult = ObjectCompare.Compare(listviewX.SubItems(ColumnToSort).Text, listviewY.SubItems(ColumnToSort).Text)

        ' Calcular el valor devuelto correcto según la comparación del objeto.
        If (OrderOfSort = SortOrder.Ascending) Then
            ' Se selecciona el orden ascendente, y se devuelve el 'resultado típico de la operación de ' comparación.
            Return compareResult
        ElseIf (OrderOfSort = SortOrder.Descending) Then
            ' Se selecciona el orden descendente, y se devuelve el resultado negativo de ' la operación de comparación.
            Return (-compareResult)
        Else
            ' Return '0' para indicar que son iguales. 
            Return 0
        End If
    End Function

    Public Property SortColumn() As Integer
        Set(ByVal Value As Integer)
            ColumnToSort = Value
        End Set

        Get
            Return ColumnToSort
        End Get
    End Property

    Public Property Order() As SortOrder
        Set(ByVal Value As SortOrder)
            OrderOfSort = Value
        End Set

        Get
            Return OrderOfSort
        End Get
    End Property
End Class