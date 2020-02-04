using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("角色位置")]
    public Transform player;

    [Header("相機")]
    public GameObject MainCamera;

    [Header("相機參數")]
    public float smooth = 0.05f; //使相機平滑

    [Header("地圖邊界")]
    public Vector2 minPosition;
    public Vector2 maxPosition;


   /* public float MAXmapsideX;    //地圖最大X邊界
    public float minmapsideX;    //地圖最小X邊界
    public float MAXmapsideY;    //地圖最大Y邊界
    public float minmapsideY;    //地圖最小Y邊界*/


    private void Start()
    {
        player = GameObject.FindWithTag("主角").transform;
        MainCamera = GameObject.FindWithTag("MainCamera");
    }

    private void LateUpdate()
    {
        CameraFollow();
    }

    /// <summary>
    /// 相機跟隨
    /// </summary>
    public void CameraFollow()
    {
        //MainCamera.transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

        if(transform.position != player.position)
        {
            Vector3 Player_pos = new Vector3(player.position.x, player.position.y, MainCamera.transform.position.z);           // 鎖定相機Z軸

            //限制邊框
            Player_pos.x = Mathf.Clamp(Player_pos.x, minPosition.x, maxPosition.x);
            Player_pos.y = Mathf.Clamp(Player_pos.y, minPosition.y, maxPosition.y);

            MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, Player_pos,  Time.deltaTime * smooth); // 相機延遲跟上角色
        }

    }





}
