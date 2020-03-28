using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;
    bool crouch = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
      /*
      GetAxisRaw:
      Basically for detecting input
      left or A = -1
      Right or D = 1

      */
      if (Input.GetButtonDown("Jump"))//if jump button is pressed sets jump to true (makes player jump)
      {
        jump = true;
      }
      if (Input.GetButtonDown("Crouch"))
      {
        crouch = true;
      } else if (Input.GetButtonUp("Crouch")){ // if crouch is no longer pressed stops crouching
        crouch = false;
      }



    }
    void FixedUpdate()
    {
      // Move our character
      controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
      jump = false; //so we're not jumping forever
      /*
      Time.fixedDeltaTime is the amount of time elapsed since the last time function called
      multiplying makes sure we move the same amount no matter how many times function is called
      ensures consistency across platforms
      */
    }
}
