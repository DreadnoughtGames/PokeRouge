using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class MyPokemonSkill : MonoBehaviour
{
    private GameManager gameManager;

    private TextMeshProUGUI[] names;
    private TextMeshProUGUI firstSkillName;
    private TextMeshProUGUI secondSkillName;
    private TextMeshProUGUI thirdSkillName;
    private TextMeshProUGUI fourthSkillName;

    private TextMeshProUGUI power;
    private TextMeshProUGUI pp;

    private int currentSkill = 0;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        firstSkillName = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        secondSkillName = transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        thirdSkillName = transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>();
        fourthSkillName = transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>();

        power = transform.Find("SkillText/SkillPower/SkillPowerNum").GetComponent<TextMeshProUGUI>();
        pp = transform.Find("SkillText/SkillPoint/SkillPointNum").GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InitPokemonSkill();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitPokemonSkill()
    {
        //for(int i = 0; i < 4; i++)
        //{
        //    names[i].text = gameManager.player.pokemons[gameManager.player.currentPokemon].skills[i].name;
        //}

        firstSkillName.text = gameManager.player.pokemons[gameManager.player.currentPokemon].skills[0].name;
        secondSkillName.text = gameManager.player.pokemons[gameManager.player.currentPokemon].skills[1].name;
        thirdSkillName.text = gameManager.player.pokemons[gameManager.player.currentPokemon].skills[2].name;
        fourthSkillName.text = gameManager.player.pokemons[gameManager.player.currentPokemon].skills[3].name;

        power.text = gameManager.player.pokemons[gameManager.player.currentPokemon].skills[0].power.ToString();
        pp.text = $"{gameManager.player.pokemons[gameManager.player.currentPokemon].skills[0].skillPoint.ToString()}/{gameManager.player.pokemons[gameManager.player.currentPokemon].skills[0].maxSkillPoint.ToString()}";
    }

    public void ChangeSkill(int selSkill)
    {
        if(currentSkill != selSkill)
        {
            power.text = gameManager.player.pokemons[gameManager.player.currentPokemon].skills[selSkill].power.ToString();
            pp.text = $"{gameManager.player.pokemons[gameManager.player.currentPokemon].skills[selSkill].skillPoint.ToString()}/{gameManager.player.pokemons[gameManager.player.currentPokemon].skills[selSkill].maxSkillPoint.ToString()}";

            currentSkill = selSkill;
        }
    }
}
