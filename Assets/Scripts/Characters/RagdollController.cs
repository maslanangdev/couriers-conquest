using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

namespace CC.Ragdoll
{
    public class RagdollController : MonoBehaviour
    {
        [SerializeField] Animator _animator;
        [SerializeField] LayerMask includeLayer;
        [SerializeField] LayerMask excludeLayer;
        [SerializeField] bool _isTesting = false;
        LayerMask _weaponMask = 1 << 16;
        Rigidbody[] rigidbodies;
        Collider[] colliders;
        void Awake()
        {
            rigidbodies = GetComponentsInChildren<Rigidbody>();
            colliders = GetComponentsInChildren<Collider>();
            Initialize();
        }

        public void Initialize()
        {
            if (!_isTesting) SetRagdoll(false, true, true);
            else SetRagdoll(true, false, true);

        }

        public void SetRagdoll(bool state, bool animatorState, bool isFirstTime = false)
        {
            foreach (var rb in rigidbodies)
            {
                rb.isKinematic = !state;
                if (((1 << rb.gameObject.layer) & _weaponMask) == 0 && isFirstTime)
                {
                    rb.includeLayers = includeLayer;
                    rb.excludeLayers = excludeLayer;
                }
            }

            foreach (var col in colliders)
            {
                col.enabled = state;
            }

            _animator.enabled = animatorState;
        }
    }
}
