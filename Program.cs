using System;
using System.IO;
using System.Collections.Generic;

namespace DPRN2_U3_A4_JHRM
{
    class Program
    {
        static void Main(string[] args)
        {
            Juego jue1 = new Juego();
            //Se asignan los atributos del juego, # menor y # mayor
            jue1.NuMenor = 1;
            jue1.NuMayor = 10;
            //Variable para acumular opcion de jugador
            Char opcion = jue1.seleccionar();
            // Se llama el método de jugar y se le pasan los params
            jue1.empezarJuego(opcion, jue1.NuMenor, jue1.NuMayor) ;

        }
    }

    class Juego
    {
        protected int nuMenor;
        public int NuMenor
        {
            set { this.nuMenor = value; }
            get { return this.nuMenor; }
        }

       


        protected int nuMayor;
        public int NuMayor
        {
            set { this.nuMayor = value; }
            get { return this.nuMayor; }
        }


        Char opcion;
        //Método para contrar input de usuario y obtener opción deseada
        public Char seleccionar()
        {
            Console.WriteLine("¿Quieres jugar? s/n");

            try
            {
                // Se convierte el input a Char
                opcion = Char.Parse(Console.ReadLine());
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Formato ingresado no válido, debe ser un caracter");
                Console.WriteLine(fe.ToString());
            }

            finally
            {
                if (opcion != 's' && opcion != 'n')
                {
                    throw new OpcionNoValidaException();
                }
            }
 
            return opcion;
            
        }

        //array para guardar premios
        List<String> premios = new List<string>();

        // Método para jugar juego
        public void empezarJuego (Char opcion, int min, int max)
        {
            if (opcion == 's')
            {
                Console.WriteLine("Empieza juego");
                Console.WriteLine(".");
                Console.WriteLine(".");
                Console.WriteLine(".");
                //generar num aleatorio
                Random aleatorio = new Random();
                int ranNum = aleatorio.Next(min, max);
                Console.WriteLine("Tu número de la suerte es: " + ranNum);
                //Se añden los premios al arreglo
                premios.Add("Oso de peluche");
                premios.Add("Ningún premio");
                premios.Add("Ningún premio");
                premios.Add("Anillo");
                premios.Add("Gatito");
                premios.Add("Ningún premio");
                premios.Add("100 pesos");
                premios.Add("Alcancia");
                premios.Add("Ningún premio");
                premios.Add("Ningún premio");

                Console.WriteLine("Obtuviste: " + premios[ranNum] + "\n");

                Console.WriteLine("Lista de premios");
                foreach (String premio in premios)
                {
                Console.WriteLine(premio);
                }



            }
            else
            {
                Console.WriteLine("No quieres jugar, hasta luego...");
            }
            

        }

        //Excepciones personalizadas
        class OpcionNoValidaException : ApplicationException
        {
            public OpcionNoValidaException()
                : base("Opción no válida, debe ser unicamente s / n")
            { }

            public OpcionNoValidaException(String mensaje)
                : base(mensaje)
            { }

            public OpcionNoValidaException(String mensaje, Exception anidada)
                : base(mensaje, anidada)
            { }
        }


    }
}
