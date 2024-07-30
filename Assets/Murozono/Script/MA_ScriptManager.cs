using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MA_ScriptManager : MonoBehaviour
{
    public MA_ScenarioFile scenarioFile;
    
    public string GetTextFromIndex(int scriptIndex, int textIndex)
    {
        if (textIndex < scenarioFile.scenario.scenario[scriptIndex].script.Length)
        {
            return scenarioFile.scenario.scenario[scriptIndex].script[textIndex].text;
        }
        else
        {
            return "";
        }
    }
    public bool IsLastText(int scriptIndex, int textIndex)
    {
        return textIndex == scenarioFile.scenario.scenario[scriptIndex].script.Length - 1;
    }
    public string GetImagePassFromIndex(int scriptIndex, int textIndex)
    {
        string imagePass = scenarioFile.scenario.scenario[scriptIndex].script[textIndex].image;
        if (String.IsNullOrEmpty(imagePass))
        {
            return null;
        }
        else
        {
            return imagePass;
        }
    }
    public string[] GetActionNamesFromIndex(int scriptIndex)
    {
        MA_ScenarioFile.Scenario.Action[] actions = scenarioFile.scenario.scenario[scriptIndex].next;
        string[] result = new string[actions.Length];
        for (int i = 0; i < actions.Length; i++)
        {
            result[i] = actions[i].action;
        }
        return result;
    }
    public int GetNextIndex(int scriptIndex, int actionIndex)
    {
        return scenarioFile.scenario.scenario[scriptIndex].next[actionIndex].index;
    }
}
