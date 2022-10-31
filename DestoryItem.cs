
using UnityEngine;
using UnityEngine.InputSystem;

public class DestoryItem : MonoBehaviour
{
    public GameObject itemContainer;
    public ParticleSystem cauldronSmoke;
    public AudioSource poof;



    public void DestroyItem()
    {
        cauldronSmoke.Play(true);
        poof.Play();

        //Destorys item if looking at Cauldron and "E" is pressed
        for (var i = itemContainer.transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(itemContainer.transform.GetChild(i).gameObject);
            PickUpItem.timer = 0;
            PickUpItem.slotFull = false;
            PickUpItemHorror.timer = 0;
            PickUpItemHorror.slotFull = false;
        }
    }
}

