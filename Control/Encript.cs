using System;
using System.Security.Cryptography;
using System.Text;

namespace SistemaGestionAerolinea.Control
{
    /// <summary>
    /// Proporcionar métodos para el cifrado y la protección de datos sensibles del sistema.
    /// </summary>
    public class Encrypt
    {
        /// <summary>
        /// Generar un hash SHA256 a partir de una cadena de texto de entrada.
        /// </summary>
        /// <param name="str">Cadena de texto plano a procesar.</param>
        /// <returns>Representación hexadecimal del hash generado.</returns>
        public static string GetSHA256(string str)
        {
            // Validar la entrada para asegurar la integridad del proceso
            if (string.IsNullOrEmpty(str)) return string.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                // Codificar el texto de entrada a bytes mediante UTF8 para el procesamiento criptográfico
                byte[] stream = sha256.ComputeHash(Encoding.UTF8.GetBytes(str));
                StringBuilder sb = new StringBuilder();

                // Convertir cada byte en formato hexadecimal de dos dígitos para la salida secuencial
                for (int i = 0; i < stream.Length; i++)
                {
                    sb.AppendFormat("{0:x2}", stream[i]);
                }
                return sb.ToString();
            }
        }
    }
}