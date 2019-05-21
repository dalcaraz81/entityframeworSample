using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Business.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeBusinessLogic business;

        public EmployeeController() {
            
            this.business = new EmployeeBusinessLogic();
        }
        // GET api/employee
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeView>> Get()
        {
            return this.business.GetAll();
        }

        // GET api/employee/5
        [HttpGet("{id}")]
        public ActionResult<EmployeeView> Get(int id)
        {
            return this.business.GetAll().Where(e => e.Id == id).FirstOrDefault();
        }

        // POST api/employee
        [HttpPost]
        public ActionResult<Message> Post([FromBody] EmployeeView employee)
        {
            bool inserted = false;
            Message msg = new Message() { Msg="",Success= false, ErrorCode=0,ErrorMessage=""};
            try
            {
                inserted = this.business.Create(employee);
                if (inserted) {
                    msg.Msg = "success";
                    msg.Success = true;
                }
            }
            catch (Exception ex)
            {
                //TODO
                //Implementar las excepciones correctas junto a sus códigos
                msg.ErrorMessage = ex.Message;
                msg.ErrorCode = 1;
                msg.Success = false;
            }
            
            return msg;
        }


        // PUT api/employee/5
        [HttpPut("{id}")]
        public ActionResult<Message> Put(Int64 id, [FromBody] EmployeeView employee)
        {
            bool updated = false;
            Message msg = new Message() { Msg = "", Success = false, ErrorCode = 0, ErrorMessage = "" };
            try
            {
                employee.Id = id;
                updated = this.business.Update(employee);
                if (updated)
                {
                    msg.Msg = "success";
                    msg.Success = true;
                }
            }
            catch (Exception ex)
            {
                //TODO
                //Implementar las excepciones correctas junto a sus códigos
                msg.ErrorMessage = ex.Message;
                msg.ErrorCode = 1;
                msg.Success = false;
            }

            return msg;
        }

        // DELETE api/employee/5
        [HttpDelete("{id}")]
        public ActionResult<Message> Delete(int id)
        {
            bool deleted = false;
            Message msg = new Message() { Msg = "", Success = false, ErrorCode = 0, ErrorMessage = "" };
            try
            {
                EmployeeView employee = this.business.GetAll().Where(e => e.Id == id).FirstOrDefault();
                if (employee != null)
                {
                    deleted = this.business.Delete(employee);
                }
                else {
                    msg.ErrorCode = -4;
                    msg.ErrorMessage = "usuario no existe";
                } 
                if (deleted)
                {
                    msg.Msg = "success";
                    msg.Success = true;
                }
            }
            catch (Exception ex)
            {
                //TODO
                //Implementar las excepciones correctas junto a sus códigos
                msg.ErrorMessage = ex.Message;
                msg.ErrorCode = 1;
                msg.Success = false;
            }

            return msg;
        }
    }
}
