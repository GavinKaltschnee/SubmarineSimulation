using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix : MonoBehaviour
{
    [SerializeField] private int MatrixDensity;
    [SerializeField] private GameObject Mine;
    [SerializeField] private Vector3 Size = new Vector3(0, 0, 0);

    void Start()
    {
        PopulateMatrix();
    }

    private void PopulateMatrix()
    {
        for (int i = 0; i < MatrixDensity; i++)
        {
            for (int j = 0; j < MatrixDensity; j++)
            {
                for (int k = 0; k < MatrixDensity; k++)
                {
                    GameObject _Mine = Instantiate(Mine, new Vector3((i+Size.x), (j + Size.y ), (k + Size.z )), Quaternion.identity);
                }
            }
        }
    }
}

