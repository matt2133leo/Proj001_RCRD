using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class BasePlayerManager : MonoBehaviour
{
    [Header("遊戲控制器")]
    public GameManager gamemanager;

    [Header("取得NPC資料")]
    public List<GameObject> NPC_Script;
    public int NPC_num;
    public float NP_Distance;
    public List<float> save_distance;
    [SerializeField] public static int NPC_ID;

    [Header("走路速度")]
    public float move_speed = 200f;

    [Header("角色參數")]
    public GameObject player;
    public Rigidbody2D player_rig2D;
    public Animator player_Anime;
    public Vector3 player_position;




    private void Start()
    {
        NPC_Script = GameObject.FindGameObjectsWithTag("NPC").ToList();
        gamemanager = FindObjectOfType<GameManager>();
        player_rig2D = GetComponent<Rigidbody2D>();
        player_Anime = GetComponent<Animator>();
        
    }

    private void Update()
    {
        move();  //角色移動方法
        anime(); //角色動畫
        NPC_ID_Detect(); //NPCID偵測
    }

    /// <summary>
    /// 角色行走
    /// </summary>
    public void move()
    {
        if (gamemanager.Player_status == true)
        {
            move_speed = 200f;
            //角色移動
            player_position = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            player_rig2D.velocity = player_position * move_speed * Time.deltaTime;
        }
        else
        {
            move_speed = 0f;
            player_rig2D.velocity = player_position * move_speed * Time.deltaTime;
        }

    }
   
    /// <summary>
    /// 對話後面像方向
    /// </summary>
    public void anime()
    {
        if (gamemanager.Player_status == true)
        {
            player_Anime.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
            player_Anime.SetFloat("Vertical", Input.GetAxis("Vertical"));
            player_Anime.SetFloat("Magnitude", player_position.magnitude);
            //使角色面向正確方向
            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {
                player_Anime.SetFloat("lastHorizontal", Input.GetAxisRaw("Horizontal"));
                player_Anime.SetFloat("lastVertical", Input.GetAxisRaw("Vertical"));
            }
        }
        else 
        {
            Vector2 PNPos = transform.position - NPC_Script[NPC_ID_Detect()].transform.position;
            player_Anime.SetFloat("lastHorizontal", -PNPos.x);
            player_Anime.SetFloat("lastVertical", -PNPos.y);
            player_Anime.SetFloat("Horizontal", 0);
            player_Anime.SetFloat("Vertical", 0);
            player_Anime.SetFloat("Magnitude", 0);
        }
    }


    /// <summary>
    /// 角色偵測
    /// </summary>
    /// <returns>角色ID</returns>
    public int NPC_ID_Detect()
    {
        save_distance.Clear();
        for (int i = 0; i < NPC_Script.Count; i++)
        {
            NP_Distance = Vector2.Distance(transform.position, NPC_Script[i].transform.position);
            save_distance.Add(NP_Distance);
            if (NP_Distance == save_distance.Min() && NP_Distance < 0.35)
            {
                    NP_Distance = save_distance[i];
                    NPC_ID = i;
            }

        }
        return NPC_ID;
    }
}
