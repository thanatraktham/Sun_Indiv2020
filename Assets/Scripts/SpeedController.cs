using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpeedController : MonoBehaviour
{
    // Start is called before the first frame update
    public static float speed;

    private static int maxSpeed;
    private static float tmpSpeed;
    private bool haltSpeedSet;

    // Start is called before the first frame update
    void Start()
    {
        speed = 16;
        tmpSpeed = speed;
        maxSpeed = 32;
        haltSpeedSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.getGameHalt()) {
            if (haltSpeedSet) {
                speed = tmpSpeed;
                haltSpeedSet = false;
            }
            if (!UI_Controller.inMenu) {
                xlr8();
            }
        } else if (!haltSpeedSet){
            tmpSpeed = speed;
            speed = 0;
            haltSpeedSet = true;
        }
        // Debug.Log(speed);
    }

    //-------------------- FUNC --------------------//
    private void xlr8() {
        if( speed > 24 && speed < maxSpeed){
            speed += (0.025f * Time.deltaTime);
        }
        else if (speed < maxSpeed) {
            speed += (0.05f * Time.deltaTime);
        }
    }

    //-------------------- GETTER / SETTER --------------------//
    public static float getSpeed() {
        return (float) Math.Round(speed, 2);
    }

    public static void setSpeed(int newSpeed) {
        speed = newSpeed;
    } 
}
