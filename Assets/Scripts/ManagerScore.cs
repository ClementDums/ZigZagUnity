using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScore : MonoBehaviour
{
    public static ManagerScore instance;

    public void Awake()
    {
        instance = this;
    }

    public Text score;
    public Text bestScore;
    public Text scoreMenu;
    public Text bestScoreMenu;

    public Material tileColor;
    int scoreInt;
    int bestScoreInt;

    private bool isPlaying = true;

    public bool IsPlaying
    {
        get => isPlaying;
        set
        {
            isPlaying = value;
            StartCoroutine(Second());
        }
    }

    public int ScoreInt { get => scoreInt; set => scoreInt = value; }


    // Start is called before the first frame update
    void Start()
    {
        score.text = "0";
        scoreMenu.text = "0";
        bestScoreInt = PlayerPrefs.GetInt("BestScore");
        bestScore.text = "Best score: "+bestScoreInt.ToString();
        bestScoreMenu.text = bestScoreInt.ToString();
        StartCoroutine(Second());
    }
   
    void ChangeColor() {
        if (scoreInt < 20)
        {
            tileColor.color = new Color(0.31f, 0.61f, 1f);

        }
        if (scoreInt >= 20)
        {
            tileColor.color = new Color(87/255f, 253/255f, 189/255f);
        }
        if (scoreInt > 40)
        {

            tileColor.color = new Color(253 / 255f, 87 / 255f, 141 / 255f);


        }
        if (scoreInt > 60)
        {
            tileColor.color = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
        }
    }
    
    public void isBestScore()
    {
        if (scoreInt > bestScoreInt)
        {
            bestScoreInt = scoreInt;
            bestScore.text = "Best score: "+bestScoreInt.ToString();
            bestScoreMenu.text = bestScoreInt.ToString();
            PlayerPrefs.SetInt("BestScore", bestScoreInt);
        }
    }

    public void PiecePoint()
    {
        addPoint(2);
    }

    public void ResetScore()
    {
        scoreInt = 0;
        score.text = "0";
        scoreMenu.text = "0";
    }

    IEnumerator Second() 
    {
        while (isPlaying)
        {
            addPoint(1);
            yield return new WaitForSeconds(1f);
        }
    }

    void addPoint(int value)
    {
        scoreInt += value;
        ChangeColor();
        score.text = scoreInt.ToString();
        scoreMenu.text = scoreInt.ToString();
    }
}
