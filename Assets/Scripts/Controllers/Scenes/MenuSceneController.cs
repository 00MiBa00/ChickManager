using Types;
using UnityEngine;
using UnityEngine.UI;
using Views.General;

namespace Controllers.Scenes
{
    public class MenuSceneController : AbstractSceneController
    {
        [SerializeField] private Button _flockTrackerBtn;
        [SerializeField] private Button _reminderBtn;
        [SerializeField] private Button _feedWaterBtn;
        [SerializeField] private Button _eggsBtn;
        [SerializeField] private Button _privacyBtn;
        [SerializeField] private PanelView _privacyPanel;
        protected override void OnSceneEnable()
        {
            
        }

        protected override void OnSceneStart()
        {
            
        }

        protected override void OnSceneDisable()
        {
            
        }

        protected override void Initialize()
        {
            
        }

        protected override void Subscribe()
        {
            _flockTrackerBtn.onClick.AddListener(OnPressFlockTrackerBtn);
            _reminderBtn.onClick.AddListener(OnPressReminderBtn);
            _feedWaterBtn.onClick.AddListener(OnPressFeedWaterBtn);
            _eggsBtn.onClick.AddListener(OnPressEggsBtn);
            _privacyBtn.onClick.AddListener(OpenPrivacyPanel);
        }

        protected override void Unsubscribe()
        {
            _flockTrackerBtn.onClick.RemoveAllListeners();
            _reminderBtn.onClick.RemoveAllListeners();
            _feedWaterBtn.onClick.RemoveAllListeners();
            _eggsBtn.onClick.RemoveAllListeners();
            _privacyBtn.onClick.RemoveAllListeners();
        }

        private void OnPressFlockTrackerBtn()
        {
            base.LoadScene(SceneType.FlockTrackerScene);
        }

        private void OnPressReminderBtn()
        {
            base.LoadScene(SceneType.ReminderScene);
        }

        private void OnPressFeedWaterBtn()
        {
            base.LoadScene(SceneType.FeedWaterScene);
        }

        private void OnPressEggsBtn()
        {
            base.LoadScene(SceneType.EggsScene);
        }

        private void OpenPrivacyPanel()
        {
            _privacyPanel.PressBtnAction += OnReceiveAnswerPrivacyPanel;
            _privacyPanel.Open();
        }

        private void OnReceiveAnswerPrivacyPanel(int answer)
        {
            _privacyPanel.PressBtnAction -= OnReceiveAnswerPrivacyPanel;
            _privacyPanel.Close();
        }
    }
}