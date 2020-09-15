using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwareMD.BusinessLayer;
using AwareMD.DataLayer.Repositories;
using AwareMD.EntityLayer.Models;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.BindingModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestWebApi.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return _unitOfWork.Patients.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Patient pat = _unitOfWork.Patients.GetById(id);

            if (pat != null)
            {
                return new JsonResult(pat);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post([FromForm] PatientPostBM inputs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                PatientLogic aptLogic = new PatientLogic(_unitOfWork);

                Patient pat;
                inputs.ConvertTo(out pat);

                try
                {
                    Patient result = aptLogic.Create(pat);

                    if (result != null)
                    {
                        return new JsonResult(result);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
        }

        [HttpPut()]
        public IActionResult Put([FromForm] PatientPutBM inputs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                PatientLogic patLogic = new PatientLogic(_unitOfWork);

                try
                {
                    if (patLogic.Update(inputs.Id, inputs.FirstName, inputs.LastName, inputs.DateOfBirth) > 0)
                    {
                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            PatientLogic patLogic = new PatientLogic(_unitOfWork);

            try
            {
                int deleted = patLogic.DeleteCascade(id);
                //int deleted = patLogic.Delete(id);
                if (deleted > 0)
                {
                    return Ok();
                }
                //else if (deleted== -1 )
                //{
                //    return BadRequest("Cascade delete is not allowed");
                //}
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
