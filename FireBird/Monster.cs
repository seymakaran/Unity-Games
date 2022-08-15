using UnityEngine;

public class Monster : MonoBehaviour
{
    private SpriteRenderer m_spriteRenderer;
    public int m_count;

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        m_spriteRenderer.color = Color.blue;
        Destroy(collision2D.gameObject);
        --m_count;

        if (m_count == 0)
            Destroy(gameObject);
    }

    private void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        
    }
}
