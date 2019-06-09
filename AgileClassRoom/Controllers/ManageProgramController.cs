using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using AgileClassRoom.Interface;
using AgileClassRoom.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgileClassRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageProgramController : ControllerBase
    {

        private readonly IProgram _program;
        public ManageProgramController(IProgram program)
        {

            _program = program;
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody] ProgramViewModel program)
        {
            if (ModelState.IsValid)
            {


                var userId = this.User.FindFirstValue(ClaimTypes.Name);
                var tempPrograms = AutoMapper.Mapper.Map<AgileClassRoom.Models.Program>(program);
                _program.InsertProgram(tempPrograms);

                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK
                };

                return response;

            }
            else
            {
                var response = new HttpResponseMessage()
                {

                    StatusCode = HttpStatusCode.BadRequest
                };

                return response;
            }

        }
        [HttpGet]
        public IEnumerable<ProgramViewModel> Get()
        {
            return _program.GetAllPrograms();
        }
        
        [HttpGet("{id}", Name = "GetProgram")]
        public ProgramViewModel GetProgramId(int ProgramId)
        {
            return _program.GetProgrambyId(ProgramId);
        }

        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody] ProgramViewModel programViewModel)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.Name);
                var tempProgram = AutoMapper.Mapper.Map<AgileClassRoom.Models.Program>(programViewModel);
                _program.UpdateProgram(tempProgram);
                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK
                };

                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
                return response;
            }
        }
        
        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {

                _program.DeleteProgram(id);
                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK
                };

                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
                return response;
            }
        }


    }
}
