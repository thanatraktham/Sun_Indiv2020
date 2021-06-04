using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLight : MonoBehaviour
{
    private float minLuminosity = 0f; 
    private float maxLuminosity = 0.8f; 
    private float luminositySteps = 0.0015f; 
    private static int scoreMod;
    private static int scoreToChange;
    private Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
        scoreToChange = 300;
    }

    void Update()
    {
        scoreMod = GameManager.getScore()%scoreToChange;

        if( scoreMod > scoreToChange/2){
            if( minLuminosity < myLight.intensity){
                myLight.intensity -= luminositySteps;
            }else myLight.intensity = minLuminosity;
        }
        else if( scoreMod > 0){
            if( maxLuminosity > myLight.intensity){
                myLight.intensity += luminositySteps;
            }else myLight.intensity = maxLuminosity;
        }

    }
    public static int getScoreMod(){
        return scoreMod;
    }
    public static int getScoreToChange(){
        return scoreToChange;
    }
}