using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : Command
{
    public override bool IsSuccessful { get; set; }

    private static HealthManager instance;

    public static HealthManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("Health Manager");
                instance = go.AddComponent<HealthManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public int actualLife;
    public int maxLife;
    public int minLife;
    public int addLife;

    public delegate void HealthDelegate(int health);

    public event HealthDelegate LifeChanged;

    public void SetHealth(int newLife)
    {
        actualLife += newLife;
    }

    public override void Execute()
    {
        addLife = 1;
        SetHealth(addLife);
        if (actualLife > maxLife)
        {
            actualLife = 10;
        }
        else
        {
            LifeChanged?.Invoke(actualLife);
            IsSuccessful = true;
        }
    }

    public override void Undo()
    {
        addLife = -1;
        SetHealth(addLife);

        if (actualLife < minLife)
        {
            actualLife = 0;
        }
        else
        {
            LifeChanged?.Invoke(actualLife);
        }
    }

    public override void Redo()
    {
        SetHealth(addLife);

        if (actualLife > maxLife)
        {
            actualLife = 10;
        }
        else if (actualLife < minLife)
        {
            actualLife = 0;
        }
        else
        {
            LifeChanged?.Invoke(actualLife);
        }
    }
}
