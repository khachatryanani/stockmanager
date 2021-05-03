using AutoMapper;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IDataRepository _dataRep;
        private readonly IMapper _mapper;

        public WorkersController(IDataRepository dataRep, IMapper mapper)
        {
            _dataRep = dataRep;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<WorkerDTO> GetWorkers()
        {
            return _mapper.Map<IEnumerable<WorkerDTO>>(_dataRep.GetWorkers());
        }

        [HttpGet("{id:int}")]
        public WorkerDTO GetWorker(int id)
        {
            return _mapper.Map<WorkerDTO>(_dataRep.GetWorker(id));
        }

        [HttpPost]
        public IActionResult CreateWorker([FromQuery] WorkerDTO workerDTO)
        {
            _dataRep.CreateWorker(_mapper.Map<Worker>(workerDTO));

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteWorker(int id)
        {
            _dataRep.DeleteWorker(id);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateWorker([FromQuery]WorkerDTO workerDTO)
        {
            _dataRep.UpdateWorker(_mapper.Map<Worker>(workerDTO));

            return Ok();
        }
    }
}
