using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{

    private Vector3 angle;
    public float wheelAngle, maxWheelAngle = 30f;

    // Start is called before the first frame update
    void Update()
    {
        wheelAngle = -Input.GetAxis("Horizontal") * maxWheelAngle;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        angle = transform.localEulerAngles;
        angle.z = wheelAngle;
        transform.localEulerAngles = angle;
    }
}
