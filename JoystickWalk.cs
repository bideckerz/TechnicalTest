using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class JoystickWalk : MonoBehaviour
{
  public SteamVR_Input_Sources leftStick;
  public SteamVR_Input_Sources rightStick;
  public SteamVR_Action_Vector2 action;
  public McRtc.ArrayInput ref_vel;


  public SpriteRenderer joystickSpriteRenderer;
  public Sprite forwardSprite;
  public Sprite backwardSprite;
  public Sprite leftSprite;
  public Sprite rightSprite;
  public Sprite standby;


  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    Vector2 leftAxis = action.GetAxis(leftStick);
    Vector2 rightAxis = action.GetAxis(rightStick);
    // Check joystick state
        if (leftAxis.y > joystickThreshold)
        {
            // Joystick is moved forward
            SetSprite(forwardSprite);
        }
        else if (leftAxis.y < -joystickThreshold)
        {
            // Joystick is moved backward
            SetSprite(backwardSprite);
        }
        else if (leftAxis.x > joystickThreshold)
        {
            // Joystick is moved left
            SetSprite(leftSprite);
        }
        else if (leftAxis.x < -joystickThreshold)
        {
            // Joystick is moved right
            SetSprite(rightSprite);
        }
        else
        {
            // Joystick is not actively moved, set a default sprite 
            SetSprite(standby);
        }

        // Update the data for McRtc.ArrayInput
        ref_vel.data = new float[] { leftAxis.y, -leftAxis.x, -rightAxis.x };
    }

    void SetSprite(Sprite sprite)
    {
        if (joystickSpriteRenderer != null)
        {
            // Set the sprite to the desired sprite or null to hide it
            joystickSpriteRenderer.sprite = sprite;
        }
    }
}
