using UnityEngine;

public class RiseObject : MonoBehaviour
{
    // Public variable to set the speed of rising
    public float riseSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        // Move the object upwards along the y-axis
        transform.Translate(Vector3.up * riseSpeed * Time.deltaTime);
    }
}
