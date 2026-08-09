using System;
using TMPro;
using UnityEngine;

public class MutiLangManager : MonoBehaviour
{
    public static MutiLangManager instance;
    public SystemLanguage language;
    public SystemLanguage defaultLanguage;
    [ContextMenu("Refresh All")]
    public  void refresh()
    {
        var textz = FindObjectsByType<TranslateRefresh>();
        for (int i = 0; i < textz.Length; i++)
        {
            var text = textz[i];
            text.language = language;
            text.refresh();
        }
    }

    private void Awake()
    {
        instance = this;
    }
}
