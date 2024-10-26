using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneUI : MonoBehaviour
{
    private Upgrade upgrade;

    private Renderer objectRenderer;


    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        upgrade = GameObject.FindWithTag("Player").GetComponent<Upgrade>();
        if(upgrade != null)
        {
            if(upgrade.KillCount >= upgrade.killsPerLevel)
            {
                ShowObject();
            }
            else
            {
                HideObject();
            }
        }
    }

    public void ShowObject()
    {
        if(objectRenderer != null)
        {
            objectRenderer.enabled = true;
        }
    }

    public void HideObject()
    {
        if (objectRenderer != null)
        {
            objectRenderer.enabled = false;
        }
    }
}
