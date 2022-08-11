using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogo : MonoBehaviour {

	[SerializeField] private GameObject torrePrefab;
	[SerializeField] private GameObject gameOver;
	[SerializeField] private DadosDoJogador jogador;

	void Start(){
		gameOver.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (JogoAcabou ()) {
			gameOver.SetActive (true);
		} else {
			if (Clicou ()) {
				CriaTorre ();
			}
		}
	}

	private bool JogoAcabou(){
		return !jogador.EstaVivo ();
	}

	private bool Clicou(){
		return Input.GetMouseButtonDown(0); //0 é esquerda, 1 direita, 2 central
	}

	public void RecomecaJogo(){
		Application.LoadLevel (Application.loadedLevel); 
		/*O nível do jogo é a cena que estamos trabalhando.
		 * Como só temos uma cena, podemos recarregar a cena 
		 * Esse método será o OnClick do botão do gameOver */

	}

	private void CriaTorre(){
		//criar torre
		Vector3 pontoDoClique = Input.mousePosition;

		Ray raioDaCamera = Camera.main.ScreenPointToRay (pontoDoClique);
		RaycastHit infoDoRaio;
		float comprimentoMaximo = 1000f;
		Physics.Raycast (raioDaCamera, out infoDoRaio, comprimentoMaximo);

		if (infoDoRaio.collider) {
			Vector3 posicao = infoDoRaio.point;
			Instantiate (torrePrefab, posicao, Quaternion.identity);
		}
	}
}
