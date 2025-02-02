using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This class is used for Events that have no arguments (Example: Exit game event)
/// </summary>

namespace CC.Events
{
    [CreateAssetMenu(menuName = "Game/Events/Void Event Channel")]
    public class VoidEventChannelSO : DescriptionBaseSO
    {
        public UnityAction OnEventRaised;

        public void RaiseEvent()
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke();
        }
    }

}


