using PersonnelApp.Entities;
using PersonnelApp.Model.PersonnelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelApp.Service.Mapping
{
    public static class Mapper
    {
        public static PersonelOut ToDto(this Personnel personnel)
        {
            return new PersonelOut { FileName = personnel.FileName, Name=personnel.Name,Surname=personnel.Surname, Username= personnel.Username, CreatedDate = personnel.CreatedDate, Id=personnel.Id, IsDeleted=personnel.IsDeleted };
        }
        public static IEnumerable<PersonelOut> ToDto(this IEnumerable<Personnel> personnel)
        {
            return personnel.Select(p=>p.ToDto());
        }
    }
}
