using System;

namespace intento12
{
    class Program
    {
        static string ruta_paquetes = @"C:\Users\alejandra\source\repos\tallertercercorte1\archivos de textos\Paquetes.txt";
        static string ruta_camiones = @"C:\Users\alejandra\source\repos\tallertercercorte1\archivos de textos\Camiones.txt";
        static Paquete[] listapaquetes;
        static Camion[] listacamion;
        static int total_paquetes = 0;
        static int total_camiones = 0;

        //POR FAVOR LEER PRIMERO ESTO PROFE JEJEJE
        // INTEGRANTES DEL GRUPO JEFERSON DAVID CAÑON MELO,PEDRO DANIEL ACERO, CARLOS ALBERTO CRISTANCHO
        static void Main(string[] args)
        {

            //paquetes 
            #region

            string[] lineas_paquete = System.IO.File.ReadAllLines(ruta_paquetes);
            
            total_paquetes = lineas_paquete.Length - 1;
            listapaquetes = new Paquete[total_paquetes];

            for (int i = 1; i <= total_paquetes; i++)
            {
                string linea_momentanea = lineas_paquete[i];
                string[] Paquete_nuevo = linea_momentanea.Split(";");
                int id_paquete_momentaneo = Convert.ToInt32(Paquete_nuevo[0]);
                double volumen_paquete_momentaneo = Convert.ToDouble(Paquete_nuevo[1]);
                int peso_paquete_momentaneo = Convert.ToInt32(Paquete_nuevo[2]);
                Paquete nuevo_paquete = new Paquete(id_paquete_momentaneo, volumen_paquete_momentaneo,peso_paquete_momentaneo);
                listapaquetes[i - 1] = nuevo_paquete;
            }


            listapaquetes = new Paquete[lineas_paquete.Length - 1];


            for (int i = 1; i < lineas_paquete.Length; i++)
            {
                listapaquetes[i - 1] = _ParseLine_paquete(lineas_paquete[i]);
            }

            foreach (var item in listapaquetes)
            {
                item.getId().ToString();
                item.GetVolumen().ToString();
                item.GetPeso().ToString();
            }
            #endregion
            //finalizacion paquetes

            //camiones
            #region
            string[] camiones_lineas = System.IO.File.ReadAllLines(ruta_camiones);

            total_camiones = camiones_lineas.Length - 1;

            listacamion = new Camion[total_camiones];

            for (int i = 1; i <= total_camiones; i++)
            {
                string linea_momentanea = camiones_lineas[i];
                string[] Nuevo_camion = linea_momentanea.Split(";");
                int id_momentaneo = Convert.ToInt32(Nuevo_camion[0]);
                double volumen_momentaneo = Convert.ToDouble(Nuevo_camion[1]);
                int peso_momentaneo =   Convert.ToInt32(Nuevo_camion[2]);
                Camion Camion_nuevo = new Camion(id_momentaneo, volumen_momentaneo, peso_momentaneo);
                listacamion[i - 1] = Camion_nuevo;
            }

            for (int i = 1; i < camiones_lineas.Length; i++)
            {
                listacamion[i - 1] = _ParseLine_camion(camiones_lineas[i]);
            }

            foreach (var item in listacamion)
            {
                item.GetIdcamion().ToString();
                 item.GetVolumencamion().ToString();
                 item.GetPesocamion().ToString();
            }
            #endregion
            //finalizacion camiones

            //union de paquetes con camion
            #region
            for (int i = 0; i < listacamion.Length; i++)
            {
                Camion camion_salido = listacamion[i];
                double camion_volumen_max = camion_salido.GetVolumencamion();
                int camion_peso_max = camion_salido.GetPesocamion();
                Paquete[] Camion_paquetes;
                int Numeropaquetes_camion = 0;

                for (int j = 0; j < listapaquetes.Length; j++)
                {
                    Paquete paquete_nuevo = listapaquetes[j];
                    double paquete_volumen = paquete_nuevo.GetVolumen();
                    int paquete_peso = paquete_nuevo.GetPeso();
                    Boolean camion_paquete_cargado = paquete_volumen <= camion_volumen_max && paquete_peso <= camion_peso_max;
                    if (camion_paquete_cargado == true && paquete_nuevo.Setcargado() == false)
                    {
                        Numeropaquetes_camion++;
                        camion_volumen_max = camion_volumen_max - paquete_volumen;
                        camion_peso_max = camion_peso_max - paquete_peso;
                    }
                }

                Camion_paquetes = new Paquete[Numeropaquetes_camion];
                int contador_paquetes_cargados = 0;
                for (int j = 0; j < listapaquetes.Length; j++)
                {
                    Paquete paquete_nuevo = listapaquetes[j];
                    double paquete_volumen = paquete_nuevo.GetVolumen();
                    int paquete_peso = paquete_nuevo.GetPeso();
                    Boolean capacidad_camion = paquete_volumen <= camion_salido.GetVolumencamion() && paquete_peso <= camion_salido.GetPesocamion();
                    if (capacidad_camion == true && paquete_nuevo.Setcargado() == false)
                    {
                        paquete_nuevo.Estacargado(true);
                        Camion_paquetes[contador_paquetes_cargados] = paquete_nuevo;
                        contador_paquetes_cargados++;
                        camion_salido.Setvolumencamion(camion_salido.GetVolumencamion() - paquete_volumen);
                        camion_salido.Setpesocamion(camion_salido.GetPesocamion() - paquete_peso);
                    }
                }
                camion_salido.Paquetescamion(Camion_paquetes);
            }
            #endregion
            //finalizacion union de paquetes con camion

            //paquetes no despachados
            #region 

          
            Console.WriteLine("Estos paquetes no fueron cargados en ningun camion :");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------------------------- ");

            for (int iterador = 0; iterador < listapaquetes.Length; iterador++)
            {
                if (listapaquetes[iterador].Setcargado() == false)
                {
                    Console.WriteLine(" paquete con el id: " + listapaquetes[iterador].getId() + " con el volumen: " + listapaquetes[iterador].GetVolumen() + " con elpeso: " + listapaquetes[iterador].GetPeso());
                    Console.WriteLine("--------------------------------------------------------- ");
                    int suma = 0;
                    suma = suma + listapaquetes[iterador].GetPeso();
                    Console.WriteLine("esto es el peso total de los paquetes no despachados---" + suma);
                    double sumavolumen = 0;

                    sumavolumen = sumavolumen + listapaquetes[iterador].GetVolumen();
                    Console.WriteLine("esto es el volumen total de los paquetes no despachados---" + sumavolumen);
                }

            }
            #endregion
            // FInalizacion paquetes no despachados

            // imprimir camiones y paquetes
            #region 
            Console.WriteLine(" ");
            Console.WriteLine("Los siguientes camiones han sido cargados exitosamente:");
            Console.WriteLine("--------------------------------------------------------- ");
            for (int i = 0; i < listacamion.Length; i++)
            {
                Camion camion_salido = listacamion[i];
                Console.WriteLine(" El camion  con el id: " + camion_salido.GetIdcamion());
                Console.WriteLine(" ha sido cargado con los siguientes  ");
              
                for (int j = 0; j < camion_salido.GetPaquetes().Length; j++)
                {
                    Console.WriteLine(" paquetes con el id : " + camion_salido.GetPaquetes()[j].getId() + " con el  volumen: " + camion_salido.GetPaquetes()[j].GetVolumen());
                    Console.WriteLine(" * con el  peso: " + camion_salido.GetPaquetes()[j].GetPeso());
                }
                Console.WriteLine("---------------------------------------------------------");
            }
            #endregion
            //finalizacion imprimir camiones y paquetes


           
        }

        private static bool Paquete(object p)
        {
            throw new NotImplementedException();
        }

        //paquete lista
        static public Paquete _ParseLine_paquete(string s)
        {
            string[] datos = s.Split(";");
            Paquete x;
            x = new Paquete(datos[0], datos[1], datos[2]);
            return x;
        }

        //finalizar camion lista


        //camion lista
        static public Camion _ParseLine_camion(string s)
        {
            string[] datoscamion = s.Split(";");
            Camion c;
            c = new Camion(datoscamion[0], datoscamion[1], datoscamion[2]);
            return c;
        }

        //finalizar camion lista
    }
}
