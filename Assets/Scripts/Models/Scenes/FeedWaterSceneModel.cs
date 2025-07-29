namespace Models.Scenes
{
    public class FeedWaterSceneModel
    {
        private int _feedPerChicken;
        private int _waterPerChicken;
        private int _chickenCount;
        private int _totalFeed => _chickenCount * _feedPerChicken;
        private int _totalWater => _chickenCount * _waterPerChicken;

        public bool CanShowResult => _chickenCount > 0;

        public int FeedPerChicken
        {
            set => _feedPerChicken = value;
        }
        
        public int WaterPerChicken
        {
            set => _waterPerChicken = value;
        }

        public int ChickenCount
        {
            get => _chickenCount;
            set => _chickenCount = value;
        }

        public FeedWaterSceneModel()
        {
            _feedPerChicken = 120;
            _waterPerChicken = 200;
            _chickenCount = 0;
        }

        public string GetFeedText()
        {
            string feedText = "";
            
            if (_feedPerChicken < 1000)
                feedText = $"{_feedPerChicken:0} g";
            else
                feedText = $"{(_feedPerChicken / 1000f):0.##} kg";

            return feedText;
        }
        
        public string GetTotalFeedText()
        {
            string feedText = "";
            
            if (_totalFeed < 1000)
                feedText = $"{_totalFeed:0} g";
            else
                feedText = $"{(_totalFeed / 1000f):0.##} kg";

            return feedText;
        }
        
        public string GetWaterText()
        {
            string waterText = "";
            
            if (_waterPerChicken < 1000)
                waterText = $"{_waterPerChicken:0} ml";
            else
                waterText = $"{(_waterPerChicken / 1000f):0.##} liters";

            return waterText;
        }
        
        public string GetTotalWaterText()
        {
            string waterText = "";
            
            if (_totalWater < 1000)
                waterText = $"{_totalWater:0} ml";
            else
                waterText = $"{(_totalWater / 1000f):0.##} liters";

            return waterText;
        }
    }
}