using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] public Camera fakeCamera;
    [SerializeField] public PlanetData Data;
    public void SetData(PlanetData newData)
    {
        Data = newData;
    }
    public void LoadLevel()
    {
        Loader.LoadLevel(Data.LevelNumber);
    }
}
