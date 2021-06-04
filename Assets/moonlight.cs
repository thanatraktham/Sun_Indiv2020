using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLight : MonoBehaviour
{
    //private Light pointLight; // The light component of the firefly
    private float minLuminosity = 0f; // min intensity
    private float maxLuminosity = 1f; // max intensity
    private float luminositySteps = 0.0015f; // factor when increasing / decreasing
    private int round = 0;
    private int dayOrNot;
    private int lightDirection;
    private int score;

    // Start is called before the first frame update
    Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
        myLight.intensity = 1;
        //transform.rotation =   Quaternion.Euler( 50f, -20f, 0f);

    }

    void Update()
    {
        score = GameManager.getScore()%200;
        lightDirection = (50 + (score*18/10))%360;
        Debug.Log("light ="+lightDirection* Time.deltaTime);
        //transform.rotation =  Quaternion.Euler( lightDirection , -20f, 0f);
        //transform.Rotate( new Vector3(2f * Time.deltaTime , 0f , 0f));

        if (GameManager.getScore() %200 == 0 ){
            dayOrNot = 1;
        }
        else if (GameManager.getScore() %100 == 0 ){
            dayOrNot = 0;
        }

        if( lightDirection > 230){
            if( minLuminosity < myLight.intensity){
                myLight.intensity -= luminositySteps;
            }else myLight.intensity = minLuminosity;
        }
        else if( lightDirection > 50){
            if( maxLuminosity > myLight.intensity){
                myLight.intensity += luminositySteps;
            }else myLight.intensity = maxLuminosity;
        }

    }

}
