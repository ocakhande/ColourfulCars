using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private CarController carController;
    public EColor Color;
    public EDirection Direction;


    private void OnTriggerEnter(Collider other)
    {
        string tag1=gameObject.tag;
        string tag2=other.gameObject.tag;
        if (tag1==tag2)
        {
            Debug.Log("carpti");
            Destroy(other.gameObject);
            
            carController.CarCount--;
        }
    }

}
