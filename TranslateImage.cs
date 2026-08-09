using System;
using UnityEngine;
using UnityEngine.UI;

public class TranslateImage : TranslateRefresh
{
    public MultiImage[] langImagez;

    public Image image;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        refresh();
    }

    [ContextMenu("Refresh")]
    public override void refresh()
    {
        var lang = Array.Find(langImagez, item => item.language == language);
        if (lang == null)
        {
            lang = Array.Find(langImagez, item => item.language == MutiLangManager.instance.defaultLanguage);
        }
        image.sprite = lang.data;
    }
}