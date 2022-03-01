using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsManager : MonoBehaviour
{
    public int CurrentPlanet;
    public Planet[] Planets;
    private void Awake()
    {
        Planets = GetComponentsInChildren<Planet>();
    }
    private void Start()
    {
        //MenuScript.Instance.MenuCamera.TargetCamera = Planets[0].fakeCamera;
        CurrentPlanet = SLS.Data.Level.Value - 1;
        MenuScript.Instance.MenuCamera.FastSet(MenuScript.Instance.PlanetsManager.Planets[CurrentPlanet].fakeCamera);
        MenuScript.Instance.PlanetPanel.SetPlanetOnPanel(CurrentPlanet);
    }
    public void SetPlanet(int planet)
    {
        CurrentPlanet = planet;
        MenuScript.Instance.MenuCamera.SetTargetCamera(MenuScript.Instance.PlanetsManager.Planets[CurrentPlanet].fakeCamera);
        MenuScript.Instance.PlanetPanel.SetPlanetOnPanel(CurrentPlanet);
    }
    public void NextPlanet()
    {
        if (CurrentPlanet + 1 < Planets.Length)
        {
            SetPlanet(CurrentPlanet + 1);
        }
    }
    public void PrevPlanet()
    {
        if (CurrentPlanet - 1 >= 0)
        {
            SetPlanet(CurrentPlanet - 1);
        }
    }
    public void LoadCurrentPlanetLevel()
    {
        Loader.LoadLevel(CurrentPlanet+1);
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
