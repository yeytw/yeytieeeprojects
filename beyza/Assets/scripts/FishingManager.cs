using UnityEngine;
using TMPro;

public class FishingManager : MonoBehaviour
{
    public GameObject fishPrefab;
    public Animator animator;
    private bool isfishing = false;
    private float fishTimer = 5f;
    private float timer = 0f;
    public float fishcount = 0f;

    public PlayerMovement pmn;
    public TMP_Text fishcounter;

    private GameObject fishplayerholds;

    
    void Update()
    {
        if (pmn.playercanfish)
        {
            if (isfishing)
            {
                timer += Time.deltaTime;
                animator.SetBool("Startfishing", isfishing);

                if (timer >= fishTimer && Input.GetKeyDown(KeyCode.M))
                {
                    GetFish();
                }
            }
            else
            { animator.SetBool("Startfishing", isfishing); }

            if (Input.GetKeyDown(KeyCode.N) && !isfishing)
            {
                StartFishing();
            }
        }else
        { 
            animator.SetBool("FishIdle", false);
            animator.SetBool("Startfishing", false);
            animator.SetBool("Walk", pmn.walking);
        }

        if (fishplayerholds != null)
        {
            fishplayerholds.transform.position = pmn.transform.position;
        }

        if (pmn.sellingstand)
        {
            SellFish();
        }

        
    }

    void StartFishing()
    {
        timer = 0f;
        isfishing = true;
        animator.SetBool("Startfishing", true);
        animator.SetBool("FishIdle", false);


    }

    void GetFish()
    {
        fishplayerholds = Instantiate(fishPrefab, pmn.transform.position, Quaternion.identity);

        isfishing = false;
        animator.SetBool("Startfishing", false);
        animator.SetBool("FishIdle", true);
        fishcount ++;

        fishplayerholds.transform.SetParent(transform);
        FishText();
    }

    void SellFish()
    {
        fishplayerholds.transform.SetParent(null);
        fishplayerholds = null;
    }

    void FishText()
    {
        fishcounter.text = "Fish Count: " + fishcount;
    }
}
