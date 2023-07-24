using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public CharacterController charController;
    public Vector3 directionVector;
    public float gravityScale;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForMovement();
        CheckForJump();
        CheckForGravity();
        //Delta Time is the interval from the last frame to the current one
        charController.Move(directionVector * Time.deltaTime);
    }

    void CheckForMovement()
    {
        //Older methods
        //rigidBody.velocity = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, rigidBody.velocity.y, Input.GetAxis("Vertical") * movementSpeed);
        // directionVector = new Vector3(Input.GetAxis("Horizontal") * speed, directionVector.y, Input.GetAxis("Vertical") * speed);

        float storedY = directionVector.y;
        directionVector = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));

        directionVector = directionVector.normalized * speed; //Normalize the vector according to the set speed
        directionVector.y = storedY; //Dont normalize the y speed
       
    }

    void CheckForJump()
    {
        if (charController.isGrounded && Input.GetButtonDown("Jump"))
        {
            directionVector.y = 0f;
            directionVector.y = jumpSpeed;
         //   Debug.Log("Jump");
            //rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpSpeed, rigidBody.velocity.z);

        }
    }

    void CheckForGravity()
    {
        if (!charController.isGrounded) directionVector.y += Physics.gravity.y * gravityScale * Time.deltaTime;
    }
}
