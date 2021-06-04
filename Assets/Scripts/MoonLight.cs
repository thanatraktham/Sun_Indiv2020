using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonLight : MonoBehaviour
{
    //private Light pointLight; // The light component of the firefly
    [SerializeField]
    private float maxLuminosity ; // max intensity
    private float minLuminosity = 0f; // min intensity

    [SerializeField]
    private float luminositySteps ; // factor when increasing / decreasing
    private int lightDirection;
    private int scoreMod;

    // Start is called before the first frame update
    Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
        myLight.intensity = 0;
    }

    void Update()
    {
        scoreMod = SunLight.getScoreMod();

        if( scoreMod > SunLight.getScoreToChange()/2 ){
            if( maxLuminosity > myLight.intensity){
                myLight.intensity += luminositySteps;
            }else myLight.intensity = maxLuminosity;
        }
        else if( scoreMod > 0){
            if( minLuminosity < myLight.intensity){
                myLight.intensity -= luminositySteps;
            }else myLight.intensity = minLuminosity;
        }

    }

}
