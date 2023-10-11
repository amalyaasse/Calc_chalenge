using System;
using Xamarin.Forms;

namespace Calc_chalange
{
    public partial class MainPage : ContentPage
    {
        private int correctAnswers = 0;
        private int wrongAnswers = 0;
        
        private int totalQuestions = 2; // Anzahl der Fragen für die Übung
        private Random random = new Random();

        public MainPage()
        {
            InitializeComponent();
            GenerateQuestion();
            
        }

        private void GenerateQuestion()
        {
            int num1 = random.Next(1, 100);
            int num2 = random.Next(1, 100);
            int correctAnswer = num1 + num2;

            questionLabel.Text = $"{num1} + {num2} = ?";
            correctAnswerLabel.Text = correctAnswer.ToString();
            correctAnswerLabel.IsVisible = false;
            

        }

        private void CheckAnswer(object sender, EventArgs e)
        {
            int userAnswer;
            if (int.TryParse(answerEntry.Text, out userAnswer))
            {
                int correctAnswer = int.Parse(correctAnswerLabel.Text);
                if (userAnswer == correctAnswer)
                {
                    DisplayAlert("Richtig", "Gut gemacht!", "OK");
                    correctAnswers++;
                }
                else
                {
                    DisplayAlert("Falsch", $"Die richtige Antwort ist {correctAnswer}", "OK");
                    wrongAnswers++;
                }

                if (correctAnswers + wrongAnswers < totalQuestions)
                {
                    GenerateQuestion();
                    answerEntry.Text = "";
                    correctAnswerLabel.IsVisible = false;
                }
                else
                {
                    // Alle Aufgaben wurden beantwortet, zeige die Zusammenfassung
                    ShowSummary();
                }
            }
        }

        private void ShowSummary()
        {
            questionLabel.Text = "Übung abgeschlossen!";
            correctAnswerLabel.Text = $"Richtig beantwortet: {correctAnswers}/{totalQuestions}";
            summaryLabel.Text = $"Falsch beantwortet: {wrongAnswers}/{totalQuestions}";
            correctAnswerLabel.IsVisible = true;
            summaryLabel.IsVisible = true;
            restartButton.IsVisible = true;
            


        }

        private void RestartExercise(object sender, EventArgs e)
        {
            correctAnswers = 0;
            wrongAnswers = 0;
            correctAnswerLabel.IsVisible = false;
            summaryLabel.IsVisible = false;
            
            GenerateQuestion();
            restartButton.IsVisible = true;
        }


    }
}
