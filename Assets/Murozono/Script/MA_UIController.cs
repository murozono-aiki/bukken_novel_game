using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MA_UIController : MonoBehaviour
{
    public MA_GameManager gameManager;
    
    [SerializeField] ButtonUI[] buttons;
    
    [System.Serializable, SerializeField]
    class ButtonUI
    {
        [SerializeField] public GameObject buttonObject;
        [SerializeField] public Button button;
        [SerializeField] public TextMeshProUGUI text;
        public int actionIndex;
    }

    [SerializeField] TextMeshProUGUI text;
    float time = 0;
    readonly float feedTime = 0.05f;
    public bool canGoToNextText = false;

    void Start()
    {
        text.maxVisibleCharacters = 0;
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].button.onClick.AddListener(() => OnButtonClick(index));
            buttons[i].buttonObject.SetActive(false);
        }
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time >= feedTime)
        {
            time -= feedTime;
            if (text.text.Length > text.maxVisibleCharacters)
            {
                text.maxVisibleCharacters++;
                if (canGoToNextText) canGoToNextText = false;
            }
            else
            {
                if (!canGoToNextText)
                {
                    canGoToNextText = true;
                    gameManager.OnCanGoToNextText();
                }
            }
        }
    }

    public void OnButtonClick(int index)
    {
        SetButton(new string[0]);
        gameManager.OnActionButtonClick(buttons[index].actionIndex);
    }

    public void SetButton(string[] actions)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i < actions.Length)
            {
                int actionIndex = actions.Length - 1 - i;
                buttons[i].text.text = actions[actionIndex];
                buttons[i].actionIndex = actionIndex;
                buttons[i].buttonObject.SetActive(true);
            }
            else
            {
                buttons[i].buttonObject.SetActive(false);
            }
        }
    }


    public void SetText(string textString)
    {
        text.text = textString;
        text.maxVisibleCharacters = 0;
        canGoToNextText = false;
    }
    public void DisplayAllCharacters()
    {
        text.maxVisibleCharacters = text.text.Length;
        canGoToNextText = true;
        gameManager.OnCanGoToNextText();
    }
}
