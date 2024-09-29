using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpalshImage : MonoBehaviour
{
    private float delayTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeScene();
    }

    void ChangeScene()
    {
        delayTime += Time.deltaTime;

        if (delayTime > 1.5)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("01_TItleScene");
            }
            else if (delayTime > 10)
            {
                SceneManager.LoadScene("01_TItleScene");
            }
        }
    }
}
