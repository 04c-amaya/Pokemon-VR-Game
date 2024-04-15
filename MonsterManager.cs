using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class MonsterManager : MonoBehaviour
{
    [HideInInspector]
    public MonsterCombat mosnterCombat;
    [HideInInspector]
    public MonsterStats monsterStats;
[HideInInspector]
    public PlayerController playerController;
    [HideInInspector]
    public PlayerInputManager playerInputManager;
    NavMeshAgent AI;
    public GameObject character;
     [SerializeField] bool AiControl;
   // [HideInInspector]
    public Monster monsterInfo;
    [SerializeField] GameObject userCamera;
    [SerializeField] GameObject uiCamera;

    [Header("Monster Information")]
    [SerializeField] MonsterElement element01;
    [SerializeField] MonsterElement element02;
    public List<AttackElement> strength;
    public List<AttackElement> weakness;
    public List<AttackElement> immunity;

    private void Awake()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        AI = GetComponent<NavMeshAgent>();
        character = GameObject.Find("Character");
        mosnterCombat = GetComponent<MonsterCombat>();
        monsterStats = GetComponent<MonsterStats>();
        playerController = GameObject.Find("PlayerManager").GetComponent<PlayerController>();
    }
    IEnumerator ResetMonster()
    {
        var playerManager = GameObject.Find("PlayerManager").GetComponentInChildren<PlayerController>();
        playerManager.characterMonster.SetActive(false);
        playerManager.characterMonster.GetComponentInChildren<Camera>().enabled = false;
        playerManager.character.GetComponentInChildren<Camera>().enabled = true;

        yield return new WaitForSeconds(1);
        playerManager.characterMonster.SetActive(true);
        playerManager.characterMonster.GetComponentInChildren<Camera>().enabled = true;
        playerManager.character.GetComponentInChildren<Camera>().enabled = false;

    }
    public void ControlMonster()
    {
        playerController.EnableMonster();
        Debug.Log("Player Control Monster");
        GameObject.Find("Character").GetComponentInChildren<Camera>().enabled = false;
        userCamera.SetActive(true);
        uiCamera.SetActive(true);
        AiControl = false;
        // StartCoroutine(ResetMonster());
    }
   public void AIControlMonster()
    {
        playerController.EnableCharacter();
        Debug.Log("AIControl");
        GameObject.Find("Character").GetComponentInChildren<Camera>().enabled = true;
        userCamera.SetActive(false);
        uiCamera.SetActive(false);
        AiControl = true;
    }
    void MonsterElements()
    {
        strength.Clear();
        weakness.Clear();
        immunity.Clear();
        if (element01 == MonsterElement.Normal)
        {
            strength.Add(AttackElement.None);
            weakness.Add(AttackElement.Dark);
            immunity.Add(AttackElement.None);
        }
        else if (element01 == MonsterElement.Fire)
        {
            strength.Add(AttackElement.Spirit);
            weakness.Add(AttackElement.Water);
            immunity.Add(AttackElement.Fire);
        }
        else if (element01 == MonsterElement.Water)
        {
            strength.Add(AttackElement.Fire);
            strength.Add(AttackElement.Earth);
            weakness.Add(AttackElement.thunder);
            weakness.Add(AttackElement.Spirit);
            immunity.Add(AttackElement.None);
        }
        else if (element01 == MonsterElement.Spirit)
        {
            strength.Add(AttackElement.Water);
            weakness.Add(AttackElement.Fire);
            immunity.Add(AttackElement.None);
        }
        else if (element01 == MonsterElement.Light)
        {
            strength.Add(AttackElement.Dark);
            weakness.Add(AttackElement.Spirit);
            immunity.Add(AttackElement.Dark);
        }
        else if (element01 == MonsterElement.Dark)
        {
            strength.Add(AttackElement.Normal);
            weakness.Add(AttackElement.Light);
            immunity.Add(AttackElement.Normal);
        }
        else if (element01 == MonsterElement.thunder)
        {
            strength.Add(AttackElement.Water);
            weakness.Add(AttackElement.thunder);
            weakness.Add(AttackElement.Spirit);
            immunity.Add(AttackElement.None);
        }
        else if (element01 == MonsterElement.Earth)
        {
            strength.Add(AttackElement.thunder);
            weakness.Add(AttackElement.Water);
            immunity.Add(AttackElement.thunder);
        }
        if (element02 == MonsterElement.Normal)
        {
            strength.Add(AttackElement.None);
            weakness.Add(AttackElement.Dark);
            immunity.Add(AttackElement.None);
        }
        else if (element02 == MonsterElement.Fire)
        {
            strength.Add(AttackElement.Spirit);
            weakness.Add(AttackElement.Water);
            immunity.Add(AttackElement.Fire);
        }
        else if (element02 == MonsterElement.Water)
        {
            strength.Add(AttackElement.Fire);
            strength.Add(AttackElement.Earth);
            weakness.Add(AttackElement.thunder);
            weakness.Add(AttackElement.Spirit);
            immunity.Add(AttackElement.None);
        }
        else if (element02 == MonsterElement.Spirit)
        {
            strength.Add(AttackElement.Water);
            weakness.Add(AttackElement.Fire);
            immunity.Add(AttackElement.None);
        }
        else if (element02 == MonsterElement.Light)
        {
            strength.Add(AttackElement.Dark);
            weakness.Add(AttackElement.Spirit);
            immunity.Add(AttackElement.Dark);
        }
        else if (element02 == MonsterElement.Dark)
        {
            strength.Add(AttackElement.Normal);
            weakness.Add(AttackElement.Light);
            immunity.Add(AttackElement.Normal);
        }
        else if (element02 == MonsterElement.thunder)
        {
            strength.Add(AttackElement.Water);
            weakness.Add(AttackElement.thunder);
            weakness.Add(AttackElement.Spirit);
            immunity.Add(AttackElement.None);
        }
        else if (element02 == MonsterElement.Earth)
        {
            strength.Add(AttackElement.thunder);
            weakness.Add(AttackElement.Water);
            immunity.Add(AttackElement.thunder);
        }
    }
    private void Update()
    {
        if (AiControl)
        {
            AI.SetDestination(character.transform.position);
            AI.transform.LookAt(character.transform);
        }

    }
}
