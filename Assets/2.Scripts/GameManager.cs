using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip sound;

    public Player player;
    public Enemy enemy;

    public Pokemon currentPlayerPokemon;
    public Pokemon currentEnemyPokemon;

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

        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GetPlayerData();
        GetEnemyPokemonData();
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

        GetCurrentPokemonData();

        Debug.Log(player);
    }

    public void GetCurrentPokemonData()
    {
        currentPlayerPokemon = player.pokemons[player.currentPokemon];
    }


    public void GetEnemyPokemonData()
    {
        string path = Path.Combine(Application.dataPath, "SaveData/enemyData.json");
        string json = File.ReadAllText(path);

        enemy = JsonUtility.FromJson<Enemy>(json);

        GetCurrentEnemyPokemonData();

        Debug.Log(enemy);
    }

    public void GetCurrentEnemyPokemonData()
    {
        currentEnemyPokemon = enemy.pokemons[player.stage - 1];
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
        if(audioSource.clip == null)
        {
            audioSource.clip = sound;
        }

        audioSource.Play();
    }
}
