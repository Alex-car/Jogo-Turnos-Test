/*
using UnityEngine;
using System.Collections;

public class QuadradosToque : MonoBehaviour {
	
	string texto = "Vazio";
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		RaycastHit ray = Camera.main.ScreenPointToRay (Input.GetTouch(0).position);
		
		if(Physics.Raycast(ray,hit,1000)){
  if(hit.collider.gameObject ==this.gameObject){
   
   switch (touch.phase) {
   
    case TouchPhase.Began: // se o toque começar
    texto = "tocou no objeto"; 
       break;
    
      case TouchPhase.Moved: // se o toque começar
        texto = "arrastou o dedo no objeto"; 
      break;
   
   }
	
	}
		}
	}
}

*/
