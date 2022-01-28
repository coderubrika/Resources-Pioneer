using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Assets.Scripts.UI
{
    public class ImageFadeInOut : MonoBehaviour
    {
        [SerializeField] private bool _hideOnAwake;

        private void Awake()
        {
            if (_hideOnAwake)
            {
                foreach (var image in _images)
                {
                    image.color = new Color(1f, 1f, 1f, 0f);
                }
            }
        }

        [SerializeField] private Image[] _images;
        [SerializeField] private float _duration;
        public void FadeTo(float value)
        {
            foreach (var image in _images)
            {
                image.DOFade(value, _duration);
            }
        }
    }
}