using UnityEngine;
using Models.Scenes;
using Views.FlockTracker;
using Views.General;

namespace Controllers.Scenes
{
    public class FlockTrackerSceneController : AbstractSceneController
    {
        [SerializeField] private AddFlockPanel _addFlockPanel;
        [SerializeField] private FlockTrackerMainPanel _flockTrackerMainPanel;
        
        private FlockTrackerSceneModel _model;
        
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
            _model = new FlockTrackerSceneModel();
        }

        protected override void Subscribe()
        {
            
        }

        protected override void Unsubscribe()
        {
            
        }

        private void OpenAddFlockPanel()
        {
            _model.ResetFlock();

            _addFlockPanel.PressBtnAction += OnReceiveAnswerAddFlockPanel;
            _addFlockPanel.OnInputCountAction += OnChangedCount;
            _addFlockPanel.OnSelectedBreedAction += OnChangedBreeds;
            
            OpenPanel(_addFlockPanel);
        }

        private void OpenMainPanel()
        {
            _flockTrackerMainPanel.PressBtnAction += OnReceiveAnswerMainPanel;
            _flockTrackerMainPanel.OnPressDeleteBtnAction += OnPressDeleteBtn;
            
            _flockTrackerMainPanel.SetInfo(_model.FlockItemModels);
            
            OpenPanel(_flockTrackerMainPanel);
        }

        private void OnReceiveAnswerAddFlockPanel(int answer)
        {
            _addFlockPanel.PressBtnAction -= OnReceiveAnswerAddFlockPanel;
            _addFlockPanel.OnInputCountAction -= OnChangedCount;
            _addFlockPanel.OnSelectedBreedAction -= OnChangedBreeds;
            
            _model.SaveFlock();
            
            ClosePanel(_addFlockPanel);
            OpenMainPanel();
        }

        private void OnReceiveAnswerMainPanel(int answer)
        {
            _flockTrackerMainPanel.PressBtnAction -= OnReceiveAnswerMainPanel;
            _flockTrackerMainPanel.OnPressDeleteBtnAction -= OnPressDeleteBtn;

            switch (answer)
            {
                case 0:
                    break;
                default:
                    ClosePanel(_flockTrackerMainPanel);
                    OpenAddFlockPanel();
                    break;
            }
        }

        private void OnChangedCount(int count)
        {
            _model.SetFlockCount(count);
        }

        private void OnChangedBreeds(int index)
        {
            _model.SetFlockBreed(index);
        }

        private void OpenPanel(PanelView view)
        {
            view.Open();
        }

        private void ClosePanel(PanelView view)
        {
            view.Close();
        }

        private void OnPressDeleteBtn(int index)
        {
            _model.DeleteFlockItem(index);
            _flockTrackerMainPanel.SetInfo(_model.FlockItemModels);
        }
    }
}