using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlatformController : MonoBehaviour
{
    private Rigidbody ballRigidbody;
    private bool isMoving = false;
    [SerializeField] private float accelarate = 0.1f;
    private float speed = 0f;
    private float maxHeight = 0f;
    private float shootForce = 10f;

    private void Start()
    {
        ballRigidbody = GameObject.FindWithTag("Ball").GetComponent<Rigidbody>();
    }

    public void MovePlatformUp(float ballMass)
    {
        // Gradually increase the speed based on the mass of the ball
        speed += ballMass * accelarate * Time.deltaTime;

        if (!isMoving)
        {
            isMoving = true;
            StartCoroutine(MovePlatform());
        }
    }

    private IEnumerator MovePlatform()
    {
        while (isMoving && transform.position.y < maxHeight)
        {
            Vector3 newPosition = transform.position + new Vector3(0, 1, 0) * speed;
            transform.position = newPosition;
            yield return null;
        }

        // Shoot the ball away when the platform reaches the maxHeight
        if (isMoving)
        {
            Vector3 shootDirection = (ballRigidbody.transform.position - transform.position).normalized;
            ballRigidbody.AddForce(shootDirection * shootForce, ForceMode.Impulse);
        }

        // Stop the platform when it reaches the maxHeight
        isMoving = false;
        speed = 0f;
    }
}
