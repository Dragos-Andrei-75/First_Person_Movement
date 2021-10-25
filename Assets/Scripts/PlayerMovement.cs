using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 15f;

    Vector3 velocity;
    [SerializeField] private float gravity = -9.81f;

    private bool isGrounded;
    public Transform groundCheck; //position of the sphere
    private float groundDistance = 0.5f; //radius of the sphere
    public LayerMask groundMask;

    public float jumpHeight = 3f;

    private void Update()
    {
        float moveVertical = Input.GetAxis("Vertical"); //Vertical movement takes place on the Z axis.
        float moveHorizontal = Input.GetAxis("Horizontal"); //Horizontal movement takes place on the X axis.

        //Vector3 move = new Vector3(moveHorizontal, 0f, moveVertical); //This technique is not convenient for a first person perspective because it uses global coordinates.
        Vector3 move = transform.forward * moveVertical + transform.right * moveHorizontal; //"forward" and "right" are normalized vectors representing the Z and X axis respectively.
        controller.Move(move * speed * Time.deltaTime); //"Move" is a more complex move method that takes absolute movement deltas.

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //"Physics" contains global physics properties and helper methods.
                                                                                            //"CheckSphere" returns "true" if there are any colliders overlapping the sphere defined by
        if (isGrounded && velocity.y < 0)                                                   //position(groundCheck.position) and radius(groundDistance) in world coordinates.
        {
            velocity.y = -2f;
        }

        if (isGrounded && Input.GetButtonDown("Jump")) //"GetButtonDown" is a function that returns "true" when the user presses down the specified virtual button.
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity); //"Sqrt" is a function that works as a square root.
        }
    }
}
