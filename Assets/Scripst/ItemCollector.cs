using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int platanos = 0;

    [SerializeField]private Text Platanotxt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Platano"))
        {
            Destroy(collision.gameObject);
            platanos++;
            Platanotxt.text = "Platanos:" + platanos;
        }
    }
}
