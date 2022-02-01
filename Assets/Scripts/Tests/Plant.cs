using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Tests
{
    public class Plant : MonoBehaviour
    {
        [SerializeField] private float _generationRate = 1f;
        private float _timer = 0f;

        [SerializeField] private Resource _resourcePrefab;
        [SerializeField] private Transform _birthOrigin;

        [SerializeField] private Platform _productPlatform;

        public bool ResourceDelivered = false;

        private bool OnResourceDeliveredAndTimeIsUp()
        {
            return ResourceDelivered && _timer >= _generationRate;
        }

        private void Start()
        {
            StartCoroutine(GenerateNewResource());
        }

        private IEnumerator GenerateNewResource()
        {
            while (true)
            {
                if (_productPlatform.HasFreePoints())
                {
                    GameObject product = Instantiate(_resourcePrefab.gameObject, _birthOrigin.position, 
                        _birthOrigin.rotation, _birthOrigin);

                    Resource resource = product.GetComponent<Resource>();

                    ResourceDelivered = false;
                    
                    resource.Init(this, _generationRate);

                    _productPlatform.Put(resource);

                    yield return new WaitUntil(OnResourceDeliveredAndTimeIsUp);

                    _timer = 0f;
                }
                else yield return null;


            }
        }

        private void Update()
        {
            if (ResourceDelivered)
            {
                _timer += Time.deltaTime;
            }
        }

    }
}