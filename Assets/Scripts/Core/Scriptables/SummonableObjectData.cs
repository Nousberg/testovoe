using UnityEngine;

namespace Assets.Scripts.Core.Scriptables
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Summonables/Data")]
    public class SummonableObjectData : ScriptableObject
    {
        [field: SerializeField] public int Id { get; private set; }
    }
}