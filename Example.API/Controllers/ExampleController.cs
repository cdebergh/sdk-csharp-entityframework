using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Example.Data.Abstract;
using Example.Model;
using Example.API.ViewModels;
using AutoMapper;
using Example.API.Core;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Example.API.Controllers
{
    [Route("api/examples")]
    public class ExampleController : Controller
    {
        private IExampleRepository _exampleRepository;

        int page = 1;
        int pageSize = 10;
        public ExampleController(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pagination = Request.Headers["Pagination"];

            if (!string.IsNullOrEmpty(pagination))
            {
                string[] vals = pagination.ToString().Split(',');
                int.TryParse(vals[0], out page);
                int.TryParse(vals[1], out pageSize);
            }

            int currentPage = page;
            int currentPageSize = pageSize;
            var totalExampleEntitys = _exampleRepository.Count();
            var totalPages = (int)Math.Ceiling((double)totalExampleEntitys / pageSize);

            IEnumerable<ExampleEntity> _ExampleEntitys = _exampleRepository
                .GetAll()
                .OrderBy(u => u.Id)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();

            IEnumerable<ExampleViewModel> _ExampleEntitysVM = Mapper.Map<IEnumerable<ExampleEntity>, IEnumerable<ExampleViewModel>>(_ExampleEntitys);

            Response.AddPagination(page, pageSize, totalExampleEntitys, totalPages);

            return new OkObjectResult(_ExampleEntitysVM);
        }

        [HttpGet("{id}", Name = "GetExampleEntity")]
        public IActionResult Get(int id)
        {
            ExampleEntity _ExampleEntity = _exampleRepository.GetSingle(u => u.Id == id);

            if (_ExampleEntity != null)
            {
                ExampleViewModel _ExampleEntityVM = Mapper.Map<ExampleEntity, ExampleViewModel>(_ExampleEntity);
                return new OkObjectResult(_ExampleEntityVM);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody]ExampleViewModel ExampleEntity)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ExampleEntity _newExampleEntity = new ExampleEntity { Name = ExampleEntity.Name };

            _exampleRepository.Add(_newExampleEntity);
            _exampleRepository.Commit();

            ExampleEntity = Mapper.Map<ExampleEntity, ExampleViewModel>(_newExampleEntity);

            CreatedAtRouteResult result = CreatedAtRoute("GetExampleEntity", new { controller = "ExampleEntitys", id = ExampleEntity.Id }, ExampleEntity);
            return result;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ExampleViewModel ExampleEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ExampleEntity _ExampleEntityDb = _exampleRepository.GetSingle(id);

            if (_ExampleEntityDb == null)
            {
                return NotFound();
            }
            else
            {
                _ExampleEntityDb.Name = ExampleEntity.Name;
                _exampleRepository.Commit();
            }

            ExampleEntity = Mapper.Map<ExampleEntity, ExampleViewModel>(_ExampleEntityDb);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ExampleEntity exampleEntity = _exampleRepository.GetSingle(id);

            if (exampleEntity == null)
            {
                return new NotFoundResult();
            }
            else
            {
                _exampleRepository.Delete(exampleEntity);

                _exampleRepository.Commit();

                return new NoContentResult();
            }
        }
    }
}
