using Oculus.Interaction.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayerMovement : MonoBehaviour
{
  
    public float speed = 1f;
    public CharacterController characterController;

    void Update()
    {
        Vector2 thumpsticks = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick) + OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        //if (thumpsticks.magnitude > 0.1f)
        //{
            Vector3 dir = Camera.main.transform.TransformDirection(new Vector3(thumpsticks.x, 0, thumpsticks.y));
            characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(dir, Vector3.up) - new Vector3(0f, 9.81f, 0f) * Time.deltaTime);
        //}
    }
}
