﻿
using Domain.Entities.Entity;
using Domain.Services.Base;
using Library.Helpers.APIUtilities;
using Models.ViewModel.Category;
using Models.ViewModel.Communications;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstracts.Administration
{
   public interface ICommunicationsService : IBaseApiService<Communications, CommunicationsVm, ResCommunicationsVm, int, int>
    {

    }

}
