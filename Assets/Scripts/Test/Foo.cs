using System;
using UnityEngine;

namespace Test
{
    public delegate void MyDelegate();
    
    public class MyEventArgs : EventArgs{}
    
    public class Foo : MonoBehaviour
    {
        // Define EventHandlers
        public event EventHandler doStuff1;
        public event EventHandler<MyEventArgs> doStuff2;
        
        // These mehthods can be added as observers
        public void OnDoStuff1(object sender, EventArgs e){}
        public void OnDoStuff2(object sender, MyEventArgs e){}

        public MyDelegate doStuff;

        public void Start()
        {
            // Here we add the method as an observer
            doStuff1 += OnDoStuff1;
            doStuff2 += OnDoStuff2;
            
            // Here we invoke the event
            if (doStuff1 != null) doStuff1(this, EventArgs.Empty);
            if (doStuff2 != null) doStuff2(this, new MyEventArgs());
        }

        public void TriggerStuffToDo()
        {
            if (doStuff != null)
                doStuff();
        }
    }   
}
