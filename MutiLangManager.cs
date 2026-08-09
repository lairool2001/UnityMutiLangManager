using System;
using System.Data;
using System.Linq;
using CSVFile;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MutiLangManager : MonoBehaviour
{
    public static MutiLangManager instance;
    public SystemLanguage language;
    public SystemLanguage defaultLanguage;
    public string filename = "mutiLangs.csv";
    private DataTable dt;
    public Mode mode = Mode.inspector;

    [ContextMenu("Refresh All")]
    public void refresh()
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
        var settings = new CSVSettings();
        string path = Application.streamingAssetsPath + "/" + filename;
        using (var cr = CSVReader.FromFile(path, settings))
        {
            dt = cr.ReadAsDataTable();
        }

        print(get(language, "蘋果"));
        refresh();
    }

    public string get(SystemLanguage language, string key)
    {
        string keyColumn = dt.Columns[0].ColumnName; // 第一欄當作 key 欄位
        DataRow[] rows = dt.Select($"{keyColumn} = '{key}'");

        if (rows.Length > 0)
        {
            return rows[0][language.ToString()].ToString();
        }

        return null;
    }

    public enum Mode
    {
        inspector,
        csv
    }
}