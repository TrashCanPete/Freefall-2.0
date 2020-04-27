﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerTest : MonoBehaviour
{
    private GliderController gliderController;
    private FlyingStates flyingStates;
    private RotationController rotationController;
    public StateMachineAnimation stateMachineAnimation;

    public float minBoost;
    public float maxBoost;
    public float boostVariable;
    private float boostUpdater;

    //input variables
    [SerializeField]
    public float pitch;
    public float yaw;

    [SerializeField]
    private float xRotationSpeed;
    [SerializeField]
    private float yRotationSpeed;


    // Start is called before the first frame update
    void Start()
    {

        stateMachineAnimation = GetComponent<StateMachineAnimation>();
        rotationController = GetComponent<RotationController>();
        flyingStates = GetComponent<FlyingStates>();
        gliderController = GetComponent<GliderController>();

    }


    // Update is called once per frame
    void Update()
    {
        boostVariable = boostUpdater;
    }
    public void InputData()
    {
        //Getting the input data for rotatiing
        yaw = yRotationSpeed * Input.GetAxis("Horizontal") * rotationController.currentYawRotationSpeed * Time.deltaTime;

        if (flyingStates.canTurnUp == true)
        {
            pitch = xRotationSpeed * Input.GetAxis("Vertical") * rotationController.currentPitchRotationSpeed * Time.deltaTime;
        }
        else if (flyingStates.canTurnUp == false)
        {
            pitch = Mathf.Clamp(pitch, 0, 1);
            //pitch = xRotationSpeed * Input.GetAxis("Vertical") * rotationController.currentPitchRotationSpeed * Time.deltaTime;
        }
        stateMachineAnimation.TiltingAnimation();
        stateMachineAnimation.TurningAnimation();


        if (flyingStates.boostFuel == 0)
        {
            Debug.Log("Out of fuel");

            flyingStates.isBoosting = false;
            boostUpdater = minBoost;

        }
        else if (flyingStates.boostFuel > 0)
        {
            if (Input.GetButtonDown("Shift"))
            {
                flyingStates.isBoosting = true;
                boostUpdater = maxBoost;


                stateMachineAnimation.BoostingAnimation();
            }
            else if (Input.GetButtonUp("Shift"))
            {
                flyingStates.isBoosting = false;

                boostUpdater = minBoost;

            }

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


    }
}
