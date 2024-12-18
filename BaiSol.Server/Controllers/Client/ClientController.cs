﻿using AuthLibrary.DTO;
using AuthLibrary.Models;
using ClientLibrary.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaiSol.Server.Controllers.Client
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize(Roles = UserRoles.Client)]
    public class ClientController(IClientProject _clientProject) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetClientProjectId(string userEmail)
        {
            var id = await _clientProject.GetClientProject(userEmail);
            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetClientProjectHistory(string userEmail)
        {
            var history = await _clientProject.GetClientProjectHistory(userEmail);
            return Ok(history);
        }

        [HttpGet]
        public async Task<IActionResult> NotificationMessages(string userEmail)
        {
            var notifs = await _clientProject.NotificationMessages(userEmail);


            return Ok(new
            {
                notifs = notifs,
                notifCount = notifs.Count(w => !w.isRead)
            });
        }

        [HttpGet]
        public async Task<IActionResult> NotificationMessage(int notifId)
        {
            var notifs = await _clientProject.NotificationMessage(notifId);
            return Ok(notifs);
        }
        [HttpPut]
        public async Task<IActionResult> ReadNotif(int notifId, string clientEmail)
        {
            await _clientProject.ReadNotif(notifId);
            return Ok();
        }

    }
}
