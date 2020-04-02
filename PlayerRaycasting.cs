using UnityEngine;
using UnityEngine.UI;

public class PlayerRaycasting : MonoBehaviour
{
    public float distanceToSee;
    RaycastHit hitTarget;
    public GameObject interactHover;
    public GameObject textBox;
    public MouseLook cameraMovement;
    public PlayerMovement movement;

    // Update is called once per frame
    void Update()
    {
        // this.transform references the position of the game object that this is attached to
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

        // out takes the collider information and puts the target of the Raycast in the hitTarget variable
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hitTarget, distanceToSee, 9))
        {
            if (hitTarget.collider.gameObject.tag == "Readable" || hitTarget.collider.gameObject.tag == "Item")
            { 
                interactHover.SetActive(true);
                interactHover.GetComponent<Text>().text = hitTarget.collider.gameObject.name;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (hitTarget.collider.gameObject.tag == "Readable")
                    {
                        cameraMovement.enabled = false;
                        movement.enabled = false;
                        textBox.SetActive(true);
                        hitTarget.collider.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                    }
                    else if (hitTarget.collider.gameObject.tag == "Item")
                    {
                        hitTarget.collider.gameObject.GetComponent<ItemPickup>().PickUp();
                    }
                }
            }
        }
        else
        {
            interactHover.SetActive(false);
        }
    }
}

// A raycast returns a true or false value if it's touching a collider
