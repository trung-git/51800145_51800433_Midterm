using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class ItemCollectController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Text txtScore;
    private int countItems = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Items"))
        {
            Destroy(other.gameObject);
            countItems++;
            txtScore.text = "Score: " + countItems;
        }
    }
}
