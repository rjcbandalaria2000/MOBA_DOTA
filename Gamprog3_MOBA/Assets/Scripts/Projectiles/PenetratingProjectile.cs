using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PenetratingProjectile : MonoBehaviour
{
    [SerializeField]
    GameObject source;
    [SerializeField]
    GameObject target;
    [SerializeField]
    float projectileSpeed;
    [SerializeField]
    float rotationSpeed;

    public float timer = 10f;

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
        projectileSpeed /= GameManager.distanceUnit;
        StartCoroutine(projectileActive(timer));
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
        //Unit targetUnit = target.GetComponent<Unit>();
        FactionComponent targetFaction = other.GetComponent<FactionComponent>();
        if (collidedUnit)
        {
            if (targetFaction != source.gameObject.GetComponent<FactionComponent>())
            {
               
                OnProjectileHit();
           
           
            }
        }

    }
    public void OnProjectileHit()
    {
        onTargetHit.Invoke(target, source);
        
    }

    IEnumerator projectileActive(float timer)
    {
        yield return new WaitForSeconds(timer);
        Destroy(this);
    }
}
