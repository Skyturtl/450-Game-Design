using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipping : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 scale = transform.localScale;

        // �������ڽ�ɫ���ұ�
        if (mousePosition.x > transform.position.x)
        {
            scale.x = -Mathf.Abs(scale.x); // ����
        }
        else
        {
            scale.x = Mathf.Abs(scale.x); // ����
        }

        transform.localScale = scale;
    }
}
