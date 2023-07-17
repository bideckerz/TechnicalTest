using UnityEngine;

public class SensorManager : MonoBehaviour
{
    public GameObject arrowAndSensorPrefab; 
    public int numberOfSensors = 1;

    public Vector3 globalMinForce = new Vector3(-10, -10, -10);
    public Vector3 globalMaxForce = new Vector3(10, 10, 10);
    public Vector3 globalMinPosition = new Vector3(-10, -10, -10);
    public Vector3 globalMaxPosition = new Vector3(10, 10, 10);
    public Vector3 globalMinRotation = new Vector3(-180, -180, -180);
    public Vector3 globalMaxRotation = new Vector3(180, 180, 180);
    public Color globalMinForceColor = new Color(0, 1, 0, 0.4f); // Green with alpha 0.4
    public Color globalMaxForceColor = new Color(1, 0, 0, 0.4f); // Red with alpha 0.4
    public float globalMinForceMagnitude = 0;
    public float globalMaxForceMagnitude = 20;

    private void Start()
    {
        CreateSensorsAndArrows();
    }

    private void CreateSensorsAndArrows()
    {
        for (int i = 0; i < numberOfSensors; i++)
        {
            CreateSensorAndArrow();
        }
    }

    private void CreateSensorAndArrow()
    {
        GameObject newArrowAndSensor = Instantiate(arrowAndSensorPrefab);

        ForceSensorSimulator newForceSensor = newArrowAndSensor.GetComponent<ForceSensorSimulator>();
        ForceDirectionArrow newArrow = newArrowAndSensor.GetComponent<ForceDirectionArrow>();

        newArrow.forceSensor = newForceSensor;

        UpdateSensorSettings(newForceSensor);
        UpdateArrowSettings(newArrow);
    }

    private void UpdateSensorSettings(ForceSensorSimulator sensor)
    {
        sensor.minForce = globalMinForce;
        sensor.maxForce = globalMaxForce;
        sensor.minPosition = globalMinPosition;
        sensor.maxPosition = globalMaxPosition;
        sensor.minRotation = globalMinRotation;
        sensor.maxRotation = globalMaxRotation;
    }

    private void UpdateArrowSettings(ForceDirectionArrow arrow)
    {
        arrow.minForceColor = globalMinForceColor;
        arrow.maxForceColor = globalMaxForceColor;
        arrow.minForceMagnitude = globalMinForceMagnitude;
        arrow.maxForceMagnitude = globalMaxForceMagnitude;
    }
}
