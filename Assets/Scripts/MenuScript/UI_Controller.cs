using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    public static bool inMenu;
    public static bool selectingCharacter;

    public Animator Anim;
    public GameObject pauseMenuUI;
    public GameObject gameUI;
    public GameObject pauseButton;
    public GameObject slowButton;
    public GameObject slowImage;
    public GameObject endGameUI;
    public GameObject menuUI;

    void Start() {
        inMenu = true;
        selectingCharacter = false;
        pauseButton.SetActive(true);
        // slowButton.SetActive(false);
    }

    void Update() {
        // Debug.Log(inMenu);ฟ
        if (Input.GetKeyDown(KeyCode.W) && inMenu && !selectingCharacter) {
            Debug.Log("resume");
            inMenu = false;
            Resume();
        }
        if (GameManager.isSlowBuff()) {
            slowImage.SetActive(true);
            Animator anim = slowImage.GetComponentInChildren<Animator>();
            StartCoroutine(slowImageAnim(anim));
            StartCoroutine(slowmotion());
        }
        if (GameManager.getHp() == 0 && GameManager.getGameHalt()) {
            // Time.timeScale = 0f;
            GameManager.setGameHalt(true);
            endGameUI.SetActive(true);
            gameUI.SetActive(false);
        }
    }

    private IEnumerator slowmotion() {
        // Debug.Log("start slow");
        GameManager.setSlowBuff(false);
        GameManager.setSlowing(true);
        GameManager.setSlowBuffPickedUp(false);
        slowButton.SetActive(false);
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(3f);
        Time.timeScale = 1f;
        slowImage.SetActive(false);
        GameManager.setSlowing(false);
        if (GameManager.isSlowBuffPickedUp()) {
            slowButton.SetActive(true);
        }
    }

    public void startSlowMotion() {
        GameManager.setSlowBuff(true);
    }

    public IEnumerator slowImageAnim(Animator anim) {
        anim.SetTrigger("slow");
        yield return new WaitForSeconds(3f);
        
    }

    public void Resume() {
        menuUI.SetActive(false);
        gameUI.SetActive(true);
        inMenu = false;
        Pointspawn.setObj_stillWaiting(false);
        GameManager.setGameHalt(false);
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }

    public void Pause() {
        Time.timeScale = 0f;
        gameUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        GameManager.setGameHalt(true);
        Debug.Log(GameManager.getGameHalt());
    }

    public void Restart() {
        Time.timeScale = 1f;
        GameManager.setGameHalt(false);
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        GameManager.setGameHalt(false);
        SceneManager.LoadScene("SampleScene");
        // Debug.Log("Loading Menu From EndGame...");
    }

    public void QuitGame() {
        // Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public static bool isInMenu() {
        return inMenu;
    }

    public static bool isSelectingCharater() {
        return selectingCharacter;
    }

    public static void setInmenuTrue() {
        inMenu = true;
    }

    public static void setInMenuFalse() {
        inMenu = false;
    }

    public static void setSelectingCharacterTrue() {
        selectingCharacter = true;
    }

    public static void setSelectingCharacterFalse() {
        selectingCharacter = false;
    }
}
