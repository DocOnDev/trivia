
Namespace UglyTrivia
    Public Module GameRunner

        Private notAWinner As Boolean

        Public Sub Main()
            Dim aGame As New Game()

            aGame.add("Chet")
            aGame.add("Pat")
            aGame.add("Sue")

            Dim rand As New Random()

            Do

                aGame.roll(rand.[Next](5) + 1)

                If rand.[Next](9) = 7 Then
                    notAWinner = aGame.wrongAnswer()
                Else
                    notAWinner = aGame.wasCorrectlyAnswered()



                End If
            Loop While notAWinner

        End Sub
    End Module
End Namespace