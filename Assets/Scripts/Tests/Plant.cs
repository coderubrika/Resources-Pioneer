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

        /*
         с этим уже работать невозможно, потому как слишком много полей и полный фарф, поэтому для начала я пожалуй
        подготовлю 3 здания и 3 префаба 
         */

        private void Start()
        {
            _currentCountOfResources = 100;
            var _  = CreateProduction();
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
                _currentCountOfResources -= 1;
                await Task.Delay((int)(_generationRate * 1000));

                if (!Application.isPlaying) break;

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


                    _currentDepthProd += _depthStep;
                }
                else
                {
                    _currentHeightProd += _heightStep;
                    return new Vector3(_currentWidthProd, _currentHeightProd, _currentDepthProd);
                }

            }
            else
            {
                _currentWidthProd += _widthStep;
                return new Vector3(_currentWidthProd, _currentHeightProd, _currentDepthProd);
            }

            return new Vector3(_currentWidthProd, _currentHeightProd, _currentDepthProd);
        }
    }
}