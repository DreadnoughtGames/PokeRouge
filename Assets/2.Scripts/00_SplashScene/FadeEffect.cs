using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    private Image image;
    private float delayTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        FadeInAndOut();
    }

    void FadeIn()
    {
        Color color = image.color;

        if(color.a > 0)
        {
            color.a -= Time.deltaTime / 2;
        }

        image.color = color;
    }
    
    void FadeOut()
    {
        Color color = image.color;

        Debug.Log(color);

        if (color.a < 1)
        {
            color.a += Time.deltaTime;
        }

        image.color = color;
    }

    void FadeInAndOut()
    {
        delayTime = Time.deltaTime;

        if (delayTime < 1)
        {
            FadeIn();
        }
        else if (delayTime > 2)
        {
            FadeOut();
        }
    }
}
