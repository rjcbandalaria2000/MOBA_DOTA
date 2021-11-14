using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissle : Skill
{
    public GameObject projectile;
    public GameObject targets;
    public float skillCooldown;
    public bool isCoolDown;
    public float damage;
    public PlayerControls playerControls; //use for targeting
    [SerializeField]
    Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        playerControls = this.gameObject.GetComponent<PlayerControls>();
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

    IEnumerator coolDown(float coolDownValue)
    {
        isCoolDown = true;
        yield return new WaitForSeconds(coolDownValue);
        isCoolDown = false;
        coolDownValue = skillCooldown;
    }
}
