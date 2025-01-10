using UnityEngine;
using TMPro;

namespace Homework19
{
    public class CounterView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI CountOfAllObjects;
        [SerializeField] private TextMeshProUGUI CountOfAllObjectsOnScene;
        [SerializeField] private TextMeshProUGUI CountOfActiveObjects;

        private ObjectCounter _counter;
        private string _countOfAllObjectsText;
        private string _countOfAllObjectsOnSceneText;
        private string _countOfActiveObjectsText;
            
        public void Initialize(ObjectCounter counter)
        {
            _counter = counter;
            _counter.CounterUpdated += UpdateUI;
            _countOfAllObjectsText = CountOfAllObjects.text;
            _countOfAllObjectsOnSceneText = CountOfAllObjectsOnScene.text;
            _countOfActiveObjectsText = CountOfActiveObjects.text;
        }

        private void OnDisable()
        {
            _counter.CounterUpdated -= UpdateUI;
        }

        private void UpdateUI()
        {
            CountOfAllObjects.text = $"{_countOfAllObjectsText} {_counter.CountOfAllObjects}";
            CountOfAllObjectsOnScene.text = $"{_countOfAllObjectsOnSceneText} {_counter.CountOfAllObjectsOnScene}";
            CountOfActiveObjects.text = $"{_countOfActiveObjectsText} {_counter.CountOfActiveObjects}";
        }
    }
}