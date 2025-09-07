﻿using POS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        List<Role> GetByUsername(string username);
        Role GetByKey(int id);
        List<Role> GetAll();
        int Create(Role item);
        int Update(Role item);
        int Delete(int id);
    }
}
