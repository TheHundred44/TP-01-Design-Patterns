using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisable : MonoBehaviour
{

    float disableTime = 3f;

    public void OnEnable()
    {
        Invoke("DisableObject", disableTime);
    }

    private void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
