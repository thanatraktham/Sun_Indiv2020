using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Animator;

public class Pointspawn : MonoBehaviour
{
    //-------------------- GENERAL --------------------//
    public GameObject hp;
    public GameObject slowBuff;
    //-------------------- FOREST --------------------//
    public GameObject cow;
    public GameObject sideRail;
    public GameObject stone;
    public GameObject tree;
    public GameObject tree_n_StoneSet1;
    public GameObject tree_n_StoneSet2;
    public GameObject tree_n_StoneSet3;
    public GameObject tree_n_StoneSet4;
    public GameObject tree_n_StoneSet5;
    public GameObject waterSet1;
    public GameObject waterSet2;
    //-------------------- DESERT --------------------//
    public GameObject bigSandStone;
    public GameObject boulder;
    public GameObject cactus;
    public GameObject deadtree;
    public GameObject deadtree_n_StoneSet1;
    public GameObject deadtree_n_StoneSet2;
    public GameObject deadtree_n_StoneSet3;
    public GameObject deadtree_n_StoneSet4;
    public GameObject deadtree_n_StoneSet5;
    public GameObject deadtree_n_StoneSet6;
    public GameObject oasisSet1;
    public GameObject oasisSet2;
    public GameObject sandStone;
    public GameObject scorpion;
    //-------------------- SNOW --------------------//
    public GameObject iceSet1;
    public GameObject iceSet2;
    public GameObject iceSet3;
    public GameObject snowSet1;
    public GameObject snowSet2;
    public GameObject snowSet3;
    public GameObject snowSet4;
    public GameObject pineTree;
    public GameObject santa;
    public GameObject snowman;
    public GameObject snowStone;

    private static bool obj_stillWaiting;
    private static bool obj_waitForSpawn;
    private static bool treeComboStarted;

    private float speed;
    private float waitTimeFactor;
    private int random;
    private int randomTreeSpawnType;
    private int set;
    private int shortOrLongSet; //short = 0 , Long = 1

