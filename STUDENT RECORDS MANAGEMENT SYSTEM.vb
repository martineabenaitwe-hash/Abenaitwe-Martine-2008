Imports System
Imports System.IO

Module Program

    Sub Main()

        Dim fileName As String = "StudentRecords.txt"
        Dim choice As String

        Do
            Console.WriteLine()
            Console.WriteLine("1. Enter Student Record")
            Console.WriteLine("2. Display Student Records")
            Console.WriteLine("3. Exit")
            Console.Write("Enter your choice: ")

            choice = Console.ReadLine()

            Select Case choice

                Case "1"

                    Try
                        Console.Write("Enter Registration Number: ")
                        Dim regNo As String = Console.ReadLine()

                        Console.Write("Enter Student Name: ")
                        Dim studentName As String = Console.ReadLine()

                        Console.Write("Enter Marks: ")
                        Dim marksInput As String = Console.ReadLine()
                        Dim marks As Double

                        If String.IsNullOrWhiteSpace(regNo) OrElse
                           String.IsNullOrWhiteSpace(studentName) Then

                            Console.WriteLine("Registration number and name are required.")

                        ElseIf Not Double.TryParse(marksInput, marks) Then

                            Console.WriteLine("Invalid marks. Please enter a number.")

                        ElseIf marks < 0 OrElse marks > 100 Then

                            Console.WriteLine("Marks must be between 0 and 100.")

                        Else
                            Using writer As New StreamWriter(fileName, True)
                                writer.WriteLine(regNo & "," &
                                                 studentName & "," & marks)
                            End Using

                            Console.WriteLine("Student record saved successfully!")
                        End If

                    Catch ex As IOException
                        Console.WriteLine("File error: " & ex.Message)

                    Catch ex As UnauthorizedAccessException
                        Console.WriteLine("Access denied: " & ex.Message)

                    End Try

                Case "2"

                    Try
                        If File.Exists(fileName) Then

                            Using reader As New StreamReader(fileName)

                                Dim record As String

                                Console.WriteLine("SAVED STUDENT RECORDS")

                                record = reader.ReadLine()

                                If record Is Nothing Then
                                    Console.WriteLine("No student records found.")
                                End If

                                While record IsNot Nothing
                                    Console.WriteLine(record)
                                    record = reader.ReadLine()
                                End While

                            End Using

                        Else
                            Console.WriteLine("No records file found.")
                            Console.WriteLine("Please save a student record first.")
                        End If

                    Catch ex As IOException
                        Console.WriteLine("File error: " & ex.Message)

                    Catch ex As UnauthorizedAccessException
                        Console.WriteLine("Access denied: " & ex.Message)

                    End Try

                Case "3"

                    Console.WriteLine("Thank you for using the system.")

                Case Else

                    Console.WriteLine("Invalid choice. Select 1, 2 or 3.")

            End Select

        Loop While choice <> "3"

        Console.WriteLine("Press Enter to close the program.")
        Console.ReadLine()

    End Sub

End Module