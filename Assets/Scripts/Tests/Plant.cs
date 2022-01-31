using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Tests
{
    public class Plant : MonoBehaviour
    {
        [SerializeField] private float _generationRate = 1f;
        [SerializeField] private Resource _resourcePrefab;
        [SerializeField] private Transform _birthOrigin;

        [SerializeField] private Platform _productPlatform;

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

                    _productPlatform.Put(product.GetComponent<Resource>());
                }

                yield return new WaitForSeconds(_generationRate);
            }
        }
        
    }
}