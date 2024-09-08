using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMenuCursor : MonoBehaviour
{
    [SerializeField]
    private Image[] cursors;

    private int preSelMenu;
    private int selMenu;
    private bool isCursorChanged = false;

    private void Awake()
    {
        InitCursor();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetUserInput();

        CursorMove();
    }

    private void InitCursor()
    {
        selMenu = 0;
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
            GetUserSelectMenu();
        }
    }

    private void InputHorizontal()
    {
        preSelMenu = selMenu;

        switch(selMenu)
        {
            case 0:             // current cursor position is 'battle'
                selMenu = 1;    // change cursor position to 'bag'
                break;
            case 1:             // current cursor position is 'bag'
                selMenu = 0;    // change cursor position to 'battle'
                break;
            case 2:             // current cursor position is 'pokemon'
                selMenu = 3;    // change cursor position to 'run'
                break;
            case 3:             // current cursor position is 'run'
                selMenu = 2;    // change cursor position to 'pokemon'
                break;
        }

        isCursorChanged = true;
    }

    private void InputVertical()
    {
        preSelMenu = selMenu;

        switch(selMenu)
        {
            case 0:             // current cursor position is 'battle'
                selMenu = 2;    // change cursor position to 'pokemon'
                break;
            case 1:             // current cursor position is 'bag'
                selMenu = 3;    // change cursor position to 'run'
                break;
            case 2:             // current cursor position is 'pokemon'
                selMenu = 0;    // change cursor position to 'battle'
                break;
            case 3:             // current cursor position is 'run'
                selMenu = 1;    // change cursor position to 'bag'
                break;
        }

        isCursorChanged = true;
    }

    private void CursorMove()
    {
        if(isCursorChanged == false)
            return;

        cursors[preSelMenu].gameObject.SetActive(false);

        cursors[selMenu].gameObject.SetActive(true);

        isCursorChanged = false;
    }

    private void GetUserSelectMenu()
    {
        switch(selMenu)
        {
            case 0:
                Debug.Log("Battle");
                break;
            case 1:
                Debug.Log("Bag");
                break;
            case 2:
                Debug.Log("Pokemon");
                break;
            case 3:
                Debug.Log("Run");
                break;
            default:
                break;
        }
    }
}
