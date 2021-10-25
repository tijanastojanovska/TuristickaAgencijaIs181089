using System;
using System.Collections.Generic;
using System.Text;
using TuristickaAgencijaIS181089.Domain.DomainModels;

namespace TuristickaAgencijaIS181089.Services.Interfaces
{
    public interface ICompanyService
    {
        List<Company> GetAllCompanies();
        Company GetDetailsForCompany(Guid? id);
        void CreateNewCompany(Company c);
        void UpdateCompany(Company c);
         void DeleteCompany(Guid id);
       
    }
}
