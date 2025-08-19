using System;
using Types;
using UnityEngine;

namespace SO.General
{
    [CreateAssetMenu(menuName="FlockSeason/SeasonSprites")]
    public class SeasonSprites : ScriptableObject
    {
        [SerializeField] private Sprite winter;
        [SerializeField] private Sprite spring;
        [SerializeField] private Sprite summer;
        [SerializeField] private Sprite autumn;

        public Sprite Get(SeasonType type) => type switch
        {
            SeasonType.Winter => winter,
            SeasonType.Spring => spring,
            SeasonType.Summer => summer,
            SeasonType.Autumn => autumn,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}