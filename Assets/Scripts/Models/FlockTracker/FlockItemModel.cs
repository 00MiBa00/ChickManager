using System;
using Types;

namespace Models.FlockTracker
{
    [Serializable]
    public class FlockItemModel
    {
        public int _count;
        private int _breedTypeId = 0;

        public BreedsChickensType BreedType
        {
            get => (BreedsChickensType)_breedTypeId;
            set => _breedTypeId = (int)value;
        }
    }
}