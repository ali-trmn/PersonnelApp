using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonnelApp.Model.PersonnelDto;
using PersonnelApp.Service;

namespace PersonnelApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PersonnelController : ControllerBase
    {
        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles ="Admin")]
        public List<PersonelOut> GetAll()
        {
            PersonnelManager personnel = new();
            return personnel.GetAll();
        }

        [HttpGet]
        [Route("Get")]
        public PersonelOut Get(int personnelId)
        {
            PersonnelManager personnelManager = new();
            return personnelManager.Get(personnelId);
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add([FromBody]AddPersonelInput addPersonelInput)
        {
            try
            {
                PersonnelManager personnelManager = new();

                string[] fileBytesStringFormat = addPersonelInput.File.Split(',');
                byte[] fileByte = new byte[fileBytesStringFormat.Length];

                for (int i = 0; i < fileBytesStringFormat.Length; i++)
                {
                    fileByte[i] = Convert.ToByte(fileBytesStringFormat[i]);
                }
                System.IO.File.WriteAllBytes(Directory.GetCurrentDirectory() + "/wwwroot/" + addPersonelInput.FileName, fileByte);

                personnelManager.Insert(addPersonelInput);

                return Ok("Personel ekleme işlemi başarılı.");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult Update([FromBody] PersonelUpdateDto personelUpdateDto, int personnelId)
        {
            try
            {
                PersonnelManager personnelManager = new();
                personnelManager.Update(personelUpdateDto, personnelId);

                return Ok("Personel bilgileri güncellendi.");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }
        [HttpGet]
        [Route("GetAllNonDeleted")]
        public List<PersonelOut> GetAllNonDeleted()
        {
            PersonnelManager personnelManager = new();
            return personnelManager.GetAllNonDelete();
        }

        [HttpGet]
        [Route("SetActive")]
        public ActionResult SetActive(int personnelId)
        {
            try
            {
                PersonnelManager personnelManager = new();
                personnelManager.SetActive(personnelId);

                return Ok("İşlem başarılı");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Delete")]
        public ActionResult Delete(int personnelId)
        {
            try
            {
                PersonnelManager personnelManager = new();
                personnelManager.Delete(personnelId);

                return Ok("Kayıt başarılıyla silindi");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
