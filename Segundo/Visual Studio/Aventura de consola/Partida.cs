using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace Entrega2_FelixHernandez_JavierIregui
{
    class Partida
    {
        Personaje jugador;

        bool seleccion_arma = true;
        bool eleccion01 = true;
        int camino01;
        int pelea01;
        bool pelea001 = true;
        int pelea02;
        bool choisefinal = true;
        int curar;
        bool pilaver = true;
        int pilaleer;
        int muestra;




        public Partida(Personaje jugador_)
        {
            jugador = jugador_;



            Presentacion();
            Equipamiento();
            Herreria();
            Mision();
            FinalMision1();


            Stack miPila = new Stack();
            miPila.Push(camino01);
            miPila.Push(pelea01);
            miPila.Push(pelea001);
            miPila.Push(pelea02);
            miPila.Push(choisefinal);
            miPila.Push(curar);

            while (pilaver == true)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("¿Quieres saber cual es la ultima decision que has tomado?");
                Console.WriteLine("");
                Console.WriteLine("1 - Si");
                Console.WriteLine("2 - No");
                Console.WriteLine("");
                try
                {
                    pilaleer = Convert.ToInt32(Console.ReadLine()); //aqui se toma la decision de hacia donde ir que dependiendo de la respuesta pasaran diferentes cosas
                }
                catch (FormatException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Fallo en la insercion de variable");
                    Console.WriteLine("");
                    Console.Write("Intentelo de nuevo: ");
                }

                if (pilaleer ==1)
                {
                    muestra= (int)miPila.Pop();
                    Console.WriteLine("La ultima opcion almacenada es " + muestra);
                }
                else if (pilaleer== 2)
                {
                    pilaver = false;
                }
                else
                {
                    Console.WriteLine("");
                    Console.Write("Parametro incorrecto, intentelo de nuevo: ");
                }
                Console.WriteLine("");
                Console.WriteLine("  Pulsa ENTER para continuar");
                Console.ReadKey();

            }
            








            StreamWriter fichero;
            fichero = File.CreateText("Resumen de la partida.txt");
            fichero.WriteLine("Nombre del personaje: " + jugador.nombre);
            fichero.WriteLine("");
            fichero.WriteLine("Oro final del personaje: " + jugador.oro);
            fichero.WriteLine("");
            fichero.WriteLine("Vida final del personaje: " + jugador.vida);
            fichero.WriteLine("");
            fichero.WriteLine("Decisiones del juego: ");
            fichero.WriteLine("");

            if (jugador.arma == 1)
            {
                fichero.WriteLine("Elegiste la espada");
            }
            else if (jugador.arma == 2)
            {
                fichero.WriteLine("Elegiste una lanza");
            }
            else if (jugador.arma == 3)
            {
                fichero.WriteLine("Elegiste una hacha");
            }

            fichero.WriteLine("");

            if (pelea02 == 1)
            {
                fichero.WriteLine("Ganaste a los bandidos y lograste salvar a la princesa");
            }
            else if (pelea02 == 2)
            {
                fichero.WriteLine("Huiste como un cobarte y Ros consumió su venganza");
            }

            fichero.Close();



            Console.Clear();
            Console.WriteLine("Gracias por jugar");
            Console.WriteLine("");
            Console.WriteLine("FIN del juego");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Pulse ENTER para finalizar");
            Console.ReadKey();










        }


        public void Presentacion() // cumulo de writelines que narran y ponen en contexto al jugador
        {

            Console.Clear();
            Console.WriteLine("Felicidades " + jugador.nombre + ", acabas de obtener un billete directo al mágico mundo de Visuality.");
            Console.WriteLine("Lugar donde vivirás las aventuras más increibles de toda tu vida.");
            Thread.Sleep(4000); // este comando sirve para que la consola de comandos espere un poco de tiempo para dejar que el jugador lea al ritmo que aparecen las frases
            Console.WriteLine("");
            Console.WriteLine("En este mundo tendrás que ir avanzando tomando decisiones sobre que camino escojer o que acciones realizar.");
            Thread.Sleep(3000);
            Console.WriteLine("");
            Console.WriteLine("Espero que lo tengas todo preparado por que vamos a entrar al mundo de Visuality en ...");

            Console.WriteLine("");
            Thread.Sleep(2000);
            Console.WriteLine("  3");
            Thread.Sleep(2000);
            Console.WriteLine("  2");
            Thread.Sleep(2000);
            Console.WriteLine("  1");
            Thread.Sleep(2000);
            Console.WriteLine("");
            Console.WriteLine("¡VAMOS ALLA!");

            Thread.Sleep(2000);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" Presione ENTER para continuar ");//aqui se da paso a la siguiente mision limpiando la consola y finalizando este apartado
            Console.ReadKey();
            Console.Clear();
        }
        public void Equipamiento() //aqui el personaje seleccionara el arma de esta partida
        {
            Console.Clear();
            Thread.Sleep(3000);
            Console.WriteLine("Perfecto, ya estas aquí.");
            Thread.Sleep(800);
            Console.WriteLine("");
            Console.WriteLine("Antes que nada, mis disculpas por no presentarme antes.");
            Thread.Sleep(1000);
            Console.WriteLine("Mi nombre es Ros y voy a ser tu guía y compañero en esta aventura.");
            Thread.Sleep(2000);
            Console.WriteLine("");
            Console.WriteLine("Una vez hechas las presentaciones, vamos a repasar tu inventario...");
            Thread.Sleep(3000);
            Console.WriteLine("Perfecto, parece que tienes " + jugador.vida + " puntos de vida y " + jugador.oro + " monedas de oro.");
            Thread.Sleep(500);
            Console.WriteLine("Uau, como brillan...");
            Thread.Sleep(2500);
            Console.WriteLine("Perdón...por donde iba...");
            Thread.Sleep(1000);
            Console.WriteLine("Ah sí!");
            Thread.Sleep(1000);
            Console.WriteLine("");
            Console.WriteLine("Parece que estamos en la plaza de la ciudad de Darsby, ahora estamos en la capital de Visuality.");
            Console.WriteLine("");
            Thread.Sleep(1000);
            Console.WriteLine("Bueno, vamos al mercado, necesitarás herramientas para tu misión.");
            Thread.Sleep(3000);

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" Presione ENTER para continuar "); // se despeja la consola a la vez que se pasa a otro momento dentro del juego
            Console.ReadKey();
            Console.Clear();

        }
        public void Herreria()//aqui se permite al usuario comprar armas
        {
            Console.Clear();
            Console.WriteLine("Bien, estamos en la herrería.");
            Thread.Sleep(1000);
            Console.WriteLine("");
            Console.WriteLine("Actualmente tienes " + jugador.oro + " monedas de oro ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("¿Qué arma vas a querer?");
            Console.WriteLine("");


            Console.WriteLine("1 - Espada (15 monedas)");
            Console.WriteLine("2 - Lanza (13 monedas)");
            Console.WriteLine("3 - Hacha de dos manos (20 monedas)");
            Console.WriteLine("");
            Console.Write("Arma a escoger: ");



            Console.WriteLine("");
            while (seleccion_arma == true)
            {
                try
                {
                    jugador.arma = Convert.ToInt32(Console.ReadLine()); //aqui se escoje el arma utilizada en el juego
                }
                catch (FormatException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Fallo en la insercion de variable");
                    Console.WriteLine("");
                    Console.Write("Intentelo de nuevo: ");
                }



                if (jugador.arma == 1 && jugador.oro > 0)
                {
                    jugador.oro = jugador.oro - 15;
                    seleccion_arma = false;
                    Console.WriteLine("-- Has obtenido una espada --");
                }
                else if (jugador.arma == 2 && jugador.oro > 0)
                {
                    jugador.oro = jugador.oro - 13;
                    seleccion_arma = false;
                    Console.WriteLine("-- Has obtenido una lanza --");
                }
                else if (jugador.arma == 3 && jugador.oro > 0)
                {
                    jugador.oro = jugador.oro - 20;
                    seleccion_arma = false;
                    Console.WriteLine("-- Has obtenido una hacha --");
                }
                else
                {
                    Console.WriteLine("");
                    Console.Write("Parametro incorrecto, intentelo de nuevo: ");
                }
                Console.WriteLine("");
            }

            Thread.Sleep(800);
            Console.WriteLine("");
            Console.WriteLine("-- Te quedan " + jugador.oro + " monedas --");


            Thread.Sleep(1000);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("--  Presione ENTER para salir de la herrería --");
            Console.ReadKey();
            Console.Clear();



        }
        public void Mision()//decisiones y acciones de la propia misión
        {
            Console.Clear();
            Thread.Sleep(1000);
            Console.WriteLine("");
            Console.WriteLine("Bueno parece que lo tenemos todo por ahora.");
            Console.WriteLine("");
            Thread.Sleep(800);
            Console.WriteLine("Cuando quieras podemos proceder a la siguiente misión");
            Thread.Sleep(500);


            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("  Presione ENTER para continuar  ");//aqui se da paso a la primera mision limpiando la consola
            Console.ReadKey();


            Console.Clear();
            Console.WriteLine("Tu primera misión, se basa en recuperar a la hija del rey Studius III, Aldenia.");
            Thread.Sleep(1000);
            Console.WriteLine("La princesa fue capturada hará ya tres semanas, nadie ha sido capaz de encontrarla hasta ahora...");
            Thread.Sleep(1000);
            Console.WriteLine("El rey Studius, en su desesperación, ha ofrecido 2000 monedas a cambio de su rescate.");
            Console.WriteLine("Y esa va a ser tu primera misión, encontrar a la princesa y traerla sana y salva.");
            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("Espero que estés a la altura...");
            Console.WriteLine("");
            Thread.Sleep(1000);

            Console.WriteLine("");
            Console.WriteLine("--  Presione ENTER para continuar -- ");
            Console.ReadKey();
            Console.Clear();




            Console.Clear();
            Console.WriteLine("-- " + jugador.nombre + " y Ros fueron directos al bosque, lugar donde se vió por última vez a la princesa Aldenia --");
            Console.WriteLine("");
            Thread.Sleep(1000);
            Console.WriteLine("");

            Console.WriteLine("Mira! Hay 3 caminos. ¿Por donde vamos?");
            Thread.Sleep(1000);




            do
            {
                Console.WriteLine("");
                Console.WriteLine("1 - Ir hacia el norte");
                Console.WriteLine("2 - Ir hacia el este");
                Console.WriteLine("3 - Ir hacia el oeste");
                Console.WriteLine("");
                Console.Write("Elige una opción: ");

                try
                {
                    camino01 = Convert.ToInt32(Console.ReadLine()); //aqui se toma la decision de hacia donde ir que dependiendo de la respuesta pasaran diferentes cosas
                }
                catch (FormatException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Fallo en la insercion de variable");
                    Console.WriteLine("");
                    Console.Write("Intentelo de nuevo: ");
                }

                Console.WriteLine("");

                if (camino01 == 1)// norte (pelea)
                {
                    eleccion01 = false;
                    Console.WriteLine("-- Llendo hacia el norte te encontrarás con un par de enemigos --");
                    Console.WriteLine("");
                    Thread.Sleep(1000);

                    while (pelea001 == true && jugador.vida > 0)
                    {
                        Console.WriteLine("-- ¿Que desea hacer? --");
                        Console.WriteLine("");
                        Console.WriteLine("1 - Atacar");
                        Console.WriteLine("2 - Volver atras");
                        Console.WriteLine("");
                        Console.WriteLine("");

                        try
                        {
                            pelea01 = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Fallo en la insercion de variable");
                            Console.WriteLine("");
                            Console.Write("Intentelo de nuevo: ");
                        }
                        

                        if (pelea01 == 1)//pelea
                        {
                            pelea001 = false;
                            Console.Clear();
                            Console.WriteLine("Veamos de que eres capaz.");
                            Console.WriteLine("");
                            Console.WriteLine("Aprovecha que están distraidos para atacar primero.");
                            Console.WriteLine("");
                            Console.WriteLine("");

                            Console.WriteLine("-- Pulsa ENTER para atacar --");
                            Console.ReadKey();
                            Console.Clear();
                            Thread.Sleep(1000);
                            jugador.Ataque();
                            Thread.Sleep(1000);
                            Console.WriteLine("");
                            Console.WriteLine("Perfecto has derrotado al primero, corre y ataca al segundo.");
                            Console.WriteLine("");
                            Console.WriteLine("");

                            Console.WriteLine("-- Pulsa ENTER para atacar --");
                            Console.ReadKey();
                            Console.WriteLine("");
                            Thread.Sleep(1000);
                            jugador.Ataque();
                            Console.WriteLine("");
                            Thread.Sleep(500);
                            AtaqueEnemigo();
                            Thread.Sleep(1000);
                            Console.WriteLine("");
                            Console.WriteLine("Yujuuuuuu!!!!!!");
                            Thread.Sleep(1000);
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("Para ser tu primer combate no ha estado nada mal " + jugador.nombre + ".");
                            Console.WriteLine("");
                            Thread.Sleep(1500);
                            Console.WriteLine("Voy a intentar curarte un poco.");
                            Console.WriteLine("");
                            Thread.Sleep(800);
                            Console.WriteLine("");
                            Console.WriteLine("-- " + jugador.nombre + " ha recuperado 2 puntos de vida --");
                            jugador.vida = jugador.vida + 2;
                            Console.WriteLine("");
                            Thread.Sleep(800);
                            Console.WriteLine("-- " + jugador.nombre + " tiene " + jugador.vida + " puntos de vida --");
                            Thread.Sleep(2000);
                            Console.WriteLine("");

                            Console.WriteLine("Bueno pues no veo mas camino la verdad, creo que tendremos que dar la vuelta.");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("-- Pulsa ENTER para volver --");
                            Console.ReadKey();
                            eleccion01 = true;
                            Console.Clear();
                        }
                        else if (pelea01 == 2)//huir
                        {
                            pelea001 = false;
                            Console.WriteLine("Yo tampoco tenía muchas ganas de pelear...Mejor volvamos antes de que nos vean.");
                            Console.WriteLine("");
                            Console.WriteLine("-- Pulsa ENTER para volver --");
                            Console.ReadKey();
                            eleccion01 = true;
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.Write("Parametro incorrecto, intentelo de nuevo: ");
                        }

                    }


                }
                else if (camino01 == 2) //este (camino malo)
                {
                    eleccion01 = false;
                    Console.WriteLine("Llendo hacia el este te encontrarás una pequeña caseta derruida con un pozo.");
                    Console.WriteLine("Lo único que puedes hacer es dar la vuelta.");
                    Console.WriteLine(" ");
                    Thread.Sleep(1500);
                    Console.WriteLine("-- Pulsa ENTER para volver --");
                    Console.ReadKey();
                    eleccion01 = true;
                    Console.Clear();

                }
                else if (camino01 == 3)//oeste (camino bueno)
                {
                    eleccion01 = false;
                    Console.Clear();
                    Console.WriteLine("-- Llendo hacia el oeste " + jugador.nombre + " camino por un sendero del bosque que parecia desolado. --");
                    Thread.Sleep(1800);
                    Console.WriteLine("");
                    Console.WriteLine("-- Caminó, caminó y caminó todo el dia...  --");
                    Thread.Sleep(2000);
                    Console.WriteLine("");
                    Console.WriteLine("-- Al caer la noche " + jugador.nombre + " acampó al lado de un arbol cerca de una pequeña cornisa,");
                    Console.WriteLine("   " + jugador.nombre + " no tardaría apenas un par de minutos en caer de cansancio --");
                    Thread.Sleep(1000);
                    Console.WriteLine("");
                    Console.WriteLine("-- Su compañero Ros, el cual al ser un ser mágico no necesitaba dormir,");
                    Console.WriteLine("   " + "montó guardia durante toda la noche hasta la siguiente mañana --");

                    Thread.Sleep(2000);
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("-- Pulsa ENTER para pasar al siguiente dia --");
                    Console.ReadKey();
                    Console.Clear();


                    Console.WriteLine("-- A la mañana siguiente --");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Thread.Sleep(1000);
                    Console.WriteLine(jugador.nombre + "!!!!" + jugador.nombre + "!!!!!!!");
                    Thread.Sleep(1000);
                    Console.WriteLine("");
                    Console.WriteLine("Despierta corre! Tienes que ver esto.");
                    Thread.Sleep(800);
                    Console.WriteLine("");
                    Console.WriteLine("¡Creo que la he encontrado!");
                    Thread.Sleep(1000);
                    Console.WriteLine("");
                    Console.WriteLine("-- " + jugador.nombre + " despertó de su aletargado sueño y empezó a seguir a su compañero --");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Thread.Sleep(2000);

                    Console.WriteLine("Estaba revisando el terreno para buscar enemigos cercanos y de repente la vi.");
                    Console.WriteLine("");
                    Thread.Sleep(1000);
                    Console.WriteLine("Corre " + jugador.nombre + "!!! Casi hemos llegado.");
                    Thread.Sleep(1400);
                    Console.WriteLine("");
                    Console.WriteLine("-- El duo se acercó rapidamente a un lateral de la cornisa, ");
                    Console.WriteLine("   y lo que vieron les dejó estupefactos --");

                    Thread.Sleep(1500);
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("-- Pulsa ENTER para mirar mas de cerca --");
                    Console.ReadKey();
                    Console.Clear();

                    Console.WriteLine("-- Inimaginablemente ahí estaba. Aldenia, la princesa de Visuality -- ");
                    Thread.Sleep(3500);
                    Console.WriteLine("");
                    Console.WriteLine("-- Tendida en el suelo, llena de arañazos y pequeños cortes. No se movía, pero al menos no parecía estar muerta --");
                    Thread.Sleep(4000);
                    Console.WriteLine("");
                    Console.WriteLine("Rapido " + jugador.nombre + "! Tenemos que sacarla de ahí.");

                    Thread.Sleep(5500);

                    Console.WriteLine("");
                    Console.WriteLine("-- " + jugador.nombre + " y Ros consiguieron subirla de donde estaba y llevarla de vuelta al");
                    Console.WriteLine("  campamento donde pasaron la noche --");
                    Thread.Sleep(1500);
                    Console.WriteLine("");

                    Console.WriteLine("-- Ros y " + jugador.nombre + " cuidaron de la princesa hasta hasta que pudieran llevarla de vuelta -- ");

                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("-- Pulsa ENTER para continuar --");
                    Console.ReadKey();
                    Console.Clear();

                }
                else
                {
                    Console.WriteLine("");
                    Console.Write("Parametro incorrecto, intentelo de nuevo: ");
                }

            } while (eleccion01 == true);
        }
        public void FinalMision1()//final de la primera misión
        {

            Console.WriteLine("-- Los dias pasaron y la princesa seguía sin despertar por lo que " + jugador.nombre + " y Ros decidieron cargar con ella ");
            Console.WriteLine("   hasta la ciudad --");
            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" -- Al volver, practicamente a las puertas de la ciudad de Darsby, nuestros heroes se encontraron con unos bandidos --");
            Console.WriteLine("");
            Console.WriteLine("");
            Thread.Sleep(2500);
            Console.WriteLine("-- Estos, reconocieron rapidamente a la princesa por lo que exigieron darsela para poder reclamar la recompensa --");
            Console.WriteLine("");
            Thread.Sleep(2500);

            Console.WriteLine("");
            Console.WriteLine("-- Pulsa ENTER para continuar --");
            Console.ReadKey();
            Console.Clear();





            Console.WriteLine("Nunca os la llevareis malditos!");
            Thread.Sleep(500);
            Console.WriteLine("");
            Console.WriteLine("Vamos " + jugador.nombre + "! Demuestrales lo que sabes hacer.");
            Thread.Sleep(3000);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("-- " + jugador.nombre + " dejó a la princesa Aldenia debajo de un arbol --");
            Console.WriteLine("");
            Console.WriteLine("");
            Thread.Sleep(3000);


            while (choisefinal == true && jugador.vida > 0)
            {
                Console.WriteLine("--¿Que deseas hacer? --");
                Console.WriteLine("");
                Console.WriteLine("1 - Atacar");
                Console.WriteLine("2 - Dejar a la princesa e huir");
                Console.WriteLine("");
                Console.WriteLine("");
                try
                {
                    pelea02 = Convert.ToInt32(Console.ReadLine());

                }
                catch (FormatException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Fallo en la insercion de variable");
                    Console.WriteLine("");
                    Console.Write("Intentelo de nuevo: ");
                }
                

                if (pelea02 == 1)//atacar
                {

                    choisefinal = false;
                    Console.WriteLine("-- Pulsa ENTER para atacar --");
                    Console.ReadKey();
                    Console.Clear();


                    Thread.Sleep(800);
                    jugador.Ataque();
                    Thread.Sleep(800);
                    AtaqueEnemigo();
                    Console.WriteLine("");
                    Thread.Sleep(1000);
                    Console.WriteLine("Uno de los bandidos ha caido! Sigue asi " + jugador.nombre);
                    Console.WriteLine("");


                    Console.WriteLine("");
                    Console.WriteLine("-- Pulsa ENTER para atacar --");
                    Console.ReadKey();
                    Console.Clear();


                    Thread.Sleep(800);
                    jugador.Ataque();
                    Thread.Sleep(800);
                    AtaqueEnemigo();
                    Console.WriteLine("");
                    Thread.Sleep(1000);
                    Console.WriteLine("Cuidado " + jugador.nombre + "!");
                    Console.WriteLine("");


                    Console.WriteLine("");
                    Console.WriteLine("-- Pulsa ENTER para atacar --");
                    Console.ReadKey();
                    Console.Clear();


                    Thread.Sleep(800);
                    jugador.Ataque();
                    Thread.Sleep(800);
                    AtaqueEnemigo();
                    Console.WriteLine("");
                    Thread.Sleep(1000);
                    Console.WriteLine("Aguanta " + jugador.nombre + "! Ya queda poco");
                    Console.WriteLine("");


                    Console.WriteLine("");
                    Console.WriteLine("-- Pulsa ENTER para atacar --");
                    Console.ReadKey();
                    Console.Clear();

                    Thread.Sleep(800);
                    jugador.Ataque();
                    Thread.Sleep(800);
                    AtaqueEnemigo();
                    Console.WriteLine("");
                    Thread.Sleep(1000);
                    Console.WriteLine("Ya han caido 2!");
                    Console.WriteLine("");
                    Console.WriteLine("");

                    Thread.Sleep(1500); 
                    Console.WriteLine("¡¿Necesitas que te cure?!");
                    Console.WriteLine("");
                    Console.WriteLine("1 - Curar");
                    Console.WriteLine("2 - No hace falta");
                    Console.WriteLine("");


                    try
                    {
                        curar = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Fallo en la insercion de variable");
                        Console.WriteLine("");
                        Console.Write("Intentelo de nuevo: ");
                    }

                    if (curar == 1)
                    {
                        jugador.Curar();
                    }
                    else if (curar == 2)
                    {
                        Console.WriteLine("Vale perfecto, " + jugador.nombre + " acaba con ellos!");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.Write("Parametro incorrecto, intentelo de nuevo: ");
                        Console.Clear();
                    }
                    
                    

                    Thread.Sleep(2000);
                    Console.WriteLine("");
                    Console.WriteLine("-- Pulsa ENTER para atacar --");
                    Console.ReadKey();
                    Console.Clear();


                    Thread.Sleep(800);
                    jugador.Ataque();
                    Thread.Sleep(800);
                    AtaqueEnemigo();
                    Console.WriteLine("");
                    Thread.Sleep(1000);
                    Console.WriteLine("Cuidado por la derecha!");
                    Console.WriteLine("");

                    Thread.Sleep(1000);
                    Console.WriteLine("");
                    Console.WriteLine("-- Pulsa ENTER para atacar --");
                    Console.ReadKey();
                    Console.Clear();


                    Thread.Sleep(800);
                    jugador.Ataque();
                    Thread.Sleep(800);
                    AtaqueEnemigo();
                    Console.WriteLine("");
                    Thread.Sleep(1000);
                    Console.WriteLine("-- Tras caer el tercer bandido, el ultimo salió corriendo por miedo a compartir su mismo destino --");
                    Console.WriteLine("");


                    Thread.Sleep(1000);
                    Console.WriteLine("");
                    Console.WriteLine("-- Pulsa ENTER para finalizar la pelea --");
                    Console.ReadKey();
                    Console.Clear();

                    FinalBueno();

                }
                else if (pelea02 == 2)//huir
                {

                    choisefinal = false;
                    FinalMalo();

                }
                else
                {
                    Console.WriteLine("");
                    Console.Write("Parametro incorrecto, intentelo de nuevo: ");
                }
            }



        }
        public void FinalBueno() //final bueno donde se explica el fin de la primera mision
        {
            Console.Clear();
            Console.WriteLine("-- Durante el combate se formó un grupo de gente alrededor de " + jugador.nombre + " lo que llamó la");
            Console.WriteLine("   atención de los soldados que vigilaban la muralla --");
            Thread.Sleep(2000);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("-- Tras finalizar el combate, los soldados aparecieron exigiendo una explicación -- ");
            Thread.Sleep(900);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("No ataquen porfavor! Hemos encontrado a la princesa Aldenia!");
            Console.WriteLine();
            Console.WriteLine("Estos maleantes trataban de secuestrarla.");
            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("-- Los soldados al entender la situación se calmaron, pero corrieron en busca de la princesa,");
            Console.WriteLine("   la cual continuaba desmayada. Entraron todos en la ciudad con la princesa en brazos de " + jugador.nombre + " --");

            Thread.Sleep(900);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Pulse ENTER para continuar");
            Console.ReadKey();
            Console.Clear();


            Console.WriteLine("-- El rey, fue rapidamente avisado por los soldados y este bajo rapidamente a la plaza de la ciudad --");
            Thread.Sleep(1000);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(jugador.nombre + ", ahora le explicaré al rey todo lo sucedido con la princesa y tu tendrás que seguir cuidando de ella.");
            Console.WriteLine("");
            Thread.Sleep(1000);
            Console.WriteLine("-- El rey apareció rapidamente, sin escolta ni protección, solo el corriendo al centro de la plaza, detrás de el, le seguian");
            Console.WriteLine("   exaustos su guardia personal y los soldados que le avisaron --");
            Console.WriteLine("");
            Console.WriteLine("");
            Thread.Sleep(2000);
            Console.WriteLine("-- No tardo ni medio minuto en encontrar a su hija en la sombra de un prqueño puesto mientras que " + jugador.nombre + " y Ros aguardaban su llegada --");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Aquí majestad aquí!");
            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("-- El rey apenas tardó unos segundos en ir hasta donde estaban los heroes del momento --");
            Console.WriteLine("");
            Console.WriteLine("-- Tras explicarle Ros todo lo sucedido y darle las gracias a " + jugador.nombre + " cogio a su hija en brazos, aun inconsciente --");
            Console.WriteLine("");
            Console.WriteLine("-- Tanto los soldados como el rey partieron de vuelta al palacio, no sin antes decir publicamente a voz en grito que " + jugador.nombre);
            Console.WriteLine("   habia recuperado a su hija, la princesa Aldenia --");
            Console.WriteLine("");
            Thread.Sleep(7000);
            Console.WriteLine("");
            Console.WriteLine("-- El pueblo, al ver la situción se agruparon frente a esta escena y tras ello comenzaron a apaludir mientras el rey y su sequito se retiraban --");
            Console.WriteLine("");
            Console.WriteLine("-- El vitoreo y el estruendo de aplausos continuó un poco mas, pero la gente comenzó a retomar su labor habitual --");
            Console.WriteLine("");
            Console.WriteLine("");
            Thread.Sleep(8000);
            Console.WriteLine("-- Una vez ya quedaron solos otra vez, Ros se dirigió a " + jugador.nombre + " --");
            Console.WriteLine("");
            Console.WriteLine("El rey nos ha convocado mañana en el palacio real.");
            Console.WriteLine("Ha dicho que quería verte en privado.");


            Thread.Sleep(900);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Pulse ENTER para continuar");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("-- Ya en el siguiente dia, " + jugador.nombre + " y Ros acudieron a su cita en palacio al mediodía --");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("-- Una vez dentro del palacio, el rey le dio la recompensa prometida y nombró a " + jugador.nombre + " caballero consagrado de su ejercito --");
            Console.WriteLine("");
            jugador.oro = jugador.oro + 2000;


            Thread.Sleep(900);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Pulse ENTER para finalizar el juego");
            Console.ReadKey();
            Console.Clear();
        }
        public void FinalMalo() //final malo donde se explica el fin del juego
        {
            Console.Clear();
            Console.WriteLine("-- " + jugador.nombre + " comenzó a correr lo mas rápido que pudo dejando atras a todo el mundo --");
            Console.WriteLine("");
            Thread.Sleep(1000);
            Console.WriteLine("-- Ros, quedó asombrado a la par que aturdudido por la actuación de " + jugador.nombre + " --");
            Console.WriteLine("");
            Console.WriteLine("");
            Thread.Sleep(4000);
            Console.WriteLine("-- Los bandidos no entendieron que habia sucedido exactamente, pero vieron una oportunidad perfecta para secuestrar a la princesa --");
            Console.WriteLine("");
            Thread.Sleep(2000);
            Console.WriteLine("-- Ros también fue capturado. El rey al escuchar la noticia de que unos bandidos habían secuestrado a su hija, no tuvo mas remedio");
            Console.WriteLine("   que permitir entrar a los bandidos los cuales al ir al palacio a liberar a la princesa acabaron secuestrando al rey y tomando el");
            Console.WriteLine("   del reino --");
            Thread.Sleep(10000);
            Console.WriteLine("-- El reino se acabo debilitando y se convirtió en una ciudad fantasma. Los bandidos la tomaron como su fortaleza --");
            Console.WriteLine("");
            Console.WriteLine("");
            Thread.Sleep(10000);
            Console.WriteLine("-- Ros, consiguió escapar. Y se dedico a buscar sin descanso a " + jugador.nombre + " por su horrible traición --");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Thread.Sleep(13000);
            Console.WriteLine("-- Tras años de busqueda finalmente Ros pudo cobrar su venganza, torturó, asesinó y mutiló a " + jugador.nombre);
            Console.WriteLine("   por todo el daño que hizó tanto a el como a todo el reino --");



            Thread.Sleep(1900);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Pulse ENTER para finalizar el juego");
            Console.ReadKey();
            Console.Clear();
        }


        public void AtaqueEnemigo()
        {
            Random rnd = new Random();
            int daño = rnd.Next(0, 4);

            if (daño == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("-- El enemigo ha fallado el ataque --");
                Console.WriteLine("");

            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("-- " + jugador.nombre + " ha recivido un daño de " + daño + " --");
                Console.WriteLine("");
                jugador.vida = jugador.vida - daño;
                Console.WriteLine("-- Te quedan " + jugador.vida + " puntos de vida --");
            }
        }


    

        
  
            
        
    }

}
