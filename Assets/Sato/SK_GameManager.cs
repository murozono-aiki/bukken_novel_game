using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SK_GameManager : MonoBehaviour
{
    // 別のクラスからGameManagerの変数などを使えるようにするためのもの。（変更はできない）
        public static SK_GameManager Instance { get; private set; }
        public SK_UserScriptManager userScriptManager;
        public SK_MainTextController mainTextController;
        public SK_ImageManager imageManager;

        // ユーザスクリプトの、今の行の数値。クリック（タップ）のたびに1ずつ増える。
        [System.NonSerialized] public int lineNumber;

        void Awake()
        {
            // これで、別のクラスからGameManagerの変数などを使えるようになる。
            Instance = this;

            lineNumber = 0;
        }
}
