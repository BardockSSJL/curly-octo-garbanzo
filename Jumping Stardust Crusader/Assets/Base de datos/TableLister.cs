using System;
using System.Data;
using System.Data.SqlClient;
using UnityEngine;

public class TableLister : MonoBehaviour
{
    public string connectionString = "Data Source=172.16.202.209;Initial Catalog=ProyectoToDoList;User ID=JuegosUnity;Password=JuegosUnityProyecto2023";

    private void Start()
    {
        ListTables();
    }

    private void ListTables()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            DataTable schema = connection.GetSchema("Tables");

            foreach (DataRow row in schema.Rows)
            {
                string tableName = row["TABLE_NAME"].ToString();
                Debug.Log("Tabla encontrada: " + tableName);
            }
        }
    }
}
