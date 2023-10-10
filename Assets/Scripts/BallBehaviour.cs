using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public BossBehaviour boss;
    public Rigidbody rb;
    public Transform cameraParent;
    public GameObject [] doors;
    public Transform [] coinsParents;
    public int level = 0;
    
    public float speed = 3f;
    public float jumpForce = 100f;
    public int maxJumps = 2;
    public int currentJumps;
    public int coinsCollected;
    public int coinsOnPlatform = 6;
    public bool invertedControll;

    public Material blinkMaterial;
    public Material defaulMaterial;
    public MeshRenderer meshRenderer;
    

    public bool invincible;



    public GameObject door;
    public GameObject door2;
    public GameObject door3;

    public Transform coinsParent;

    public Transform coinsParent2;

    public Transform coinsParen3;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        //transform.position = new Vector3(5f, 0.5f, 0f);
        
        //coinsOnPlatform = GameObject.FindGameObjectsWithTag("Collectible").Length;
        coinsOnPlatform = coinsParents[level].childCount;
        Vector3 a = new Vector3(1f, 0f, 1f);
        //Debug.Log(Vector3.Normalize(a));
        Debug.Log(Mathf.Cos(Mathf.Deg2Rad * 0f));
    }

    
    void FixedUpdate()//0.2 seconds
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(x, 0f, z);
        direction = cameraParent.forward * z + cameraParent.right * x;
        


        //if(currentJumps == 0)
        rb.AddForce(invertedControll ? new Vector3(-z, 0f, x) * speed : Vector3.Normalize(direction) * speed);        
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentJumps = 0;
        if (collision.gameObject.tag == "Enemy" && !invincible)
        {
            transform.localScale = transform.localScale * 0.9f;
            StartCoroutine(Invulnarabity());
        }
        if (collision.gameObject.tag == "EnemyHead")
        {
            collision.transform.parent.GetComponent<EnemyBehaviour>().TakeDamage();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectible")
        {
            other.gameObject.SetActive(false);
            coinsCollected++;
            if (coinsCollected == coinsOnPlatform)
            {
                doors[level].SetActive(false);
                coinsCollected = 0;
                level++;
                coinsOnPlatform = coinsParents[level].childCount;
            }
        }
        if (other.gameObject.tag == "Health")
        {
            transform.localScale = transform.localScale * 1.2f;
            if (transform.localScale.x >= 1f)
                transform.localScale = Vector3.one;
        }
    }

    IEnumerator Invulnarabity()
    {
        invincible = true;
        
        for (int i = 0; i < 15; i++)
        {
            if (i % 2 == 0)
            {
                meshRenderer.material = blinkMaterial;
            }
            else
            {
                meshRenderer.material = defaulMaterial;
            }
            yield return new WaitForSeconds(0.2f);
        }


        meshRenderer.material = defaulMaterial;
        invincible = false;
    }
    float [] minPosYs;
    //_aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa____
    //GetKey  
    //GetKeyDown
    //GetKeyUp
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentJumps < maxJumps)
        {
            rb.AddForce(Vector3.up * jumpForce);
            currentJumps++;
        }
        if (Input.GetKeyDown(KeyCode.J))
            boss.StartBossFight();

        //if (transform.position.y < minPosYs[level])
          //  transform.position = new Vector3(0, 2, -3);
        /*
        rb.AddForce(Vector3.right);
        //transform.position = transform.position + new Vector3(1f, 0f, 0f) * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }*/
    }
}
