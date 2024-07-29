using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MA_GameManager : MonoBehaviour
{
    public MA_ScriptManager scriptManager;
    public MA_UIController UIController;
    
    public int currentScriptIndex = 0;
    public int currentTextIndex = 0;
    bool is_waitingButtonClick = false;
    
    // Start is called before the first frame update
    void Start()
    {
        UIController.SetText(scriptManager.GetTextFromIndex(currentScriptIndex, currentTextIndex));
    }

    // Update is called once per frame
    void Update()
    {
        if (UIController.canGoToNextText && scriptManager.IsLastText(currentScriptIndex, currentTextIndex) && !is_waitingButtonClick)
        {
            UIController.SetButton(scriptManager.GetActionNamesFromIndex(currentScriptIndex));
            is_waitingButtonClick = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (!is_waitingButtonClick)
            {
                if (!UIController.canGoToNextText)
                {
                    UIController.DisplayAllCharacters();
                }
                else
                {
                    currentTextIndex++;
                    UIController.SetText(scriptManager.GetTextFromIndex(currentScriptIndex, currentTextIndex));
                }
            }
        }
    }

    public void OnActionButtonClick(int actionIndex)
    {
        is_waitingButtonClick = false;
        currentScriptIndex = scriptManager.GetNextIndex(currentScriptIndex, actionIndex);
        currentTextIndex = 0;
        UIController.SetText(scriptManager.GetTextFromIndex(currentScriptIndex, currentTextIndex));
    }
}
