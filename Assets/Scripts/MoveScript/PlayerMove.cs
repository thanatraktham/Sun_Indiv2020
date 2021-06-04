using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour
{
    
    public AnimationController animationController;
    public CameraShake cameraShake;
    public GameObject slowButton;
    
    private bool alreadyMove;
    private int direction;
    private int isGameStart;
    private Vector3 placeLeft;
    private Vector3 placeRight;
    private Vector3 placeFront;
    private Vector3 placeBack;
    private Vector3 nextPosition;

    // Start is called before the first frame update
    void Start()
    {
        isGameStart = 0;
        placeLeft = new Vector3(-2f, 0f, 0f);
        placeRight = new Vector3(2f, 0f, 0f);
        placeFront = new Vector3(0f, 0f, 2f);
        placeBack = new Vector3(0f, 0f, -2f);
        transform.position = new Vector3(0f, 0f, 19f);

        alreadyMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.getHp() == 0) {
            gameObject.transform.localScale = Vector3.zero;
        }
        // if(Input.GetKeyDown(KeyCode.W)){
        //     isGameStart = 1;
        // }

        if (!GameManager.getGameHalt()){
            if (transform.position.z <= 5) {
                GameManager.instaDeath();
            }
            // Debug.Log(Pointspawn.getObj_stillWaiting());
            if (!UI_Controller.isInMenu() && !UI_Controller.isSelectingCharater()) {
            // if ( isGameStart == 1) {
                if(Input.GetKey(KeyCode.W)){
                    if (transform.position.z < 50) {
                        transform.Translate(0f, 0f, 1f * Time.deltaTime * SpeedController.getSpeed());
                    } 
                }
                else if(Input.GetKey(KeyCode.S)) {
                    transform.Translate(0f, 0f, -2f * Time.deltaTime * SpeedController.getSpeed());
                } else {
                    // transform.Translate(Vector3.back * Time.deltaTime * SpeedController.getSpeed());
                }

                if (!alreadyMove) {                
                    if (Input.GetKeyDown(KeyCode.A)) {
                        moveLeft();
                    } else if (Input.GetKeyDown(KeyCode.D)) {
                        moveRight();
                    }
                } else {
                    if (direction == -1){
                        if (nextPosition.x <= transform.position.x){
                            transform.Translate(-30f * Time.deltaTime, 0f, 0f);
                        } else {
                            // direction = 0;
                            int tmpPos = (int)Math.Round(nextPosition.x, 0);
                            // if (tmpPos % 2 != 0) {
                            //     tmpPos -= 1;
                            // }
                            transform.position = new Vector3(tmpPos - (tmpPos % 2), transform.position.y, transform.position.z);
                            alreadyMove = false;
                            // Debug.Log(transform.position.x);
                        }
                    }
                    else if (direction == 1){
                        if (nextPosition.x >= transform.position.x){
                            transform.Translate(30f * Time.deltaTime, 0f, 0f);
                        } else {
                            // direction = 0;
                            int tmpPos = (int)Math.Round(nextPosition.x, 0);
                            // if (tmpPos % 2 != 0) {
                            //     tmpPos += 1;
                            // }
                            transform.position = new Vector3(tmpPos + (tmpPos % 2), transform.position.y, transform.position.z);
                            alreadyMove = false;
                            // Debug.Log(transform.position.x);
                        }
                    }
                }
            }
            
        }
    }

    void OnTriggerEnter(Collider other) {
        if (!GameManager.getIsInvincible()) {
            //-------------------- OBSTACLE --------------------//
            if (other.gameObject.CompareTag("Obstacle")) {
                other.GetComponent<Collider>().enabled = false;
                if (other.gameObject != null) {
                    Animator anim = other.gameObject.GetComponentInChildren<Animator>();
                    StartCoroutine(animationController.fallOverAnim(other, anim));
                    hitObstacle();
                }
            } else if (other.gameObject.CompareTag("MovableObstacle")) {
                hitObstacle();
            } else if (other.gameObject.CompareTag("Cart")) {
                hitObstacle();
            } else if (other.gameObject.CompareTag("Snowball")) {
                hitObstacle();
            }
        }
        //-------------------- WALL --------------------//
        if (other.gameObject.CompareTag("Wall")) {
            StartCoroutine(cameraShake.Shake(.20f, .4f));
            if (direction == -1) {
                moveRight();
            } else if (direction == 1) {
                moveLeft();
            }
            hitObstacle();
            // GameManager.instaDeath();
        //-------------------- DeathWall --------------------//
        } else if (other.gameObject.CompareTag("DeathWall")) {
            GameManager.instaDeath();
        //-------------------- WATER --------------------//
        } else if (other.gameObject.CompareTag("Water")) {
            transform.Translate(0f, 0f, -0.2f * Time.deltaTime * SpeedController.getSpeed());
        //-------------------- ICE --------------------//
        } else if (other.gameObject.CompareTag("Ice")) {
            transform.Translate(0f, 0f, 0.5f * Time.deltaTime * SpeedController.getSpeed());
        //-------------------- HEALTH --------------------//
        } else if (other.gameObject.CompareTag("Health")) {
            // hitObs = true;
            // Debug.Log("pickup");
            increaseHPAnim();
            GameManager.increaseHP();
            other.GetComponentInChildren<Collider>().enabled = false;
            Animator anim = other.gameObject.GetComponentInChildren<Animator>();
            StartCoroutine(animationController.healthPickup(other, anim));
        //-------------------- SLOW --------------------//
        } else if (other.gameObject.CompareTag("SlowBuff")) {
            if (!GameManager.getIsSlowing()) {
                // Debug.Log("set button active");
                slowButton.SetActive(true);
            }
            GameManager.setSlowBuffPickedUp(true);
            // Debug.Log("Pick up status : " + GameManager.isSlowBuffPickedUp());
            other.GetComponentInChildren<Collider>().enabled = false;
            Animator anim = other.gameObject.GetComponentInChildren<Animator>();
            StartCoroutine(animationController.slowPickup(other, anim));
        }
    }

    void OnTriggerStay(Collider other) {
        if (!GameManager.getIsInvincible()) {
            //-------------------- OBSTACLE --------------------//
            if (other.gameObject.CompareTag("Obstacle")) {
                if (other.gameObject != null) {
                    other.GetComponent<Collider>().enabled = false;
                    Animator anim = other.gameObject.GetComponentInChildren<Animator>();
                    StartCoroutine(animationController.fallOverAnim(other, anim));
                    hitObstacle();
                }
            }
            else if (other.gameObject.CompareTag("Snowball")) {
                hitObstacle();
            }
        }
        if (other.gameObject.CompareTag("Water")) {
            transform.Translate(0f, 0f, -0.2f * Time.deltaTime * SpeedController.getSpeed());
        }
        else if (other.gameObject.CompareTag("Ice")) {
            transform.Translate(0f, 0f, 0.5f * Time.deltaTime * SpeedController.getSpeed());
        }
    }
    
    private void reduecHPAnim() {
        int hp = GameManager.getHp();
        if (hp == 4) {
            StartCoroutine(animationController.breakHeartExtra());
        } else if (hp == 3) {
            StartCoroutine(animationController.breakHeart3());
        } else if (hp == 2) {
            StartCoroutine(animationController.breakHeart2());
        }
    }
    
    private void increaseHPAnim() {
        int hp = GameManager.getHp();
        if (hp == 1) {
            StartCoroutine(animationController.returnHeart2());
        } else if (hp == 2) {
            StartCoroutine(animationController.returnHeart3());
        }
    }

    private void hitObstacle() {
        StartCoroutine(cameraShake.Shake(.15f, .3f));
        reduecHPAnim();
        GameManager.reduceHP();
        if (GameManager.getHp() != 0) {
            StartCoroutine(GameManager.BecomeTempInvincible(2f, 0.1f));
            
        }
    }
    
    private void moveRight() {
        nextPosition = transform.position + placeRight;
        direction = 1;
        alreadyMove = true;
        Animator anim = GetComponentInChildren<Animator>();
        StartCoroutine(animationController.playerTurnRightAnim(gameObject, anim));
    }

    private void moveLeft() {
        nextPosition = transform.position + placeLeft;
        direction = -1;
        alreadyMove = true;
        Animator anim = GetComponentInChildren<Animator>();
        StartCoroutine(animationController.playerTurnLeftAnim(gameObject, anim));
    }

    // private IEnumerator snapPosition() {
    //     if (alreadyMove) {
    //         if (nextPosition.x >= transform.position.x){
    //             transform.Translate(30f * Time.deltaTime, 0f, 0f);
    //         } else {
    //             transform.position = new Vector3( nextPosition.x, transform.position.y, transform.position.z);
    //             alreadyMove = false;
    //         }
    //     }
    // }

}