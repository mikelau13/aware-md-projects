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
    [Route("api/appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Appointment> Get()
        {
            AppointmentLogic aptLogic = new AppointmentLogic(_unitOfWork);

            return aptLogic.ReadAll();
        }

        // GET api/appointment/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            AppointmentLogic aptLogic = new AppointmentLogic(_unitOfWork);

            Appointment apt = aptLogic.ReadById(id);

            if (apt != null)
            {
                return new JsonResult(apt);
            }
            else 
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post(AppointmentPostBM inputs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                AppointmentLogic aptLogic = new AppointmentLogic(_unitOfWork);

                Appointment apt;
                inputs.ConvertTo(out apt);

                try
                {
                    Appointment result = aptLogic.Create(apt);

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
        public IActionResult Put(AppointmentPutBM inputs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                AppointmentLogic aptLogic = new AppointmentLogic(_unitOfWork);

                try
                {
                    if (aptLogic.Update(inputs.Id, inputs.PatientId, inputs.AppointmentTime, inputs.Notes) > 0)
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
            AppointmentLogic aptLogic = new AppointmentLogic(_unitOfWork);

            try
            {
                if (aptLogic.Delete(id) > 0)
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
}
