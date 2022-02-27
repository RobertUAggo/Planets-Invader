using UnityEngine;

public class SField<T>
{
    private const char Prefix = 'F';
    private static int Count=0;
    //
    private int index;
    private T value;
    public T Value
    {
        get
        {
            return value;
        }
        set
        {
            this.value = value;
            Save();
        }
    }
    public SField(T defaultValue)
    {
        value = defaultValue;
        index = Count;
        Load();
        Count++;
    }
    private void Load()
    {
        if (!PlayerPrefs.HasKey(Prefix + index.ToString()))
        {
            Save();
        }
        else
        {
            if (typeof(T) == typeof(int))
            {
                value = (T)(object)PlayerPrefs.GetInt(Prefix + index.ToString());
            }
            else if (typeof(T) == typeof(float))
            {
                value = (T)(object)PlayerPrefs.GetFloat(Prefix + index.ToString());
            }
            else if (typeof(T) == typeof(string))
            {
                value = (T)(object)PlayerPrefs.GetString(Prefix + index.ToString());
            }
            else if (typeof(T) == typeof(bool))
            {
                value = (T)(object)PlayerPrefs.GetInt(Prefix + index.ToString());
            }
        }
    }
    private void Save()
    {
        if (typeof(T) == typeof(int))
        {
            PlayerPrefs.SetInt(Prefix + index.ToString(), (int)(object)value);
        }
        else if (typeof(T) == typeof(float))
        {
            PlayerPrefs.SetFloat(Prefix + index.ToString(), (float)(object)value);
        }
        else if (typeof(T) == typeof(string))
        {
            PlayerPrefs.SetString(Prefix + index.ToString(), value.ToString());
        }
        else if (typeof(T) == typeof(bool))
        {
            PlayerPrefs.SetInt(Prefix + index.ToString(), (int)(object)value);
        }    
    }
}
