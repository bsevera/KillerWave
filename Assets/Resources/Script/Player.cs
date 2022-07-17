using UnityEngine;

public class Player : MonoBehaviour, IActorTemplate
{
    int travelSpeed;
    int health;
    int hitPower;
    GameObject actor;
    GameObject fire;
    GameObject _Player;
    float width;
    float height;


    #region Properties

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public GameObject Fire
    {
        get { return fire; }
        set { fire = value; }
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        height = 1 / (Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).y - .5f);
        width = 1/(Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f);
        _Player = GameObject.Find("_Player");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
    }

    void Movement()
    {
        float xPos = Input.GetAxisRaw("Horizontal");
        float yPos = Input.GetAxisRaw("Vertical");

        //move right
        if (xPos > 0)
        {
            if (transform.localPosition.x < width + width / 0.9f)
            {
                transform.localPosition += new Vector3(xPos * Time.deltaTime * travelSpeed, 0, 0);
            }
        }

        //move left
        if (xPos < 0)
        {
            if (transform.localPosition.x > width + width / 6)
            {
                transform.localPosition += new Vector3(xPos * Time.deltaTime * travelSpeed, 0, 0);
            }
        }

        //move down
        if (yPos < 0)
        {
            if (transform.localPosition.y > -height / 3f)
            {
                transform.localPosition += new Vector3(0, xPos * Time.deltaTime * travelSpeed, 0);
            }
        }

        //move up
        if (yPos > 0)
        {
            if (transform.localPosition.y < height / 2.5f)
            {
                transform.localPosition += new Vector3(0, xPos * Time.deltaTime * travelSpeed, 0);
            }
        }
    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = GameObject.Instantiate(fire, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            bullet.transform.SetParent(_Player.transform);

            //make bullet look bigger by increasing its scale
            bullet.transform.localScale = new Vector3(7, 7, 7);
        }
    }

    #region SOActorTemplateImplementations
    
    public void ActorStats(SOActorModel actorModel)
    {
        health = actorModel.health;
        travelSpeed = actorModel.speed;
        hitPower = actorModel.hitPower;
        fire = actorModel.actorBullets;
    }

    #region DamageManagement
    public int SendDamage()
    {
        return hitPower;
    }

    public void TakeDamage(int incomingDamage)
    {
        health -= incomingDamage;
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    #endregion

    #endregion

    #region CollisionManagement

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (health >= 1)
            {
                if (transform.Find("enemy +1(Clone)"))
                {
                    Destroy(transform.Find("enemy +1(Clone)").gameObject);
                    health -= other.GetComponent<IActorTemplate>().SendDamage();
                }
                else
                {
                    health -= 1;
                }
            }

            if (health <= 0)
            {
                Die();
            }
        }

    }

    #endregion

}
