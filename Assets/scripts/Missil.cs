using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missil : MonoBehaviour {

	[SerializeField] private float velocidade = 80f;
	[SerializeField] private int dano = 20;

	private Inimigo alvo;

	void Start(){
		AutoDestroy(20);
	}

	private void AutoDestroy(float seg){
		Destroy(this.gameObject, seg);
	}

	// Update is called once per frame
	void Update () {
		Anda();
		AlteraDirecao ();
	}

	void Anda(){
		Vector3 posicaoAtual = transform.position;
		Vector3 frente = transform.forward;
		Vector3 deslocamento = frente * velocidade * Time.deltaTime;

		transform.position = posicaoAtual + deslocamento;
	}

	private void AlteraDirecao(){
		Vector3 direcaoDoMissil = transform.position;

		
		if (alvo) {
			Vector3 direcaoDoInimigo = alvo.transform.position;

			Vector3 novaDirecao = direcaoDoInimigo - direcaoDoMissil;

			transform.rotation = Quaternion.LookRotation (novaDirecao);
		}
	}

	private void OnTriggerEnter(Collider elementoColidido){
		if (elementoColidido.CompareTag("Inimigo")) {
			Destroy(this.gameObject);

			Inimigo inimigo = elementoColidido.GetComponent<Inimigo>();

			inimigo.RecebeDano(dano);
		}
	}

	public void DefineAlvo(Inimigo inimigo){
		alvo = inimigo;
	}
}