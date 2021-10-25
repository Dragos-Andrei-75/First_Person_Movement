using System.Collections; //This is a library. A library is a collection of predefined classes, methods, variables, etc.
using System.Collections.Generic;
using UnityEngine;

//access_modifier type variable = value;
//access_modifier type variable = class.variable;
//access_modifier type variable = class.method(type variable_2, type variable_3, ...);

public class MouseLook : MonoBehaviour //This is a class. A class is a container that includes methods and variables.
{                                      //In Unity, the main class derives from the built-in class "MonoBehaviour".
                                       //The main class must have the same name as the script file it belongs to in order for the script to work properly.
    
    public Transform playerBody; //This is a variable. A variable is a container that holds data or the memory adress of data.
                                 //"public" highlights the fact that this variable is visible to other scripts aswell as in the Inspector.
                                 //"Transform" is a reference data type. This variable will be used to refer to the "Transform" component of the GameObject to which this script is assigned.
    
    private float xRotation = 0f; //"private" highlights the fact that this variable is invisible to other scripts as well as in the Inspector.
    
    [SerializeField] private float mouseSensitivity = 500f; //"[SerializeField]" will make this variable visible in the Inspector in spite of the fact that it is declared as a private variable, without
                                                            //giving users the option to modify it.

    //Start is called before the first frame update
    void Start() //This is a method. A method is a container that includes instructions and variables.
    {
        Cursor.lockState = CursorLockMode.Locked; //"Cursor" is a cursor API for setting the mouse pointer.
                                                  //"lockState" determines wether the hardware pointer is locked to the center of the view, constrained to the game window or not constrained at all.
                                                  //"CursorLockMode" is used to describe how the cursor should behave(Locked, Constrained or None).
                                                  //This line of code will position the cursor at the center of the screen and make it invisible.
    }

    //Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; //"Input" is an interface into the Input system.
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; //"GetAxis" returns the value of the specified virtual axis.
                                                                                     //"Mouse X" / "Mouse Y" is a predefined virtual axis in Unity that is going to change based on the mouse movement.
                                                                                     //"Time" is an interface used to get time information from Unity.
                                                                                     //"deltaTime" provides the time between the current frame and the previous frame.

        playerBody.Rotate(Vector3.up * mouseX); //"Rotate" rotates GameObjects.
                                                //"Vector3" is a representation of 3D vectors and points that passes 3D positions and directions around.
                                                //This line of code will allow the user to move the camera from side to side(along the X axis). Moving the camera along the X axis means rotating the
                                                //camera around the Y axis.

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //"Mathf" is a collection of common math methods.
                                                       //"Clamp" will limit the rotation around the X axis to 180 degrees in order to prevent the player from over-rotating the camera.
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //"transform" refers to the "Transform" component of the GameObject to which this script is assigned.
                                                                       //"Quaternion" is used to represent rotations.
                                                                       //"Euler" returns a rotation around the X, Y and Z axis in that specific order.
                                                                       //This line of code will allow the user to move the camera up and down(along the Y axis). Moving the camera along the Y axis
                                                                       //means rotating the camera around the X axis.
    }
}
