using UnityEngine;

public class AnimatedObject : MonoBehaviour
{
    public float newAngle;
    public float newPosition;
    public float rotationSpeed = 1.0f;
    public float movementSpeed = 1.0f;

    public bool isAnimating = false;
    public bool isMovement = false;
    public bool isRotation = true;


    private void Update()
    {
        if (isAnimating)
        {
            if (isRotation)
            {
                if (transform.eulerAngles.z < newAngle)
                {
                    transform.Rotate(Vector3.forward * (Time.deltaTime * rotationSpeed), Space.World);
                }
                else
                {
                    isAnimating = false;
                }
            }

            if (isMovement)
            {

                if (transform.position.y > newPosition)
                {
                    transform.Translate(Vector3.down * (Time.deltaTime * movementSpeed), Space.World);
                }
                else
                {
                    isAnimating = false;
                }
            }


        }
    }
}