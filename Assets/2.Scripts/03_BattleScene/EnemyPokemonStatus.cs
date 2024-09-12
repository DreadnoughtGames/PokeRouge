using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPokemonStatus : MonoBehaviour
{
    private GameManager gameManager;

    private TextMeshProUGUI name;
    private TextMeshProUGUI level;
    private GameObject hpBarObj;
    private RectTransform hpBarRect;
    private Image hpBarImg;

    [SerializeField]
    private Sprite[] hpSprites;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        name = transform.Find("EnemyStatus/StatusBg/StatusText/PokemonName").GetComponent<TextMeshProUGUI>();
        level = transform.Find("EnemyStatus/StatusBg/StatusText/PokemonLevel").GetComponent<TextMeshProUGUI>();
        hpBarObj = transform.Find("EnemyStatus/StatusBg/Hp/HpImg").gameObject;
        hpBarRect = hpBarObj.GetComponent<RectTransform>();
        hpBarImg = hpBarObj.GetComponent<Image>();
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
        name.text = gameManager.currentEnemyPokemon.name;
        level.text = $"Lv{gameManager.currentEnemyPokemon.level.ToString()}";

        UpdateHpBar();
    }

    private void UpdateHpBar()
    {
        // change hpBarObj width
        float hpPercent = (float) gameManager.currentEnemyPokemon.hp / gameManager.currentEnemyPokemon.maxHp;

        Debug.Log(hpPercent);

        hpBarRect.sizeDelta = new Vector2(hpBarRect.sizeDelta.x * hpPercent, hpBarRect.sizeDelta.y);

        // change hpBarImg sprite (color)
        if(hpPercent > 0.7)
        {
            hpBarImg.sprite = hpSprites[0];
        }
        else if(hpPercent > 0.3)
        {
            hpBarImg.sprite = hpSprites[1];
        }
        else
        {
            hpBarImg.sprite = hpSprites[2];
        }
    }
}
