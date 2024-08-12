using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleMovement : MonoBehaviour
{

    public Rigidbody rb;
    public Transform transforms;
    private float currRotationSpeed;
    private float currLinearVelocity;
    private bool grounded;
    public Vector3 jump;

    [SerializeField] float jumpPower;

    [SerializeField] float maxRotationValue;
    [SerializeField] float RaccelerationRate;

    [SerializeField] float maxVelocity;
    [SerializeField] float LaccelerationRate;




    // Start is called before the first frame update
    void Start()
    {
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        grounded = true;
    }


    // Update is called once per frame
    void Update()
    {
        updateRotationSpeed();
        updateRotation();
        updateLinearVelocity();
        updatePosition();
        jumpListener();
        

    }


    void jumpListener() {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(jump * jumpPower, ForceMode.VelocityChange);
            
        }
    }


    void updateLinearVelocity() {
        if (Input.GetKey(KeyCode.W) && currLinearVelocity > -1 * maxVelocity)
        {
            currLinearVelocity += LaccelerationRate;
        }

        if (Input.GetKey(KeyCode.S) && currLinearVelocity < maxVelocity)
        {
            currLinearVelocity -= LaccelerationRate;
        }



        if (!(Input.GetKey(KeyCode.W)) && !(Input.GetKey(KeyCode.S)))
        {
            currLinearVelocity = 0;
        }


    }

    void updatePosition() {
        float xAmount;
        float zAmount;
        int angle = (int)transforms.rotation.y;

        while (angle < 0) { angle += 360; }
        while (angle > 360) { angle -= 360; }

        zAmount = currLinearVelocity * Mathf.Cos(angle);
        xAmount = currLinearVelocity * Mathf.Sin(angle);


        Debug.Log("curr Vel: " + currLinearVelocity+ " x: " + currLinearVelocity * Mathf.Sin(angle) + " z: " + zAmount);

        transforms.Translate((float)xAmount * Time.deltaTime, 0, (float)zAmount * Time.deltaTime);

        /*rb.velocity = new Vector3(xAmount, 0, zAmount);*/
        

    }

    void updateRotationSpeed() {

        if (Input.GetKey(KeyCode.A) && currRotationSpeed > -1*maxRotationValue)
        {
            currRotationSpeed -= RaccelerationRate;
        }

        if (Input.GetKey(KeyCode.D) && currRotationSpeed < maxRotationValue)
        {
            currRotationSpeed += RaccelerationRate;
        }



        if (!(Input.GetKey(KeyCode.D)) && !(Input.GetKey(KeyCode.A)))
        {
            currRotationSpeed = 0;
        }

    }

    void updateRotation() {
        /*transforms.Rotate(0, (float)currRotationSpeed * Time.deltaTime, 0);*/

        rb.angularVelocity = new Vector3(0, currRotationSpeed, 0); 
    }
}
