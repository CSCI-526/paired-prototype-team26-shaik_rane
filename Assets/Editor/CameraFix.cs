using UnityEngine;
using UnityEditor;

public static class CameraFix
{
    [MenuItem("Tools/Sonar/Center Camera On Player")]
    public static void CenterCameraOnPlayer()
    {
        Camera cam = Camera.main;
        if (cam == null)
        {
            Debug.LogError("No Main Camera found in scene. Please tag your camera as MainCamera.");
            return;
        }

        GameObject player = GameObject.FindWithTag("Player");
        if (player == null)
            player = GameObject.Find("Player");

        if (player == null)
        {
            Debug.LogError("No Player object found (tag 'Player' or name 'Player'). Place player in scene first.");
            return;
        }

        Undo.RecordObject(cam.transform, "Center Camera On Player");
        Vector3 p = player.transform.position;
        cam.transform.position = new Vector3(p.x, p.y, -10f);

        if (cam.orthographic)
        {
            Undo.RecordObject(cam, "Set Camera Size");
            cam.orthographicSize = 12f;
        }

        Debug.Log("Camera centered on Player and orthographic size set to 12.");
    }
}
