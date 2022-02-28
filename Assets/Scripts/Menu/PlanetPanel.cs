using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlanetPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI PlanetName;

    public void SetPlanetOnPanel(int planet)
    {
        // temp
        PlanetName.text = "Planet " + planet;
        // temp
    }

}
