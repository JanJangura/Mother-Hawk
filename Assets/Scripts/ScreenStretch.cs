using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenStretch : MonoBehaviour
{
    private Vector2 screenResolution;

    void Start()
    {
        screenResolution = new Vector2(Screen.width, Screen.height);
        MatchPlaneToScreenSize();
    }

    private void Update()
    {
        // Check if screen changed size
        if (screenResolution.x != Screen.width || screenResolution.y != Screen.height)
        {
            MatchPlaneToScreenSize();
            screenResolution.x = Screen.width;
            screenResolution.y = Screen.height;
        }
    }

    private void MatchPlaneToScreenSize()
    {
        // Orthographic Camera. Radians = (Math.PI / 180) * degrees. Default plane scale is 10 units in x and z
        float planeHeightScale = 2.0f * Camera.main.orthographicSize / 10f;
        float planeWidthScale = planeHeightScale * Camera.main.aspect;
        gameObject.transform.localScale = new Vector3(planeWidthScale, 1, planeHeightScale);
    }
}
