using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace _Game.Utils
{
    //Utility class for mathematical methods.
    public static class MyMath
    {

        //Performance-oriented method for computing vector distance
        public static float Distance(Vector3 point1, Vector3 point2)
        {
            return Mathf.Pow(point1.x - point2.x, 2) + Mathf.Pow(point1.y - point2.y, 2) + Mathf.Pow(point1.z - point2.z, 2);
        }
    }
}
