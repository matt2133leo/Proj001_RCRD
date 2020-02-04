using System.Collections;
using UnityEngine;

public class BaseNPC : MonoBehaviour
{
    [Header("取得玩家資料")]
    public BasePlayerManager playerdata; 

    [Header("NPC參數")]
    public GameObject NPC;
    public Animator NPCAnime;

    [Header("對話開關")]
    public bool NPCdialogue =false;

    private void Start()
    {
     //   gamemanager = GameObject.FindWithTag("gamemanager").GetComponent<GameManager>();
        playerdata = GameObject.FindWithTag("主角").GetComponent<BasePlayerManager>();
        NPC = GameObject.FindWithTag("NPC");
        NPCAnime = NPC.GetComponent<Animator>();
    }

    public void Update()
    {
        //print("NPC取得玩家位置" + playerdata.player.transform.position);
        //print("NPC與玩家之間的距離" + (transform.position - playerdata.player.transform.position));
        NPCLayer();
    }


    /// <summary>
    /// 玩家靠近時,NPC執行的動作
    /// </summary>
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "主角" )
        {
            NPCdialogue = true;
            Vector2 NPPos = transform.position - playerdata.player.transform.position;
            NPCAnime.SetFloat("PositionX", NPPos.x);
            NPCAnime.SetFloat("PositionY", NPPos.y);
        }
        
    }

    /// <summary>
    /// 當主角離開NPC身旁
    /// </summary>
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "主角")
        {
            NPCdialogue = false;
        }
    }


    /// <summary>
    /// NPC的圖層位置
    /// </summary>
    public void NPCLayer()
    {
        if (transform.position.y - playerdata.player.transform.position.y < 0)
        {
            NPC.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
        else
        {
            NPC.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
    }
}
