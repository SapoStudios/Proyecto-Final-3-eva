using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

public class ShootController : MonoBehaviour, IMixedRealityPointerHandler
{
    public GameObject balaPrefab; // Prefab de la bala
    public float velocidadBala = 10f; // Velocidad de la bala
    public Transform posicionObjetivo;
    private bool isFocused = false;

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        // No necesitas implementar este método para detectar el hover
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        // No necesitas implementar este método para detectar el hover
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        // Verificar si el evento se originó desde un collider
        if (eventData.Pointer.Result?.CurrentPointerTarget != null)
        {
            // Verificar si el objeto con el que el cursor está colisionando tiene un collider
            Collider collider = eventData.Pointer.Result.CurrentPointerTarget.GetComponent<Collider>();
            if (collider != null)
            {
                    // Instanciamos la bala en la posición del objeto especificado como objetivo
                    GameObject bala = Instantiate(balaPrefab, posicionObjetivo.position, Quaternion.identity);

                    // Calculamos la dirección hacia la que se moverá la bala
                    Vector3 direccion = (posicionObjetivo.position - transform.position).normalized;

                    // Asignamos velocidad a la bala multiplicando la dirección por la velocidad
                    bala.GetComponent<Rigidbody>().velocity = direccion * velocidadBala;
                }
            }
        }


    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        // No necesitas implementar este método para detectar el hover
    }

    public void OnPointerHovered(MixedRealityPointerEventData eventData)
    {
        Debug.Log("tocado");


    }
}
