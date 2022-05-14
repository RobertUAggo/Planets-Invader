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
        for (int i = 0; i < Planets.Length; i++)
        {
            Planets[i].SetData(MainScript.Instance.AllPlanetsData[i]);
        }
    }
    private void Start()
    {
        //MenuScript.Instance.MenuCamera.TargetCamera = Planets[0].fakeCamera;
        SetPlanet(SLS.Data.Level.Value - 1, true);
    }
    public void SetPlanet(int planet, bool instant=false)
    {
        CurrentPlanet = planet;
        MenuScript.Instance.MenuCamera.SetTargetCamera(Planets[CurrentPlanet].fakeCamera, instant);
        MenuScript.Instance.PlanetPanel.SetPlanetOnPanel(CurrentPlanet);
        LoadScreenUI.Instance.SetBarSprite(Planets[CurrentPlanet].Data.Sprite);
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
        Planets[CurrentPlanet].LoadLevel();
    }
}
