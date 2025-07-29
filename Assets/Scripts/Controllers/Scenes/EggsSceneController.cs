using Models.Scenes;
using Types;
using UnityEngine;
using UnityEngine.UI;
using Views.Eggs;

namespace Controllers.Scenes
{
    public class EggsSceneController : AbstractSceneController
    {
        [SerializeField] private InputField _inputField;
        [SerializeField] private LastDaysBodyView _lastDaysBodyView;
        [SerializeField] private Button _backBtn;
        
        private EggsSceneModel _model;
        
        protected override void OnSceneEnable()
        {
            UpdateLastDaysBody();
        }

        protected override void OnSceneStart()
        {
            
        }

        protected override void OnSceneDisable()
        {
            
        }

        protected override void Initialize()
        {
            _model = new EggsSceneModel();
        }

        protected override void Subscribe()
        {
            _inputField.onEndEdit.AddListener(OnEndEdit);
            _backBtn.onClick.AddListener(OnPressBackBtn);
        }

        protected override void Unsubscribe()
        {
            _inputField.onEndEdit.RemoveAllListeners();
            _backBtn.onClick.RemoveAllListeners();
        }

        private void OnEndEdit(string input)
        {
            if (int.TryParse(input, out int count))
            {
                _model.AddEggs(count);
            }
            
            UpdateLastDaysBody();
        }

        private void UpdateLastDaysBody()
        {
            _lastDaysBodyView.SetInfo(_model.Load());
        }

        private void OnPressBackBtn()
        {
            base.LoadScene(SceneType.MenuScene);
        }
    }
}