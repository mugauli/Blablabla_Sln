using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjBlablabla.DTO
{
    public class MethodResponseDTO<T>
    {
        /// <summary>
        ///Lista de Códigos de Error
        /// Modelo de Datos                  -100
        /// Modelo Negocio                   -200
        /// Modelo Servicios                 -300
        /// Controlador                      -400
        /// Customer MemberShip Provider     -500
        /// Customer Role Provider           -600
        /// Envio Correos                    -700
        /// Errores controlados              -800
        /// </summary>
        public int Code { get; set; }

        public string Message { get; set; }

        public string InternalMessage { get; set; }

        public T Result { get; set; }
    }
}