using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordGuessApplication1
{
    public partial class Form1 : Form
    {
        private string[] words = new[]{ "ironman", "batman", "superman", "spiderman",
                                        "aquaman", "hevabi", "aljames", "voltier",
                                        "anjo pogi", "chocolate", "reynold" };

        private int index = 0;  
        private int score = 0;  
        private bool gameStarted = false;  // the game is started
        Random random = new Random();  // for random 

        public Form1()
        {
            InitializeComponent();
        }

        //start the game or check guesses 
        private void button1_Click(object sender, EventArgs e)
        {
            if (!gameStarted)
            {
          
                StartGame();
            }
            else
            {
                
                CheckWord();
            }
        }

        //start and reset the game
        private void StartGame()
        {
            // reset score and index
            index = 0;
            score = 0;
            listBox1.Items.Clear();  // clear wrong guesses
            label1.Text = "Result";
            label1.BackColor = Color.Peru;
            label2.Text = "Score: 00";  // reset score display
            displayWord();  // Display the first word with hidden letters
            gameStarted = true;  // Mark the game as started
            button1.Text = "Guess";  // Change button text to 'Guess'
        }

        public void displayWord()
        {
            string word = words[index];  // Get the current word to guess
            StringBuilder sb = new StringBuilder(word);

            // randomly select 3 positions to hide letters
            int pos1 = random.Next(word.Length);
            int pos2, pos3;
            do { pos2 = random.Next(word.Length); } while (pos2 == pos1);
            do { pos3 = random.Next(word.Length); } while (pos3 == pos1 || pos3 == pos2);

            // replace characters with selected positions with '?'
            sb[pos1] = '?';
            sb[pos2] = '?';
            sb[pos3] = '?';

            // display the word with hidden characters
            label1.Text = sb.ToString();
        }

        //check if the guessed word is correct
        public void CheckWord()
        {
            string guessedWord = textBox1.Text.ToLower();  // get the guessed word

            if (guessedWord.Equals(words[index]))
            {
                label1.Text = "Correct!";
                label1.BackColor = Color.Green;
                score++;  
            }
            else
            {
                label1.Text = "Wrong!";
                label1.BackColor = Color.Red;
                listBox1.Items.Add(guessedWord);  // add wrong guess to lsitbox
            }

            
            label2.Text = $"Score: {score} / {words.Length}";

            // clear the text box 
            textBox1.Text = "";

            // check if there are more words left to guess
            if (index < words.Length - 1)
            {
                index++; 
                displayWord();  
            }
            else
            {
                // if all words are guessed, end the game
                label1.Text = "Game Over!";
                button1.Text = "Start Over";  // change button text to 'Start Over'
                gameStarted = false;  //game finished
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
