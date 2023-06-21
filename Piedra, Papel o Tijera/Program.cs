int jugadores;
int cantTiros;
string[] arrayJugadores;
int[] arrayPuntos;

void Jugar()
{
  Console.WriteLine("-----------------------------------------");
  Console.WriteLine("Juguemos Piedra, Papel o Tijera!!");

  jugadores = IngresoJugadores();
  cantTiros = IngresarTiros();

  for (int i = 0; i < arrayJugadores.Length; i++)
  {
    int tiros = cantTiros;
    int puntaje = 0;
    while (tiros > 0)
    {
      Console.WriteLine($"{arrayJugadores[i]}, Tiro N° {tiros}: ¿Piedra, Papel o Tijera? (R/P/T)");
      var respuestaJugador = RespuestaJugador();
      var respuestaMaquina = GenerarRespuesta();
      puntaje += CalcularPuntos(respuestaJugador, respuestaMaquina);

      Console.WriteLine();
      Console.WriteLine($"Tu puntaje al momento es de {puntaje}");

      tiros--;
    }
    arrayPuntos[i] = puntaje;
    Console.WriteLine("----------");
    Console.WriteLine($"{arrayJugadores[i]}, tu puntaje total es de {arrayPuntos[i]} puntos.");
    Console.WriteLine("----------");
  }
  MostrarTotal(arrayPuntos, arrayJugadores);

}

int IngresoJugadores()
{
  //Se creara la longitud de arrayJugadores y arrayPuntos
  Console.WriteLine("¿Cuantos Jugadores seran? MAXIMO 10");
  jugadores = int.Parse(Console.ReadLine());
  while (!(jugadores >= 1 && jugadores <= 10))
  {
    Console.WriteLine("ERROR! Ingrese entre 1 o 10 jugadores");
    jugadores = int.Parse(Console.ReadLine());
  }

  arrayJugadores = new string[jugadores];
  arrayPuntos = new int[jugadores];
  Console.WriteLine($"Jugaran {arrayJugadores.Length} personas");
  //-----------------------------------------------------


  //PASAMOS arrayJugadores y arrayPuntos COMO ARGUMENTOS 
  //A LA FUNCION IniciarJugadores PERMITIENDO QUE INICIALICE LOS NOMBRES Y PUNTOS DE LOS JUGADORES
  IniciarJugadores(arrayJugadores, arrayPuntos);
  //--------------------------------------------------------

  return jugadores;
}

void IniciarJugadores(string[] array1, int[] array2)
{
  //Se guardaran los nombres en array1 e iniciaran con 0 puntos en el array2
  for (int i = 0; i < array1.Length; i++)
  {
    Console.WriteLine($"Ingrese el nombre del jugador {i + 1}");
    var nombre = Console.ReadLine();
    array1[i] = nombre;
    array2[i] = 0;
  }
  //------------------------------------------------------------------------
}

int IngresarTiros()
{
  Console.WriteLine("Ingrese la cantidad de tiros. MAXIMO 10");
  var tiros = int.Parse(Console.ReadLine());
  while (!(tiros >= 1 && tiros <= 10))
  {
    Console.WriteLine("ERROR! Vuelva a ingresar un numero del 1 al 10");
    tiros = int.Parse(Console.ReadLine());
  }
  return tiros;
}

string RespuestaJugador()
{
  var respuesta = Console.ReadLine().ToUpper();
  while (respuesta.ToUpper() != "R" && respuesta.ToUpper() != "P" && respuesta.ToUpper() != "T")
  {
    Console.WriteLine("La respuesta es incorrecta, vuelva a ingresar.");
    respuesta = Console.ReadLine().ToUpper();
  }
  return respuesta;
}

int GenerarRespuesta()
{
  var rnd = new Random();
  var num = rnd.Next(1, 4);
  Console.WriteLine($"Maquina: {(num == 1 ? "Piedra" : ((num == 2) ? "Papel" : "Tijera"))}");
  return num;
}

int CalcularPuntos(string res, int respuestaMaquina)
{
  int num;
  if ((res == "R" && respuestaMaquina == 3) || (res == "P" && respuestaMaquina == 1) || (res == "T" && respuestaMaquina == 2))
  {
    Console.WriteLine("Felicitaciones, Ganaste!!");
    num = 2;
  }
  else if ((res == "R" && respuestaMaquina == 2) || (res == "P" && respuestaMaquina == 3) || (res == "T" && respuestaMaquina == 1))
  {
    Console.WriteLine("Perdedoooor! JAJAJA");
    num = -1;
  }
  else
  {
    Console.WriteLine("Nada para nadie!");
    num = 0;
  }
  return num;
}

void MostrarTotal(int[] array1, string[] array2)
{
  int max = 0;
  int indice = 0;

  for (int i = 0; i < array1.Length; i++)
  {
    if (array1[i] > max)
    {
      max = array1[i];
      indice = i;
    }
  }
  Array.Sort(array1);
  Console.WriteLine($"El Ganador es {array2[indice]} con {max} puntos, Felicitaciones!!");
  Console.WriteLine("Estos son los puntajes totales: ");
  for (int i = 0; i < array1.Length; i++)
  {
    Console.WriteLine(array1[i]);
  }
}

Jugar();





