using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI messageText; // �󶨵� TextMeshPro ����

    void Awake()
    {
        if (messageText != null)
        {
            messageText.gameObject.SetActive(true); // ȷ���ı���ʾ
            StartCoroutine(HideTextAfterDelay(3f)); // ����Э�̣��ӳ� 3 ������
        }
    }

    private System.Collections.IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // �ȴ�ָ��ʱ��
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false); // �����ı�
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
