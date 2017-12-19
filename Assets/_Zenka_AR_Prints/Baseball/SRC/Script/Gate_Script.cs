using UnityEngine;
using System.Collections;

public class Gate_Script : MonoBehaviour 
{
    public float timer_Inicio;

    public ParticleSystem ParticleBaseBall;
    public ParticleSystem[] ParticleJetpack;
    public ParticleSystem[] ParticleGate;

    Animator animGate;
    public Animator animBrazo;
    public MeshRenderer[] materialFX_1;
    public float velDestelloLuz;

	void Start () 
    {

	}

	void OnEnable(){
		animGate = GetComponent<Animator>();

		StartCoroutine(LightControl(0));

        /*for (int i = 0; i < ParticleGate.Length; i++)
            ParticleGate[i].enableEmission = false;*/

		ParticleJetpack[0].enableEmission = false;
		ParticleJetpack[1].enableEmission = false;
		
        StartCoroutine(IniciarAnimaciones());

	}

    IEnumerator IniciarAnimaciones()
    {
        yield return new WaitForSeconds(timer_Inicio);
        
        for (int i = 0; i < ParticleGate.Length; i++)
        {

            ParticleGate[i].Play();
        }

        yield return new WaitForSeconds(0.5f);

        animGate.Play("OpenGate");

        yield return new WaitForSeconds(2);
        animBrazo.Play("Inicio");

        Invoke("ActivaParticleJetpack", 8);

        yield return new WaitForSeconds(3);
        ParticleBaseBall.Play();
    }


    IEnumerator LightControl(int anterior)
    {
        
        for (int i = 0; i < materialFX_1.Length; i++)
        {
            materialFX_1[anterior].enabled = false;
            materialFX_1[i].enabled = true;
            anterior = i;

            yield return new WaitForSeconds(velDestelloLuz);
        }

        StartCoroutine(LightControl(anterior));
    }

    void ActivaParticleJetpack()
    {
        ParticleJetpack[0].enableEmission = true;
        ParticleJetpack[1].enableEmission = true;
    }
}
