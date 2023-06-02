using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarController : MonoBehaviour
{
    public List<Car> carList = new List<Car> ();

    private int carIndex;

    public Car CurrentCar { get; private set; }
    public int CarCount { get; set; }


    void Update()
    {
        if(CarCount==0)
        {
            GenerateNumber();
        }
    }

    public void GenerateNumber()
    {

        carIndex = Random.Range(0, carList.Count);

        CurrentCar = Instantiate(carList[carIndex]);
        CurrentCar.transform.SetParent(gameObject.transform);
        CurrentCar.transform.localScale = Vector3.zero;
        CurrentCar.transform.DOScale(3, 2);
        CarCount++;
    }
}
