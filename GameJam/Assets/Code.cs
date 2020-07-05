using System.Collections.Generic;
using UnityEngine;

public class Code : MonoBehaviour {
   [SerializeField] private List<Platform> Cubes;

   private void Update() {
      if (Input.GetKeyDown(KeyCode.E)) {
         CheckWin();
      }
   }

   public void CheckWin() {
      foreach (Platform cube in Cubes) {
         if ((cube.solution && !cube.isActive || (!cube.solution && cube.isActive))){
            DisableCubes();
            return;
         }
      }
   }
   

   public void DisableCubes() {
      foreach (Platform platform in Cubes) {
         platform.Disable();
      }
   }
}
