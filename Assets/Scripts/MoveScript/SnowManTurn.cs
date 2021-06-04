using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManTurn : MonoBehaviour
{
    public GameObject snowball;
    private bool alreadyTurn;
    private static int count;

    // Start is called before the first frame update
    void Start()
    {
        alreadyTurn = true;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.getGameHalt()) {
            if(alreadyTurn){
                StartCoroutine(wait(1f));
                // transform.Rotate( 0f, 90f, 0f);
                GameObject snowballClone = Instantiate(snowball) as GameObject;
                // StartCoroutine(TmpIgnoreCollision(snowballClone));
                //Debug.Log("ball spawn");
                // snowballClone.transform.Rotate(0f, 90f * count, 0f);
                snowballClone.transform.position = this.transform.position + new Vector3( 0f, 0.5f, 0f);
                count = (count + 1) % 4;
            }
        }
    }

    private IEnumerator wait(float t) {
        alreadyTurn = false;
        yield return new WaitForSeconds(t);
        alreadyTurn = true;
    }

    private IEnumerator TmpIgnoreCollision(GameObject snowball) {
        // Physics.IgnoreCollision(ball.GetComponent<Collider>(), snowman.GetComponent<Collision>());
        snowball.GetComponent<Collider>().enabled = false;
        Debug.Log("Collision disable");
        yield return new WaitForSeconds(0.1f);
        snowball.GetComponent<Collider>().enabled = true;
        Debug.Log("Collision enable");
    }

    public static int getCount(){
        return count;
    }
}