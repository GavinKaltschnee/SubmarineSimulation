using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineMatrix : MonoBehaviour
{
    [SerializeField] private int MatrixDensity;
    [SerializeField] private GameObject Mine;

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
                    GameObject _Mine =Instantiate(Mine, new Vector3((i + Random.Range(-2000, 2000)), (j+ Random.Range(-450,-25)), (k+Random.Range(-2000,2000))), Quaternion.identity);
                    _Mine.transform.parent = this.transform;
                }
            }
        }
    }
}
