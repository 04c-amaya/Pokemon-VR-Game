using Cinemachine.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Scene mainScene;
    bool battleSceneLoaed;
    public GameObject target1Obj;
    public GameObject target2Obj;
    public BattleScene battleScene;
    public Vector3 target1Position;
    public Vector3 target2Position;
    [HideInInspector]
    public PlayerController playerController;
    private void Awake()
    {
        playerController = GameObject.Find("PlayerManager").GetComponent<PlayerController>();
    }
    public void StartBattle(GameObject target1, GameObject target2)
    {
        target1Obj = target1;
        target2Obj = target2;
        if (playerController.isInBattle == false)
        {
            mainScene = SceneManager.GetActiveScene();
            target1Position = target1.transform.position;
            target2Position = target2.transform.position;

            target2.GetComponent<NavMeshAgent>().enabled = false;
            target2.transform.LookAt(target1.transform);
            if(battleSceneLoaed == false)
            {
                SceneManager.LoadSceneAsync(battleScene.scene, LoadSceneMode.Additive);
                battleSceneLoaed = true;
            }
            battleScene.target1BattlePosition = GameObject.Find("Target1BattlePosition").transform;
            battleScene.target2BattlePosition = GameObject.Find("Target2BattlePosition").transform;



            target1.transform.position = battleScene.target1BattlePosition.position;
            target2.transform.position = battleScene.target2BattlePosition.position;
            playerController.isInBattle = true;
            
        }
        
    }
    public void EndBattle()
    {
        playerController.EnableCharacter();
        Destroy(playerController.characterMonster);
        playerController.character.GetComponentInChildren<Camera>().enabled = true;
        playerController.isControllingCharacter = true;
        playerController.isControllingMonster = false;
        target1Obj.transform.position = target1Position;
        target2Obj.transform.position = target2Position;
        SceneManager.UnloadSceneAsync(battleScene.scene);
    }


}
