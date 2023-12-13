using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHealthManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;

    private void Start()
    {
        HealthManager.Instance.LifeChanged += Notify;
    }

    public void Notify(int newLife)
    {
        _scoreText.SetText($"{newLife}");
        Debug.Log("woah");

    }
}
