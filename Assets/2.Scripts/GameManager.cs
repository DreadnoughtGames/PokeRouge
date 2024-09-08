using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public Pokemon myPokemon;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        GetMyPokemonData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetMyPokemonData()
    {
        myPokemon = new Pokemon();

        string path = Path.Combine(Application.dataPath, "SaveData/myPokemonData.json");
        string json = File.ReadAllText(path);

        myPokemon = JsonUtility.FromJson<Pokemon>(json);
    }
}
