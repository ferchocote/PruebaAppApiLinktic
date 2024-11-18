﻿using DomainServices.Domain.Contracts.User;
using Microsoft.EntityFrameworkCore;
using PruebaAppApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Domain.User
{
    public class UserDomain : IUserDomain
    {
        private readonly LinkticEcomerceContext _linkticEcomerceContext;

        public UserDomain(LinkticEcomerceContext linkticEcomerceContext)
        {
            _linkticEcomerceContext = linkticEcomerceContext;
        }

        /// <summary>
        ///     obtiene usuario por numero de documento
        /// </summary>
        /// <author>Diego Molina</author>
        /// <param name="user">entidad usuario para obtener los datos</param>
        public async Task<PruebaAppApi.DataAccess.Entities.User> GetUser(string documentNumber)
        {
            return await _linkticEcomerceContext.User.Where(x => x.DocumentNumber.Equals(documentNumber)).FirstOrDefaultAsync();
        }
    }
}