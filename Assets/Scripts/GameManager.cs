using UnityEngine;


public class GameManager : MonoBehaviour
{
    [Header("UIManager")]
    public UIManager UImanager;

    [Header("玩家的狀態")]
    public bool Player_status = true;

    private void Awake()
    {
        Player_status = true;
    }

    private void Start()
    {
        UImanager = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        DetectUI();
    }

    public void DetectUI()
    {
        if(UImanager.Dia_status == false)
        {
            Player_status = true;
        }
        else
        {
            Player_status = false;
        }
    }

}
