using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Translate (Vector3.back * Time.deltaTime * SpeedController.getSpeed());
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Obstacle")) {
            // Debug.Log("set destroy object");
            if (gameObject != null) {
                Destroy(gameObject);
            }
        } else if (other.gameObject.CompareTag("DeathWall")) {
            // Debug.Log("ojbect destroy set");
            if (gameObject != null) {
                Destroy(gameObject);
            }
        }
    }
}