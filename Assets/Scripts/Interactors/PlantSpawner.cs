using Assets.Scripts.Core;
using Assets.Scripts.Core.Scriptables;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Interactors
{
    public class PlantSpawner : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Camera playerCam;
        [SerializeField] private Summoner summoner;

        [Header("Properties")]
        [SerializeField] private KeyCode pickUpBind;
        [SerializeField] private KeyCode plantBind;
        [SerializeField] private LayerMask floorLayer;
        [SerializeField] private LayerMask plantsLayer;
        [SerializeField] private float scanDistance;
        [SerializeField] private List<SummonableObjectData> plants = new List<SummonableObjectData>();

        private bool plantIndexValid => selectedPlantIndex >= 0 && selectedPlantIndex < plants.Count;
        private int selectedPlantIndex;

        private void Update()
        {
            if (Input.mouseScrollDelta.y != 0)
            {
                selectedPlantIndex += (int)Input.mouseScrollDelta.y;

                if (selectedPlantIndex >= plants.Count)
                    selectedPlantIndex = 0;
                else if (selectedPlantIndex < 0)
                    selectedPlantIndex = plants.Count - 1;
            }
            if (Input.GetKeyDown(pickUpBind))
            {
                Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, scanDistance, plantsLayer))
                {
                    Plant plant = hit.collider.GetComponent<Plant>();

                    if (plant != null && plant.Ripened)
                        Destroy(plant.gameObject);
                }
            }
            else if (Input.GetKeyDown(plantBind) && plantIndexValid)
            {
                Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, scanDistance, floorLayer))
                {
                    GameObject summonedPlant = summoner.Summon(plants[selectedPlantIndex].Id, hit.point, Quaternion.identity, plantsLayer);

                    if (summonedPlant != null)
                        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), summonedPlant.GetComponent<Collider>());
                }
            }
        }
    }
}