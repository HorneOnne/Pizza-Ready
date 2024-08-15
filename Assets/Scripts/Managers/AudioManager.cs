using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }



    [SerializeField] private FMODUnity.EventReference _sfx;


    private void Awake()
    {
        // Check if an instance already exists, and destroy the duplicate
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        
    }

    private void Start()
    {

    }

    public void PlaySfx(Vector2 position)
    {
        FMODUnity.RuntimeManager.PlayOneShot(_sfx, position);
    }


}
