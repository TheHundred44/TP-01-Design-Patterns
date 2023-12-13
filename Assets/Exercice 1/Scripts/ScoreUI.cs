using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;

    private void Awake()
    {
        ScoreManager.Instance.ScoreChanged += Notify;
    }

    public void Notify(int newScore)
    {
        _scoreText.SetText($"{newScore}");
    }
}
