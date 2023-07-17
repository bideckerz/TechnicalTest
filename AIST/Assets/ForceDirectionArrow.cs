using UnityEngine;

public class ForceDirectionArrow : MonoBehaviour
{
    public ForceSensorSimulator forceSensor;
    public Color minForceColor = new Color(0, 0, 1, 0.4f); // Blue with alpha 0.4
    public Color maxForceColor = new Color(1, 0, 0, 0.4f); // Red with alpha 0.4
    public float minForceMagnitude = 0;
    public float maxForceMagnitude = 20;

    private void Update()
    {
        Vector3 force = forceSensor.GetCurrentForce();

        // Set the position and rotation of the arrow to match the force sensor
        transform.position = forceSensor.transform.position;
        transform.rotation = Quaternion.LookRotation(force);

        // Set the color of the arrow based on the magnitude of the force
        float forceMagnitude = force.magnitude;
        float normalizedMagnitude = Mathf.InverseLerp(minForceMagnitude, maxForceMagnitude, forceMagnitude);
        Color newColor = Color.Lerp(minForceColor, maxForceColor, normalizedMagnitude);
        GetComponent<MeshRenderer>().material.color = newColor;
    }
}
