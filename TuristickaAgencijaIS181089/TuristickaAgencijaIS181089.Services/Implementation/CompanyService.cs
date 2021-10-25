using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TuristickaAgencijaIS181089.Domain.DomainModels;
using TuristickaAgencijaIS181089.Repository.Interfaces;
using TuristickaAgencijaIS181089.Services.Interfaces;

namespace TuristickaAgencijaIS181089.Services.Implementation
{
   public class CompanyService: ICompanyService
    {
        private readonly IRepository<Company> _companyRepository;
        public CompanyService(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public void CreateNewCompany(Company c)
        {
            this._companyRepository.Insert(c);
        }

        public void DeleteCompany(Guid id)
        {
            var Company = this.GetDetailsForCompany(id);
            this._companyRepository.Delete(Company);
        }

        public List<Company> GetAllCompanies()
        {
            return this._companyRepository.GetAll().ToList();
        }
        public Company GetDetailsForCompany(Guid? id)
        {
            return this._companyRepository.Get(id);
        }
        public void UpdateCompany(Company c)
        {
            this._companyRepository.Update(c);
        }

    }
}
