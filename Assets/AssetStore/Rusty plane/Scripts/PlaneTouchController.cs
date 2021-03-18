using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTouchController : MonoBehaviour
{
    #region Public Variables

    public float moveSpeed = 5f;
    public float turnSpeed = 10f;
    public float upForce = 3.5f;
    public float deadZone = 0.2f;

    #endregion

    #region Private Variables

    private Rigidbody planeRigidBody;
    private Joystick joystick;

    #endregion
    

    void OnEnable()
    {
        joystick = FindObjectOfType<Joystick>();
        planeRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        #region Movement

        // keep the plane flying
        planeRigidBody.AddForce(transform.up * upForce, ForceMode.Acceleration);

        // limit how fast it is
        planeRigidBody.velocity = Vector3.ClampMagnitude(planeRigidBody.velocity, moveSpeed);

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        #endregion

        #region Rotation

        Quaternion deviceRotation = DeviceRotation.Get();

        transform.rotation = deviceRotation;

        #endregion
    }
}
