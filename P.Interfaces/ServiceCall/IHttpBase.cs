using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.Interfaces
{
    public interface IHttpBase
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <typeparam name="T">Tipo del valor devuelte</typeparam>
        /// <param name="uri">URL de consulta</param>
        /// <returns></returns>
        Task<BaseResponse<T>> Get<T>(string uri);

        /// <summary>
        /// Llamada post
        /// </summary>
        /// <typeparam name="S">Tipo de dato enviado</typeparam>
        /// <typeparam name="R">Tipo de dato devuelto</typeparam>
        /// <param name="uri">url ws</param>
        /// <param name="Element">Elemento del tipo enviado enviado</param>
        /// <returns></returns>
        Task<BaseResponse<R>> Post<R, S>(string uri, S Element);

        /// <summary>
        /// Llamada post
        /// </summary>
        /// <typeparam name="S">Tipo de dato enviado</typeparam>
        /// <typeparam name="R">Tipo de dato devuelto</typeparam>
        /// <param name="uri">url ws</param>
        /// <param name="Element">Elemento del tipo enviado enviado</param>
        /// <returns></returns>
        Task<BaseResponse<R>> Put<R, S>(string uri, S Element);

        /// <summary>
        /// Delete
        /// </summary>
        /// <typeparam name="T">Tipo del valor devuelte</typeparam>
        /// <param name="uri">URL de consulta</param>
        /// <returns></returns>
        Task<BaseResponse<T>> Delete<T>(string uri);
    }
}
