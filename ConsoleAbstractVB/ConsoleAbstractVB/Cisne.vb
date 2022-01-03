Public Class Cisne
    Inherits Animal
    Implements IVolador
    Public Overrides Sub Desplazarse()
        Console.WriteLine("El cisne surca los cielos")
    End Sub
    Public Sub Despegar() Implements IVolador.Despegar
        Console.WriteLine("El cisne aterriza")
    End Sub
    Public Sub Aterrizar() Implements IVolador.Aterrizar
        Console.WriteLine("El cisne alza el vuelo")
    End Sub
End Class
