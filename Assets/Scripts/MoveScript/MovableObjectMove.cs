using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjectMove : MonoBehaviour
{
    private float speed;
    private AnimationController animationController;

    // Start is called before the first frame update
    void Start()
    {
        animationController = FindObjectOfType<AnimationController>();
        // animationController = GameObject.Find("GameManager").GetComponent<AnimationController>();
        // speed = 11;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (Vector3.back * Time.deltaTime * (SpeedController.getSpeed() + 5) );
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Obstacle")) {
            // other.GetComponent<Collider>().enabled = false;
            Animator anim = other.gameObject.GetComponentInChildren<Animator>();
            if (anim != null) {
                StartCoroutine(animationController.fallOverReverseAnim(other, anim));
            }
        } else if (other.gameObject.CompareTag("Cart") || other.gameObject.CompareTag("DeathWall")) {
            Animator anim = gameObject.GetComponentInChildren<Animator>();
            if (anim != null) {
                StartCoroutine(animationController.cowFallOverAnim(gameObject, anim));
            }
            // Destroy(gameObject);
        } else if (other.gameObject.CompareTag("MovableObstacle")) {
            if (other.gameObject != null) {
                Destroy(other.gameObject);
            }
        }
    }
}
