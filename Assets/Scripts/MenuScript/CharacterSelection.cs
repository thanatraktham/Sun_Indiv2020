using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject car;
    public GameObject UFO;
    public GameObject van;

    public GameObject carImg;
    public GameObject UFOImg;
    public GameObject vanImg;

    private static int index = 1;
    private int total_char = 3;
    // private GameObject car, UFO;

    private void Awake() {
        // car = car.GetComponent<GameObject>();
        // UFO = UFO.GetComponent<GameObject>();
        
        disableAllImg();
        switch ((index-1+total_char) % total_char)
        {
            case 0 :
                // Debug.Log("here");
                toggleCar(true);
                toggleUFO(false);
                toggleVan(false);
                break;
            case 1 :
                toggleUFO(true);
                toggleCar(false);
                toggleVan(false);
                break;
            case 2 :
                toggleVan(true);
                toggleUFO(false);
                toggleCar(false);
                break;
            default :
                break;
        }
    }

    public void NextCharacter() {
        // Debug.Log("index : " + index);
        switch (index)
        {
            case 0 :
                // Debug.Log("here");
                toggleCar(true);
                toggleUFO(false);
                toggleVan(false);
                index = 1;
                break;
            case 1 :
                toggleUFO(true);
                toggleCar(false);
                toggleVan(false);
                index = 2;
                break;
            case 2 :
                toggleVan(true);
                toggleUFO(false);
                toggleCar(false);
                index = 0;
                break;
            default :
                break;
        }
    }

    public void PrevCharacter() {
        // Debug.Log(index);
        switch (index)
        {
            case 0 :
                toggleUFO(true);
                toggleCar(false);
                toggleVan(false);
                index = 2;
                break;
            case 1 :
                toggleVan(true);
                toggleUFO(false);
                toggleCar(false);
                index = 0;
                break;
            case 2 :
                toggleCar(true);
                toggleUFO(false);
                toggleVan(false);
                index = 1;
                break;
            default :
                break;
        }
    }

    private void toggleCar(bool boolean) {
        car.SetActive(boolean);
        carImg.SetActive(boolean);
    }

    private void toggleUFO(bool boolean) {
        UFO.SetActive(boolean);
        UFOImg.SetActive(boolean);
    }

    private void toggleVan(bool boolean) {
        van.SetActive(boolean);
        vanImg.SetActive(boolean);
    }

    public void disableAllImg() {
        carImg.SetActive(false);
        UFOImg.SetActive(false);
        vanImg.SetActive(false);
    }
}
