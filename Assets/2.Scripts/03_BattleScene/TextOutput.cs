using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextOutput : MonoBehaviour
{
    private GameManager gameManager;
    private TextMeshProUGUI textOutput;

    private void Awake()
    {
        gameManager = gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
