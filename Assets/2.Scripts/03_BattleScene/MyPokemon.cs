using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyPokemon : MonoBehaviour
{
    private GameManager gameManager;

    private TextMeshProUGUI name;
    private TextMeshProUGUI level;
    private TextMeshProUGUI hp;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        name = transform.Find("MyStatus/StatusBg/StatusText/PokemonName").GetComponent<TextMeshProUGUI>();
        level = transform.Find("MyStatus/StatusBg/StatusText/PokemonLevel").GetComponent<TextMeshProUGUI>();
        hp = transform.Find("MyStatus/StatusBg/Hp/HpNum").GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InitPokemonData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitPokemonData()
    {
        name.text = gameManager.myPokemon.name;
        level.text = $"Lv{gameManager.myPokemon.level.ToString()}";
        hp.text = $"{gameManager.myPokemon.hp.ToString()}/{gameManager.myPokemon.maxHp.ToString()}";
    }
}
