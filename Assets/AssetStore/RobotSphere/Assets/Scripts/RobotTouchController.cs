using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotTouchController : MonoBehaviour
{

    #region Public Variables

    public float moveSpeed = 3f;
    public float turnSpeed = 10f;
    public float deadZone = 0.2f;

    #endregion

    #region Private Variables

    private Animator robotAnim;
    private Rigidbody robotRigidBody;
    private Joystick joystick;

    #endregion

    private void OnEnable()
    {
        joystick = FindObjectOfType<Joystick>();
        robotRigidBody = GetComponent<Rigidbody>();
        robotAnim = GetComponent<Animator>();

        robotAnim.SetBool("Open_Anim", true);
    }
   
    void Update()
    {
        #region Movement

        if(joystick.Direction.magnitude >= deadZone)
        {
            robotRigidBody.AddForce(transform.forward * moveSpeed);

            // Animate the robot walking
            robotAnim.SetBool("Walk_Anim", true);
        }
        else
        {
            // Animate the robot idle
            robotAnim.SetBool("Walk_Anim", false);
        }
        #endregion

        #region Rotation

        Vector3 targetDirection = new Vector3(joystick.Direction.x, 0, joystick.Direction.y);
        Vector3 direction = Vector3.RotateTowards(transform.forward, targetDirection, turnSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(direction);

        #endregion
    }
}
