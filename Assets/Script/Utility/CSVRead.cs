using UnityEngine;

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;


public class CSVRead
{
    private TextAsset txtFile;
    private StringReader stringReader;
    private String[] value;

    public CSVRead(string path)
    {
        LoadCSV(path);
    }
    public void LoadCSV(string path)
    {
        TextAsset textAssetTmp = (TextAsset)Resources.Load(path);
        stringReader = new StringReader(textAssetTmp.text);

        // Need the Return true, false;
    }
    public void ReadLineCSV()
    {
        string line;

        if ((line = stringReader.ReadLine()) != null)
            value = line.Split(',');
    }
    public void CloseCSV()
    {
        stringReader.Close();
    }

    public string GetString(int index)
    {
        return value[index];
    }
    public int GetInt(int index)
    {
        string stringTmp = value[index];
        if (stringTmp == "" || stringTmp == null)
            return 0;
        else
            return Int32.Parse(stringTmp);
    }
    public float GetFloat(int ndex)
    {
        string stingTmp = value[ndex];
        if (stingTmp == "" || stingTmp == null)
            return 0;
        else
            return float.Parse(stingTmp);
    }
}
