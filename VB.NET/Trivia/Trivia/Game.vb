Namespace UglyTrivia
    Public Class Game


        Private players As New List(Of String)()

        Private places As Integer() = New Integer(5) {}
        Private purses As Integer() = New Integer(5) {}

        Private inPenaltyBox As Boolean() = New Boolean(5) {}

        Private popQuestions As New LinkedList(Of String)()
        Private scienceQuestions As New LinkedList(Of String)()
        Private sportsQuestions As New LinkedList(Of String)()
        Private rockQuestions As New LinkedList(Of String)()

        Private currentPlayer As Integer = 0
        Private isGettingOutOfPenaltyBox As Boolean

        Public Sub New()
            For i As Integer = 0 To 49
                popQuestions.AddLast("Pop Question " + i)
                scienceQuestions.AddLast(("Science Question " + i))
                sportsQuestions.AddLast(("Sports Question " + i))
                rockQuestions.AddLast(createRockQuestion(i))
            Next
        End Sub

        Public Function createRockQuestion(index As Integer) As [String]
            Return "Rock Question " + index
        End Function

        Public Function isPlayable() As Boolean
            Return (howManyPlayers() >= 2)
        End Function

        Public Function add(playerName As [String]) As Boolean


            players.Add(playerName)
            places(howManyPlayers()) = 0
            purses(howManyPlayers()) = 0
            inPenaltyBox(howManyPlayers()) = False

            Console.WriteLine(playerName + " was added")
            Console.WriteLine("They are player number " + players.Count)
            Return True
        End Function

        Public Function howManyPlayers() As Integer
            Return players.Count
        End Function

        Public Sub roll(roll As Integer)
            Console.WriteLine(players(currentPlayer) + " is the current player")
            Console.WriteLine("They have rolled a " + roll)

            If inPenaltyBox(currentPlayer) Then
                If roll Mod 2 <> 0 Then
                    isGettingOutOfPenaltyBox = True

                    Console.WriteLine(players(currentPlayer) + " is getting out of the penalty box")
                    places(currentPlayer) = places(currentPlayer) + roll
                    If places(currentPlayer) > 11 Then
                        places(currentPlayer) = places(currentPlayer) - 12
                    End If

                    Console.WriteLine(players(currentPlayer) + "'s new location is " + places(currentPlayer))
                    Console.WriteLine("The category is " + currentCategory())
                    askQuestion()
                Else
                    Console.WriteLine(players(currentPlayer) + " is not getting out of the penalty box")
                    isGettingOutOfPenaltyBox = False

                End If
            Else

                places(currentPlayer) = places(currentPlayer) + roll
                If places(currentPlayer) > 11 Then
                    places(currentPlayer) = places(currentPlayer) - 12
                End If

                Console.WriteLine(players(currentPlayer) + "'s new location is " + places(currentPlayer))
                Console.WriteLine("The category is " + currentCategory())
                askQuestion()
            End If

        End Sub

        Private Sub askQuestion()
            If currentCategory() = "Pop" Then
                Console.WriteLine(popQuestions.First())
                popQuestions.RemoveFirst()
            End If
            If currentCategory() = "Science" Then
                Console.WriteLine(scienceQuestions.First())
                scienceQuestions.RemoveFirst()
            End If
            If currentCategory() = "Sports" Then
                Console.WriteLine(sportsQuestions.First())
                sportsQuestions.RemoveFirst()
            End If
            If currentCategory() = "Rock" Then
                Console.WriteLine(rockQuestions.First())
                rockQuestions.RemoveFirst()
            End If
        End Sub


        Private Function currentCategory() As [String]
            If places(currentPlayer) = 0 Then
                Return "Pop"
            End If
            If places(currentPlayer) = 4 Then
                Return "Pop"
            End If
            If places(currentPlayer) = 8 Then
                Return "Pop"
            End If
            If places(currentPlayer) = 1 Then
                Return "Science"
            End If
            If places(currentPlayer) = 5 Then
                Return "Science"
            End If
            If places(currentPlayer) = 9 Then
                Return "Science"
            End If
            If places(currentPlayer) = 2 Then
                Return "Sports"
            End If
            If places(currentPlayer) = 6 Then
                Return "Sports"
            End If
            If places(currentPlayer) = 10 Then
                Return "Sports"
            End If
            Return "Rock"
        End Function

        Public Function wasCorrectlyAnswered() As Boolean
            If inPenaltyBox(currentPlayer) Then
                If isGettingOutOfPenaltyBox Then
                    Console.WriteLine("Answer was correct!!!!")
                    purses(currentPlayer) += 1
                    Console.WriteLine(players(currentPlayer) + " now has " + purses(currentPlayer) + " Gold Coins.")

                    Dim winner As Boolean = didPlayerWin()
                    currentPlayer += 1
                    If currentPlayer = players.Count Then
                        currentPlayer = 0
                    End If

                    Return winner
                Else
                    currentPlayer += 1
                    If currentPlayer = players.Count Then
                        currentPlayer = 0
                    End If
                    Return True



                End If
            Else

                Console.WriteLine("Answer was corrent!!!!")
                purses(currentPlayer) += 1
                Console.WriteLine(players(currentPlayer) + " now has " + purses(currentPlayer) + " Gold Coins.")

                Dim winner As Boolean = didPlayerWin()
                currentPlayer += 1
                If currentPlayer = players.Count Then
                    currentPlayer = 0
                End If

                Return winner
            End If
        End Function

        Public Function wrongAnswer() As Boolean
            Console.WriteLine("Question was incorrectly answered")
            Console.WriteLine(players(currentPlayer) + " was sent to the penalty box")
            inPenaltyBox(currentPlayer) = True

            currentPlayer += 1
            If currentPlayer = players.Count Then
                currentPlayer = 0
            End If
            Return True
        End Function


        Private Function didPlayerWin() As Boolean
            Return Not (purses(currentPlayer) = 6)
        End Function
    End Class
End NameSpace