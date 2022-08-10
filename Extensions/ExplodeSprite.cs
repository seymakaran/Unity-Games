using System;
using UnityEngine;
using Karan.Game.Extensions;
using Object = System.Object;

public class ExplodeSprite : MonoBehaviour
{
    private GameObject[] m_gameObjects;
    public string Tag = "bug";
    public float Pow;
    public float Radius;
    public GameObject Platform;

    private void explodeTagged()
    {
        Platform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        foreach (var go in m_gameObjects)
        {
            var rigidBody = go.GetComponent<Rigidbody2D>();
            rigidBody.AddExplosionForce(Pow, transform.position, Radius);
        }
    }
    private void explode()
    {
        var pos = transform.position;
        var colliders = Physics2D.OverlapCircleAll(pos, Radius);
        
        foreach (var collider in colliders)
        {
            var rigidBody = collider.GetComponent<Rigidbody2D>();

            if (rigidBody != null)
                rigidBody.AddExplosionForce(Pow, pos, Radius);
        }
    }

    private void Awake()
    {
        m_gameObjects = GameObject.FindGameObjectsWithTag(Tag);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            explode();
        
        if (Input.GetKeyUp(KeyCode.X))
            explodeTagged();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
