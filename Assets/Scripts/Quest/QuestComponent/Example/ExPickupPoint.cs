using CC.Event;
using CC.Events;
using CC.Inventory;
using UnityEngine;
using CC.NPC;
using System.Collections.Generic;


namespace CC.Quest.Example
{
    public class ExPickupPoint : MonoBehaviour
    {
        [SerializeField] SenderDataEventChannelSO _onPickup;
        [SerializeField] ItemInventoryEventChannel _addItemToInventory;
        [SerializeField] List<NPCQuestDialogueNodeTransfer> _nextNpcList;
        [SerializeField] SenderDataEventChannelSO SendNPCQuestDialogue;
        [ReadOnly] QuestManager _manager;

        [ReadOnly] ABaseItem _itemToDeliver;
        bool _isPickup;

        private void Start()
        {
            _manager = FindObjectOfType<QuestManager>();
        }

        public void Init(ABaseItem _itemToDeliver)
        {
            this._itemToDeliver = _itemToDeliver;
        }
        public void doPickup()
        {
            if(_isPickup) return;
            _isPickup = true;
            _onPickup?.raiseEvent(this, null);
            foreach(var npc in _nextNpcList) SendNPCQuestDialogue?.raiseEvent(this, npc);
            _addItemToInventory.RaiseEvent(_itemToDeliver, 1);
            // Destroy(gameObject);
        }
    }
}
