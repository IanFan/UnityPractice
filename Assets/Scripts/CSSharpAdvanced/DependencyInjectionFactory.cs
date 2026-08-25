using UnityEngine;

public class DependencyInjectionFactory : MonoBehaviour
{
    void Start()
    {
        // 建立 Dependency
        IDamageService damageService = new DamageService();
        EnemyFactory enemyFactory = new EnemyFactory();

        // 建立 Player
        SPlayer player = new SPlayer();

        // Dependency Injection
        player.Initialize(damageService, enemyFactory);

        // 測試攻擊
        player.Attack();
    }
}


// ========================
// Damage Service
// ========================

public interface IDamageService
{
    void Damage(SEnemy enemy, int damage);
}

public class DamageService : IDamageService
{
    public void Damage(SEnemy enemy, int damage)
    {
        enemy.TakeDamage(damage);
    }
}


// ========================
// Factory
// ========================

public class EnemyFactory
{
    public SEnemy Create()
    {
        Debug.Log("Create Enemy");

        return new SEnemy();
    }
}


// ========================
// Player
// ========================

public class SPlayer
{
    private IDamageService damageService;
    private EnemyFactory enemyFactory;

    // Dependency Injection
    public void Initialize(
        IDamageService damageService,
        EnemyFactory enemyFactory)
    {
        this.damageService = damageService;
        this.enemyFactory = enemyFactory;
    }

    public void Attack()
    {
        // Factory 負責建立 Enemy
        SEnemy enemy = enemyFactory.Create();

        // DamageService 負責傷害
        damageService.Damage(enemy, 10);
    }
}


// ========================
// Enemy
// ========================

public class SEnemy
{
    private int hp = 100;

    public void TakeDamage(int damage)
    {
        hp -= damage;

        Debug.Log($"Enemy HP: {hp}");
    }
}