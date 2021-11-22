using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PenetratingProjectile : MonoBehaviour
{
    [SerializeField]
    public GameObject source;
    [SerializeField]
    GameObject target;
    [SerializeField]
    float projectileSpeed;
    [SerializeField]
    float rotationSpeed;
    [SerializeField]
    Vector3 mousePos;
    public float timer;
    public float range;
    [SerializeField]
    WaveOfTerrorBuff buffPrefab;
    public int skillLevel;
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
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
          mousePos = hitInfo.point;
            this.transform.LookAt(new Vector3(mousePos.x, source.transform.position.y, mousePos.z));
        }

        //Vector3 distanceToTarget = mousePos - this.gameObject.transform.position;
        //this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
        //Quaternion.LookRotation(distanceToTarget), rotationSpeed * Time.deltaTime);

        Debug.Log(source);
      
    }

    // Update is called once per frame
    void Update()
    {
        GoToTarget();


    }

    void GoToTarget()
    {
        if (Vector3.Distance(source.transform.position, this.transform.position) < range)
        {
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
                target = collidedUnit.gameObject;
                OnProjectileHit();
           
           
            }
        }

    }
    public void OnProjectileHit()
    {
        if (buffPrefab)
        {
            WaveOfTerrorBuff waveOfTerrorBuff = Instantiate(buffPrefab);
            waveOfTerrorBuff.targetUnit = target;
            waveOfTerrorBuff.gameObject.transform.parent = target.transform;
            waveOfTerrorBuff.buffLevel = skillLevel;
            waveOfTerrorBuff.ActivateBuff(target);
            onTargetHit.Invoke(target, source);
        }
        
        
    }

    IEnumerator projectileActive(float timer)
    {
        yield return new WaitForSeconds(timer);
        Destroy(this);
    }
}
