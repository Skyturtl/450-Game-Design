using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI messageText; // 绑定的 TextMeshPro 对象

    void Awake()
    {
        if (messageText != null)
        {
            messageText.gameObject.SetActive(true); // 确保文本显示
            StartCoroutine(HideTextAfterDelay(3f)); // 调用协程，延迟 3 秒隐藏
        }
    }

    private System.Collections.IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 等待指定时间
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false); // 隐藏文本
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
