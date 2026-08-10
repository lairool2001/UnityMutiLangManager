using System;
using TMPro;
using UnityEngine;

public class TranslateText : TranslateRefresh
{
    public MultiText[] langWordz;

    public TMP_Text text;

    public StringToString[] setWordz;

    private string origin;

    [ContextMenu("Refresh")]
    public override void refresh()
    {
        if (origin == null)
        {
            origin = text.text;
        }

        string aText = origin;
        switch (MutiLangManager.instance.mode)
        {
            case MutiLangManager.Mode.csv:
                aText = MutiLangManager.instance.get(language, aText);
                break;
            case MutiLangManager.Mode.inspector:
                var lang = Array.Find(langWordz, item => item.language == language);
                if (lang == null)
                {
                    lang = Array.Find(langWordz, item => item.language == MutiLangManager.instance.defaultLanguage);
                }

                aText = lang.data;
                break;
        }

        for (int i = 0; i < setWordz.Length; i++)
        {
            aText = aText.Replace(setWordz[i].key, setWordz[i].value);
        }

        text.text = aText;
    }
}

[Serializable]
public class MultiData<T>
{
    public SystemLanguage language;
    public T data;
}

[Serializable]
public class MultiText : MultiData<string>
{
}

[Serializable]
public class MultiImage : MultiData<Sprite>
{
}

[Serializable]
public class StringToString
{
    public string key;
    public string value;
}

public class TranslateRefresh : MonoBehaviour
{
    public SystemLanguage language;

    public virtual void refresh()
    {
    }
}