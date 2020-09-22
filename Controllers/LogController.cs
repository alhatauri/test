using Log.Abstractions;
using Log.Extensions;
using Log.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Log.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        readonly ICacheService<object, Logs, long> _logService;
        readonly ISerializer _serializer;
        public LogController(ICacheService<object, Logs, long> logService, ISerializer serializer)
        {
            _logService = logService ?? throw new NullReferenceException(nameof(logService));
            _serializer = serializer;
        }

        [HttpGet("{id}")]
        public ActionResult<object> Get(long id)
        {
            var item = _logService.Get(id);

            if (item == null)
                return NotFound();

            return item;
        }

        [HttpPost]
        public ActionResult Post([FromBody] object body)
        {
            if (body == null)
                return BadRequest(ModelState);

            var id = _logService.Create(body);

            return CreatedAtAction(nameof(Get), new { id = id }, "json");
        }

        [HttpPatch("{id}")]
        public ActionResult Patch(long id, [FromBody] JsonPatchDocument patch)
        {
            if (patch == null)
                return BadRequest(ModelState);

            IDictionary<string, object> item = new ExpandoObject();
            patch.ApplyTo(item);

            var value = item.FirstOrDefault().Value as JObject;
            if (value == null)
                return BadRequest(ModelState);

            _logService.Update(new Logs { LogsId = id, Info = _serializer.Serialize(value) });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<object> Delete(long id)
        {
            return _logService.Delete(id);
        }
    }
}
