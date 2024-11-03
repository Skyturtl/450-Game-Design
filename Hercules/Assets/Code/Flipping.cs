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

        // 如果鼠标在角色的右边
        if (mousePosition.x > transform.position.x)
        {
            scale.x = -Mathf.Abs(scale.x); // 朝右
        }
        else
        {
            scale.x = Mathf.Abs(scale.x); // 朝左
        }

        transform.localScale = scale;
    }
}
