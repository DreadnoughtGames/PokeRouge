using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BattleMenuCursor : MonoBehaviour
{
    [SerializeField]
    private GameObject[] menus;
    private TextMeshProUGUI gameMessage;
    private MyPokemonSkill myPokemonSkill;

    private Image[] cursors;


    private int preSelAction;
    private int selAction;
    private bool isCursorChanged = false;

    private MenuType currentMenu;

    enum MenuType
    {
        ROOT,
        BATTLE,
        BAG,
        POKEMON,
        RUN
    }

    private void Awake()
    {
        // get game message object in root menu
        gameMessage = menus[(int) MenuType.ROOT].transform.Find("TextOutputBg/GameMessage").gameObject.GetComponent<TextMeshProUGUI>();
        myPokemonSkill = transform.Find("BattleMenu").GetComponent<MyPokemonSkill>();

        currentMenu = MenuType.ROOT;

        ChangeCursorImg();
    }

    private void Update()
    {
        GetUserInput();

        CursorMove();
    }

    private void InitCursor()
    {
        selAction = 0;

        cursors[0].gameObject.SetActive(true);

        for(int i = 1; i < cursors.Length; i++)
        {
            cursors[i].gameObject.SetActive(false);
        }
    }

    private void GetUserInput()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            InputVertical();
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            InputHorizontal();
        }
        else if(Input.GetKeyDown(KeyCode.Z))
        {
            if(currentMenu == MenuType.ROOT)
            {
                GetUserSelectAction();
            }
            else if(currentMenu == MenuType.BATTLE)
            {
                GetUserSelectSkill();
            }
        }
        else if(Input.GetKeyDown(KeyCode.X))
        {
            ExitMenu(currentMenu);
        }
    }

    private void InputHorizontal()
    {
        preSelAction = selAction;

        switch(selAction)
        {
            case 0:             // current cursor position is 'battle'
                selAction = 1;    // change cursor position to 'bag'
                break;
            case 1:             // current cursor position is 'bag'
                selAction = 0;    // change cursor position to 'battle'
                break;
            case 2:             // current cursor position is 'pokemon'
                selAction = 3;    // change cursor position to 'run'
                break;
            case 3:             // current cursor position is 'run'
                selAction = 2;    // change cursor position to 'pokemon'
                break;
        }

        isCursorChanged = true;
    }

    private void InputVertical()
    {
        preSelAction = selAction;

        switch(selAction)
        {
            case 0:             // current cursor position is 'battle'
                selAction = 2;    // change cursor position to 'pokemon'
                break;
            case 1:             // current cursor position is 'bag'
                selAction = 3;    // change cursor position to 'run'
                break;
            case 2:             // current cursor position is 'pokemon'
                selAction = 0;    // change cursor position to 'battle'
                break;
            case 3:             // current cursor position is 'run'
                selAction = 1;    // change cursor position to 'bag'
                break;
        }

        isCursorChanged = true;
    }

    private void CursorMove()
    {
        if(isCursorChanged == false)
            return;

        cursors[preSelAction].gameObject.SetActive(false);

        cursors[selAction].gameObject.SetActive(true);

        if(currentMenu == MenuType.BATTLE)
        {
            myPokemonSkill.ChangeSkill(selAction);
        }

        isCursorChanged = false;
    }

    private void GetUserSelectAction()
    {
        switch(selAction)
        {
            case 0:
                EnterMenu(MenuType.BATTLE);

                break;
            case 1:
                gameMessage.text = "지금은 사용할 수 없어";

                break;
            case 2:
                Debug.Log("Pokemon");

                break;
            case 3:
                gameMessage.text = "지금은 도망칠 수 없어";

                break;
            default:
                break;
        }
    }

    private void GetUserSelectSkill()
    {
        switch(selAction)
        {
            case 0:
                Debug.Log("몸통박치기");
                break;
            case 1:
                Debug.Log("전광석화");
                break;
            case 2:
                Debug.Log("울부짖기");
                break;
            case 3:
                Debug.Log("째려보기");
                break;
            default:
                break;
        }
    }

    private void ExitMenu(MenuType menu)
    {
        if(currentMenu == 0)
        {
            return;
        }

        menus[(int) MenuType.ROOT].SetActive(true);
        menus[(int) menu].SetActive(false);

        currentMenu = MenuType.ROOT;

        ChangeCursorImg();

        gameMessage.text = "포켓몬 이름은 무엇을 할까?";
    }

    private void EnterMenu(MenuType menu)
    {
        menus[(int) MenuType.ROOT].SetActive(false);
        menus[(int) menu].SetActive(true);

        currentMenu = menu;

        ChangeCursorImg();
    }

    private void ChangeCursorImg()
    {
        // get cursors parent object
        Transform obj = menus[(int) currentMenu].transform.Find("MenuBg/MenuCursor");

        if(obj == null)
            return;

        cursors = new Image[obj.childCount];

        for(int i = 0; i < obj.childCount; i++)
        {
            cursors[i] = obj.GetChild(i).GetComponent<Image>();
        }

        InitCursor();
    }
}
