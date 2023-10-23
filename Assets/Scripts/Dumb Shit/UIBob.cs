using UnityEngine;

namespace Dumb_Shit
{
    public class UIBob : MonoBehaviour
    {
        [SerializeField] private float _bobSpeed = 1f;
        [SerializeField] private float _bobHeight = 1f;
    
        private Vector3 _startPosition;

        private void Awake()
        {
            _startPosition = transform.position;
        }

        private void Update()
        {
            // Make it bop up and down
            transform.position = _startPosition + new Vector3(0, Mathf.Sin(Time.time * _bobSpeed) * _bobHeight, 0);
        }
    }
}
