using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlotCursor : MonoBehaviour
{
    [SerializeField]
    private Image[] cursors;

    private int preSelSlot;
    private int selSlot;
    private bool isCursorChanged = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        InitCursor();
    }

    // Update is called once per frame
    void Update()
    {
        GetUserInput();

        CursorMove();
    }

    private void InitCursor()
    {

        for (int i = 0; i < cursors.Length; i++)
        {
            if (i == selSlot)
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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            InputUp();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            InputDown();
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            GetUserSelectSlot();
        }
    }

    private void InputDown()
    {
        preSelSlot = selSlot;
        selSlot++;

        if (selSlot > cursors.Length - 1)
        {
            selSlot = 0;
        }

        isCursorChanged = true;
    }

    private void InputUp()
    {
        preSelSlot = selSlot;
        selSlot--;

        if (selSlot < 0)
        {
            selSlot = cursors.Length - 1;
        }

        isCursorChanged = true;
    }

    private void CursorMove()
    {
        if (isCursorChanged == false)
            return;

        cursors[preSelSlot].gameObject.SetActive(false);

        cursors[selSlot].gameObject.SetActive(true);

        isCursorChanged = false;
    }

    private void GetUserSelectSlot()
    {
        switch (selSlot)
        {
            case 0:
                Debug.Log("저장 슬롯 1");
                break;
            case 1:
                Debug.Log("저장 슬롯 2");
                break;
            case 2:
                Debug.Log("저장 슬롯 3");
                break;
            case 3:
                Debug.Log("저장 슬롯 4");
                break;
            case 4:
                Debug.Log("저장 슬롯 5");
                break;
            default:
                break;
        }
    }
}