    // Start is called before the first frame update
    void Start()
    {
        obj_stillWaiting = true;
        obj_waitForSpawn = false;
        waitTimeFactor = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.getGameHalt()) {

            // Debug.Log("random = " + random +" ,ratespawn + " + increaseRateSpawn);
            random = Random.Range(231, 303 );
            // random = Random.Range(increaseRateSpawn  , 239);

            //-----------check Time-------------//
            speed = SpeedController.getSpeed();
            waitTimeFactor = 4f/speed;
 
            if(obj_waitForSpawn){
                // Debug.Log("spawned");
                if(set == 1){
                    if(shortOrLongSet == 1){
                        StartCoroutine(wait(10.8f * waitTimeFactor));
                    }else{
                        StartCoroutine(wait(4f * waitTimeFactor));

                    }
                }
                else{
                    StartCoroutine(wait(1.5f * waitTimeFactor));
                }
            } else if (!obj_stillWaiting) {
                
                //-----------------------------------------------------//
                //-------------------- FOREST PART --------------------//
                //-----------------------------------------------------//
                if (GameManager.getMap_status() == 0) {
                    
                    //-------------------- EMPTY --------------------//
                    if( random <= 240){
                        obj_waitForSpawn = true;
                        return;
                    }
                    //-------------------- TREE --------------------//
                    else if(random > 275){
                        GameObject treeClone1 =  Instantiate(tree) as GameObject;
                        GameObject treeClone2 =  Instantiate(tree) as GameObject;
                        
                        int treePos1 = Random.Range(-3,4) * 2;
                        int treePos2 = Random.Range(-3,4) * 2;
                        if(treePos1 == treePos2){
                            treePos2 = changePosition(treePos1, treePos2);
                        }    
                        
                        treeClone1.transform.position = transform.position + new Vector3(treePos1, 0f, 0f);
                        treeClone2.transform.position = transform.position + new Vector3(treePos2, 0f, 0f);
                        
                        set = 0;
                        obj_waitForSpawn = true;
                
                    }
                    //-------------------- STONE --------------------//
                    else if( random > 270 ) {
                        GameObject stoneClone1 = Instantiate(stone) as GameObject;
                        GameObject stoneClone2 = Instantiate(stone) as GameObject;

                        int stonePos1 = Random.Range(-3,4) * 2;
                        int stonePos2 = Random.Range(-3,4) * 2;
                        if(stonePos1 == stonePos2){
                            stonePos2 = changePosition(stonePos1, stonePos2);
                        }
                        
                        stoneClone1.transform.position = transform.position + new Vector3(stonePos1, 0f, 0f);
                        stoneClone2.transform.position = transform.position + new Vector3(stonePos2, 0f, 0f);
                        
                        set = 0;
                        obj_waitForSpawn = true;
                    } 
                    //--------------- TREE & STONE SET ----------------//
                    else if (random > 265){
                         int randomset = Random.Range(1,6);
                        //int randomset = 5;
                        if(randomset == 1){
                            GameObject tree_n_StoneSet1Clone = Instantiate(tree_n_StoneSet1) as GameObject;
                            tree_n_StoneSet1Clone.transform.position = transform.position + new Vector3(0f, 0f, 0f);
                            shortOrLongSet = 0;
                        }
                        else if(randomset == 2){
                            GameObject tree_n_StoneSet2Clone = Instantiate(tree_n_StoneSet2) as GameObject;
                            tree_n_StoneSet2Clone.transform.position = transform.position + new Vector3(0f, 0f, 0f);
                            shortOrLongSet = 0;
                        }
                        else if(randomset == 3){
                            GameObject tree_n_StoneSet3Clone = Instantiate(tree_n_StoneSet3) as GameObject;
                            tree_n_StoneSet3Clone.transform.position = transform.position + new Vector3(0f, 0f, 0f);
                            shortOrLongSet = 0;
                        }
                        else if(randomset == 4){
                            GameObject tree_n_StoneSet4Clone = Instantiate(tree_n_StoneSet4) as GameObject;
                            tree_n_StoneSet4Clone.transform.position = transform.position + new Vector3(0f, 0f, 0f);
                            shortOrLongSet = 0;
                        }
                        else if(randomset == 5){
                            GameObject tree_n_StoneSet5Clone = Instantiate(tree_n_StoneSet5) as GameObject;
                            tree_n_StoneSet5Clone.transform.position = transform.position + new Vector3(0f, 0f, 0f);
                            shortOrLongSet = 1;
                        }
                        set = 1;
                        obj_waitForSpawn = true;
                    }
                    //--------------- TREE & STONE ----------------//
                    else if (random > 250){
                        spawnTreeStoneType(tree, stone, 0f);
                    }
                    //-------------------- WATER --------------------//
                    else if(random > 245){
                    // else if (random > 50) {
                        int randomWater;
                        randomWater = Random.Range(1,3);
                        if(randomWater == 1){
                            GameObject waterSet1Clone = Instantiate(waterSet1) as GameObject;
                            waterSet1Clone.transform.position = transform.position + new Vector3(0f, 0f, 0f);
                            shortOrLongSet = 0;
                        }
                        else if(randomWater == 2){
                            GameObject waterSet2Clone = Instantiate(waterSet2) as GameObject;
                            waterSet2Clone.transform.position = transform.position + new Vector3(0f, 0f, 0f);
                            shortOrLongSet = 0;
                        }
                        set = 1;
                        obj_waitForSpawn = true;
                    }
                    //-------------------- COW --------------------//
                    else if (random > 240) {
                        spawnGeneralType(cow, 1.5f);
                    }
                    
                    //-------------------- CART --------------------//
                    else if(random > 235){
                        spawnCartType(sideRail, 0f);
                    }
                    
                }
                //-----------------------------------------------------//
                //-------------------- DESERT PART --------------------//
                //-----------------------------------------------------//
                else if (GameManager.getMap_status() == 1) {

                    //-------------------- EMPTY ----------------------//
                    if(random < 230){
                        return;
                    }
                    //-------------------- CACTUS --------------------//
                    else if (random > 280) {
                        GameObject cactusClone1 =  Instantiate(cactus) as GameObject;
                        GameObject cactusClone2 =  Instantiate(cactus) as GameObject;

                        int cactusPos1 = Random.Range(-3,4) * 2;
                        int cactusPos2 = Random.Range(-3,4) * 2;

                        if(cactusPos1 == cactusPos2){
                            cactusPos2 = changePosition(cactusPos1, cactusPos2);
                        }

                        cactusClone1.transform.position = transform.position + new Vector3(cactusPos1, 0f, 0f);
                        cactusClone2.transform.position = transform.position + new Vector3(cactusPos2, 0f, 0f);
                        
                        set = 0;
                        obj_waitForSpawn = true;
                    }
                    //-------------------- DEADTREE --------------------//
                    else if(random > 275) {
                        GameObject deadTreeClone1 =  Instantiate(deadtree) as GameObject;
                        GameObject deadTreeClone2 =  Instantiate(deadtree) as GameObject;

                        int deadtreePos1 = Random.Range(-3,4) * 2;
                        int deadtreePos2 = Random.Range(-3,4) * 2;
                        if(deadtreePos1 == deadtreePos2){
                            deadtreePos2 = changePosition(deadtreePos1, deadtreePos2);
                        }    
                        
                        deadTreeClone1.transform.position = transform.position + new Vector3(deadtreePos1, 0f, 0f);
                        deadTreeClone2.transform.position = transform.position + new Vector3(deadtreePos2, 0f, 0f);
                        
                        set = 0;
                        obj_waitForSpawn = true;
                    }
                    
                    //-------------------- SANDSTONE --------------------//
                    else if(random > 270) {
                        GameObject SandStoneClone1 = Instantiate(sandStone) as GameObject;
                        GameObject SandStoneClone2 = Instantiate(sandStone) as GameObject;
                        
                        int sandstonePos1 = Random.Range(-3,4) * 2;
                        int sandstonePos2 = Random.Range(-3,4) * 2;
                        if(sandstonePos1 == sandstonePos2){
                            sandstonePos2 = changePosition(sandstonePos1, sandstonePos2);
                        }

                        SandStoneClone1.transform.position = transform.position + new Vector3(sandstonePos1, 0f, 0f);
                        SandStoneClone2.transform.position = transform.position + new Vector3(sandstonePos2, 0f, 0f);
                        
                        set = 0;
                        obj_waitForSpawn = true;
                    }
                    //-------------------- SANDSTONE & TREE SET --------------------//
                    else if (random > 265){
                        int randomset = Random.Range(1,7);

                        if(randomset == 1){
                            GameObject deadtree_n_StoneSet1Clone = Instantiate(deadtree_n_StoneSet1) as GameObject;
                            deadtree_n_StoneSet1Clone.transform.position = transform.position + new Vector3(0f, 0f, 0f);
                            shortOrLongSet = 0;
                        }
                        else if(randomset == 2){
                            GameObject deadtree_n_StoneSet2Clone = Instantiate(deadtree_n_StoneSet2) as GameObject;
                            deadtree_n_StoneSet2Clone.transform.position = transform.position + new Vector3(0f, 0f, 0f);
                            shortOrLongSet = 0;
                        }
                        else if(randomset == 3){
                            GameObject deadtree_n_StoneSet3Clone = Instantiate(deadtree_n_StoneSet3) as GameObject;
                            deadtree_n_StoneSet3Clone.transform.position = transform.position + new Vector3(0f, 0f, 0f);
                            shortOrLongSet = 0;
                        }
                        else if(randomset == 4){
                            GameObject deadtree_n_StoneSet4Clone = Instantiate(deadtree_n_StoneSet4) as GameObject;
                            deadtree_n_StoneSet4Clone.transform.position = transform.position + new Vector3(0f, 0f, 0f);
                            shortOrLongSet = 0;
                        }
                        else if(randomset == 5){
                            GameObject deadtree_n_StoneSet5Clone = Instantiate(deadtree_n_StoneSet5) as GameObject;
                            deadtree_n_StoneSet5Clone.transform.position = transform.position + new Vector3(0f, 0f, 0f);
                            shortOrLongSet = 1;
                        }
                        else if(randomset == 6){
                            GameObject deadtree_n_StoneSet5Clone = Instantiate(deadtree_n_StoneSet6) as GameObject;
                            deadtree_n_StoneSet5Clone.transform.position = transform.position + new Vector3(0f, 0f, 0f);
                            shortOrLongSet = 1;
                        }

                        set = 1;
                        obj_waitForSpawn = true;
                    }
                    //---------------  STONE & DEADTREE ----------------//
                    else if (random > 255){
                        spawnTreeStoneType(deadtree, sandStone, 0f);
                    }

                    //--------------- OASIS SET ----------------//
                    else if (random > 250){
                        int randomset = Random.Range(1,3);
                        // int randomset = 5;
                        if(randomset == 1){
                            GameObject oasisSet1Clone1 = Instantiate(oasisSet1) as GameObject;
                            oasisSet1Clone1.transform.position = transform.position + new Vector3(0f, 0f, 0f);
                            shortOrLongSet = 0;
                        }
                        else if(randomset == 2){
                            GameObject oasisSet1Clone2 = Instantiate(oasisSet2) as GameObject;
                            oasisSet1Clone2.transform.position = transform.position + new Vector3(0f, 0f, 0f);
                            shortOrLongSet = 0;
                        }
                        obj_waitForSpawn = true;
                        set = 1;
                    }
                    //-------------------- BIG SAND STONE --------------------//
                    else if (random > 245) {
                        GameObject bigSandStoneClone = Instantiate(bigSandStone) as GameObject;
                        int ranStone = Random.Range(-2,3) * 2;
                        bigSandStoneClone.transform.position = transform.position + new Vector3(ranStone, 0f, 0f);
                        
                        obj_waitForSpawn = true;
                        shortOrLongSet = 0;
                        set = 1;
                    }
                    //-------------------- BOULDER --------------------//
                    else if (random > 240) {
                        spawnGeneralType(boulder, 1f);
                    }
                    //-------------------- SCORPION --------------------//
                    else if(random > 235){
                        spawnCartType(scorpion, 0.5f);
                    }
                }
                
                //-----------------------------------------------------//
                //-------------------- SNOW PART ----------------------//
                //-----------------------------------------------------//

                else if (GameManager.getMap_status() == 2) {

                    //-------------------- PINE TREE --------------------//
                    if (random > 275) {
                        GameObject pineTreeClone1 =  Instantiate(pineTree) as GameObject;
                        GameObject pineTreeClone2 =  Instantiate(pineTree) as GameObject;

                        int pinetreePos1 = Random.Range(-3,4) * 2;
                        int pinetreePos2 = Random.Range(-3,4) * 2;
                        if(pinetreePos1 == pinetreePos2){
                            pinetreePos2 = changePosition(pinetreePos1, pinetreePos2);
                        }

                        pineTreeClone1.transform.position = transform.position + new Vector3( pinetreePos1, 0f, 0f);
                        pineTreeClone2.transform.position = transform.position + new Vector3( pinetreePos2, 0f, 0f);

                        obj_waitForSpawn = true;
                        set = 0;
                    }   
                    //-------------------- SNOWSTONE --------------------//
                    else if (random > 265) {
                        GameObject snowstoneClone1 = Instantiate(snowStone) as GameObject;
                        GameObject snowstoneClone2 = Instantiate(snowStone) as GameObject;

                        int snowstonePos1 = Random.Range(-3,4) * 2;
                        int snowstonePos2 = Random.Range(-3,4) * 2;
                        if(snowstonePos1 == snowstonePos2){
                            snowstonePos2 = changePosition(snowstonePos1, snowstonePos2);
                        }

                        snowstoneClone1.transform.position = transform.position + new Vector3(snowstonePos1, 0f, 0f);
                        snowstoneClone2.transform.position = transform.position + new Vector3(snowstonePos2, 0f, 0f);
                        
                        set = 0;
                        obj_waitForSpawn = true;
                    }                 
                    //-------------------- ICESET --------------------//
                    else if (random > 260) {
                        int ranIceSet = Random.Range(1,4);
                        if( ranIceSet == 1){
                            GameObject iceSetClone1 = Instantiate(iceSet1) as GameObject;
                            iceSetClone1.transform.position = transform.position + new Vector3(0f, 0f, 12f);
                            shortOrLongSet = 1;
                        }
                        else if ( ranIceSet == 2 ){
                            GameObject iceSetClone2 = Instantiate(iceSet2) as GameObject;
                            iceSetClone2.transform.position = transform.position + new Vector3(0f, 0f, 12f);
                            shortOrLongSet = 1;
                        }
                        else if ( ranIceSet == 3 ){
                            GameObject iceSetClone3 = Instantiate(iceSet3) as GameObject;
                            iceSetClone3.transform.position = transform.position + new Vector3(0f, 0f, 12f);
                            shortOrLongSet = 1;
                        }

                        obj_waitForSpawn = true;
                        set = 1;
                    }
                    //-------------------- SNOWSET --------------------//
                    else if(random > 255){
                        int ranSnowSet = Random.Range(1,5);
                        if( ranSnowSet == 1){
                            GameObject snowSetClone1 = Instantiate(snowSet1) as GameObject;
                            snowSetClone1.transform.position = transform.position + new Vector3(0f, 0f, 0f);
                            shortOrLongSet = 0;
                        }else if(ranSnowSet == 2){
                            GameObject snowSetClone2 = Instantiate(snowSet2) as GameObject;
                            snowSetClone2.transform.position = transform.position + new Vector3(0f, 0f, 0f);
                            shortOrLongSet = 0;
                        }else if(ranSnowSet == 3){
                            GameObject snowSetClone3 = Instantiate(snowSet3) as GameObject;
                            snowSetClone3.transform.position = transform.position + new Vector3(0f, 0f, 0f);
                            shortOrLongSet = 0;
                        }else if(ranSnowSet == 4){
                            GameObject snowSetClone4 = Instantiate(snowSet4) as GameObject;
                            snowSetClone4.transform.position = transform.position + new Vector3(0f, 0f, 0f);
                            shortOrLongSet = 0;
                        }
                        obj_waitForSpawn = true;
                        set = 1;
                    }
                    //-------------------- PINETREE AND SNOWSTONE --------------------//
                    else if (random > 245) {
                        spawnTreeStoneType(pineTree, snowStone, 0f);
                    }
                    //-------------------- SANTA --------------------//
                    else if(random > 240){
                        spawnCartType(santa, 0.5f);
                    }
                    //-------------------- COW --------------------//
                    else if (random > 245) {
                        spawnGeneralType(cow, 1.5f);
                    }
                    
                    //-------------------- SNOW MAN --------------------//
                    else if (random > 235) {
                        GameObject snowmanClone = Instantiate(snowman) as GameObject;
                        int ransnowmanPos = Random.Range(-3,4) * 2;
                        snowmanClone.transform.position = transform.position + new Vector3(ransnowmanPos, 0f, 0f);
                        set = 0;
                        obj_waitForSpawn = true;
                    }

                }
                
                //-------------------- HP BUFF --------------------//
                if(random == 301){
                    spawnGeneralType(hp, 1f);
                }
                
                //-------------------- SLOW BUFF --------------------//
                else if(random == 302){
                    spawnGeneralType(slowBuff, 1f);
                }
            }
        }
    }

    //-----------------------------------------------------//
    //--------------------- FUNCTION ----------------------//
    //-----------------------------------------------------//

    private IEnumerator wait(float t) {
        obj_waitForSpawn = false;
        obj_stillWaiting = true;
        //Debug.Log("wait for : " + t);
        yield return new WaitForSeconds(t);
        obj_stillWaiting = false;
    }

    private int changePosition(int pos1, int pos2){
        int ranLeftOrRight = Random.Range(0,2);
        if( ranLeftOrRight == 0){
            pos2 = pos2 + Random.Range(1,4) * 2;
        }else{
            pos2 = pos2 - Random.Range(1,4) * 2;
        }
        if( pos2 > 6 ){
            pos2 = 6;
            if( pos2 == pos1){
                pos2 = Random.Range(-3,3) * 2; 
            }    
        }
        else if( pos2 < -6){
            pos2 = -6;
            if( pos2 == pos1){
                pos2 = Random.Range(-2,4) * 2; 
            } 
        }
        return pos2;
    }

    private void spawnCartType(GameObject obj, float hight) {
        GameObject obj_clone = Instantiate(obj) as GameObject;                        
        obj_clone.transform.position = transform.position + new Vector3(0f , hight , 0f);
        set = 0;
        obj_waitForSpawn = true;
    }

    private void spawnGeneralType(GameObject obj, float hight) {
        GameObject obj_clone = Instantiate(obj) as GameObject;
        int ran_position = 2*Random.Range(-3,4);
        obj_clone.transform.position = transform.position + new Vector3(ran_position, hight, 0f);
        obj_waitForSpawn = true;
        set = 0;
    }

    private void spawnTreeStoneType(GameObject obj_tree, GameObject obj_stone, float hight) {
        int randomTreeOrStone = Random.Range(1,3);
        int ranpos1, ranpos2, ranpos3;
        ranpos1 = Random.Range(-3,4) * 2;
        ranpos2 = Random.Range(-3,4) * 2;
        ranpos3 = Random.Range(-3,4) * 2;

        if(ranpos1 == ranpos2 ){
            ranpos2 = changePosition(ranpos1, ranpos2);
        }
        if(ranpos2 == ranpos3){
            ranpos3 = changePosition(ranpos2, ranpos3);
        }
        if(ranpos1 == ranpos3){
            ranpos3 = changePosition(ranpos1, ranpos3);
        }
        if(ranpos2 == ranpos3){
            randomTreeOrStone = 3;
        }

        GameObject treeClone1 = Instantiate(obj_tree) as GameObject;
        GameObject stoneClone1 = Instantiate(obj_stone) as GameObject;
        //--------------- TREE 2 & STONE 1 ----------------//
        if( randomTreeOrStone == 1){
            GameObject treeClone2 = Instantiate(obj_tree) as GameObject;

            treeClone1.transform.position = transform.position + new Vector3(ranpos1, hight, 0f);
            treeClone2.transform.position = transform.position + new Vector3(ranpos2, hight, 0f);
            stoneClone1.transform.position = transform.position + new Vector3(ranpos3, hight, 0f);
        //--------------- TREE 1 & STONE 2 ----------------//
        }else if( randomTreeOrStone == 2){
            GameObject stoneClone2 = Instantiate(obj_stone) as GameObject;

            treeClone1.transform.position = transform.position + new Vector3(ranpos1, hight, 0f);
            stoneClone1.transform.position = transform.position + new Vector3(ranpos2, hight, 0f);
            stoneClone2.transform.position = transform.position + new Vector3(ranpos3, hight, 0f);
        }else{
            treeClone1.transform.position = transform.position + new Vector3(ranpos1, hight, 0f);
            stoneClone1.transform.position = transform.position + new Vector3(ranpos2, hight, 0f);
        }
        obj_waitForSpawn = true;
        set = 0;
    }

    public static void setObj_stillWaiting(bool boolean) {
        obj_stillWaiting = boolean;
    }

    public static bool getObj_stillWaiting() {
        return obj_stillWaiting;
    }

}
