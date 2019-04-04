﻿using CorePacs.DataAccess.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using CorePacs.WebServer.Helpers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.IO;
using CorePacs.DataAccess.Domain;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CorePacs.Dicom.Contracts;


namespace CorePacs.WebServer.Controllers
{
    [Route("api/v1/[controller]")]
    public class SettingsController : MasterBaseController<Settings,int>
    {
        public SettingsController(ISettingsRepository masterRepository)
        {
            if (masterRepository == null) throw new ArgumentNullException(nameof(masterRepository));
            this._masterRepository = masterRepository;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            return Ok(this._masterRepository.Delete(id).GetAwaiter().GetResult());
        }

        [HttpGet]
        [Route("byid/{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok(this._masterRepository.Get(id).GetAwaiter().GetResult());
        }
    }
}
