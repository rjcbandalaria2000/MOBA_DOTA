using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveOfTerror : Skill
{
    public GameObject penetratingProjectile;
    public GameObject targets;

    public List<float> damage;

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
        isCoolDown = true;
        coolDownRoutine = StartCoroutine(SkillCoolDown(skillCooldown[skillLevel - 1], skillIndex));
    }

    void SpawnProjectile(GameObject target, GameObject source)
    {
        GameObject spawnedProjectile = Instantiate(penetratingProjectile, source.transform.GetChild(0).transform.position, Quaternion.identity);
        PenetratingProjectile projectileSpawned = spawnedProjectile.GetComponent<PenetratingProjectile>();
        projectileSpawned.range = castRange/GameManager.distanceUnit;

        if (projectileSpawned)
        {
            UnitStats sourceStats = source.GetComponent<UnitStats>();
            if (sourceStats)
            {
                projectileSpawned.SetSource(source);
                projectileSpawned.SetTarget(target);
                // projectileSpawned.SetProjectileSpeed(900f/GameManager.distanceUnit);
                projectileSpawned.SetProjectileSpeed(800f);
                projectileSpawned.skillLevel = skillLevel;
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
                //Make a new stun state mechanim 
                //Go to stun and wait for timer then return to idle 
                //Same with nether swap 
                targetHealth.TakeDamage(damage[skillLevel - 1]);
            }

        }

    }
}
