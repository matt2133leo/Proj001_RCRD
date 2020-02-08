using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [Header("UI控制器")]
    public UIManager UIcontroller;

    [Header("對話視窗")]
    public GameObject DialogueUI;

    [Header("NPC資料")]
    public BaseNPC NPCdata;

    [Header("Player資料")]
    public BasePlayerManager playerdata;

    private void Start()
    {
        UIcontroller = FindObjectOfType<UIManager>();
        NPCdata = GameObject.FindWithTag("NPC").GetComponent<BaseNPC>();
        playerdata = GameObject.FindWithTag("主角").GetComponent<BasePlayerManager>();
        DialogueUI = GameObject.FindWithTag("UI").transform.Find("對話視窗").gameObject;
        DialogueUI.SetActive(UIcontroller.Dia_status);
    }

    private void Update()
    {
        if (NPCdata.Playerisclose == true) dialogue();
    }

    /// <summary>
    /// 角色對話
    /// </summary>
    public void dialogue()
    {
        DialogueUI.SetActive(UIcontroller.Dia_status);
        if (Input.GetKeyDown(KeyCode.Space) && UIcontroller.Dia_status == false)
        {
            UIcontroller.Dia_status = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && UIcontroller.Dia_status == true)
        {
            UIcontroller.Dia_status = false;
        }

    }
}
