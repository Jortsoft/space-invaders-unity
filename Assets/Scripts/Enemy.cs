using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float[] maxShootTime;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;

    private float timer;
    private float currentMaxShootTime;

    private Animator animator;

    private void Start()
    {
        currentMaxShootTime = Random.Range(maxShootTime[0], maxShootTime[1]);
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    private void Update()
    {
        if (timer > currentMaxShootTime)
        {
            Shoot();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
    }
    public void DestroyEnemy()
    {
        animator.enabled = true;
        GameManager.Instance.UpdateScore();
        Destroy(gameObject, 1f);
    }
}
