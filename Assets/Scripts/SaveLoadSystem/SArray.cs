using System;
using UnityEngine;

public class SArray<T>
{
    private const char Prefix = 'A';
    private static int Count = 0;
    //
    private char sep;
    private int index;
    private T[] values;
    public SArray(T[] defValues, char sep = '\\')
    {
        this.sep = sep;
        values = defValues;
        index = Count;
        Load();
        Count++;
    }
    public int Length
    {
        get { return values.Length; }
    }
    public T this[int index]
    {
        set
        {
            values[index] = value;
            Save();
        }
        get
        {
            return values[index];
        }
    }
    private void Save()
    {
        string str = "";
        for (int i = 0; i < values.Length; i++)
        {
            if (i > 0)
            {
                str += sep;
            }
            str += values[i].ToString();
        }
        //Debug.Log("Save: " + str);
        PlayerPrefs.SetString(Prefix + index.ToString(), str);
    }
    private void Load()
    {
        if (!PlayerPrefs.HasKey(Prefix + index.ToString()))
        {
            Save();
        }
        else
        {
            string str = PlayerPrefs.GetString(Prefix + index.ToString());
            string[] strs = str.Split(sep);
            for (int i = 0; i < values.Length; i++)
            {
                if (strs.Length > i)
                {
                    values[i] = (T)Convert.ChangeType(strs[i], typeof(T));
                }
                else
                {
                    Save();
                    break;
                }
            }
            //Debug.Log("Load: " + this);
        }
    }
    public override string ToString()
    {
        string str = "";
        for(int i = 0; i < values.Length; i++)
        {
            if (i > 0) str += sep;
            str += values[i];
        }
        return str;
    }
}
