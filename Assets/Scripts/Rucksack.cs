using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Rucksack : Platform
    {
        public override bool Put(Resource resource)
        {
            if (base.Put(resource))
            {
                resource.transform.Rotate(new Vector3(0f, 0f, 90f), Space.Self);
                return true;
            }
            return false;
        }
    }
}