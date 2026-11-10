
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float damageToPlayer = 10f;

    private Transform target;
    private int pathIndex = 0;

    private void Start()
    {
        target = LevelManager.main.path[pathIndex];
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) <= 0.1f)
        {
            pathIndex++;

            if (pathIndex >= LevelManager.main.path.Length)
            {
                // Damage the player
                HealthManager healthManager = FindAnyObjectByType<HealthManager>();

                if (healthManager != null)
                {
                    healthManager.TakeDamage(damageToPlayer);
                }

                // Update enemy count
                EnemySpawner.onEnemyDestroy.Invoke();

                // Destroy enemy
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.main.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        if (target == null) return;

        Vector2 direction = (target.position - transform.position).normalized;

        rb.linearVelocity = direction * moveSpeed;
    }
}
