using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _damage;
    [SerializeField] private float _range;

    public void DoAttack()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(_attackPoint.position, _range, _layerMask);
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].gameObject == gameObject) continue;
            PlayerLife pl = cols[i].GetComponent<PlayerLife>();
            pl?.DoDamage(_damage);
        }
    }

    private void OnDrawGizmo()
    {
        Gizmos.color = new Color(1, 0, 0, .2f);
        Gizmos.DrawSphere(_attackPoint.position, _range);
    }
}
