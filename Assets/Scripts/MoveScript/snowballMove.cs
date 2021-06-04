using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowballMove : MonoBehaviour
{
    private int count;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        count = SnowManTurn.getCount();
        if(count == 0){
            direction = new Vector3(  15f * Time.deltaTime, 0f, 0f);
        }else if(1%count == 0){
            direction = new Vector3(  0f  , 0f, -1f * Time.deltaTime * SpeedController.getSpeed());
        }else if(count == 2){
            direction = new Vector3(  -15f * Time.deltaTime, 0f, 0f);
        /* UNCOMMENT THESE LINE IF YOU WANT SNOWBALL TO MOVE UPWARD
        }else if(count == 3){
            direction = new Vector3(  0f, 0f, 2f * Time.deltaTime * SpeedController.getSpeed());
        */
        }
        StartCoroutine(destroyTimer(5f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (Vector3.back * Time.deltaTime * SpeedController.getSpeed());
        transform.position = transform.position + direction;
        // if (!GameManager.getGameHalt()) {
        // }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("DeathWall") || other.gameObject.CompareTag("Cart")) {
            Destroy(this.gameObject);
        }
    }

    private IEnumerator destroyTimer(float f) {
        yield return new WaitForSeconds(f);
        if (this.gameObject != null) {
            Destroy(this.gameObject);
            // Debug.Log("Destroyed");
        }
    } 
}
