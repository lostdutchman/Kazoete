using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour {

    //Test Manager
    public int questionsToGo = 20;
    public float penaltyTime = 5;
    public Text timer, toGo, number, gameOverScore, gameOverHighScore;
    public GameObject[] buttons;
    public int gameMode = 3; //1 = Romanji, 2 = Kana, 3 = Kanji
    public AudioSource audioSource;
    public AudioClip wrongFX, rightFX;
    public GameObject Game, GameOver;

    private float score = 0;
    private float highscore = 6039;

    //Test
    private int correctAnswer = 0;

    // Use this for initialization
    void Start () {
        gameMode = PlayerPrefs.GetInt("game_mode");
        highscore = PlayerPrefs.GetFloat("high_score");
        Game.SetActive(true);
        GameOver.SetActive(false);
        GetQuestion();
    }

    void Update()
    {
        score += Time.deltaTime;
        timer.text = FormatTime(score);
    }

    string FormatTime(float time)
    {
        int intTime = (int)time;
        int minutes = intTime / 60;
        int seconds = intTime % 60;
        float fraction = time * 1000;
        fraction = (fraction % 1000);
        string timeText = String.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
        return timeText;
    }

    public void GetQuestion()
    {
        int thisAnswer = UnityEngine.Random.Range(1, 100000);
        number.text = thisAnswer.ToString();
        correctAnswer = (UnityEngine.Random.Range(0, 6));
        List<int> used = new List<int>();
        used.Add(thisAnswer);
        for (int i = 0; i < 6; i++)
        {
            //Get each wrong number
            int wrongAnswer = 0;
            //Make it harder for people by shuffling numbers, but in case the numbers cannot be shuffled still pick random close numbers
            if (thisAnswer > 99)
            {
                if (UnityEngine.Random.Range(0, 2) == 1) //1 in 3 chance of using random number
                {
                    wrongAnswer = UnityEngine.Random.Range(thisAnswer - 10, thisAnswer + 10);
                }
                else
                {
                    wrongAnswer = Shuffle(GetIntArray(thisAnswer));
                }
            }
            else
            {
                wrongAnswer = UnityEngine.Random.Range(thisAnswer - 10, thisAnswer + 10);
            }
            //Makes sure im not using an already used number
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

    public void CheckAnswer(int answer)
    {
        if(answer == correctAnswer)
        {
            audioSource.clip = rightFX;
            audioSource.Play();
            questionsToGo--;
            toGo.text = questionsToGo.ToString();
            if(questionsToGo <= 0)
            {
                Game.SetActive(false);
                GameOver.SetActive(true);
                if(score < highscore)
                {
                    highscore = score;
                }
                gameOverScore.text = FormatTime(score);
                gameOverHighScore.text = FormatTime(highscore);
                PlayerPrefs.SetFloat("high_score", score);
            }
            else
            {
                GetQuestion();
            }
        }
        else
        {
            audioSource.clip = wrongFX;
            audioSource.Play();
            score += penaltyTime;
        }
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

    int Shuffle(int[] source)
    {
        int result = 0;
        //Shuffle int array
        for (var i = source.Length - 1; i > 0; i--)
        {
            var r = UnityEngine.Random.Range(0, i);
            var tmp = source[i];
            source[i] = source[r];
            source[r] = tmp;
        }
        //return iterator as animation int
        for (int i = 0; i < source.Length; i++)
        {
            result += source[i] * Convert.ToInt32(Math.Pow(10, source.Length - i - 1));
        }

        return result;
    }

}
