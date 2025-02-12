using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

  

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        Application.targetFrameRate = 60;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {

    }


}
