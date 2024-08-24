using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCursor : MonoBehaviour
{
    [SerializeField]
    private Image[] cursors;

    private int preSelMenu;
    private int selMenu;
    private bool isCursorChanged = false;

    bool hasSave = false;

    void Start()
    {
        
    }

    private void Awake()
    {
        InitCursor();
    }

    void Update()
    {
        GetUserInput();

        CursorMove();
    }

    private void InitCursor()
    {
        if (hasSave == true)
        {
            // If the user has saved data then the cursor's initial position is 'continue'
            selMenu = 1;
        }
        else
        {
            // If the user has not saved data then the cursor's initial position is 'new game'
            selMenu = 0;
        }

        for (int i = 0; i < cursors.Length; i++)
        {
            if(i == selMenu)
            {
                cursors[i].gameObject.SetActive(true);
            }
            else
            {
                cursors[i].gameObject.SetActive(false);
            }
        }
    }

    private void GetUserInput()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            InputUp();
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            InputDown();
        }
        else if(Input.GetKeyDown(KeyCode.Z))
        {
            GetUserSelectMenu();
        }
    }

    private void InputDown()
    {
        preSelMenu = selMenu;
        selMenu++;

        if(selMenu > cursors.Length - 1)
        {
            selMenu = 0;
        }

        isCursorChanged = true;
    }

    private void InputUp()
    {
        preSelMenu = selMenu;
        selMenu--;

        if (selMenu < 0)
        {
            selMenu = cursors.Length - 1;
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
                Debug.Log("New Game");
                break;
            case 1:
                Debug.Log("Continue");
                break;
            case 2:
                Debug.Log("Options");
                break;
            case 3:
                Debug.Log("Exit");
                break;
            default:
                break;
        }
    }
}
