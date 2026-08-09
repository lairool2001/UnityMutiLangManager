using System;
using TMPro;
using UnityEditor;
using UnityEngine;

public class TranslateText : TranslateRefresh
{
    public MultiText[] langWordz;

    public TMP_Text text;

    public StringToString[] setWordz;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        refresh();
    }

    [ContextMenu("Refresh")]
    public override void refresh()
    {
        var lang = Array.Find(langWordz, item => item.language == language);
        if (lang == null)
        {
            lang = Array.Find(langWordz, item => item.language == MutiLangManager.instance.defaultLanguage);
        }

        if (setWordz.Length == 0)
        {
            text.text = lang.data;
        }
        else
        {
            string text = lang.data;
            for (int i = 0; i < setWordz.Length; i++)
            {
                text = text.Replace(setWordz[i].key, setWordz[i].value);
            }

            this.text.text = text;
        }
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

public interface ITranslateRefresh
{
    public void refresh();
    public SystemLanguage getLanguage();
}

public class TranslateRefresh : MonoBehaviour
{
    public SystemLanguage language;

    public virtual void refresh()
    {
    }
}