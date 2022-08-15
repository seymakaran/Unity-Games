using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBird : MonoBehaviour
{
    private int m_count;
    public GameObject Wall;
    public GameObject Fire;
    public float Speed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ++m_count;
            var go = Instantiate(Fire, transform.position, transform.rotation);
            go.GetComponent<Rigidbody2D>().velocity = new Vector3(1, 0, 0) * Speed;
            Destroy(go, 0.5F);

            if (m_count == 10) 
                Destroy(Wall);
            
        }
    }
}
