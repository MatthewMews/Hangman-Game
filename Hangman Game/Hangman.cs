using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Hangman_Game
{
    public partial class Hangman_Form : Form
    {
        List<string> questionList = new List<string>(new string[] {
            "The name of a transport vehicle?",
            "What day is the first of the week?",
            "What is commonly purchased from a takeway?",
            "A country shaped like a boot?",
            "Football's coming... ?",
        });

        private List<Label> listOfLetterLabels = new List<Label>();
        private List<PictureBox> listOfHangmanParts = new List<PictureBox>();
        private List<Label> listOfHangmanFields = new List<Label>();
        private List<Label> listOfUnderlines = new List<Label>();

        private static List<char> chosenLetters = new List<char>();

        private static string selectedQuestion = String.Empty;
        private static string answer = String.Empty;
        private static int numOfCorrectGuesses = 0;
        private static int numOfIncorrectGuesses = 0;
        private static bool gameCompeleted = false;

        public Hangman_Form()
        {
            InitializeComponent();

            GetGameObjects();

            PlayGame();
        }

        private void GetGameObjects()
        {
            listOfLetterLabels.Add(lbl_Letter_A);
            listOfLetterLabels.Add(lbl_Letter_B);
            listOfLetterLabels.Add(lbl_Letter_C);
            listOfLetterLabels.Add(lbl_Letter_D);
            listOfLetterLabels.Add(lbl_Letter_E);
            listOfLetterLabels.Add(lbl_Letter_F);
            listOfLetterLabels.Add(lbl_Letter_G);
            listOfLetterLabels.Add(lbl_Letter_H);
            listOfLetterLabels.Add(lbl_Letter_I);
            listOfLetterLabels.Add(lbl_Letter_J);
            listOfLetterLabels.Add(lbl_Letter_K);
            listOfLetterLabels.Add(lbl_Letter_L);
            listOfLetterLabels.Add(lbl_Letter_M);
            listOfLetterLabels.Add(lbl_Letter_N);
            listOfLetterLabels.Add(lbl_Letter_O);
            listOfLetterLabels.Add(lbl_Letter_P);
            listOfLetterLabels.Add(lbl_Letter_Q);
            listOfLetterLabels.Add(lbl_Letter_R);
            listOfLetterLabels.Add(lbl_Letter_S);
            listOfLetterLabels.Add(lbl_Letter_T);
            listOfLetterLabels.Add(lbl_Letter_U);
            listOfLetterLabels.Add(lbl_Letter_V);
            listOfLetterLabels.Add(lbl_Letter_W);
            listOfLetterLabels.Add(lbl_Letter_X);
            listOfLetterLabels.Add(lbl_Letter_Y);
            listOfLetterLabels.Add(lbl_Letter_Z);

            listOfHangmanParts.Add(hangman_frame_one);
            listOfHangmanParts.Add(hangman_frame_two);
            listOfHangmanParts.Add(hangman_frame_three);
            listOfHangmanParts.Add(hangman_frame_four);
            listOfHangmanParts.Add(hangman_head);
            listOfHangmanParts.Add(hangman_body);
            listOfHangmanParts.Add(hangman_left_arm);
            listOfHangmanParts.Add(hangman_left_leg);
            listOfHangmanParts.Add(hangman_right_arm);
            listOfHangmanParts.Add(hangman_right_leg);

            listOfHangmanFields.Add(hangman_field_one);
            listOfHangmanFields.Add(hangman_field_two);
            listOfHangmanFields.Add(hangman_field_three);
            listOfHangmanFields.Add(hangman_field_four);
            listOfHangmanFields.Add(hangman_field_five);
            listOfHangmanFields.Add(hangman_field_six);
            listOfHangmanFields.Add(hangman_field_seven);
            listOfHangmanFields.Add(hangman_field_eight);
            listOfHangmanFields.Add(hangman_field_nine);
            listOfHangmanFields.Add(hangman_field_ten);

            listOfUnderlines.Add(hangman_underline_one);
            listOfUnderlines.Add(hangman_underline_two);
            listOfUnderlines.Add(hangman_underline_three);
            listOfUnderlines.Add(hangman_underline_four);
            listOfUnderlines.Add(hangman_underline_five);
            listOfUnderlines.Add(hangman_underline_six);
            listOfUnderlines.Add(hangman_underline_seven);
            listOfUnderlines.Add(hangman_underline_eight);
            listOfUnderlines.Add(hangman_underline_nine);
            listOfUnderlines.Add(hangman_underline_ten);
        }

        private void PlayGame()
        {
            GetQuestion();

            GetAnswerToQuestion();

            UpdateFormElements();
        }

        private void GetQuestion()
        {
            Random random = new Random();

            selectedQuestion = questionList[random.Next(questionList.Count)];

            lbl_Question.Text = "Question:  " + selectedQuestion;
        }

        private void GetAnswerToQuestion()
        {
            Debug.WriteLine("Selected Question: " + selectedQuestion);

            switch (selectedQuestion)
            {
                case "The name of a transport vehicle?": answer = "Car"; break;
                case "What day is the first of the week?": answer = "Monday"; break;
                case "What is commonly purchased from a takeway?": answer = "Pizza"; break;
                case "A country shaped like a boot?": answer = "Italy"; break;
                case "Football's coming... ?": answer = "Home"; break;

                default: throw new Exception($"Unable to find a answer to question {selectedQuestion}.");
            }

            if (answer.Length > 10)
            {
                throw new Exception($"The answer for the question '{selectedQuestion}' exceeds the 10 character limit.");
            }
        }

        private void UpdateFormElements()
        {
            for (int i = 0; i <= answer.Length - 1; i++)
            {
                listOfUnderlines[i].Visible = true;
            }
        }

        private void Letter_Clicked(object sender, EventArgs e)
        {
            Label letter = sender as Label;

            char[] alphabetArray = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            for (int i = 0; i <= alphabetArray.Length - 1; i++)
            {
                try
                {
                    if (letter.Text == alphabetArray[i].ToString())
                    {
                        CheckForLetters(alphabetArray[i]);
                        break;
                    }
                }
                catch
                {
                    throw new Exception("Error attempting to pass letter into CheckForLetters Function.");
                }
            }
        }

        // If the player presses a letter on the keyboard rather than clicking with the mouse.
        private void HangmanForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Debug.WriteLine("KeyCode: " + e.KeyChar);

            char[] alphabetArray = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            for (int i = 0; i <= alphabetArray.Length - 1; i++)
            {
                try
                {
                    if (char.ToUpper(e.KeyChar) == alphabetArray[i])
                    {
                        CheckForLetters(alphabetArray[i]); break;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error attempting to pass letter into CheckForLetters Function: " + ex);
                }
            }
        }

        private void CheckForLetters(char letterClicked)
        {
            if (gameCompeleted == true)
            {
                lbl_RestartMessage.ForeColor = Color.Yellow;
                lbl_RestartMessage.Text = "Please click 'Reset' to start a new game.";

                return;
            }

            lbl_Message.Text = String.Empty;
            lbl_Message.ForeColor = Color.White;

            char[] result = answer.ToUpper().ToCharArray();

            if (chosenLetters.Contains(letterClicked))
            {
                lbl_Message.ForeColor = Color.Yellow;
                lbl_Message.Text = ($"The letter '{letterClicked}' has already been chosen.");
                return;
            }

            if (answer.ToUpper().Contains(letterClicked))
            {
                for (int i = 0; i <= result.Length - 1; i++)
                {
                    if (letterClicked == result[i])
                    {
                        if (result[i] == result[0])
                        {
                            listOfHangmanFields[i].Text = letterClicked.ToString();
                        }
                        else
                        {
                            listOfHangmanFields[i].Text = letterClicked.ToString().ToLower();
                        }

                        listOfHangmanFields[i].Visible = true;
                        chosenLetters.Add(letterClicked);
                        numOfCorrectGuesses++;
                        break;
                    }
                }

                lbl_NumOfCorrectGuesses.Text = "Number of Correct Guesses: " + numOfCorrectGuesses;

                // change color to green if the guess is incorrect.
                for (int i = 0; i <= listOfLetterLabels.Count - 1; i++)
                {
                    if (letterClicked == listOfLetterLabels[i].Text.ToCharArray()[0])
                    {
                        listOfLetterLabels[i].ForeColor = Color.Green; break;
                    }
                }

                if (numOfCorrectGuesses == answer.Length)
                {
                    lbl_NumOfTotalGuesses.Text = "Total Guesses: " + (numOfCorrectGuesses + numOfIncorrectGuesses).ToString();

                    lbl_Message.ForeColor = Color.DarkGreen;
                    lbl_Message.Text = "You Win!";
                    gameCompeleted = true;

                    return;
                }
            }
            else
            {
                numOfIncorrectGuesses++;

                lbl_NumOfWrongGuesses.Text = "Number of Wrong Guesses: " + numOfIncorrectGuesses;

                chosenLetters.Add(letterClicked);

                // make a hangman part visible
                for (int i = 1; i <= listOfHangmanParts.Count; i++)
                {
                    if (numOfIncorrectGuesses == i)
                    {
                        listOfHangmanParts[i - 1].Visible = true; break;
                    }
                }

                // change color to red if the guess is incorrect.
                for (int i = 0; i <= listOfLetterLabels.Count - 1; i++)
                {
                    if (letterClicked == listOfLetterLabels[i].Text.ToCharArray()[0])
                    {
                        listOfLetterLabels[i].ForeColor = Color.Red; break;
                    }
                }
            }

            lbl_NumOfTotalGuesses.Text = "Total Guesses: " + (numOfCorrectGuesses + numOfIncorrectGuesses).ToString();

            if (numOfIncorrectGuesses >= 10) // The player has 10 attempts to guess before game over.
            {
                lbl_Message.ForeColor = Color.Red;
                lbl_Message.Text = "You are out of guesses! You Lose.";
                gameCompeleted = true;

                return;
            }

            Debug.WriteLine("Chosen Letters: " + string.Join(", ", chosenLetters));
        }

        private void ResetGameElements()
        {
            var labels = this.Controls.OfType<Label>();

            foreach (var label in labels)
            {
                if (label.Name.Contains("lbl_Letter") || label.Name.Contains("lbl_Message") || label.Name.Contains("lbl_RestartMesssage"))
                {
                    label.ForeColor = Color.White;
                }
            }

            for (int i = 0; i <= listOfHangmanParts.Count - 1; i++)
            {
                listOfHangmanParts[i].Visible = false;
            }

            for (int i = 0; i <= listOfHangmanFields.Count - 1; i++)
            {
                listOfHangmanFields[i].Visible = false;
            }

            for (int i = 0; i <= listOfUnderlines.Count - 1; i++)
            {
                listOfUnderlines[i].Visible = false;
            }

            selectedQuestion = String.Empty;
            lbl_Question.Text = String.Empty;
            lbl_Message.Text = String.Empty;
            lbl_RestartMessage.Text = String.Empty;
            chosenLetters.Clear();

            numOfIncorrectGuesses = 0;
            numOfCorrectGuesses = 0;

            lbl_NumOfCorrectGuesses.Text = "Number of Correct Guesses: " + numOfCorrectGuesses;
            lbl_NumOfWrongGuesses.Text = "Number of Wrong Guesses: " + numOfCorrectGuesses;
            lbl_NumOfTotalGuesses.Text = "Total Guesses: " + 0;

            gameCompeleted = false;
        }

        private void Reset_Game_Button(object sender, EventArgs e)
        {
            ResetGameElements();

            PlayGame();
        }

        private void Exit_Program(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}