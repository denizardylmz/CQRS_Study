using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Context;
using BusinessLayer.CQRS.Commands.Request;
using BusinessLayer.CQRS.Commands.Response;
using BusinessLayer.CQRS.Handlers.CommandHandlers;
using BusinessLayer.CQRS.Quaries.Request;
using BusinessLayer.CQRS.Quaries.Response;
using Database_Logic.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace UI_API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private readonly IMediator _mediator;


        public TestController( IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommandRequest request)
        {
            CreateProductCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }
        
        
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteProductCommandRequest request)
        {
            DeleteProductCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]GetAllProductQueryRequest request)
        {
            GetAllProductQueryResponse response = await _mediator.Send(request);
            
            return Ok(response);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdProductQueryRequest request)
        {
            GetByIdProductQueryResponse response = await _mediator.Send(request);

            return Ok(response);
        }
        
    }
}
