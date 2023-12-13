using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class ScoreManager : Command
{
    public override bool IsSuccessful { get; set; }

    public static ScoreManager instance;

    public static ScoreManager Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject go = new GameObject("Score Manager");
                instance = go.AddComponent<ScoreManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public int actualScore;
    public int addScore;

    public delegate void ScoreDelegate(int score);

    public event ScoreDelegate ScoreChanged;

    public void SetScore(int newScore)
    {
        actualScore += newScore;

    }

    public override void Execute()
    {
        addScore = 1;
        SetScore(addScore);
        IsSuccessful = true;
        ScoreChanged?.Invoke(actualScore);
    }

    public override void Undo()
    {
        addScore = -1;
        SetScore(-1);
        ScoreChanged?.Invoke(actualScore);
    }
    public override void Redo()
    {
        SetScore(addScore);
        ScoreChanged?.Invoke(actualScore);
    }
}

