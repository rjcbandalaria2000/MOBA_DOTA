using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRangedAttack : Skill
{
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        //spawnPoint = this.gameObject.transform.parent.gameObject.transform.GetChild(0).transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnActivate(GameObject target, GameObject attacker = null)
    {
        base.OnActivate(target, attacker);
        SpawnProjectile(target, attacker);

    }

    public override void ActivateSkill(GameObject target, GameObject attacker = null)
    {
        base.ActivateSkill(target, attacker);
    }

    void SpawnProjectile(GameObject target, GameObject source)
    {
        GameObject spawnedProjectile = Instantiate(projectile, source.transform.GetChild(0).transform.position, Quaternion.identity);
        Projectile projectileSpawned = spawnedProjectile.GetComponent<Projectile>();
        if (projectileSpawned)
        {
            UnitStats sourceStats = source.GetComponent<UnitStats>();
            if (sourceStats)
            {
                projectileSpawned.SetSource(source);
                projectileSpawned.SetTarget(target);
                projectileSpawned.SetProjectileSpeed(sourceStats.GetProjectileSpeed());
                projectileSpawned.onTargetHit.AddListener(HitTarget);
            }
        }
    }

    public void HitTarget(GameObject target, GameObject source)
    {
        DamageReceiver targetDamageReceiver = target.GetComponent<DamageReceiver>();
        if (targetDamageReceiver)
        {
            UnitStats sourceStats = source.GetComponent<UnitStats>();
            if (sourceStats)
            {
                targetDamageReceiver.ReceiveDamage(sourceStats.GetBaseDamage());
            }
        }

        //HealthComponent targetHealth = target.GetComponent<HealthComponent>();
        //if (targetHealth)
        //{
        //    UnitStats sourceStats = source.GetComponent<UnitStats>();
        //    if (sourceStats)
        //    {
        //        targetHealth.TakeDamage(sourceStats.GetBaseDamage());
        //    }

        //}

    }
}
