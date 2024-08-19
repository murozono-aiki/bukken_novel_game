using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SK_SceneBranchScript3 : MonoBehaviour
{
    public void Onclick()
    {
        SceneManager.LoadScene("MainScene4");
        SceneManager.UnloadScene("MainScene1");
        Debug.Log("scene4");
    }
}

