Imports System
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity
Imports System.Linq

Partial Public Class NorthwindEntities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=NorthwindEntities")
    End Sub

    Public Overridable Property Customers As DbSet(Of Customer)
    Public Overridable Property Employees As DbSet(Of Employee)
    Public Overridable Property Order_Details As DbSet(Of Order_Detail)
    Public Overridable Property Orders As DbSet(Of Order)
    Public Overridable Property Products As DbSet(Of Product)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of Customer)() _
            .Property(Function(e) e.CustomerID) _
            .IsFixedLength()

        modelBuilder.Entity(Of Customer)() _
            .Property(Function(e) e.Timestamp) _
            .IsFixedLength()

        modelBuilder.Entity(Of Employee)() _
            .HasMany(Function(e) e.Employees1) _
        .WithOptional(Function(e) e.Employee1) _
        .HasForeignKey(Function(e) e.ReportsTo)

        modelBuilder.Entity(Of Order_Detail)() _
            .Property(Function(e) e.UnitPrice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Order)() _
            .Property(Function(e) e.CustomerID) _
            .IsFixedLength()

        modelBuilder.Entity(Of Order)() _
            .Property(Function(e) e.Freight) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Order)() _
            .Property(Function(e) e.Timestamp) _
            .IsFixedLength()

        modelBuilder.Entity(Of Order)() _
            .HasMany(Function(e) e.Order_Details) _
            .WithRequired(Function(e) e.Order) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Product)() _
            .Property(Function(e) e.UnitPrice) _
            .HasPrecision(19, 4)

        modelBuilder.Entity(Of Product)() _
            .HasMany(Function(e) e.Order_Details) _
            .WithRequired(Function(e) e.Product) _
            .WillCascadeOnDelete(False)
    End Sub
End Class
