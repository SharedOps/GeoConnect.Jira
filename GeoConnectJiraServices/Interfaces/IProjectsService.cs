﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  GeoConnectJiraServices.Models;

namespace GeoConnectJiraServices.Interfaces
{
   public interface IProjectsService
    {

        //Method signature for Projects

        Task<int> AddProject(AddProject project);


    }
}
