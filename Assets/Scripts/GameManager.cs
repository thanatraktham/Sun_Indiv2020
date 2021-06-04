using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static bool gameHalt;
    public static bool isInvincible = false;
    public static GameObject model;

    public AnimationController animationController;
    public GameObject tmpModel;
    public Text newHighscoreTextTmp;
    public Text scoreText;
    public Text showHighScoreText;
    public Text showScoreText;

    private static bool notFirstTime;
    private static bool slow;
    private static bool slowBuffPickedUp;
    private static bool isSlowing;
    private static bool gameHasEnded;
    private static bool mapHasChanged;
    private static bool scoreIncreasing;
    // private static float distance;
    private static int hp;
    private static int highScore;
    private static int map_status;
    private static int maxHP;
    private static int score;
    private static Text newHighscoreText;

    private bool pastHighScore;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        gameHalt = false;
        gameHasEnded = false;
        maxHP = 3;
        hp = maxHP + 1;
        isInvincible = false;
        isSlowing = false;
        mapHasChanged = true;
        map_status = 0;
        model = tmpModel;
        newHighscoreText = newHighscoreTextTmp;
        newHighscoreText.text = "Yay!\nNew High Score";
        pastHighScore = false;
        score = 0;
        scoreIncreasing = false;
        scoreText.text = score + "  M";
        slow = false;
        slowBuffPickedUp = false;
    }

    // Update is called once per frame
    void Update() {
        if( gameHasEnded ){
            gameHasEnded = true;
            gameHalt = true;
            notFirstTime = true;
            scoreText.enabled = false;
            SpeedController.setSpeed(0);
            showHighScoreText.text = "HIGH SCORE : " + highScore;
            showScoreText.text = "" + score;
        } else if (!gameHalt){
            checkMap_status();
            if (!scoreIncreasing && !UI_Controller.inMenu) {
                StartCoroutine(increaseScore());
            }
        }
    }

    //-------------------- GETTER / SETTER --------------------//
    public static bool getGameHalt() {
        return gameHalt;
    }

    public static void setGameHalt(bool boolean) {
        gameHalt = boolean;
    }

    public static bool getGameHasEnded() {
        return gameHasEnded;
    }

    public static int getHp() {
        return hp;
    }

    public static void setHp(int newHp) {
        hp = newHp;
    }

    public static bool isSlowBuff() {
        return slow;
    }

    public static void setSlowBuff(bool boolean) {
        slow = boolean;
    }

    public static bool isSlowBuffPickedUp() {
        return slowBuffPickedUp;
    }

    public static void setSlowBuffPickedUp(bool boolean) {
        slowBuffPickedUp = boolean;
    }

    public static bool getIsSlowing() {
        return isSlowing;
    }

    public static void setSlowing(bool boolean) {
        isSlowing = boolean;
    }

    public static bool getIsInvincible() {
        return isInvincible;
    }

    public static void setIsInvincible(bool boolean) {
        isInvincible = boolean;
    }

    public static int getScore() {
        return score;
    }

    public static void setMap_status(int status) {
        map_status = status;
    }

    public static int getMap_status() {
        return map_status;
    }

    public static void setNHSText(bool boolean) {
        newHighscoreText.enabled = boolean;
    }

    //-------------------- FUNC --------------------//
    public void checkMap_status() {
        if (!mapHasChanged && score % 600 == 0) { // 20 40 60 ...
            Debug.Log("To Forest..." + score);
            mapHasChanged = true;
            map_status = 0;
            // StartCoroutine(animationController.DesertToForest());
        } else if (!mapHasChanged && score % 400 == 0) {
            Debug.Log("To Desert..." + score);
            mapHasChanged = true;
            map_status = 1;
            // StartCoroutine(animationController.ForestToDesert());
        } else if (!mapHasChanged && score % 200 == 0){ // 10 30 50 ...
            Debug.Log("To Snow..." + score);
            mapHasChanged = true;
            map_status = 2;
        } else if (score % 200 != 0) {
            mapHasChanged = false;
        }
        // map_status = 2;
    }

    public static IEnumerator BecomeTempInvincible(float IFrameDuration, float blinkDuration) {
        // if (isInvincible) {
        //     yield return new WaitUntil(() => isInvincible == false);
        // }
        // Debug.Log("Invinc Start");
        int curHp = hp;
        isInvincible = true;

        for (float i = 0; i < IFrameDuration; i += blinkDuration) {
            // Debug.Log("GameHasEnd = " + gameHasEnded);
            if (curHp != hp) {
                break;
            }
            Vector3 tmpPos = model.transform.position;
            if (model.transform.localScale == Vector3.zero) {
                ScaleModelTo(new Vector3(1f, 1f, 1f));
            } else {
                ScaleModelTo(Vector3.zero);
            }
            model.transform.position = tmpPos;
            yield return new WaitForSeconds(blinkDuration);
        }

        // Debug.Log("Invinc End");
        isInvincible = false;
        ScaleModelTo(new Vector3(1f, 1f, 1f));
    }

    public static void ScaleModelTo(Vector3 scale) {
        model.transform.localScale = scale;
    }

    public static void reduceHP() {
        if ( hp > 1 ) {
            hp--;
            // Debug.Log(hp);
        } else {
            instaDeath();
        }
    }

    public static void instaDeath() {
        hp = 0;
        gameHasEnded = true;
        Debug.Log("asdf");
        AudioManager.instance.Stop("MainTheme");
        AudioManager.instance.Play("Fing");
    }

    public static void increaseHP() {
        if (0 < hp && hp < maxHP) {
            hp++;
        }
    }

    private IEnumerator increaseScore() {
            scoreIncreasing = true;
            // float tmp = (10 - SpeedController.getSpeed()) / 12;
            // if (tmp < 0.2f) {
            //     tmp = 0.2f;
            //}
            float tmp = 2f/SpeedController.getSpeed();
            //  Debug.Log("TMP= " + tmp);
            yield return new WaitForSeconds(tmp);
            if (!gameHalt) {
                score++;
                scoreText.text = score + "  M";
                if (score > highScore) {
                    if (!pastHighScore && notFirstTime) {
                        pastHighScore = true;
                        StartCoroutine(animationController.showHighScore());
                    }
                    highScore = score;
                }
            }
            scoreIncreasing = false;
    }
    
}
