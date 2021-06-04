using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartmove : MonoBehaviour
{
    private int direction ;
    private int speed ;
    private int checkHead; // 0 = Left , 1 = Right

    // Start is called before the first frame update
    void Start()
    {
        checkHead = 1;
        direction = 1;    
        speed = (Random.Range(1,5) * 4);
        transform.Rotate( 0f, 180f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if( transform.position.x < -20){
            direction = 1;
            if (checkHead == 0) {
                checkHead = 1;
                transform.Rotate ( 0f, 180f, 0f);
            }
        }
        else if( transform.position.x > 20){
            direction = -1;
            if (checkHead == 1) {
                checkHead = 0;
                transform.Rotate ( 0f, 180f, 0f);
            }
        }
        
        transform.position = transform.position + new Vector3( speed * direction * Time.deltaTime, 0f, 0f);

        // if( direction == -1 && checkHead == 1){
        //     checkHead = 0;
        //     transform.Rotate ( 0f, 180f, 0f);
        // }else if(direction == 1 && checkHead == 0){
        //     checkHead = 1;
        //     transform.Rotate ( 0f, 180f, 0f);
        // }

    }
}
