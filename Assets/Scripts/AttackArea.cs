using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [field: SerializeField, Range(0, 100)]
    public float damage { get; private set; } = 10f;
}
