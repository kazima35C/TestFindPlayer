using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace _Game._State
{
    //Abstaract class States
    public abstract class State : MonoBehaviour
    {
        private void Awake()
        {
            OnInit();
        }
        public abstract void OnInit();
        public abstract void OnUpdate();
        public abstract void OnStart();
    }
}
