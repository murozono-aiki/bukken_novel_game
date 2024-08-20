using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SK_BranchScript : MonoBehaviour
{
    public SK_GameManager gamemanager;
    public GameObject button;
    public GameObject button1;
    public GameObject button2;
    public int n;
    int branch1 = 0;

    void Start()
    {
        button.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);
    }
    void Update()
    {
        branch1 = gamemanager.lineNumber;
        if(branch1 >= n)
        {
            button.SetActive(true);
            button1.SetActive(true);
            button2.SetActive(true);
        }
    }
}
