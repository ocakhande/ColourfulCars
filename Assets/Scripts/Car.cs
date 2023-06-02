using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private EColor color;

    public EColor Color => color; // getter
}
