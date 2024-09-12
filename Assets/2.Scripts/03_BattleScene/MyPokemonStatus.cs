using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyPokemonStatus : MonoBehaviour
{
    private GameManager gameManager;

    private TextMeshProUGUI name;
    private TextMeshProUGUI level;
    private TextMeshProUGUI hpNum;
    private GameObject hpBarObj;
    private RectTransform hpBarRect;
    private Image hpBarImg;

    [SerializeField]
    private Sprite[] hpSprites;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        name = transform.Find("MyStatus/StatusBg/StatusText/PokemonName").GetComponent<TextMeshProUGUI>();
        level = transform.Find("MyStatus/StatusBg/StatusText/PokemonLevel").GetComponent<TextMeshProUGUI>();
        hpNum = transform.Find("MyStatus/StatusBg/Hp/HpNum").GetComponent<TextMeshProUGUI>();
        hpBarObj = transform.Find("MyStatus/StatusBg/Hp/HpImg").gameObject;
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
        name.text = gameManager.currentPlayerPokemon.name;
        level.text = $"Lv{gameManager.currentPlayerPokemon.level.ToString()}";
        hpNum.text = $"{gameManager.currentPlayerPokemon.hp.ToString()}/{gameManager.currentPlayerPokemon.maxHp.ToString()}";

        UpdateHpBar();
    }

    private void UpdateHpBar()
    {
        // change hpBarObj width
        float hpPercent = (float) gameManager.currentPlayerPokemon.hp / gameManager.currentPlayerPokemon.maxHp;

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
