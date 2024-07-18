using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SK_DialogScript : MonoBehaviour
{
    [SerializeField] Text nextText;
    int count;

    void Start()
    {
        count = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            count++;
        }
        if(count == 0)
        {
            nextText.text = "マウス左クリックで次に進む";
        }
        if(count == 1)
        {
            nextText.text = "1";
        }
        if(count == 2)
        {
            nextText.text = "2";
        }
    }
}
