using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : Skill
{
   [SerializeField]
   GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        
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
        GameObject spawnedProjectile = Instantiate(projectile, source.transform);
        Projectile projectileSpawned = spawnedProjectile.GetComponent<Projectile>();
        if (projectileSpawned)
        {
            UnitStats sourceStats = source.GetComponent<UnitStats>();
            if (sourceStats) {
                projectileSpawned.SetSource(source);
                projectileSpawned.SetTarget(target);
                projectileSpawned.SetProjectileSpeed(sourceStats.GetProjectileSpeed());
                //onApply.AddListener(HitTarget);
            }

            
        }
    }

    //void HitTarget(GameObject target, GameObject source) {

    //    HealthComponent targetHealth = target.GetComponent<HealthComponent>();
    //    if (targetHealth)
    //    {
    //        UnitStats sourceStats = source.GetComponent<UnitStats>();
    //        if (sourceStats)
    //        {
    //            targetHealth.TakeDamage(sourceStats.GetBaseDamage());
    //        }

    //    }

    //}
}
