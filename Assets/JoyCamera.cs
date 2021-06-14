using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyCamera : MonoBehaviour
{
    public float sight_x = 0;
    public float sight_y = 0;
    public Camera camera;
    // Update is called once per frame
    void Update()
    {
        float angleH = Input.GetAxis("ds4_L3h") * 3.0f;
        float angleV = -1 * Input.GetAxis("ds4_L3v") * 3.0f;
        float scroll = Input.GetAxis("ds4_R3v");
        float view = camera.fieldOfView - scroll;
        camera.fieldOfView = Mathf.Clamp(value: view, min: 0.1f, max: 120f);
        sight_y = Mathf.Clamp(sight_y + angleV, min: -90, max: 80);
        if (sight_x >= 360)
        {
            sight_x = sight_x - 360;
        }
        else if (sight_x < 0)
        {
            sight_x = 360 - sight_x;
        }
        sight_x = sight_x + angleH;
        transform.localRotation = Quaternion.Euler(sight_y, sight_x, 0);

    }
    
}
