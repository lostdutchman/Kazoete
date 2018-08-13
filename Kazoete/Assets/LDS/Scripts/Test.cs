using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour {

    //Test Manager
    public int wrongThreshold = 3;
    public Text score, level, number, gameOverScore;
    public GameObject[] buttons;
    public int gameMode = 3; //1 = Romanji, 2 = Kana, 3 = Kanji
    public AudioSource audioSource;
    public AudioClip wrongFX, rightFX;
    public GameObject Game, GameOver;

    private int currentLevel = 1;
    private int highscore = 0;

    //Test
    private int correctAnswer = 0;


    // Use this for initialization
    void Start () {
        gameMode = PlayerPrefs.GetInt("game_mode");
        Game.SetActive(true);
        GameOver.SetActive(false);
        ScoreBoard();
        GetQuestion();
    }

    public void GetQuestion()
    {
        switch(currentLevel)
        {
            case 1: Level1(); break;
            case 2: Level2(); break;
            case 3: Level3(); break;
            case 4: Level4(); break;
            case 5: Level5(); break;
            case 6: Level6(); break;
            default: Level7(); break;
        }
    }

    private void Level1()
    {
        if (highscore >= 10)
        {
            LevelUp();
            GetQuestion();
        }
        else
        {
            number.text = (highscore + 1).ToString();
            correctAnswer = (UnityEngine.Random.Range(0, 6));
            List<int> used = new List<int>();
            used.Add(highscore + 1);
            for(int i = 0; i < 6; i++ )
            {
                int wrongAnswer = UnityEngine.Random.Range(1, 11);
                if (!used.Contains(wrongAnswer))
                {
                    buttons[i].GetComponentInChildren<Text>().text = Translate(wrongAnswer);
                    used.Add(wrongAnswer);
                }
                else
                {
                    i--;
                }
            }
            buttons[correctAnswer].GetComponentInChildren<Text>().text = Translate(highscore + 1);
        }
    }

    private void Level2()
    {
        if (highscore >= 25)
        {
            LevelUp();
            GetQuestion();
        }
        else
        {
            number.text = (highscore + 1).ToString();
            correctAnswer = (UnityEngine.Random.Range(0, 6));
            List<int> used = new List<int>();
            used.Add(highscore + 1);
            for (int i = 0; i < 6; i++)
            {
                int wrongAnswer = UnityEngine.Random.Range(11, 26);
                if (!used.Contains(wrongAnswer))
                {
                    buttons[i].GetComponentInChildren<Text>().text = Translate(wrongAnswer);
                    used.Add(wrongAnswer);
                }
                else
                {
                    i--;
                }
            }
            buttons[correctAnswer].GetComponentInChildren<Text>().text = Translate(highscore + 1);
        }
    }

    private void Level3()
    {
        if (highscore >= 45)
        {
            LevelUp();
            GetQuestion();
        }
        else
        {
            int thisAnswer = UnityEngine.Random.Range(10, 100);
            number.text = thisAnswer.ToString();
            correctAnswer = (UnityEngine.Random.Range(0, 6));
            List<int> used = new List<int>();
            used.Add(thisAnswer);
            for (int i = 0; i < 6; i++)
            {
                int wrongAnswer = UnityEngine.Random.Range(10, 100);
                if (!used.Contains(wrongAnswer))
                {
                    buttons[i].GetComponentInChildren<Text>().text = Translate(wrongAnswer);
                    used.Add(wrongAnswer);
                }
                else
                {
                    i--;
                }
            }
            buttons[correctAnswer].GetComponentInChildren<Text>().text = Translate(thisAnswer);
        }
    }

    private void Level4()
    {
        if (highscore >= 65)
        {
            LevelUp();
            GetQuestion();
        }
        else
        {
            int thisAnswer = UnityEngine.Random.Range(100, 1000);
            number.text = thisAnswer.ToString();
            correctAnswer = (UnityEngine.Random.Range(0, 6));
            List<int> used = new List<int>();
            used.Add(thisAnswer);
            for (int i = 0; i < 6; i++)
            {
                int wrongAnswer = UnityEngine.Random.Range(100, 1000);
                if (!used.Contains(wrongAnswer))
                {
                    buttons[i].GetComponentInChildren<Text>().text = Translate(wrongAnswer);
                    used.Add(wrongAnswer);
                }
                else
                {
                    i--;
                }
            }
            buttons[correctAnswer].GetComponentInChildren<Text>().text = Translate(thisAnswer);
        }
    }

    private void Level5()
    {
        if (highscore >= 85)
        {
            LevelUp();
            GetQuestion();
        }
        else
        {
            int thisAnswer = UnityEngine.Random.Range(1000, 10000);
            number.text = thisAnswer.ToString();
            correctAnswer = (UnityEngine.Random.Range(0, 6));
            List<int> used = new List<int>();
            used.Add(thisAnswer);
            for (int i = 0; i < 6; i++)
            {
                int wrongAnswer = UnityEngine.Random.Range(10, 100);
                if (!used.Contains(wrongAnswer))
                {
                    buttons[i].GetComponentInChildren<Text>().text = Translate(wrongAnswer);
                    used.Add(wrongAnswer);
                }
                else
                {
                    i--;
                }
            }
            buttons[correctAnswer].GetComponentInChildren<Text>().text = Translate(thisAnswer);
        }
    }

    private void Level6()
    {
        if (highscore >= 105)
        {
            LevelUp();
            GetQuestion();
        }
        else
        {
            int thisAnswer = UnityEngine.Random.Range(10000, 100000);
            number.text = thisAnswer.ToString();
            correctAnswer = (UnityEngine.Random.Range(0, 6));
            List<int> used = new List<int>();
            used.Add(thisAnswer);
            for (int i = 0; i < 6; i++)
            {
                int wrongAnswer = UnityEngine.Random.Range(10, 100);
                if (!used.Contains(wrongAnswer))
                {
                    buttons[i].GetComponentInChildren<Text>().text = Translate(wrongAnswer);
                    used.Add(wrongAnswer);
                }
                else
                {
                    i--;
                }
            }
            buttons[correctAnswer].GetComponentInChildren<Text>().text = Translate(thisAnswer);
        }
    }

    private void Level7()
    {
        if (highscore >= 125)
        {
            LevelUp();
            GetQuestion();
        }
        else
        {
            int thisAnswer = UnityEngine.Random.Range(1, 100000);
            number.text = thisAnswer.ToString();
            correctAnswer = (UnityEngine.Random.Range(0, 6));
            List<int> used = new List<int>();
            used.Add(thisAnswer);
            for (int i = 0; i < 6; i++)
            {
                int wrongAnswer = UnityEngine.Random.Range(10, 100);
                if (!used.Contains(wrongAnswer))
                {
                    buttons[i].GetComponentInChildren<Text>().text = Translate(wrongAnswer);
                    used.Add(wrongAnswer);
                }
                else
                {
                    i--;
                }
            }
            buttons[correctAnswer].GetComponentInChildren<Text>().text = Translate(thisAnswer);
        }
    }

    public void CheckAnswer(int answer)
    {
        if(answer == correctAnswer)
        {
            audioSource.clip = rightFX;
            audioSource.Play();
            highscore++;
            GetQuestion();
        }
        else
        {
            audioSource.clip = wrongFX;
            audioSource.Play();
            wrongThreshold--;
            ScoreBoard();
            if(wrongThreshold <= 0)
            {
                Game.SetActive(false);
                GameOver.SetActive(true);
                gameOverScore.text = highscore.ToString();
            }
        }
    }

    private void LevelUp()
    {
        currentLevel++;
        GameObject.FindObjectOfType<BackdropShuffle>().Change();

        switch (currentLevel)
        {
            case 1: level.text = "Level 1!"; break;
            case 2: level.text = "Level 2!"; break;
            case 3: level.text = "Level 3!"; break;
            case 4: level.text = "Level 4!"; break;
            case 5: level.text = "Level 5!"; break;
            case 6: level.text = "Level 6!"; break;
            default: level.text = "Endless!"; break;
        }

        wrongThreshold++;
        ScoreBoard();
    }

    private void ScoreBoard()
    {
        string temp = "";
        for(int i = 0; i < wrongThreshold; i++)
        {
            temp += "X";
        }
        score.text = temp;
    }

    private string Translate(int num)
    {
        switch (gameMode)
        {
            case 1: return (Romanji(num));
            case 2: return (Hiragana(num));
            case 3: return (Kanji(num));
            default: print("translate got an invalid result"); return ("Error");
        }
    }

    private string Romanji(int num)
    {
        string[] dict = new string[] { "", "Ichi", "Ni", "San", "Yon", "Go", "Roku", "Shichi", "Hachi", "Kyuu"};

        System.Text.StringBuilder translation = new System.Text.StringBuilder("");
        int[] digits = GetIntArray(num);

        translation.Append(dict[digits[0]]);
        if (digits[0] != 0)
        {
            translation.Append("Man");
        }
        translation.Append(dict[digits[1]]);
        if (digits[1] != 0)
        {
            translation.Append("Sen");
        }
        if (digits[2] != 1)
        {
            translation.Append(dict[digits[2]]);
        }
        if (digits[2] != 0)
        {
            translation.Append("Hyaku");
        }
        if(!(digits[3] == 1))
        {
            translation.Append(dict[digits[3]]);
        }
        if (digits[3] != 0)
        {
            translation.Append("Juu");
        }
        if(digits[4] == 4)
        {
            translation.Append("Shi");
        }
        else
        {
            translation.Append(dict[digits[4]]);
        }

        return (translation.ToString());
    }

    private string Hiragana(int num)
    {
        string[] dict = new string[] { "", "いち", "に", "さん", "よん", "ご", "ろく", "しち", "はち", "きゅう" };

        System.Text.StringBuilder translation = new System.Text.StringBuilder("");
        int[] digits = GetIntArray(num);

        translation.Append(dict[digits[0]]);
        if (digits[0] != 0)
        {
            translation.Append("まん");
        }
        translation.Append(dict[digits[1]]);
        if (digits[1] != 0)
        {
            translation.Append("せん");
        }
        if (digits[2] != 1)
        {
            translation.Append(dict[digits[2]]);
        }
        if (digits[2] != 0)
        {
            translation.Append("ひゃく");
        }
        if (!(digits[3] == 1))
        {
            translation.Append(dict[digits[3]]);
        }
        if (digits[3] != 0)
        {
            translation.Append("じゅう");
        }
        if (digits[4] == 4)
        {
            translation.Append("し");
        }
        else
        {
            translation.Append(dict[digits[4]]);
        }

        return (translation.ToString());
    }

    private string Kanji(int num)
    {
        string[] dict = new string[] { "", "一", "二", "三", "四", "五", "六", "七", "八", "九" };

        System.Text.StringBuilder translation = new System.Text.StringBuilder("");
        int[] digits = GetIntArray(num);

        translation.Append(dict[digits[0]]);
        if (digits[0] != 0)
        {
            translation.Append("万");
        }
        translation.Append(dict[digits[1]]);
        if (digits[1] != 0)
        {
            translation.Append("千");
        }
        if (digits[2] != 1)
        {
            translation.Append(dict[digits[2]]);
        }
        if (digits[2] != 0)
        {
            translation.Append("百");
        }
        if (!(digits[3] == 1))
        {
            translation.Append(dict[digits[3]]);
        }
        if (digits[3] != 0)
        {
            translation.Append("十");
        }
        translation.Append(dict[digits[4]]);

        return (translation.ToString());
    }

    int[] GetIntArray(int num)
    {
        List<int> listOfInts = new List<int>();
        while (num > 0)
        {
            listOfInts.Add(num % 10);
            num = num / 10;
        }
        while (listOfInts.Count < 5)
        {
            listOfInts.Add(0);
        }
        listOfInts.Reverse();
        return listOfInts.ToArray();
    }

}
