using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public GameObject player;
    public GameObject uiCanvas;
    private void Awake()
    {
        // 检查是否已有一个实例
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 确保 PlayerManager 不被销毁
        }
        else
        {
            Destroy(gameObject); // 避免重复实例
            return;
        }

        // 确保玩家和UI也不会被销毁
        if (player != null)
        {
            DontDestroyOnLoad(player);
        }
        if (uiCanvas != null)
        {
            DontDestroyOnLoad(uiCanvas);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
