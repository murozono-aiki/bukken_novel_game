using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SK_SceneBranchScript1 : MonoBehaviour
{
    public void Onclick()
    {
        SceneManager.LoadScene("MainScene2");
        SceneManager.UnloadScene("MainScene1");
    }
}

