using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace NovelGame
{
    public class MainTextController : MonoBehaviour
    {
     [SerializeField ] private TextMashProUGUI mainTextobject;

    // Start is called before the first frame update
    void Start()
    {
           //DisplayText();
    }

    // Update is called once per frame
    void Update()
    {

            if (Input.GetMouseButtonUp(0))
            {
                GoToTheNextLine();
              //  DisplayText();
            }
    }
        private void GoToTheNextLine()
        {
            throw new NotImplementedException();
        }//テキストを表示
        public void DisPlayText()
        {
            string sentence =
        SK_GameManager.Instance.userScriptManager.GetCurrentSentence();
           // MainTextObject.text = sentence;
        }
    }

}
       
