using UnityEngine;

public class TowerController : MonoBehaviour
{
    [Header("TAGS Used")]
    public string enemyTag = "Enemy";
    public string towerTag = "Tower";

    [Header("Attributes")]
    public float range = 15f;
    public float turnSpeed = 5f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Setup")]
    public Transform rotatePart;
    public Transform firePoint;
    public GameObject pfBullet;
    private Transform target;

    [Header("Use Sun")]
    public bool useSun = false;
    public int sunIncome = 5;
    private float sunTimer = 0f;

    [Header("Use Wind")]
    public bool useWind = false;
    public float slowPercentage = 0.5f;
    public Vector3 windBoxSize = new Vector3(10f, 5f, 5f); // Largura, Altura, Profundidade
    public Transform windBoxCenter;

    [Header("Use Data")]
    public bool useData = false;
    public Vector3 dataBoxSize = new Vector3(10f, 5f, 10f); // Área de efeito
    public Transform dataBoxCenter;
    public float boostTurnSpeed = 2f;
    public float boostFireRate = 0.5f;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        if (useWind || useSun || useData)
        {
            target = null; // Desativar o alvo ao usar Wind, Sun ou Data
            return;
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (useWind)
        {
            ApplyWindEffect();
            return;
        }
        if (useSun)
        {
            GenerateSunIncome();
            return;
        }
        if (useData)
        {
            ApplyDataEffect();
            return;
        }

        if (target == null) return;

        // Rotação da torre
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotatePart.rotation, lookRotation, turnSpeed * Time.deltaTime).eulerAngles;
        rotatePart.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        // Atirar
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(pfBullet, firePoint.position, firePoint.rotation);
        BulletController bullet = bulletGO.GetComponent<BulletController>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void GenerateSunIncome()
    {
        sunTimer += Time.deltaTime;
        if (sunTimer >= 1f) // Gera renda a cada segundo
        {
            StatsManager.Money += sunIncome; // Adiciona dinheiro ao StatsManager
            sunTimer = 0f;
        }
    }

    void ApplyWindEffect()
    {
        if (windBoxCenter == null)
        {
            Debug.LogWarning("WindBoxCenter não está definido!");
            return;
        }

        Vector3 boxCenter = windBoxCenter.position;
        Quaternion boxRotation = windBoxCenter.rotation;

        Collider[] hitColliders = Physics.OverlapBox(boxCenter, windBoxSize / 2, boxRotation);
        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag(enemyTag))
            {
                EnemyController enemy = collider.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    enemy.Slow(slowPercentage);
                }
            }
        }
    }

    void ApplyDataEffect()
    {
        if (dataBoxCenter == null)
        {
            Debug.LogWarning("DataBoxCenter não está definido!");
            return;
        }

        Vector3 boxCenter = dataBoxCenter.position;
        Quaternion boxRotation = dataBoxCenter.rotation;

        Collider[] hitColliders = Physics.OverlapBox(boxCenter, dataBoxSize / 2, boxRotation);
        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag(towerTag) && collider.gameObject != this.gameObject)
            {
                TowerController tower = collider.GetComponent<TowerController>();
                if (tower != null)
                {
                    tower.turnSpeed += boostTurnSpeed;
                    tower.fireRate += boostFireRate;
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (useWind && windBoxCenter != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.matrix = Matrix4x4.TRS(windBoxCenter.position, windBoxCenter.rotation, Vector3.one);
            Gizmos.DrawWireCube(Vector3.zero, windBoxSize);
        }
        else if (useData && dataBoxCenter != null)
        {
            Gizmos.color = Color.green;
            Gizmos.matrix = Matrix4x4.TRS(dataBoxCenter.position, dataBoxCenter.rotation, Vector3.one);
            Gizmos.DrawWireCube(Vector3.zero, dataBoxSize);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}
