using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using WebApiModelo.domain;
using WebApiModelo.domain.Request;

namespace WebApiModelo.api.Controllers
{
    public class BaseController : Controller
    {
        private HeaderRequest _headerRequest;

        public BaseController()
        {
        }

        private void PreencherHeaderRequest()
        {
            _headerRequest = new HeaderRequest()
            {
                Authorization = Request.Headers["authorization"].ToString(),
            };
        }

        protected HeaderRequest GetHeaderRequest
        {
            get
            {
                if (_headerRequest == null)
                {
                    PreencherHeaderRequest();
                }

                return _headerRequest;
            }
        }

        public override BadRequestObjectResult BadRequest(object error)
        {
            if (error.GetType().BaseType == typeof(Exception))
            {
                Exception ex = (Exception)error;

                Error response = new Error()
                {
                    Codigo = HttpStatusCode.BadRequest.ToString(),
                    Mensagem = ex.Message
                };
                return base.BadRequest(response);
            }
            else
            {
                return base.BadRequest(error);
            }
        }
    }
}