using LoginMVCClase.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace LoginMVCClase.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly string connectionString = "Server=localhost;Database=MiBase;Trusted_Connection=True;";
        public IActionResult Lista()
        {
            List<UsuarioModel> usuarios = new List<UsuarioModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = " SELECT id, username, name, fechadenacimiento, email, password from usuarios";

                SqlCommand command= new SqlCommand(query, connection);
                connection.Open();


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    usuarios.Add(new UsuarioModel()
                    { 
                    id= reader.GetInt32(0), email= reader.GetString(1), fechadenacimiento_ = Convert.ToDateTime(reader.GetString(2)), name= reader.GetString(3), password= reader.GetString(4), username= reader.GetString(5)
                    
                    
                    });
                }
            }
                return View(usuarios); 
        }


        private static List<UsuarioModel> listUsuario = new List<UsuarioModel>();

        public IActionResult Index()
        {
            if (listUsuario.Count == 0)
            {
                for (int i = 0; i <= 5; i++)
                {
                    var usuario = new UsuarioModel
                    {
                        id = i,
                        email = "florenciacarpena@gmail.com",
                        username = "FCarpena",
                        password = "password",
                        fechadenacimiento_ = DateTime.Now,
                        name = "Florencia Carpena"
                    };
                    listUsuario.Add(usuario);
                }
            }

            return View(listUsuario);
        }

        [HttpPost]
        public IActionResult FormMethod(string username, string password, string name, string fechanacimiento, string email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))



                {
                    string query = @"INSERT INTO Usuario (Username, name, fechanacimiento, email, passowrd)" +
                        " VALUES(@username, @name, @fechanacimiento, @email, @password)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("username", username);
                    command.Parameters.AddWithValue("password", password);
                    command.Parameters.AddWithValue("name", name);
                    command.Parameters.AddWithValue("email", email);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        ViewBag.Mensaje = "Usuario creado exitosamente";
                    }
                    else
                    {
                        ViewBag.Mensaje = "ERROR - Usuario no creado ";
                    }
                }
            }

            catch (Exception ex) {
                ViewBag.Error = "Error al insertar el usuario" + username + ": " + ex.Message;
                    
                    }
                return RedirectToAction("Index");
            }
    }

    } 

