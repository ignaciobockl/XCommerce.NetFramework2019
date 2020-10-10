using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public class ComprobanteServicio
    {
        private readonly Dictionary<Type, string> diccionario;

        public ComprobanteServicio()
        {
            diccionario = new Dictionary<Type, string>();

            Inicializador(ref diccionario);
        }

        private void Inicializador(ref Dictionary<Type, string> diccionario)
        {
            diccionario.Add(typeof(Compra), "ClassLibrary1.ComprobanteCompra");

            diccionario.Add(typeof(Factura), "ClassLibrary1.ComprobanteFactura");

            diccionario.Add(typeof(Salon), "ClassLibrary1.ComprobanteSalon");
        }

        public decimal Calcular(Comprobante comprobante)
        {
            if(!diccionario.TryGetValue(comprobante.GetType(), out var tipoComprobante))
                throw new Exception("Ocurrio un error.");

            var total = InstanciarObjeto(tipoComprobante);

            return total.Calcular();
        }

        private object InstanciarObjeto(string tipoComprobante)
        {
            var tipo = Type.GetType(tipoComprobante);

            if (tipo == null)
                throw new Exception("Ocurrio un error, tipo de comprobante es nulo.");

            var obj = Activator.CreateInstance(tipo) as ;

            return obj;
        }
    }
}
