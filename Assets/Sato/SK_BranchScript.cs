using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SK_BranchScript : MonoBehaviour
{
    public SK_GameManager gamemanager;
    public SK_UserScriptManager userscript;
    public GameObject button;
    public GameObject button1;
    public GameObject button2;
    /*[SerializeField] Sprite _background1;
    [SerializeField] GameObject _backgroundObject;
    [SerializeField] GameObject _imagePrefab;*/

    // テキストファイルから、文字列でSpriteやGameObjectを扱えるようにするための辞書
    Dictionary<string, Sprite> _textToSprite;
    Dictionary<string, GameObject> _textToParentObject;

        // 操作したいPrefabを指定できるようにするための辞書
    Dictionary<string, GameObject> _textToSpriteObject;

    void Awake()
    {
        _textToSprite = new Dictionary<string, Sprite>();
        //_textToSprite.Add("background1", _background1);
        _textToParentObject = new Dictionary<string, GameObject>();
        //_textToParentObject.Add("backgroundObject", _backgroundObject);
        _textToSpriteObject = new Dictionary<string, GameObject>();
    }

        // 画像を配置する
    /*public void PutImage(string imageName, string parentObjectName)
    {
        Sprite image = _textToSprite[imageName];
        GameObject parentObject = _textToParentObject[parentObjectName];
        Vector2 position = new Vector2(0, 0);
        Quaternion rotation = Quaternion.identity;
        Transform parent = parentObject.transform;
        GameObject item = Instantiate(_imagePrefab, position, rotation, parent);
        item.GetComponent<Image>().sprite = image;

        _textToSpriteObject.Add(imageName, item);
    }*/
    
    int branch1 = 0;

    void Start()
    {
        button.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);
    }
    void Update()
    {
        branch1 = gamemanager.lineNumber;
        if(branch1 >= 7)
        {
            button.SetActive(true);
            button1.SetActive(true);
            button2.SetActive(true);
        }
    }
}
