using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlanetPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI PlanetName;

    public void SetPlanetOnPanel(int planet)
    {
        PlanetName.text = MainScript.Instance.PlanetsData[planet].Name;
    }

}
