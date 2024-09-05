using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private bool hasAlien = false;
    [SerializeField] private float moveSpeed = 10f;

    private void Update()
    {
        MoveBullet();
    }

    private void MoveBullet()
    {
        if (hasAlien)
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        } else
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Wall wallScript = collision.gameObject.GetComponent<Wall>();
            wallScript.Demage();
            Destroy(gameObject);
        }
        if (!hasAlien && collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemyScript = collision.gameObject.GetComponent<Enemy>();
            enemyScript.DestroyEnemy();
            Destroy(gameObject);
        }
        if (hasAlien && collision.gameObject.CompareTag("Player"))
        {
            Ship shipScript = collision.gameObject.GetComponent<Ship>();
            shipScript.DestroyShip();
            Destroy(gameObject);
        }
    }
}
