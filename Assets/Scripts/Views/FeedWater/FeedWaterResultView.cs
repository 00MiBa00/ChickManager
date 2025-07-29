using UnityEngine;
using UnityEngine.UI;

namespace Views.FeedWater
{
    public class FeedWaterResultView : MonoBehaviour
    {
        [SerializeField] private Text _text;

        public void UpdateText(int chickenCount, string feedText, string waterText)
        {
            _text.text = $"For {chickenCount} chicken(s) you will need {feedText} of feed and {waterText} of water.";
        }
    }
}