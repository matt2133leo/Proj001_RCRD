using UnityEngine;
using UnityEngine.UI;

public class BasePlayerManager : MonoBehaviour
{

    [Header("取得NPC資料")]
    public BaseNPC NPCdata;

    [Header("走路速度")]
    public float move_speed = 200f;

    [Header("角色參數")]
    public GameObject player;
    public Rigidbody2D player_rig2D;
    public Animator playerAnime;
    public Vector3 player_position;

    [Header("移動與動畫開關")]
    public bool move_ani_bool = true;

    /* 已捨棄 switch case 部分
    [Header("開關")]
    public bool player_walk_down;
    public bool player_walk_up;
    public bool player_walk_vertical;
    public bool playerflipX;
    */

    private void Start()
    {
        NPCdata = GameObject.FindWithTag("NPC").GetComponent<BaseNPC>();
        player = GameObject.FindWithTag("主角");
        player_rig2D = player.GetComponent<Rigidbody2D>();
        playerAnime = player.GetComponent<Animator>();

        #region switch if 已捨棄
        /*
        player_walk_down = false;
        player_walk_up = false;
        playerflipX = false;
        */
        #endregion
    }

    private void Update()
    {
        move();  //角色移動方法
        anime(); //角色動畫
    }


    /// <summary>
    /// 角色行走
    /// </summary>
    public void move()
    {
        if (move_ani_bool == true)
        {
            move_speed = 200f;
            //角色移動
            player_position = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            //player.transform.position += player_position * move_speed * Time.deltaTime;
            player_rig2D.velocity = player_position * move_speed * Time.deltaTime;

            #region 已捨棄Switch寫法
            /*
                    //角色移動位置
           Vector3 player_positon = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
           player.transform.position += player_positon * move_speed * Time.deltaTime;
           player.GetComponent<SpriteRenderer>().flipX = playerflipX;

           int walkcase = 1; //移動的參數

           //角色動畫開關
           playerAnime.SetBool("Walk_Down", player_walk_down);
           playerAnime.SetBool("Walk_Up", player_walk_up);
           playerAnime.SetBool("Walk_Vertical", player_walk_vertical);

           #region 角色動畫控制

           //動畫執行編號
           if (Input.GetKey(KeyCode.DownArrow) == true && Input.GetKey(KeyCode.UpArrow) == false)
           {
               walkcase = 1; //面向下方
           }
           else if (Input.GetKey(KeyCode.UpArrow) == true && Input.GetKey(KeyCode.DownArrow) == false)
           {
               walkcase = 2; //面向上方
           }
           else if (Input.GetKey(KeyCode.LeftArrow) == true)
           {
           walkcase = 3; //面向左方
           }
           else if (Input.GetKey(KeyCode.RightArrow) == true)
           {
           walkcase = 4; //面向右方
           }
           else 
           {
           walkcase = 9; //原地不動
          }
          //動畫開關
          switch (walkcase) 
                   {
              case 1:
                  //print("角色往下移動");
                  player_walk_up = false;
                  player_walk_down = true;
                  player_walk_vertical = false;
                  break;
               case 2:
                   //print("角色往上移動");
                   player_walk_up = true;
                   player_walk_down = false;
                   player_walk_vertical = false;
                   break;
                case 3:
                    player_walk_vertical = true;
                    playerflipX = false;
                    break;
                case 4:
                    player_walk_vertical = true;
                    playerflipX = true;
                    break;
                case 9:
                    //print("case3");
                  player_walk_up = false;
                  player_walk_down = false;
                  player_walk_vertical = false;
                  break;
           }
           #endregion
           */
            #endregion

            #region 已捨棄if寫法
            /*
            //往上走
            if (Input.GetKey(KeyCode.DownArrow) )
            {
                player_walk_down = true;
                Vector3 player_positon = new Vector3(0, Input.GetAxisRaw("Vertical"));
                player.transform.position += player_positon * move_speed * Time.deltaTime;

            }
            else
            {
                player_walk_down = false;
            }

            //往下走
            if(Input.GetKey(KeyCode.UpArrow))
            {
                player_walk_up = true;
                Vector3 player_positon = new Vector3(0, Input.GetAxisRaw("Vertical"));
                player.transform.position += player_positon * move_speed * Time.deltaTime;
            }
            else
            {
                player_walk_up = false;
            }
            */
            #endregion
        }
        else
        {
            move_speed = 0f;
            player_rig2D.velocity = player_position * move_speed * Time.deltaTime;
        }

    }

    public void anime()
    {
        if (move_ani_bool == true)
        {
            playerAnime.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
            playerAnime.SetFloat("Vertical", Input.GetAxis("Vertical"));
            playerAnime.SetFloat("Magnitude", player_position.magnitude);
            //使角色面向正確方向
            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {
                playerAnime.SetFloat("lastHorizontal", Input.GetAxisRaw("Horizontal"));
                playerAnime.SetFloat("lastVertical", Input.GetAxisRaw("Vertical"));
            }
        }
        else
        {
            Vector2 PNPos = transform.position - NPCdata.transform.position;
            playerAnime.SetFloat("lastHorizontal", -PNPos.x);
            playerAnime.SetFloat("lastVertical", -PNPos.y);
            playerAnime.SetFloat("Horizontal", 0);
            playerAnime.SetFloat("Vertical", 0);
            playerAnime.SetFloat("Magnitude", 0);
        }










    }
}
