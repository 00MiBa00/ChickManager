using Models.Scenes;
using Types;
using UnityEngine;
using Views.General;
using Views.Reminder;

namespace Controllers.Scenes
{
    public class ReminderSceneController : AbstractSceneController
    {
        [SerializeField] private AddReminderPanel _addReminderPanel;
        [SerializeField] private ReminderMainPanel _reminderMainPanel;
        [SerializeField] private ReminderCounterView _reminderCounterView;

        private ReminderSceneModel _model;
        
        protected override void OnSceneEnable()
        {
            OpenMainPanel();
        }

        protected override void OnSceneStart()
        {
            
        }

        protected override void OnSceneDisable()
        {
            
        }

        protected override void Initialize()
        {
            _model = new ReminderSceneModel();
        }

        protected override void Subscribe()
        {
            
        }

        protected override void Unsubscribe()
        {
            
        }

        private void OpenAddReminderPanel()
        {
            _addReminderPanel.PressBtnAction += OnReceiveAnswerAddReminderPanel;
            _addReminderPanel.OnPressSaveBtnAction += OnPressSaveBtn;
            
            OpenPanel(_addReminderPanel);
        }

        private void OpenMainPanel()
        {
            _reminderMainPanel.PressBtnAction += OnReceiveAnswerMainPanel;
            _reminderMainPanel.OnPressDeleteItemBtnAction += OnPressDeleteBtn;
            _reminderMainPanel.OnToggleValueChangedAction += OnToggleChanged;
            
            _reminderMainPanel.SetInfo(_model.ReminderDatas);
            
            UpdateReminderCounter();
            OpenPanel(_reminderMainPanel);
        }

        private void CloseAddReminderPanel()
        {
            _addReminderPanel.PressBtnAction -= OnReceiveAnswerAddReminderPanel;
            _addReminderPanel.OnPressSaveBtnAction -= OnPressSaveBtn;
            
            ClosePanel(_addReminderPanel);
        }

        private void CloseMainPanel()
        {
            _reminderMainPanel.PressBtnAction -= OnReceiveAnswerMainPanel;
            _reminderMainPanel.OnPressDeleteItemBtnAction -= OnPressDeleteBtn;
            _reminderMainPanel.OnToggleValueChangedAction -= OnToggleChanged;
            
            ClosePanel(_reminderMainPanel);
        }

        private void OnPressDeleteBtn(int index)
        {
            _model.DeleteItem(index);
            
            _reminderMainPanel.SetInfo(_model.ReminderDatas);
        }

        private void OnReceiveAnswerMainPanel(int answer)
        {
            switch (answer)
            {
                case 0:
                    CloseMainPanel();
                    base.LoadScene(SceneType.MenuScene);
                    break;
                case 1:
                    CloseMainPanel();
                    OpenAddReminderPanel();
                    break;
                case 2:
                    _model.ResetStates();
                    _reminderMainPanel.SetInfo(_model.ReminderDatas);
                    break;
            }
        }

        private void OnReceiveAnswerAddReminderPanel(int answer)
        {
            CloseAddReminderPanel();
            OpenMainPanel();
        }

        private void OnPressSaveBtn(string value)
        {
            _model.AddItem(value);
            
            CloseAddReminderPanel();
            OpenMainPanel();
        }

        private void OnToggleChanged(int index)
        {
            _model.ChangeToggleState(index);
            
            UpdateReminderCounter();
        }

        private void OpenPanel(PanelView view)
        {
            view.Open();
        }

        private void ClosePanel(PanelView view)
        {
            view.Close();
        }

        private void UpdateReminderCounter()
        {
            _reminderCounterView.UpdateCount(_model.CountTrue(), _model.DatasCount);
        }
    }
}