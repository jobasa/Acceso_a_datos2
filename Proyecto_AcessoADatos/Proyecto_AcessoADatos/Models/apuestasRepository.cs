﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Proyecto_AcessoADatos.Models
{
    public class apuestasRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=mydb;Uid=root;password=none;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<apuestas> Retrieve()
        {
            //Devuelve todos los registros
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuestas";

            try { 
            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            apuestas a = null;

                //Cada vez que ecuentra un objeto lo añade al list
                List<apuestas> apuesta = new List<apuestas>();

                //Devolver objeto apuestas. Se devolvera un registro y lo añadira a la lista
                while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetInt32(1) + " " + res.GetString(2) + " " + res.GetInt32(3) + " " + res.GetString(4) + " " + res.GetInt32(5) + " " + res.GetString(6));
                a = new apuestas(res.GetInt32(0), res.GetInt32(1), res.GetString(2), res.GetInt32(3), res.GetString(4), res.GetInt32(5), res.GetString(6));
                    apuesta.Add(a);
                }

            con.Close();
            return apuesta;

            }
            //Error que salta cuando esta puesto mal el server
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha porducido un error de conexión");
                return null;
            }

        }

        internal List<apuestasDTO> RetrieveDTO()
        {
            //Devuelve todos los registros
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuestas";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                apuestasDTO a = null;

                //Cada vez que ecuentra un objeto lo añade al list
                List<apuestasDTO> apuesta = new List<apuestasDTO>();

                //Devolver objeto apuestas. Se devolvera un registro y lo añadira a la lista
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetInt32(1) + " " + res.GetString(2) + " " + res.GetInt32(3) + " " + res.GetString(4) + " " + res.GetInt32(5) + " " + res.GetString(6));
                    a = new apuestasDTO(res.GetInt32(1), res.GetString(2), res.GetInt32(3), res.GetString(4));
                    apuesta.Add(a);
                }

                con.Close();
                return apuesta;

            }
            //Error que salta cuando esta puesto mal el server
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha porducido un error de conexión");
                return null;
            }

        }

        string apuesta = "INSERT INTO apuestas(idApuestas, Dinero_apostado, Cuota, Mercado_apuesta, Tipo_apuesta, idMercado, Dni) values ()" ;
        string mercados = "UPDATE mercado SET"+overUnder+"="+overUnder+" + "+a.Dinero_apostado+" WHERE idApuestas = " + idMercado+";" ;
        EjecutarConsulta(apuesta);
        EjecutarConsulta(mercados);

        List<mercado> mercadoARegular = RecuperarMercado(a.idMercado);
        double cuotaOver;
        double cuotaUnder;
        double probabilidadOver;
        double probabilidadUnder;

        probabilidadOver= mercadoARegular[0];
        probabilidadUnder;
        cuotaOver= 1/probabilidadOver*0.95;
        cuotaUnder= 1/probabilidadUnder*0.95;

        string actualizarCuota = "UPDATE mercado SET Cuota ="+ cuotaOver+", Cuota= "+ cuotaUnder+";";
        EjecutarConsulta(actualizarCuota);
    }
}