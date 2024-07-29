using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MA_ScriptManager : MonoBehaviour
{
    public MA_ScenarioFile scenarioFile;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(JsonUtility.ToJson(scenarioFile.scenario));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
