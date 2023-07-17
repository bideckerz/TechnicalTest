using System;
using UnityEngine;

public class ForceSensorSimulator : MonoBehaviour
{

    [Header("Force Settings")]
    public Vector3 minForce;
    public Vector3 maxForce;
    [Header("Position and Rotation Settings")]
    public Vector3 minPosition;
    public Vector3 maxPosition;
    public Vector3 minRotation;
    public Vector3 maxRotation;
    [Header("Current Values")]
    [SerializeField]
    private Vector3 currentForce;
    [SerializeField]
    private Vector3 currentPosition;
    [SerializeField]
    private Vector3 currentRotation;



    private Vector3 GenerateRandomVector3(Vector3 min, Vector3 max)
    {
        return new Vector3(
            UnityEngine.Random.Range(min.x, max.x),
            UnityEngine.Random.Range(min.y, max.y),
            UnityEngine.Random.Range(min.z, max.z));
    }

    private void Start()
    {
        // Randomize position and rotation only once at the start
        Vector3 randomPosition = GenerateRandomVector3(minPosition, maxPosition);
        Vector3 randomRotation = GenerateRandomVector3(minRotation, maxRotation);

        transform.position = randomPosition;
        transform.rotation = Quaternion.Euler(randomRotation);
    }

    private void Update()
    {
        currentForce = GenerateRandomVector3(minForce, maxForce);
    }

    public Vector3 GetCurrentForce()
    {
        return currentForce;
    }
}
