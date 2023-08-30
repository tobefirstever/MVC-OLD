using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace JuegoOlimpico.Web.ClientEncrypt
{
    public class Clave
    {
        private readonly Random _random = new Random();

        public int RandomNumero(int min, int max)
        {
            return _random.Next(min, max);
        }

        // Generates a random string with a given size.    
        public string RandomCadena(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):   
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length = 26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        public string reordenaString(string textoOriginal)
        {
            string textoReordenado = string.Empty;
            StringBuilder bld = new StringBuilder();
            string textoReordenamiento = textoOriginal;
            int posicion;

            int longitudOriginal = textoOriginal.Length;

            for (int i = longitudOriginal - 1; i > 0; i--)
            {
                posicion = RandomNumero(0, i);
                bld.Append(textoReordenamiento.Substring(posicion, 1));
                textoReordenamiento = textoReordenamiento.Substring(0, posicion) + textoReordenamiento.Substring(posicion + 1, textoReordenamiento.Length - (posicion + 1));
            }
            textoReordenado = bld.ToString();

            return textoReordenado + textoReordenamiento;
        }

        public string generar(int numeroAleatorioDesde, int numeroAleatorioHasta, int numeroCaracteres)
        {
            return reordenaString(RandomNumero(numeroAleatorioDesde, numeroAleatorioHasta) + RandomCadena(numeroCaracteres));
        }
    }
}