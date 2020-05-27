using UnityEngine;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class PermissionsRationaleDialogue : MonoBehaviour
{
    const int kDialogueWidth = 300;
    const int kDialogueHeight = 100;
    private bool windowOpen = true;

    void DoMyWindow(int windowID)
    {
        GUI.Label(new Rect(10, 20, kDialogueWidth - 20, kDialogueHeight - 50), "Painted Puffin uses the user's country and state/province for display on the in-app online high score list.");
        GUI.Button(new Rect(10, kDialogueHeight - 30, 100, 20), "No");
        if (GUI.Button(new Rect(kDialogueWidth - 110, kDialogueHeight - 30, 100, 20), "Yes"))
        {
#if PLATFORM_ANDROID
            Permission.RequestUserPermission(Permission.CoarseLocation);
#endif
            windowOpen = false;
        }
    }

    void OnGUI()
    {
        if (windowOpen)
        {
            Rect rect = new Rect((Screen.width / 2) - (kDialogueWidth / 2), (Screen.height / 2) - (kDialogueHeight / 2), kDialogueWidth, kDialogueHeight);
            GUI.ModalWindow(0, rect, DoMyWindow, "Permissions Request Dialogue");
        }
    }
}