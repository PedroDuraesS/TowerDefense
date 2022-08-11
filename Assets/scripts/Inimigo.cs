using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inimigo : MonoBehaviour {

	public int vida = 100;

	// Use this for initialization
	void Start () {
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		GameObject fim = GameObject.Find ("FimDoCaminho");
		Vector3 posicaodofim = fim.transform.position;
		agent.SetDestination (posicaodofim);
	}

	public void RecebeDano(int pontosDeDano){

		vida -= pontosDeDano;

		if (vida <= 0) {
			Destroy(this.gameObject);
		}
	}
}