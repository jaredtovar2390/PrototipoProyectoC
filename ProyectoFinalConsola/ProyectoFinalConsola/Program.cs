using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalConsola
{
    class Program
    {
        public struct productos
        {
            public float codigo;
            public string nombre_producto;
            public double precio_producto;
            public string detalle_producto;
            public DateTime fecha_ingreso;
            public int cantidad;
        }
        enum tipo { lacteos, confiteria, limpieza }
        const int tope = 2;
        static List<productos> lista = new List<productos>();
        static int contador = 0;
        static productos obj = new productos();
     // static int cantidad = 0;
        static void Main(string[] args)
        {
            menu();
        }
        public static void menu()
        {
            int opcion = 0;
            Console.WriteLine("***Menu de opciones***");
            Console.WriteLine("1.-Ingrese Datos del Producto");
            Console.WriteLine("2.-Consultar todo");
            Console.WriteLine("3.-Consultar por fecha");
            Console.WriteLine("4.-Valor de inventario");
            Console.WriteLine("5.-Salir");
            do
            {
                Console.WriteLine("Ingrese la opcion :");
                opcion = int.Parse(Console.ReadLine());
                if (opcion <= 0 || opcion >= 6)
                {
                    Console.WriteLine("Ingrese una opcion Valida ");
                }
            } while (opcion > 5);
            switch (opcion)
            {
                case 1: ingresardatos(); break;
                case 2: consultartodo(); break;
                case 3: consultarporfecha(); break;
                case 4: valorinventario(); break;
            }
        }
        static double total = 0;
        public static void ingresardatos()
        {
            for (int i = contador; i < tope; i++)
            {
                Console.WriteLine("----------Ingreso de datos del producto " + (i + 1) + " ----------");
                Console.WriteLine("Ingrese codigo del producto :");
                obj.codigo = float.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese nombre del producto :");
                obj.nombre_producto = Console.ReadLine();

                Console.WriteLine("Seleccione tipo del producto :");
                obj.detalle_producto = seleccionetipo();

                Console.WriteLine("Ingrese precio del producto :");
                obj.precio_producto = double.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese cantidad del producto :");
                obj.cantidad = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese fecha de registro :");
                obj.fecha_ingreso = DateTime.Parse(Console.ReadLine());

                total = total + obj.precio_producto * obj.cantidad;

                if (contador > tope)
                {
                    Console.WriteLine("Valor maximo para ingresar alcanzado");
                    break;
                }
                lista.Add(obj);
                contador++;
            }
            menu();
        }
        public static void consultartodo()
        { 
          for (int i = 0; i < tope; i++)
            {
                Console.WriteLine("----------Ingreso de datos del producto----------");
                Console.WriteLine("Codigo          :\t " + lista[i].codigo);
                Console.WriteLine("Nombre          :\t " + lista[i].nombre_producto);
                Console.WriteLine("Tipo de producto:\t " + lista[i].detalle_producto);
                Console.WriteLine("Cantidad        :\t " + lista[i].cantidad);
                Console.WriteLine("Precio          :\t " + lista[i].precio_producto);
                Console.WriteLine("Fecha registro  :\t " + lista[i].fecha_ingreso);
            }
            menu();
}
        public static void consultarporfecha()
        {
            Console.WriteLine("----------Ingrese fecha de registro----------");
            DateTime fecha = DateTime.Parse(Console.ReadLine());

            for (int i = 0; i < tope; i++)
            {
                if (fecha == lista[i].fecha_ingreso)
                {
                    Console.WriteLine("Productos ingresados el dia: \t" + fecha);
                    Console.WriteLine("Codigo          :\t " + lista[i].codigo);
                    Console.WriteLine("Nombre          :\t " + lista[i].nombre_producto);
                    Console.WriteLine("Tipo de producto:\t " + lista[i].detalle_producto);
                    Console.WriteLine("Cantidad        :\t " + lista[i].cantidad);
                    Console.WriteLine("Precio          :\t " + lista[i].precio_producto);
                }    
            }
            menu();
}
        public static void valorinventario()
        {
            Console.WriteLine("El costo total de inventario en existencia es de" + "$ " + total);
            menu();
        }
        public static string seleccionetipo()
        {
            int opcion = 0;
            string tip = "";

            Console.WriteLine("Seleccione una opcion : 1.-Lacteos  2.-Confiteria  3.-Limpieza ");
            opcion = int.Parse(Console.ReadLine());

            if (opcion == 1)
            {
                tip = tipo.lacteos.ToString();
            }
            else if (opcion == 2)
            {
                tip = tipo.confiteria.ToString();
            }
            else if (opcion == 3)
            {
                tip = tipo.limpieza.ToString();
            }
            return tip;
               
        }
      }
    }
