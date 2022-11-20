using PersonnelApp.Data.UOW;
using PersonnelApp.Entities;
using PersonnelApp.Model.PersonnelDto;
using PersonnelApp.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelApp.Service
{
    public class PersonnelManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonnelManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PersonnelManager()
        {
            _unitOfWork = new UnitOfWork();
        }

        public void Insert (AddPersonelInput addPersonelInput)
        {
            try
            {
                Personnel personnel = new()
                {
                    Name = addPersonelInput.Name,
                    Surname = addPersonelInput.Surname,
                    Username = addPersonelInput.Username,
                    FileName = addPersonelInput.FileName,
                    CreatedBy = 0,
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,

                };
                _unitOfWork.personnel.Add(personnel);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<PersonelOut> GetAll()
        {
            List<PersonelOut> personelOuts = _unitOfWork.personnel.GetAll().ToDto().ToList();
            return personelOuts;
        }

        public PersonelOut Get(int personnelId)
        {
            PersonelOut personelOut = _unitOfWork.personnel.Get(p => p.Id == personnelId).ToDto();
            return personelOut;
        }

        public void Delete(int personnelId)
        {
            try
            {
                Personnel personnel = _unitOfWork.personnel.Get(p=>p.Id== personnelId);
                personnel.IsDeleted = true;
                personnel.DeletedDate = DateTime.Now;
                personnel.DeletedBy = 0;
                _unitOfWork.personnel.Update(personnel);
                _unitOfWork.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Update(PersonelUpdateDto personelUpdateDto, int personnelId)
        {
            try
            {
                Personnel personnel = _unitOfWork.personnel.Get(p => p.Id == personnelId);
                personnel.ModifiedDate = DateTime.Now;
                personnel.ModifiedBy = 0;
                personnel.FileName = personelUpdateDto.FileName;
                personnel.Name = personelUpdateDto.Name;
                personnel.Surname = personelUpdateDto.Surname;
                personnel.Username = personelUpdateDto.Username;
                _unitOfWork.personnel.Update(personnel);
                _unitOfWork.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<PersonelOut> GetAllNonDelete()
        {
            List<PersonelOut> personelOut = GetAll();
            personelOut = personelOut.Where(p => !p.IsDeleted).ToList();
            return personelOut;
        }

        public void SetActive(int personnelId)
        {
            try
            {
                Personnel personnel = _unitOfWork.personnel.Get(p => p.Id == personnelId);
                personnel.IsDeleted = false;
                personnel.ModifiedDate= DateTime.Now;
                personnel.ModifiedBy = 1;
                _unitOfWork.personnel.Update(personnel) ;
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
