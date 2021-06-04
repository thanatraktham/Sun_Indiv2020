using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheckPass : MonoBehaviour
{
    public WallSpawnPoint wsp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LeftWall")) {
            wsp.wall_stillWaiting = false;
        }
    }
}
