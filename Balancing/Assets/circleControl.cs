using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleControl : MonoBehaviour
{

    public GameObject shukaPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, (GameManager.instance.c_score + 10) )* Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.c_score++;
        GameManager.instance.trialMoving = false;
        collision.gameObject.transform.SetParent(gameObject.transform);
        //        collision.gameObject.SetActive(false);
        //      collision.gameObject.transform.position = collision.gameObject.transform.position;
        Instantiate(shukaPrefab);

    }
}
