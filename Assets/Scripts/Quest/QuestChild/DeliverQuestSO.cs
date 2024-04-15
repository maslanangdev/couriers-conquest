using System.Collections.Generic;
using CC.Inventory;
using CC.Quest.Example;
using UnityEngine;

namespace CC.Quest
{
    [CreateAssetMenu(menuName = "Data/Statics/Quest/Deliver Quest")]
    public class DeliverQuestSO : AQuest
    {
        [SerializeField] questPrefab pickupPrefab;
        [SerializeField] questPrefab dropPrefab;
        [SerializeField] questPrefab[] _questPrefabs;

        [SerializeField] ABaseItem itemToDeliver;
        [SerializeField] bool _pickedUp;
        List<GameObject> _instantiatedPrefabs = new();
        public override void OnQuestStarted(Component sender, object data)
        {
            var temp = Instantiate(pickupPrefab.prefab, pickupPrefab.position, Quaternion.identity);
            if (temp != null) _instantiatedPrefabs.Add(temp);
            temp.GetComponent<ExPickupPoint>().Init(itemToDeliver);

            temp = Instantiate(dropPrefab.prefab, dropPrefab.position, Quaternion.identity);
            if (temp != null) _instantiatedPrefabs.Add(temp);
            temp.GetComponent<ExDropPoint>().Init(itemToDeliver);

            foreach (var prefab in _questPrefabs)
            {
                temp = Instantiate(prefab.prefab, prefab.position, Quaternion.identity);
                if (temp != null) _instantiatedPrefabs.Add(temp);
            }

            Debug.Log("quest has started");
        }
        public override void OnQuestProgress(Component sender, object data)
        {
            _pickedUp = true;
            Debug.Log("picked up");
        }
        public override void OnQuestFinished(Component sender, object data)
        {
            clearAllPrefab();
            Debug.Log("quest has finished");
        }
        public override void OnQuestCancelled(Component sender, object data)
        {
            clearAllPrefab();
            Debug.Log("quest has cancelled");
        }

        public void clearAllPrefab()
        {
            if (_instantiatedPrefabs != null)
            {
                foreach (var temp in _instantiatedPrefabs)
                {
                    if (temp != null) Destroy(temp);
                }
                _instantiatedPrefabs.Clear();
            }
            //foreach (GameObject item in GameObject.FindGameObjectsWithTag("PayLoad"))
            //{
            // Destroy(item);
            //}
            //foreach (GameObject item in GameObject.FindGameObjectsWithTag("VPayload"))
            //{
            // item.SetActive(false);
            //}
        }

        public bool IsPickedUp()
        {
            return _pickedUp;
        }
    }

}
