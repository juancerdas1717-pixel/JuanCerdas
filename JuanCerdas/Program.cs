using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuanCerdas
{
    internal class Program
    {
        const int MAXIMO = 16;

      
        static string[] nombres = new string[MAXIMO];
        static string[] cedulas = new string[MAXIMO];
        static string[] estados = new string[MAXIMO];

    
        static int cantidadPacientes = 0;

        static void Main()
        {
            int opcion = 0;

            
            while (opcion != 5)
            {
               

                Console.WriteLine(" SISTEMA DE ADMISIONES ");
                Console.Write("Seleccione una opcion: ");
                Console.WriteLine("1. Registrar paciente");
                Console.WriteLine("2. Mostrar pacientes");
                Console.WriteLine("3. Buscar paciente por cedula");
                Console.WriteLine("4. Dar de alta / baja paciente");
                Console.WriteLine("5. Salir");
            

                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        RegistrarPaciente();
                        break;

                    case 2:
                        MostrarPacientes();
                        break;

                    case 3:
                        BuscarPaciente();
                        break;

                    case 4:
                        CambiarEstado();
                        break;

                    case 5:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opcion no valida.");
                        break;
                }

                if (opcion != 5)
                {
                    Console.WriteLine("Presione ENTER para continuar...");
                    Console.ReadLine();
                }
            }
        }

       
        static void RegistrarPaciente()
        {
           
            Console.WriteLine(" REGISTRAR PACIENTE ");

          
            if (cantidadPacientes >= MAXIMO)
            {
                Console.WriteLine("El sistema ya tiene los 16 registros ocupados.");
                return;
            }

            Console.Write("Ingrese el nombre del paciente: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese la cedula del paciente: ");
            string cedula = Console.ReadLine();

            nombres[cantidadPacientes] = nombre;
            cedulas[cantidadPacientes] = cedula;
            estados[cantidadPacientes] = "Activo";

            cantidadPacientes++;

            Console.WriteLine("Paciente registrado correctamente.");
        }

      
        static void MostrarPacientes()
        {
        

            Console.WriteLine("PACIENTES REGISTRADOS");

            if (cantidadPacientes == 0)
            {
                Console.WriteLine("No hay pacientes registrados.");
                return;
            }

            for (int i = 0; i < cantidadPacientes; i++)
            {
                Console.WriteLine("Paciente #" + (i + 1));
                Console.WriteLine("Nombre: " + nombres[i]);
                Console.WriteLine("Cedula: " + cedulas[i]);
                Console.WriteLine("Estado: " + estados[i]);
            }
        }

        static void BuscarPaciente()
        {
           

            Console.WriteLine("BUSCAR PACIENTE ");

            Console.Write("Ingrese la cedula del paciente: ");
            string cedulaBuscada = Console.ReadLine();

            bool encontrado = false;

            for (int i = 0; i < cantidadPacientes; i++)
            {
                if (cedulas[i] == cedulaBuscada)
                {
                    Console.WriteLine("Paciente encontrado.");
                    Console.WriteLine("Nombre: " + nombres[i]);
                    Console.WriteLine("Cedula: " + cedulas[i]);
                    Console.WriteLine("Estado: " + estados[i]);

                    encontrado = true;
                    break;
                }
            }

            if (encontrado == false)
            {
                Console.WriteLine("\nNo se encontro ningun paciente con esa cedula.");
            }
        }

      
        static void CambiarEstado()
        {
          

            Console.WriteLine(" CAMBIAR ESTADO (ALTA/BAJA) ");

            Console.Write("Ingrese la cedula del paciente: ");
            string cedulaBuscada = Console.ReadLine();

            bool encontrado = false;

            for (int i = 0; i < cantidadPacientes; i++)
            {
                if (cedulas[i] == cedulaBuscada)
                {
                    Console.WriteLine("Paciente encontrado.");
                    Console.WriteLine("Nombre: " + nombres[i]);
                    Console.WriteLine("Estado actual: " + estados[i]);

                    Console.WriteLine("1. Dar de alta");
                    Console.WriteLine("2. Dar de baja");
                    Console.Write("Seleccione una opcion: ");

                    int opcion = Convert.ToInt32(Console.ReadLine());

                    if (opcion == 1)
                    {
                        estados[i] = "Alta medica";
                        Console.WriteLine("Paciente dado de alta correctamente.");
                    }
                    else if (opcion == 2)
                    {
                        estados[i] = "Inactivo";
                        Console.WriteLine("Paciente dado de baja correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("Opcion no valida.");
                    }

                    encontrado = true;
                    break;
                }
            }

            if (encontrado == false)
            {
                Console.WriteLine("No se encontro ningun paciente con esa cedula.");
            }
        }
    }
}