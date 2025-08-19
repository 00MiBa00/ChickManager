using System.Collections;
using SO.General;
using Types;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utility.General;

namespace Controllers.Scenes
{
    public abstract class AbstractSceneController : MonoBehaviour
    {
        [SerializeField] private Image _bgImage;
        [SerializeField] private SeasonSprites _sprites;
        
        private void OnEnable()
        {   
            Initialize();
            Subscribe();
            OnSceneEnable();
            
            UpdateBackground();
        }

        private void Start()
        {
            OnSceneStart();
        }

        private void OnDisable()
        {   
            Unsubscribe();
            OnSceneDisable();
        }

        protected abstract void OnSceneEnable();
        protected abstract void OnSceneStart();
        protected abstract void OnSceneDisable();
        protected abstract void Initialize();
        protected abstract void Subscribe();
        protected abstract void Unsubscribe();

        protected void LoadScene(SceneType type)
        {
            StartCoroutine(DelayLoadScene(type.ToString()));
        }

        private void UpdateBackground()
        {
            SeasonType type = SeasonUtility.FromDate();
            _bgImage.sprite = _sprites.Get(type);
        }

        private IEnumerator DelayLoadScene(string sceneName)
        {
            yield return new WaitForSecondsRealtime(0.3f);

            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }

            SceneManager.LoadScene(sceneName);
        }
    }
}