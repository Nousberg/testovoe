using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class Summoner : MonoBehaviour
    {
        [SerializeField] private List<Summonable> summonables = new List<Summonable>();

        public GameObject Summon(int id, Vector3 pos, Quaternion rot, LayerMask layer)
        {
            Summonable findedObject = summonables.Find(n => n.data.Id == id);

            if (findedObject != null)
            {
                GameObject summonedObj = Instantiate(findedObject.gameObject, pos, rot);
                summonedObj.layer = (int)Mathf.Log(layer.value, 2);

                return summonedObj;
            }

            return null;
        }
    }
}