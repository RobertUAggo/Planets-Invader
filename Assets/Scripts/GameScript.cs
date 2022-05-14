using UnityEngine;

public class GameScript : MonoBehaviour
{
    [SerializeField] public CameraScript CameraScript;
    //
    [HideInInspector] public static GameScript Instance;
    private void Awake()
    {
        Instance = this;
    }
}
