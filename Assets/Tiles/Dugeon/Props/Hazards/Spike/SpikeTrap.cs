using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    Animator spike;
    HealthPlayer healthPlayer;
    public bool dealDamgage;

    // Start is called before the first frame update
    void Start()
    {
        spike = GetComponent<Animator>();
        healthPlayer = FindObjectOfType<HealthPlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator  getHit()
    {
        yield return new WaitForSeconds(1);
        if (dealDamgage == true)
        {
            Debug.Log("Yes");
            healthPlayer.Health -= 10;
        }
        else if (dealDamgage == false)
        {
            Debug.Log("No");
            yield return null;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Invoke("stepIn",1f);
            dealDamgage = true;
            StartCoroutine(getHit());
        }    
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Invoke("stepOut",1f);
            dealDamgage = false;
        }
    }

    private void stepIn()
    {
        spike.SetBool("stepIn", true);
        
    }
    
    private void stepOut()
    {
        spike.SetBool("stepIn", false);
    }

    
}
