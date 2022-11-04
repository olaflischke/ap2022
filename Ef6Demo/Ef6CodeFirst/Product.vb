Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Product
    Public Sub New()
        Order_Details = New HashSet(Of Order_Detail)()
    End Sub

    Public Property ID As Integer

    <Required>
    <StringLength(40)>
    Public Property ProductName As String

    Public Property SupplierID As Integer?

    Public Property CategoryID As Integer?

    <StringLength(20)>
    Public Property QuantityPerUnit As String

    <Column(TypeName:="money")>
    Public Property UnitPrice As Decimal?

    Public Property UnitsInStock As Short?

    Public Property UnitsOnOrder As Short?

    Public Property ReorderLevel As Short?

    Public Property Discontinued As Boolean

    Public Overridable Property Order_Details As ICollection(Of Order_Detail)
End Class
