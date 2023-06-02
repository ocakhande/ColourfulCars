using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class MoveController : MonoBehaviour
{
    [SerializeField] public CarController carController;
    [SerializeField] public Wall greenWall;
    [SerializeField] public Wall blueWall;
    [SerializeField] public Wall redWall;
    [SerializeField] public Wall yellowWall;

    private Vector3 difference;
    private Vector3 mousePosition1;
    private List<Wall> walls = new List<Wall>();

    public float rotationDuration = 2f;
    public float moveDuration = 2f;

    private void Start()
    {
        walls.Add(redWall);
        walls.Add(yellowWall);
        walls.Add(greenWall);
        walls.Add(blueWall);
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            mousePosition1 = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePosition2 = Input.mousePosition;
            difference = mousePosition2 - mousePosition1;

            var isDirectionX = Mathf.Abs(difference.x) > Mathf.Abs(difference.y) ? true : false;

            if (isDirectionX)
            {
                if (difference.x > 0) // East
                {
                    moveCar(EDirection.East);

                }
                else // West
                {
                    moveCar(EDirection.West);

                }
            }
            else
            {
                if (difference.y < 0) // South
                {
                    moveCar(EDirection.South);

                }
                else // North
                {
                    moveCar(EDirection.North);


                }
            }
        }
    }
    private void moveCar(EDirection direction)
    {

        Wall targetWall;
        foreach (Wall wall in walls)
        {
            if (wall.Direction == direction)
            {
                targetWall = wall;

                var currentCar = carController.CurrentCar;
                if (currentCar.Color == targetWall.Color)
                {
                    currentCar.transform.DOLookAt(targetWall.transform.position, rotationDuration)
                        .OnComplete(() =>
                        {
                            // lambda function
                            currentCar.transform.DOMove(targetWall.transform.position, moveDuration)
                                .SetEase(Ease.Linear);
                        });
                }
            }
        }
    }
}
