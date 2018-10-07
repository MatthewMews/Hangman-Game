using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Hangman_Game
{
    public partial class object_7 : Form
    {
        List<string> questionList = new List<string>();
        private static string selectedQuestion = String.Empty;
        private static string answer = String.Empty;
        private static int numOfIncorrectAttempts = 0;
        private static int numOfCorrectGuesses = 0;

        public object_7()
        {
            InitializeComponent();

            CreateQuestions();

            PlayGame();
        }

        private void CreateQuestions()
        {
            questionList.Add("A name of a transport vehicle?");
            questionList.Add("What day is the first of the week?");
            questionList.Add("What food item is commonly purchased from an takeway?");
            questionList.Add("Winne The ... ?");
            questionList.Add("Football's coming  ... ?");
        }

        private void PlayGame()
        {
            Random random = new Random();

            int randomInt = random.Next(questionList.Count);

            selectedQuestion = questionList[randomInt];

            question_label.Text = "Question:   " + selectedQuestion;

            GetAnswerToQuestion();

            UpdateFormElements();
        }

        private void GetAnswerToQuestion()
        {
            Debug.WriteLine("Selected Question: " + selectedQuestion);

            switch (selectedQuestion)
            {
                case "A name of a transport vehicle?": answer = "Car"; break;
                case "What day is the first of the week?": answer = "Monday"; break;
                case "What food item is commonly purchased from an takeway?": answer = "Pizza"; break;
                case "Winne The ... ?": answer = "Pooh"; break;
                case "Football's coming  ... ?": answer = "Home"; break;
                default: MessageBox.Show("An error has occurred when attempting to attain answer."); break;
            }
        }

        private void UpdateFormElements()
        {
            switch (answer.Length)
            {
                case 1: hangman_underline_one.Visible = true; break;
                case 2: hangman_underline_one.Visible = true; hangman_underline_two.Visible = true; hangman_underline_two.Visible = true; break;
                case 3: hangman_underline_one.Visible = true; hangman_underline_two.Visible = true; hangman_underline_two.Visible = true; hangman_underline_three.Visible = true; break;
                case 4: hangman_underline_one.Visible = true; hangman_underline_two.Visible = true; hangman_underline_two.Visible = true; hangman_underline_three.Visible = true; hangman_underline_four.Visible = true; break;
                case 5: hangman_underline_one.Visible = true; hangman_underline_two.Visible = true; hangman_underline_two.Visible = true; hangman_underline_three.Visible = true; hangman_underline_four.Visible = true; hangman_underline_five.Visible = true; break;
                case 6: hangman_underline_one.Visible = true; hangman_underline_two.Visible = true; hangman_underline_two.Visible = true; hangman_underline_three.Visible = true; hangman_underline_four.Visible = true; hangman_underline_five.Visible = true; hangman_underline_six.Visible = true; break;
                case 7: hangman_underline_one.Visible = true; hangman_underline_two.Visible = true; hangman_underline_two.Visible = true; hangman_underline_three.Visible = true; hangman_underline_four.Visible = true; hangman_underline_five.Visible = true; hangman_underline_six.Visible = true; hangman_underline_seven.Visible = true; break;
                case 8: hangman_underline_one.Visible = true; hangman_underline_two.Visible = true; hangman_underline_two.Visible = true; hangman_underline_three.Visible = true; hangman_underline_four.Visible = true; hangman_underline_five.Visible = true; hangman_underline_six.Visible = true; hangman_underline_seven.Visible = true; hangman_underline_eight.Visible = true; break;
                case 9: hangman_underline_one.Visible = true; hangman_underline_two.Visible = true; hangman_underline_two.Visible = true; hangman_underline_three.Visible = true; hangman_underline_four.Visible = true; hangman_underline_five.Visible = true; hangman_underline_six.Visible = true; hangman_underline_seven.Visible = true; hangman_underline_eight.Visible = true; hangman_underline_nine.Visible = true; break;
                case 10: hangman_underline_one.Visible = true; hangman_underline_two.Visible = true; hangman_underline_two.Visible = true; hangman_underline_three.Visible = true; hangman_underline_four.Visible = true; hangman_underline_five.Visible = true; hangman_underline_six.Visible = true; hangman_underline_seven.Visible = true; hangman_underline_eight.Visible = true; hangman_underline_nine.Visible = true; hangman_underline_ten.Visible = true; break;

                default: MessageBox.Show("An error has occurred while attempting to make the hangman fields visible"); break;
            }
        }

        private void CheckForLetters(char letterClicked)
        {
            char[] result = answer.ToLower().ToCharArray();

            Debug.WriteLine("Result Length: " + result.Length);

            if (answer.ToLower().Contains(letterClicked))
            {
                if (result.Length >= 1) { if (letterClicked == result[0]) { hangman_field_one.Text = letterClicked.ToString().ToUpper(); hangman_field_one.Visible = true; numOfCorrectGuesses++; } }
                if (result.Length >= 2) { if (letterClicked == result[1]) { hangman_field_two.Text = letterClicked.ToString(); hangman_field_two.Visible = true; numOfCorrectGuesses++; } }
                if (result.Length >= 3) { if (letterClicked == result[2]) { hangman_field_three.Text = letterClicked.ToString(); hangman_field_three.Visible = true; numOfCorrectGuesses++; } }
                if (result.Length >= 4) { if (letterClicked == result[3]) { hangman_field_four.Text = letterClicked.ToString(); hangman_field_four.Visible = true; numOfCorrectGuesses++; } }
                if (result.Length >= 5) { if (letterClicked == result[4]) { hangman_field_five.Text = letterClicked.ToString(); hangman_field_five.Visible = true; numOfCorrectGuesses++; } }
                if (result.Length >= 6) { if (letterClicked == result[5]) { hangman_field_six.Text = letterClicked.ToString(); hangman_field_six.Visible = true; numOfCorrectGuesses++; } }
                if (result.Length >= 7) { if (letterClicked == result[6]) { hangman_field_seven.Text = letterClicked.ToString(); hangman_field_seven.Visible = true; numOfCorrectGuesses++; } }
                if (result.Length >= 8) { if (letterClicked == result[7]) { hangman_field_eight.Text = letterClicked.ToString(); hangman_field_eight.Visible = true; numOfCorrectGuesses++; } }
                if (result.Length >= 9) { if (letterClicked == result[8]) { hangman_field_nine.Text = letterClicked.ToString(); hangman_field_nine.Visible = true; numOfCorrectGuesses++; } }
                if (result.Length >= 10) { if (letterClicked == result[9]) { hangman_field_ten.Text = letterClicked.ToString(); hangman_field_ten.Visible = true; numOfCorrectGuesses++; } }
               
                // Change colour to green if correct
                switch (Char.ToLower(letterClicked))
                {
                    case 'a': letter_a_label.ForeColor = Color.Green; break;
                    case 'b': letter_b_label.ForeColor = Color.Green; break;
                    case 'c': letter_c_label.ForeColor = Color.Green; break;
                    case 'd': letter_d_label.ForeColor = Color.Green; break;
                    case 'e': letter_e_label.ForeColor = Color.Green; break;
                    case 'f': letter_f_label.ForeColor = Color.Green; break;
                    case 'g': letter_g_label.ForeColor = Color.Green; break;
                    case 'h': letter_h_label.ForeColor = Color.Green; break;
                    case 'i': letter_i_label.ForeColor = Color.Green; break;
                    case 'j': letter_j_label.ForeColor = Color.Green; break;
                    case 'k': letter_k_label.ForeColor = Color.Green; break;
                    case 'm': letter_m__label.ForeColor = Color.Green; break;
                    case 'n': letter_n_label.ForeColor = Color.Green; break;
                    case 'o': letter_o_label.ForeColor = Color.Green; break;
                    case 'p': letter_p_label.ForeColor = Color.Green; break;
                    case 'q': letter_q_label.ForeColor = Color.Green; break;
                    case 'r': letter_r_label.ForeColor = Color.Green; break;
                    case 's': letter_s_label.ForeColor = Color.Green; break;
                    case 't': letter_t_label.ForeColor = Color.Green; break;
                    case 'u': letter_u_label.ForeColor = Color.Green; break;
                    case 'v': letter_v_label.ForeColor = Color.Green; break;
                    case 'w': letter_w_label.ForeColor = Color.Green; break;
                    case 'x': letter_x_label.ForeColor = Color.Green; break;
                    case 'y': letter_y_label.ForeColor = Color.Green; break;
                    case 'z': letter_z_label.ForeColor = Color.Green; break;
                }                 

                if(numOfCorrectGuesses == answer.Length)
                {
                    MessageBox.Show("You Win!");
                    ResetGameElements();                
                }
            }
            else
            {
                numOfIncorrectAttempts++;

                switch(numOfIncorrectAttempts)
                {
                    case 1: hangman_object_one.Visible = true; break;
                    case 2: hangman_object_two.Visible = true; break;
                    case 3: hangman_object_three.Visible = true; break;
                    case 4: hangman_object_four.Visible = true; break;
                    case 5: hangman_object_five.Visible = true; break;
                    case 6: hangman_object_six.Visible = true; break;
                    case 7: hangman_object_seven.Visible = true; break;
                    case 8: hangman_object_eight.Visible = true; break;
                    case 9: hangman_object_nine.Visible = true; break;
                    case 10: hangman_object_ten.Visible = true; break;
                }

                // change color to red if incorrect.
                switch (Char.ToLower(letterClicked))
                {
                    case 'a': letter_a_label.ForeColor = Color.Red; break;
                    case 'b': letter_b_label.ForeColor = Color.Red; break;
                    case 'c': letter_c_label.ForeColor = Color.Red; break;
                    case 'd': letter_d_label.ForeColor = Color.Red; break;
                    case 'e': letter_e_label.ForeColor = Color.Red; break;
                    case 'f': letter_f_label.ForeColor = Color.Red; break;
                    case 'g': letter_g_label.ForeColor = Color.Red; break;
                    case 'h': letter_h_label.ForeColor = Color.Red; break;
                    case 'i': letter_i_label.ForeColor = Color.Red; break;
                    case 'j': letter_j_label.ForeColor = Color.Red; break;
                    case 'k': letter_k_label.ForeColor = Color.Red; break;
                    case 'm': letter_m__label.ForeColor = Color.Red; break;
                    case 'n': letter_n_label.ForeColor = Color.Red; break;
                    case 'o': letter_o_label.ForeColor = Color.Red; break;
                    case 'p': letter_p_label.ForeColor = Color.Red; break;
                    case 'q': letter_q_label.ForeColor = Color.Red; break;
                    case 'r': letter_r_label.ForeColor = Color.Red; break;
                    case 's': letter_s_label.ForeColor = Color.Red; break;
                    case 't': letter_t_label.ForeColor = Color.Red; break;
                    case 'u': letter_u_label.ForeColor = Color.Red; break;
                    case 'v': letter_v_label.ForeColor = Color.Red; break;
                    case 'w': letter_w_label.ForeColor = Color.Red; break;
                    case 'x': letter_x_label.ForeColor = Color.Red; break;
                    case 'y': letter_y_label.ForeColor = Color.Red; break;
                    case 'z': letter_z_label.ForeColor = Color.Red; break;
                }
            }
           
            if (numOfIncorrectAttempts >= 10) // change this depending on how many attemps there are.
            {
                MessageBox.Show("You are out of attempts! Game Over.");
                ResetGameElements();
            }

            Debug.WriteLine("Num of Correct Guesses: " + numOfCorrectGuesses);
        }

        private void ResetGameElements()
        {
            var labels = this.Controls.OfType<Label>();

            foreach(var label in labels)
            {
                if(label.Name.Contains("letter"))
                {
                    label.ForeColor = Color.White;
                }
            }

            hangman_object_one.Visible = false;
            hangman_object_two.Visible = false;
            hangman_object_three.Visible = false;
            hangman_object_four.Visible = false;
            hangman_object_five.Visible = false;
            hangman_object_six.Visible = false;
            hangman_object_seven.Visible = false;
            hangman_object_eight.Visible = false;
            hangman_object_nine.Visible = false;
            hangman_object_ten.Visible = false;

            hangman_field_one.Visible = false;
            hangman_field_two.Visible = false;
            hangman_field_three.Visible = false;
            hangman_field_four.Visible = false;
            hangman_field_five.Visible = false;
            hangman_field_six.Visible = false;
            hangman_field_seven.Visible = false;
            hangman_field_eight.Visible = false;
            hangman_field_nine.Visible = false;
            hangman_field_ten.Visible = false;

            hangman_underline_one.Visible = false;
            hangman_underline_two.Visible = false;
            hangman_underline_three.Visible = false;
            hangman_underline_four.Visible = false;
            hangman_underline_five.Visible = false;
            hangman_underline_six.Visible = false;
            hangman_underline_seven.Visible = false;
            hangman_underline_seven.Visible = false;
            hangman_underline_eight.Visible = false;
            hangman_underline_nine.Visible = false;
            hangman_underline_ten.Visible = false;
        
            selectedQuestion = String.Empty;
            question_label.Text = String.Empty;

            numOfIncorrectAttempts = 0;
            numOfCorrectGuesses = 0;

            PlayGame();
        }

        private void Reset_Game_Button(object sender, EventArgs e)
        {
            ResetGameElements();

            PlayGame();
        }

        private void Exit_Button(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Letter_A_Label_Clicked(object sender, EventArgs e) { char letterClicked = 'a'; CheckForLetters(letterClicked); }
        private void Letter_B_Label_Clicked(object sender, EventArgs e) { char letterClicked = 'b'; CheckForLetters(letterClicked); }
        private void Letter_C_Label_Clicked(object sender, EventArgs e) { char letterClicked = 'c'; CheckForLetters(letterClicked); }
        private void Letter_D_Label_Clicked(object sender, EventArgs e) { char letterClicked = 'd'; CheckForLetters(letterClicked); }
        private void Letter_E_Label_Clicked(object sender, EventArgs e) { char letterClicked = 'e'; CheckForLetters(letterClicked); }
        private void Letter_F_Label_Clicked(object sender, EventArgs e) { char letterClicked = 'f'; CheckForLetters(letterClicked); }
        private void Letter_G_Label_Clicked(object sender, EventArgs e) { char letterClicked = 'g'; CheckForLetters(letterClicked); }
        private void Letter_H_Label_Clicked(object sender, EventArgs e) { char letterClicked = 'h'; CheckForLetters(letterClicked); }
        private void Letter_I_Label_Clicked(object sender, EventArgs e) { char letterClicked = 'i'; CheckForLetters(letterClicked); }
        private void Letter_J_Label_Clicked(object sender, EventArgs e) { char letterClicked = 'j'; CheckForLetters(letterClicked); }
        private void Letter_K_Label_Clicked(object sender, EventArgs e) { char letterClicked = 'k'; CheckForLetters(letterClicked); }
        private void Letter_L_Label_Clicked(object sender, EventArgs e) { char letterClicked = 'l'; CheckForLetters(letterClicked); }
        private void Letter_M_Label_Clicked(object sender, EventArgs e) { char letterClicked = 'm'; CheckForLetters(letterClicked); }
        private void Letter_N_Label_Clicked(object sender, EventArgs e) { char letterClicked = 'n'; CheckForLetters(letterClicked); }
        private void Letter_O_Label_Clicked(object sender, EventArgs e) { char letterClicked = 'o'; CheckForLetters(letterClicked); }
        private void Letter_P_Label_Clicked(object sender, EventArgs e) { char letterClicked = 'p'; CheckForLetters(letterClicked); }
        private void Letter_Q_Label_Clicked(object sender, EventArgs e) { char letterClicked = 'q'; CheckForLetters(letterClicked); }
        private void Letter_R_Label_Clicked(object sender, EventArgs e) { char letterClicked = 'r'; CheckForLetters(letterClicked); }
        private void Letter_S_Label_Clicked(object sender, EventArgs e) { char letterClicked = 's'; CheckForLetters(letterClicked); }
        private void Letter_T_Label_Clicked(object sender, EventArgs e) { char letterClicked = 't'; CheckForLetters(letterClicked); }
        private void Letter_U_Label_Clicked(object sender, EventArgs e) { char letterClicked = 'u'; CheckForLetters(letterClicked); }
        private void Letter_V_Label_Clicked(object sender, EventArgs e) { char letterClicked = 'v'; CheckForLetters(letterClicked); }
        private void Letter_W_Label_Clicked(object sender, EventArgs e) { char letterClicked = 'w'; CheckForLetters(letterClicked); }
        private void Letter_X_Label_Clicked(object sender, EventArgs e) { char letterClicked = 'x'; CheckForLetters(letterClicked); }
        private void Letter_Y_Label_Clicked(object sender, EventArgs e) { char letterClicked = 'y'; CheckForLetters(letterClicked); }
        private void Letter_Z_Label_Clicked(object sender, EventArgs e) { char letterClicked = 'z'; CheckForLetters(letterClicked); }
    }
}
