using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public ObjectPool objectPool;

    public void OnButtonClick()
    {
        GameObject obj = objectPool.GetObjectFromPool();
        Debug.Log(obj);
        if (obj != null)
        {
            obj.SetActive(true);
        }
    }
}
