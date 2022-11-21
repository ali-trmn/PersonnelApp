using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonnelApp.API.Controllers.Base;
using PersonnelApp.Model.PersonnelDto;
using PersonnelApp.Model.Shared;
using PersonnelApp.Service;

namespace PersonnelApp.API.Controllers
{

    public class PersonnelController : BaseController
    {


        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public ActionResult<ResultList<PersonelOut>> GetAll()
        {
            try
            {
                PersonnelManager personnel = new();
                List<PersonelOut> result = personnel.GetAll();

                return Ok(new ResultList<PersonelOut> { Data = result, Success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultList<PersonelOut> { Success = false, Message = ex.Message });
            }



        }

        [HttpGet("Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<Result<PersonelOut>> Get(int personnelId)
        {
            try
            {
                PersonnelManager personnelManager = new();
                PersonelOut result = personnelManager.Get(personnelId);
                return Ok(new Result<PersonelOut> { Data = result, Success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultList<PersonelOut> { Success = false, Message = ex.Message });
            }


        }

        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<Result> Add([FromBody] AddPersonelInput addPersonelInput)
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

                return Ok(new Result { Message="Kayıt işlemi başarılı", Success=true});
            }
            catch (Exception ex)
            {

                return BadRequest(new Result { Message = ex.Message, Success = false });
            }
        }


        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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


        [HttpGet("GetAllNonDeleted")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<ResultList<PersonelOut>> GetAllNonDeleted()
        {
            try
            {
                PersonnelManager personnelManager = new();
                List<PersonelOut> result = personnelManager.GetAllNonDelete();
                return Ok(new ResultList<PersonelOut> { Data = result, Success = true });
            }
            catch (Exception ex)
            {

                return BadRequest(new ResultList<PersonelOut> { Success = false, Message = ex.Message });
            }
            
        }

        [HttpGet("SetActive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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

        [HttpGet("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
