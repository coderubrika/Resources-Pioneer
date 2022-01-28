using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tests
{
    public class Plant : MonoBehaviour
    {
        [SerializeField] private float _generationRate = 1f;

        [SerializeField] private float _maxWidth, _maxHeight, _maxDepth;
        
        [SerializeField] private float _widthStep, _heightStep, _depthStep;

        [SerializeField] private Transform _productionPoint;
        [SerializeField] private GameObject _productionPrefab;
        [SerializeField] private int _maxCountOfProduct;
        [SerializeField] private int _currentCountOfProduct;
        [SerializeField] private float _currentWidthProd = 0f, _currentHeightProd = 0f, _currentDepthProd = 0f;

        [SerializeField] private Transform _resourcesPoint;
        [SerializeField] private GameObject __resourcePrefab;
        [SerializeField] private int _maxCountOfResources;
        [SerializeField] private int _currentCountOfResources;
        [SerializeField] private float _currentWidthRes = 0f, _currentHeightRes = 0f, _currentDepthRes = 0f;

        private void Start()
        {
            // здесь можно запустить корутину
        }

        private async Task CreateProduction()
        {
            while (_currentCountOfResources > 0)
            {
                //Addressables.InstantiateAsync for future
                Instantiate(
                    _productionPrefab, 
                    _productionPoint.position + GetProductPositionDelta(), 
                    Quaternion.identity
                );
            }
        }

        private Vector3 GetProductPositionDelta()
        {
            if ((_currentWidthProd + _widthStep) > _maxWidth)
            {
                _currentWidthProd = 0f;

                if ((_currentDepthProd + _depthStep) > _maxDepth)
                {
                    _currentDepthProd = 0f;

                    _currentHeightProd += _depthStep;
                }
                else _currentDepthProd += _depthStep;

            }
            else _currentWidthProd += _widthStep;

            Vector3 delta = new Vector3(_currentWidthProd, _currentHeightProd, _currentDepthProd);
            return delta;
        }
    }
}