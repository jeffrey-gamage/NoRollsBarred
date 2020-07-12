using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startupLoader : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Awake()
    {
        panel = this.transform.GetChild(3).gameObject;
        panel.SetActive(false);
    }
}
