using UnityEngine;

public class EndOfLvlTrigger : MonoBehaviour
{
    public GameObject endOfLevelPlatform;
    private PlatformController platformController;

    void Start()
    {
        // Get the PlatformController component from the endOfLevelPlatform game object
        platformController = endOfLevelPlatform.GetComponent<PlatformController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            float ballMass = other.attachedRigidbody.mass; // get the mass of the ball
            platformController.MovePlatformUp(ballMass);
        }
    }
}
