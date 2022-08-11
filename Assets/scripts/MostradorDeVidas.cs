using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostradorDeVidas : MonoBehaviour {

	private Text campoTexto;
	public DadosDoJogador jogador;

	void Start () {
		campoTexto = GetComponent<Text> ();
	}

	void Update () {
		/*Para pegarmos a vida do Jogador precisamos criar um novo GameObject Vazio para carregarmos
			essas informações.
		*/
		campoTexto.text = "   Vida: " + jogador.GetVida ();
	}
}