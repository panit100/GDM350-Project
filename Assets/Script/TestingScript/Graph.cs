using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab = default;

    [SerializeField,Range(10,100)]
    int resolution = 10;
    [SerializeField,Range(1,100)]
    int speed = 1;
    [SerializeField,Range(0,1)]
    int Invert = 0;

    [SerializeField]
    FunctionLibrary.FunctionName function = default;

    Transform[] points;

    void Awake()
    {
        float step = 2f /resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position = Vector3.zero;
        
        points = new Transform[resolution];
        for(int i = 0; i < points.Length; i++)
        {
            Transform point = Instantiate(pointPrefab);
            position.x = (i+0.5f) * step - 1f;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform,false);
            points[i] = point;
        }

        
    }

    void Update()
    {
        FunctionLibrary.Function f = FunctionLibrary.GetFunction(function);
        
        

        float time = Time.time;
        for(int i = 0; i< points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;

            if(Invert == 0){
                position.x += (speed * Time.deltaTime);
            }else{
                position.x -= (speed * Time.deltaTime);
            }

            position.y = f(position.x,time);

            point.localPosition = position;
        }
    }
}
