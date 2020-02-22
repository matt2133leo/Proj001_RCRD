using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [Header("UI控制器")]
    public UIManager UIcontroller;

    [Header("對話視窗")]
    public GameObject DialogueUI;

    [Header("NPC資料")]
    public List<BaseNPC> NPCdata;

    [Header("Player資料")]
    public BasePlayerManager playerdata;

    private void Start()
    {
        UIcontroller = FindObjectOfType<UIManager>();
        NPCdata = FindObjectsOfType<BaseNPC>().ToList();
        playerdata = GameObject.FindWithTag("主角").GetComponent<BasePlayerManager>();
        DialogueUI = GameObject.FindWithTag("UI").transform.Find("對話視窗").gameObject;
        DialogueUI.SetActive(UIcontroller.Dia_status);
    }

    private void Update()
    {
        for (int i = 0; i < NPCdata.Count; i++)
        {
            if (i == BasePlayerManager.NPC_ID && NPCdata[i].Playerisclose == true) dialogue();
        }

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
