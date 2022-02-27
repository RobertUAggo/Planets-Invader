using UnityEngine;

public class MainScript : MonoBehaviour
{
    [SerializeField] public int LevelCount = 2;
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
            Loader.LoadCurrentLevel();
        }
    }
    private void Start()
    {
        Loader.GameStart();
    }
}
