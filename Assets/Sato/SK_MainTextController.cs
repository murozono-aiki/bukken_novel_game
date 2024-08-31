using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SK_MainTextController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _mainTextObject;
    int _displayedSentenceLength;
    float _time;
    float _feedTime;
    int _sentenceLength;

        // Start is called before the first frame update
    void Start()
    {
        _time = 0f;
        _feedTime = 0.05f;
        DisplayText();
        // 最初の行のテキストを表示、または命令を実行
        string statement = SK_GameManager.Instance.userScriptManager.GetCurrentSentence();
        if (SK_GameManager.Instance.userScriptManager.IsStatement(statement))
        {
            SK_GameManager.Instance.userScriptManager.ExecuteStatement(statement);
            GoToTheNextLine();
        }
        DisplayText();
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if (_time >= _feedTime)
        {
            _time -= _feedTime;
            if (!CanGoToTheNextLine())
            {
                _displayedSentenceLength++;
                _mainTextObject.maxVisibleCharacters = _displayedSentenceLength;
            }
        }
        // クリックされたとき、次の行へ移動
        if (Input.GetMouseButtonUp(0))
        {
            if (CanGoToTheNextLine())
            {
                GoToTheNextLine();
                DisplayText();
            }
            else
            {
                _displayedSentenceLength = _sentenceLength;
            }
        }
    }

    public bool CanGoToTheNextLine()
    {
        string sentence = SK_GameManager.Instance.userScriptManager.GetCurrentSentence();
        _sentenceLength = sentence.Length;
        return (_displayedSentenceLength > sentence.Length);
    }

    // 次の行へ移動
    public void GoToTheNextLine()
    {
        _displayedSentenceLength = 0;
        _time = 0f;
        _mainTextObject.maxVisibleCharacters = 0;
        SK_GameManager.Instance.lineNumber++;
        string sentence = SK_GameManager.Instance.userScriptManager.GetCurrentSentence();
        if (SK_GameManager.Instance.userScriptManager.IsStatement(sentence))
        {
            SK_GameManager.Instance.userScriptManager.ExecuteStatement(sentence);
            GoToTheNextLine();
        }
    }

    // テキストを表示
    public void DisplayText()
    {
        string sentence = SK_GameManager.Instance.userScriptManager.GetCurrentSentence();
        _mainTextObject.text = sentence;
    }
}
