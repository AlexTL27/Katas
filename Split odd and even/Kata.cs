
public class Kata
{
    public static void Main(string[] args)
    {
        long[] num = SplitOddAndEven(12379285);

        foreach(long a in num) 
            Console.WriteLine($"Num: " + a);
    }

  public static long[] SplitOddAndEven(long n)
  {
    string impares = string.Empty;
    string pares = string.Empty;
    
    
    //Usado para recorrer todo el número que llegó
    string numCompleto = n.ToString();

    //Número final a regresar
    List<long> numFinal = new List<long>();

    foreach (char c in numCompleto)
    {
        byte num = byte.Parse(c.ToString());

        if(num % 2 == 0)
        {
            //par
            pares += c;   
            if (impares == "") continue;

            //Si es par, convertimos antes los impares que tenemos y los agregamos a la lista final
            long imparesLong = long.Parse(impares);
            numFinal.Add(imparesLong);

            //ahora resereamos los pares que teniamos
            impares = "";
        }
    
        else
        {
            //impar
            impares += c;
            if (pares == "") continue;

            //Si no es par, convertimos antes los pares que tenemos y los agregamos a la lista final
            long paresLong = long.Parse(pares);
            numFinal.Add(paresLong);

            //ahora resereamos los pares que teniamos
            pares = "";
        }
    }
        //Ahora falta agregar la ultima cadena de digitos, ya sea impares o pares
        if (!(string.IsNullOrEmpty(pares)))
        {
            long paresLong = long.Parse(pares);
            numFinal.Add(paresLong);
        }
        else if (!(string.IsNullOrEmpty(impares)))
        {
            long imparesLong = long.Parse(impares);
            numFinal.Add(imparesLong);
        }
        return numFinal.ToArray();
  }

    
  
}