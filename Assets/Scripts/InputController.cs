using UnityEngine;
using UnityEngine.Events;

public enum SwipeDirection
{
    Up, Right, Down, Left
}

public class InputController : MonoBehaviour
{
    [SerializeField] private Vector2 resolution = new Vector2(1080, 1920);
    public static UnityEvent<Vector2> OnHold = new UnityEvent<Vector2>();
    //
    private static Vector2 prevMousePosition;
    //
    private static float screenScale;
    private void Awake()
    {
        screenScale = ((Screen.width / resolution.x) + (Screen.height / resolution.y))/2;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            prevMousePosition = Input.mousePosition;
        }
        else if(Input.GetMouseButton(0))
        {
            OnHold.Invoke(((Vector2)Input.mousePosition - prevMousePosition) / screenScale);
            prevMousePosition = Input.mousePosition;
        }
        
    }
    public static SwipeDirection GetSwipeDirection(Vector2 vec)
    {
        if(Mathf.Abs(vec.x) > Mathf.Abs(vec.y))
        {
            if (vec.x > 0) return SwipeDirection.Right;
            else return SwipeDirection.Left;
        }
        else
        {
            if (vec.y > 0) return SwipeDirection.Up;
            else return SwipeDirection.Down;
        }
    }

}
