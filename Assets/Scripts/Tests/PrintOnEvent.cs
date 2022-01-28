using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Tests
{
    public class PrintOnEvent : MonoBehaviour
    {
        public void PrintMessage(string msg)
        {
            print(msg);
        }
        public void PrintMessage(int msg)
        {
            print(msg);
        }
        public void PrintMessage(float msg)
        {
            print(msg);
        }
        public void PrintMessage(Vector2 msg)
        {
            print(msg);
        }
        public void PrintMessage(Vector3 msg)
        {
            print(msg);
        }


    }
}