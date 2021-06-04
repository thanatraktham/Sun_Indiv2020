using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator tmp_newHighScoreAnim;
    public Animator tmp_heartAnim1;
    public Animator tmp_heartAnim2;
    public Animator tmp_heartAnim3;
    public Animator tmp_heartAnimExtra;
    public Animator tmp_planeAnim;

    private static Animator heartAnim1;
    private static Animator heartAnim2;
    private static Animator heartAnim3;
    private static Animator heartAnimExtra;
    private static Animator newHighScoreAnim;
    private static Animator planeAnim;

    void Start() {
        newHighScoreAnim = tmp_newHighScoreAnim;
        heartAnim1 = tmp_heartAnim1;
        heartAnim2 = tmp_heartAnim2;
        heartAnim3 = tmp_heartAnim3;
        heartAnimExtra = tmp_heartAnimExtra;
        planeAnim = tmp_planeAnim;
    }

    public IEnumerator showHighScore() {
        GameManager.setNHSText(true);
        newHighScoreAnim.SetTrigger("Show");
        yield return new WaitForSeconds(2f);
        newHighScoreAnim.SetTrigger("Hide");
        yield return new WaitForSeconds(0.5f);
        GameManager.setNHSText(false);
    }

    public IEnumerator healthPickup(Collider other, Animator anim) {
        if (other.gameObject != null) {
            // Debug.Log("here");
            anim.SetTrigger("pickup");
            // Physics.IgnoreCollision(GetComponent<Collider>(), other);
            yield return new WaitForSeconds(.5f);
            // other.GetComponentInChildren<Collider>().enabled = true;
            if (other != null) {
                other.transform.position = new Vector3(0f, 5f, 0f);
            }
            // other.SetActive(false);
            // Destroy(other.gameObject);
        }
    }

    public IEnumerator slowPickup(Collider other, Animator anim) {
        if (other.gameObject != null) {
            // Debug.Log("here");
            anim.SetTrigger("pickup");
            yield return new WaitForSeconds(.5f);
            // other.GetComponentInChildren<Collider>().enabled = true;
            if (other != null) {
                other.transform.position = new Vector3(0f, 5f, 0f);
            }            // Destroy(other.gameObject);
        }
    }

    public IEnumerator breakHeart3() {
        heartAnim3.SetTrigger("heartBreak");
        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator breakHeart2() {
        heartAnim2.SetTrigger("heartBreak");
        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator returnHeart3() {
        heartAnim3.SetTrigger("heartReturn");
        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator returnHeart2() {
        heartAnim2.SetTrigger("heartReturn");
        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator breakHeartExtra() {
        heartAnimExtra.SetTrigger("heartBreakExtra");
        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator ForestToDesert() {
        planeAnim.SetTrigger("toDesert");
        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator DesertToForest() {
        planeAnim.SetTrigger("toForest");
        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator fallOverAnim(Collider other, Animator anim) {
        if (other.gameObject != null) {
            anim.SetTrigger("fallOver");
            // Physics.IgnoreCollision(GetComponent<Collider>(), other);
            // other.GetComponentInChildren<Collider>().enabled = false;
            yield return new WaitForSeconds(0.5f);
            Destroy(other.gameObject);
            // if (other.gameObject != null) {
            // }
            // other.transform.position = new Vector3(0f, 1f, 0f);
        }
    }

    public IEnumerator fallOverReverseAnim(Collider other, Animator anim) {
        if (other.gameObject != null) {
            anim.SetTrigger("fallOverReverse");
            // Physics.IgnoreCollision(GetComponent<Collider>(), other);
            // other.GetComponentInChildren<Collider>().enabled = false;
            yield return new WaitForSeconds(0.5f);
            // other.GetComponentInChildren<Collider>().enabled = true;
            // Debug.Log(other.GetComponentInChildren<Collider>().enabled);
            // Debug.Log("Object that cow hit is Null : " + (other.gameObject != null));
            if (other != null) {
                Destroy(other.gameObject);
                // other.transform.position = new Vector3(0f, 5f, 0f);
            }
            // other.transform.position = new Vector3(0f, 1f, 0f);
        }
    }

    public IEnumerator cowFallOverAnim(GameObject gameObject, Animator anim) {
        if (gameObject != null) {
            anim.SetTrigger("movableFallOver");
            // Physics.IgnoreCollision(GetComponent<Collider>(), other);
            // gameObject.GetComponentInChildren<Collider>().enabled = false;
            yield return new WaitForSeconds(0.5f);
            // Destroy(gameObject);
            gameObject.transform.position = new Vector3(0f, 5f, 0f);
            // if (gameObject != null) {
            // }
            // other.transform.position = new Vector3(0f, 1f, 0f);
        }
    }

    public IEnumerator playerTurnLeftAnim(GameObject obj, Animator anim) {
        // if (obj == null) {
        // }
        // Debug.Log("here");
        anim.SetTrigger("turnLeft");
        yield return new WaitForSeconds(0.15f);
    }

    public IEnumerator playerTurnRightAnim(GameObject obj, Animator anim) {
        // if (obj == null) {
        // }
        // Debug.Log("here");
        anim.SetTrigger("turnRight");
        yield return new WaitForSeconds(0.15f);
    }
}
