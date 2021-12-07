﻿using Mango.Web.Models.Dto;
using Mango.Web.Models;

namespace Mango.Web.Services
{
    public interface IBaseService :IDisposable
    {
        ResponseDto  responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
