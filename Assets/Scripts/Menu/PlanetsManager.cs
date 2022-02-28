using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsManager : MonoBehaviour
{
    public int CurrentPlanet = 0;
    public Planet[] Planets;
    private void Awake()
    {
        Planets = GetComponentsInChildren<Planet>();
    }
    private void Start()
    {
        //MenuScript.Instance.MenuCamera.TargetCamera = Planets[0].fakeCamera;
        SetPlanet(CurrentPlanet);
    }
    public void SetPlanet(int planet)
    {
        MenuScript.Instance.MenuCamera.TargetCamera = MenuScript.Instance.PlanetsManager.Planets[planet].fakeCamera;
        MenuScript.Instance.PlanetPanel.SetPlanetOnPanel(planet);
    }
    public void NextPlanet()
    {
        if (CurrentPlanet + 1 < Planets.Length)
        {
            CurrentPlanet++;
            SetPlanet(CurrentPlanet);
        }
    }
    public void PrevPlanet()
    {
        if (CurrentPlanet - 1 >= 0)
        {
            CurrentPlanet--;
            SetPlanet(CurrentPlanet);
        }
    }
#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetPlanet(0);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            SetPlanet(1);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            SetPlanet(2);
        }
    }
#endif
}
