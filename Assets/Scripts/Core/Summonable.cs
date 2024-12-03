using Assets.Scripts.Core.Scriptables;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public abstract class Summonable : MonoBehaviour
    {
        [field: SerializeField] public SummonableObjectData data { get; private set; }
    }
}