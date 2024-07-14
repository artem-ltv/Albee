using UnityEngine;
using TMPro;

namespace Albee
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreTextDisplay;
        [SerializeField] private ItemsManager _itemManager;

        private int _score;

        private void OnEnable()
        {
            _itemManager.OnItemDeliveredToPlace += OnItemDeliveredToPlaceHandler;
        }

        private void OnDisable()
        {
            _itemManager.OnItemDeliveredToPlace -= OnItemDeliveredToPlaceHandler;
        }

        private void Start()
        {
            _score = 0;

            UpdateScoreDisplay();
        }

        private void OnItemDeliveredToPlaceHandler()
        {
            _score++;

            UpdateScoreDisplay();
        }

        private void UpdateScoreDisplay()
        {
            _scoreTextDisplay.SetText(_score.ToString());
        }
    }
}
