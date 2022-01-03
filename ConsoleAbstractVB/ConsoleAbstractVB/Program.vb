Imports System

Module Program
    Sub Main(args As String())
        Dim cygnus As Cisne = New Cisne With {.Peso = 15.4, .Color = "Blanco", .Extremidades = 4}

        Dim cygnus2 As Animal = New Cisne With {.Peso = 15.4, .Color = "Blanco", .Extremidades = 4}
        cygnus2.Desplazarse()

        Dim cygnus3 As IVolador = New Cisne With {.Peso = 15.4, .Color = "Blanco", .Extremidades = 4}

        Dim persian As Animal = New Gato With {.Peso = 20.4, .Color = "Beige", .Extremidades = 4}
        persian.Desplazarse()
    End Sub
End Module
