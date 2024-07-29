using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MA_ScenarioFile : MonoBehaviour
{
    public TextAsset file;
    public class Scenario
    {
        public class Script
        {
            public string text;
            public string image;
        }
        public class Action
        {
            public string action;
            public int index;
        }
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
