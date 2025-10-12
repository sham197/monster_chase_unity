using UnityEngine;

public class Collector : MonoBehaviour
{
    string ENEMY_TAG = "Monster";
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG) || collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
