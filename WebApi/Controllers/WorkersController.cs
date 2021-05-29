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
        public IEnumerable<WorkerModel> GetWorkers()
        {
            return _mapper.Map<IEnumerable<WorkerModel>>(_dataRep.GetWorkers());
        }

        [HttpPost]
        public IActionResult CreateWorker([FromBody] WorkerModel workerDTO)
        {
            _dataRep.CreateWorker(_mapper.Map<Worker>(workerDTO));

            return Ok();
        }

        [HttpGet("{id:int}")]
        public WorkerModel GetWorker(int id)
        {
            return _mapper.Map<WorkerModel>(_dataRep.GetWorker(id));
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateWorker(int id, [FromBody] WorkerModel workerDTO)
        {
            workerDTO.WorkerId = id;
            _dataRep.UpdateWorker(_mapper.Map<Worker>(workerDTO));

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteWorker(int id)
        {
            _dataRep.DeleteWorker(id);

            return Ok();
        }
    }
}
