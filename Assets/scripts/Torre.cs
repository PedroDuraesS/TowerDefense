using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour {

	[SerializeField] private GameObject prefabDoMissil;
	[SerializeField] private float tempoDeRecarga = 2f;
	[SerializeField] private float raioDeAlcance = 200f;
	private float momentoUltimoDisparo;

	void Update(){
		Inimigo alvo = EscolheAlvo();
		if (alvo){
			Atira(alvo);
		}
	}

	private void Atira(Inimigo inimigo){
		float tempoAtual = Time.time;
		//para as torres atirarem cada uma com seu comportamentos
		Transform pontodedisparo = this.transform.Find("CanhaoDaTorre/PontoDeDisparo");
		Vector3 posicao = pontodedisparo.transform.position;

		if (tempoAtual > momentoUltimoDisparo + tempoDeRecarga) {
			momentoUltimoDisparo = tempoAtual;
			GameObject missilObject = 
				(GameObject) Instantiate (prefabDoMissil, posicao, transform.rotation);
			Missil missil = missilObject.GetComponent<Missil>();
			missil.DefineAlvo(inimigo);
		}
	}

	private Inimigo EscolheAlvo(){
		GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");
		foreach (GameObject inimigo in inimigos) {
			if (EstaNoRaioDeAlcance(inimigo)){
				return inimigo.GetComponent<Inimigo>();
			}
		}
		return null;
	}

	private bool EstaNoRaioDeAlcance(GameObject inimigo){

		Vector3 posicaoInimigo = 
			Vector3.ProjectOnPlane (inimigo.transform.position, Vector3.up);
		Vector3 posicaoTorre = 
			Vector3.ProjectOnPlane (this.transform.position, Vector3.up);
		
		float distancia = Vector3.Distance (posicaoTorre, posicaoInimigo);

		return distancia <= raioDeAlcance;

	}

}