using Models.Scenes;
using Types;
using UnityEngine;
using UnityEngine.UI;
using Views.FeedWater;

namespace Controllers.Scenes
{
    public class FeedWaterSceneController : AbstractSceneController
    {
        [SerializeField] private InputField _feedInputField;
        [SerializeField] private InputField _waterInputField;
        [SerializeField] private InputField _chickenCountInputField;
        [SerializeField] private FeedWaterResultView _feedWaterResultView;
        [SerializeField] private Button _backBtn;
        
        private FeedWaterSceneModel _model;
        
        protected override void OnSceneEnable()
        {
            UpdateFeedText();
            UpdateWaterText();
            UpdateChickenCount();
        }

        protected override void OnSceneStart()
        {
            
        }

        protected override void OnSceneDisable()
        {
            
        }

        protected override void Initialize()
        {
            _model = new FeedWaterSceneModel();
        }

        protected override void Subscribe()
        {
            _feedInputField.onEndEdit.AddListener(OnEndEditFeedCount);
            _waterInputField.onEndEdit.AddListener(OnEndEditWaterCount);
            _chickenCountInputField.onValueChanged.AddListener(OnChickenCountValueChanged);
            _backBtn.onClick.AddListener(OnPressBackBtn);
        }

        protected override void Unsubscribe()
        {
            _feedInputField.onEndEdit.RemoveAllListeners();
            _waterInputField.onEndEdit.RemoveAllListeners();
            _chickenCountInputField.onValueChanged.RemoveAllListeners();
            _backBtn.onClick.RemoveAllListeners();
        }

        private void UpdateFeedText()
        {
            _feedInputField.contentType = InputField.ContentType.Standard;
            _feedInputField.text = _model.GetFeedText();
            _feedInputField.contentType = InputField.ContentType.DecimalNumber;
        }
        
        private void UpdateWaterText()
        {
            _waterInputField.contentType = InputField.ContentType.Standard;
            _waterInputField.text = _model.GetWaterText();
            _waterInputField.contentType = InputField.ContentType.Standard;
        }

        private void UpdateChickenCount()
        {
            _chickenCountInputField.text = _model.ChickenCount.ToString();
        }

        private void TryShowResultPanel()
        {
            if (!_model.CanShowResult)
            {
                return;
            }
            
            _feedWaterResultView.UpdateText(_model.ChickenCount, _model.GetTotalFeedText(), _model.GetTotalWaterText());
            _feedWaterResultView.gameObject.SetActive(true);
        }

        private void OnEndEditFeedCount(string input)
        {
            if (int.TryParse(input, out int count))
            {
                _model.FeedPerChicken = count;
                
                TryShowResultPanel();
            }
        }
        
        private void OnEndEditWaterCount(string input)
        {
            if (int.TryParse(input, out int count))
            {
                _model.WaterPerChicken = count;
                
                TryShowResultPanel();
            }
        }

        private void OnChickenCountValueChanged(string input)
        {
            if (int.TryParse(input, out int count))
            {
                _model.ChickenCount = count;

                TryShowResultPanel();

                if (count == 0 && _feedWaterResultView.gameObject.activeSelf)
                {
                    _feedWaterResultView.gameObject.SetActive(false);
                }
            }
        }

        private void OnPressBackBtn()
        {
            base.LoadScene(SceneType.MenuScene);
        }
    }
}