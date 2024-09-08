using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMenuSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] sounds;
    private AudioSource sound;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetUserInput();
    }

    private void GetUserInput()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PlayCursorSound();
        }
        else if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X))
        {
            PlaySelectSound();
        }
    }

    private void PlaySelectSound()
    {
        Debug.Log("PlaySelectSound");
        sound.clip = sounds[0];
        sound.Play();
    }

    private void PlayCursorSound()
    {
        Debug.Log("PlayCursorSound");
        sound.clip = sounds[1];
        sound.Play();
    }
}
