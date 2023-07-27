using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Test
{
    public class Controller : MonoBehaviour
    {
        void Start()
        {
            Foo foo = GetComponentInChildren<Foo>();
            Bar bar = GetComponentInChildren<Bar>();

            foo.doStuff = bar.OnDoStuff;
            foo.TriggerStuffToDo();
        }

        void OnEnable()
        {
            Enemy.DiedEvent += OnDiedEvent;
        }

        private void OnDisable()
        {
            Enemy.DiedEvent -= OnDiedEvent;
        }

        void OnDiedEvent(object sender, EventArgs e)
        {
            // TODO: Something happen when enemy dies
        }
    }   
}
