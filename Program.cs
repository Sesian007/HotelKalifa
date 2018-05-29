using System;
using System.IO;

namespace Proyecto_final
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo carpeta = new DirectoryInfo(@"D:\HotelKalifa");
            if (carpeta.Exists == false)
            {
                carpeta.Create();
            }
            string carpetaDeDatos = @"D:\HotelKalifa";
            string archivohabitacionesdisponibles = carpetaDeDatos + "habitacionesdispondesreser.txt";

            int nh = 101; //numero de Habitaciones
            int[,] hotel = new int[5, 2];
           TextReader leer_archivos;

            Console.WriteLine("*****************BIENVENIDO AL HOTEL KALIFA***********************");
            Console.WriteLine("Estas son las Habitaciones disponibles de  nuestro Hotel");
           
            for (int i = 0; i < 5; i++)
            {
                for (int y = 0; y < 2; y++)
                {
                    hotel[i, y] = nh++;

                }
            }
            FileInfo fileInfo1 = new FileInfo(@"D:\HotelKalifa\HabitacionesDisponibles.txt");//GUARDADO DE HABITACIONES DISPONIBLES
            if (fileInfo1.Exists == false)
                using (StreamWriter sw = fileInfo1.CreateText())
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int y = 0; y < 2; y++)
                        {
                           sw.Write(hotel[i, y] + " ");
                            Console.WriteLine();

                        }
                        Console.WriteLine();
                    }
                }
            if (fileInfo1.Exists == true)   //Ingeniero buenas tardes tuve complicaciones en esta area,me permito enviar mi programa de esta manera.
            {
                leer_archivos = new StreamReader(@"D:\HotelKalifa\Habitacionessinreserva.txt");
                Console.Write(leer_archivos.ReadToEnd());
            }
            else
            {
                leer_archivos = new StreamReader(@"D:\HotelKalifa\HabitacionesDisponibles.txt");
                Console.Write(leer_archivos.ReadToEnd());
            }
            
            
        



            Console.WriteLine();
            Console.WriteLine("En nuestras Instalaciones manejamos dos tipos de precios con ventilador a $40.000 y con Aire Acondicionado $60.000 por Persona, se le cobrara $10.000 por adicion a otra persona");
            Console.WriteLine();
            Console.WriteLine("***LAS SIGUIENTES HABITACIONES TIENEN AIRE ACONDICIONADO***");
            for (int i = 0; i < 5; i++)// ciclo para indicar mis habitaciones con aire acondicionado
            {
                for (int y = 1; y < 2; y++)
                    Console.Write(hotel[i, y] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("**LAS SIGUIENTES HABITACIONES TIENEN CUPO MAXIMO DE DOS PERSONAS, EL RESTO SON PARA UNA PERSONA**");
            for (int i = 0; i < 5; i++) //ciclo para determinar habitaciones que tienen dos camas.
            {
                for (int y = 0; y < 1; y++)
                {
                    Console.Write(hotel[i, y] + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("****¿ DESEARIA RESERVAR SU HABITACION ? ****");
            Console.WriteLine("### escribir el Numero (1) si desea continuar con su reserva de lo contrario marque 0 ####");
            int siono;
            int reserva = 0;
            int diasr = 0;
            siono = Convert.ToInt32(Console.ReadLine());
            if (siono == 1)
            {
                Console.WriteLine("Bienvenido a nuestras instalaciones, eres nuestro primer cliente. de acuerdo con la informacion anterior, que habitacion desea");
                reserva = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"ha elegido la Habitacion para reservar Nro° {reserva}");
                int adicionf = 0;

                if (reserva % 2 == 1)// clasificacion de la reserva para con ventilador y con cama doble aire
                {
                    Console.WriteLine("esta habitacion es con ventilador y  cama doble adicional para otra persona su adicional es de $10.000");
                    Console.WriteLine("Marca  Numero (1) si desea la adicion, marque 0 si no desea.");
                    int adicion;
                    adicion = Convert.ToInt32(Console.ReadLine());
                    if (adicion == 1)
                    {
                        adicionf += 10000;
                    }
                }
                else
                {
                    Console.WriteLine("esta habitacion es con Aire Acondicionado, cama solo para una persona");
                }
                Console.WriteLine("¿ cuantos dias desea reservar la habitacion ?");
                diasr = Convert.ToInt32(Console.ReadLine());
                int valor = 0;
                int ventilador = 40000, aire = 60000;
                if (reserva % 2 == 1)
                {
                    valor = ventilador * diasr;
                    valor += adicionf;

                }
                else
                {
                    valor = aire * diasr;
                }
                Console.WriteLine($"EL PRECIO POR LA RESERVA DE LOS {diasr} DIAS , DE LA HABITACION N° {reserva}, TODO INCLUIDO ES ${valor} ");
            }
            else
            {
                Console.WriteLine("**gracias por su atencion, recuerde que estamos para servirle.**");
            }

            Console.WriteLine();
            Console.WriteLine("###estas son las habitaciones disponibles###");
            int[] vector = new int[9];
      
            for (int i = 0; i < 5; i++)
            {
                for (int y = 0; y < 2; y++)
                {
                    if (hotel[i, y] != reserva)
                    {
                        Console.Write(hotel[i, y] + " ");
                    }
                    
                }
                Console.WriteLine();

            }
            FileInfo fileInfo= new FileInfo(@"D:\HotelKalifa\Habitacionessinreserva.txt");//GUARDADO DE HABITACIONES DISPONIBLES DESPUES DE LA RESERVA
            if (fileInfo1.Exists == false)
            {
                using (StreamWriter sw = fileInfo.CreateText())
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int y = 0; y < 2; y++)
                        {
                            if (hotel[i, y] != reserva)
                            {
                                sw.Write(hotel[i, y] + " ");
                            }

                        }

                    }
                }
            }
            else
{
            using (StreamWriter sw = new StreamWriter(@"D:\HotelKalifa\HabitacionesDisponibles.txt")) //LUEGO DE QUE CIERRA CONSOLA ESTA FUNCION REMPLAZA LAS RESERVAS ANTERIORES Y CONTINUA CON LA NUEVA 
    {
        for (int i = 0; i < 5; i++)
        {
            for (int y = 0; y < 2; y++)
            {
                if (hotel[i, y] != reserva)
                {
                    sw.Write(hotel[i, y] + " ");

                }


            }

        }
    }



}
Console.ReadKey();
}
}
}
          