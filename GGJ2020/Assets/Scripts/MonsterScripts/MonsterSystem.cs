using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class MonsterSystem : MonoBehaviour
{
    public Enum.Player player = Enum.Player.Player_1;
    public float speedMove = 4;
    public int life = 10;
    public int powerAttack = 1;
    public float delayAttack = 0.2f;
    public GameObject PickUp; 
    public GameObject hitParticle; 

    public UnityEvent Attack;
    public UnityEvent Dead;

    [HideInInspector] public GameObject nearMonster;
    [HideInInspector] public float pvMax; 
    bool isMove = true;
    float chronoAttack = 0; 
    MonsterStats monsterStats;

    private void Start()
    {
        monsterStats = GetComponent<MonsterStats>();
        monsterStats.UpgradeStats(); 
        life *= monsterStats.constitution;
        speedMove *= 0.1f * monsterStats.agility;
        powerAttack *= monsterStats.strength;
        pvMax = life; 
    }

    private void Update()
    {  
        if (life <= 0) Die();
        if (nearMonster != null) Attacking(); 
        else isMove = true;
    }

    private void FixedUpdate()
    {
        if (isMove) transform.Translate(Vector3.right * speedMove * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            nearMonster = collision.gameObject; 
            isMove = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            nearMonster = null;
            isMove = true;
        }
    }

    public void Attacking()
    {
        if (nearMonster != null)
        {
            MonsterSystem otherMonster = nearMonster.GetComponent<MonsterSystem>();
            if (player != otherMonster.player)
            {
                chronoAttack += Time.deltaTime; 
                if (chronoAttack >= delayAttack)
                {
                    Attack.Invoke();
                    Instantiate(hitParticle, nearMonster.transform.GetChild(2).position, nearMonster.transform.rotation);
                    otherMonster.life -= powerAttack; 
                    chronoAttack = 0; 
                }                        
            }
        }
    }

    public void Die()
    {
        Dead.Invoke();
        InstantiateLoot();    
        Destroy(gameObject);         
    }

    public void InstantiateLoot()
    {
        PartSystem[] part = GetComponentsInChildren<PartSystem>();

        for (int i = 0; i < part.Length; i++)
        {
            GameObject newObject = Instantiate(PickUp, transform.position, transform.rotation) as GameObject;
            newObject.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z); 
            newObject.AddComponent<PartSystem>();
            PartSystem newPart = newObject.GetComponentInChildren<PartSystem>();
            newPart.partBody = part[i].partBody;
            newPart.InitiatePartBody();
            newPart.gameObject.AddComponent<PolygonCollider2D>();

            float random_x = Random.Range(-1f, 1f); 
            Vector2 randomDir = new Vector2(random_x, 0.5f); 

            newPart.GetComponent<Rigidbody2D>().AddForce(randomDir * 300); 
        } 
        



    }
}
