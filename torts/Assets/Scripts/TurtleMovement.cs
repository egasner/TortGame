using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleMovement : MonoBehaviour
{

    public Transform transforms;
    private double currRotationSpeed;
    private double currLinearVelocity;
    [SerializeField] double maxRotationValue;
    [SerializeField] double RaccelerationRate;

    [SerializeField] double maxVelocity;
    [SerializeField] double LaccelerationRate;




    // Start is called before the first frame update
    void Start()
    {
       
    }


    // Update is called once per frame
    void Update()
    {
        updateRotationSpeed();
        updateRotation();
        updateLinearVelocity();
        UpdatePosition();


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

    void UpdatePosition() {
        double xAmount;
        double zAmount;
        int angle = (int)transforms.rotation.y;

        while (angle < 0) { angle += 360; }
        while (angle > 360) { angle -= 360; }

        zAmount = currLinearVelocity * Mathf.Cos(angle);
        xAmount = currLinearVelocity * Mathf.Sin(angle);


       

        transforms.Translate((float)xAmount * Time.deltaTime, 0, (float)zAmount * Time.deltaTime);


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
        transforms.Rotate(0, (float)currRotationSpeed * Time.deltaTime, 0);
    }
}
