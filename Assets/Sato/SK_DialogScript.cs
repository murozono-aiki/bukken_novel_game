using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SK_DialogScript : MonoBehaviour
{
    [SerializeField] Text nextText;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            count++;
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
