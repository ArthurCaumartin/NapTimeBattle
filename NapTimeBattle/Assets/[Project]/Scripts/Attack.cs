using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private PlayerLife _life;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _damage;
    [SerializeField] private float _range;
    [SerializeField] private float _knockBackForce = 5;

    public void DoAttack()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(_attackPoint.position, _range, _layerMask);
        for (int i = 0; i < cols.Length; i++)
        {
            PlayerLife pl = cols[i].GetComponent<PlayerLife>();
            if (pl.name == transform.parent.name)
            {
                print("pl = sefl / continue");
                continue;
            }
            print("Damage " + pl.name);

            bool hisParry = false;
            pl?.DoDamage(_damage, (pl.transform.position - transform.parent.position).normalized * _knockBackForce, out hisParry);
            if (hisParry)
            {
                _life.DoDamage(0, (transform.parent.position - pl.transform.position).normalized * _knockBackForce, out bool h);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, .2f);
        Gizmos.DrawSphere(_attackPoint.position, _range);
    }
}
