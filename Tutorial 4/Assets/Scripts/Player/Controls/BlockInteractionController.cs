using UnityEngine;
using System.Collections;

public class BlockInteractionController : MonoBehaviour
{
    public float max_distance = 0.5f;
    public GameObject highlight_object;

    public bool remove_mode = false;

    private Block current_selected;

    // Updates current block to be selected
    private void Update()
    {
        Ray r = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hitInfo;

        bool hit = Physics.Raycast(r, out hitInfo, max_distance) && hitInfo.collider.tag == "Block";
        if (hit)
        {
            current_selected = hitInfo.collider.GetComponent<Block>();
            highlight_object.transform.position = current_selected.transform.position + (remove_mode ? 0.0f : 1.0f)* current_selected.transform.localScale.y* current_selected.transform.up;
            highlight_object.transform.rotation = current_selected.transform.rotation;
        }
        else
        {
            current_selected = null;
        }
        highlight_object.SetActive(hit);
    }

    public bool RemoveSelectedBlock()
    {
        if(current_selected == null)
        {
            Debug.Log("Tried to remove block, but nothing selected");
            return false;
        }
        
        return BlockManager.getInstance().RemoveBlock(current_selected.grid_position);
    }

    public bool AddBlock(string ressource_id)
    {
        if (current_selected == null)
        {
            Debug.Log("Tried to add block, but no base underneath to add");
            return false;
        }

        return BlockManager.getInstance().AddBlock(ressource_id ,current_selected.grid_position + current_selected.transform.localScale.y * current_selected.transform.up);
    }

    private void OnDrawGizmos()
    {
        Ray r = new Ray(this.transform.position, this.transform.forward);
        Gizmos.DrawRay(r.origin, r.direction * max_distance);
    }


}
