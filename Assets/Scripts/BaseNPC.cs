using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class BaseNPC : MonoBehaviour
{
    [Header("取得玩家資料")]
    public GameObject player;                   //玩家物件
    public BasePlayerManager player_script;     //玩家腳本
    public SpriteRenderer player_sprite;        //玩家圖塊

    [Header("NPC參數")]
    public GameObject NPC;
    public Animator NPC_Anime;
    public SpriteRenderer NPC_sprite;

    [Header("判定玩家已經靠近")]
    public bool Playerisclose =false;

    [Header("互動標籤")]
    public GameObject ChooseTag; 


    private void Start()
    {
        //取得玩家部分
        player = GameObject.FindWithTag("主角");
        player_script = FindObjectOfType<BasePlayerManager>();
        player_sprite = player.GetComponent<SpriteRenderer>();

        //取得NPC部分
        NPC_Anime = GetComponent<Animator>();
        NPC_sprite = GetComponent<SpriteRenderer>();

        //取得對話氣球
        ChooseTag = transform.GetChild(0).gameObject;
        ChooseTag.SetActive(false);

    }

    public void Update()
    {
        NPCLayer();
        NPCAnime();
    }


    /// <summary>
    /// 玩家靠近時,NPC執行的動作
    /// </summary>
    public void NPCAnime()
    {
        float NPC_Player_Distance = Vector2.Distance(transform.position, player.transform.position);

        if (NPC_Player_Distance <= 0.35)
        {
            ChooseTag.SetActive(true);
            Playerisclose = true;
            Vector2 NPPos = transform.position - player.transform.position;
            NPC_Anime.SetFloat("PositionX", NPPos.x);
            NPC_Anime.SetFloat("PositionY", NPPos.y);
        }
        else
        {
            Playerisclose = false;
            ChooseTag.SetActive(false);
        }
    }


    /// <summary>
    /// NPC的圖層位置
    /// </summary>
    public void NPCLayer()
    {

        if (transform.position.y - player.transform.position.y < 0)
        {
            NPC_sprite.sortingOrder = player_sprite.sortingOrder +1;
        }
        else
        {
            NPC_sprite.sortingOrder = player_sprite.sortingOrder -1;
        }
    }
}
