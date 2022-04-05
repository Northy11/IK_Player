using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;


public class Monster : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent agent;
    public ThirdPersonCharacter charecter;
    public Animator animator;
    public float animationTime = 2f;
    public float startCatch = 10f;

    //Meteor

    public float forceMag = 10f;
    public GameObject meteor;
    public float meteorHeight = 20f;
    public GameObject[] meteors;
    public GameObject meteorShadow; 
    public Transform[] targets;
    public GameObject[] targetPlates;

    //Spin

    public GameObject spinAttack;


    //Rain
    public GameObject crystalRain;
    public float spawnAt;

    //Last attack used
    //Summon = 0
    //Meteor = 1
    //Spin = 2
    //Rain = 3
    int lastAttackUsed = 0;
    public float longRange;
    public float medRange;

    public float attackTimer;
    public float initialAttackTimer;

    void Start()
    {
        agent.updateRotation = false;
        animator = gameObject.GetComponent<Animator>();
        attackTimer = initialAttackTimer;
        StartCoroutine("Spin");
    }

    void Update()
    {
        attackTimer -= Time.deltaTime;
        if (player != null)
        {
            agent.SetDestination(player.transform.position);
        }
        //Velocity Controls
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            charecter.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            charecter.Move(Vector3.zero, false, false);
        }

        if(attackTimer < 0)
        {
            attackTimer = Random.Range(initialAttackTimer - 5f, initialAttackTimer + 5f);
          //  Attack();
        }
    }

    void Attack()
    {
        float dist = new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z).magnitude;
        if (dist > longRange)
        {
            int rnd = Random.Range(0, 100);
            if (rnd > 90)
            {
                StartCoroutine("Spin");
            }
            else if (rnd > 40)
            {
                StartCoroutine("Rain");
            }
            else
            {
                StartCoroutine("Meteor");
            }
        }
        else if (dist > medRange)
        {

            int rnd = Random.Range(0, 100);
            if (rnd > 70)
            {
                StartCoroutine("Spin");
            }
            else if (rnd > 35)
            {
                StartCoroutine("Rain");
            }
            else
            {
                StartCoroutine("Meteor");
            }
        }
        else
        {

            int rnd = Random.Range(0, 100);
            if (rnd > 60)
            {
                StartCoroutine("Spin");
            }
            else if (rnd > 30)
            {
                StartCoroutine("Rain");
            }
            else
            {
                StartCoroutine("Meteor");
            }
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            //Debug.Log("Hit");
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }

    private IEnumerator Meteor()
    {
        animator.SetBool("CastSpell", true);


        meteors = new GameObject[5];
        targetPlates = new GameObject[5];
        Vector3 spawn = gameObject.transform.position + new Vector3(0, meteorHeight, 0);
        for (int i = 0; i < 5; i++)
        {
            meteors[i] = Instantiate(meteor, spawn, Quaternion.identity);
            Vector3 force = (targets[i].position - meteors[i].transform.position).normalized;
            meteors[i].GetComponent<Rigidbody>().AddForce(force * forceMag, ForceMode.VelocityChange);
        }

        for (int i = 0; i < 5; i++)
        {
            Instantiate(meteorShadow, targets[i].position, Quaternion.identity);
        }

        yield return new WaitForSeconds(animationTime);

        animator.SetBool("CastSpell", false);
    }

    private IEnumerator Spin()
    {
        yield return new WaitForSeconds(animationTime);
        spinAttack.SetActive(true);
    }

    public IEnumerator Summon()
    {
        yield return new WaitForSeconds(attackTimer + animationTime);
    }

    public IEnumerator Rain()
    {
        Vector3 dir = (player.transform.localPosition - transform.position);
        Vector3 pos = ((-dir.normalized) * (dir.magnitude * spawnAt)) + new Vector3(0, 30, 0);
        GameObject rain = Instantiate(crystalRain, pos, Quaternion.identity);
        yield return new WaitForSeconds(0f);
    }
}
