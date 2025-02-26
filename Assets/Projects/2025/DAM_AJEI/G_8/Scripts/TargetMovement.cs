using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EntilandVR.DosCinco.DAM_AJEI.G_Ocho
{
    public class TargetMovement : MonoBehaviour
    {
        public float moveSpeed = 1f;
        public List<Transform> pathPoints;
        private Rigidbody rb;
        private Vector3 targetPosition;
        private int currentPointIndex = 0;

        //Recogemos referencia al componente de la diana
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Utilizamos FixedUpdate en lugar de Update para actualizar la posicion ya que, al ser un objecto con rigidbody,
        // su movimiento es actualizado/influenciado por las físicas
        // Las físicas se ejecutan antes de la "lógica" del script (Update)
        void FixedUpdate()
        {
            targetPosition = pathPoints[currentPointIndex].position;
            // FixedDeltaTime es el DeltaTime del loop de Fisicas de Unity, distinto al de la logica (DeltaTime).
            // Lo uso porque estamos en un Fixed update y por tanto si dejásemos el deltaTime normal sería mas lento
            // y causaría errores al interactuar con el sistema de fisicas como la bala o el target.
            Vector3 newPosition = Vector3.Lerp(rb.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPosition);

            //MOVIMIENTO TARGETS
            // Si estamos lo suficiente cerca de un pathPoint, asignamos el siguiente para ir hacia el. 
            if (Vector3.Distance(rb.position, targetPosition) < 0.1f)
            {
                currentPointIndex++;
                if (currentPointIndex >= pathPoints.Count)
                {
                    currentPointIndex = 0;
                }
            }
        }
    }
}