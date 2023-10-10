using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int hitPoints = 3;
    public Material blinkMaterial;
    public Material defaulMaterial;
    public MeshRenderer meshRenderer;

    public Vector3 patrolPos1 = new Vector3(6.71f, 0.5f, 5f);

    public Vector3 patrolPos2 = new Vector3(-6.96f, 0.5f, -6.44f);
    Vector3 targetPos;
    public bool invincible;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = patrolPos1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, 5f * Time.deltaTime);
        if (transform.position == targetPos)
        {
            if (targetPos == patrolPos1)
                targetPos = patrolPos2;
            else
                targetPos = patrolPos1;
        }
    }

    public void TakeDamage()
    {
        if (invincible)
            return;
        hitPoints--;
        if (hitPoints == 0)
            gameObject.SetActive(false);
        else
            StartCoroutine(Invulnarabity());
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
}
