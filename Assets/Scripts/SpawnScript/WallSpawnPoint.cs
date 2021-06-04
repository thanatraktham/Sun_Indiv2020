using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawnPoint : MonoBehaviour
{
    public bool wall_stillWaiting;
    public bool wall_waitForSpawn;

    public GameObject leftStoneWall;
    public GameObject rightStoneWall;
    public GameObject leftSandWall;
    public GameObject rightSandWall;
    public GameObject leftSnowWall;
    public GameObject rightSnowWall;

    // Start is called before the first frame update
    void Start()
    {
        wall_stillWaiting = false;
        wall_waitForSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.getGameHalt()) {
            if (!wall_stillWaiting) 
            {
                //-------------------- STONE WALL --------------------//
                if (GameManager.getMap_status() == 0) {
                    spawnWalls(leftStoneWall, rightStoneWall);
                }
                //-------------------- SAND WALL --------------------//
                else if (GameManager.getMap_status() == 1) {
                    spawnWalls(leftSandWall, rightSandWall);
                }
                //-------------------- SNOW WALL --------------------//
                else if (GameManager.getMap_status() == 2) {
                    spawnWalls(leftSnowWall, rightSnowWall);
                }
            }
        }
    }

    //-------------------- FUNC --------------------//
    private void spawnWalls(GameObject leftWall, GameObject rightWall) {
        GameObject leftWallClone = Instantiate(leftWall) as GameObject;
        GameObject rightWallClone = Instantiate(rightWall) as GameObject;

        leftWallClone.transform.position = transform.position + new Vector3(-10f, 0f, 0f);
        rightWallClone.transform.position = transform.position + new Vector3(10f, 0f, 0f);
        wall_stillWaiting = true;
    }
}
