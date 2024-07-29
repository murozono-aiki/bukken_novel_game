using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MA_ScenarioFile : MonoBehaviour
{
    public TextAsset file;
    [System.Serializable]
    public class Scenario
    {
        [System.Serializable]
        public class Script
        {
            public string text;
            public string image;
        }
        [System.Serializable]
        public class Action
        {
            public string action;
            public int index;
        }
        [System.Serializable]
        public class Object
        {
            public Script[] script;
            public Action[] next;
        }
        public Object[] scenario;
    }
    public Scenario scenario;
    void Awake() {
        scenario = JsonUtility.FromJson<Scenario>(file.text);
    }
}
