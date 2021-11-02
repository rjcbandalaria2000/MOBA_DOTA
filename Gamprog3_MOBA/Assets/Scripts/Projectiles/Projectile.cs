using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    GameObject source;
    [SerializeField]
    GameObject target;
    [SerializeField]
    float projectileSpeed;
    [SerializeField]
    float rotationSpeed;

    public UnityEvent<GameObject, GameObject> onTargetHit;

    #region Getter Setter
    public void SetSource(GameObject sourceUnit)
    {
        source = sourceUnit;
    }
    public void SetTarget(GameObject unitTarget)
    {
        target = unitTarget;
    }
    public void SetProjectileSpeed(float speed)
    {
        projectileSpeed = speed; 
    }
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GoToTarget();
    }

    void GoToTarget()
    {
        if (target)
        {
            Vector3 distanceToTarget = target.gameObject.transform.position - this.gameObject.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(distanceToTarget), rotationSpeed * Time.deltaTime);

            this.transform.Translate(0, 0, Time.deltaTime * projectileSpeed);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Unit collidedUnit = other.GetComponent<Unit>();
        Unit targetUnit = target.GetComponent<Unit>();
        if (collidedUnit) {
            if (collidedUnit == targetUnit)
            {
                //HealthComponent targetHealth = target.GetComponent<HealthComponent>();
                //if (targetHealth)
                //{
                OnProjectileHit();
                Destroy(this.gameObject);
                //}
            }
        }

    }
    public void OnProjectileHit()
    {
        onTargetHit.Invoke(target, source);
        //HealthComponent targetHealth = target.GetComponent<HealthComponent>();
        //if (targetHealth)
        //{
        //    UnitStats sourceStats = source.GetComponent<UnitStats>();
        //    if (sourceStats) {
        //        targetHealth.TakeDamage(sourceStats.GetBaseDamage());
        //    }
            
        //}
        //Skill skill = source.GetComponent<Unit>().GetSkill(0);
       // RangedAttack rangedSkill = skill.GetComponent<RangedAttack>();

        //rangedSkill.onApply.Invoke(target);
    }
    

}