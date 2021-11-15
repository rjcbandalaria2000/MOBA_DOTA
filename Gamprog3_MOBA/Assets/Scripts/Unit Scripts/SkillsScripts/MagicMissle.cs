using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissle : Skill
{
    public GameObject projectile;
    public GameObject targets;
   
    public float damage;
  
    [SerializeField]
    Transform skillSpawnPoint;

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
        GameObject spawnedProjectile = Instantiate(projectile, source.transform.GetChild(0).transform.position, Quaternion.identity);
        Projectile projectileSpawned = spawnedProjectile.GetComponent<Projectile>();
        if (projectileSpawned)
        {
            UnitStats sourceStats = source.GetComponent<UnitStats>();
            if (sourceStats)
            {
                projectileSpawned.SetSource(source);
                projectileSpawned.SetTarget(target);
                projectileSpawned.SetProjectileSpeed(900f/GameManager.distanceUnit);
                projectileSpawned.onTargetHit.AddListener(HitTarget);
            }


        }
    }

    public void HitTarget(GameObject target, GameObject source)
    {

        HealthComponent targetHealth = target.GetComponent<HealthComponent>();
        if (targetHealth)
        {
            UnitStats sourceStats = source.GetComponent<UnitStats>();
            if (sourceStats)
            {
                targetHealth.TakeDamage(sourceStats.GetBaseDamage());
            }

        }

    }

    //void spawnMagicMissle(GameObject target, GameObject source)
    //{
    //    GameObject skillSpawnPoint = Instantiate(projectile, source.transform.GetChild(0).transform.position, Quaternion.identity);
    //    Projectile projectileSpawned = skillSpawnPoint.GetComponent<Projectile>();
    //    if (projectileSpawned)
    //    {
    //        UnitStats sourceStats = source.GetComponent<UnitStats>();
    //        if (sourceStats)
    //        {
    //            projectileSpawned.SetSource(source);
    //            projectileSpawned.SetTarget(target);
    //            projectileSpawned.SetProjectileSpeed(900f/GameManager.distanceUnit);
    //            projectileSpawned.onTargetHit.AddListener(HitTarget);
    //        }


    //    }
    //}
   
}
