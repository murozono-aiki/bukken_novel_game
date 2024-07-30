using System;
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

    public void OnCanGoToNextText()
    {
        if (scriptManager.IsLastText(currentScriptIndex, currentTextIndex)) {
            string[] actionNames = scriptManager.GetActionNamesFromIndex(currentScriptIndex);
            if (actionNames.Length > 0)
            {
                if (!String.IsNullOrEmpty(actionNames[0]))
                {
                    // ボタンによる分岐
                    UIController.SetButton(actionNames);
                    is_waitingButtonClick = true;
                }
                else
                {
                    // 他のインデックスへ移動
                    currentScriptIndex = scriptManager.GetNextIndex(currentScriptIndex, 0);
                    currentTextIndex = -1;  // 次の左クリック時に0になる
                }
            }
            else
            {
                // シナリオの終了（エンディング）
                ;
            }
        }
    }
}
