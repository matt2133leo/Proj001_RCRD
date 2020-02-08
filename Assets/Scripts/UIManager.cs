using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("對話視窗狀態")]
    public bool Dia_status = false;

    private void Awake()
    {
        Dia_status = false; //遊戲開始時對話視窗為關閉的
    }

}
