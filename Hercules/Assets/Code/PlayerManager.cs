using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public GameObject player;
    public GameObject uiCanvas;
    public GameObject SoundManager;
    
    private void Awake()
    {
        
        
        // ����Ƿ�����һ��ʵ��
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ȷ�� PlayerManager ��������
        }
        else
        {
            Destroy(gameObject); // �����ظ�ʵ��
            return;
        }
        

        // ȷ����Һ�UIҲ���ᱻ����
        if (player != null)
        {
            DontDestroyOnLoad(player);
        }
        if (uiCanvas != null)
        {
            DontDestroyOnLoad(uiCanvas);
        }
        if (SoundManager != null)
        {
            DontDestroyOnLoad(SoundManager);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        
        uiCanvas = GameObject.FindWithTag("Canvas");
        SoundManager = GameObject.FindWithTag("SoundManager");

        // ȷ����Һ�UIҲ���ᱻ����
        if (player != null)
        {
            DontDestroyOnLoad(player);
        }
        if (uiCanvas != null)
        {
            DontDestroyOnLoad(uiCanvas);
        }
        if (SoundManager != null)
        {
            DontDestroyOnLoad(SoundManager);
        }
    }
}
