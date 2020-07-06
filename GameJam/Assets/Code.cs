using System.Collections.Generic;
using UnityEngine;

public class Code : MonoBehaviour {
   public bool completed;
   [SerializeField] private List<Platform> Cubes;
   [SerializeField]private GameObject gameObject;

   private void Update() {
      if (Input.GetKeyDown(KeyCode.E) && !completed) {
         CheckWin();
      }
   }

   private void CheckWin() {
      foreach (Platform cube in Cubes) {
         if ((cube.solution && !cube.isActive || (!cube.solution && cube.isActive))){
            DisableCubes();
            return;
         }
      }
      Win();
   }

   private void Win() {
      completed = true;
      gameObject.SetActive(true);
   }
   

   public void DisableCubes() {
      foreach (Platform platform in Cubes) {
         platform.Disable();
      }
   }
}
