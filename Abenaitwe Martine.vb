Imports System.IO

Module Program

    Sub Main()

        Dim fileName As String = "StudentMarks.txt"

        Using writer As New StreamWriter(fileName, False)
            writer.WriteLine("ST001, Shaminah, 85")
            writer.WriteLine("ST002, Mahoro, 84")
            writer.WriteLine("ST003, Saum, 82")
            writer.WriteLine("ST004, Henry, 95")
        End Using

        Console.WriteLine("Student marks saved successfully.")
        Console.WriteLine()

        Using reader As New StreamReader(fileName)

            Dim line As String = reader.ReadLine()

            While line IsNot Nothing
                Console.WriteLine(line)
                line = reader.ReadLine()
            End While

        End Using

        Console.ReadLine()

    End Sub

End Module