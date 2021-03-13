using UnityEngine;
using static UnityEngine.Mathf;
public static class FunctionLibrary
{
    public delegate float Function(float x, float t);
    public enum FunctionName {TestFunction,IncreaseLine,DecreaseLine,Wave,MultiWave,Ripple};
    static Function[] functions = {TestFunction,IncreaseLine,DecreaseLine,Wave,MultiWave,Ripple};

    public static Function GetFunction(FunctionName name){
        return functions[(int)name];
    }

    public static float TestFunction(float x,float t){
        float y = (x * Sin((x+t)*(x+t))) + 1;
        return y * 2; 
    }

    public static float IncreaseLine(float x,float t){
        return x; 
    }

    public static float DecreaseLine(float x,float t){
        return x; 
    }

    public static float Wave(float x, float t){
        return Sin(Mathf.PI * (x + t));
    }

    public static float MultiWave(float x, float t){
        float y = Sin(PI * (x * 0.5f + t));
        y += 0.5f * Sin(2f * PI * (x + t));
        return y * (2f / 3f);
    }

    public static float Ripple(float x,float t){
        float d = Abs(x);
        float y = Sin(PI * (4f * d - t));
        return y / (1f + 10f * d);
    }
}
