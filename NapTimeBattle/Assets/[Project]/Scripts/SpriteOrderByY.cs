using UnityEngine;

public class SpriteOrderByY : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        _spriteRenderer.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
    }
}
