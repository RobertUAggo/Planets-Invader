using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField] public MenuCamera MenuCamera;
    [SerializeField] public PlanetsManager PlanetsManager;
    [SerializeField] public PlanetPanel PlanetPanel;
    //
    [HideInInspector] public static MenuScript Instance;
    private void Awake()
    {
        Instance = this;
    }
    
}
