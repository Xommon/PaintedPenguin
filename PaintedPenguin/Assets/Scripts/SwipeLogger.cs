using UnityEngine;

public class SwipeLogger : MonoBehaviour
{
    public PlayerMovement player;

    private void Awake()
    {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }

    private void SwipeDetector_OnSwipe(SwipeData data)
    {
        if (player.position == "walking")
        {
            if (data.Direction == SwipeDirection.Up)
            {
                player.Jump();
            }

            if (data.Direction == SwipeDirection.Down)
            {
                player.Dive();
            }
        }
    }


}