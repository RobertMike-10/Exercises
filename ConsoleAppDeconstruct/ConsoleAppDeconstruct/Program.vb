Imports System
Imports System.Runtime.InteropServices
Module Program

    Public Sub Example(arg1 As Integer, arg2 As Integer)

    End Sub

    Sub Main(args As String())

        Dim person = New Person("Miguel", "calle 123", 36)
        Dim Name, Address As String, Age As Integer
        person.Deconstruct(Name, Address, Age)
        person.Deconstruct(Name)
        person.Deconstruct(Name, Age:=Age)
        Console.WriteLine("Me llamo " + Name + " vivo en " + Address + " y tengo " + Age.ToString())

        Dim x As Integer = Nothing
        Console.WriteLine(x)

        Dim y? As Integer = Nothing
        Console.WriteLine(y)

        Dim array = {Nothing, 33, Nothing}
        For Each item As Integer In array
            Console.WriteLine(item)
        Next

        If x = Nothing Then
            Console.WriteLine("El valor es cero")
        End If

        Dim z = If(x > 0, Nothing, 1.5)
        Console.WriteLine(z)

        Console.WriteLine(DefaultFunc())


    End Sub

    Public Function DefaultFunc() As Integer
        Return Nothing
    End Function

    Public Sub Example(a As Double, b As Double, c As Double)

        Dim CalculateDiscriminant = New Func(Of Double, Double, Double, Double)(Function(aa, bb, cc) bb * bb - 4 * aa * cc)
        Dim calculationDiscriminantFull = Function(aa, bb, cc) bb * bb - 4 * aa * cc
        Dim calculationDiscriminant = Function() b * b - 4 * a * c

        Dim disc = CalculateDiscriminant(a, b, c)
        Dim disc2 = calculationDiscriminant()
        Dim disc3 = calculationDiscriminantFull(a, b, c)
        Console.WriteLine(disc3)
        Console.WriteLine(disc)
        Console.WriteLine(disc2)
    End Sub

    Class Person
        Property Name As String
        Property Address As String
        Property Age As Integer
        Sub New(Name As String, Address As String, Age As Integer)
            Me.Name = Name
            Me.Address = Address
            Me.Age = Age
        End Sub
        Sub Deconstruct(<Out> ByRef Name As String, <Out> ByRef Optional Address As String = Nothing,
                        <Out> Optional ByRef Age As Integer = 0)
            Name = Me.Name
            Address = Me.Address
            Age = Me.Age
        End Sub
    End Class





End Module
