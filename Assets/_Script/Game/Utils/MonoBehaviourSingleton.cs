using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Utils
{
    //Generic class for implementing a singleton pattern.
    public class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instnce;
        public static T Instance
        {
            get
            {
                if (instnce == null)
                    instnce = FindObjectOfType<T>();
                return instnce;
            }
        }

    }
}
