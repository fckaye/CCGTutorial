using System;
using UnityEngine;

namespace Test
{
    public class Enemy : MonoBehaviour
    {
        public static event EventHandler DiedEvent;

        void OnDestroy()
        {
            if(DiedEvent != null)
                DiedEvent(this, EventArgs.Empty);
        }
    }
}