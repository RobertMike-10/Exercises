Imports System

Module Program
    Sub Main(args As String())

        MainAsync(New String() {"Hello", "Miguel"}).
                 GetAwaiter().
                 GetResult()

        Dim results = Task.WhenAll(
                ExampleOne,
                ExampleTwo).
                    Result

        For Each result In results
            Console.WriteLine(result)
        Next

    End Sub
    Public Async Function MainAsync(ByVal args() As String) As Task
        Await Task.Delay(3000)
        Console.WriteLine($"{args(0)} {args(1)}")
    End Function
    Async Function ExampleOne() As Task(Of Integer)
        Await Task.Delay(2000)
        Return 40
    End Function

    Async Function ExampleTwo() As Task(Of Integer)
        Await Task.Delay(5000)
        Return 60
    End Function
End Module
