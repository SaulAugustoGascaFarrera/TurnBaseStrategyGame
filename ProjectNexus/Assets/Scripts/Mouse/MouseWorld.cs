using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    public static MouseWorld instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("There is more than one instance of Mouse World");
        }

        instance = this;
    }

    [SerializeField] private LayerMask mousePlaneLayerMask;
    private void Update()
    {
        transform.position = GetPosition();
    }

    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //print(ray);

        Physics.Raycast(ray, out RaycastHit raycasHit, float.MaxValue, instance.mousePlaneLayerMask);

        return raycasHit.point;
    }
}
