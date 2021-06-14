using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotater : MonoBehaviour
{
    public Camera SubCamera;
    public Vector2 rotationSpeed;
    public bool reverse;
    private Vector2 lastMousePosition;
    private Vector2 newAngle = new Vector2(0, 0);

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            newAngle = SubCamera.transform.localEulerAngles;
            lastMousePosition = Input.mousePosition;
        }

        else if (Input.GetMouseButton(0))
        {
            if (!reverse)
            {
                newAngle.y -= (lastMousePosition.x - Input.mousePosition.x) * rotationSpeed.y;
                newAngle.x -= (Input.mousePosition.y - lastMousePosition.y) * rotationSpeed.x;
                SubCamera.transform.localEulerAngles = newAngle;
                lastMousePosition = Input.mousePosition;
            }
            else if (reverse)
            {
                newAngle.y -= (Input.mousePosition.x - lastMousePosition.x) * rotationSpeed.y;
                newAngle.x -= (lastMousePosition.y - Input.mousePosition.y) * rotationSpeed.x;
                SubCamera.transform.localEulerAngles = newAngle;
                lastMousePosition = Input.mousePosition;
            }
        }
    }
    public void DirectionChange()
    {
        // 判定フラグ変数"reverse"が"false"であれば
        if (!reverse)
        {
            // 判定フラグ変数"reverse"に"true"を代入
            reverse = true;
        }
        // でなければ（判定フラグ変数"reverse"が"true"であれば）
        else
        {
            // 判定フラグ変数"reverse"に"false"を代入
            reverse = false;
        }
    }
}
