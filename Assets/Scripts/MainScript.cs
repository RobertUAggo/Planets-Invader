using UnityEngine;

public class MainScript : MonoBehaviour
{
    [SerializeField] public AllPlanetsData AllPlanetsData;
    //
    [HideInInspector] public static MainScript Instance;
    private void Awake()
    {
        Instance = this;
        Application.targetFrameRate = 90;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SLS.Data.Level.Value++;
            if (SLS.Data.Level.Value > AllPlanetsData.Length)
            {
                SLS.Data.Level.Value = 1;
            }
            Loader.LoadLevel(SLS.Data.Level.Value);
        }
    }
    private void Start()
    {
        Loader.GameStart();
    }
}
