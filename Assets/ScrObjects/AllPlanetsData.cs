using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AllPlanetsData", menuName = "ScriptableObjects/AllPlanetsData")]
public class AllPlanetsData : ScriptableObject
{
    public PlanetData[] PlanetsData;
    public PlanetData this[int i]
    {
        get { return PlanetsData[i]; }
    }
    public int Length 
    {
        get { return PlanetsData.Length; }
    }

}

[Serializable]
public class PlanetData
{
    public int LevelNumber;
    public Sprite Sprite;
    public string Name = "Planet Name";
}
