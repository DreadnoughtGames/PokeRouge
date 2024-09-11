using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private AudioSource sound;

    public Player player;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        sound = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GetPlayerData();
    }

    // Update is called once per frame
    void Update()
    {
        GetUserInput();
    }

    public void GetPlayerData()
    {
        if(player == null)
        {
            player = new Player();
        }

        string path = Path.Combine(Application.dataPath, "SaveData/playerData.json");
        string json = File.ReadAllText(path);

        player = JsonUtility.FromJson<Player>(json);

        Debug.Log(player);
    }
    public void GetEnemyPokemonData()
    {

    }

    // Cursor Sound Method
    private void GetUserInput()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X))
        {
            PlayCursorSound();
        }
    }

    private void PlayCursorSound()
    {
        sound.Play();
    }
}
