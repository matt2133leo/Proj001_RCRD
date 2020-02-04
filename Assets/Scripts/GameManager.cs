using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("對話視窗")]
    public GameObject DialogueUI;

    [Header("對話判定")]
    public bool player_dialogue = false;

    [Header("NPC資料")]
    public BaseNPC NPCdata;

    [Header("Player資料")]
    public BasePlayerManager playerdata;

    private void Start()
    {
        NPCdata = GameObject.FindWithTag("NPC").GetComponent<BaseNPC>();
        playerdata = GameObject.FindWithTag("主角").GetComponent<BasePlayerManager>();
        DialogueUI = GameObject.FindWithTag("UI");
        DialogueUI.SetActive(false);

    }

    private void Update()
    {
        if (NPCdata.NPCdialogue == true) dialogue();
    }

    /// <summary>
    /// 角色對話
    /// </summary>
    public void dialogue()
    {
        if (Input.GetKeyDown(KeyCode.Space) && player_dialogue == false)
        {
            player_dialogue = true;
            DialogueUI.SetActive(player_dialogue);
            playerdata.move_ani_bool = false;
           // playerdata.GetComponent<BasePlayerManager>().enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && player_dialogue == true)
        {
            player_dialogue = false;
            DialogueUI.SetActive(player_dialogue);
            playerdata.move_ani_bool = true;
           // playerdata.GetComponent<BasePlayerManager>().enabled = true;
        }

    }
}
